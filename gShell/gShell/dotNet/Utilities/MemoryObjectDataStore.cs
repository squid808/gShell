using System;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Json;
using Google.Apis.Util.Store;

using gShell.dotNet.Utilities.OAuth2;

namespace gShell.dotNet.Utilities
{
    /// <summary>
    /// The data store that is used by the authorization flow from Google. Only called when authorizing.
    /// </summary>
    /// <remarks>
    /// Unfortunately, gShell needs to store tokens by more than just a single key - it needs three. one for the api,
    /// one for the domain and one for the user. Since some of these can't be determined until AFTER the user has been
    /// authorized (in the case where they don't provide the domain or user and no default is stored), normally our
    /// only option would be to just call the authorization again just to access the methods listed below, which is ugly.
    /// 
    /// Instead, I've decided to use this data store (which is necessary to run the client authentication) only as a
    /// shell to temporarily store the token when authorizing, after which we will manually have to save it any time we
    /// also call the Google Authorization. Loading the token also pulls from the variable, so we have to take care to 
    /// set it in advance, as well. 
    /// 
    /// The best way around this would be to allow the Auth Async to take not just a single string as a key, but an
    /// array thereof. However, this still wouldn't solve the issue of needing the username and domain, which needs
    /// a separate API call after we have the token and the authorization is complete.
    /// 
    /// See OAuth2Base for the rest of the logic related to this.
    /// </remarks>
    public class MemoryObjectDataStore : IDataStore
    {
        //private static string token { get; set; }

        #region IDataStore Implementation

        public Task ClearAsync()
        {
            return null;
        }

        public Task DeleteAsync<T>(string key)
        {
            return null;
        }

        /// <summary>Return the token, if there is one.</summary>
        /// <remarks>
        /// This is pretty much only called from Authorize at this point in time. It attempts to load the token from
        /// storage before making the user authenticate instead. In our case, we have manually loaded any possible
        /// token info in to OAuth2Base.currentAuthInfo, so that becomes our storage. This is looking for the token
        /// in serialized string form.
        /// 
        /// The AuthorizeAsync method then takes this token as part of the info and adds it to the 
        /// Oauth2Base.asyncUserCredential object, whether it was from the web or storage. It does NOT check for the
        /// token expiration, that happens in the services.
        /// </remarks>
        public Task<T> GetAsync<T>(string key)
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();

            if (OAuth2Base.currentAuthInfo.tokenString != null)
            {
                tcs.SetResult(NewtonsoftJsonSerializer.Instance.Deserialize<T>(OAuth2Base.currentAuthInfo.tokenString));
            }
            else
            {
                tcs.SetResult(default(T));
            }

            return tcs.Task;
        }

        /// <summary>
        /// Store a token.
        /// </summary>
        /// <remarks>
        /// This will occur as a result of either one of two scenarios. First, it will occur when first authorizing
        /// a user against Google in which case a brand new token is returned. Second, when a service attempts to
        /// use a token to make an API call and fails due to the token being expired.
        /// 
        /// While this overall class is a requirement for the Google APIs, it does not allow for enough information
        /// to store tokens in gShell (three strings - Domain, User, Api). As such, we must store that information
        /// elsewhere for use when storing. Similarly, if the Domain or User is missing, we must make a call to the
        /// OAuth service to gather that from the authenticating user's account.
        /// 
        /// We can also be almost 100% sure that T is going to be a TokenResponse, at least at the time of writing.
        /// </remarks>
        public Task StoreAsync<T>(string key, T value)
        {
            TokenResponse tokenResponse = value as TokenResponse; //null if not actually a TokenResponse

            //If we're authenticating we have to delay storing the token so that we can get the user info from google,
            // which uses information that is only created once authentication finishes. So, we toggle this off after
            // and then call this again.
            if (OAuth2Base.IsAuthenticating)
            {
                OAuth2Base.AuthTokenTempSwap = tokenResponse;
            } 
            else
            {
                if (tokenResponse != null)
                {
                    string tokenString = NewtonsoftJsonSerializer.Instance.Serialize(value);

                    //This should only matter when authenticating; if no tokens were able to be prefetched, these will
                    // be blank. When called from a service, we will have authenticated already.
                    if (OAuth2Base.currentAuthInfo.domain == null || OAuth2Base.currentAuthInfo.userName == null)
                    {
                        OAuth2Base.SetAuthenticatedUserInfo();
                    }

                    OAuth2Base.SaveToken(tokenString, tokenResponse);
                }
                else
                {
                    throw (new FormatException(string.Format(
                        "The API Authorization Token was received in an unexpected format: {0}.", typeof(T).ToString())));
                }
            }

            return TaskEx.Delay(0);
        }

        #endregion
    }
}

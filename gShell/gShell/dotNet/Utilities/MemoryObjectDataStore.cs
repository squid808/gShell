using System;
using System.Threading.Tasks;
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
    class MemoryObjectDataStore : IDataStore
    {
        private static string token { get; set; }

        #region IDataStore Implementation

        public Task ClearAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the token, if there is one. tokenTemp needs to be manually set prior to calling this by 
        /// authorizing, if possible.
        /// </summary>
        public Task<T> GetAsync<T>(string key)
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();

            if (token != null)
            {
                tcs.SetResult(NewtonsoftJsonSerializer.Instance.Deserialize<T>(token));
            }
            else
            {
                tcs.SetResult(default(T));
            }

            return tcs.Task;
        }

        public Task StoreAsync<T>(string key, T value)
        {
            token = NewtonsoftJsonSerializer.Instance.Serialize(value);
            return TaskEx.Delay(0);
        }

        #endregion

        /// <summary>Set the token for the data store to return when requested.</summary>
        public void SetToken(string Token)
        {
            token = Token;
        }

        public string GetToken()
        {
            return token;
        }
    }
}

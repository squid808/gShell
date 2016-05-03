using System;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.dotNet
{
    /// <summary>
    /// This class is a base for any classes that wish to wrap a google apps service with the gShell authentication
    /// logic. All that needs to be added aside from the virtual members is a wrapper of the services and their 
    /// methods in subclasses.
    /// </summary>
    /// <remarks>
    /// In this and other files, the flow assumes that before each API call the Authenticate() method is called, which
    /// in turn sets the OAuth2Base.currentAuthInfo, which contains the currently authenticated domain and user (and 
    /// possibly more).
    /// </remarks>
    public abstract class ServiceWrapper<T> where T : BaseClientService
    {
        #region Properties
        /// <summary>
        /// A collection of services keyed by the domain auth info. TODO: have an alternate set for gmail users
        /// </summary>
        public static Dictionary<AuthenticatedUserInfo, T> services { get; set; }

        /// <summary>
        /// A collection of service account services keyed by the domain auth info, then the service account user.
        /// </summary>
        public static Dictionary<AuthenticatedUserInfo, Dictionary<string, T>> serviceAccountServices { get; set; }

        /// <summary>
        /// Indicates if this set of services will work with Gmail (as opposed to Google Apps). 
        /// This will cause authentication to fail if false and the user attempts to authenticate with
        /// a gmail address.
        /// </summary>
        protected abstract bool worksWithGmail { get; }

        /// <summary>
        /// Returns the currently authenticated domain. This could be null if nothing has yet been authenticated.
        /// </summary>
        protected static string activeDomain
        {
            get
            {
                return OAuth2Base.currentAuthInfo.domain;
            }
        }

        public abstract string apiNameAndVersion { get; }
        #endregion

        #region Constructors
        public ServiceWrapper()
        {
            services = new Dictionary<AuthenticatedUserInfo, T>();
            serviceAccountServices = new Dictionary<AuthenticatedUserInfo, Dictionary<string, T>>();
        }
        #endregion

        #region Accessors
        /// <summary>
        /// Returns the loaded and authenticated service for this domain. Returns null if it doesn't exist.
        /// </summary>
        public static T GetService(AuthenticatedUserInfo AuthInfo, string serviceAccountUser = null)
        {
            if (string.IsNullOrWhiteSpace(serviceAccountUser))
            {
                if (services.ContainsKey(AuthInfo))
                {
                    return services[AuthInfo];
                }
            }
            else
            {
                if (serviceAccountServices.ContainsKey(AuthInfo)
                    && serviceAccountServices[AuthInfo].ContainsKey(serviceAccountUser))
                {
                    return serviceAccountServices[AuthInfo][serviceAccountUser];
                }
            }

            return null;
        }

        public static T GetService(string serviceAccountUser = null)
        {
            return GetService(OAuth2Base.currentAuthInfo, serviceAccountUser);
        }
        #endregion

        #region Authenticate
        /// <summary>
        /// Authenticates the given domain and creates a service for it, if necessary. 
        /// The process of authenticating will update the default and current domains.
        /// </summary>
        public AuthenticatedUserInfo Authenticate(string ApiNameAndVersion, IEnumerable<string> scopes, ClientSecrets secrets, string domain=null)
        {
            return OAuth2Base.Authenticate(ApiNameAndVersion, scopes, secrets, domain);
        }
        #endregion

        #region BuildService
        /// <summary>
        /// Initialize and return a new service with the given domain.
        /// </summary>
        protected abstract T CreateNewService(string domain, AuthenticatedUserInfo authInfo, string serviceAccountUser = null);

        /// <summary>
        /// Build the service and return the domain the service is working on.
        /// </summary>
        public AuthenticatedUserInfo BuildService(AuthenticatedUserInfo authInfo, string serviceAccountUser = null)
        {
            if (authInfo == null) {return null;}

            if (string.IsNullOrWhiteSpace(serviceAccountUser))
            {
                if (!services.ContainsKey(authInfo))
                {
                    //this sets the OAuth2Base current domain and default domain, if necessary
                    T service = CreateNewService(OAuth2Base.GetAppName(apiNameAndVersion), authInfo);

                    //current domain should be set at this point 
                    if (authInfo.domain == "gmail.com" && !worksWithGmail)
                    {
                        throw new Exception("This Google API is not available for a Gmail account.");
                    }
                    else
                    {
                        services.Add(authInfo, service);
                    }
                }
            }
            else
            {
                if (!serviceAccountServices.ContainsKey(authInfo))
                {
                    serviceAccountServices.Add(authInfo, new Dictionary<string,T>());
                }

                if (!serviceAccountServices[authInfo].ContainsKey(serviceAccountUser))
                {
                    T service = CreateNewService(OAuth2Base.GetAppName(apiNameAndVersion), authInfo, serviceAccountUser);

                    if (authInfo.domain == "gmail.com" && !worksWithGmail)
                    {
                        throw new Exception("This Google API is not available for a Gmail account.");
                    }
                    else
                    {
                        serviceAccountServices[authInfo].Add(serviceAccountUser, service);
                    }
                }
            }

            return authInfo;
        }

        #endregion
    }
}

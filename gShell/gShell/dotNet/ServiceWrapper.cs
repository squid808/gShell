using System;
using System.Collections.Generic;
using Google.Apis.Requests;
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
        /// A collection of services keyed by the domain name. TODO: have an alternate set for gmail users
        /// </summary>
        public static Dictionary<string, T> services { get; set; }

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
                return OAuth2Base.currentAuthInfo.authenticatedDomain;
            }
        }

        public abstract string apiNameAndVersion { get; }

        #endregion

        #region Constructors
        public ServiceWrapper()
        {
            services = new Dictionary<string, T>();
        }
        #endregion

        #region Accessors
        /// <summary>
        /// Returns the loaded and authenticated service for this domain. Returns null if it doesn't exist.
        /// </summary>
        public T GetService(string domain)
        {
            if (ContainsService(domain))
            {
                return services[domain];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Do the loaded and authenticated domains contain a service for this domain?
        /// </summary>
        public static bool ContainsService(string domain)
        {
            return services.ContainsKey(domain);
        }

        ///// <summary>
        ///// Returns the default domain. This could be null if nothing has yet been authenticated.
        ///// </summary>
        //protected static string GetDefaultDomain()
        //{
        //    return OAuth2Base.defaultDomain;
        //}

        ///// <summary>
        ///// Returns the currently authenticated domain. This could be null if nothing has yet been authenticated.
        ///// </summary>
        //protected static string GetCurrentDomain()
        //{
        //    return OAuth2Base.currentDomain;
        //}
        #endregion

        #region Authenticate
        /// <summary>
        /// Authenticates the given domain and creates a service for it, if necessary. 
        /// The process of authenticating will update the default and current domains.
        /// </summary>
        public AuthenticationInfo Authenticate(string apiNameAndVersion, IEnumerable<string> scopes)
        {
            return OAuth2Base.Authenticate(apiNameAndVersion, scopes);
        }
        #endregion

        #region BuildService
        /// <summary>
        /// Initialize and return a new service with the given domain.
        /// </summary>
        protected abstract T CreateNewService(string domain);

        ///// <summary>
        ///// Build the service and return the domain the service is working on.
        ///// </summary>
        //public string BuildService(string domain)
        //{
        //    if (string.IsNullOrWhiteSpace(domain) ||
        //        !services.ContainsKey(domain))
        //    {
        //        //this sets the OAuth2Base current domain and default domain, if necessary
        //        T service = CreateNewService(domain);

        //        //current domain should be set at this point 
        //        if (activeDomain == "gmail.com" && !worksWithGmail)
        //        {
        //            throw new Exception("This Google API is not available for a Gmail account.");
        //        }
        //        else
        //        {
        //            services.Add(activeDomain, service);

        //            return activeDomain;
        //        }
        //    }
        //    else
        //    {
        //        return domain;
        //    }
        //}

        #endregion

        //#region MultiPageResult Helpers



        //#endregion
    }
}

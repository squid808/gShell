using System;
using System.Collections.Generic;
using Google.Apis.Requests;
using Google.Apis.Services;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.dotNet
{
    /// <summary>
    /// This class is a base for any classes that wish to wrap a google apps service with the gShell authentication logic.
    /// All that needs to be added aside from the virtual members is a wrapper of the services and their methods in subclasses.
    /// </summary>
    public abstract class ServiceWrapper<T> where T : BaseClientService
    {
        #region Properties
        protected static abstract Dictionary<string, T> services = new Dictionary<string,T>();

        protected static virtual bool worksWithGmail;
        #endregion

        #region Accessors
        public static abstract T GetService(string domain)
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

        public static abstract bool ContainsService(string domain)
        {
            return services.ContainsKey(domain);
        }

        protected static string GetDefaultDomain()
        {
            return OAuth2Base.defaultDomain;
        }
        #endregion

        #region Authenticate
        /// <summary>
        /// Authenticates the given domain and creates a service for it, if necessary.
        /// </summary>
        public static string Authenticate(string domain)
        {
            return OAuth2Base.Authenticate(domain, BuildService);
        }
        #endregion

        #region BuildService
        /// <summary>
        /// Build the service and return the domain the service is working on.
        /// </summary>
        private static abstract string BuildService(string domain)
        {
            if (string.IsNullOrWhiteSpace(domain) ||
                !services.ContainsKey(domain))
            {
                //this sets the OAuth2Base current domain and default domain, if necessary
                T service = CreateNewService(domain);

                //current domain should be set at this point 
                if (OAuth2Base.currentDomain == "gmail.com" && !worksWithGmail)
                {
                    throw new Exception("This service is not available for a gmail account.");
                }
                else
                {
                    services.Add(OAuth2Base.currentDomain, service);

                    return OAuth2Base.currentDomain;
                }
            }
            else
            {
                return domain;
            }
        }

        /// <summary>
        /// Create a new instance of the service.
        /// </summary>
        private static virtual T CreateNewService(string domain);
        #endregion

        #region MultiPageResult Helpers
        


        #endregion
    }

    public class thing<T, U, V>
    {
        public string DoSome(string a, int b){
            return "Hi";
        }

        public int DoOther(string c, string d) {
            return 0;
        }
    }
}

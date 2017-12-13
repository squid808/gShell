using System.Collections.Generic;
using gShell.Cmdlets.Utilities.OAuth2;
using Google.Apis.Services;
using gShell.dotNet.Utilities.OAuth2;
using Google.Apis.Auth.OAuth2;

namespace gShell.dotNet
{
    public interface IServiceWrapper<T> where T : IClientService
    {
        string apiNameAndVersion { get; }

        /// <summary>
        /// Authenticates the given domain and creates a service for it, if necessary. 
        /// The process of authenticating will update the default and current domains.
        /// </summary>
        AuthenticatedUserInfo Authenticate(AuthenticatedUserInfo scopesAuthObj, ClientSecrets secrets);

        /// <summary>
        /// Build the service and return the domain the service is working on.
        /// </summary>
        AuthenticatedUserInfo BuildService(AuthenticatedUserInfo authInfo, string serviceAccountUser = null);
    }
}


using System.Security.Cryptography.X509Certificates;

namespace gShell.dotNet.Utilities.OAuth2
{
    /// <summary>A container for all necessary information for using a service account.</summary>
    public class ServiceAccount
    {
        public X509Certificate2 certificate { get; set; }

        public string privateKey { get; set; }

        public OAuth2Domain.CertTypeEnum certType { get; set; }

        public string email { get; set; }
    }
}

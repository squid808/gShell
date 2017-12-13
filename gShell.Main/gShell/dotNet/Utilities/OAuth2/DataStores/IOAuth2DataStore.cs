using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gShell.dotNet.Utilities.OAuth2.DataStores
{
    /// <summary>Save and load the OAuth Info to and from a datastore.</summary>
    public interface IOAuth2DataStore
    {
        string fileName { get; }
        string destFolder { get; set; }
        string destFile { get; }

        OAuth2Info LoadInfo();
        void SaveInfo(OAuth2Info infoToSave);
    }
}

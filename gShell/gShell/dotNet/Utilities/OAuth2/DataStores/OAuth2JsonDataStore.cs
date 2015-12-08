using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gShell.dotNet.Utilities.OAuth2.DataStores
{
    /// <summary>
    /// Responsible solely for the saving and loading of the OAuth2 information from a local serialized file.
    /// </summary>
    /// <remarks>
    /// This file is saved without encryption.
    /// </remarks>
    class OAuth2JsonDataStore : IOAuth2DataStore
    {
        public OAuth2Info LoadInfo()
        {
            throw new NotImplementedException();
        }

        public void SaveInfo(OAuth2Info infoToSave)
        {
            throw new NotImplementedException();
        }
    }
}

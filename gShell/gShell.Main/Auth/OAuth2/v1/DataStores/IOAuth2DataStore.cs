namespace gShell.Main.Auth.OAuth2.v1.DataStores
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

namespace gShell.Main.Auth.OAuth2.v1
{
    /// <summary>An easier-to-use version of the returned class of scope information.</summary>
    public class ScopeInfo
    {
        /// <summary>Scope name</summary>
        public string Name { get; set; }

        /// <summary>Scope description</summary>
        public string Description { get; set; }

        /// <summary>Scope uri</summary>
        public string Uri { get; set; }

        public ScopeInfo(string Name, string Description, string Uri)
        {
            this.Name = Name;
            this.Description = Description;
            this.Uri = Uri;
        }
    }
}

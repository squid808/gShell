namespace gShell.Main.Auth.OAuth2.v1
{
    public interface IApiInfo
    {
        ScopeInfo[] ScopeInfos { get; }

        string ApiName { get; }

        string ApiVersion { get; }

        string ApiNameAndVersion { get; }

        bool WorksWithGmail { get; }
    }
}

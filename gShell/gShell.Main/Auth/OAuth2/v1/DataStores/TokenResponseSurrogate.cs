using System.Runtime.Serialization;
using Google.Apis.Auth.OAuth2.Responses;

namespace gShell.Main.Auth.OAuth2.v1.DataStores
{
    public class TokenResponseSurrogate : ISerializationSurrogate
    {
        void ISerializationSurrogate.GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            TokenResponse token = (TokenResponse)obj;

            info.AddValue("AccessToken", token.AccessToken);
            info.AddValue("ExpiresInSeconds", token.ExpiresInSeconds);
            info.AddValue("Issued", token.IssuedUtc);
            info.AddValue("RefreshToken", token.RefreshToken);
            info.AddValue("Scope", token.Scope);
            info.AddValue("TokenType", token.TokenType);
        }

        object ISerializationSurrogate.SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            TokenResponse token = (TokenResponse)obj;

            token.AccessToken = info.GetString("AccessToken");
            token.ExpiresInSeconds = info.GetInt64("ExpiresInSeconds");
            token.IssuedUtc = info.GetDateTime("Issued");
            token.RefreshToken = info.GetString("RefreshToken");
            token.Scope = info.GetString("Scope");
            token.TokenType = info.GetString("TokenType");

            return token;
        }
    }
}
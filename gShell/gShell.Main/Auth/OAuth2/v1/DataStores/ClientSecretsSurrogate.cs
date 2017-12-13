using System.Runtime.Serialization;
using Google.Apis.Auth.OAuth2;

namespace gShell.Main.Auth.OAuth2.v1.DataStores
{
    public class ClientSecretsSurrogate : ISerializationSurrogate
    {
        void ISerializationSurrogate.GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            ClientSecrets secrets = (ClientSecrets)obj;

            info.AddValue("ClientId", secrets.ClientId);
            info.AddValue("ClientSecret", secrets.ClientSecret);
        }

        object ISerializationSurrogate.SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            ClientSecrets secrets = (ClientSecrets)obj;

            secrets.ClientId = info.GetString("ClientId");
            secrets.ClientSecret = info.GetString("ClientSecret");

            return secrets;
        }
    }
}
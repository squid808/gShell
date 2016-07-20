using System;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;

namespace gShell.dotNet.Utilities.OAuth2.DataStores
{
    /// <summary>
    /// Responsible solely for the saving and loading of the OAuth2 information from a local serialized file.
    /// </summary>
    /// <remarks>
    /// This file is saved with encryption based on the user currently executing the assembly.
    /// </remarks>
    class OAuth2BinDataStore : DataStoreBase, IOAuth2DataStore
    {
        #region Parameters
        
        private static byte[] s_aditionalEntropy = { 8, 4, 5, 6, 6, 5, 6, 5, 9, 7, 2, 5, 9, 6, 1, 7, 3, 9 };

        public override string fileName { get { return "gShell_OAuth2.bin"; } }

        #endregion

        public OAuth2BinDataStore(string DestinationFolder) : base(DestinationFolder) { }

        #region Interface Implementation

        public override OAuth2Info LoadInfo()
        {
            OAuth2Info savedInfo = null;

            if (File.Exists(destFile))
            {
                byte[] protectedArray = System.IO.File.ReadAllBytes(destFile);

                byte[] byteArray = ProtectedData.Unprotect(protectedArray, s_aditionalEntropy,
                    DataProtectionScope.CurrentUser);

                using (MemoryStream memoryStream = new MemoryStream(byteArray))
                {

                    SurrogateSelector selector = new SurrogateSelector();

                    selector.AddSurrogate(typeof(ClientSecrets),
                        new StreamingContext(StreamingContextStates.All),
                        new ClientSecretsSurrogate());

                    selector.AddSurrogate(typeof(TokenResponse),
                        new StreamingContext(StreamingContextStates.All),
                        new TokenResponseSurrogate());

                    IFormatter deserializer = new BinaryFormatter();

                    deserializer.SurrogateSelector = selector;

                    try
                    {
                        savedInfo = (OAuth2Info)deserializer.Deserialize(memoryStream);
                    }
                    catch
                    {
                        throw new System.InvalidOperationException(
                            string.Format(
                            "Saved authentication out of date. Please delete {0} and try again. (see Remove-Item)",
                            destFile));
                    }
                }
            }

            //ThrowNoOauthSettingsError();
            return savedInfo;
        }

        public override void SaveInfo(OAuth2Info infoToSave)
        {
            CheckOrCreateDirectory();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                SurrogateSelector selector = new SurrogateSelector();
                
                selector.AddSurrogate(typeof(ClientSecrets),
                    new StreamingContext(StreamingContextStates.All),
                    new ClientSecretsSurrogate());

                selector.AddSurrogate(typeof(TokenResponse),
                    new StreamingContext(StreamingContextStates.All),
                    new TokenResponseSurrogate());

                IFormatter serializer = new BinaryFormatter();

                serializer.SurrogateSelector = selector;

                serializer.Serialize(memoryStream, infoToSave);

                byte[] byteArray = memoryStream.ToArray();
                byte[] protectedArray = ProtectedData.Protect(byteArray, s_aditionalEntropy,
                    DataProtectionScope.CurrentUser);

                System.IO.File.WriteAllBytes(destFile, protectedArray);
            }
        }

        #endregion
    }

    #region Serialization Surrogates

    public class TokenResponseSurrogate : ISerializationSurrogate
    {
        void ISerializationSurrogate.GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            TokenResponse token = (TokenResponse)obj;

            info.AddValue("AccessToken", token.AccessToken);
            info.AddValue("ExpiresInSeconds", token.ExpiresInSeconds);
            info.AddValue("Issued", token.Issued);
            info.AddValue("RefreshToken", token.RefreshToken);
            info.AddValue("Scope", token.Scope);
            info.AddValue("TokenType", token.TokenType);
        }

        object ISerializationSurrogate.SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            TokenResponse token = (TokenResponse)obj;

            token.AccessToken = info.GetString("AccessToken");
            token.ExpiresInSeconds = info.GetInt64("ExpiresInSeconds");
            token.Issued = info.GetDateTime("Issued");
            token.RefreshToken = info.GetString("RefreshToken");
            token.Scope = info.GetString("Scope");
            token.TokenType = info.GetString("TokenType");

            return token;
        }
    }

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

    #endregion
}

using System;
using System.Collections.Generic;

using gShell.dotNet;
using gShell.dotNet.Utilities;
using gShell.dotNet.Utilities.OAuth2;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell_dotNetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //You need to pick the scopes you plan on giving gShell permission to. You can use the string from the website or from the services.
            HashSet<string> scopes = new HashSet<string>();
            //Add this one first, it's always required.
            scopes.Add(Google.Apis.Oauth2.v2.Oauth2Service.Scope.UserinfoEmail);
            // you could also add "https://www.googleapis.com/auth/userinfo.email" if you don't want to add references to that package

            scopes.Add(DirectoryService.Scope.AdminDirectoryUser);

            //Set the scopes to the OAuth2Base
            //OAuth2Base.SetScopes(scopes);

            //Determind your domain
            Console.WriteLine("Please enter a user in your domain:");
            string email = Console.ReadLine();

            string domain = Utils.GetDomainFromEmail(email);
            string user = Utils.GetUserFromEmail(email);

            //Create a new Directory object from the gShell.dotNet namespace
            Directory directory = new Directory();

            ClientSecrets secrets = OAuth2Base.infoConsumer.GetDefaultClientSecrets();

            try
            {
                gShell.dotNet.Utilities.OAuth2.AuthenticatedUserInfo authInfo = 
                    directory.Authenticate(directory.apiNameAndVersion, scopes, secrets);

                //Tell your domain to authenticate and build the service
                directory.BuildService(authInfo);

                //Get the full email address of the user with the authenticated domain, just in case.
                email = Utils.GetFullEmailAddress(email, authInfo.domain);

                //We make the method call, using the full email since it asks for a userKey
                User result = directory.users.Get(email);

                //Let's look at some of the info we found:
                Console.WriteLine("Email: " + result.PrimaryEmail);
                Console.WriteLine("Given Name: " + result.Name.GivenName);
                Console.WriteLine("Family Name: " + result.Name.FamilyName);
                Console.WriteLine("Aliases: " + result.Aliases.Count.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPress any key to exit");
            Console.ReadLine();
        }
    }
}

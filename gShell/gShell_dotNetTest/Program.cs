using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gShell.dotNet;
//using Google.Apis.Admin.Directory.directory_v1
//using Google.Apis.Admin.Directory.directory_v1.Data;
using Google.Apis.Discovery.v1;
using Google.Apis.Discovery.v1.Data;

namespace gShell_dotNetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DiscoveryService service = new DiscoveryService(new gShell.dotNet.CustomSerializer.gInitializer());

            DirectoryList dlist = service.Apis.List().Execute();

            foreach (DirectoryList.ItemsData data in dlist.Items)
            {

                RestDescription getRests = service.Apis.GetRest(data.Name, data.Version).Execute();

                if (getRests.Auth != null)
                {
                    Console.WriteLine(data.Name + " " + data.Version);

                    foreach (string key in getRests.Auth.Oauth2.Scopes.Keys)
                    {
                        Console.WriteLine(key);
                        Console.WriteLine(getRests.Auth.Oauth2.Scopes[key]);
                    }
                }
            }

            //Console.WriteLine("Please enter the domain:");
            //string Domain = Console.ReadLine();

            //Directory directory = new Directory();
            
            //try
            //{
            //    directory.Authenticate(Domain);

            //    List<User> result = directory.users.List(new Directory.Users.UsersListProperties()
            //    {
            //        domain = Domain
            //    });

            //    Console.WriteLine(result[0].PrimaryEmail);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.WriteLine("\nPress any key to exit");
            //Console.ReadLine();
        }
    }
}

//using System.Collections.Generic;
//using System.Management.Automation;
//using System.Linq;
//using Data = Google.Apis.admin.Directory.directory_v1.Data;

//namespace gShell.Cmdlets.Directory.GAUser
//{
//    [Cmdlet(VerbsCommon.Get, "GAUser",
//          DefaultParameterSetName = "OneUser",
//          SupportsShouldProcess = true,
//          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAUser")]
//    public class GetGAUser : DirectoryBase
//    {
//        #region Properties

//        [Parameter(Position = 0,
//            ParameterSetName = "OneUser",
//            Mandatory = true,
//            ValueFromPipeline = true,
//            ValueFromPipelineByPropertyName = true,
//            HelpMessage = "The username of the user you would like to retrieve.")]
//        [ValidateNotNullOrEmpty]
//        public string UserName { get; set; }

//        //Domain position = 1

//        [Parameter(Position = 2,
//            ParameterSetName = "AllUsers",
//            HelpMessage = "Retrieve all users in the domain.")]
//        public SwitchParameter All { get; set; }

//        [Parameter(Position = 3,
//            Mandatory=false,
//            ParameterSetName = "AllUsers")]
//        public int MaxResults { get; set; }

//        #endregion

//        protected override void ProcessRecord()
//        {
//            switch (ParameterSetName)
//            {
//                case "OneUser":

//                    UserName = GetFullEmailAddress(UserName, Domain);

//                    if (ShouldProcess(UserName, "Get-GAUser"))
//                    {
//                        WriteObject(new GShellUserObject(users.Get(UserName)));
//                    }
//                    break;

//                case "AllUsers":
//                    if (ShouldProcess("All Users", "Get-GAUser"))
//                    {
//                        //Make sure to include the domain here because List could use things other than domain (customer, etc)
//                        List<Data.User> result = users.List(new dotNet.Directory.Users.UsersListProperties()
//                        {
//                            TotalResults = MaxResults,
//                            Domain = Domain
//                        }).SelectMany(x => x.UsersValue).ToList();
                        
//                        WriteObject(GShellUserObject.ConvertList(result));
//                    }
//                    break;
//            }
//        }
//    }
//}

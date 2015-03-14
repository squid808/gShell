using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

using Google.Apis.Requests;
using gShell.DirectoryCmdlets.GAUser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using gShell.Serialization;

namespace gShell.DirectoryCmdlets.GAUser.GAUserProperties
{
    [Cmdlet(VerbsCommon.Remove, "GAUserProperty",
         SupportsShouldProcess = true)]
    public class RemoveGAUserProperty : GAUserPropertyBase
    {
        #region Properties

        //UserName = 0

        //Domain position = 1

        [Parameter(
           Mandatory = false,
           HelpMessage = "The GShellUserObject to act upon. For example, the result of Get-GAUser",
           ValueFromPipeline = true)]
        public GShellUserObject GShellObject { get; set; }

        [Parameter(Position = 3,
           Mandatory = false,
           HelpMessage = "The property type to retrieve for the user. Allowed values are: address, email, externalid, im, organization, phone, relation.",
           ParameterSetName = "ClearOneProperty")]
        [Parameter(Position = 3,
           Mandatory = false,
           HelpMessage = "The property type to retrieve for the user. Allowed values are: address, email, externalid, im, organization, phone, relation.",
           ParameterSetName = "ClearOneType")]
        [Alias("Type")]
        public GAUserPropertyType PropertyType { get; set; }

        [Parameter(Position = 4,
           Mandatory = false,
           HelpMessage = "The 0-based index number of the item you want to remove for the given Property Type. (The first item in the list is an index of 0.)",
           ParameterSetName = "ClearOneProperty")]
        public int Index { get; set; }

        [Parameter(Position = 5,
            Mandatory = false,
            HelpMessage = "Get all property types for the given user as a Property Collection.",
            ParameterSetName="ClearOneType")]
         public SwitchParameter ClearType { get; set; }

        [Parameter(Position = 6,
            Mandatory = false,
            HelpMessage = "Get all property types for the given user as a Property Collection.",
            ParameterSetName="ClearAll")]
         public SwitchParameter ClearAll { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserName, "Get-GAUserProperty"))
            {
                User u = new User();

                if (null != GShellObject)
                {
                    u = GShellObject.userObject;
                }
                else if (!string.IsNullOrWhiteSpace(UserName))
                {
                    u = GetOneUser(UserName);
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception(
                    string.Format("No username or user object was provided.")),
                        "", ErrorCategory.InvalidOperation, UserName));
                }

                switch (ParameterSetName)
                {
                    case "ClearOneProperty":
                        RemoveOneProperty(u);
                        break;

                    case "ClearOneType":
                        ClearOneProperty(u);
                        break;

                    case "ClearAll":
                        ClearAllProperties(u);
                        break;

                }
            }
        }

        public void RemoveOneProperty(User u) {

            //User userAcct = new User();

            //pull it in to a collection in order to access the methods
            GAUserPropertyCollection upc = new GAUserPropertyCollection(u);
            
            //we don't need to worry about empty lists removing other information here since we're directly adding it to the user object
            switch (PropertyType)
            {
                case GAUserPropertyType.address:
                    upc.RemoveAt(PropertyType,Index);
                    u.Addresses = upc.GetAddresses();
                    break;
                case GAUserPropertyType.email:
                    upc.RemoveAt(PropertyType, Index);
                    u.Emails = upc.GetEmails();
                    break;
                case GAUserPropertyType.externalid:
                    upc.RemoveAt(PropertyType, Index);
                    u.ExternalIds = upc.GetExternalIds();
                    break;
                case GAUserPropertyType.im:
                    upc.RemoveAt(PropertyType, Index);
                    u.Ims = upc.GetIms();
                    break;
                case GAUserPropertyType.organization:
                    upc.RemoveAt(PropertyType, Index);
                    u.Organizations = upc.GetOrganizations();
                    break;
                case GAUserPropertyType.phone:
                    upc.RemoveAt(PropertyType, Index);
                    u.Phones = upc.GetPhones();
                    break;
                case GAUserPropertyType.relation:
                    upc.RemoveAt(PropertyType, Index);
                    u.Relations = upc.GetRelations();
                    break;
            }

            //we have to update instead of patching - it looks like patching will instead ignore any empty lists.
            directoryServiceDict[Domain].Users.Update(u, u.PrimaryEmail).Execute();
        }

        public void ClearOneProperty(User u)
        {
            User userAcct = new User();

            List<string> emptyList = new List<string>();

            //again, we're only directly setting one attribute and don't have to worry about the other collection information
            switch (PropertyType)
            {
                case GAUserPropertyType.address:
                    u.Addresses = NullStringConverter.NullToken;
                    break;
                case GAUserPropertyType.email:
                    u.Emails = emptyList;
                    break;
                case GAUserPropertyType.externalid:
                    u.ExternalIds = emptyList;
                    break;
                case GAUserPropertyType.im:
                    u.Ims = emptyList;
                    break;
                case GAUserPropertyType.organization:
                    u.Organizations = emptyList;
                    break;
                case GAUserPropertyType.phone:
                    u.Phones = emptyList;
                    break;
                case GAUserPropertyType.relation:
                    u.Relations = emptyList;
                    break;
            }

            //Google.Apis.Admin.Directory.directory_v1.UsersResource.PatchRequest pR =
            //    directoryServiceDict[Domain].Users.Patch(u, u.PrimaryEmail);

            //emptyList.Add("");

            //userAcct.Addresses = "null";

            WriteObject(NullStringConverter.NullToken);

            //WriteObject(NullStringConverter.NullToken);

            string serialized = directoryServiceDict[Domain].SerializeObject(userAcct);

            WriteObject(serialized);

            //directoryServiceDict[Domain].Users.Patch(userAcct, u.PrimaryEmail).Execute();

        }

        public void ClearAllProperties(User u)
        {
            //User userAcct = new User();

            List<string> emptyList = new List<string>();

            u.Addresses = emptyList;
            u.Emails = emptyList;
            u.ExternalIds = emptyList;
            u.Ims = emptyList;
            u.Organizations = emptyList;
            u.Phones = emptyList;
            u.Relations = emptyList;

            directoryServiceDict[Domain].Users.Update(u, u.PrimaryEmail).Execute();
        }
    }
}
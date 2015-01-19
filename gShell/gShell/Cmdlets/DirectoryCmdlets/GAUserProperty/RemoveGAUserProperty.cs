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
            HelpMessage = "Clear the entire selected property type for the given user.",
            ParameterSetName="ClearOneType")]
         public SwitchParameter ClearType { get; set; }

        [Parameter(Position = 6,
            Mandatory = false,
            HelpMessage = "Clear all property types for the given user.",
            ParameterSetName="ClearAll")]
         public SwitchParameter ClearAll { get; set; }

        [Parameter(Position = 7,
            HelpMessage = "Force the action to complete without a prompt to continue.")]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            WriteWarning("At the time of release of this version there is a bug in the Google API preventing the deletion of User Properties. For more information, see https://code.google.com/a/google.com/p/apps-api-issues/issues/detail?id=3701 - if you would like this fixed please star the issue to bring it more to their attention. There is no guarantee your information will be deleted.");

            if (ShouldProcess(UserName, "Get-GAUserProperty"))
            {
                if (Force || ShouldContinue((String.Format("One or more user property types of type {0} will be removed from {1}@{2}.\nContinue?",
                    PropertyType.ToString(), UserName, Domain)), "Confirm Google Apps User Property Removal"))
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
                else
                {
                    WriteError(new ErrorRecord(new Exception("Removal of user property not confirmed"),
                        "", ErrorCategory.InvalidData, UserName));
                }
            }
        }

        /// <summary>
        /// Remove one property item from a property list of a User.
        /// </summary>
        /// <param name="u"></param>
        public void RemoveOneProperty(User u) {

            User userAcct = new User();

            //pull it in to a collection in order to access the methods
            GAUserPropertyCollection upc = new GAUserPropertyCollection(u);
            
            //we don't need to worry about empty lists removing other information here since we're directly adding it to the user object
            switch (PropertyType)
            {
                case GAUserPropertyType.address:
                    if (upc.addresses.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Addresses = upc.GetAddresses();
                    }
                    else
                    {
                        userAcct.Addresses = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.email:
                    if (upc.emails.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Emails = upc.GetEmails();
                    }
                    else
                    {
                        userAcct.Emails = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.externalid:
                    if (upc.externalIds.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.ExternalIds = upc.GetExternalIds();
                    }
                    else
                    {
                        userAcct.ExternalIds = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.im:
                    if (upc.ims.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Ims = upc.GetIms();
                    }
                    else
                    {
                        userAcct.Ims = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.organization:
                    if (upc.organizations.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Organizations = upc.GetOrganizations();
                    }
                    else
                    {
                        userAcct.Organizations = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.phone:
                    if (upc.phones.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Phones = upc.GetPhones();
                    }
                    else
                    {
                        userAcct.Phones = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.relation:
                    if (upc.relations.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Relations = upc.GetRelations();
                    }
                    else
                    {
                        userAcct.Relations = NullTokenProvider.NullToken;
                    }
                    break;
            }

            directoryServiceDict[Domain].Users.Update(userAcct, u.PrimaryEmail).Execute();
        }

        /// <summary>
        /// Clear one property fully from a User account.
        /// </summary>
        /// <param name="u"></param>
        public void ClearOneProperty(User u)
        {
            User userAcct = new User();

            //again, we're only directly setting one attribute and don't have to worry about the other collection information
            switch (PropertyType)
            {
                case GAUserPropertyType.address:
                    userAcct.Addresses = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.email:
                    userAcct.Emails = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.externalid:
                    userAcct.ExternalIds = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.im:
                    userAcct.Ims = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.organization:
                    userAcct.Organizations = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.phone:
                    userAcct.Phones = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.relation:
                    userAcct.Relations = NullTokenProvider.NullToken;
                    break;
            }

            directoryServiceDict[Domain].Users.Patch(userAcct, u.PrimaryEmail).Execute();

        }

        /// <summary>
        /// Clear all the properties from a user account.
        /// </summary>
        /// <param name="u"></param>
        public void ClearAllProperties(User u)
        {
            User userAcct = new User();

            userAcct.Addresses = NullTokenProvider.NullToken;
            userAcct.Emails = NullTokenProvider.NullToken;
            userAcct.ExternalIds = NullTokenProvider.NullToken;
            userAcct.Ims = NullTokenProvider.NullToken;
            userAcct.Organizations = NullTokenProvider.NullToken;
            userAcct.Phones = NullTokenProvider.NullToken;
            userAcct.Relations = NullTokenProvider.NullToken;

            directoryServiceDict[Domain].Users.Patch(userAcct, u.PrimaryEmail).Execute();
        }
    }
}
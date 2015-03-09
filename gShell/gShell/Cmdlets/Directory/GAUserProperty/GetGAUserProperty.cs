using System;
using System.Management.Automation;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;

using gShell.dotNet.Utilities;

namespace gShell.Cmdlets.Directory.GAUserProperty
{
     [Cmdlet(VerbsCommon.Get, "GAUserProperty",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAUserProperty")]
    public class GetGAUserProperty : GAUserPropertyBase
    {
        #region Properties

        //UserName = 0

        //Domain position = 1

         [Parameter(Position = 2,
            Mandatory = false,
            HelpMessage = "The GShellUserObject to act upon. For example, the result of Get-GAUser",
            ValueFromPipeline=true)]
         public GShellUserObject GShellObject { get; set; }

         [Parameter(Position = 3,
            Mandatory = true,
            HelpMessage = "The property type to retrieve for the user. Allowed values are: address, email, externalid, im, organization, phone, relation.",
            ParameterSetName="OneType")]
         [Alias("Type")]
         public GAUserPropertyType PropertyType { get; set; }

         [Parameter(Position = 3,
            Mandatory = true,
            HelpMessage = "Get all property types for the given user as a Property Collection.",
            ParameterSetName="AllTypes")]
         public SwitchParameter AllTypes { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserName, "Get-GAUserProperty"))
            {
                Data.User u = new Data.User();

                if (null != GShellObject)
                {
                    u = GShellObject.userObject;
                }
                else if (!string.IsNullOrWhiteSpace(UserName))
                {
                    u = Users.Get(Utils.GetFullEmailAddress(UserName, Domain));
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception(
                    string.Format("No username or user object was provided.")),
                        "", ErrorCategory.InvalidOperation, UserName));
                }

                switch (ParameterSetName)
                {
                    case "OneType":
                        switch (PropertyType)
                        {
                            case GAUserPropertyType.address:
                                WriteObject(GetAddressFromUser(u));
                                break;
                            case GAUserPropertyType.email:
                                WriteObject(GetEmailFromUser(u));
                                break;
                            case GAUserPropertyType.externalid:
                                WriteObject(GetExIdFromUser(u));
                                break;
                            case GAUserPropertyType.im:
                                WriteObject(GetImFromUser(u));
                                break;
                            case GAUserPropertyType.organization:
                                WriteObject(GetOrgFromUser(u));
                                break;
                            case GAUserPropertyType.phone:
                                WriteObject(GetPhoneFromUser(u));
                                break;
                            case GAUserPropertyType.relation:
                                WriteObject(GetRelationFromUser(u));
                                break;
                        }

                        break;

                    case "AllTypes":
                        WriteObject(new GAUserPropertyCollection(u));
                        break;
                }
            }
        }
    }
}

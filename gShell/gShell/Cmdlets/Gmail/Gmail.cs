using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using Google.Apis.Gmail.v1;
using Data = Google.Apis.Gmail.v1.Data;

using gGmail = gShell.dotNet.Gmail;

namespace gShell.Cmdlets.Gmail.Users
{
    [Cmdlet(VerbsCommon.Get, "GGmailUserProfile",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName = "all")]
    public class GetGGmailUserProfile : GmailBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        //[Parameter(Position = 0,
        //    Mandatory = false,
        //    ParameterSetName="all")]
        //[ValidateNotNullOrEmpty]
        //public bool? ShowDeleted { get; set; }

        //[Parameter(Position = 1,
        //    Mandatory = false,
        //    ParameterSetName="all")]
        //[ValidateNotNullOrEmpty]
        //public int? MaxResults { get; set; }
        #endregion

        protected override void BeginProcessing()
        {
            gShellServiceAccount = UserId;

            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Shared Contact", "Get-GSharedContact"))
            {
                //if (ParameterSetName == "one")
                //{
                //    WriteObject(contact.Get(Domain, Id));
                //}
                //else
                //{
                    //var properties = new gSharedContacts.Contact.ContactListProperties();

                    //if (ShowDeleted.HasValue) properties.showdeleted = this.ShowDeleted.Value.ToString();

                    //if (MaxResults.HasValue) properties.maxResults = this.MaxResults.Value;

                

                WriteObject(users.GetProfile(UserId));
                //}
            }
        }
    }
}
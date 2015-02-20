using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAUser
{
    [Cmdlet(VerbsCommon.Get, "GAUser",
          DefaultParameterSetName = "OneUser",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAUser")]
    public class GetGAUser : GetGAUserBase
    {
        #region Properties

        [Parameter(Position = 0,
            ParameterSetName = "OneUser",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The username of the user you would like to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            ParameterSetName = "AllUsers",
            HelpMessage = "Retrieve all users in the domain.")]
        public SwitchParameter All { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "AllUsers",
            HelpMessage = "Retrieves the information from local memory if it already exists, this may not get up-to-date information from the web.")]
        public SwitchParameter Cache { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "AllUsers",
            HelpMessage = "Force the cmdlet to refresh any cached information. This will ensure you get up-to-date information from the web.")]
        public SwitchParameter ForceCacheReload { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "OneUser":

                    if (ShouldProcess(UserName, "Get-GAUser"))
                    {
                        WriteObject(GetOneCustomUser(UserName));
                    }
                    break;

                case "AllUsers":
                    if (ShouldProcess("All Users", "Get-GAUser"))
                    {
                        if (Cache)
                        {
                            WriteObject(GetAllCustomCachedUsers(ForceCacheReload));
                        }
                        else
                        {
                            WriteObject(GetAllCustomUsers());
                        }
                    }
                    break;
            }
        }
    }
}

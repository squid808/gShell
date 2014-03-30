using System;
using System.Collections.Generic;
using System.Management.Automation;
using gShell.DirectoryCmdlets.GAGroup;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAGroupMember
{
    [Cmdlet(VerbsCommon.Add, "GAGroupMember",
          DefaultParameterSetName = "OneGroup",
          SupportsShouldProcess = true)]
    public class AddGAGroupMember : GetGAGroupBase
    {
        #region Properties

        public enum GroupMembershipRoles {MEMBER, MANAGER, OWNER};

        [Parameter(Position = 0,
            ParameterSetName = "OneGroup",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Help Text")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "OneGroup")]
        public string UserName { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "OneGroup")]
        public GroupMembershipRoles Role { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(GroupName, "Add-GAGroupMember"))
            {
                AddGroupMember();
            }
        }

        private void AddGroupMember()
        {
            GroupName = GetFullEmailAddress(GroupName, Domain);

            Member member = new Member {
                Email = GetFullEmailAddress(UserName, Domain),
                Role = this.Role.ToString()
            };

            directoryServiceDict[Domain].Members.Insert(member, GroupName).Execute();
        }
    }

}
using System;
using System.Collections.Generic;
using System.Management.Automation;
using gShell.DirectoryCmdlets.GAGroup;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using gShell.OAuth2;

namespace gShell.DirectoryCmdlets.GAGroupMember
{
    [Cmdlet(VerbsCommon.Set, "GAGroupMember",
          DefaultParameterSetName = "OneGroup",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAGroupMember")]
    public class SetGAGroupMember : GetGAGroupBase
    {
        #region Properties

        public enum GroupMembershipRoles { MEMBER, MANAGER, OWNER };

        [Parameter(Position = 0,
            ParameterSetName = "OneGroup",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group whose member you want to update. For a group AllThings@domain.com named 'All The Things', use AllThings")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "OneGroup",
            HelpMessage = "The username of the group member you want to update.")]
        public string UserName { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            ParameterSetName = "OneGroup",
            HelpMessage = "The new role of the group member. Values can be MEMBER, MANAGER, or OWNER.")]
        public GroupMembershipRoles Role { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(GroupName, "Set-GAGroupMember"))
            {
                UpdateGroupMember();
            }
        }

        private void UpdateGroupMember()
        {
            GroupName = OAuth2Base.GetFullEmailAddress(GroupName, Domain);
            UserName = OAuth2Base.GetFullEmailAddress(UserName, Domain);
            
            Member member = new Member
            {
                Role = this.Role.ToString()
            };

            directoryServiceDict[Domain].Members.Update(member, GroupName, UserName).Execute();
        }
    }

}
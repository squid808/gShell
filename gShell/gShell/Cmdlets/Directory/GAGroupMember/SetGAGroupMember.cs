using System;
using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Directory.GAGroupMember
{
    [Cmdlet(VerbsCommon.Set, "GAGroupMember",
          DefaultParameterSetName = "OneGroup",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAGroupMember")]
    public class SetGAGroupMember : DirectoryBase
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
            GroupName = GetFullEmailAddress(GroupName, Domain);
            UserName = GetFullEmailAddress(UserName, Domain);
            
            Data.Member member = new Data.Member
            {
                Role = this.Role.ToString()
            };

            members.Update(member, GroupName, UserName);
        }
    }

}
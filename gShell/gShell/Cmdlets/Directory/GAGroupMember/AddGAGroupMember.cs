using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Directory.GAGroupMember
{
    [Cmdlet(VerbsCommon.Add, "GAGroupMember",
          DefaultParameterSetName = "OneGroup",
          SupportsShouldProcess = true,
          HelpUri=@"https://github.com/squid808/gShell/wiki/Add-GAGroupMember")]
    public class AddGAGroupMember : DirectoryBase
    {
        #region Properties

        public enum GroupMembershipRoles {MEMBER, MANAGER, OWNER};

        [Parameter(Position = 0,
            ParameterSetName = "OneGroup",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group to which you'd like to add one or more members. For a group AllThings@domain.com named 'All The Things', use AllThings")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "OneGroup",
            HelpMessage = "The username of the group member you want to add.")]
        public string UserName { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "OneGroup",
            HelpMessage = "The role of the new group member. Values can be MEMBER, MANAGER, or OWNER.")]
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

            Members.Insert(member, GroupName);
        }
    }

}
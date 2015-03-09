using System;
using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Directory.GAGroupMember
{
    [Cmdlet(VerbsCommon.Get, "GAGroupMember",
          DefaultParameterSetName = "OneGroup",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAGroupMember")]
    public class GetGAGroupMember : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            ParameterSetName = "OneGroup",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group whose member(s) you want to retrieve. For a group AllThings@domain.com named 'All The Things', use AllThings")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            ParameterSetName = "OneGroup",
            HelpMessage = "The username of the user whose membership information you'd like to retrieve.")]
        public string UserName { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "AllGroups",
            Mandatory = true,
            HelpMessage = "Indicates if you would like to get all members of all groups in the domain.")]
        public SwitchParameter All { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "AllGroups",
            HelpMessage = "Retrieves the information from local memory if it already exists, this may not get up-to-date information from the web.")]
        public SwitchParameter Cache { get; set; }

        [Parameter(Position = 5,
            ParameterSetName = "AllGroups",
            HelpMessage = "Force the cmdlet to refresh any cached information. This will ensure you get up-to-date information from the web.")]
        public SwitchParameter ForceCacheReload { get; set; }

        [Parameter(Position = 6,
            HelpMessage = "Include members in the results.")]
        public SwitchParameter Members { get; set; }

        [Parameter(Position = 7,
            HelpMessage = "Include managers in the results.")]
        public SwitchParameter Managers { get; set; }

        [Parameter(Position = 8,
            HelpMessage = "Include owners in the results.")]
        public SwitchParameter Owners { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                if (ShouldProcess(GroupName, "Get-GAGroupMember"))
                {
                    WriteObject(DirectoryBase.Members.Get(
                        GetFullEmailAddress(GroupName, Domain),
                        GetFullEmailAddress(UserName, Domain)
                        ));
                }
            }
            else
            {
                switch (ParameterSetName)
                {
                    case "OneGroup":
                        if (ShouldProcess(GroupName, "Get-GAGroupMember"))
                        {
                            WriteObject(DirectoryBase.Members.List(
                                GetFullEmailAddress(GroupName, Domain)));
                        }
                        break;

                    case "AllGroups":
                        if (ShouldProcess("All Groups and Members", "Get-GAGroupMember"))
                        {
                            WriteObject(GetAllGroupsAndMembers());
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Construct a roles string based on the parameters passed. Defaults to all.
        /// </summary>
        /// <returns></returns>
        private string DetermineRoles()
        {
            if (!Members && !Managers && !Owners)
            {
                return "MEMBER,MANAGER,OWNER";
            }

            string roles = "";

            int count = 0;

            if (Members)
            {
                roles += "MEMBER";
                count += 1;
            }

            if (Managers)
            {
                if (count > 0)
                {
                    roles += ",";
                }

                roles += "MANAGER";
                count += 1;
            }

            if (Owners)
            {
                if (count > 0)
                {
                    roles += ",";
                }

                roles += "OWNER";
            }

            return roles;
        }

        /// <summary>
        /// Gets a list of all members from all groups. Calls for cached list of all groups.
        /// </summary>
        private GAMultiGroupMembersList GetAllGroupsAndMembers()
        {
            List<Data.Group> allGroups = Groups.List();

            GAMultiGroupMembersList multiList = new GAMultiGroupMembersList();

            foreach (Data.Group group in allGroups)
            {
                List<Data.Member> members = DirectoryBase.Members.List(GetFullEmailAddress(GroupName, Domain));

                multiList.Add(group.Email, members);

                //if (MaxResults != 0 &&
                //    multiList.GetMemberCount() >= MaxResults) { break; }
            }

            return (multiList);
        }
    }

    /// <summary>
    /// A collection of members sorted by group.
    /// </summary>
    public class GAMultiGroupMembersList
    {
        public List<GACustomMembersList> membersByGroup;
        private Dictionary<string, int> groupIndex;

        public GAMultiGroupMembersList () {
            membersByGroup = new List<GACustomMembersList>();
            groupIndex = new Dictionary<string, int>();
        }

        public void Add(string groupName, List<Data.Member> membersList)
        {
            GACustomMembersList temp = new GACustomMembersList(groupName, membersList);
            membersByGroup.Add(temp);
            groupIndex[groupName] = membersByGroup.Count - 1;
        }

        public List<Data.Member> GetGroupMembers(string groupName)
        {
            if (groupIndex.ContainsKey(groupName))
            {
                return membersByGroup[groupIndex[groupName]].MembersList;
            }
            else
            {
                throw new System.InvalidOperationException(
                    string.Format("Object does not contain group information for {0}.", groupName));
            }
        }

        public List<GACustomMembersListEntry> ToSingleList()
        {
            List<GACustomMembersListEntry> singleList = new List<GACustomMembersListEntry>();

            foreach (GACustomMembersList group in membersByGroup)
            {
                singleList.AddRange(group.ToCustomList());
            }

            return singleList;
        }

        public int GetMemberCount()
        {
            int count = 0;

            foreach (GACustomMembersList list in membersByGroup)
            {
                count += list.MembersList.Count;
            }

            return count;
        }
    }

    public class GACustomMembersList
    {
        public string GroupName;
        public List<Data.Member> MembersList;

        public GACustomMembersList (string groupName, List<Data.Member> members) {
            GroupName = groupName;
            MembersList = members;
        }

        public List<GACustomMembersListEntry> ToCustomList()
        {
            List<GACustomMembersListEntry> customList = new List<GACustomMembersListEntry>();

            foreach (Data.Member member in MembersList)
            {
                customList.Add(new GACustomMembersListEntry(
                    GroupName, member));
            }

            return (customList);
        }
    }

    /// <summary>
    /// Extends the base Member class to include the group it came from.
    /// </summary>
    public class GACustomMembersListEntry : Data.Member
    {
        public string Group;

        public GACustomMembersListEntry(string groupEmail, Data.Member baseMember)
        {
            Email = baseMember.Email;
            ETag = baseMember.ETag;
            Id = baseMember.Id;
            Kind = baseMember.Kind;
            Role = baseMember.Role;
            Type = baseMember.Type;
            Group = groupEmail;
        }
    }
}
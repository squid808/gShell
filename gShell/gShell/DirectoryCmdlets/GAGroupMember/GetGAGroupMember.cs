using System;
using System.Collections.Generic;
using System.Management.Automation;
using gShell.DirectoryCmdlets.GAGroup;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAGroupMember
{
    [Cmdlet(VerbsCommon.Get, "GAGroupMember",
          DefaultParameterSetName = "OneGroup",
          SupportsShouldProcess = true)]
    public class GetGAGroupMember : GetGAGroupBase
    {
        #region Properties

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
            ParameterSetName = "OneGroup")]
        public string UserName { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "AllGroups",
            Mandatory = true)]
        public SwitchParameter All { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "AllGroups")]
        public SwitchParameter Cache { get; set; }

        [Parameter(Position = 5,
            ParameterSetName = "AllGroups")]
        public SwitchParameter ForceCacheReload { get; set; }

        [Parameter(Position = 6)]
        public SwitchParameter Members { get; set; }

        [Parameter(Position = 7)]
        public SwitchParameter Managers { get; set; }

        [Parameter(Position = 8)]
        public SwitchParameter Owners { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                GroupName = GetFullEmailAddress(GroupName, Domain);
                WriteObject(GetOneMember());
            }
            else
            {
                switch (ParameterSetName)
                {
                    case "OneGroup":
                        GroupName = GetFullEmailAddress(GroupName, Domain);
                        WriteObject(GetMemberList(GroupName));
                        break;

                    case "AllGroups":
                        WriteObject(GetAllGroupsAndMembers());
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

        private List<Member> GetMemberList(string groupName)
        {
            if (Cache)
            {
                return (RetrieveCachedGroupMembers(groupName));
            }
            else
            {
                return (GetOneMemberList(groupName));
            }
        }

        /// <summary>
        /// Returns a list of all members of a given group.
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        private List<Member> GetOneMemberList(string groupName)
        {
            MembersResource.ListRequest request = directoryServiceDict[Domain].Members.List(groupName);

            request.MaxResults = 200;
            request.Roles = DetermineRoles();

            StartProgressBar(string.Format("Gathering members for group {0}",
                    groupName), string.Empty);

            UpdateProgressBar(1, 2, string.Format("Gathering members for group {0}",
                    groupName), "-Collecting members 1 to " + request.MaxResults.ToString());

            Members execution = request.Execute();

            List<Member> returnedList = new List<Member>();

            if (execution.MembersValue == null) {
                return returnedList;
            }

            returnedList.AddRange(execution.MembersValue);

            while (!string.IsNullOrWhiteSpace(execution.NextPageToken) && 
                execution.NextPageToken != request.PageToken)
            {
                request.PageToken = execution.NextPageToken;
                UpdateProgressBar(1, 2,
                    string.Format("Gathering members for group {0}",
                     groupName),
                    string.Format("-Collecting members {0} to {1}",
                     (returnedList.Count + 1 ).ToString(),
                     (returnedList.Count + request.MaxResults).ToString()));
                execution = request.Execute();
                returnedList.AddRange(execution.MembersValue);
            }

            UpdateProgressBar(1, 2, "Gathering accounts",
                "-Returning " + returnedList.Count.ToString() + " results.");

            return (returnedList);
        }

        /// <summary>
        /// Returns a member object for the given user in the given group, if any.
        /// </summary>
        private Member GetOneMember()
        {
            UserName = GetFullEmailAddress(UserName, Domain);

            Member groupMember = directoryServiceDict[Domain].Members.Get(GroupName, UserName).Execute();

            return (groupMember);
        }

        /// <summary>
        /// Wrapper method that returns group members from memory if it exists, otherwise the net.
        /// Assumes other methods will use cached too.
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        private List<Member> RetrieveCachedGroupMembers(string groupName, 
            bool forceCacheReload=false)
        {
            List<Member> memberList = new List<Member>();

            if (cachedDomainGroupMembers.ContainsKey(Domain) &&
                cachedDomainGroupMembers[Domain].ContainsKey(groupName) &&
                !forceCacheReload)
            {
                memberList = cachedDomainGroupMembers[Domain][groupName];
            }
            else
            {
                if (!cachedDomainGroupMembers.ContainsKey(Domain))
                {
                    cachedDomainGroupMembers[Domain] = new Dictionary<string, List<Member>>();
                }

                memberList = GetOneMemberList(groupName);
                cachedDomainGroupMembers[Domain][groupName] = memberList;
            }

            return memberList;
        }

        /// <summary>
        /// Gets a list of all members from all groups. Calls for cached list of all groups.
        /// </summary>
        private GAMultiDomainMembersList GetAllGroupsAndMembers()
        {
            List<Group> allGroups = RetrieveCachedGroups(ForceCacheReload);

            GAMultiDomainMembersList multiList = new GAMultiDomainMembersList();

            foreach (Group group in allGroups)
            {
                List<Member> members = new List<Member>();

                if (Cache)
                {
                    members = RetrieveCachedGroupMembers(group.Email, ForceCacheReload);
                }
                else
                {
                    members = GetOneMemberList(group.Email);
                }
                multiList.Add(group.Email, members);
            }

            return (multiList);
        }
    }


    public class GAMultiDomainMembersList
    {
        //private Dictionary<string,List<Member>> MembersByGroup;
        public List<GACustomMembersList> membersByGroup;
        private Dictionary<string, int> groupIndex;

        public GAMultiDomainMembersList () {
            //MembersByGroup = new Dictionary<string, List<Member>>();
            membersByGroup = new List<GACustomMembersList>();
            groupIndex = new Dictionary<string, int>();
        }

        public void Add(string groupName, List<Member> membersList)
        {
            //MembersByGroup[groupName] = membersList;
            membersByGroup.Add(new GACustomMembersList(groupName, membersList));
            groupIndex[groupName] = membersByGroup.Count - 1;
        }

        public List<Member> GetGroupMembers(string groupName)
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
    }

    public class GACustomMembersList
    {
        public string GroupName;
        public List<Member> MembersList;

        public GACustomMembersList (string groupName, List<Member> members) {
            GroupName = groupName;
            MembersList = members;
        }

        public List<GACustomMembersListEntry> ToCustomList()
        {
            List<GACustomMembersListEntry> customList = new List<GACustomMembersListEntry>();

            foreach (Member member in MembersList)
            {
                customList.Add(new GACustomMembersListEntry(
                    GroupName, member));
            }

            return (customList);
        }
    }

    public class GACustomMembersListEntry : Member
    {
        public string Group;

        public GACustomMembersListEntry(string groupEmail, Member baseMember)
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
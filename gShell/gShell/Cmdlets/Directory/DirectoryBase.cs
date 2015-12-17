using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Services;
using directory_v1 = Google.Apis.Admin.Directory.directory_v1;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;

using gShell.dotNet.Utilities;
using gShell.dotNet.Utilities.OAuth2;
using gDirectory = gShell.dotNet.Directory;

namespace gShell.Cmdlets.Directory
{
    /// <summary>
    /// The base class for all Google Directory API calls within the PowerShell Cmdlets.
    /// </summary>
    public class DirectoryBase : OAuth2CmdletBase
    {
        #region Properties
        protected static gDirectory gdirectory { get; set; }
        protected ChromeosDevices chromeosDevices { get; set; }
        protected Groups groups { get; set; }
        protected Members members { get; set; }
        protected MobileDevices mobileDevices { get; set; }
        protected Orgunits orgunits { get; set; }
        protected Users users { get; set; }
        protected Asps asps { get; set; }
        protected Tokens tokens { get; set; }
        protected VerificationCodes verificationCodes { get; set; }
        protected Notifications notifications { get; set; }
        protected Channels channels { get; set; }
        protected Schemas schemas { get; set; }

        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Google Apps domain, ex contoso.com. If none is provided the gShell default domain will be used.")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected override string apiNameAndVersion { get { return gdirectory.apiNameAndVersion; } }

        #endregion

        #region Constructors

        public DirectoryBase()
        {
            gdirectory = new gDirectory();
            chromeosDevices = new ChromeosDevices();
            groups = new Groups();
            members = new Members();
            mobileDevices = new MobileDevices();
            orgunits = new Orgunits();
            users = new Users();
            asps = new Asps();
            tokens = new Tokens();
            verificationCodes = new VerificationCodes();
            notifications = new Notifications();
            channels = new Channels();
            schemas = new Schemas();
        }
        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing()
        {
            if (null == gdirectory) { gdirectory = new gDirectory(); }
            ShouldPromptForScopes(Domain);
            Domain = Authenticate().authenticatedDomain;

            GWriteProgress = new gWriteProgress(WriteProgress);
        }
        #endregion

        #region Authentication & Processing

        /// <summary>
        /// A method specific to each inherited object, called during authentication. Must be implemented.
        /// </summary>
        protected override AuthenticationInfo Authenticate()
        {
            return gdirectory.Authenticate(apiNameAndVersion);
        }

        #endregion

        #region Wrapped Methods

        //the following methods assume that the service has been authenticated first.

        #region Chromeosdevices

        public class ChromeosDevices
        {
            public Data.ChromeOsDevice Get(string customerId, string deviceId,
                directory_v1.ChromeosdevicesResource.GetRequest.ProjectionEnum? projection = null)
            {
                return gdirectory.chromeosDevices.Get(Utils.CheckCustomerID(customerId), deviceId, projection); 
            }

            public List<Data.ChromeOsDevice> List(string customerId, gDirectory.ChromeosDevices.ChromeosDevicesListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.ChromeosDevices.ChromeosDevicesListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gdirectory.chromeosDevices.List(Utils.CheckCustomerID(customerId), properties);
            }

            public Data.ChromeOsDevice Patch(Data.ChromeOsDevice body, string customerId, string deviceId,
                directory_v1.ChromeosdevicesResource.PatchRequest.ProjectionEnum? projection = null)
            {
                return gdirectory.chromeosDevices.Patch(body, Utils.CheckCustomerID(customerId), deviceId, projection);
            }

            public Data.ChromeOsDevice Update(Data.ChromeOsDevice body, string customerId, string deviceId,
                directory_v1.ChromeosdevicesResource.UpdateRequest.ProjectionEnum? projection = null)
            {
                return gdirectory.chromeosDevices.Update(body, Utils.CheckCustomerID(customerId), deviceId, projection);
            }
        }

        #endregion

        #region Groups

        public class Groups
        {
            public Aliases aliases = new Aliases();

            public string Delete(string groupKey, string domain)
            {
                return gdirectory.groups.Delete(Utils.GetFullEmailAddress(groupKey, domain));
            }

            public Data.Group Get(string groupKey, string domain)
            {
                return gdirectory.groups.Get(Utils.GetFullEmailAddress(groupKey, domain));
            }

            public Data.Group Insert(Data.Group body)
            {
                return gdirectory.groups.Insert(body);
            }

            public List<Data.Group> List(gDirectory.Groups.GroupsListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.Groups.GroupsListProperties();
                if (properties.userKey != null)
                {
                    properties.userKey = Utils.GetFullEmailAddress(properties.userKey, properties.domain);
                }
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gdirectory.groups.List(properties);
            }

            public Data.Group Patch(Data.Group body, string groupKey, string domain)
            {
                return gdirectory.groups.Patch(body, (Utils.GetFullEmailAddress(groupKey, domain)));
            }

            public Data.Group Update(Data.Group body, string groupKey, string domain)
            {
                return gdirectory.groups.Update(body, (Utils.GetFullEmailAddress(groupKey, domain)));
            }

            #region Groups.aliases
            public class Aliases
            {

                public string Delete(string groupKey, string domain, string alias)
                {
                    return gdirectory.groups.aliases.Delete(Utils.GetFullEmailAddress(groupKey, domain), alias);
                }

                public Data.Alias Insert(Data.Alias body, string groupKey, string domain)
                {
                    return gdirectory.groups.aliases.Insert(body, (Utils.GetFullEmailAddress(groupKey, domain)));
                }

                public List<Data.Alias> List(string groupKey, string domain)
                {
                    return gdirectory.groups.aliases.List(Utils.GetFullEmailAddress(groupKey, domain));
                }
            }

            #endregion

        }

        #endregion

        #region Members

        public class Members
        {
            public string Delete(string groupKey, string domain, string memberKey)
            {
                return gdirectory.members.Delete(Utils.GetFullEmailAddress(groupKey, domain), Utils.GetFullEmailAddress(memberKey, domain));
            }

            public Data.Member Get(string groupKey, string domain, string memberKey)
            {
                return gdirectory.members.Get(Utils.GetFullEmailAddress(groupKey, domain), Utils.GetFullEmailAddress(memberKey, domain));
            }

            public Data.Member Insert(Data.Member body, string groupKey, string domain)
            {
                return gdirectory.members.Insert(body, (Utils.GetFullEmailAddress(groupKey, domain)));
            }

            public List<Data.Member> List(string groupKey, string domain, gDirectory.Members.MembersListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.Members.MembersListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gdirectory.members.List(Utils.GetFullEmailAddress(groupKey, domain), properties);
            }

            public Data.Member Patch(Data.Member body, string groupKey, string domain, string memberKey)
            {
                return gdirectory.members.Patch(body, Utils.GetFullEmailAddress(groupKey, domain), Utils.GetFullEmailAddress(memberKey, domain));
            }

            public Data.Member Update(Data.Member body, string groupKey, string domain, string memberKey)
            {
                return gdirectory.members.Update(body, Utils.GetFullEmailAddress(groupKey, domain), Utils.GetFullEmailAddress(memberKey, domain));
            }
        }

        #endregion

        #region MobileDevices

        public class MobileDevices
        {
            public string Action(gDirectory.MobileDevices.MobileDeviceAction action, string customerId, string resourceId)
            {
                Data.MobileDeviceAction body = new Data.MobileDeviceAction();
                body.Action = action.ToString();
                return gdirectory.mobileDevices.Action(body, Utils.CheckCustomerID(customerId), resourceId);
            }

            public string Delete(string customerId, string resourceId)
            {
                return gdirectory.mobileDevices.Delete(Utils.CheckCustomerID(customerId), resourceId);
            }

            public Data.MobileDevice Get(string customerId, string resourceId,
                directory_v1.MobiledevicesResource.GetRequest.ProjectionEnum? projection = null)
            {
                return gdirectory.mobileDevices.Get(Utils.CheckCustomerID(customerId), resourceId, projection);
            }

            public List<Data.MobileDevice> List(string customerId, gDirectory.MobileDevices.MobileDevicesPropertiesList properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.MobileDevices.MobileDevicesPropertiesList();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gdirectory.mobileDevices.List(Utils.CheckCustomerID(customerId), properties);
            }
        }

        #endregion

        #region Orgunits

        public class Orgunits
        {
            public string Delete(string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gdirectory.orgunits.Delete(Utils.CheckCustomerID(customerId), orgUnitPath);
            }

            public Data.OrgUnit Get(string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gdirectory.orgunits.Get(Utils.CheckCustomerID(customerId), orgUnitPath);
            }

            public Data.OrgUnit Insert(Data.OrgUnit body, string customerId)
            {
                return gdirectory.orgunits.Insert(body, Utils.CheckCustomerID(customerId));
            }

            public List<Data.OrgUnit> List(string customerId, gDirectory.Orgunits.OrgunitsListProperties properties = null)
            {
                return gdirectory.orgunits.List(Utils.CheckCustomerID(customerId), properties);
            }

            public Data.OrgUnit Patch(Data.OrgUnit body, string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gdirectory.orgunits.Patch(body, Utils.CheckCustomerID(customerId), orgUnitPath);
            }

            public Data.OrgUnit Update(Data.OrgUnit body, string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gdirectory.orgunits.Update(body, Utils.CheckCustomerID(customerId), orgUnitPath);
            }
        }

        #endregion

        #region Users

        public class Users
        {
            public Aliases aliases = new Aliases();
            public Photos photos = new Photos();

            public string Delete(string userKey, string domain)
            {
                return gdirectory.users.Delete(Utils.GetFullEmailAddress(userKey, domain));
            }

            public Data.User Get(string userKey, string domain,
                directory_v1.UsersResource.GetRequest.ProjectionEnum? projection = null,
                directory_v1.UsersResource.GetRequest.ViewTypeEnum? viewType = null)
            {
                return gdirectory.users.Get(Utils.GetFullEmailAddress(userKey, domain), projection, viewType);
            }

            public Data.User Insert(Data.User body)
            {
                return gdirectory.users.Insert(body);
            }

            public List<Data.User> List(gDirectory.Users.UsersListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.Users.UsersListProperties()
                {
                    maxResults = 500
                };
                properties.maxResults = (properties.maxResults == 0) ? 500 : properties.maxResults; //set it to the max if not specified
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gdirectory.users.List(properties);
            }

            public string MakeAdmin(Data.UserMakeAdmin body, string userKey, string domain)
            {
                return gdirectory.users.MakeAdmin(body, (Utils.GetFullEmailAddress(userKey, domain)));
            }

            public Data.User Patch(Data.User body, string userKey, string domain)
            {
                return gdirectory.users.Patch(body, (Utils.GetFullEmailAddress(userKey, domain)));
            }

            public string Undelete(Data.UserUndelete body, string userKey)
            {
                return gdirectory.users.Undelete(body, userKey);
            }

            public Data.User Update(Data.User body, string userKey, string domain)
            {
                return gdirectory.users.Update(body, (Utils.GetFullEmailAddress(userKey, domain)));
            }

            public Data.Channel Watch(Data.Channel body)
            {
                return gdirectory.users.Watch(body);
            }

            #region Users.aliases

            public class Aliases
            {
                public string Delete(string userKey, string domain, string alias)
                {
                    return gdirectory.users.aliases.Delete(Utils.GetFullEmailAddress(userKey, domain), Utils.GetFullEmailAddress(alias, domain));
                }

                public Data.Alias Insert(Data.Alias body, string userKey, string domain)
                {
                    return gdirectory.users.aliases.Insert(body, (Utils.GetFullEmailAddress(userKey, domain)));
                }

                public List<Data.Alias> List(string userKey, string domain)
                {
                    return gdirectory.users.aliases.List(Utils.GetFullEmailAddress(userKey, domain));
                }

                public Data.Channel Watch(Data.Channel body, string userKey, string domain)
                {
                    return gdirectory.users.aliases.Watch(body, (Utils.GetFullEmailAddress(userKey, domain)));
                }
            }

            #endregion

            #region Users.photos

            public class Photos
            {
                public string Delete(string userKey, string domain)
                {
                    return gdirectory.users.photos.Delete(Utils.GetFullEmailAddress(userKey, domain));
                }

                public Data.UserPhoto Get(string userKey, string domain)
                {
                    return gdirectory.users.photos.Get(Utils.GetFullEmailAddress(userKey, domain));
                }

                public Data.UserPhoto Patch(Data.UserPhoto body, string userKey, string domain)
                {
                    return gdirectory.users.photos.Patch(body, (Utils.GetFullEmailAddress(userKey, domain)));
                }

                public Data.UserPhoto Update(Data.UserPhoto body, string userKey, string domain)
                {
                    return gdirectory.users.photos.Update(body, (Utils.GetFullEmailAddress(userKey, domain)));
                }
            }

            #endregion

        }
        #endregion

        #region Asps

        public class Asps
        {
            public string Delete(string userKey, string domain, int codeId)
            {
                return gdirectory.asps.Delete(Utils.GetFullEmailAddress(userKey, domain), codeId);
            }

            public Data.Asp Get(string userKey, string domain, int codeId)
            {
                return gdirectory.asps.Get(Utils.GetFullEmailAddress(userKey, domain), codeId);
            }

            public List<Data.Asp> List(string userKey, string domain)
            {
                return gdirectory.asps.List(Utils.GetFullEmailAddress(userKey, domain));
            }
        }

        #endregion

        #region Tokens

        public class Tokens
        {
            public string Delete(string userKey, string domain, string clientId)
            {
                return gdirectory.tokens.Delete(Utils.GetFullEmailAddress(userKey, domain), clientId);
            }

            public Data.Token Get(string userKey, string domain, string clientId)
            {
                return gdirectory.tokens.Get(Utils.GetFullEmailAddress(userKey, domain), clientId);
            }

            public List<Data.Token> List(string userKey, string domain)
            {
                return gdirectory.tokens.List(Utils.GetFullEmailAddress(userKey, domain));
            }
        }

        #endregion

        #region VerificationCodes

        public class VerificationCodes
        {
            public string Generate(string userKey, string domain)
            {
                return gdirectory.verificationCodes.Generate(Utils.GetFullEmailAddress(userKey, domain));
            }

            public string Invalidate(string userKey, string domain)
            {
                return gdirectory.verificationCodes.Invalidate(Utils.GetFullEmailAddress(userKey, domain));
            }

            public List<Data.VerificationCode> List(string userKey, string domain)
            {
                return gdirectory.verificationCodes.List(Utils.GetFullEmailAddress(userKey, domain));
            }
        }

        #endregion

        #region Notifications

        public class Notifications
        {
            public string Delete(string customer, string notificationId)
            {
                return gdirectory.notifications.Delete(customer, notificationId);
            }

            public Data.Notification Get(string customer, string notificationId)
            {
                return gdirectory.notifications.Get(customer, notificationId);
            }

            public List<Data.Notification> List(string customer, gDirectory.Notifications.NotificationsListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.Notifications.NotificationsListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gdirectory.notifications.List(customer, properties);
            }

            public Data.Notification Patch(Data.Notification body, string customer, string notificationId)
            {
                return gdirectory.notifications.Patch(body, customer, notificationId);
            }

            public Data.Notification Update(Data.Notification body, string customer, string notificationId)
            {
                return gdirectory.notifications.Update(body, customer, notificationId);
            }
        }

        #endregion

        #region Channels

        public class Channels
        {
            public string Stop(Data.Channel body)
            {
                return gdirectory.channels.Stop(body);
            }
        }

        #endregion

        #region Schemas

        public class Schemas
        {
            public string Delete(string customerId, string schemaKey)
            {
                return gdirectory.schemas.Delete(customerId, schemaKey);
            }

            public Data.Schema Get(string customerId, string schemaKey)
            {
                return gdirectory.schemas.Get(customerId, schemaKey);
            }

            public Data.Schema Insert(Data.Schema body, string customerId)
            {
                return gdirectory.schemas.Insert(body, customerId);
            }

            public List<Data.Schema> List(string customerId)
            {
                return gdirectory.schemas.List(customerId);
            }

            public Data.Schema Patch(Data.Schema body, string customerId, string schemaKey)
            {
                return gdirectory.schemas.Patch(body, customerId, schemaKey);
            }

            public Data.Schema Update(Data.Schema body, string customerId, string schemaKey)
            {
                return gdirectory.schemas.Update(body, customerId, schemaKey);
            }
        }

        #endregion

        //end of wrapped methods
        #endregion

    }

    /// <summary>
    /// A custom class to more easily expose common attributes for viewing
    /// </summary>
    public class GShellUserObject
    {
        public string GivenName;
        public string FamilyName;
        public string PrimaryEmail;
        public List<string> Aliases;
        public bool Suspended;
        public string OrgUnitPath;
        public DateTime? LastLoginTime;

        public Data.User userObject;

        public GShellUserObject(Data.User userObj)
        {
            Aliases = new List<string>();

            FamilyName = userObj.Name.FamilyName;
            GivenName = userObj.Name.GivenName;
            PrimaryEmail = userObj.PrimaryEmail;
            if (null != userObj.Aliases)
            {
                Aliases.AddRange(userObj.Aliases);
            }
            if (userObj.Suspended.HasValue)
            {
                Suspended = userObj.Suspended.Value;
            }
            OrgUnitPath = userObj.OrgUnitPath;
            LastLoginTime = userObj.LastLoginTime;

            userObject = userObj;
        }

        //TODO make this inherit from a superclass with a generic function
        public static List<GShellUserObject> ConvertList(List<Data.User> userList)
        {
            List<GShellUserObject> customList = new List<GShellUserObject>();

            foreach (Data.User user in userList)
            {
                customList.Add(new GShellUserObject(user));
            }

            return (customList);
        }
    }
}

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
        protected static gShell.dotNet.Directory gdirectory = new gDirectory();
        protected ChromeosDevices chromeosDevices = new ChromeosDevices();
        protected Groups groups = new Groups();
        protected Members members = new Members();
        protected MobileDevices mobileDevices = new MobileDevices();
        protected Orgunits orgunits = new Orgunits();
        protected Users users = new Users();
        protected Asps asps = new Asps();
        protected Tokens tokens = new Tokens();
        protected VerificationCodes verificationCodes = new VerificationCodes();
        protected Notifications notifications = new Notifications();
        protected Channels channels = new Channels();
        protected Schemas schemas = new Schemas();

        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Google Apps domain, ex contoso.com. If none is provided the gShell default domain will be used.")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }
        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing()
        {
            if (null == gdirectory) { gdirectory = new gDirectory(); }
            Domain = Authenticate(Domain);

            GWriteProgress = new gWriteProgress(WriteProgress);
        }
        #endregion

        #region Authentication & Processing
        /// <summary>
        /// A method specific to each inherited object, called during authentication. Must be implemented.
        /// </summary>
        protected override string Authenticate(string domain)
        {
            return gdirectory.Authenticate(domain);
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
                return gdirectory.chromeosDevices.Get(customerId, deviceId, projection); 
            }

            public List<Data.ChromeOsDevice> List(string customerId, gDirectory.ChromeosDevices.ChromeosDevicesListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.ChromeosDevices.ChromeosDevicesListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gdirectory.chromeosDevices.List(customerId, properties);
            }

            public Data.ChromeOsDevice Patch(Data.ChromeOsDevice body, string customerId, string deviceId,
                directory_v1.ChromeosdevicesResource.PatchRequest.ProjectionEnum? projection = null)
            {
                return gdirectory.chromeosDevices.Patch(body, customerId, deviceId, projection);
            }

            public Data.ChromeOsDevice Update(Data.ChromeOsDevice body, string customerId, string deviceId,
                directory_v1.ChromeosdevicesResource.UpdateRequest.ProjectionEnum? projection = null)
            {
                return gdirectory.chromeosDevices.Update(body, customerId, deviceId, projection);
            }
        }
        #endregion

        #region Groups
        public class Groups
        {
            public Aliases aliases = new Aliases();

            public string Delete(string groupKey)
            {
                return gdirectory.groups.Delete(groupKey);
            }

            public Data.Group Get(string groupKey)
            {
                return gdirectory.groups.Get(groupKey);
            }

            public Data.Group Insert(Data.Group body)
            {
                return gdirectory.groups.Insert(body);
            }

            public List<Data.Group> List(gDirectory.Groups.GroupsListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.Groups.GroupsListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gdirectory.groups.List(properties);
            }

            public Data.Group Patch(Data.Group body, string groupKey)
            {
                return gdirectory.groups.Patch(body, groupKey);
            }

            public Data.Group Update(Data.Group body, string groupKey)
            {
                return gdirectory.groups.Update(body, groupKey);
            }

            #region Groups.aliases
            public class Aliases
            {
                public string Delete(string groupKey, string alias)
                {
                    return gdirectory.groups.aliases.Delete(groupKey, alias);
                }

                public Data.Alias Insert(Data.Alias body, string groupKey)
                {
                    return gdirectory.groups.aliases.Insert(body, groupKey);
                }

                public List<Data.Alias> List(string groupKey)
                {
                    return gdirectory.groups.aliases.List(groupKey);
                }
            }
            #endregion

        }
        #endregion

        #region Members
        public class Members
        {
            public string Delete(string groupKey, string memberKey)
            {
                return gdirectory.members.Delete(groupKey, memberKey);
            }

            public Data.Member Get(string groupKey, string memberKey)
            {
                return gdirectory.members.Get(groupKey, memberKey);
            }

            public Data.Member Insert(Data.Member body, string groupKey)
            {
                return gdirectory.members.Insert(body, groupKey);
            }

            public List<Data.Member> List(string groupKey, gDirectory.Members.MembersListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.Members.MembersListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gdirectory.members.List(groupKey, properties);
            }

            public Data.Member Patch(Data.Member body, string groupKey, string memberKey)
            {
                return gdirectory.members.Patch(body, groupKey, memberKey);
            }

            public Data.Member Update(Data.Member body, string groupKey, string memberKey)
            {
                return gdirectory.members.Update(body, groupKey, memberKey);
            }
        }
        #endregion

        #region MobileDevices
        public class MobileDevices
        {
            public string Action(Data.MobileDeviceAction body, string customerId, string resourceId)
            {
                return gdirectory.mobileDevices.Action(body, customerId, resourceId);
            }

            public string Delete(string customerId, string resourceId)
            {
                return gdirectory.mobileDevices.Delete(customerId, resourceId);
            }

            public Data.MobileDevice Get(string customerId, string resourceId,
                directory_v1.MobiledevicesResource.GetRequest.ProjectionEnum? projection = null)
            {
                return gdirectory.mobileDevices.Get(customerId, resourceId, projection);
            }

            public List<Data.MobileDevice> List(string customerId, gDirectory.MobileDevices.MobileDevicesPropertiesList properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.MobileDevices.MobileDevicesPropertiesList();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gdirectory.mobileDevices.List(customerId, properties);
            }
        }
        #endregion

        #region Orgunits
        public class Orgunits
        {
            public string Delete(string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gdirectory.orgunits.Delete(customerId, orgUnitPath);
            }

            public Data.OrgUnit Get(string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gdirectory.orgunits.Get(customerId, orgUnitPath);
            }

            public Data.OrgUnit Insert(Data.OrgUnit body, string customerId)
            {
                return gdirectory.orgunits.Insert(body, customerId);
            }

            public List<Data.OrgUnit> List(string customerId, gDirectory.Orgunits.OrgunitsListProperties properties = null)
            {
                return gdirectory.orgunits.List(customerId, properties);
            }

            public Data.OrgUnit Patch(Data.OrgUnit body, string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gdirectory.orgunits.Patch(body, customerId, orgUnitPath);
            }

            public Data.OrgUnit Update(Data.OrgUnit body, string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gdirectory.orgunits.Update(body, customerId, orgUnitPath);
            }
        }
        #endregion

        #region Users
        public class Users
        {
            public Aliases aliases = new Aliases();
            public Photos photos = new Photos();

            public string Delete(string userKey)
            {
                return gdirectory.users.Delete(userKey);
            }

            public Data.User Get(string userKey,
                directory_v1.UsersResource.GetRequest.ProjectionEnum? projection = null,
                directory_v1.UsersResource.GetRequest.ViewTypeEnum? viewType = null)
            {
                return gdirectory.users.Get(userKey, projection, viewType);
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

            public string MakeAdmin(Data.UserMakeAdmin body, string userKey)
            {
                return gdirectory.users.MakeAdmin(body, userKey);
            }

            public Data.User Patch(Data.User body, string userKey)
            {
                return gdirectory.users.Patch(body, userKey);
            }

            public string Undelete(Data.UserUndelete body, string userKey)
            {
                return gdirectory.users.Undelete(body, userKey);
            }

            public Data.User Update(Data.User body, string userKey)
            {
                return gdirectory.users.Update(body, userKey);
            }

            public Data.Channel Watch(Data.Channel body)
            {
                return gdirectory.users.Watch(body);
            }

            #region Users.aliases
            public class Aliases
            {
                public string Delete(string userKey, string alias)
                {
                    return gdirectory.users.aliases.Delete(userKey, alias);
                }

                public Data.Alias Insert(Data.Alias body, string userKey)
                {
                    return gdirectory.users.aliases.Insert(body, userKey);
                }

                public List<Data.Alias> List(string userKey)
                {
                    return gdirectory.users.aliases.List(userKey);
                }

                public Data.Channel Watch(Data.Channel body, string userKey)
                {
                    return gdirectory.users.aliases.Watch(body, userKey);
                }
            }
            #endregion

            #region Users.photos
            public class Photos
            {
                public string Delete(string userKey)
                {
                    return gdirectory.users.photos.Delete(userKey);
                }

                public Data.UserPhoto Get(string userKey)
                {
                    return gdirectory.users.photos.Get(userKey);
                }

                public Data.UserPhoto Patch(Data.UserPhoto body, string userKey)
                {
                    return gdirectory.users.photos.Patch(body, userKey);
                }

                public Data.UserPhoto Update(Data.UserPhoto body, string userKey)
                {
                    return gdirectory.users.photos.Update(body, userKey);
                }
            }
            #endregion
        }
        #endregion

        #region Asps
        public class Asps
        {
            public string Delete(string userKey, int codeId)
            {
                return gdirectory.asps.Delete(userKey, codeId);
            }

            public Data.Asp Get(string userKey, int codeId)
            {
                return gdirectory.asps.Get(userKey, codeId);
            }

            public List<Data.Asp> List(string userKey)
            {
                return gdirectory.asps.List(userKey);
            }
        }
        #endregion

        #region Tokens
        public class Tokens
        {
            public string Delete(string userKey, string clientId)
            {
                return gdirectory.tokens.Delete(userKey, clientId);
            }

            public Data.Token Get(string userKey, string clientId)
            {
                return gdirectory.tokens.Get(userKey, clientId);
            }

            public List<Data.Token> List(string userKey)
            {
                return gdirectory.tokens.List(userKey);
            }
        }
        #endregion

        #region VerificationCodes
        public class VerificationCodes
        {
            public string Generate(string userKey)
            {
                return gdirectory.verificationCodes.Generate(userKey);
            }

            public string Invalidate(string userKey)
            {
                return gdirectory.verificationCodes.Invalidate(userKey);
            }

            public List<Data.VerificationCode> List(string userKey)
            {
                return gdirectory.verificationCodes.List(userKey);
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

                return gdirectory.notifications.List(customer);
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

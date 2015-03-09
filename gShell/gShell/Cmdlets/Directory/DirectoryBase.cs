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
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Google Apps domain, ex contoso.com. If none is provided the gShell default domain will be used.")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static Dictionary<string, List<Data.User>> cachedDomainUsers;
        protected static Dictionary<string, List<Data.Group>> cachedDomainGroups;
        protected static Dictionary<string, List<Data.Alias>> cachedDomainAliases;
        protected static Dictionary<string, Dictionary<string, List<Data.Member>>> cachedDomainGroupMembers;
        #endregion

        #region Generic Methods
        protected static string GetFullEmailAddress(string account, string domain)
        {
            return Utils.GetFullEmailAddress(account, domain);
        }

        protected override void BeginProcessing()
        {
            Domain = Authenticate(Domain);
        }

        protected static string GetMd5Hash(string s)
        {
            using (var md5Hasher = System.Security.Cryptography.MD5.Create())
            {
                var data = md5Hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(s));
                return BitConverter.ToString(data, 0).Replace("-", string.Empty);
            }
        }

        /// <summary>
        /// Generates a hashed password based on the input.
        /// </summary>
        /// <param name="PasswordLength">Min 8, max 100. Defaults to 8 if empty.</param>
        /// <param name="printPassword">Default false - prints the new password to screen.</param>
        /// <returns>New password in hex string format.</returns>
        protected static string GeneratePassword(int? PasswordLength, bool ShowNewPassword)
        {
            int PasswordLengthInt;
            if (PasswordLength < 8 || !PasswordLength.HasValue)
            {
                PasswordLength = 8;
            }
            else if (PasswordLength > 100)
            {
                PasswordLength = 100;
            }
            PasswordLengthInt = PasswordLength.Value;
            string newPassword = CreatePassword(PasswordLengthInt);
            //Console.WriteLine(newPassword);

            if (ShowNewPassword == true)
            {
                Console.WriteLine(newPassword);
            }

            return GetMd5Hash(newPassword);
        }

        /// <summary>
        /// Creates a random password of length.
        /// </summary>
        /// <param name="length"></param>
        /// <see cref="http://stackoverflow.com/questions/54991/generating-random-passwords"/>
        protected static string CreatePassword(int length)
        {
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!-%?";
            string res = "";
            Random rnd = new Random();
            while (0 < length--)
                res += valid[rnd.Next(valid.Length)];
            return res;
        }
        #endregion

        #region Wrapped Methods
        //the following methods assume that the service has been authenticated first.

        #region Chromeosdevices
        public class ChromeosDevices
        {
            public static Data.ChromeOsDevice Get(string customerId, string deviceId,
                directory_v1.ChromeosdevicesResource.GetRequest.ProjectionEnum? projection = null)
            {
                return gDirectory.ChromeosDevices.Get(customerId, deviceId, projection); 
            }

            public static List<Data.ChromeOsDevice> List(string customerId, gDirectory.ChromeosDevices.ChromeosDevicesListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.ChromeosDevices.ChromeosDevicesListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gDirectory.ChromeosDevices.List(customerId, properties);
            }

            public static Data.ChromeOsDevice Patch(Data.ChromeOsDevice body, string customerId, string deviceId,
                directory_v1.ChromeosdevicesResource.PatchRequest.ProjectionEnum? projection = null)
            {
                return gDirectory.ChromeosDevices.Patch(body, customerId, deviceId, projection);
            }

            public static Data.ChromeOsDevice Update(Data.ChromeOsDevice body, string customerId, string deviceId,
                directory_v1.ChromeosdevicesResource.UpdateRequest.ProjectionEnum? projection = null)
            {
                return gDirectory.ChromeosDevices.Update(body, customerId, deviceId, projection);
            }
        }
        #endregion

        #region Groups
        public class Groups
        {
            public static string Delete(string groupKey)
            {
                return gDirectory.Groups.Delete(groupKey);
            }

            public static Data.Group Get(string groupKey)
            {
                return gDirectory.Groups.Get(groupKey);
            }

            public static Data.Group Insert(Data.Group body)
            {
                return gDirectory.Groups.Insert(body);
            }

            public static List<Data.Group> List(gDirectory.Groups.GroupsListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.Groups.GroupsListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gDirectory.Groups.List(properties);
            }

            public static Data.Group Patch(Data.Group body, string groupKey)
            {
                return gDirectory.Groups.Patch(body, groupKey);
            }

            public static Data.Group Update(Data.Group body, string groupKey)
            {
                return gDirectory.Groups.Update(body, groupKey);
            }

            #region Groups.aliases
            public class Aliases
            {
                public static string Delete(string groupKey, string alias)
                {
                    return gDirectory.Groups.Aliases.Delete(groupKey, alias);
                }

                public static Data.Alias Insert(Data.Alias body, string groupKey)
                {
                    return gDirectory.Groups.Aliases.Insert(body, groupKey);
                }

                public static List<Data.Alias> List(string groupKey)
                {
                    return gDirectory.Groups.Aliases.List(groupKey);
                }
            }
            #endregion

        }
        #endregion

        #region Members
        public class Members
        {
            public static string Delete(string groupKey, string memberKey)
            {
                return gDirectory.Members.Delete(groupKey, memberKey);
            }

            public static Data.Member Get(string groupKey, string memberKey)
            {
                return gDirectory.Members.Get(groupKey, memberKey);
            }

            public static Data.Member Insert(Data.Member body, string groupKey)
            {
                return gDirectory.Members.Insert(body, groupKey);
            }

            public static List<Data.Member> List(string groupKey, gDirectory.Members.MembersListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.Members.MembersListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gDirectory.Members.List(groupKey, properties);
            }

            public static Data.Member Patch(Data.Member body, string groupKey, string memberKey)
            {
                return gDirectory.Members.Patch(body, groupKey, memberKey);
            }

            public static Data.Member Update(Data.Member body, string groupKey, string memberKey)
            {
                return gDirectory.Members.Update(body, groupKey, memberKey);
            }
        }
        #endregion

        #region MobileDevices
        public class MobileDevices
        {
            public static string Action(Data.MobileDeviceAction body, string customerId, string resourceId)
            {
                return gDirectory.MobileDevices.Action(body, customerId, resourceId);
            }

            public static string Delete(string customerId, string resourceId)
            {
                return gDirectory.MobileDevices.Delete(customerId, resourceId);
            }

            public static Data.MobileDevice Get(string customerId, string resourceId,
                directory_v1.MobiledevicesResource.GetRequest.ProjectionEnum? projection = null)
            {
                return gDirectory.MobileDevices.Get(customerId, resourceId, projection);
            }

            public static List<Data.MobileDevice> List(string customerId, gDirectory.MobileDevices.MobileDevicesPropertiesList properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.MobileDevices.MobileDevicesPropertiesList();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gDirectory.MobileDevices.List(customerId, properties);
            }
        }
        #endregion

        #region Orgunits
        public class Orgunits
        {
            public static string Delete(string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gDirectory.Orgunits.Delete(customerId, orgUnitPath);
            }

            public static Data.OrgUnit Get(string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gDirectory.Orgunits.Get(customerId, orgUnitPath);
            }

            public static Data.OrgUnit Insert(Data.OrgUnit body, string customerId)
            {
                return gDirectory.Orgunits.Insert(body, customerId);
            }

            public static List<Data.OrgUnit> List(string customerId, gDirectory.Orgunits.OrgunitsListProperties properties = null)
            {
                return gDirectory.Orgunits.List(customerId, properties);
            }

            public static Data.OrgUnit Patch(Data.OrgUnit body, string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gDirectory.Orgunits.Patch(body, customerId, orgUnitPath);
            }

            public static Data.OrgUnit Update(Data.OrgUnit body, string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return gDirectory.Orgunits.Update(body, customerId, orgUnitPath);
            }
        }
        #endregion

        #region Users
        public class Users
        {
            public static string Delete(string userKey)
            {
                return gDirectory.Users.Delete(userKey);
            }

            public static Data.User Get(string userKey,
                directory_v1.UsersResource.GetRequest.ProjectionEnum? projection = null,
                directory_v1.UsersResource.GetRequest.ViewTypeEnum? viewType = null)
            {
                return gDirectory.Users.Get(userKey, projection, viewType);
            }

            public static Data.User Insert(Data.User body)
            {
                return gDirectory.Users.Insert(body);
            }

            public static List<Data.User> List(gDirectory.Users.UsersListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.Users.UsersListProperties()
                {
                    maxResults = 500
                };
                properties.maxResults = (properties.maxResults == 0) ? 500 : properties.maxResults; //set it to the max if not specified
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gDirectory.Users.List(properties);
            }

            public static string MakeAdmin(Data.UserMakeAdmin body, string userKey)
            {
                return gDirectory.Users.MakeAdmin(body, userKey);
            }

            public static Data.User Patch(Data.User body, string userKey)
            {
                return gDirectory.Users.Patch(body, userKey);
            }

            public static string Undelete(Data.UserUndelete body, string userKey)
            {
                return gDirectory.Users.Undelete(body, userKey);
            }

            public static Data.User Update(Data.User body, string userKey)
            {
                return gDirectory.Users.Update(body, userKey);
            }

            public static Data.Channel Watch(Data.Channel body)
            {
                return gDirectory.Users.Watch(body);
            }

            #region Users.aliases
            public class Aliases
            {
                public static string Delete(string userKey, string alias)
                {
                    return gDirectory.Users.Aliases.Delete(userKey, alias);
                }

                public static Data.Alias Insert(Data.Alias body, string userKey)
                {
                    return gDirectory.Users.Aliases.Insert(body, userKey);
                }

                public static List<Data.Alias> List(string userKey)
                {
                    return gDirectory.Users.Aliases.List(userKey);
                }

                public static Data.Channel Watch(Data.Channel body, string userKey)
                {
                    return gDirectory.Users.Aliases.Watch(body, userKey);
                }
            }
            #endregion

            #region Users.photos
            public class Photos
            {
                public static string Delete(string userKey)
                {
                    return gDirectory.Users.Photos.Delete(userKey);
                }

                public static Data.UserPhoto Get(string userKey)
                {
                    return gDirectory.Users.Photos.Get(userKey);
                }

                public static Data.UserPhoto Patch(Data.UserPhoto body, string userKey)
                {
                    return gDirectory.Users.Photos.Patch(body, userKey);
                }

                public static Data.UserPhoto Update(Data.UserPhoto body, string userKey)
                {
                    return gDirectory.Users.Photos.Update(body, userKey);
                }
            }
            #endregion
        }
        #endregion

        #region Asps
        public class Asps
        {
            public static string Delete(string userKey, int codeId)
            {
                return gDirectory.Asps.Delete(userKey, codeId);
            }

            public static Data.Asp Get(string userKey, int codeId)
            {
                return gDirectory.Asps.Get(userKey, codeId);
            }

            public static List<Data.Asp> List(string userKey)
            {
                return gDirectory.Asps.List(userKey);
            }
        }
        #endregion

        #region Tokens
        public class Tokens
        {
            public static string Delete(string userKey, string clientId)
            {
                return gDirectory.Tokens.Delete(userKey, clientId);
            }

            public static Data.Token Get(string userKey, string clientId)
            {
                return gDirectory.Tokens.Get(userKey, clientId);
            }

            public static List<Data.Token> List(string userKey)
            {
                return gDirectory.Tokens.List(userKey);
            }
        }
        #endregion

        #region VerificationCodes
        public class VerificationCodes
        {
            public static string Generate(string userKey)
            {
                return gDirectory.VerificationCodes.Generate(userKey);
            }

            public static string Invalidate(string userKey)
            {
                return gDirectory.VerificationCodes.Invalidate(userKey);
            }

            public static List<Data.VerificationCode> List(string userKey)
            {
                return gDirectory.VerificationCodes.List(userKey);
            }
        }
        #endregion

        #region Notifications
        public class Notifications
        {
            public static string Delete(string customer, string notificationId)
            {
                return gDirectory.Notifications.Delete(customer, notificationId);
            }

            public static Data.Notification Get(string customer, string notificationId)
            {
                return gDirectory.Notifications.Get(customer, notificationId);
            }

            public static List<Data.Notification> List(string customer, gDirectory.Notifications.NotificationsListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gDirectory.Notifications.NotificationsListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return gDirectory.Notifications.List(customer);
            }

            public static Data.Notification Patch(Data.Notification body, string customer, string notificationId)
            {
                return gDirectory.Notifications.Patch(body, customer, notificationId);
            }

            public static Data.Notification Update(Data.Notification body, string customer, string notificationId)
            {
                return gDirectory.Notifications.Update(body, customer, notificationId);
            }
        }
        #endregion

        #region Channels
        public class Channels
        {
            public static string Stop(Data.Channel body)
            {
                return gDirectory.Channels.Stop(body);
            }
        }
        #endregion

        #region Schemas
        public class Schemas
        {
            public static string Delete(string customerId, string schemaKey)
            {
                return gDirectory.Schemas.Delete(customerId, schemaKey);
            }

            public static Data.Schema Get(string customerId, string schemaKey)
            {
                return gDirectory.Schemas.Get(customerId, schemaKey);
            }

            public static Data.Schema Insert(Data.Schema body, string customerId)
            {
                return gDirectory.Schemas.Insert(body, customerId);
            }

            public static List<Data.Schema> List(string customerId)
            {
                return gDirectory.Schemas.List(customerId);
            }

            public static Data.Schema Patch(Data.Schema body, string customerId, string schemaKey)
            {
                return gDirectory.Schemas.Patch(body, customerId, schemaKey);
            }

            public static Data.Schema Update(Data.Schema body, string customerId, string schemaKey)
            {
                return gDirectory.Schemas.Update(body, customerId, schemaKey);
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

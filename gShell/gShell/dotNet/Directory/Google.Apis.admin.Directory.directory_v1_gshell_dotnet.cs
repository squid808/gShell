namespace gShell.Cmdlets.Directory{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using directory_v1 = Google.Apis.admin.Directory.directory_v1;
    using Data = Google.Apis.admin.Directory.directory_v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gDirectory = gShell.dotNet.Directory;

    public abstract class DirectoryBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gDirectory mainBase { get; set; }

        public Asps asps { get; set; }
        public Channels channels { get; set; }
        public Chromeosdevices chromeosdevices { get; set; }
        public Customers customers { get; set; }
        public DomainAliases domainAliases { get; set; }
        public Domains domains { get; set; }
        public Groups groups { get; set; }
        public Members members { get; set; }
        public Mobiledevices mobiledevices { get; set; }
        public Notifications notifications { get; set; }
        public Orgunits orgunits { get; set; }
        public Privileges privileges { get; set; }
        public Resources resources { get; set; }
        public RoleAssignments roleAssignments { get; set; }
        public Roles roles { get; set; }
        public Schemas schemas { get; set; }
        public Tokens tokens { get; set; }
        public Users users { get; set; }
        public VerificationCodes verificationCodes { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }
        #endregion

        #region Constructors
        public DirectoryBase()
        {
            mainBase = new gDirectory();

            asps = new Asps();
            channels = new Channels();
            chromeosdevices = new Chromeosdevices();
            customers = new Customers();
            domainAliases = new DomainAliases();
            domains = new Domains();
            groups = new Groups();
            members = new Members();
            mobiledevices = new Mobiledevices();
            notifications = new Notifications();
            orgunits = new Orgunits();
            privileges = new Privileges();
            resources = new Resources();
            roleAssignments = new RoleAssignments();
            roles = new Roles();
            schemas = new Schemas();
            tokens = new Tokens();
            users = new Users();
            verificationCodes = new VerificationCodes();
        }
        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets();
            if (secrets != null)
            {
                IEnumerable<string> scopes = EnsureScopesExist(Domain);
                Domain = mainBase.BuildService(Authenticate(scopes, secrets, Domain)).domain;

                GWriteProgress = new gWriteProgress(WriteProgress);
            }
            else
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Client Secrets must be set before running cmdlets. Run 'Get-Help "
                    + "Set-gShellClientSecrets -online' for more information."))));
            }
        }
        #endregion

        #region Authentication & Processing
        protected override AuthenticatedUserInfo Authenticate(IEnumerable<string> Scopes, ClientSecrets Secrets, string Domain = null)
        {
            return mainBase.Authenticate(apiNameAndVersion, Scopes, Secrets, Domain);
        }
        #endregion

        #region Wrapped Methods



        #region Asps

        public class Asps
        {




            public void Delete (
            string

             userKey, int

             codeId)
            {

                mainBase.asps.Delete(
                userKey, codeId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Asp Get (
            string

             userKey, int

             codeId)
            {

                return mainBase.asps.Get(
                userKey, codeId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Asps List (
            string

             userKey)
            {

                return mainBase.asps.List(
                userKey);
            }
        }

        #endregion



        #region Channels

        public class Channels
        {




            public void Stop (
            Google.Apis.admin.Directory.directory_v1.Data.Channel body)
            {

                mainBase.channels.Stop(
                body);
            }
        }

        #endregion



        #region Chromeosdevices

        public class Chromeosdevices
        {




            public Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevice Get (
            string

             customerId, string

             deviceId, gDirectory.Chromeosdevices.ChromeosdevicesGetProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Chromeosdevices.ChromeosdevicesGetProperties();

                return mainBase.chromeosdevices.Get(
                customerId, deviceId, properties);
            }


            public List<Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevices> List(
            string

             customerId, gDirectory.Chromeosdevices.ChromeosdevicesListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Chromeosdevices.ChromeosdevicesListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.chromeosdevices.List(
                customerId, properties);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevice Patch (
            Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevice body, string

             customerId, string

             deviceId, gDirectory.Chromeosdevices.ChromeosdevicesPatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Chromeosdevices.ChromeosdevicesPatchProperties();

                return mainBase.chromeosdevices.Patch(
                body, customerId, deviceId, properties);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevice Update (
            Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevice body, string

             customerId, string

             deviceId, gDirectory.Chromeosdevices.ChromeosdevicesUpdateProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Chromeosdevices.ChromeosdevicesUpdateProperties();

                return mainBase.chromeosdevices.Update(
                body, customerId, deviceId, properties);
            }
        }

        #endregion



        #region Customers

        public class Customers
        {




            public Google.Apis.admin.Directory.directory_v1.Data.Customer Get (
            string

             customerKey)
            {

                return mainBase.customers.Get(
                customerKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Customer Patch (
            Google.Apis.admin.Directory.directory_v1.Data.Customer body, string

             customerKey)
            {

                return mainBase.customers.Patch(
                body, customerKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Customer Update (
            Google.Apis.admin.Directory.directory_v1.Data.Customer body, string

             customerKey)
            {

                return mainBase.customers.Update(
                body, customerKey);
            }
        }

        #endregion



        #region DomainAliases

        public class DomainAliases
        {




            public void Delete (
            string

             customer, string

             domainAliasName)
            {

                mainBase.domainAliases.Delete(
                customer, domainAliasName);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.DomainAlias Get (
            string

             customer, string

             domainAliasName)
            {

                return mainBase.domainAliases.Get(
                customer, domainAliasName);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.DomainAlias Insert (
            Google.Apis.admin.Directory.directory_v1.Data.DomainAlias body, string

             customer)
            {

                return mainBase.domainAliases.Insert(
                body, customer);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.DomainAliases List (
            string

             customer, gDirectory.DomainAliases.DomainAliasesListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.DomainAliases.DomainAliasesListProperties();

                return mainBase.domainAliases.List(
                customer, properties);
            }
        }

        #endregion



        #region Domains

        public class Domains
        {




            public void Delete (
            string

             customer, string

             domainName)
            {

                mainBase.domains.Delete(
                customer, domainName);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Domains Get (
            string

             customer, string

             domainName)
            {

                return mainBase.domains.Get(
                customer, domainName);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Domains Insert (
            Google.Apis.admin.Directory.directory_v1.Data.Domains body, string

             customer)
            {

                return mainBase.domains.Insert(
                body, customer);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Domains2 List (
            string

             customer)
            {

                return mainBase.domains.List(
                customer);
            }
        }

        #endregion



        #region Groups

        public class Groups
        {

            public Aliases aliases{ get; set; }

            public Groups() //public Reports()
            {

                aliases = new Aliases();
            }

            #region Aliases

            public class Aliases
            {




                public void Delete (
                string

                 groupKey, string

                 alias)
                {

                    mainBase.groups.aliases.Delete(
                    groupKey, alias);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.Alias Insert (
                Google.Apis.admin.Directory.directory_v1.Data.Alias body, string

                 groupKey)
                {

                    return mainBase.groups.aliases.Insert(
                    body, groupKey);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.Aliases List (
                string

                 groupKey)
                {

                    return mainBase.groups.aliases.List(
                    groupKey);
                }
            }

            #endregion


            public void Delete (
            string

             groupKey)
            {

                mainBase.groups.Delete(
                groupKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Group Get (
            string

             groupKey)
            {

                return mainBase.groups.Get(
                groupKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Group Insert (
            Google.Apis.admin.Directory.directory_v1.Data.Group body)
            {

                return mainBase.groups.Insert(
                body);
            }


            public List<Google.Apis.admin.Directory.directory_v1.Data.Groups> List(
            gDirectory.Groups.GroupsListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Groups.GroupsListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.groups.List(properties);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Group Patch (
            Google.Apis.admin.Directory.directory_v1.Data.Group body, string

             groupKey)
            {

                return mainBase.groups.Patch(
                body, groupKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Group Update (
            Google.Apis.admin.Directory.directory_v1.Data.Group body, string

             groupKey)
            {

                return mainBase.groups.Update(
                body, groupKey);
            }
        }

        #endregion



        #region Members

        public class Members
        {




            public void Delete (
            string

             groupKey, string

             memberKey)
            {

                mainBase.members.Delete(
                groupKey, memberKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Member Get (
            string

             groupKey, string

             memberKey)
            {

                return mainBase.members.Get(
                groupKey, memberKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Member Insert (
            Google.Apis.admin.Directory.directory_v1.Data.Member body, string

             groupKey)
            {

                return mainBase.members.Insert(
                body, groupKey);
            }


            public List<Google.Apis.admin.Directory.directory_v1.Data.Members> List(
            string

             groupKey, gDirectory.Members.MembersListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Members.MembersListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.members.List(
                groupKey, properties);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Member Patch (
            Google.Apis.admin.Directory.directory_v1.Data.Member body, string

             groupKey, string

             memberKey)
            {

                return mainBase.members.Patch(
                body, groupKey, memberKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Member Update (
            Google.Apis.admin.Directory.directory_v1.Data.Member body, string

             groupKey, string

             memberKey)
            {

                return mainBase.members.Update(
                body, groupKey, memberKey);
            }
        }

        #endregion



        #region Mobiledevices

        public class Mobiledevices
        {




            public void Action (
            Google.Apis.admin.Directory.directory_v1.Data.MobileDeviceAction body, string

             customerId, string

             resourceId)
            {

                mainBase.mobiledevices.Action(
                body, customerId, resourceId);
            }


            public void Delete (
            string

             customerId, string

             resourceId)
            {

                mainBase.mobiledevices.Delete(
                customerId, resourceId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.MobileDevice Get (
            string

             customerId, string

             resourceId, gDirectory.Mobiledevices.MobiledevicesGetProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Mobiledevices.MobiledevicesGetProperties();

                return mainBase.mobiledevices.Get(
                customerId, resourceId, properties);
            }


            public List<Google.Apis.admin.Directory.directory_v1.Data.MobileDevices> List(
            string

             customerId, gDirectory.Mobiledevices.MobiledevicesListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Mobiledevices.MobiledevicesListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.mobiledevices.List(
                customerId, properties);
            }
        }

        #endregion



        #region Notifications

        public class Notifications
        {




            public void Delete (
            string

             customer, string

             notificationId)
            {

                mainBase.notifications.Delete(
                customer, notificationId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Notification Get (
            string

             customer, string

             notificationId)
            {

                return mainBase.notifications.Get(
                customer, notificationId);
            }


            public List<Google.Apis.admin.Directory.directory_v1.Data.Notifications> List(
            string

             customer, gDirectory.Notifications.NotificationsListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Notifications.NotificationsListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.notifications.List(
                customer, properties);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Notification Patch (
            Google.Apis.admin.Directory.directory_v1.Data.Notification body, string

             customer, string

             notificationId)
            {

                return mainBase.notifications.Patch(
                body, customer, notificationId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Notification Update (
            Google.Apis.admin.Directory.directory_v1.Data.Notification body, string

             customer, string

             notificationId)
            {

                return mainBase.notifications.Update(
                body, customer, notificationId);
            }
        }

        #endregion



        #region Orgunits

        public class Orgunits
        {




            public void Delete (
            string

             customerId, Google.Apis.Util.Repeatable<string>

             orgUnitPath)
            {

                mainBase.orgunits.Delete(
                customerId, orgUnitPath);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.OrgUnit Get (
            string

             customerId, Google.Apis.Util.Repeatable<string>

             orgUnitPath)
            {

                return mainBase.orgunits.Get(
                customerId, orgUnitPath);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.OrgUnit Insert (
            Google.Apis.admin.Directory.directory_v1.Data.OrgUnit body, string

             customerId)
            {

                return mainBase.orgunits.Insert(
                body, customerId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.OrgUnits List (
            string

             customerId, gDirectory.Orgunits.OrgunitsListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Orgunits.OrgunitsListProperties();

                return mainBase.orgunits.List(
                customerId, properties);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.OrgUnit Patch (
            Google.Apis.admin.Directory.directory_v1.Data.OrgUnit body, string

             customerId, Google.Apis.Util.Repeatable<string>

             orgUnitPath)
            {

                return mainBase.orgunits.Patch(
                body, customerId, orgUnitPath);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.OrgUnit Update (
            Google.Apis.admin.Directory.directory_v1.Data.OrgUnit body, string

             customerId, Google.Apis.Util.Repeatable<string>

             orgUnitPath)
            {

                return mainBase.orgunits.Update(
                body, customerId, orgUnitPath);
            }
        }

        #endregion



        #region Privileges

        public class Privileges
        {




            public Google.Apis.admin.Directory.directory_v1.Data.Privileges List (
            string

             customer)
            {

                return mainBase.privileges.List(
                customer);
            }
        }

        #endregion



        #region Resources

        public class Resources
        {

            public Calendars calendars{ get; set; }

            public Resources() //public Reports()
            {

                calendars = new Calendars();
            }

            #region Calendars

            public class Calendars
            {




                public void Delete (
                string

                 customer, string

                 calendarResourceId)
                {

                    mainBase.resources.calendars.Delete(
                    customer, calendarResourceId);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.CalendarResource Get (
                string

                 customer, string

                 calendarResourceId)
                {

                    return mainBase.resources.calendars.Get(
                    customer, calendarResourceId);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.CalendarResource Insert (
                Google.Apis.admin.Directory.directory_v1.Data.CalendarResource body, string

                 customer)
                {

                    return mainBase.resources.calendars.Insert(
                    body, customer);
                }


                public List<Google.Apis.admin.Directory.directory_v1.Data.CalendarResources> List(
                string

                 customer, gDirectory.Resources.Calendars.CalendarsListProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gDirectory.Resources.Calendars.CalendarsListProperties();
                    properties.startProgressBar = StartProgressBar;
                    properties.updateProgressBar = UpdateProgressBar;

                    return mainBase.resources.calendars.List(
                    customer, properties);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.CalendarResource Patch (
                Google.Apis.admin.Directory.directory_v1.Data.CalendarResource body, string

                 customer, string

                 calendarResourceId)
                {

                    return mainBase.resources.calendars.Patch(
                    body, customer, calendarResourceId);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.CalendarResource Update (
                Google.Apis.admin.Directory.directory_v1.Data.CalendarResource body, string

                 customer, string

                 calendarResourceId)
                {

                    return mainBase.resources.calendars.Update(
                    body, customer, calendarResourceId);
                }
            }

            #endregion
        }

        #endregion



        #region RoleAssignments

        public class RoleAssignments
        {




            public void Delete (
            string

             customer, string

             roleAssignmentId)
            {

                mainBase.roleAssignments.Delete(
                customer, roleAssignmentId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.RoleAssignment Get (
            string

             customer, string

             roleAssignmentId)
            {

                return mainBase.roleAssignments.Get(
                customer, roleAssignmentId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.RoleAssignment Insert (
            Google.Apis.admin.Directory.directory_v1.Data.RoleAssignment body, string

             customer)
            {

                return mainBase.roleAssignments.Insert(
                body, customer);
            }


            public List<Google.Apis.admin.Directory.directory_v1.Data.RoleAssignments> List(
            string

             customer, gDirectory.RoleAssignments.RoleAssignmentsListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.RoleAssignments.RoleAssignmentsListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.roleAssignments.List(
                customer, properties);
            }
        }

        #endregion



        #region Roles

        public class Roles
        {




            public void Delete (
            string

             customer, string

             roleId)
            {

                mainBase.roles.Delete(
                customer, roleId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Role Get (
            string

             customer, string

             roleId)
            {

                return mainBase.roles.Get(
                customer, roleId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Role Insert (
            Google.Apis.admin.Directory.directory_v1.Data.Role body, string

             customer)
            {

                return mainBase.roles.Insert(
                body, customer);
            }


            public List<Google.Apis.admin.Directory.directory_v1.Data.Roles> List(
            string

             customer, gDirectory.Roles.RolesListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Roles.RolesListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.roles.List(
                customer, properties);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Role Patch (
            Google.Apis.admin.Directory.directory_v1.Data.Role body, string

             customer, string

             roleId)
            {

                return mainBase.roles.Patch(
                body, customer, roleId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Role Update (
            Google.Apis.admin.Directory.directory_v1.Data.Role body, string

             customer, string

             roleId)
            {

                return mainBase.roles.Update(
                body, customer, roleId);
            }
        }

        #endregion



        #region Schemas

        public class Schemas
        {




            public void Delete (
            string

             customerId, string

             schemaKey)
            {

                mainBase.schemas.Delete(
                customerId, schemaKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Schema Get (
            string

             customerId, string

             schemaKey)
            {

                return mainBase.schemas.Get(
                customerId, schemaKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Schema Insert (
            Google.Apis.admin.Directory.directory_v1.Data.Schema body, string

             customerId)
            {

                return mainBase.schemas.Insert(
                body, customerId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Schemas List (
            string

             customerId)
            {

                return mainBase.schemas.List(
                customerId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Schema Patch (
            Google.Apis.admin.Directory.directory_v1.Data.Schema body, string

             customerId, string

             schemaKey)
            {

                return mainBase.schemas.Patch(
                body, customerId, schemaKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Schema Update (
            Google.Apis.admin.Directory.directory_v1.Data.Schema body, string

             customerId, string

             schemaKey)
            {

                return mainBase.schemas.Update(
                body, customerId, schemaKey);
            }
        }

        #endregion



        #region Tokens

        public class Tokens
        {




            public void Delete (
            string

             userKey, string

             clientId)
            {

                mainBase.tokens.Delete(
                userKey, clientId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Token Get (
            string

             userKey, string

             clientId)
            {

                return mainBase.tokens.Get(
                userKey, clientId);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Tokens List (
            string

             userKey)
            {

                return mainBase.tokens.List(
                userKey);
            }
        }

        #endregion



        #region Users

        public class Users
        {

            public Aliases aliases{ get; set; }
            public Photos photos{ get; set; }

            public Users() //public Reports()
            {

                aliases = new Aliases();
                photos = new Photos();
            }

            #region Aliases

            public class Aliases
            {




                public void Delete (
                string

                 userKey, string

                 alias)
                {

                    mainBase.users.aliases.Delete(
                    userKey, alias);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.Alias Insert (
                Google.Apis.admin.Directory.directory_v1.Data.Alias body, string

                 userKey)
                {

                    return mainBase.users.aliases.Insert(
                    body, userKey);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.Aliases List (
                string

                 userKey, gDirectory.Users.Aliases.AliasesListProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gDirectory.Users.Aliases.AliasesListProperties();

                    return mainBase.users.aliases.List(
                    userKey, properties);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.Channel Watch (
                Google.Apis.admin.Directory.directory_v1.Data.Channel body, string

                 userKey, gDirectory.Users.Aliases.AliasesWatchProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gDirectory.Users.Aliases.AliasesWatchProperties();

                    return mainBase.users.aliases.Watch(
                    body, userKey, properties);
                }
            }

            #endregion
            #region Photos

            public class Photos
            {




                public void Delete (
                string

                 userKey)
                {

                    mainBase.users.photos.Delete(
                    userKey);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.UserPhoto Get (
                string

                 userKey)
                {

                    return mainBase.users.photos.Get(
                    userKey);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.UserPhoto Patch (
                Google.Apis.admin.Directory.directory_v1.Data.UserPhoto body, string

                 userKey)
                {

                    return mainBase.users.photos.Patch(
                    body, userKey);
                }


                public Google.Apis.admin.Directory.directory_v1.Data.UserPhoto Update (
                Google.Apis.admin.Directory.directory_v1.Data.UserPhoto body, string

                 userKey)
                {

                    return mainBase.users.photos.Update(
                    body, userKey);
                }
            }

            #endregion


            public void Delete (
            string

             userKey)
            {

                mainBase.users.Delete(
                userKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.User Get (
            string

             userKey, gDirectory.Users.UsersGetProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Users.UsersGetProperties();

                return mainBase.users.Get(
                userKey, properties);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.User Insert (
            Google.Apis.admin.Directory.directory_v1.Data.User body)
            {

                return mainBase.users.Insert(
                body);
            }


            public List<Google.Apis.admin.Directory.directory_v1.Data.Users> List(
            gDirectory.Users.UsersListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Users.UsersListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.users.List(properties);
            }


            public void MakeAdmin (
            Google.Apis.admin.Directory.directory_v1.Data.UserMakeAdmin body, string

             userKey)
            {

                mainBase.users.MakeAdmin(
                body, userKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.User Patch (
            Google.Apis.admin.Directory.directory_v1.Data.User body, string

             userKey)
            {

                return mainBase.users.Patch(
                body, userKey);
            }


            public void Undelete (
            Google.Apis.admin.Directory.directory_v1.Data.UserUndelete body, string

             userKey)
            {

                mainBase.users.Undelete(
                body, userKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.User Update (
            Google.Apis.admin.Directory.directory_v1.Data.User body, string

             userKey)
            {

                return mainBase.users.Update(
                body, userKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.Channel Watch (
            Google.Apis.admin.Directory.directory_v1.Data.Channel body, gDirectory.Users.UsersWatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDirectory.Users.UsersWatchProperties();

                return mainBase.users.Watch(
                body, properties);
            }
        }

        #endregion



        #region VerificationCodes

        public class VerificationCodes
        {




            public void Generate (
            string

             userKey)
            {

                mainBase.verificationCodes.Generate(
                userKey);
            }


            public void Invalidate (
            string

             userKey)
            {

                mainBase.verificationCodes.Invalidate(
                userKey);
            }


            public Google.Apis.admin.Directory.directory_v1.Data.VerificationCodes List (
            string

             userKey)
            {

                return mainBase.verificationCodes.List(
                userKey);
            }
        }

        #endregion

        #endregion

    }
}



namespace gShell.dotNet
{
    using System;
    using System.Collections.Generic;

    using gShell.dotNet;
    using gShell.dotNet.Utilities.OAuth2;

    using directory_v1 = Google.Apis.admin.Directory.directory_v1;
    using Data = Google.Apis.admin.Directory.directory_v1.Data;

    public class Directory : ServiceWrapper<directory_v1.DirectoryService>
    {

        protected override bool worksWithGmail { get { return false; } }

        protected override directory_v1.DirectoryService CreateNewService(string domain)
        {
            return new directory_v1.DirectoryService(OAuth2Base.GetInitializer(domain));
        }

        public override string apiNameAndVersion { get { return "admin:directory_v1"; } }

        public Asps asps{ get; set; }
        public Channels channels{ get; set; }
        public Chromeosdevices chromeosdevices{ get; set; }
        public Customers customers{ get; set; }
        public DomainAliases domainAliases{ get; set; }
        public Domains domains{ get; set; }
        public Groups groups{ get; set; }
        public Members members{ get; set; }
        public Mobiledevices mobiledevices{ get; set; }
        public Notifications notifications{ get; set; }
        public Orgunits orgunits{ get; set; }
        public Privileges privileges{ get; set; }
        public Resources resources{ get; set; }
        public RoleAssignments roleAssignments{ get; set; }
        public Roles roles{ get; set; }
        public Schemas schemas{ get; set; }
        public Tokens tokens{ get; set; }
        public Users users{ get; set; }
        public VerificationCodes verificationCodes{ get; set; }

        public Directory() //public Reports()
        {

            asps = new Asps();
            channels = new Channels();
            chromeosdevices = new Chromeosdevices();
            customers = new Customers();
            domainAliases = new DomainAliases();
            domains = new Domains();
            groups = new Groups();
            members = new Members();
            mobiledevices = new Mobiledevices();
            notifications = new Notifications();
            orgunits = new Orgunits();
            privileges = new Privileges();
            resources = new Resources();
            roleAssignments = new RoleAssignments();
            roles = new Roles();
            schemas = new Schemas();
            tokens = new Tokens();
            users = new Users();
            verificationCodes = new VerificationCodes();
        }




        public class Asps
        {





            public void Delete
            (string userKey, int codeId)
            {
                GetService().Asps.Delete(    userKey, codeId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Asp Get
            (string userKey, int codeId)
            {
                return GetService().Asps.Get(    userKey, codeId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Asps List
            (string userKey)
            {
                return GetService().Asps.List(    userKey).Execute();
            }

        }


        public class Channels
        {





            public void Stop
            (Google.Apis.admin.Directory.directory_v1.Data.Channel body)
            {
                GetService().Channels.Stop(    body).Execute();
            }

        }


        public class Chromeosdevices
        {



            public class ChromeosdevicesGetProperties
            {
                public    directory_v1.ChromeosdevicesResource.GetRequest.ProjectionEnum?     projection = null; //test
            }

            public class ChromeosdevicesListProperties
            {
                public int maxResults = 0;
                public    directory_v1.ChromeosdevicesResource.ListRequest.OrderByEnum?     orderBy = null; //test

                public    directory_v1.ChromeosdevicesResource.ListRequest.ProjectionEnum?     projection = null; //test
                public     string     query = null; //test
                public    directory_v1.ChromeosdevicesResource.ListRequest.SortOrderEnum?     sortOrder = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public class ChromeosdevicesPatchProperties
            {
                public    directory_v1.ChromeosdevicesResource.PatchRequest.ProjectionEnum?     projection = null; //test
            }

            public class ChromeosdevicesUpdateProperties
            {
                public    directory_v1.ChromeosdevicesResource.UpdateRequest.ProjectionEnum?     projection = null; //test
            }


            public Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevice Get
            (string customerId, string deviceId, ChromeosdevicesGetProperties properties = null)
            {
                return GetService().Chromeosdevices.Get(    customerId, deviceId).Execute();
            }

            public List<Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevices> List(
                string     customerId, ChromeosdevicesListProperties properties = null)
            {
                var results = new List<Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevices>();

                directory_v1.ChromeosdevicesResource.ListRequest request = GetService().Chromeosdevices.List(
                    customerId);

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;
                    request.OrderBy = properties.orderBy;
                    request.Projection = properties.projection;
                    request.Query = properties.query;
                    request.SortOrder = properties.sortOrder;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Chromeosdevices",
                        string.Format("-Collecting Chromeosdevices 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevices pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Chromeosdevices",
                                    string.Format("-Collecting Chromeosdevices {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Chromeosdevices",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevice Patch
            (Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevice body, string customerId, string deviceId, ChromeosdevicesPatchProperties properties = null)
            {
                return GetService().Chromeosdevices.Patch(    body, customerId, deviceId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevice Update
            (Google.Apis.admin.Directory.directory_v1.Data.ChromeOsDevice body, string customerId, string deviceId, ChromeosdevicesUpdateProperties properties = null)
            {
                return GetService().Chromeosdevices.Update(    body, customerId, deviceId).Execute();
            }

        }


        public class Customers
        {





            public Google.Apis.admin.Directory.directory_v1.Data.Customer Get
            (string customerKey)
            {
                return GetService().Customers.Get(    customerKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Customer Patch
            (Google.Apis.admin.Directory.directory_v1.Data.Customer body, string customerKey)
            {
                return GetService().Customers.Patch(    body, customerKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Customer Update
            (Google.Apis.admin.Directory.directory_v1.Data.Customer body, string customerKey)
            {
                return GetService().Customers.Update(    body, customerKey).Execute();
            }

        }


        public class DomainAliases
        {



            public class DomainAliasesListProperties
            {
                public     string     parentDomainName = null; //test
            }


            public void Delete
            (string customer, string domainAliasName)
            {
                GetService().DomainAliases.Delete(    customer, domainAliasName).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.DomainAlias Get
            (string customer, string domainAliasName)
            {
                return GetService().DomainAliases.Get(    customer, domainAliasName).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.DomainAlias Insert
            (Google.Apis.admin.Directory.directory_v1.Data.DomainAlias body, string customer)
            {
                return GetService().DomainAliases.Insert(    body, customer).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.DomainAliases List
            (string customer, DomainAliasesListProperties properties = null)
            {
                return GetService().DomainAliases.List(    customer).Execute();
            }

        }


        public class Domains
        {





            public void Delete
            (string customer, string domainName)
            {
                GetService().Domains.Delete(    customer, domainName).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Domains Get
            (string customer, string domainName)
            {
                return GetService().Domains.Get(    customer, domainName).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Domains Insert
            (Google.Apis.admin.Directory.directory_v1.Data.Domains body, string customer)
            {
                return GetService().Domains.Insert(    body, customer).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Domains2 List
            (string customer)
            {
                return GetService().Domains.List(    customer).Execute();
            }

        }


        public class Groups
        {

        public Aliases aliases{ get; set; }

        public Groups() //public Reports()
        {

            aliases = new Aliases();
        }


            public class GroupsListProperties
            {
                public     string     customer = null; //test
                public     string     domain = null; //test
                public int maxResults = 0;

                public     string     userKey = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public void Delete
            (string groupKey)
            {
                GetService().Groups.Delete(    groupKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Group Get
            (string groupKey)
            {
                return GetService().Groups.Get(    groupKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Group Insert
            (Google.Apis.admin.Directory.directory_v1.Data.Group body)
            {
                return GetService().Groups.Insert(    body).Execute();
            }

            public List<Google.Apis.admin.Directory.directory_v1.Data.Groups> List(
                GroupsListProperties properties = null)
            {
                var results = new List<Google.Apis.admin.Directory.directory_v1.Data.Groups>();

                directory_v1.GroupsResource.ListRequest request = GetService().Groups.List(
            );

                if (properties != null)
                {
                    request.Customer = properties.customer;
                    request.Domain = properties.domain;
                    request.MaxResults = properties.maxResults;
                    request.UserKey = properties.userKey;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Groups",
                        string.Format("-Collecting Groups 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Directory.directory_v1.Data.Groups pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Groups",
                                    string.Format("-Collecting Groups {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Groups",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Group Patch
            (Google.Apis.admin.Directory.directory_v1.Data.Group body, string groupKey)
            {
                return GetService().Groups.Patch(    body, groupKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Group Update
            (Google.Apis.admin.Directory.directory_v1.Data.Group body, string groupKey)
            {
                return GetService().Groups.Update(    body, groupKey).Execute();
            }


            public class Aliases
            {





                public void Delete
                (string groupKey, string alias)
                {
                    GetService().Groups.Aliases.Delete(    groupKey, alias).Execute();
                }

                public Google.Apis.admin.Directory.directory_v1.Data.Alias Insert
                (Google.Apis.admin.Directory.directory_v1.Data.Alias body, string groupKey)
                {
                    return GetService().Groups.Aliases.Insert(    body, groupKey).Execute();
                }

                public Google.Apis.admin.Directory.directory_v1.Data.Aliases List
                (string groupKey)
                {
                    return GetService().Groups.Aliases.List(    groupKey).Execute();
                }

            }

        }


        public class Members
        {



            public class MembersListProperties
            {
                public int maxResults = 0;

                public     string     roles = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public void Delete
            (string groupKey, string memberKey)
            {
                GetService().Members.Delete(    groupKey, memberKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Member Get
            (string groupKey, string memberKey)
            {
                return GetService().Members.Get(    groupKey, memberKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Member Insert
            (Google.Apis.admin.Directory.directory_v1.Data.Member body, string groupKey)
            {
                return GetService().Members.Insert(    body, groupKey).Execute();
            }

            public List<Google.Apis.admin.Directory.directory_v1.Data.Members> List(
                string     groupKey, MembersListProperties properties = null)
            {
                var results = new List<Google.Apis.admin.Directory.directory_v1.Data.Members>();

                directory_v1.MembersResource.ListRequest request = GetService().Members.List(
                    groupKey);

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;
                    request.Roles = properties.roles;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Members",
                        string.Format("-Collecting Members 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Directory.directory_v1.Data.Members pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Members",
                                    string.Format("-Collecting Members {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Members",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Member Patch
            (Google.Apis.admin.Directory.directory_v1.Data.Member body, string groupKey, string memberKey)
            {
                return GetService().Members.Patch(    body, groupKey, memberKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Member Update
            (Google.Apis.admin.Directory.directory_v1.Data.Member body, string groupKey, string memberKey)
            {
                return GetService().Members.Update(    body, groupKey, memberKey).Execute();
            }

        }


        public class Mobiledevices
        {



            public class MobiledevicesGetProperties
            {
                public    directory_v1.MobiledevicesResource.GetRequest.ProjectionEnum?     projection = null; //test
            }

            public class MobiledevicesListProperties
            {
                public int maxResults = 0;
                public    directory_v1.MobiledevicesResource.ListRequest.OrderByEnum?     orderBy = null; //test

                public    directory_v1.MobiledevicesResource.ListRequest.ProjectionEnum?     projection = null; //test
                public     string     query = null; //test
                public    directory_v1.MobiledevicesResource.ListRequest.SortOrderEnum?     sortOrder = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public void Action
            (Google.Apis.admin.Directory.directory_v1.Data.MobileDeviceAction body, string customerId, string resourceId)
            {
                GetService().Mobiledevices.Action(    body, customerId, resourceId).Execute();
            }

            public void Delete
            (string customerId, string resourceId)
            {
                GetService().Mobiledevices.Delete(    customerId, resourceId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.MobileDevice Get
            (string customerId, string resourceId, MobiledevicesGetProperties properties = null)
            {
                return GetService().Mobiledevices.Get(    customerId, resourceId).Execute();
            }

            public List<Google.Apis.admin.Directory.directory_v1.Data.MobileDevices> List(
                string     customerId, MobiledevicesListProperties properties = null)
            {
                var results = new List<Google.Apis.admin.Directory.directory_v1.Data.MobileDevices>();

                directory_v1.MobiledevicesResource.ListRequest request = GetService().Mobiledevices.List(
                    customerId);

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;
                    request.OrderBy = properties.orderBy;
                    request.Projection = properties.projection;
                    request.Query = properties.query;
                    request.SortOrder = properties.sortOrder;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Mobiledevices",
                        string.Format("-Collecting Mobiledevices 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Directory.directory_v1.Data.MobileDevices pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Mobiledevices",
                                    string.Format("-Collecting Mobiledevices {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Mobiledevices",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

        }


        public class Notifications
        {



            public class NotificationsListProperties
            {
                public     string     language = null; //test
                public int maxResults = 0;

                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public void Delete
            (string customer, string notificationId)
            {
                GetService().Notifications.Delete(    customer, notificationId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Notification Get
            (string customer, string notificationId)
            {
                return GetService().Notifications.Get(    customer, notificationId).Execute();
            }

            public List<Google.Apis.admin.Directory.directory_v1.Data.Notifications> List(
                string     customer, NotificationsListProperties properties = null)
            {
                var results = new List<Google.Apis.admin.Directory.directory_v1.Data.Notifications>();

                directory_v1.NotificationsResource.ListRequest request = GetService().Notifications.List(
                    customer);

                if (properties != null)
                {
                    request.Language = properties.language;
                    request.MaxResults = properties.maxResults;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Notifications",
                        string.Format("-Collecting Notifications 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Directory.directory_v1.Data.Notifications pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Notifications",
                                    string.Format("-Collecting Notifications {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Notifications",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Notification Patch
            (Google.Apis.admin.Directory.directory_v1.Data.Notification body, string customer, string notificationId)
            {
                return GetService().Notifications.Patch(    body, customer, notificationId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Notification Update
            (Google.Apis.admin.Directory.directory_v1.Data.Notification body, string customer, string notificationId)
            {
                return GetService().Notifications.Update(    body, customer, notificationId).Execute();
            }

        }


        public class Orgunits
        {



            public class OrgunitsListProperties
            {
                public     string     orgUnitPath = null; //test
                public    directory_v1.OrgunitsResource.ListRequest.TypeEnum?     type = null; //test
            }


            public void Delete
            (string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                GetService().Orgunits.Delete(    customerId, orgUnitPath).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.OrgUnit Get
            (string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return GetService().Orgunits.Get(    customerId, orgUnitPath).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.OrgUnit Insert
            (Google.Apis.admin.Directory.directory_v1.Data.OrgUnit body, string customerId)
            {
                return GetService().Orgunits.Insert(    body, customerId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.OrgUnits List
            (string customerId, OrgunitsListProperties properties = null)
            {
                return GetService().Orgunits.List(    customerId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.OrgUnit Patch
            (Google.Apis.admin.Directory.directory_v1.Data.OrgUnit body, string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return GetService().Orgunits.Patch(    body, customerId, orgUnitPath).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.OrgUnit Update
            (Google.Apis.admin.Directory.directory_v1.Data.OrgUnit body, string customerId, Google.Apis.Util.Repeatable<string> orgUnitPath)
            {
                return GetService().Orgunits.Update(    body, customerId, orgUnitPath).Execute();
            }

        }


        public class Privileges
        {





            public Google.Apis.admin.Directory.directory_v1.Data.Privileges List
            (string customer)
            {
                return GetService().Privileges.List(    customer).Execute();
            }

        }


        public class Resources
        {

        public Calendars calendars{ get; set; }

        public Resources() //public Reports()
        {

            calendars = new Calendars();
        }





            public class Calendars
            {



                public class CalendarsListProperties
                {
                    public int maxResults = 500;

                    public Action<string, string> startProgressBar = null;
                    public Action<int, int, string, string> updateProgressBar = null;
                    public int totalResults = 0;
                }


                public void Delete
                (string customer, string calendarResourceId)
                {
                    GetService().Resources.Calendars.Delete(    customer, calendarResourceId).Execute();
                }

                public Google.Apis.admin.Directory.directory_v1.Data.CalendarResource Get
                (string customer, string calendarResourceId)
                {
                    return GetService().Resources.Calendars.Get(    customer, calendarResourceId).Execute();
                }

                public Google.Apis.admin.Directory.directory_v1.Data.CalendarResource Insert
                (Google.Apis.admin.Directory.directory_v1.Data.CalendarResource body, string customer)
                {
                    return GetService().Resources.Calendars.Insert(    body, customer).Execute();
                }

                public List<Google.Apis.admin.Directory.directory_v1.Data.CalendarResources> List(
                    string     customer, CalendarsListProperties properties = null)
                {
                    var results = new List<Google.Apis.admin.Directory.directory_v1.Data.CalendarResources>();

                    directory_v1.ResourcesResource.CalendarsResource.ListRequest request = GetService().Resources.Calendars.List(
                        customer);

                    if (properties != null)
                    {
                        request.MaxResults = properties.maxResults;

                    }

                    if (null != properties.startProgressBar)
                    {
                        properties.startProgressBar("Gathering Calendars",
                            string.Format("-Collecting Calendars 1 to {0}", request.MaxResults.ToString()));
                    }

                    Google.Apis.admin.Directory.directory_v1.Data.CalendarResources pagedResult = request.Execute();

                    if (pagedResult != null)
                    {
                        results.Add(pagedResult);

                        while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                            pagedResult.NextPageToken != request.PageToken &&
                        (properties.totalResults == 0 || results.Count < properties.totalResults))
                        {
                            request.PageToken = pagedResult.NextPageToken;

                            if (null != properties.updateProgressBar)
                            {
                                properties.updateProgressBar(5, 10, "Gathering Calendars",
                                        string.Format("-Collecting Calendars {0} to {1}",
                                            (results.Count + 1).ToString(),
                                            (results.Count + request.MaxResults).ToString()));
                            }
                            pagedResult = request.Execute();
                            results.Add(pagedResult);
                        }

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(1, 2, "Gathering Calendars",
                                    string.Format("-Returning {0} results.", results.Count.ToString()));
                        }
                    }

                    return results;
                }

                public Google.Apis.admin.Directory.directory_v1.Data.CalendarResource Patch
                (Google.Apis.admin.Directory.directory_v1.Data.CalendarResource body, string customer, string calendarResourceId)
                {
                    return GetService().Resources.Calendars.Patch(    body, customer, calendarResourceId).Execute();
                }

                public Google.Apis.admin.Directory.directory_v1.Data.CalendarResource Update
                (Google.Apis.admin.Directory.directory_v1.Data.CalendarResource body, string customer, string calendarResourceId)
                {
                    return GetService().Resources.Calendars.Update(    body, customer, calendarResourceId).Execute();
                }

            }

        }


        public class RoleAssignments
        {



            public class RoleAssignmentsListProperties
            {
                public int maxResults = 200;

                public     string     roleId = null; //test
                public     string     userKey = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public void Delete
            (string customer, string roleAssignmentId)
            {
                GetService().RoleAssignments.Delete(    customer, roleAssignmentId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.RoleAssignment Get
            (string customer, string roleAssignmentId)
            {
                return GetService().RoleAssignments.Get(    customer, roleAssignmentId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.RoleAssignment Insert
            (Google.Apis.admin.Directory.directory_v1.Data.RoleAssignment body, string customer)
            {
                return GetService().RoleAssignments.Insert(    body, customer).Execute();
            }

            public List<Google.Apis.admin.Directory.directory_v1.Data.RoleAssignments> List(
                string     customer, RoleAssignmentsListProperties properties = null)
            {
                var results = new List<Google.Apis.admin.Directory.directory_v1.Data.RoleAssignments>();

                directory_v1.RoleAssignmentsResource.ListRequest request = GetService().RoleAssignments.List(
                    customer);

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;
                    request.RoleId = properties.roleId;
                    request.UserKey = properties.userKey;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering RoleAssignments",
                        string.Format("-Collecting RoleAssignments 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Directory.directory_v1.Data.RoleAssignments pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering RoleAssignments",
                                    string.Format("-Collecting RoleAssignments {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering RoleAssignments",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

        }


        public class Roles
        {



            public class RolesListProperties
            {
                public int maxResults = 100;

                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public void Delete
            (string customer, string roleId)
            {
                GetService().Roles.Delete(    customer, roleId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Role Get
            (string customer, string roleId)
            {
                return GetService().Roles.Get(    customer, roleId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Role Insert
            (Google.Apis.admin.Directory.directory_v1.Data.Role body, string customer)
            {
                return GetService().Roles.Insert(    body, customer).Execute();
            }

            public List<Google.Apis.admin.Directory.directory_v1.Data.Roles> List(
                string     customer, RolesListProperties properties = null)
            {
                var results = new List<Google.Apis.admin.Directory.directory_v1.Data.Roles>();

                directory_v1.RolesResource.ListRequest request = GetService().Roles.List(
                    customer);

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Roles",
                        string.Format("-Collecting Roles 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Directory.directory_v1.Data.Roles pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Roles",
                                    string.Format("-Collecting Roles {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Roles",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Role Patch
            (Google.Apis.admin.Directory.directory_v1.Data.Role body, string customer, string roleId)
            {
                return GetService().Roles.Patch(    body, customer, roleId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Role Update
            (Google.Apis.admin.Directory.directory_v1.Data.Role body, string customer, string roleId)
            {
                return GetService().Roles.Update(    body, customer, roleId).Execute();
            }

        }


        public class Schemas
        {





            public void Delete
            (string customerId, string schemaKey)
            {
                GetService().Schemas.Delete(    customerId, schemaKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Schema Get
            (string customerId, string schemaKey)
            {
                return GetService().Schemas.Get(    customerId, schemaKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Schema Insert
            (Google.Apis.admin.Directory.directory_v1.Data.Schema body, string customerId)
            {
                return GetService().Schemas.Insert(    body, customerId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Schemas List
            (string customerId)
            {
                return GetService().Schemas.List(    customerId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Schema Patch
            (Google.Apis.admin.Directory.directory_v1.Data.Schema body, string customerId, string schemaKey)
            {
                return GetService().Schemas.Patch(    body, customerId, schemaKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Schema Update
            (Google.Apis.admin.Directory.directory_v1.Data.Schema body, string customerId, string schemaKey)
            {
                return GetService().Schemas.Update(    body, customerId, schemaKey).Execute();
            }

        }


        public class Tokens
        {





            public void Delete
            (string userKey, string clientId)
            {
                GetService().Tokens.Delete(    userKey, clientId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Token Get
            (string userKey, string clientId)
            {
                return GetService().Tokens.Get(    userKey, clientId).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Tokens List
            (string userKey)
            {
                return GetService().Tokens.List(    userKey).Execute();
            }

        }


        public class Users
        {

        public Aliases aliases{ get; set; }
        public Photos photos{ get; set; }

        public Users() //public Reports()
        {

            aliases = new Aliases();
            photos = new Photos();
        }


            public class UsersGetProperties
            {
                public     string     customFieldMask = null; //test
                public    directory_v1.UsersResource.GetRequest.ProjectionEnum?     projection = null; //test
                public    directory_v1.UsersResource.GetRequest.ViewTypeEnum?     viewType = null; //test
            }

            public class UsersListProperties
            {
                public     string     customFieldMask = null; //test
                public     string     customer = null; //test
                public     string     domain = null; //test
                public    directory_v1.UsersResource.ListRequest.EventEnum?     adminEvent = null; //test
                public int maxResults = 500;
                public    directory_v1.UsersResource.ListRequest.OrderByEnum?     orderBy = null; //test

                public    directory_v1.UsersResource.ListRequest.ProjectionEnum?     projection = null; //test
                public     string     query = null; //test
                public     string     showDeleted = null; //test
                public    directory_v1.UsersResource.ListRequest.SortOrderEnum?     sortOrder = null; //test
                public    directory_v1.UsersResource.ListRequest.ViewTypeEnum?     viewType = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public class UsersWatchProperties
            {
                public     string     customFieldMask = null; //test
                public     string     customer = null; //test
                public     string     domain = null; //test
                public    directory_v1.UsersResource.WatchRequest.EventEnum?     adminEvent = null; //test
                public int maxResults = 500;
                public    directory_v1.UsersResource.WatchRequest.OrderByEnum?     orderBy = null; //test

                public    directory_v1.UsersResource.WatchRequest.ProjectionEnum?     projection = null; //test
                public     string     query = null; //test
                public     string     showDeleted = null; //test
                public    directory_v1.UsersResource.WatchRequest.SortOrderEnum?     sortOrder = null; //test
                public    directory_v1.UsersResource.WatchRequest.ViewTypeEnum?     viewType = null; //test
            }


            public void Delete
            (string userKey)
            {
                GetService().Users.Delete(    userKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.User Get
            (string userKey, UsersGetProperties properties = null)
            {
                return GetService().Users.Get(    userKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.User Insert
            (Google.Apis.admin.Directory.directory_v1.Data.User body)
            {
                return GetService().Users.Insert(    body).Execute();
            }

            public List<Google.Apis.admin.Directory.directory_v1.Data.Users> List(
                UsersListProperties properties = null)
            {
                var results = new List<Google.Apis.admin.Directory.directory_v1.Data.Users>();

                directory_v1.UsersResource.ListRequest request = GetService().Users.List(
            );

                if (properties != null)
                {
                    request.CustomFieldMask = properties.customFieldMask;
                    request.Customer = properties.customer;
                    request.Domain = properties.domain;
                    request.Event = properties.adminEvent;
                    request.MaxResults = properties.maxResults;
                    request.OrderBy = properties.orderBy;
                    request.Projection = properties.projection;
                    request.Query = properties.query;
                    request.ShowDeleted = properties.showDeleted;
                    request.SortOrder = properties.sortOrder;
                    request.ViewType = properties.viewType;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Users",
                        string.Format("-Collecting Users 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Directory.directory_v1.Data.Users pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Users",
                                    string.Format("-Collecting Users {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Users",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public void MakeAdmin
            (Google.Apis.admin.Directory.directory_v1.Data.UserMakeAdmin body, string userKey)
            {
                GetService().Users.MakeAdmin(    body, userKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.User Patch
            (Google.Apis.admin.Directory.directory_v1.Data.User body, string userKey)
            {
                return GetService().Users.Patch(    body, userKey).Execute();
            }

            public void Undelete
            (Google.Apis.admin.Directory.directory_v1.Data.UserUndelete body, string userKey)
            {
                GetService().Users.Undelete(    body, userKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.User Update
            (Google.Apis.admin.Directory.directory_v1.Data.User body, string userKey)
            {
                return GetService().Users.Update(    body, userKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.Channel Watch
            (Google.Apis.admin.Directory.directory_v1.Data.Channel body, UsersWatchProperties properties = null)
            {
                return GetService().Users.Watch(    body).Execute();
            }


            public class Aliases
            {



                public class AliasesListProperties
                {
                    public    directory_v1.UsersResource.AliasesResource.ListRequest.EventEnum?     adminEvent = null; //test
                }

                public class AliasesWatchProperties
                {
                    public    directory_v1.UsersResource.AliasesResource.WatchRequest.EventEnum?     adminEvent = null; //test
                }


                public void Delete
                (string userKey, string alias)
                {
                    GetService().Users.Aliases.Delete(    userKey, alias).Execute();
                }

                public Google.Apis.admin.Directory.directory_v1.Data.Alias Insert
                (Google.Apis.admin.Directory.directory_v1.Data.Alias body, string userKey)
                {
                    return GetService().Users.Aliases.Insert(    body, userKey).Execute();
                }

                public Google.Apis.admin.Directory.directory_v1.Data.Aliases List
                (string userKey, AliasesListProperties properties = null)
                {
                    return GetService().Users.Aliases.List(    userKey).Execute();
                }

                public Google.Apis.admin.Directory.directory_v1.Data.Channel Watch
                (Google.Apis.admin.Directory.directory_v1.Data.Channel body, string userKey, AliasesWatchProperties properties = null)
                {
                    return GetService().Users.Aliases.Watch(    body, userKey).Execute();
                }

            }


            public class Photos
            {





                public void Delete
                (string userKey)
                {
                    GetService().Users.Photos.Delete(    userKey).Execute();
                }

                public Google.Apis.admin.Directory.directory_v1.Data.UserPhoto Get
                (string userKey)
                {
                    return GetService().Users.Photos.Get(    userKey).Execute();
                }

                public Google.Apis.admin.Directory.directory_v1.Data.UserPhoto Patch
                (Google.Apis.admin.Directory.directory_v1.Data.UserPhoto body, string userKey)
                {
                    return GetService().Users.Photos.Patch(    body, userKey).Execute();
                }

                public Google.Apis.admin.Directory.directory_v1.Data.UserPhoto Update
                (Google.Apis.admin.Directory.directory_v1.Data.UserPhoto body, string userKey)
                {
                    return GetService().Users.Photos.Update(    body, userKey).Execute();
                }

            }

        }


        public class VerificationCodes
        {





            public void Generate
            (string userKey)
            {
                GetService().VerificationCodes.Generate(    userKey).Execute();
            }

            public void Invalidate
            (string userKey)
            {
                GetService().VerificationCodes.Invalidate(    userKey).Execute();
            }

            public Google.Apis.admin.Directory.directory_v1.Data.VerificationCodes List
            (string userKey)
            {
                return GetService().VerificationCodes.List(    userKey).Execute();
            }

        }

    }
}
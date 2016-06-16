using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

using gCalendar = gShell.dotNet.Calendar;

namespace gShell.Cmdlets.Calendar
{
    public abstract class CalendarServiceAccountBase : CalendarBase
    {
        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string aTargetUserEmail { get; set; }
        #endregion

        protected override void BeginProcessing()
        {
            gShellServiceAccount = aTargetUserEmail;

            base.BeginProcessing();
        }
    }

    

    [Cmdlet(VerbsCommon.New, "GCalendarEventReminderObj",
    SupportsShouldProcess = true)]
    public class NewGCalendarEventReminderObj : PSCmdlet
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = false)]
        public string Method { get; set; }

        [Parameter(Position = 1,
        Mandatory = false)]
        public System.Nullable<int> Minutes { get; set; }
        #endregion

         protected override void ProcessRecord()
        {
            var body = new EventReminder()
            {
                Method = this.Method,
                Minutes = this.Minutes,
            };

            if (ShouldProcess("Calendar EventReminder", "New-GCalendarEventReminderObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GCalendarEventAttachmentObj",
    SupportsShouldProcess = true)]
    public class NewGCalendarEventAttachmentObj : PSCmdlet
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = false)]
        public string FileId { get; set; }

        [Parameter(Position = 1,
        Mandatory = false)]
        public string FileUrl { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public string IconLink { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public string MimeType { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public string Title { get; set; }
        #endregion

         protected override void ProcessRecord()
        {
            var body = new EventAttachment()
            {
                FileId = this.FileId,
                FileUrl = this.FileUrl,
                IconLink = this.IconLink,
                MimeType = this.MimeType,
                Title = this.Title,
            };

            if (ShouldProcess("Calendar EventAttachment", "New-GCalendarEventAttachmentObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GCalendarEventAttendeeObj",
    SupportsShouldProcess = true)]
    public class NewGCalendarEventAttendeeObj : PSCmdlet
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = false)]
        public System.Nullable<int> AdditionalGuests { get; set; }

        [Parameter(Position = 1,
        Mandatory = false)]
        public string Comment { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public string DisplayName { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public string Email { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public string Id { get; set; }

        [Parameter(Position = 5,
        Mandatory = false)]
        public System.Nullable<bool> Optional { get; set; }

        [Parameter(Position = 6,
        Mandatory = false)]
        public System.Nullable<bool> Organizer { get; set; }

        [Parameter(Position = 7,
        Mandatory = false)]
        public System.Nullable<bool> Resource { get; set; }

        [Parameter(Position = 8,
        Mandatory = false)]
        public string ResponseStatus { get; set; }

        [Parameter(Position = 9,
        Mandatory = false)]
        public System.Nullable<bool> Self { get; set; }
        #endregion

         protected override void ProcessRecord()
        {
            var body = new EventAttendee()
            {
                AdditionalGuests = this.AdditionalGuests,
                Comment = this.Comment,
                DisplayName = this.DisplayName,
                Email = this.Email,
                Id = this.Id,
                Optional = this.Optional,
                Organizer = this.Organizer,
                Resource = this.Resource,
                ResponseStatus = this.ResponseStatus,
                Self = this.Self,
            };

            if (ShouldProcess("Calendar EventAttendee", "New-GCalendarEventAttendeeObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GCalendarEventDateTimeObj",
    SupportsShouldProcess = true)]
    public class NewGCalendarEventDateTimeObj : PSCmdlet
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = false)]
        public string Date { get; set; }

        [Parameter(Position = 1,
        Mandatory = false)]
        public System.Nullable<System.DateTime> DateTime { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public string TimeZone { get; set; }
        #endregion

         protected override void ProcessRecord()
        {
            var body = new EventDateTime()
            {
                Date = this.Date,
                DateTime = this.DateTime,
                TimeZone = this.TimeZone,
            };

            if (ShouldProcess("Calendar EventDateTime", "New-GCalendarEventDateTimeObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GCalendarFreeBusyRequestItemObj",
    SupportsShouldProcess = true)]
    public class NewGCalendarFreeBusyRequestItemObj : PSCmdlet
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = false)]
        public string Id { get; set; }
        #endregion

         protected override void ProcessRecord()
        {
            var body = new FreeBusyRequestItem()
            {
                Id = this.Id,
            };

            if (ShouldProcess("Calendar FreeBusyRequestItem", "New-GCalendarFreeBusyRequestItemObj"))
            {
                WriteObject(body);
            }
        }
    }
}







namespace gShell.Cmdlets.Calendar.Acl
{


    [Cmdlet("Delete", "GCalendarAcl",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/acl/delete")]
    public class DeleteGCalendarAclCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public string RuleId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Acl", "Delete-GCalendarAcl"))
            {

                acl.Delete(CalendarId, RuleId);
            }

        }
    }
    [Cmdlet("Get", "GCalendarAcl",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/acl/get")]
    public class GetGCalendarAclCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public string RuleId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Acl", "Get-GCalendarAcl"))
            {

                 WriteObject(acl.Get(CalendarId, RuleId));
            }

        }
    }
    [Cmdlet("Insert", "GCalendarAcl",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/acl/insert")]
    public class InsertGCalendarAclCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 2,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.AclRule AclRuleBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Acl", "Insert-GCalendarAcl"))
            {

                 WriteObject(acl.Insert(AclRuleBody, CalendarId));
            }

        }
    }
    [Cmdlet("List", "GCalendarAcl",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/acl/list")]
    public class ListGCalendarAclCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = false)]
        public System.Nullable<int> MaxResults { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<bool> ShowDeleted { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public string SyncToken { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Acl", "List-GCalendarAcl"))
            {

                var properties = new gCalendar.Acl.AclListProperties()
                {
                    showDeleted = this.ShowDeleted,
                    syncToken = this.SyncToken
                };


                 WriteObject(acl.List(CalendarId, properties));
            }

        }
    }
    [Cmdlet("Patch", "GCalendarAcl",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/acl/patch")]
    public class PatchGCalendarAclCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public string RuleId { get; set; }

        [Parameter(Position = 2,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.AclRule AclRuleBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Acl", "Patch-GCalendarAcl"))
            {

                 WriteObject(acl.Patch(AclRuleBody, CalendarId, RuleId));
            }

        }
    }
    [Cmdlet("Update", "GCalendarAcl",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/acl/update")]
    public class UpdateGCalendarAclCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public string RuleId { get; set; }

        [Parameter(Position = 2,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.AclRule AclRuleBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Acl", "Update-GCalendarAcl"))
            {

                 WriteObject(acl.Update(AclRuleBody, CalendarId, RuleId));
            }

        }
    }
    [Cmdlet("Watch", "GCalendarAcl",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/acl/watch")]
    public class WatchGCalendarAclCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<int> MaxResults { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public System.Nullable<bool> ShowDeleted { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public string SyncToken { get; set; }

        [Parameter(Position = 0,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Channel ChannelBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Acl", "Watch-GCalendarAcl"))
            {

                var properties = new gCalendar.Acl.AclWatchProperties()
                {
                    showDeleted = this.ShowDeleted,
                    syncToken = this.SyncToken
                };


                 WriteObject(acl.Watch(ChannelBody, CalendarId, properties));
            }

        }
    }

}

namespace gShell.Cmdlets.Calendar.CalendarList
{


    [Cmdlet("Delete", "GCalendarCalendarList",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendarList/delete")]
    public class DeleteGCalendarCalendarListCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar CalendarList", "Delete-GCalendarCalendarList"))
            {

                calendarList.Delete(CalendarId);
            }

        }
    }
    [Cmdlet("Get", "GCalendarCalendarList",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendarList/get")]
    public class GetGCalendarCalendarListCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar CalendarList", "Get-GCalendarCalendarList"))
            {

                 WriteObject(calendarList.Get(CalendarId));
            }

        }
    }
    [Cmdlet("Insert", "GCalendarCalendarList",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendarList/insert")]
    public class InsertGCalendarCalendarListCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 1,
        Mandatory = false)]
        public System.Nullable<bool> ColorRgbFormat { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.CalendarListEntry CalendarListEntryBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar CalendarList", "Insert-GCalendarCalendarList"))
            {

                var properties = new gCalendar.CalendarList.CalendarListInsertProperties()
                {
                    colorRgbFormat = this.ColorRgbFormat
                };


                 WriteObject(calendarList.Insert(CalendarListEntryBody, properties));
            }

        }
    }
    [Cmdlet("List", "GCalendarCalendarList",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendarList/list")]
    public class ListGCalendarCalendarListCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = false)]
        public System.Nullable<int> MaxResults { get; set; }

        [Parameter(Position = 1,
        Mandatory = false)]
        public CalendarListResource.ListRequest.MinAccessRoleEnum? MinAccessRole { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<bool> ShowDeleted { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public System.Nullable<bool> ShowHidden { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public string SyncToken { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar CalendarList", "List-GCalendarCalendarList"))
            {

                var properties = new gCalendar.CalendarList.CalendarListListProperties()
                {
                    minAccessRole = this.MinAccessRole,
                    showDeleted = this.ShowDeleted,
                    showHidden = this.ShowHidden,
                    syncToken = this.SyncToken
                };


                 WriteObject(calendarList.List(properties));
            }

        }
    }
    [Cmdlet("Patch", "GCalendarCalendarList",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendarList/patch")]
    public class PatchGCalendarCalendarListCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<bool> ColorRgbFormat { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.CalendarListEntry CalendarListEntryBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar CalendarList", "Patch-GCalendarCalendarList"))
            {

                var properties = new gCalendar.CalendarList.CalendarListPatchProperties()
                {
                    colorRgbFormat = this.ColorRgbFormat
                };


                 WriteObject(calendarList.Patch(CalendarListEntryBody, CalendarId, properties));
            }

        }
    }
    [Cmdlet("Update", "GCalendarCalendarList",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendarList/update")]
    public class UpdateGCalendarCalendarListCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<bool> ColorRgbFormat { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.CalendarListEntry CalendarListEntryBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar CalendarList", "Update-GCalendarCalendarList"))
            {

                var properties = new gCalendar.CalendarList.CalendarListUpdateProperties()
                {
                    colorRgbFormat = this.ColorRgbFormat
                };


                 WriteObject(calendarList.Update(CalendarListEntryBody, CalendarId, properties));
            }

        }
    }
    [Cmdlet("Watch", "GCalendarCalendarList",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendarList/watch")]
    public class WatchGCalendarCalendarListCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 1,
        Mandatory = false)]
        public System.Nullable<int> MaxResults { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public CalendarListResource.WatchRequest.MinAccessRoleEnum? MinAccessRole { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public System.Nullable<bool> ShowDeleted { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public System.Nullable<bool> ShowHidden { get; set; }

        [Parameter(Position = 5,
        Mandatory = false)]
        public string SyncToken { get; set; }

        [Parameter(Position = 0,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Channel ChannelBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar CalendarList", "Watch-GCalendarCalendarList"))
            {

                var properties = new gCalendar.CalendarList.CalendarListWatchProperties()
                {
                    minAccessRole = this.MinAccessRole,
                    showDeleted = this.ShowDeleted,
                    showHidden = this.ShowHidden,
                    syncToken = this.SyncToken
                };


                 WriteObject(calendarList.Watch(ChannelBody, properties));
            }

        }
    }

}

namespace gShell.Cmdlets.Calendar.Calendars
{


    [Cmdlet("Clear", "GCalendarCalendars",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendars/clear")]
    public class ClearGCalendarCalendarsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Calendars", "Clear-GCalendarCalendars"))
            {

                calendars.Clear(CalendarId);
            }

        }
    }
    [Cmdlet("Delete", "GCalendarCalendars",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendars/delete")]
    public class DeleteGCalendarCalendarsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Calendars", "Delete-GCalendarCalendars"))
            {

                calendars.Delete(CalendarId);
            }

        }
    }
    [Cmdlet("Get", "GCalendarCalendars",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendars/get")]
    public class GetGCalendarCalendarsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Calendars", "Get-GCalendarCalendars"))
            {

                 WriteObject(calendars.Get(CalendarId));
            }

        }
    }
    [Cmdlet("Insert", "GCalendarCalendars",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendars/insert")]
    public class InsertGCalendarCalendarsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 1,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Calendar CalendarBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Calendars", "Insert-GCalendarCalendars"))
            {

                 WriteObject(calendars.Insert(CalendarBody));
            }

        }
    }
    [Cmdlet("Patch", "GCalendarCalendars",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendars/patch")]
    public class PatchGCalendarCalendarsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Calendar CalendarBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Calendars", "Patch-GCalendarCalendars"))
            {

                 WriteObject(calendars.Patch(CalendarBody, CalendarId));
            }

        }
    }
    [Cmdlet("Update", "GCalendarCalendars",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/calendars/update")]
    public class UpdateGCalendarCalendarsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Calendar CalendarBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Calendars", "Update-GCalendarCalendars"))
            {

                 WriteObject(calendars.Update(CalendarBody, CalendarId));
            }

        }
    }

}

namespace gShell.Cmdlets.Calendar.Channels
{


    [Cmdlet("Stop", "GCalendarChannels",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/channels/stop")]
    public class StopGCalendarChannelsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Channel ChannelBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Channels", "Stop-GCalendarChannels"))
            {

                channels.Stop(ChannelBody);
            }

        }
    }

}

namespace gShell.Cmdlets.Calendar.Colors
{


    [Cmdlet("Get", "GCalendarColors",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/colors/get")]
    public class GetGCalendarColorsCommand : CalendarServiceAccountBase
    {
        #region Properties

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Colors", "Get-GCalendarColors"))
            {

                 WriteObject(colors.Get());
            }

        }
    }

}

namespace gShell.Cmdlets.Calendar.Events
{


    [Cmdlet("Delete", "GCalendarEvents",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/events/delete")]
    public class DeleteGCalendarEventsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public string EventId { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<bool> SendNotifications { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Events", "Delete-GCalendarEvents"))
            {

                var properties = new gCalendar.Events.EventsDeleteProperties()
                {
                    sendNotifications = this.SendNotifications
                };


                events.Delete(CalendarId, EventId, properties);
            }

        }
    }
    [Cmdlet("Get", "GCalendarEvents",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/events/get")]
    public class GetGCalendarEventsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public string EventId { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<bool> AlwaysIncludeEmail { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public System.Nullable<int> MaxAttendees { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public string TimeZone { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Events", "Get-GCalendarEvents"))
            {

                var properties = new gCalendar.Events.EventsGetProperties()
                {
                    alwaysIncludeEmail = this.AlwaysIncludeEmail,
                    maxAttendees = this.MaxAttendees,
                    timeZone = this.TimeZone
                };


                 WriteObject(events.Get(CalendarId, EventId, properties));
            }

        }
    }
    [Cmdlet("Import", "GCalendarEvents",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/events/import")]
    public class ImportGCalendarEventsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<bool> SupportsAttachments { get; set; }

        [Parameter(Position = 2,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Event EventBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Events", "Import-GCalendarEvents"))
            {

                var properties = new gCalendar.Events.EventsImportProperties()
                {
                    supportsAttachments = this.SupportsAttachments
                };


                 WriteObject(events.Import(EventBody, CalendarId, properties));
            }

        }
    }
    [Cmdlet("Insert", "GCalendarEvents",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/events/insert")]
    public class InsertGCalendarEventsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<int> MaxAttendees { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public System.Nullable<bool> SendNotifications { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public System.Nullable<bool> SupportsAttachments { get; set; }

        [Parameter(Position = 2,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Event EventBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Events", "Insert-GCalendarEvents"))
            {

                var properties = new gCalendar.Events.EventsInsertProperties()
                {
                    maxAttendees = this.MaxAttendees,
                    sendNotifications = this.SendNotifications,
                    supportsAttachments = this.SupportsAttachments
                };


                 WriteObject(events.Insert(EventBody, CalendarId, properties));
            }

        }
    }
    [Cmdlet("Instances", "GCalendarEvents",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/events/instances")]
    public class InstancesGCalendarEventsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public string EventId { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<bool> AlwaysIncludeEmail { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public System.Nullable<int> MaxAttendees { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public System.Nullable<int> MaxResults { get; set; }

        [Parameter(Position = 5,
        Mandatory = false)]
        public string OriginalStart { get; set; }

        [Parameter(Position = 6,
        Mandatory = false)]
        public System.Nullable<bool> ShowDeleted { get; set; }

        [Parameter(Position = 7,
        Mandatory = false)]
        public System.Nullable<System.DateTime> TimeMax { get; set; }

        [Parameter(Position = 8,
        Mandatory = false)]
        public System.Nullable<System.DateTime> TimeMin { get; set; }

        [Parameter(Position = 9,
        Mandatory = false)]
        public string TimeZone { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Events", "Instances-GCalendarEvents"))
            {

                var properties = new gCalendar.Events.EventsInstancesProperties()
                {
                    alwaysIncludeEmail = this.AlwaysIncludeEmail,
                    maxAttendees = this.MaxAttendees,
                    originalStart = this.OriginalStart,
                    showDeleted = this.ShowDeleted,
                    timeMax = this.TimeMax,
                    timeMin = this.TimeMin,
                    timeZone = this.TimeZone
                };


                 WriteObject(events.Instances(CalendarId, EventId, properties));
            }

        }
    }
    [Cmdlet("List", "GCalendarEvents",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/events/list")]
    public class ListGCalendarEventsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = false)]
        public System.Nullable<bool> AlwaysIncludeEmail { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public string ICalUID { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public System.Nullable<int> MaxAttendees { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public System.Nullable<int> MaxResults { get; set; }

        [Parameter(Position = 5,
        Mandatory = false)]
        public EventsResource.ListRequest.OrderByEnum? OrderBy { get; set; }

        [Parameter(Position = 6,
        Mandatory = false)]
        public string[] PrivateExtendedProperty { get; set; }

        [Parameter(Position = 7,
        Mandatory = false)]
        public string Q { get; set; }

        [Parameter(Position = 8,
        Mandatory = false)]
        public string[] SharedExtendedProperty { get; set; }

        [Parameter(Position = 9,
        Mandatory = false)]
        public System.Nullable<bool> ShowDeleted { get; set; }

        [Parameter(Position = 10,
        Mandatory = false)]
        public System.Nullable<bool> ShowHiddenInvitations { get; set; }

        [Parameter(Position = 11,
        Mandatory = false)]
        public System.Nullable<bool> SingleEvents { get; set; }

        [Parameter(Position = 12,
        Mandatory = false)]
        public string SyncToken { get; set; }

        [Parameter(Position = 13,
        Mandatory = false)]
        public System.Nullable<System.DateTime> TimeMax { get; set; }

        [Parameter(Position = 14,
        Mandatory = false)]
        public System.Nullable<System.DateTime> TimeMin { get; set; }

        [Parameter(Position = 15,
        Mandatory = false)]
        public string TimeZone { get; set; }

        [Parameter(Position = 16,
        Mandatory = false)]
        public System.Nullable<System.DateTime> UpdatedMin { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Events", "List-GCalendarEvents"))
            {

                var properties = new gCalendar.Events.EventsListProperties()
                {
                    alwaysIncludeEmail = this.AlwaysIncludeEmail,
                    iCalUID = this.ICalUID,
                    maxAttendees = this.MaxAttendees,
                    orderBy = this.OrderBy,
                    privateExtendedProperty = this.PrivateExtendedProperty,
                    q = this.Q,
                    sharedExtendedProperty = this.SharedExtendedProperty,
                    showDeleted = this.ShowDeleted,
                    showHiddenInvitations = this.ShowHiddenInvitations,
                    singleEvents = this.SingleEvents,
                    syncToken = this.SyncToken,
                    timeMax = this.TimeMax,
                    timeMin = this.TimeMin,
                    timeZone = this.TimeZone,
                    updatedMin = this.UpdatedMin
                };


                 WriteObject(events.List(CalendarId, properties));
            }

        }
    }
    [Cmdlet("Move", "GCalendarEvents",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/events/move")]
    public class MoveGCalendarEventsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public string EventId { get; set; }

        [Parameter(Position = 2,
        Mandatory = true)]
        public string Destination { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public System.Nullable<bool> SendNotifications { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Events", "Move-GCalendarEvents"))
            {

                var properties = new gCalendar.Events.EventsMoveProperties()
                {
                    sendNotifications = this.SendNotifications
                };


                 WriteObject(events.Move(CalendarId, EventId, Destination, properties));
            }

        }
    }
    [Cmdlet("Patch", "GCalendarEvents",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/events/patch")]
    public class PatchGCalendarEventsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public string EventId { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public System.Nullable<bool> AlwaysIncludeEmail { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public System.Nullable<int> MaxAttendees { get; set; }

        [Parameter(Position = 5,
        Mandatory = false)]
        public System.Nullable<bool> SendNotifications { get; set; }

        [Parameter(Position = 6,
        Mandatory = false)]
        public System.Nullable<bool> SupportsAttachments { get; set; }

        [Parameter(Position = 2,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Event EventBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Events", "Patch-GCalendarEvents"))
            {

                var properties = new gCalendar.Events.EventsPatchProperties()
                {
                    alwaysIncludeEmail = this.AlwaysIncludeEmail,
                    maxAttendees = this.MaxAttendees,
                    sendNotifications = this.SendNotifications,
                    supportsAttachments = this.SupportsAttachments
                };


                 WriteObject(events.Patch(EventBody, CalendarId, EventId, properties));
            }

        }
    }
    [Cmdlet("QuickAdd", "GCalendarEvents",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/events/quickAdd")]
    public class QuickAddGCalendarEventsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public string Text { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<bool> SendNotifications { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Events", "QuickAdd-GCalendarEvents"))
            {

                var properties = new gCalendar.Events.EventsQuickAddProperties()
                {
                    sendNotifications = this.SendNotifications
                };


                 WriteObject(events.QuickAdd(CalendarId, Text, properties));
            }

        }
    }
    [Cmdlet("Update", "GCalendarEvents",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/events/update")]
    public class UpdateGCalendarEventsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 1,
        Mandatory = true)]
        public string EventId { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public System.Nullable<bool> AlwaysIncludeEmail { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public System.Nullable<int> MaxAttendees { get; set; }

        [Parameter(Position = 5,
        Mandatory = false)]
        public System.Nullable<bool> SendNotifications { get; set; }

        [Parameter(Position = 6,
        Mandatory = false)]
        public System.Nullable<bool> SupportsAttachments { get; set; }

        [Parameter(Position = 2,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Event EventBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Events", "Update-GCalendarEvents"))
            {

                var properties = new gCalendar.Events.EventsUpdateProperties()
                {
                    alwaysIncludeEmail = this.AlwaysIncludeEmail,
                    maxAttendees = this.MaxAttendees,
                    sendNotifications = this.SendNotifications,
                    supportsAttachments = this.SupportsAttachments
                };


                 WriteObject(events.Update(EventBody, CalendarId, EventId, properties));
            }

        }
    }
    [Cmdlet("Watch", "GCalendarEvents",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/events/watch")]
    public class WatchGCalendarEventsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string CalendarId { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public System.Nullable<bool> AlwaysIncludeEmail { get; set; }

        [Parameter(Position = 3,
        Mandatory = false)]
        public string ICalUID { get; set; }

        [Parameter(Position = 4,
        Mandatory = false)]
        public System.Nullable<int> MaxAttendees { get; set; }

        [Parameter(Position = 5,
        Mandatory = false)]
        public System.Nullable<int> MaxResults { get; set; }

        [Parameter(Position = 6,
        Mandatory = false)]
        public EventsResource.WatchRequest.OrderByEnum? OrderBy { get; set; }

        [Parameter(Position = 7,
        Mandatory = false)]
        public string[] PrivateExtendedProperty { get; set; }

        [Parameter(Position = 8,
        Mandatory = false)]
        public string Q { get; set; }

        [Parameter(Position = 9,
        Mandatory = false)]
        public string[] SharedExtendedProperty { get; set; }

        [Parameter(Position = 10,
        Mandatory = false)]
        public System.Nullable<bool> ShowDeleted { get; set; }

        [Parameter(Position = 11,
        Mandatory = false)]
        public System.Nullable<bool> ShowHiddenInvitations { get; set; }

        [Parameter(Position = 12,
        Mandatory = false)]
        public System.Nullable<bool> SingleEvents { get; set; }

        [Parameter(Position = 13,
        Mandatory = false)]
        public string SyncToken { get; set; }

        [Parameter(Position = 14,
        Mandatory = false)]
        public System.Nullable<System.DateTime> TimeMax { get; set; }

        [Parameter(Position = 15,
        Mandatory = false)]
        public System.Nullable<System.DateTime> TimeMin { get; set; }

        [Parameter(Position = 16,
        Mandatory = false)]
        public string TimeZone { get; set; }

        [Parameter(Position = 17,
        Mandatory = false)]
        public System.Nullable<System.DateTime> UpdatedMin { get; set; }

        [Parameter(Position = 0,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Channel ChannelBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Events", "Watch-GCalendarEvents"))
            {

                var properties = new gCalendar.Events.EventsWatchProperties()
                {
                    alwaysIncludeEmail = this.AlwaysIncludeEmail,
                    iCalUID = this.ICalUID,
                    maxAttendees = this.MaxAttendees,
                    orderBy = this.OrderBy,
                    privateExtendedProperty = this.PrivateExtendedProperty,
                    q = this.Q,
                    sharedExtendedProperty = this.SharedExtendedProperty,
                    showDeleted = this.ShowDeleted,
                    showHiddenInvitations = this.ShowHiddenInvitations,
                    singleEvents = this.SingleEvents,
                    syncToken = this.SyncToken,
                    timeMax = this.TimeMax,
                    timeMin = this.TimeMin,
                    timeZone = this.TimeZone,
                    updatedMin = this.UpdatedMin
                };


                 WriteObject(events.Watch(ChannelBody, CalendarId, properties));
            }

        }
    }

}

namespace gShell.Cmdlets.Calendar.Freebusy
{


    [Cmdlet("Query", "GCalendarFreebusy",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/freebusy/query")]
    public class QueryGCalendarFreebusyCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.FreeBusyRequest FreeBusyRequestBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Freebusy", "Query-GCalendarFreebusy"))
            {

                 WriteObject(freebusy.Query(FreeBusyRequestBody));
            }

        }
    }

}

namespace gShell.Cmdlets.Calendar.Settings
{


    [Cmdlet("Get", "GCalendarSettings",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/settings/get")]
    public class GetGCalendarSettingsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = true)]
        public string Setting { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Settings", "Get-GCalendarSettings"))
            {

                 WriteObject(settings.Get(Setting));
            }

        }
    }
    [Cmdlet("List", "GCalendarSettings",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/settings/list")]
    public class ListGCalendarSettingsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 0,
        Mandatory = false)]
        public System.Nullable<int> MaxResults { get; set; }

        [Parameter(Position = 1,
        Mandatory = false)]
        public string SyncToken { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Settings", "List-GCalendarSettings"))
            {

                var properties = new gCalendar.Settings.SettingsListProperties()
                {
                    syncToken = this.SyncToken
                };


                 WriteObject(settings.List(properties));
            }

        }
    }
    [Cmdlet("Watch", "GCalendarSettings",
    SupportsShouldProcess = true,
      HelpUri = @"https://developers.google.com/google-apps/calendar/firstappv3/reference/settings/watch")]
    public class WatchGCalendarSettingsCommand : CalendarServiceAccountBase
    {
        #region Properties


        [Parameter(Position = 1,
        Mandatory = false)]
        public System.Nullable<int> MaxResults { get; set; }

        [Parameter(Position = 2,
        Mandatory = false)]
        public string SyncToken { get; set; }

        [Parameter(Position = 0,
        Mandatory = true)]
        public Google.Apis.Calendar.v3.Data.Channel ChannelBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Calendar Settings", "Watch-GCalendarSettings"))
            {

                var properties = new gCalendar.Settings.SettingsWatchProperties()
                {
                    syncToken = this.SyncToken
                };


                 WriteObject(settings.Watch(ChannelBody, properties));
            }

        }
    }

}
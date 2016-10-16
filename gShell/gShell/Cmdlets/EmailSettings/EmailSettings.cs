using System;
using System.Management.Automation;

using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;


namespace gShell.Cmdlets.Emailsettings
{
    public enum ForwardingActionEnum
    { KEEP, ARCHIVE, DELETE, MARK_READ }

    public enum PopEnableForEnum
    { ALL_MAIL, MAIL_FROM_NOW_ON }

    public enum PopActionEnum
    { KEEP, ARCHIVE, DELETE }

    public enum LanguageLanguageEnum
    {
        Arabic, Bengali, Bulgarian, Catalan, Chinese_Simplified, Chinese_Traditional, Croatian, Czech, Danish, Dutch,
        English_United_States, English_United_Kingdom, Estonian, Finnish, French, German, Greek, Gujarati, Hebrew,
        Hindi, Hungarian, Icelandic, Indonesian, Italian, Japanese, Kannada, Korean, Latvian, Lithuanian, Malay,
        Malayalam, Marathi, Norwegian, Oriya, Persian, Polish, Portuguese_Brazil, Portuguese_Portugal, Romanian,
        Russian, Serbian, Slovak, Slovenian, Spanish, Swedish, Tagalog, Tamil, Telugu, Thai, Turkish, Ukrainian, Urdu,
        Vietnamese
    }

    public enum LanguageLanguageAbbrevEnum
    {
        ar, bn, bg, ca, zh_CN, zh_TW, hr, cs, da, nl, en_US, en_GB, et, fi, fr, de, el, gu, iw, i, hu, @is, @in, it,
        ja, kn, ko, lv, lt, ms, l, mr, no, or, fa, pl, pt_BR, pt_PT, ro, ru, sr, sk, sl, es, sv, tl, ta, te, th, tr,
        uk, ur, vi
    }

    public enum GeneralPageSizeEnum
    { _25 = 25, _50 = 50, _100 = 100 }
}

namespace gShell.Cmdlets.Emailsettings.Delegation
{
    /// <summary>
    /// <para type="synopsis">Retrieve all Gmail delegates for a specific delegator.</para>
    /// <para type="description">Retrieve all Gmail delegates for a specific delegator.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsDelegation -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GEmailSettingsDelegation">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsDelegation",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GEmailSettingsDelegation")]
    public class GetGEmailSettingsDelegationCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The name used in the primary email address. or a user alias of the user granting access.</para>
        /// </summary>
        [Parameter(HelpMessage = "The name used in the primary email address. or a user alias of the user granting access.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Delegation", "Get-GEmailSettingsDelegation"))
            {
                WriteObject(delegation.Get(GAuthId, GetUserFromEmail(UserName)).DelegatesValue);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Create a new Gmail delegate for a specific delegator.</para>
    /// <para type="description">Create a new Gmail delegate for a specific delegator.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GEmailSettingsDelegation -UserName $SomeUserNameString -Address $SomeAddressString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GEmailSettingsDelegation">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GEmailSettingsDelegation",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GEmailSettingsDelegation")]
    public class NewGEmailSettingsDelegationCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The name used in the primary email address. or a user alias of the user granting access.</para>
        /// </summary>
        [Parameter(HelpMessage = "The name used in the primary email address. or a user alias of the user granting access.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">The name of the user given access to a Gmail account.</para>
        /// </summary>
        [Parameter(HelpMessage = "The name of the user given access to a Gmail account.",
            Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Delegate()
            {
                Address = Address
            };

            if (ShouldProcess("Email Settings Delegation", "New-GEmailSettingsDelegation"))
            {
                WriteObject(delegation.Insert(body, GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Remove a Gmail delegate.</para>
    /// <para type="description">Remove a Gmail delegate.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GEmailSettingsDelegation -UserName $SomeUserNameString -DelegateEmail $SomeDelegateEmailString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GEmailSettingsDelegation">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GEmailSettingsDelegation",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GEmailSettingsDelegation")]
    public class RemoveGEmailSettingsDelegationCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The name used in the primary email address. or a user alias of the user granting access.</para>
        /// </summary>
        [Parameter(HelpMessage = "The name used in the primary email address. or a user alias of the user granting access.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">The name of the user given access to a Gmail account.</para>
        /// </summary>
        [Parameter(HelpMessage = "The name of the user given access to a Gmail account.",
            Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DelegateEmail { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Email Settings Delegation";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        delegation.Delete(GAuthId, GetUserFromEmail(UserName), DelegateEmail);
							
						WriteVerbose("Removal of " + toRemoveTarget + " completed without error.");
					}
					catch (Exception e)
					{
						WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, toRemoveTarget));
					}
				}
				else
				{
					WriteError(new ErrorRecord(new Exception("Deletion not confirmed"),
						"", ErrorCategory.InvalidData, toRemoveTarget));
				}
			}
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Filters
{
    /// <summary>
    /// <para type="synopsis">Create a Google Mail filter.</para>
    /// <para type="description">Create a Google Mail filter.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GEmailSettingsFilter -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GEmailSettingsFilter">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GEmailSettingsFilter",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GEmailSettingsFilter")]
    public class NewGEmailSettingsFilterCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">The email must come from this address in order to be filtered.</para>
        /// </summary>
        [Parameter(HelpMessage = "The email must come from this address in order to be filtered.",
            Position = 2)]
        [ValidateNotNullOrEmpty]
        public string From { get; set; }

        /// <summary>
        /// <para type="description">The email must be sent to this address in order to be filtered.</para>
        /// </summary>
        [Parameter(HelpMessage = "The email must be sent to this address in order to be filtered.",
            Position = 3)]
        [ValidateNotNullOrEmpty]
        public string To { get; set; }

        /// <summary>
        /// <para type="description">A string the email must have in its subject line to be filtered.</para>
        /// </summary>
        [Parameter(HelpMessage = "A string the email must have in its subject line to be filtered.",
            Position = 4)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; }

        /// <summary>
        /// <para type="description">	A string the email can have anywhere in it's subject or body.</para>
        /// </summary>
        [Parameter(HelpMessage = "	A string the email can have anywhere in it's subject or body.",
            Position = 5)]
        [ValidateNotNullOrEmpty]
        public string HasTheWords { get; set; }

        /// <summary>
        /// <para type="description">A string that the email cannot have anywhere in its subject or body.</para>
        /// </summary>
        [Parameter(HelpMessage = "A string that the email cannot have anywhere in its subject or body.",
            Position = 6)]
        [ValidateNotNullOrEmpty]
        public string DoesntHave { get; set; }

        /// <summary>
        /// <para type="description">A boolean representing whether or not the email contains an attachment.</para>
        /// </summary>
        [Parameter(HelpMessage = "A boolean representing whether or not the email contains an attachment.",
            Position = 7)]
        [ValidateNotNullOrEmpty]
        public bool? HasAttachment { get; set; }

        /// <summary>
        /// <para type="description">Whether to automatically move the message to "Archived" state if it matches the specified filter criteria</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to automatically move the message to \"Archived\" state if it matches the specified filter criteria",
            Position = 8)]
        [ValidateNotNullOrEmpty]
        public bool? ArchiveIt { get; set; }

        /// <summary>
        /// <para type="description">Whether to automatically mark the message as read if it matches the specified filter criteria</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to automatically mark the message as read if it matches the specified filter criteria",
            Position = 9)]
        [ValidateNotNullOrEmpty]
        public bool? MarkAsRead { get; set; }

        /// <summary>
        /// <para type="description">Whether to automatically star the message if it matches the specified filter criteria</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to automatically star the message if it matches the specified filter criteria",
            Position = 10)]
        [ValidateNotNullOrEmpty]
        public bool? StarIt { get; set; }

        /// <summary>
        /// <para type="description">The name of the label to apply if a message matches the specified fitler criteria.</para>
        /// </summary>
        [Parameter(HelpMessage = "The name of the label to apply if a message matches the specified fitler criteria.",
            Position = 11)]
        [ValidateNotNullOrEmpty]
        public string ApplyTheLabel { get; set; }

        /// <summary>
        /// <para type="description">Whether to automatically forward the message to the given verified email address if it matches the filter criteria. The forwarding email address must be validated or an error is returned.</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to automatically forward the message to the given verified email address if it matches the filter criteria. The forwarding email address must be validated or an error is returned.",
            Position = 12)]
        [ValidateNotNullOrEmpty]
        public string ForwardIt { get; set; }

        /// <summary>
        /// <para type="description">Whether to automatically move the message to "Trash" state if it matches the specified filter criteria</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to automatically move the message to \"Trash\" state if it matches the specified filter criteria",
            Position = 13)]
        [ValidateNotNullOrEmpty]
        public bool? DeleteIt { get; set; }

        /// <summary>
        /// <para type="description">Whether to automatically move the message to "Spam" state if it matches the specified filter criteria</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to automatically move the message to \"Spam\" state if it matches the specified filter criteria",
            Position = 14)]
        [ValidateNotNullOrEmpty]
        public bool? NeverSendItToSpam { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (string.IsNullOrWhiteSpace(From)
                && string.IsNullOrWhiteSpace(To)
                && string.IsNullOrWhiteSpace(Subject)
                && string.IsNullOrWhiteSpace(HasTheWords)
                && string.IsNullOrWhiteSpace(DoesntHave)
                && !HasAttachment.HasValue)
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Must use at least one of: From, To, Subject, HasTheWords, DoesntHave or HasAttachment"))));
            }

            if (!ArchiveIt.HasValue
                && !MarkAsRead.HasValue
                && !StarIt.HasValue
                && string.IsNullOrWhiteSpace(ApplyTheLabel)
                && string.IsNullOrWhiteSpace(ForwardIt)
                && !DeleteIt.HasValue
                && !NeverSendItToSpam.HasValue)
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Must use at least one of: MarkAsRead, StarIt, ApplyTheLabel, ForwardIt, DeleteIt, or NeverSendItToSpam"))));
            }

            var body = new Data.Filter();

            if (!string.IsNullOrWhiteSpace(From)) { body.From = From; }
            if (!string.IsNullOrWhiteSpace(To)) { body.To = To; }
            if (!string.IsNullOrWhiteSpace(Subject)) { body.Subject = Subject; }
            if (!string.IsNullOrWhiteSpace(HasTheWords)) { body.HasTheWord = HasTheWords; }
            if (!string.IsNullOrWhiteSpace(DoesntHave)) { body.DoesNotHaveTheWord = DoesntHave; }
            if (HasAttachment.HasValue) { body.HasAttachment = HasAttachment.Value; }

            if (ArchiveIt.HasValue) { body.ShouldArchive = ArchiveIt.Value; }
            if (MarkAsRead.HasValue) { body.ShouldMarkAsRead = MarkAsRead.Value; }
            if (StarIt.HasValue) { body.ShouldStar = StarIt.Value; }
            if (!string.IsNullOrWhiteSpace(ApplyTheLabel)) { body.Label = ApplyTheLabel; }
            if (!string.IsNullOrWhiteSpace(ForwardIt)) { body.ForwardTo = ForwardIt; }
            if (DeleteIt.HasValue) { body.ShouldTrash = DeleteIt.Value; }
            if (NeverSendItToSpam.HasValue) { body.NeverSpam = NeverSendItToSpam.Value; }


            if (ShouldProcess("Email Settings Filter", "New-GEmailSettingsFilter"))
            {
                WriteObject(filters.Insert(body, GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Forwarding
{
    /// <summary>
    /// <para type="synopsis"></para>
    /// <para type="description"></para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsForwarding -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GEmailSettingsForwarding">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsForwarding",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GEmailSettingsForwarding")]
    public class NewGEmailSettingsForwardingCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Forwarding", "Get-GEmailSettingsForwarding"))
            {
                WriteObject(forwarding.Get(GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis"></para>
    /// <para type="description"></para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GEmailSettingsForwarding -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GEmailSettingsForwarding">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsForwarding",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GEmailSettingsForwarding")]
    public class SetGEmailSettingsForwardingCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">Whether to enable forwarding of incoming mail.</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to enable forwarding of incoming mail.",
            Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool Enable { get; set; }

        /// <summary>
        /// <para type="description">The email will be forwarded to this address.</para>
        /// </summary>
        [Parameter(HelpMessage = "The email will be forwarded to this address.",
            Position = 3,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ForwardTo { get; set; }

        /// <summary>
        /// <para type="description">What Google Mail should do with its copy of the email after forwarding it on. "KEEP" (in inbox), "ARCHIVE", or "DELETE" (send to spam), or "MARK_READ" (marked as read),</para>
        /// </summary>
        [Parameter(HelpMessage = "What Google Mail should do with its copy of the email after forwarding it on. \"KEEP\" (in inbox), \"ARCHIVE\", or \"DELETE\" (send to spam), or \"MARK_READ\" (marked as read).",
            Position = 4,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ForwardingActionEnum Action { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Forwarding()
            {
                Enable = Enable,
                ForwardTo = ForwardTo,
                Action = Action.ToString()
            };

            if (ShouldProcess("Email Settings Forwarding", "Set-GEmailSettingsForwarding"))
            {
                WriteObject(forwarding.Update(body, GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.General
{
    /// <summary>
    /// <para type="synopsis">Update various Google Mail General settings.</para>
    /// <para type="description">Update various Google Mail General settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GEmailSettingsGeneral -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GEmailSettingsGeneral">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsGeneral",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GEmailSettingsGeneral")]
    public class SetGEmailSettingsGeneralCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">The number of conversations to be shown per page. - 25, 50, 100</para>
        /// </summary>
        [Parameter(HelpMessage = "The number of conversations to be shown per page. - 25, 50, 100",
            Position = 2)]
        [ValidateNotNullOrEmpty]
        public GeneralPageSizeEnum? PageSize { get; set; }

        /// <summary>
        /// <para type="description">Whether to enable keyboard shortcuts</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to enable keyboard shortcuts",
            Position = 3)]
        [ValidateNotNullOrEmpty]
        public bool? Shortcuts { get; set; }

        /// <summary>
        /// <para type="description">Whether to display arrow-shaped personal indicators next to emails that were sent specifically to the user. ( › and » )</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to display arrow-shaped personal indicators next to emails that were sent specifically to the user. ( › and » )",
            Position = 4)]
        [ValidateNotNullOrEmpty]
        public bool? Arrows { get; set; }

        /// <summary>
        /// <para type="description">Whether to display snippets of messages in the inbox and when searching.</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to display snippets of messages in the inbox and when searching.",
            Position = 5)]
        [ValidateNotNullOrEmpty]
        public bool? Snippets { get; set; }

        /// <summary>
        /// <para type="description">Whether to use UTF-8 (unicode) encoding for all outgoing messages, instead of the default text encoding.</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to use UTF-8 (unicode) encoding for all outgoing messages, instead of the default text encoding.",
            Position = 6)]
        [ValidateNotNullOrEmpty]
        public bool? Unicode { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (!PageSize.HasValue
                && !Shortcuts.HasValue
                && !Arrows.HasValue
                && !Snippets.HasValue
                && !Unicode.HasValue)
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Must use at least one of: PageSize, Shortcuts, Arrows, Snippets, Unicode"))));
            }

            var body = new Data.General();

            if (PageSize != null) body.PageSize = (int)(PageSize.Value);
            if (Shortcuts != null) body.Shortcuts = Shortcuts.Value;
            if (Arrows != null) body.Arrows = Arrows.Value;
            if (Snippets != null) body.Snippets = Snippets.Value;
            if (Unicode != null) body.Unicode = Unicode.Value;

            if (ShouldProcess("Email Settings General", "Set-GEmailSettingsGeneral"))
            {
                WriteObject(general.Update(body, GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Imap
{
    /// <summary>
    /// <para type="synopsis">Retrieve Google Mail IMAP settings.</para>
    /// <para type="description">Retrieve Google Mail IMAP settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsImap -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GEmailSettingsImap">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsImap",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GEmailSettingsImap")]
    public class GetGEmailSettingsImapCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Imap", "Get-GEmailSettingsImap"))
            {
                WriteObject(imap.Get(GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update Google Mail IMAP settings.</para>
    /// <para type="description">Update Google Mail IMAP settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GEmailSettingsImap -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GEmailSettingsImap">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsImap",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GEmailSettingsImap")]
    public class SetGEmailSettingsImapCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">Whether to enable IMAP access.</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to enable IMAP access.",
            Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool Enable { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Imap()
            {
                Enable = Enable
            };

            if (ShouldProcess("Email Settings Imap", "Set-GEmailSettingsImap"))
            {
                WriteObject(imap.Update(body, GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Label
{
    /// <summary>
    /// <para type="synopsis">Retrieve all labels and their settings in Google Mail.</para>
    /// <para type="description">Reetrieve all labels and their settings in Google Mail.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsLabel -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GEmailSettingsLabel">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsLabel",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GEmailSettingsLabel")]
    public class GetEmailSettingsLabelCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Label", "Get-GEmailSettingsLabel"))
            {
                WriteObject(labels.Get(GAuthId, GetUserFromEmail(UserName)).LabelsValue);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Create labels in Google Mail.</para>
    /// <para type="description">Create labels in Google Mail.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GEmailSettingsLabel -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GEmailSettingsLabel">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GEmailSettingsLabel",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GEmailSettingsLabel")]
    public class NewEmailSettingsLabelCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">The label to create in Google Mail</para>
        /// </summary>
        [Parameter(HelpMessage = "The label to create in Google Mail",
            Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Label", "New-GEmailSettingsLabel"))
            {
                var newLabel = new Data.Label()
                {
                    LabelValue = Label
                };

                WriteObject(labels.Insert(newLabel, GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Delete a Gmail label.</para>
    /// <para type="description">Delete a Gmail label.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GEmailSettingsLabel -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GEmailSettingsLabel">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GEmailSettingsLabel",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GEmailSettingsLabel")]
    public class RemoveEmailSettingsLabelCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">The label to delete.</para>
        /// </summary>
        [Parameter(HelpMessage = "The label to delete.",
            Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string LabelName { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Email Settings Label";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        labels.Delete(GAuthId, GetUserFromEmail(UserName), LabelName);
							
						WriteVerbose("Removal of " + toRemoveTarget + " completed without error.");
					}
					catch (Exception e)
					{
						WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, toRemoveTarget));
					}
				}
				else
				{
					WriteError(new ErrorRecord(new Exception("Deletion not confirmed"),
						"", ErrorCategory.InvalidData, toRemoveTarget));
				}
			}
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Language
{
    /// <summary>
    /// <para type="synopsis">Update the display language setting in Google Mail.</para>
    /// <para type="description">Update the display language setting in Google Mail.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsLanguage -UserName $SomeUserNameString -Language $SomeLanguageEnum</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsLanguage -UserName $SomeUserNameString -LanguageAbbreviation $SomeLanguageAbbreviationEnum</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GEmailSettingsLanguage">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsLanguage",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GEmailSettingsLanguage")]
    public class SetGEmailSettingsLanguageCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true,
            ParameterSetName = "word")]
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true,
            ParameterSetName = "abbrev")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">Google Mail's display language</para>
        /// </summary>
        [Parameter(HelpMessage = "Google Mail's display language",
            Position = 2,
            Mandatory = true,
            ParameterSetName = "word")]
        [ValidateNotNullOrEmpty]
        public LanguageLanguageEnum Language { get; set; }

        /// <summary>
        /// <para type="description">Google Mail's display language, abbreviated</para>
        /// </summary>
        [Parameter(HelpMessage = "Google Mail's display language, abbreviated",
            Position = 2,
           Mandatory = true,
           ParameterSetName = "abbrev")]
        [ValidateNotNullOrEmpty]
        public LanguageLanguageAbbrevEnum LanguageAbbreviation { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Language();

            if (ParameterSetName == "word")
            {
                body.LanguageValue = LookupLanguage(this.Language);
            }
            else
            {
                body.LanguageValue = LookupLanguage(this.LanguageAbbreviation);
            }

            if (ShouldProcess("Email Settings Language", "Get-GEmailSettingsLanguage"))
            {
                WriteObject(language.Update(body, GAuthId, GetUserFromEmail(UserName)));
            }
        }

        public static string LookupLanguage(LanguageLanguageAbbrevEnum abbrev)
        {
            switch (abbrev)
            {
                case LanguageLanguageAbbrevEnum.zh_CN:
                    return "zh-CN";
                case LanguageLanguageAbbrevEnum.zh_TW:
                    return "zh-TW";
                case LanguageLanguageAbbrevEnum.en_US:
                    return "en-US";
                case LanguageLanguageAbbrevEnum.en_GB:
                    return "en-GB";
                case LanguageLanguageAbbrevEnum.pt_BR:
                    return "pt-BR";
                case LanguageLanguageAbbrevEnum.pt_PT:
                    return "pt-PT";
                default:
                    return abbrev.ToString();
            }
        }

        public static string LookupLanguage(LanguageLanguageEnum language)
        {
            switch (language)
            {
                case LanguageLanguageEnum.Arabic:
                    return "ar";
                case LanguageLanguageEnum.Bengali:
                    return "bn";
                case LanguageLanguageEnum.Bulgarian:
                    return "bg";
                case LanguageLanguageEnum.Catalan:
                    return "ca";
                case LanguageLanguageEnum.Chinese_Simplified:
                    return "zh-CN";
                case LanguageLanguageEnum.Chinese_Traditional:
                    return "zh-TW";
                case LanguageLanguageEnum.Croatian:
                    return "hr";
                case LanguageLanguageEnum.Czech:
                    return "cs";
                case LanguageLanguageEnum.Danish:
                    return "da";
                case LanguageLanguageEnum.Dutch:
                    return "nl";
                case LanguageLanguageEnum.English_United_States:
                    return "en-US";
                case LanguageLanguageEnum.English_United_Kingdom:
                    return "en-GB";
                case LanguageLanguageEnum.Estonian:
                    return "et";
                case LanguageLanguageEnum.Finnish:
                    return "fi";
                case LanguageLanguageEnum.French:
                    return "fr";
                case LanguageLanguageEnum.German:
                    return "de";
                case LanguageLanguageEnum.Greek:
                    return "el";
                case LanguageLanguageEnum.Gujarati:
                    return "gu";
                case LanguageLanguageEnum.Hebrew:
                    return "iw";
                case LanguageLanguageEnum.Hindi:
                    return "i";
                case LanguageLanguageEnum.Hungarian:
                    return "hu";
                case LanguageLanguageEnum.Icelandic:
                    return "is";
                case LanguageLanguageEnum.Indonesian:
                    return "in";
                case LanguageLanguageEnum.Italian:
                    return "it";
                case LanguageLanguageEnum.Japanese:
                    return "ja";
                case LanguageLanguageEnum.Kannada:
                    return "kn";
                case LanguageLanguageEnum.Korean:
                    return "ko";
                case LanguageLanguageEnum.Latvian:
                    return "lv";
                case LanguageLanguageEnum.Lithuanian:
                    return "lt";
                case LanguageLanguageEnum.Malay:
                    return "ms";
                case LanguageLanguageEnum.Malayalam:
                    return "l";
                case LanguageLanguageEnum.Marathi:
                    return "mr";
                case LanguageLanguageEnum.Norwegian:
                    return "no";
                case LanguageLanguageEnum.Oriya:
                    return "or";
                case LanguageLanguageEnum.Persian:
                    return "fa";
                case LanguageLanguageEnum.Polish:
                    return "pl";
                case LanguageLanguageEnum.Portuguese_Brazil:
                    return "pt-BR";
                case LanguageLanguageEnum.Portuguese_Portugal:
                    return "pt-PT";
                case LanguageLanguageEnum.Romanian:
                    return "ro";
                case LanguageLanguageEnum.Russian:
                    return "ru";
                case LanguageLanguageEnum.Serbian:
                    return "sr";
                case LanguageLanguageEnum.Slovak:
                    return "sk";
                case LanguageLanguageEnum.Slovenian:
                    return "sl";
                case LanguageLanguageEnum.Spanish:
                    return "es";
                case LanguageLanguageEnum.Swedish:
                    return "sv";
                case LanguageLanguageEnum.Tagalog:
                    return "tl";
                case LanguageLanguageEnum.Tamil:
                    return "ta";
                case LanguageLanguageEnum.Telugu:
                    return "te";
                case LanguageLanguageEnum.Thai:
                    return "th";
                case LanguageLanguageEnum.Turkish:
                    return "tr";
                case LanguageLanguageEnum.Ukrainian:
                    return "uk";
                case LanguageLanguageEnum.Urdu:
                    return "ur";
                case LanguageLanguageEnum.Vietnamese:
                    return "vi";
                default:
                    return "en-US";
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Pop
{
    /// <summary>
    /// <para type="synopsis">Retrieve Google Mail POP settings.</para>
    /// <para type="description">Retrieve Google Mail POP settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsPop -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GEmailSettingsPop">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsPop",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GEmailSettingsPop")]
    public class GetGEmailSettingsPopCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Pop", "Get-GEmailSettingsPop"))
            {
                WriteObject(pop.Get(GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update Google Mail POP settings.</para>
    /// <para type="description">Update Google Mail POP settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsPop -UserName $SomeUserNameString -Enable $SomeEnableBool</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GEmailSettingsPop">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsPop",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GEmailSettingsPop")]
    public class SetGEmailSettingsPopCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">Whether to enable POP access.</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to enable POP access.",
            Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool Enable { get; set; }

        /// <summary>
        /// <para type="description">Whether to enable POP for all mail, or mail from now on.</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to enable POP for all mail, or mail from now on.",
            Position = 3)]
        [ValidateNotNullOrEmpty]
        public PopEnableForEnum? EnableFor { get; set; }

        /// <summary>
        /// <para type="description">What Google Mail should do with its copy of the email after it is retrieved using POP.</para>
        /// </summary>
        [Parameter(HelpMessage = "What Google Mail should do with its copy of the email after it is retrieved using POP.",
            Position = 4)]
        [ValidateNotNullOrEmpty]
        public PopActionEnum? Action { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Pop()
            {
                Enable = this.Enable
            };

            if (EnableFor != null) body.EnableFor = EnableFor.ToString();

            if (Action != null) body.Action = Action.ToString();

            if (ShouldProcess("Email Settings Pop", "Get-GEmailSettingsPop"))
            {
                WriteObject(pop.Update(body, GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Signature
{
    /// <summary>
    /// <para type="synopsis">Retrieve the Google Mail signature.</para>
    /// <para type="description">Retrieve the Google Mail signature.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsSignature -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GEmailSettingsSignature">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsSignature",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GEmailSettingsSignature")]
    public class GetGEmailSettingsSignatureCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Signature", "Get-GEmailSettingsSignature"))
            {
                WriteObject(signature.Get(GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update the Google Mail signature.</para>
    /// <para type="description">Update the Google Mail signature.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GEmailSettingsSignature -UserName $SomeUserNameString -Signature $SomeSignatureString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GEmailSettingsSignature">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsSignature",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GEmailSettingsSignature")]
    public class SetGEmailSettingsSignatureCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">The signature to be appended to outgoing messages. * Don't want a signature? Set the signature to "" (empty string).</para>
        /// </summary>
        [Parameter(HelpMessage = "The signature to be appended to outgoing messages. * Don't want a signature? Set the signature to \"\" (empty string).",
            Position = 2,
            Mandatory = true)]
        [ValidateNotNull]
        public string Signature { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Signature()
            {
                SignatureValue = this.Signature
            };

            if (ShouldProcess("Email Settings Signature", "Set-GEmailSettingsSignature"))
            {
                WriteObject(signature.Update(body, GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.SendasAlias
{
    /// <summary>
    /// <para type="synopsis">Retrieve a Google Mail send-as alias.</para>
    /// <para type="description">Retrieve a Google Mail send-as alias.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsSendasAlias -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GEmailSettingsSendasAlias">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsSendasAlias",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GEmailSettingsSendasAlias")]
    public class GetGEmailSettingsSendasAliasCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings SendasAlias", "Get-GEmailSettingsSendasAlias"))
            {
                WriteObject(sendasAliases.Get(GAuthId, GetUserFromEmail(UserName)).SendasAliases);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Create a Google Mail send-as alias.</para>
    /// <para type="description">Create a Google Mail send-as alias.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GEmailSettingsSendasAlias -UserName $SomeUserNameString -Name $SomeNameString -Address $SomeAddressString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GEmailSettingsSendasAlias">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GEmailSettingsSendasAlias",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GEmailSettingsSendasAlias")]
    public class NewGEmailSettingsSendasAliasCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">The name that will appear in the "From" field for this user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The name that will appear in the \"From\" field for this user.",
            Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// <para type="description">The email address that appears as the origination address for emails sent by this user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The email address that appears as the origination address for emails sent by this user.",
            Position = 3,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }

        /// <summary>
        /// <para type="description">If set, this address will be included as the reply-to address in emails sent using the alias.</para>
        /// </summary>
        [Parameter(HelpMessage = "If set, this address will be included as the reply-to address in emails sent using the alias.",
            Position = 4)]
        [ValidateNotNullOrEmpty]
        public string ReplyTo { get; set; }

        /// <summary>
        /// <para type="description">If set to true, this alias will be become the new default alias to send-as for this user.</para>
        /// </summary>
        [Parameter(HelpMessage = "If set to true, this alias will be become the new default alias to send-as for this user.",
            Position = 5)]
        [ValidateNotNullOrEmpty]
        public bool? MakeDefault { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.SendasAlias()
            {
                Name = this.Name,
                Address = this.Address
            };

            if (!string.IsNullOrWhiteSpace(ReplyTo)) body.ReplyTo = ReplyTo;

            if (MakeDefault.HasValue) body.MakeDefault = MakeDefault.Value;

            if (ShouldProcess("Email Settings SendasAlias", "New-GEmailSettingsSendasAlias"))
            {
                WriteObject(sendasAliases.Insert(body, GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.VacationResponder
{
    /// <summary>
    /// <para type="synopsis">Retrieve Google Mail vacation-responder settings.</para>
    /// <para type="description">Retrieve Google Mail vacation-responder settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsVacationResponder -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GEmailSettingsVacationResponder">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsVacationResponder",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GEmailSettingsVacationResponder")]
    public class GetGEmailSettingsVacationResponderCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings VacationResponder", "Get-GEmailSettingsVacationResponder"))
            {
                WriteObject(vacationResponder.Get(GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update Google Mail vacation-responder settings.</para>
    /// <para type="description">Update Google Mail vacation-responder settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GEmailSettingsVacationResponder -UserName $SomeUserNameString -ContactsOnly $SomeContactsOnlyBool
    ///   -Enable $SomeEnableBool -EndDate $SomeEndDateTimeObject -Message $SomeMessageString -StartDate $SomeStartDateTimeObject -Subject $SomeSubjectString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GEmailSettingsVacationResponder">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsVacationResponder",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GEmailSettingsVacationResponder")]
    public class SetGEmailSettingsVacationResponderCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">Whether to only send the autoresponse to known contacts.</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to only send the autoresponse to known contacts.",
            Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool ContactsOnly { get; set; }

        /// <summary>
        /// <para type="description">Whether to only send the autoresponse to users in the same primary domain as the user taking the vacation.</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to only send the autoresponse to users in the same primary domain as the user taking the vacation.",
            Position = 3)]
        [ValidateNotNullOrEmpty]
        public bool? DomainOnly { get; set; }

        /// <summary>
        /// <para type="description">Whether to enable the vacation-responder.</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to enable the vacation-responder.",
            Position = 4,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool Enable { get; set; }

        /// <summary>
        /// <para type="description">The last day until which vacation responder is enabled for the user. In this version of the API, the endDate is the UTC timezone, not the user's timezone. Also see the startDate property.</para>
        /// </summary>
        [Parameter(HelpMessage = "The last day until which vacation responder is enabled for the user. In this version of the API, the endDate is the UTC timezone, not the user's timezone. Also see the startDate property.",
            Position = 5,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// <para type="description">The message body of the vacation-responder autoresponse.</para>
        /// </summary>
        [Parameter(HelpMessage = "The message body of the vacation-responder autoresponse.",
            Position = 6,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Message { get; set; }

        /// <summary>
        /// <para type="description">The first day when the vacation responder was enabled for the user. In this version of the API, the startDate is in the UTC timezone, not the user's timezone. Also see the endDate property.</para>
        /// </summary>
        [Parameter(HelpMessage = "The first day when the vacation responder was enabled for the user. In this version of the API, the startDate is in the UTC timezone, not the user's timezone. Also see the endDate property.",
            Position = 7,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// <para type="description">The subject line of the vacation-responder autoresponse.</para>
        /// </summary>
        [Parameter(HelpMessage = "The subject line of the vacation-responder autoresponse.",
            Position = 8,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.VacationResponder()
            {
                ContactsOnly = this.ContactsOnly,
                DomainOnly = (this.DomainOnly.HasValue) ? this.DomainOnly.Value : false,
                Enable = this.Enable,
                EndDate = this.EndDate.ToUniversalTime().ToString("yyyy-MM-dd"),
                Message = this.Message,
                StartDate = this.StartDate.ToUniversalTime().ToString("yyyy-MM-dd"),
                Subject = this.Subject
            };

            if (ShouldProcess("Email Settings VacationResponder", "Get-GEmailSettingsVacationResponder"))
            {
                WriteObject(vacationResponder.Update(body, GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.WebClip
{
    /// <summary>
    /// <para type="synopsis">Update Google Mail web clip settings.</para>
    /// <para type="description">Update Google Mail web clip settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Email Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GEmailSettingsWebClip -UserName $SomeUserNameString -Enable $SomeEnableBool</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GEmailSettingsWebClip">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsWebClip",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GEmailSettingsWebClip")]
    public class SetGEmailSettingsWebClipCommand : EmailsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The target Google Apps user.</para>
        /// </summary>
        [Parameter(HelpMessage = "The target Google Apps user.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">Whether to enable showing Web clips.</para>
        /// </summary>
        [Parameter(HelpMessage = "Whether to enable showing Web clips.",
            Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool Enable { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.WebClip()
            {
                Enable = this.Enable
            };

            if (ShouldProcess("Email Settings WebClip", "Set-GEmailSettingsWebClip"))
            {
                WriteObject(webClip.Update(body, GAuthId, GetUserFromEmail(UserName)));
            }
        }
    }
}
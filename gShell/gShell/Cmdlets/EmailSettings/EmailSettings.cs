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
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsDelegation",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGEmailSettingsDelegation : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Delegation", "Get-GEmailSettingsDelegation"))
            {
                WriteObject(delegation.Get(Domain, GetUserFromEmail(UserName)).DelegatesValue);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GEmailSettingsDelegation",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGEmailSettingsDelegation : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
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
                WriteObject(delegation.Insert(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GEmailSettingsDelegation",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class RemoveGEmailSettingsDelegation : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DelegateEmail { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Delegation", "Remove-GEmailSettingsDelegation"))
            {
                delegation.Delete(Domain, GetUserFromEmail(UserName), DelegateEmail);
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Filters
{
    [Cmdlet(VerbsCommon.New, "GEmailSettingsFilter",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGEmailSettingsFilter : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2)]
        [ValidateNotNullOrEmpty]
        public string From { get; set; }

        [Parameter(Position = 3)]
        [ValidateNotNullOrEmpty]
        public string To { get; set; }

        [Parameter(Position = 4)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; }

        [Parameter(Position = 5)]
        [ValidateNotNullOrEmpty]
        public string HasTheWords { get; set; }

        [Parameter(Position = 6)]
        [ValidateNotNullOrEmpty]
        public string DoesntHave { get; set; }

        [Parameter(Position = 7)]
        [ValidateNotNullOrEmpty]
        public bool? HasAttachment { get; set; }

        [Parameter(Position = 8)]
        [ValidateNotNullOrEmpty]
        public bool? ArchiveIt { get; set; }

        [Parameter(Position = 9)]
        [ValidateNotNullOrEmpty]
        public bool? MarkAsRead { get; set; }

        [Parameter(Position = 10)]
        [ValidateNotNullOrEmpty]
        public bool? StarIt { get; set; }

        [Parameter(Position = 11)]
        [ValidateNotNullOrEmpty]
        public string ApplyTheLabel { get; set; }

        [Parameter(Position = 12)]
        [ValidateNotNullOrEmpty]
        public string ForwardIt { get; set; }

        [Parameter(Position = 13)]
        [ValidateNotNullOrEmpty]
        public bool? DeleteIt { get; set; }

        [Parameter(Position = 14)]
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
                WriteObject(filters.Insert(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Forwarding
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsForwarding",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGEmailSettingsForwarding : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Forwarding", "Get-GEmailSettingsForwarding"))
            {
                WriteObject(forwarding.Get(Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GEmailSettingsForwarding",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsForwarding : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool Enable { get; set; }

        [Parameter(Position = 3,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ForwardTo { get; set; }

        [Parameter(Position = 4,
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
                WriteObject(forwarding.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.General
{
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsGeneral",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsGeneral : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2)]
        [ValidateNotNullOrEmpty]
        public GeneralPageSizeEnum? PageSize { get; set; }

        [Parameter(Position = 3)]
        [ValidateNotNullOrEmpty]
        public bool? Shortcuts { get; set; }

        [Parameter(Position = 4)]
        [ValidateNotNullOrEmpty]
        public bool? Arrows { get; set; }

        [Parameter(Position = 5)]
        [ValidateNotNullOrEmpty]
        public bool? Snippets { get; set; }

        [Parameter(Position = 6)]
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
                WriteObject(general.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Imap
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsImap",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGEmailSettingsImap : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Imap", "Get-GEmailSettingsImap"))
            {
                WriteObject(imap.Get(Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GEmailSettingsImap",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsImap : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
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
                WriteObject(imap.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Label
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsLabel",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetEmailSettingsLabel : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Label", "Get-GEmailSettingsLabel"))
            {
                WriteObject(labels.Get(Domain, GetUserFromEmail(UserName)).LabelsValue);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GEmailSettingsLabel",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewEmailSettingsLabel : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
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

                WriteObject(labels.Insert(newLabel, Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GEmailSettingsLabel",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class RemoveEmailSettingsLabel : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string LabelName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Label", "Remove-GEmailSettingsLabel"))
            {
                labels.Delete(Domain, GetUserFromEmail(UserName), LabelName);
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Language
{
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsLanguage",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsLanguage : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "word")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "abbrev")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "word")]
        [ValidateNotNullOrEmpty]
        public LanguageLanguageEnum Language { get; set; }

        [Parameter(Position = 2,
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
                WriteObject(language.Update(body, Domain, GetUserFromEmail(UserName)));
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
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsPop",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGEmailSettingsPop : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Pop", "Get-GEmailSettingsPop"))
            {
                WriteObject(pop.Get(Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GEmailSettingsPop",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsPop : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool Enable { get; set; }

        [Parameter(Position = 3)]
        [ValidateNotNullOrEmpty]
        public PopEnableForEnum? EnableFor { get; set; }

        [Parameter(Position = 4)]
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
                WriteObject(pop.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.Signature
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsSignature",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGEmailSettingsSignature : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Signature", "Get-GEmailSettingsSignature"))
            {
                WriteObject(signature.Get(Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GEmailSettingsSignature",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsSignature : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
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

            if (ShouldProcess("Email Settings Signature", "Get-GEmailSettingsSignature"))
            {
                WriteObject(signature.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.SendasAlias
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsSendasAlias",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGEmailSettingsSendasAlias : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings SendasAlias", "Get-GEmailSettingsSendasAlias"))
            {
                WriteObject(sendasAliases.Get(Domain, GetUserFromEmail(UserName)).SendasAliases);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GEmailSettingsSendasAlias",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGEmailSettingsSendasAlias : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }

        [Parameter(Position = 4)]
        [ValidateNotNullOrEmpty]
        public string ReplyTo { get; set; }

        [Parameter(Position = 5)]
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
                WriteObject(sendasAliases.Insert(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.VacationResponder
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsVacationResponder",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGEmailSettingsVacationResponder : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings VacationResponder", "Get-GEmailSettingsVacationResponder"))
            {
                WriteObject(vacationResponder.Get(Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GEmailSettingsVacationResponder",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsVacationResponder : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool ContactsOnly { get; set; }

        [Parameter(Position = 3)]
        [ValidateNotNullOrEmpty]
        public bool? DomainOnly { get; set; }

        [Parameter(Position = 4,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool Enable { get; set; }

        [Parameter(Position = 5,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public DateTime EndDate { get; set; }

        [Parameter(Position = 6,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Message { get; set; }

        [Parameter(Position = 7,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public DateTime StartDate { get; set; }

        [Parameter(Position = 8,
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
                WriteObject(vacationResponder.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}

namespace gShell.Cmdlets.Emailsettings.WebClip
{
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsWebClip",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsWebClip : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
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
                WriteObject(webClip.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}
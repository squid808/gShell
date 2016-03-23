using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;
using gShell.Cmdlets.Emailsettings;

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
            ParameterSetName="word")]
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
                WriteObject(mainBase.language.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }

        private string LookupLanguage(LanguageLanguageAbbrevEnum abbrev){
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

        private string LookupLanguage(LanguageLanguageEnum language)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

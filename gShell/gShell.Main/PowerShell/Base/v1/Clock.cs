using System;
using Google.Apis.Util;

namespace gShell.Main.PowerShell.Base.v1
{
    /// <summary>
    /// Class required to check the expiration of a token. A bit silly if you ask me.
    /// </summary>
    public sealed class Clock : IClock 
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
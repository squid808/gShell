using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gShell.dotNet.Utilities
{
    public class Utils
    {
        /// <summary>
        /// If the given username doesn't contain an @ assume it doesn't contain a domain and add it in.
        /// </summary>
        /// <returns></returns>
        public static string GetFullEmailAddress(string userName, string domain)
        {
            if (!userName.Contains("@"))
            {
                userName += "@" + domain;
            }

            return userName;
        }

        /// <summary>
        /// Return the domain given a full email address.
        /// </summary>
        public static string GetDomainFromEmail(string userEmail)
        {
            return userEmail.Split('@')[1];
        }

        /// <summary>
        /// Return the username given a full email address.
        /// </summary>
        public static string GetUserFromEmail(string userEmail)
        {
            return userEmail.Split('@')[0];
        }
    }
}

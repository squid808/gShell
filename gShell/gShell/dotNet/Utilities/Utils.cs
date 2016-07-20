using System;
using System.IO;
using gShell.dotNet.Utilities.OAuth2;

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
            if (string.IsNullOrWhiteSpace(userName)) return null;

            if (!userName.Contains("@"))
            {
                userName += "@" + domain;
            }

            return userName;
        }

        /// <summary>
        /// Google allows the user to provide a customerID of my_customer for some calls.
        /// This allows a user to use a blank customerID instead, filling it in for them.
        /// </summary>
        public static string CheckCustomerID(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                return "my_customer";
            }
            else
            {
                return customerId;
            }
        }

        /// <summary>
        /// Return the domain given a full email address.
        /// </summary>
        public static string GetDomainFromEmail(string userEmail)
        {
            if (userEmail.Contains("@"))
            {
                return userEmail.Split('@')[1];
            }
            else
            {
                return userEmail;
            }
        }

        /// <summary>
        /// Return the username given a full email address.
        /// </summary>
        public static string GetUserFromEmail(string userEmail)
        {
            if (!string.IsNullOrWhiteSpace(userEmail) && userEmail.Contains("@"))
            {
                return userEmail.Split('@')[0];
            }
            else
            {
                return userEmail;
            }
        }

        /// <summary>
        /// Takes a web-safe base64 encoded string and saves it to a file at the given path. Will overwrite files.
        /// </summary>
        public static void SaveImageFromBase64(string photoData, string path, bool noClobber=false)
        {
            FileMode createMode = (noClobber) ? FileMode.CreateNew : FileMode.Create;

            byte[] bytes = UrlTokenDecode(photoData);

            using (FileStream fs = new FileStream(path, createMode, FileAccess.Write))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        /// <summary>
        /// Loads a files and returns it as a web-safe base64 encoded string.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string LoadImageToBase64(string path)
        {
            return UrlTokenEncode(File.ReadAllBytes(path));
        }

        /// <summary>
        /// Custom version of System.Web.UrlTokenDecode found here: http://referencesource.microsoft.com/#System.Web/Util/HttpEncoder.cs,fb2fadc6081d51ed,references
        /// Normal method only reverses + and / and reads an end char to show how many padding characters were removed. 
        /// This actually replaces the padding and also handles replacing non-padding = with * and uses . for padding.
        /// https://developers.google.com/admin-sdk/directory/v1/reference/users/photos/update
        /// </summary>
        public static byte[] UrlTokenDecode(string input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            int len = input.Length;
            if (len < 1)
                return new byte[0];
            int endPos = 0;


            ///////////////////////////////////////////////////////////////////
            // Step 1: Create array to store the chars and the padding chars
            char[] base64Chars = new char[len];




            ////////////////////////////////////////////////////////
            // Step 2a: Find how many padding chars are present in the end
            for (endPos = len; endPos > 0; endPos--)
            {
                if (input[endPos - 1] != '.') // Found a non-padding char!
                {
                    break; // Stop here
                }
            }

            //get a count of how many paddings to add
            int paddingCount = len - endPos;

            ////////////////////////////////////////////////////////
            // Step 2b: Store all non-padding chars,
            //      replacing padding '.' with a '='
            for (int padPos = 0; padPos < paddingCount; padPos++)
            {
                base64Chars[len - padPos - 1] = '.';
            }

            ////////////////////////////////////////////////////////
            // Step 3: Copy in the chars. Transform the "-" to "+", and "*" to "/"
            for (int iter = 0; iter < len - paddingCount; iter++)
            {
                char c = input[iter];

                switch (c)
                {
                    case '-':
                        base64Chars[iter] = '+';
                        break;

                    case '_':
                        base64Chars[iter] = '/';
                        break;

                    case '*':
                        base64Chars[iter] = '=';
                        break;

                    default:
                        base64Chars[iter] = c;
                        break;
                }
            }

            string updated = new string(base64Chars);

            // Do the actual conversion
            byte[] results = Convert.FromBase64CharArray(base64Chars, 0, base64Chars.Length);
            return results;
        }

        /// <summary>
        /// Custom version of System.Web.UrlTokenEncode found here: http://referencesource.microsoft.com/#System.Web/Util/HttpEncoder.cs,0e3cb83cf51ca334,references
        /// Normal method only replaces + and / and gives an end char to show how many padding characters were removed. 
        /// This actually replaces the padding and also handles replacing non-padding = with * and uses . for padding.
        /// https://developers.google.com/admin-sdk/directory/v1/reference/users/photos/update
        /// </summary>
        public static string UrlTokenEncode(byte[] input)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (input.Length < 1)
                return String.Empty;

            string base64Str = null;
            int endPos = 0;
            char[] base64Chars = null;

            ////////////////////////////////////////////////////////
            // Step 1: Do a Base64 encoding
            base64Str = Convert.ToBase64String(input);
            if (base64Str == null)
                return null;

            ////////////////////////////////////////////////////////
            // Step 2: Find how many padding chars are present in the end
            for (endPos = base64Str.Length; endPos > 0; endPos--)
            {
                if (base64Str[endPos - 1] != '=') // Found a non-padding char!
                {
                    break; // Stop here
                }
            }

            //get a count of how many paddings to add
            int paddingCount = base64Str.Length - endPos;

            ////////////////////////////////////////////////////////
            // Step 3: Create char array to store all non-padding chars,
            //      replacing padding '=' signs with a '.'
            base64Chars = new char[base64Str.Length];
            for (int padPos = 0; padPos < paddingCount; padPos++)
            {
                base64Chars[base64Chars.Length - padPos - 1] = '.';
            }

            ////////////////////////////////////////////////////////
            // Step 3: Copy in the other chars. Transform the "+" to "-", and "/" to "_" and '=' to '*'
            for (int iter = 0; iter < endPos; iter++)
            {
                char c = base64Str[iter];

                switch (c)
                {
                    case '+':
                        base64Chars[iter] = '-';
                        break;

                    case '/':
                        base64Chars[iter] = '_';
                        break;

                    case '=':
                        base64Chars[iter] = '*';
                        break;

                    default:
                        base64Chars[iter] = c;
                        break;
                }
            }
            return new string(base64Chars);
        }
    }
}

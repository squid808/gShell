using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

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

        /// <summary>
        /// Converts a base64 string to an image.
        /// http://stackoverflow.com/questions/5400173/converting-a-base-64-string-to-an-image-and-saving-it
        /// </summary>
        public static Image Base64StringToImage(string photoData)
        {
            byte[] bytes = Convert.FromBase64String(photoData);

            Image image;    
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }

        /// <summary>
        /// Converts an image from a path to a base64 string
        /// http://stackoverflow.com/questions/21325661/convert-image-path-to-base64-string
        /// </summary>
        public static string ImageToBase64String(string Path)
        {
            using (Image image = Image.FromFile(Path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
    }
}

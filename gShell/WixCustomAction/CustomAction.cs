using System;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;
using System.Windows.Forms;
using System.Xml;

namespace CustomActions
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CustomAction1(Session session)
        {
            //TODO: Check for PS version and .NET version
            try
            {
                session.Log("Begin gShell Install Custom Action");

                session.Log("Updating local psModulePath environmental variable...");
                UpdatePowerShellPath();

                session.Log("Updating machine.config file...");
                UpdateConfigFile();


                session.Log("End gShell Install Custom Action");
                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.Log("ERROR in custom action ConfigureEwsFilter {0}", ex.ToString());
                return ActionResult.Failure;
            }
        }

        /// <summary>
        /// Adds a local env variable to the modules directory
        /// </summary>
        public static void UpdatePowerShellPath() 
        {
            //TODO: have it check to see if it exists first and, if it does, check if it has this string in it

            Environment.SetEnvironmentVariable("PSModulePath", @"%USERPROFILE%\Documents\WindowsPowerShell\Modules\",
                EnvironmentVariableTarget.User);
        }

        public static void UpdateConfigFile()
        {
            try
            {
                //TODO: Make sure this doesn't happen on subsequent upgrades and installs, multiple times
                string file = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\Machine.Config";                

                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                XmlElement node = doc.SelectSingleNode("/configuration") as XmlElement;

                XmlElement runtimeNode = doc.SelectSingleNode("/configuration/runtime") as XmlElement;

                if (runtimeNode == null)
                {
                    runtimeNode = node.AppendChild(doc.CreateElement("runtime")) as XmlElement;
                }

                
                XmlElement bindingNode = runtimeNode.AppendChild(doc.CreateElement("assemblyBinding")) as XmlElement;
                bindingNode.SetAttribute("xmlns", "urn:schemas-microsoft-com:asm.v1");

                XmlElement dependent1 = bindingNode.AppendChild(doc.CreateElement("dependentAssembly")) as XmlElement;
                XmlElement id1 = dependent1.AppendChild(doc.CreateElement("assemblyIdentity")) as XmlElement;
                id1.SetAttribute("name", "System.Runtime");
                id1.SetAttribute("publicKeyToken", "b03f5f7f11d50a3a");
                id1.SetAttribute("culture", "neutral");
                XmlElement redirect1 = dependent1.AppendChild(doc.CreateElement("bindingRedirect")) as XmlElement;
                redirect1.SetAttribute("oldVersion", "0.0.0.0-2.5.19.0");
                redirect1.SetAttribute("newVersion", "2.5.19.0");

                XmlElement dependent2 = bindingNode.AppendChild(doc.CreateElement("dependentAssembly")) as XmlElement;
                XmlElement id2 = dependent2.AppendChild(doc.CreateElement("assemblyIdentity")) as XmlElement;
                id2.SetAttribute("name", "System.Threading.Tasks");
                id2.SetAttribute("publicKeyToken", "b03f5f7f11d50a3a");
                id2.SetAttribute("culture", "neutral");
                XmlElement redirect2 = dependent2.AppendChild(doc.CreateElement("bindingRedirect")) as XmlElement;
                redirect2.SetAttribute("oldVersion", "0.0.0.0-2.5.19.0");
                redirect2.SetAttribute("newVersion", "2.5.19.0");

                XmlElement dependent3 = bindingNode.AppendChild(doc.CreateElement("dependentAssembly")) as XmlElement;
                XmlElement id3 = dependent3.AppendChild(doc.CreateElement("assemblyIdentity")) as XmlElement;
                id3.SetAttribute("name", "System.Net.Http");
                id3.SetAttribute("publicKeyToken", "b03f5f7f11d50a3a");
                id3.SetAttribute("culture", "neutral");
                XmlElement redirect3 = dependent3.AppendChild(doc.CreateElement("bindingRedirect")) as XmlElement;
                redirect3.SetAttribute("oldVersion", "0.0.0.0-2.1.10.0");
                redirect3.SetAttribute("newVersion", "2.1.10.0");

                XmlElement dependent4 = bindingNode.AppendChild(doc.CreateElement("dependentAssembly")) as XmlElement;
                XmlElement id4 = dependent4.AppendChild(doc.CreateElement("assemblyIdentity")) as XmlElement;
                id4.SetAttribute("name", "System.Net.Http.Primitives");
                id4.SetAttribute("publicKeyToken", "b03f5f7f11d50a3a");
                id4.SetAttribute("culture", "neutral");
                XmlElement redirect4 = dependent4.AppendChild(doc.CreateElement("bindingRedirect")) as XmlElement;
                redirect4.SetAttribute("oldVersion", "0.0.0.0-2.1.10.0");
                redirect4.SetAttribute("newVersion", "2.1.10.0");

                doc.Save(file);
            }
            catch
            {
                MessageBox.Show("Machine.Config failed to update");
            }
            
        }
    }
}
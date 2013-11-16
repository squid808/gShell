using System;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Collections.Generic;
using System.Xml.Linq;
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
            string current = Environment.GetEnvironmentVariable("PSModulePath", EnvironmentVariableTarget.User);
            string newPath = @"%USERPROFILE%\Documents\WindowsPowerShell\Modules\";

            if (null == current)
            {
                Environment.SetEnvironmentVariable("PSModulePath", newPath,
                    EnvironmentVariableTarget.User);
            }
            else if (!current.Contains(newPath))
            {
                Environment.SetEnvironmentVariable("PSModulePath",
                    current + ";" + newPath,
                    EnvironmentVariableTarget.User);
            }
        }

        public static void UpdateConfigFile()
        {
            try
            {
                //string file = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\Machine.Config";

                XmlDocument doc = new XmlDocument();
                doc.Load(System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile);

                XmlElement configurationNode = doc.SelectSingleNode("/configuration") as XmlElement;

                XmlElement runtimeNode = doc.SelectSingleNode("/configuration/runtime") as XmlElement;

                if (runtimeNode == null)
                {
                    //this may have to be added to the <configSections> if it's not already there - that's another battle i'm sure
                    runtimeNode = configurationNode.AppendChild(doc.CreateElement("runtime")) as XmlElement;
                }

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("bind", "urn:schemas-microsoft-com:asm.v1");

                XmlElement bindingNode;

                if (null == doc.SelectSingleNode("//bind:assemblyBinding", nsmgr))
                {
                    bindingNode = runtimeNode.AppendChild(doc.CreateElement("assemblyBinding", nsmgr.LookupNamespace("bind"))) as XmlElement;
                    bindingNode.SetAttribute("xmlns", "urn:schemas-microsoft-com:asm.v1");
                }
                else
                {
                    bindingNode = doc.SelectSingleNode("//bind:assemblyBinding", nsmgr) as XmlElement;
                }

                CheckNode(
                    doc, bindingNode, nsmgr,
                    "System.Runtime", "b03f5f7f11d50a3a",
                    "0.0.0.0-2.5.19.0", "2.5.19.0"
                    );

                CheckNode(
                    doc, bindingNode, nsmgr,
                    "System.Threading.Tasks", "b03f5f7f11d50a3a",
                    "0.0.0.0-2.5.19.0", "2.5.19.0"
                    );

                CheckNode(
                    doc, bindingNode, nsmgr,
                    "System.Net.Http", "b03f5f7f11d50a3a",
                    "0.0.0.0-2.1.10.0", "2.1.10.0"
                    );

                CheckNode(
                    doc, bindingNode, nsmgr,
                    "System.Net.Http.Primitives", "b03f5f7f11d50a3a",
                    "0.0.0.0-2.1.10.0", "2.1.10.0"
                    );

                doc.Save(System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile);
            }
            catch
            {
                MessageBox.Show("Machine.Config failed to update");
            }
            
        }

        public static void CheckNode(XmlDocument xmlDoc, XmlElement parentNode, XmlNamespaceManager nsmgr,
            string assemblyName, string assemblyPublicKeyToken,
            string bindingRedirectOldVersion, string bindingRedirectNewVersion)
        {
            XmlNodeList nodeList = xmlDoc.SelectNodes(
                    string.Format("//bind:assemblyBinding/bind:dependentAssembly/bind:assemblyIdentity[@name='{0}']", assemblyName),
                    nsmgr);

            if (0 < nodeList.Count)
            {
                foreach (XmlNode node in nodeList)
                {
                    bool isMatch = true;

                    //first check that the assembly ID matches
                    XmlElement assemblyIdentity = node as XmlElement;

                    if (assemblyIdentity.HasAttribute("name")
                        && assemblyIdentity.GetAttribute("name") == assemblyName
                        && assemblyIdentity.HasAttribute("publicKeyToken")
                        && assemblyIdentity.GetAttribute("publicKeyToken") == assemblyPublicKeyToken
                        && assemblyIdentity.HasAttribute("culture")
                        && assemblyIdentity.GetAttribute("culture") == "neutral")
                    {

                        //The assemblyIdentity element exists. Now grab the parent and check the other one
                        XmlNode parent = node.ParentNode;

                        XmlElement redirect = parent.SelectSingleNode(
                            string.Format("//bind:bindingRedirect[@oldVersion='{0}']", bindingRedirectOldVersion), nsmgr) as XmlElement;

                        if (!redirect.HasAttribute("oldVersion")
                        || redirect.GetAttribute("oldVersion") != bindingRedirectOldVersion
                        || !redirect.HasAttribute("newVersion")
                        || redirect.GetAttribute("newVersion") != bindingRedirectNewVersion)
                        {
                            isMatch = false;
                        }
                    }
                    else
                    {
                        isMatch = false;
                    }

                    if (!isMatch)
                    {
                        AddNode(xmlDoc, parentNode, nsmgr,
                            assemblyName, assemblyPublicKeyToken,
                            bindingRedirectOldVersion, bindingRedirectNewVersion);
                    }
                }
            }
            else
            {
                AddNode(xmlDoc, parentNode, nsmgr,
                    assemblyName, assemblyPublicKeyToken,
                    bindingRedirectOldVersion, bindingRedirectNewVersion);
            }
        }

        public static void AddNode(XmlDocument xmlDoc, XmlElement parentNode, XmlNamespaceManager nsmgr,
            string assemblyName, string assemblyPublicKeyToken,
            string bindingRedirectOldVersion, string bindingRedirectNewVersion)
        {
            //XmlElement dependent = parentNode.AppendChild(xmlDoc.CreateElement("dependentAssembly")) as XmlElement;
            XmlElement dependent = parentNode.AppendChild(xmlDoc.CreateElement(
                "dependentAssembly", nsmgr.LookupNamespace("bind"))) as XmlElement;
            XmlElement id = dependent.AppendChild(xmlDoc.CreateElement("assemblyIdentity", nsmgr.LookupNamespace("bind"))) as XmlElement;
            id.SetAttribute("name", assemblyName);
            id.SetAttribute("publicKeyToken", assemblyPublicKeyToken);
            id.SetAttribute("culture", "neutral");
            XmlElement redirect = dependent.AppendChild(xmlDoc.CreateElement("bindingRedirect", nsmgr.LookupNamespace("bind"))) as XmlElement;
            redirect.SetAttribute("oldVersion", bindingRedirectOldVersion);
            redirect.SetAttribute("newVersion", bindingRedirectNewVersion);
        }
    }
}
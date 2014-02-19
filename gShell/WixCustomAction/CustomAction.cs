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
        static bool logResults = false;
        static string logFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "gShellCustomLog.txt");

        [CustomAction]
        public static ActionResult CustomAction1(Session session)
        {
            Log(string.Format("Starting custom action log for gShell installation."));
            //TODO: Check for PS version and .NET version
            try
            {
                session.Log("Begin gShell Install Custom Action");

                session.Log("Updating local psModulePath environmental variable...");
                UpdatePowerShellPath();

                session.Log("Updating machine.config file...");

                string path = System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile;
                string path32, path64 = string.Empty;


                if (path.Contains("Framework64"))
                {
                    path64 = path;
                    path32 = path.Replace("Framework64", "Framework");
                }
                else
                {
                    path64 = path.Replace("Framework", "Framework64");
                    path32 = path;
                }

                Log(string.Format("System machine.config path: {0}", path));
                Log(string.Format("32 bit path determined to be: {0}",path32));
                Log(string.Format("64 bit path determined to be: {0}",path64));
                //Log(string.Format("{0}",));

                bool result32, result64 = false;

                if (File.Exists(path32)) {
                    result32 = UpdateConfigFile(path32);
                    Log(string.Format("Check/update for 32 bit config file was success: {0}",result32));
                } else {
                    result32 = true;
                    Log(string.Format("32 bit path file not found; proceeding with install."));
                }

                if (File.Exists(path64))
                {
                    result64 = UpdateConfigFile(path64);
                    Log(string.Format("Check/update for 64 bit config file was success: {0}", result64));
                }
                else
                {
                    result64 = true;
                    Log(string.Format("64 bit path file not found; proceeding with install."));
                }

                if (!result32 || !result64)
                {
                    Log(string.Format("One of the path updates returned false - aborting install."));
                    return ActionResult.Failure;
                }

                Log(string.Format("Custom install updates completed successfully. Remainder of installation proceeding."));
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
            Log(string.Format("Updating PowerShell path for user."));

            string current = Environment.GetEnvironmentVariable("PSModulePath", EnvironmentVariableTarget.User);
            Log(string.Format("Current PS env path: {0}", current));

            string newPath = @"%USERPROFILE%\Documents\WindowsPowerShell\Modules\";

            if (null == current)
            {
                Environment.SetEnvironmentVariable("PSModulePath", newPath,
                    EnvironmentVariableTarget.User);
                Log(string.Format("Existing path was missing or null. Path set to: {0}",newPath));
            }
            else if (!current.Contains(newPath))
            {
                Environment.SetEnvironmentVariable("PSModulePath",
                    current + ";" + newPath,
                    EnvironmentVariableTarget.User);
                Log(string.Format("Existing path found. Updating to: {0}", current + ";" + newPath));
            }
            else
            {
                Log(string.Format("Existing path found and is up to date."));
            }
            Log(string.Format("Updating of the PS Environmental path has completed."));
        }

        public static bool UpdateConfigFile(string path)
        {
            try
            {
                Log(string.Format("Updating config file: {0}", path));

                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                Log(string.Format("File has been loaded. Checking XML elements."));

                XmlElement configurationNode = doc.SelectSingleNode("/configuration") as XmlElement;

                XmlElement runtimeNode = doc.SelectSingleNode("/configuration/runtime") as XmlElement;

                if (runtimeNode == null)
                {
                    //this may have to be added to the <configSections> if it's not already there - that's another battle i'm sure
                    Log(string.Format("Runtime node was null. Adding..."));
                    runtimeNode = configurationNode.AppendChild(doc.CreateElement("runtime")) as XmlElement;
                    Log(string.Format("...added."));
                }

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("bind", "urn:schemas-microsoft-com:asm.v1");

                XmlElement bindingNode;

                if (null == doc.SelectSingleNode("//bind:assemblyBinding", nsmgr))
                {
                    Log(string.Format("Cannot find AssemblyBinding element. Creating..."));
                    bindingNode = runtimeNode.AppendChild(doc.CreateElement("assemblyBinding", nsmgr.LookupNamespace("bind"))) as XmlElement;
                    bindingNode.SetAttribute("xmlns", "urn:schemas-microsoft-com:asm.v1");
                    Log(string.Format("...created."));
                }
                else
                {
                    Log(string.Format("AssemblyBinding element found."));
                    bindingNode = doc.SelectSingleNode("//bind:assemblyBinding", nsmgr) as XmlElement;
                }

                bool result1, result2, result3, result4 = false;

                result1 = CheckNode(
                    doc, bindingNode, nsmgr,
                    "System.Runtime", "b03f5f7f11d50a3a",
                    "0.0.0.0-2.5.19.0", "2.5.19.0"
                    );

                result2 = CheckNode(
                    doc, bindingNode, nsmgr,
                    "System.Threading.Tasks", "b03f5f7f11d50a3a",
                    "0.0.0.0-2.5.19.0", "2.5.19.0"
                    );

                result3 = CheckNode(
                    doc, bindingNode, nsmgr,
                    "System.Net.Http", "b03f5f7f11d50a3a",
                    "0.0.0.0-2.1.10.0", "2.1.10.0"
                    );

                result4 = CheckNode(
                    doc, bindingNode, nsmgr,
                    "System.Net.Http.Primitives", "b03f5f7f11d50a3a",
                    "0.0.0.0-2.1.10.0", "2.1.10.0"
                    );

                if (result1 || result2 || result3 || result4)
                {
                    Log(string.Format("Saving file {0}", path));
                    doc.Save(path);
                    Log(string.Format("Save complete."));
                }
                else
                {
                    Log(string.Format("No changes found, the file will not be saved; may its soul rest in peace."));
                }
                return true;
            }
            catch
            {
                Log(string.Format("There was an error."));
                MessageBox.Show("Machine.Config failed to update - installation will not be successful.");
                return false;
            }
            
        }

        public static bool CheckNode(XmlDocument xmlDoc, XmlElement parentNode, XmlNamespaceManager nsmgr,
            string assemblyName, string assemblyPublicKeyToken,
            string bindingRedirectOldVersion, string bindingRedirectNewVersion)
        {
            Log(string.Format("Checking node for {0}",assemblyName));
            XmlNodeList nodeList = null;

            nodeList = xmlDoc.SelectNodes(
                    string.Format("//bind:assemblyBinding/bind:dependentAssembly/bind:assemblyIdentity[@name='{0}']", assemblyName),
                    nsmgr);

            if (0 < nodeList.Count)
            {
                Log(string.Format("{0} nodes were found matching that assembly name.", nodeList.Count.ToString()));

                bool isMatch = true; //err on the side of caution
                
                foreach (XmlNode node in nodeList)
                {
                    //first check that the assembly ID matches
                    XmlElement assemblyIdentity = node as XmlElement;

                    if (assemblyIdentity.HasAttribute("name")
                        && assemblyIdentity.GetAttribute("name") == assemblyName
                        && assemblyIdentity.HasAttribute("publicKeyToken")
                        && assemblyIdentity.GetAttribute("publicKeyToken") == assemblyPublicKeyToken
                        && assemblyIdentity.HasAttribute("culture")
                        && assemblyIdentity.GetAttribute("culture") == "neutral")
                    {
                        Log(string.Format("The assembly ID element exists and matches."));

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
                            Log(string.Format("The binding redirect does not match."));
                        }
                        else
                        {
                            Log(string.Format("The binding redirect also matches."));
                        }
                    }
                    else
                    {
                        Log(string.Format("The assembly ID element does not match."));
                        isMatch = false;
                    }
                }

                if (!isMatch)
                {
                    Log(string.Format("None of the existing nodes matched."));
                    AddNode(xmlDoc, parentNode, nsmgr,
                        assemblyName, assemblyPublicKeyToken,
                        bindingRedirectOldVersion, bindingRedirectNewVersion);

                    return true; //changed?
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Log(string.Format("No nodes were found that match this element."));
                AddNode(xmlDoc, parentNode, nsmgr,
                    assemblyName, assemblyPublicKeyToken,
                    bindingRedirectOldVersion, bindingRedirectNewVersion);

                return true;
            }
            
        }

        public static void AddNode(XmlDocument xmlDoc, XmlElement parentNode, XmlNamespaceManager nsmgr,
            string assemblyName, string assemblyPublicKeyToken,
            string bindingRedirectOldVersion, string bindingRedirectNewVersion)
        {
            Log(string.Format("Creating new element for {0}...", assemblyName));
            
            XmlElement dependent = parentNode.AppendChild(xmlDoc.CreateElement(
                "dependentAssembly", nsmgr.LookupNamespace("bind"))) as XmlElement;
            XmlElement id = dependent.AppendChild(xmlDoc.CreateElement("assemblyIdentity", nsmgr.LookupNamespace("bind"))) as XmlElement;
            id.SetAttribute("name", assemblyName);
            id.SetAttribute("publicKeyToken", assemblyPublicKeyToken);
            id.SetAttribute("culture", "neutral");
            XmlElement redirect = dependent.AppendChild(xmlDoc.CreateElement("bindingRedirect", nsmgr.LookupNamespace("bind"))) as XmlElement;
            redirect.SetAttribute("oldVersion", bindingRedirectOldVersion);
            redirect.SetAttribute("newVersion", bindingRedirectNewVersion);
            
            Log(string.Format("...created."));
        }

        private static void Log(string message)
        {
            if (logResults)
            {
                File.AppendAllText(logFile, 
                    string.Format("\r\n{0}: {1}", DateTime.Now.ToString("yyyyMMddHHmmssfff").ToString(), message));
            }
        }
    }
}
using System;
using System.Management.Automation;

namespace gShell.Cmdlets.Directory.GAUserProperty
{
    [Cmdlet(VerbsCommon.New, "GAUserPropertyCollection",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserPropertyCollection")]
    public class NewGAUserPropertyCollection : PSCmdlet
    {
        
        protected override void ProcessRecord()
        {
            WriteObject(new GAUserPropertyCollection());
        }

    }
}
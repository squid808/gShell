using System;
using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Directory.GAOrgUnit
{
    [Cmdlet(VerbsCommon.Get, "GAOrgUnit",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAOrgUnit")]
    public class GetGAOrgUnit : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            ParameterSetName = "One",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            ParameterSetName = "One",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OrgUnitPath { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "List",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OrgPath { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "List")]
        public SwitchParameter All { get; set; }

        [Parameter(Position = 5,
            Mandatory = true,
            ParameterSetName = "List",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Google.Apis.Admin.Directory.directory_v1.OrgunitsResource.ListRequest.TypeEnum Type { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(CustomerId, "Get-GAOrgUnit"))
            {
                if (ParameterSetName == "List")
                {
                    WriteObject(orgunits.List(CustomerId, new dotNet.Directory.Orgunits.OrgunitsListProperties()
                    {
                        orgUnitPath = OrgPath,
                        type = Type
                    }));
                } else {
                    WriteObject(orgunits.Get(CustomerId, OrgUnitPath));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GAOrgUnit",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAOrgUnit")]
    public class RemoveGAOrgUnit : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OrgUnitPath { get; set; }

        [Parameter(Position = 2)]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(CustomerId, "Remove-GAOrgUnit"))
            {
                if (Force || ShouldContinue((String.Format("OrgUnit {0} for CustomerId {2} will be removed from the {1} Google Apps domain.\nContinue?",
                    OrgUnitPath, Domain, CustomerId)), "Confirm Google Apps OrgUnit Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove OrgUnit {0}...",
                            CustomerId));
                        WriteObject(orgunits.Delete(CustomerId, OrgUnitPath));
                        WriteVerbose(string.Format("Removal of OrgUnit {0} completed without error.",
                            CustomerId));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, CustomerId));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("OrgUnit deletion not confirmed"),
                        "", ErrorCategory.InvalidData, CustomerId));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GAOrgUnit",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAOrgUnit")]
    public class SetGAOrgUnit : DirectoryBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OrgUnitPath { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ParentOrgUnitPath { get; set; }

        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool BlockInheritance { get; set; }

        [Parameter(Position = 6,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(CustomerId, "Set-GAOrgUnit"))
            {
                Data.OrgUnit body = new Data.OrgUnit();

                if (!string.IsNullOrWhiteSpace(Name))
                {
                    body.Name = Name;
                }

                if (!string.IsNullOrWhiteSpace(ParentOrgUnitPath))
                {
                    body.ParentOrgUnitPath = ParentOrgUnitPath;
                }

                if (BlockInheritance != null)
                {
                    body.BlockInheritance = BlockInheritance;
                }

                if (!string.IsNullOrWhiteSpace(Description))
                {
                    body.Description = Description;
                }

                WriteObject(orgunits.Patch(body, CustomerId, OrgUnitPath));
            }
        }
    }

    [Cmdlet(VerbsCommon.Add, "GAOrgUnit",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Add-GAOrgUnit")]
    public class NewGAOrgUnit : DirectoryBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ParentOrgUnitPath { get; set; }

        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool BlockInheritance { get; set; }

        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Position = 6,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OrgUnitPath { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(CustomerId, "Add-GAOrgUnit"))
            {
                Data.OrgUnit body = new Data.OrgUnit()
                {
                    Name = this.Name,
                    ParentOrgUnitPath = this.ParentOrgUnitPath,
                    BlockInheritance = this.BlockInheritance,
                    Description = this.Description,
                    OrgUnitPath = this.OrgUnitPath
                };

                WriteObject(orgunits.Insert(body, CustomerId));
            }
        }
    }
}

using System.IO;
using System.Management.Automation;

namespace gShell.Cmdlets.GroupsMigration
{
    public enum UploadTypeEnum
    {
        media, resumable
    }

    /// <summary>
    /// <para type="synopsis">Inserts a new mail into the archive of the Google group.</para>
    /// <para type="description">Inserts a new mail into the archive of the Google group.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google GroupsMigration API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GGroupsMigration -GroupUniqueId $SomeGroupIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> New-GGroupsMigration -GroupUniqueId $SomeGroupIdString -FilePath $SomeFilePath -UploadType media</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGroupsMigration">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGroupsMigration",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGroupsMigration",
          DefaultParameterSetName = "NoUpload")]
    public class NewGGroupsMigrationCommand : GroupsMigrationBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The group ID</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "The group ID")]
        [ValidateNotNullOrEmpty]
        public string GroupId { get; set; }

        /// <summary>
        /// <para type="description">The path to the file to upload.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "The path to the file to upload.",
            ParameterSetName = "MediaUpload")]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        /// <summary>
        /// <para type="description">The type of upload request to the upload URI.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = true,
            HelpMessage = "The type of upload request to the upload URI",
            ParameterSetName = "MediaUpload")]
        [ValidateNotNullOrEmpty]
        public UploadTypeEnum UploadType { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("GroupsMigration", "New-GGroupsMigration"))
            {
                if (ParameterSetName == "Default")
                {
                    WriteObject(archive.Insert(GroupId));
                }
                else
                {
                    using (FileStream stream = File.OpenRead(FilePath))
                    {
                        archive.Insert(GroupId, stream, UploadType.ToString());
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using System.Management.Automation;
using gShell.DriveCmdlets;

namespace gShell.DriveCmdlets.GADriveItem
{
    [Cmdlet(VerbsCommon.Get, "GADriveItem",
          SupportsShouldProcess = true)]
    public class GetGADriveItem : DriveBase
    {
        [Parameter(Position = 2,
            ParameterSetName = "Query",
            HelpMessage="https://developers.google.com/drive/search-parameters")]
        public string Query { get; set; }

        protected override void ProcessRecord()
        {

            switch (ParameterSetName)
            {
                case "Query":
                    if (ShouldProcess("Query", "Get-GADriveItem"))
                    {
                        WriteObject(QueryFile());
                    }
                    break;

                default:
                    if (ShouldProcess("Drive Item", "Get-GADriveItem"))
                    {
                        WriteObject(ListAllFiles());
                    }
                    break;
            }
        }

        private List<GShellDriveItemObject> ListAllFiles(string query = "")
        {
            FilesResource.ListRequest request = driveServiceDict[Domain][User].Files.List();

            request.MaxResults = 1000;

            if (!string.IsNullOrWhiteSpace(Query))
            {
                request.Q = Query;
            }

            StartProgressBar("Gathering drive items",
                "-Collecting drive items 1 to " + request.MaxResults.ToString());

            UpdateProgressBar(1, 2, "Gathering drive items",
                "-Collecting drive items 1 to " + request.MaxResults.ToString());

            FileList execution = request.Execute();

            List<File> returnedList = new List<File>();

            returnedList.AddRange(execution.Items);

            while (!string.IsNullOrWhiteSpace(execution.NextPageToken))
            {
                request.PageToken = execution.NextPageToken;
                UpdateProgressBar(5, 10,
                    "Gathering drive items",
                    string.Format("-Collecting drive items {0} to {1}",
                     (returnedList.Count + 1).ToString(),
                     (returnedList.Count + request.MaxResults).ToString()));
                execution = request.Execute();
                returnedList.AddRange(execution.Items);
            }

            UpdateProgressBar(1, 2, "Gathering drive items",
                "-Returning " + returnedList.Count.ToString() + " results.");

            return (GShellDriveItemObject.ConvertList(returnedList));
        }

        private List<GShellDriveItemObject> QueryFile()
        {
            return (ListAllFiles(Query));
        }
    }

    public class GShellDriveItemObject
    {
        public bool? Editable;
        public bool? Shared;
        public string Title;
        public string FileExtension;
        public long? FileSize;
        public long? QuotaBytesUsed;
        public List<string> OwnerNames;
        public string LastModifyingUserName;
        public string OriginalFileName;
        
        public File driveItemObject;

        public GShellDriveItemObject(File fileObj)
        {
            OwnerNames = new List<string>();

            Editable = fileObj.Editable;
            Shared = fileObj.Shared;
            Title = fileObj.Title;
            FileExtension = fileObj.FileExtension;
            FileSize = fileObj.FileSize;
            QuotaBytesUsed = fileObj.QuotaBytesUsed;
            if (null != fileObj.OwnerNames && fileObj.OwnerNames.Count != 0)
            {
                OwnerNames.AddRange(fileObj.OwnerNames);
            }
            LastModifyingUserName = fileObj.LastModifyingUserName;
            OriginalFileName = fileObj.OriginalFilename;

            driveItemObject = fileObj;
        }

        //TODO make this inherit from a superclass with a generic function
        public static List<GShellDriveItemObject> ConvertList(List<File> fileList)
        {
            List<GShellDriveItemObject> customList = new List<GShellDriveItemObject>();

            foreach (File file in fileList)
            {
                customList.Add(new GShellDriveItemObject(file));
            }

            return (customList);
        }
    }
}

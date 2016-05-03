namespace gShell.Cmdlets.Classroom{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using v1 = Google.Apis.Classroom.v1;
    using Data = Google.Apis.Classroom.v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gClassroom = gShell.dotNet.Classroom;

    public abstract class ClassroomBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gClassroom mainBase { get; set; }

        public Courses courses { get; set; }
        public Invitations invitations { get; set; }
        public UserProfiles userProfiles { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        protected static string gShellServiceAccount { get; set; }
        #endregion

        #region Constructors
        public ClassroomBase()
        {
            mainBase = new gClassroom();

            courses = new Courses();
            invitations = new Invitations();
            userProfiles = new UserProfiles();
        }
        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets();
            if (secrets != null)
            {
                IEnumerable<string> scopes = EnsureScopesExist(Domain);
                Domain = mainBase.BuildService(Authenticate(scopes, secrets, Domain), gShellServiceAccount).domain;

                GWriteProgress = new gWriteProgress(WriteProgress);
            }
            else
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Client Secrets must be set before running cmdlets. Run 'Get-Help "
                    + "Set-gShellClientSecrets -online' for more information."))));
            }
        }

        protected override void EndProcessing()
        {
            gShellServiceAccount = string.Empty;
        }

        protected override void StopProcessing()
        {
            gShellServiceAccount = string.Empty;
        }
        #endregion

        #region Authentication & Processing
        protected override AuthenticatedUserInfo Authenticate(IEnumerable<string> Scopes, ClientSecrets Secrets, string Domain = null)
        {
            return mainBase.Authenticate(apiNameAndVersion, Scopes, Secrets, Domain);
        }
        #endregion

        #region Wrapped Methods



        #region Courses

        public class Courses
        {

            public Aliases aliases{ get; set; }
            public Students students{ get; set; }
            public Teachers teachers{ get; set; }

            public Courses() //public Reports()
            {

                aliases = new Aliases();
                students = new Students();
                teachers = new Teachers();
            }

            #region Aliases

            public class Aliases
            {




                public Google.Apis.Classroom.v1.Data.CourseAlias Create (Google.Apis.Classroom.v1.Data.CourseAlias body, string

                 courseId)
                {

                    return mainBase.courses.aliases.Create(body, courseId, gShellServiceAccount);
                }


                public Google.Apis.Classroom.v1.Data.Empty Delete (string

                 courseId, string

                 alias)
                {

                    return mainBase.courses.aliases.Delete(courseId, alias, gShellServiceAccount);
                }


                public List<Google.Apis.Classroom.v1.Data.ListCourseAliasesResponse> List(string

                 courseId, gClassroom.Courses.Aliases.AliasesListProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gClassroom.Courses.Aliases.AliasesListProperties();


                    return mainBase.courses.aliases.List(courseId, properties);
                }
            }

            #endregion
            #region Students

            public class Students
            {




                public Google.Apis.Classroom.v1.Data.Student Create (Google.Apis.Classroom.v1.Data.Student body, string

                 courseId, gClassroom.Courses.Students.StudentsCreateProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gClassroom.Courses.Students.StudentsCreateProperties();

                    return mainBase.courses.students.Create(body, courseId, properties, gShellServiceAccount);
                }


                public Google.Apis.Classroom.v1.Data.Empty Delete (string

                 courseId, string

                 userId)
                {

                    return mainBase.courses.students.Delete(courseId, userId, gShellServiceAccount);
                }


                public Google.Apis.Classroom.v1.Data.Student Get (string

                 courseId, string

                 userId)
                {

                    return mainBase.courses.students.Get(courseId, userId, gShellServiceAccount);
                }


                public List<Google.Apis.Classroom.v1.Data.ListStudentsResponse> List(string

                 courseId, gClassroom.Courses.Students.StudentsListProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gClassroom.Courses.Students.StudentsListProperties();


                    return mainBase.courses.students.List(courseId, properties);
                }
            }

            #endregion
            #region Teachers

            public class Teachers
            {




                public Google.Apis.Classroom.v1.Data.Teacher Create (Google.Apis.Classroom.v1.Data.Teacher body, string

                 courseId)
                {

                    return mainBase.courses.teachers.Create(body, courseId, gShellServiceAccount);
                }


                public Google.Apis.Classroom.v1.Data.Empty Delete (string

                 courseId, string

                 userId)
                {

                    return mainBase.courses.teachers.Delete(courseId, userId, gShellServiceAccount);
                }


                public Google.Apis.Classroom.v1.Data.Teacher Get (string

                 courseId, string

                 userId)
                {

                    return mainBase.courses.teachers.Get(courseId, userId, gShellServiceAccount);
                }


                public List<Google.Apis.Classroom.v1.Data.ListTeachersResponse> List(string

                 courseId, gClassroom.Courses.Teachers.TeachersListProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gClassroom.Courses.Teachers.TeachersListProperties();


                    return mainBase.courses.teachers.List(courseId, properties);
                }
            }

            #endregion


            public Google.Apis.Classroom.v1.Data.Course Create (Google.Apis.Classroom.v1.Data.Course body)
            {

                return mainBase.courses.Create(body, gShellServiceAccount);
            }


            public Google.Apis.Classroom.v1.Data.Empty Delete (string

             id)
            {

                return mainBase.courses.Delete(id, gShellServiceAccount);
            }


            public Google.Apis.Classroom.v1.Data.Course Get (string

             id)
            {

                return mainBase.courses.Get(id, gShellServiceAccount);
            }


            public List<Google.Apis.Classroom.v1.Data.ListCoursesResponse> List(gClassroom.Courses.CoursesListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gClassroom.Courses.CoursesListProperties();


                return mainBase.courses.List(properties);
            }


            public Google.Apis.Classroom.v1.Data.Course Patch (Google.Apis.Classroom.v1.Data.Course body, string

             id, gClassroom.Courses.CoursesPatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gClassroom.Courses.CoursesPatchProperties();

                return mainBase.courses.Patch(body, id, properties, gShellServiceAccount);
            }


            public Google.Apis.Classroom.v1.Data.Course Update (Google.Apis.Classroom.v1.Data.Course body, string

             id)
            {

                return mainBase.courses.Update(body, id, gShellServiceAccount);
            }
        }

        #endregion



        #region Invitations

        public class Invitations
        {




            public Google.Apis.Classroom.v1.Data.Empty Accept (string

             id)
            {

                return mainBase.invitations.Accept(id, gShellServiceAccount);
            }


            public Google.Apis.Classroom.v1.Data.Invitation Create (Google.Apis.Classroom.v1.Data.Invitation body)
            {

                return mainBase.invitations.Create(body, gShellServiceAccount);
            }


            public Google.Apis.Classroom.v1.Data.Empty Delete (string

             id)
            {

                return mainBase.invitations.Delete(id, gShellServiceAccount);
            }


            public Google.Apis.Classroom.v1.Data.Invitation Get (string

             id)
            {

                return mainBase.invitations.Get(id, gShellServiceAccount);
            }


            public List<Google.Apis.Classroom.v1.Data.ListInvitationsResponse> List(gClassroom.Invitations.InvitationsListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gClassroom.Invitations.InvitationsListProperties();


                return mainBase.invitations.List(properties);
            }
        }

        #endregion



        #region UserProfiles

        public class UserProfiles
        {




            public Google.Apis.Classroom.v1.Data.UserProfile Get (string

             userId)
            {

                return mainBase.userProfiles.Get(userId, gShellServiceAccount);
            }
        }

        #endregion

        #endregion

    }
}



namespace gShell.dotNet
{
    using System;
    using System.Collections.Generic;

    using gShell.dotNet;
    using gShell.dotNet.Utilities.OAuth2;

    using v1 = Google.Apis.Classroom.v1;
    using Data = Google.Apis.Classroom.v1.Data;

    public class Classroom : ServiceWrapper<v1.ClassroomService>
    {

        protected override bool worksWithGmail { get { return true; } }

        protected override v1.ClassroomService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new v1.ClassroomService(OAuth2Base.GetInitializer(domain, authInfo, gShellServiceAccount));
        }

        public override string apiNameAndVersion { get { return "classroom:v1"; } }

        public Courses courses{ get; set; }
        public Invitations invitations{ get; set; }
        public UserProfiles userProfiles{ get; set; }

        public Classroom() //public Reports()
        {

            courses = new Courses();
            invitations = new Invitations();
            userProfiles = new UserProfiles();
        }




        public class Courses
        {

        public Aliases aliases{ get; set; }
        public Students students{ get; set; }
        public Teachers teachers{ get; set; }

        public Courses() //public Reports()
        {

            aliases = new Aliases();
            students = new Students();
            teachers = new Teachers();
        }


            public class CoursesListProperties
            {
                public     string     studentId = null; //test
                public     string     teacherId = null; //test
                public     System.Nullable<int>     pageSize = null; //test

                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public class CoursesPatchProperties
            {
                public     string     updateMask = null; //test
            }


            public Google.Apis.Classroom.v1.Data.Course Create
            (Google.Apis.Classroom.v1.Data.Course body, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Courses.Create(body).Execute();
            }

            public Google.Apis.Classroom.v1.Data.Empty Delete
            (string id, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Courses.Delete(id).Execute();
            }

            public Google.Apis.Classroom.v1.Data.Course Get
            (string id, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Courses.Get(id).Execute();
            }

            public List<Google.Apis.Classroom.v1.Data.ListCoursesResponse> List(
                CoursesListProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Classroom.v1.Data.ListCoursesResponse>();

                v1.CoursesResource.ListRequest request = GetService(gShellServiceAccount).Courses.List(
            );

                if (properties != null)
                {
                    request.StudentId = properties.studentId;
                    request.TeacherId = properties.teacherId;
                    request.PageSize = properties.pageSize;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Courses",
                        string.Format("-Collecting Courses 1 to {0}", "unknown"));
                }

                Google.Apis.Classroom.v1.Data.ListCoursesResponse pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Courses",
                                    string.Format("-Collecting Courses {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        "unknown"));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Courses",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.Classroom.v1.Data.Course Patch
            (Google.Apis.Classroom.v1.Data.Course body, string id, CoursesPatchProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Courses.Patch(body, id).Execute();
            }

            public Google.Apis.Classroom.v1.Data.Course Update
            (Google.Apis.Classroom.v1.Data.Course body, string id, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Courses.Update(body, id).Execute();
            }


            public class Aliases
            {



                public class AliasesListProperties
                {
                    public     System.Nullable<int>     pageSize = null; //test

                    public Action<string, string> startProgressBar = null;
                    public Action<int, int, string, string> updateProgressBar = null;
                    public int totalResults = 0;
                }


                public Google.Apis.Classroom.v1.Data.CourseAlias Create
                (Google.Apis.Classroom.v1.Data.CourseAlias body, string courseId, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Courses.Aliases.Create(body, courseId).Execute();
                }

                public Google.Apis.Classroom.v1.Data.Empty Delete
                (string courseId, string alias, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Courses.Aliases.Delete(courseId, alias).Execute();
                }

                public List<Google.Apis.Classroom.v1.Data.ListCourseAliasesResponse> List(
                    string     courseId, AliasesListProperties properties = null, string gShellServiceAccount = null)
                {
                    var results = new List<Google.Apis.Classroom.v1.Data.ListCourseAliasesResponse>();

                    v1.CoursesResource.AliasesResource.ListRequest request = GetService(gShellServiceAccount).Courses.Aliases.List(
                courseId);

                    if (properties != null)
                    {
                        request.PageSize = properties.pageSize;

                    }

                    if (null != properties.startProgressBar)
                    {
                        properties.startProgressBar("Gathering Aliases",
                            string.Format("-Collecting Aliases 1 to {0}", "unknown"));
                    }

                    Google.Apis.Classroom.v1.Data.ListCourseAliasesResponse pagedResult = request.Execute();

                    if (pagedResult != null)
                    {
                        results.Add(pagedResult);

                        while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                            pagedResult.NextPageToken != request.PageToken &&
                        (properties.totalResults == 0 || results.Count < properties.totalResults))
                        {
                            request.PageToken = pagedResult.NextPageToken;

                            if (null != properties.updateProgressBar)
                            {
                                properties.updateProgressBar(5, 10, "Gathering Aliases",
                                        string.Format("-Collecting Aliases {0} to {1}",
                                            (results.Count + 1).ToString(),
                                            "unknown"));
                            }
                            pagedResult = request.Execute();
                            results.Add(pagedResult);
                        }

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(1, 2, "Gathering Aliases",
                                    string.Format("-Returning {0} results.", results.Count.ToString()));
                        }
                    }

                    return results;
                }

            }


            public class Students
            {



                public class StudentsCreateProperties
                {
                    public     string     enrollmentCode = null; //test
                }

                public class StudentsListProperties
                {
                    public     System.Nullable<int>     pageSize = null; //test

                    public Action<string, string> startProgressBar = null;
                    public Action<int, int, string, string> updateProgressBar = null;
                    public int totalResults = 0;
                }


                public Google.Apis.Classroom.v1.Data.Student Create
                (Google.Apis.Classroom.v1.Data.Student body, string courseId, StudentsCreateProperties properties = null, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Courses.Students.Create(body, courseId).Execute();
                }

                public Google.Apis.Classroom.v1.Data.Empty Delete
                (string courseId, string userId, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Courses.Students.Delete(courseId, userId).Execute();
                }

                public Google.Apis.Classroom.v1.Data.Student Get
                (string courseId, string userId, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Courses.Students.Get(courseId, userId).Execute();
                }

                public List<Google.Apis.Classroom.v1.Data.ListStudentsResponse> List(
                    string     courseId, StudentsListProperties properties = null, string gShellServiceAccount = null)
                {
                    var results = new List<Google.Apis.Classroom.v1.Data.ListStudentsResponse>();

                    v1.CoursesResource.StudentsResource.ListRequest request = GetService(gShellServiceAccount).Courses.Students.List(
                courseId);

                    if (properties != null)
                    {
                        request.PageSize = properties.pageSize;

                    }

                    if (null != properties.startProgressBar)
                    {
                        properties.startProgressBar("Gathering Students",
                            string.Format("-Collecting Students 1 to {0}", "unknown"));
                    }

                    Google.Apis.Classroom.v1.Data.ListStudentsResponse pagedResult = request.Execute();

                    if (pagedResult != null)
                    {
                        results.Add(pagedResult);

                        while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                            pagedResult.NextPageToken != request.PageToken &&
                        (properties.totalResults == 0 || results.Count < properties.totalResults))
                        {
                            request.PageToken = pagedResult.NextPageToken;

                            if (null != properties.updateProgressBar)
                            {
                                properties.updateProgressBar(5, 10, "Gathering Students",
                                        string.Format("-Collecting Students {0} to {1}",
                                            (results.Count + 1).ToString(),
                                            "unknown"));
                            }
                            pagedResult = request.Execute();
                            results.Add(pagedResult);
                        }

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(1, 2, "Gathering Students",
                                    string.Format("-Returning {0} results.", results.Count.ToString()));
                        }
                    }

                    return results;
                }

            }


            public class Teachers
            {



                public class TeachersListProperties
                {
                    public     System.Nullable<int>     pageSize = null; //test

                    public Action<string, string> startProgressBar = null;
                    public Action<int, int, string, string> updateProgressBar = null;
                    public int totalResults = 0;
                }


                public Google.Apis.Classroom.v1.Data.Teacher Create
                (Google.Apis.Classroom.v1.Data.Teacher body, string courseId, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Courses.Teachers.Create(body, courseId).Execute();
                }

                public Google.Apis.Classroom.v1.Data.Empty Delete
                (string courseId, string userId, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Courses.Teachers.Delete(courseId, userId).Execute();
                }

                public Google.Apis.Classroom.v1.Data.Teacher Get
                (string courseId, string userId, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Courses.Teachers.Get(courseId, userId).Execute();
                }

                public List<Google.Apis.Classroom.v1.Data.ListTeachersResponse> List(
                    string     courseId, TeachersListProperties properties = null, string gShellServiceAccount = null)
                {
                    var results = new List<Google.Apis.Classroom.v1.Data.ListTeachersResponse>();

                    v1.CoursesResource.TeachersResource.ListRequest request = GetService(gShellServiceAccount).Courses.Teachers.List(
                courseId);

                    if (properties != null)
                    {
                        request.PageSize = properties.pageSize;

                    }

                    if (null != properties.startProgressBar)
                    {
                        properties.startProgressBar("Gathering Teachers",
                            string.Format("-Collecting Teachers 1 to {0}", "unknown"));
                    }

                    Google.Apis.Classroom.v1.Data.ListTeachersResponse pagedResult = request.Execute();

                    if (pagedResult != null)
                    {
                        results.Add(pagedResult);

                        while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                            pagedResult.NextPageToken != request.PageToken &&
                        (properties.totalResults == 0 || results.Count < properties.totalResults))
                        {
                            request.PageToken = pagedResult.NextPageToken;

                            if (null != properties.updateProgressBar)
                            {
                                properties.updateProgressBar(5, 10, "Gathering Teachers",
                                        string.Format("-Collecting Teachers {0} to {1}",
                                            (results.Count + 1).ToString(),
                                            "unknown"));
                            }
                            pagedResult = request.Execute();
                            results.Add(pagedResult);
                        }

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(1, 2, "Gathering Teachers",
                                    string.Format("-Returning {0} results.", results.Count.ToString()));
                        }
                    }

                    return results;
                }

            }

        }


        public class Invitations
        {



            public class InvitationsListProperties
            {
                public     string     userId = null; //test
                public     string     courseId = null; //test
                public     System.Nullable<int>     pageSize = null; //test

                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public Google.Apis.Classroom.v1.Data.Empty Accept
            (string id, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Invitations.Accept(id).Execute();
            }

            public Google.Apis.Classroom.v1.Data.Invitation Create
            (Google.Apis.Classroom.v1.Data.Invitation body, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Invitations.Create(body).Execute();
            }

            public Google.Apis.Classroom.v1.Data.Empty Delete
            (string id, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Invitations.Delete(id).Execute();
            }

            public Google.Apis.Classroom.v1.Data.Invitation Get
            (string id, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Invitations.Get(id).Execute();
            }

            public List<Google.Apis.Classroom.v1.Data.ListInvitationsResponse> List(
                InvitationsListProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Classroom.v1.Data.ListInvitationsResponse>();

                v1.InvitationsResource.ListRequest request = GetService(gShellServiceAccount).Invitations.List(
            );

                if (properties != null)
                {
                    request.UserId = properties.userId;
                    request.CourseId = properties.courseId;
                    request.PageSize = properties.pageSize;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Invitations",
                        string.Format("-Collecting Invitations 1 to {0}", "unknown"));
                }

                Google.Apis.Classroom.v1.Data.ListInvitationsResponse pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Invitations",
                                    string.Format("-Collecting Invitations {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        "unknown"));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Invitations",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

        }


        public class UserProfiles
        {





            public Google.Apis.Classroom.v1.Data.UserProfile Get
            (string userId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).UserProfiles.Get(userId).Execute();
            }

        }

    }
}
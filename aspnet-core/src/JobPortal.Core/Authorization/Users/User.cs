using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using JobPortal.Applicant;
using JobPortal.ApplicantJobs;
using JobPortal.Jobs;
using JobPortal.Models.Recruiters;

namespace JobPortal.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public RecruiterDetails Recruiter { get; set; }

        public ApplicantDetails Applicant { get; set; }


        public ICollection<JobDetails> PostedJobs { get; set; }

        public ICollection<AppliedJobs> AppliedJobs { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}

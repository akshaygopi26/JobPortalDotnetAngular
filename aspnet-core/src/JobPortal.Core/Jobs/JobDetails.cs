using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JobPortal.ApplicantJobs;
using JobPortal.Authorization.Users;
using JobPortal.Models.Recruiters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Jobs
{
    [Table("JobDetails")]
    public class JobDetails : Entity,IAudited,IMustHaveTenant
    {
        public long? CreatorUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string Eligibility { get; set; }

        public string SkillsRequired { get; set; }

        public string MinimumExperienceRequired { get; set; }

        public DateTime CreationTime { get; set ; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }

        public ICollection<AppliedJobs> ApplicantList { get; set; }
        public int TenantId { get ; set ; }
    }
}

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JobPortal.ApplicantJobs;
using JobPortal.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Applicant
{
    public class ApplicantDetails : Entity, ICreationAudited, IMustHaveTenant
    {

        [Column("ApplicantID")]
        public long? CreatorUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }


        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public int Age { get; set; }

        public int TenthPercentage { get; set; }

        public int TwelthPercentage { get; set; }

        public string HighestQualifcation { get; set; }
        public DateTime CreationTime { get ; set ; }
        public int TenantId { get ; set ; }

        // public ICollection<AppliedJobs> AppliedJobs { get; set; }

    }
}

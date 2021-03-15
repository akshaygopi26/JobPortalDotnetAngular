using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JobPortal.Authorization.Users;
using JobPortal.Jobs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Models.Recruiters
{
    public class RecruiterDetails : Entity,IAudited,IMustHaveTenant
    {
        [Column("RecruiterID")]
        public long? CreatorUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }


        public string CompanyName { get; set; }

       // public string Mobile { get; set; }

        //public string Email { get; set; }
        //public string Password { get; set; }

        
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set ; }
        public DateTime? LastModificationTime { get ; set ; }
        public int TenantId { get ; set; }

        // public ICollection<JobDetails> PostedJobs { get; set; }
    }
}

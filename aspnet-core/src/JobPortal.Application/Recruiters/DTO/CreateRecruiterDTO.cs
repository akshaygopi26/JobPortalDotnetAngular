using Abp.AutoMapper;
using JobPortal.Models.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Recruiters.DTO
{
    [AutoMapTo(typeof(RecruiterDetails))]
    public class CreateRecruiterDTO
    {

        public string CompanyName { get; set; }

        // public string Mobile { get; set; }

        //public string Email { get; set; }
        //public string Password { get; set; }


       // public DateTime CreationTime { get; set; }
       // public long? LastModifierUserId { get; set; }
        //public DateTime? LastModificationTime { get; set; }

      //  public ICollection<JobDetails> PostedJobs { get; set; }

    }
}

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JobPortal.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.ApplicantJobs.DTO
{
    //[AutoMapFrom(typeof(JobDetails))]
    public class AppliedJobListDTO 
    {
        public int AppliedJobId { get; set; }
        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string Eligibility { get; set; }

        public string SkillsRequired { get; set; }

        public string MinimumExperienceRequired { get; set; }
       
    }
}

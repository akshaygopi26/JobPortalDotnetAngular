using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Jobs.DTO
{
    [AutoMapTo(typeof(JobDetails))]
    public class CreateJobInput
    {
        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string Eligibility { get; set; }

        public string SkillsRequired { get; set; }

        public string MinimumExperienceRequired { get; set; }
    }
}

using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Applicant.DTO
{
    [AutoMapTo(typeof(ApplicantDetails))]
    public class CreateApplicantDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public int Age { get; set; }

        public int TenthPercentage { get; set; }

        public int TwelthPercentage { get; set; }

        public string HighestQualifcation { get; set; }
    }
}

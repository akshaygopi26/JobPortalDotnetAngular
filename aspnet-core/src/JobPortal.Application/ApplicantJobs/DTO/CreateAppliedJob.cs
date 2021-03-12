using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.ApplicantJobs.DTO
{
    [AutoMapTo(typeof(AppliedJobs))]
    public class CreateAppliedJob
    {
        public int JobId { get; set; }
    }
}

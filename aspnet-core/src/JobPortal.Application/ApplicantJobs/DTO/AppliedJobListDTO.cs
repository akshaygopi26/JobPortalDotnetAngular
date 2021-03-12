using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.ApplicantJobs.DTO
{
    [AutoMapFrom(typeof(AppliedJobs))]
    public class AppliedJobListDTO
    {
        public long? CreatorUserId { get; set; }

        public int JobId { get; set; }
    }
}

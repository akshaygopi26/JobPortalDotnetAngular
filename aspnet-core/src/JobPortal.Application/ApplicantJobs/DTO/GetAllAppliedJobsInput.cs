using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.ApplicantJobs.DTO
{
    public class GetAllAppliedJobsInput : PagedResultRequestDto
    {
        public long CreatorUserId { get; set; }
    }
}

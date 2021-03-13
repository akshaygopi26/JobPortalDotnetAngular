using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Jobs.DTO
{
    public class GetAllJobsInput : PagedResultRequestDto
    {
        public string CompanyName { get; set; }
    }
}

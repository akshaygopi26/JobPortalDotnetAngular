using Abp.Application.Services.Dto;
using JobPortal.ApplicantJobs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.ApplicantJobs
{
   public interface IAppliedJobsAppService
    {

        Task<ListResultDto<AppliedJobListDTO>> GetAll(GetAllAppliedJobsInput input);

        void CreateApplyJob(CreateAppliedJob input);

        Task DeleteJob(DeleteAppliedJobDTO input);
    }
}

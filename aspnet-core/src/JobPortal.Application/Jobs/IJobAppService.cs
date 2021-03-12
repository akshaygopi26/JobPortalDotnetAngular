using Abp.Application.Services.Dto;
using JobPortal.Jobs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Jobs
{
   public interface IJobAppService
    {
        Task<ListResultDto<JobListDTO>> GetAll(GetAllJobsInput input);

        void CreateJob(CreateJobInput input);

        void UpdateJob(UpdateJobInputDTO input);

        Task DeleteJob(DeleteJobInput input);

    }
}

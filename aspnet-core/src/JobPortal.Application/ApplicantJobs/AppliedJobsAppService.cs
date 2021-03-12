using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JobPortal.ApplicantJobs.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.ApplicantJobs
{
    public class AppliedJobsAppService : JobPortalAppServiceBase, IAppliedJobsAppService
    {

        private readonly IRepository<AppliedJobs> _appliedJobsRepository;

        public AppliedJobsAppService(IRepository<AppliedJobs> appliedJobsRepository)
        {
            _appliedJobsRepository = appliedJobsRepository;
        }

       

        public async Task<ListResultDto<AppliedJobListDTO>> GetAll(GetAllAppliedJobsInput input)
        {
            var m = await _appliedJobsRepository.GetAll()
               .Where( t => t.CreatorUserId == input.CreatorUserId)
               .ToListAsync();

            var applied = ObjectMapper.Map<List<AppliedJobListDTO>>(m);
            return new ListResultDto<AppliedJobListDTO>(applied);

        }


        public void CreateApplyJob(CreateAppliedJob input)
        {
            var job = ObjectMapper.Map<AppliedJobs>(input);
            _appliedJobsRepository.Insert(job);
        }

        public async Task DeleteJob(DeleteAppliedJobDTO input)
        {
            await _appliedJobsRepository.DeleteAsync(input.Id);
        }
    }
}

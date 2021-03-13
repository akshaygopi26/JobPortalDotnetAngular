using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using JobPortal.Jobs.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq;

namespace JobPortal.Jobs
{
    public class JobAppService : JobPortalAppServiceBase,IJobAppService
    {

        private readonly IRepository<JobDetails> _jobRepository;

        public JobAppService(IRepository<JobDetails> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<ListResultDto<JobListDTO>> GetAll(GetAllJobsInput input)
        {
            var m = await _jobRepository.GetAll()
                .WhereIf(!input.CompanyName.IsNullOrEmpty(), t => t.CompanyName == input.CompanyName)
                .ToListAsync();

            var jobdto = ObjectMapper.Map<List<JobListDTO>>(m);
            return new ListResultDto<JobListDTO>(jobdto);
        }


        public void CreateJob(CreateJobInput input)
        {    //var job = ObjectMapper.Map<JobDetails>(input);
            var job1 = new JobDetails { CompanyName = input.CompanyName, Position = input.Position, Eligibility = input.Eligibility, SkillsRequired = input.SkillsRequired, MinimumExperienceRequired = input.MinimumExperienceRequired };
            var job2 = ObjectMapper.Map<JobDetails>(input);
            _jobRepository.Insert(job2); 
        }

        public void UpdateJob(UpdateJobInputDTO input)
        {
            var job = _jobRepository.Get(input.Id);
            ObjectMapper.Map(input, job);
        }

        public async Task DeleteJob(DeleteJobInput input)
        {
            await _jobRepository.DeleteAsync(input.Id);
        }

        public PagedResultDto<JobListDTO> GetJobCounts(GetAllJobsInput input)
        {
            var jobrepo = _jobRepository
            .GetAll()
            .WhereIf(
                !input.CompanyName.IsNullOrEmpty(),
                p => p.CompanyName.Contains(input.CompanyName)
            );

            var pagedResult = jobrepo.OrderBy(p => p.CompanyName)
             .Skip(input.SkipCount)
             .Take(input.MaxResultCount)

             .ToList();
            var totalcount = jobrepo.Count();
            var jobmapped = ObjectMapper.Map<List<JobListDTO>>(pagedResult);
            return new PagedResultDto<JobListDTO>(totalcount, jobmapped);
        }


    }
}

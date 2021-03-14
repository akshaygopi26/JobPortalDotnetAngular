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
using JobPortal.ApplicantJobs;

namespace JobPortal.Jobs
{
    public class JobAppService : JobPortalAppServiceBase,IJobAppService
    {

        private readonly IRepository<JobDetails> _jobRepository;

        private readonly IRepository<AppliedJobs> _appliedJobsRepository;


        public JobAppService(IRepository<JobDetails> jobRepository, IRepository<AppliedJobs> appliedJobsRepository)
        {
            _jobRepository = jobRepository;
            _appliedJobsRepository = appliedJobsRepository;
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

        public PagedResultDto<JobListDTO> GetAllPaginatedJobs(GetAllJobsInput input)
        {
            var jobrepo = _jobRepository
            .GetAll()
            .WhereIf(
                !input.CompanyName.IsNullOrEmpty(),
                p => p.CompanyName.Contains(input.CompanyName)
            )
            .WhereIf(input.ExcludeJobsId != null && input.ExcludeJobsId.Count!=0, t => !input.ExcludeJobsId.Contains(t.Id) );
          
            

            var pagedResult = jobrepo.OrderByDescending(p => p.Id)
             .Skip(input.SkipCount)
             .Take(input.MaxResultCount)
             .ToList();
            
            var totalcount = jobrepo.Count();
            var jobmapped = ObjectMapper.Map<List<JobListDTO>>(pagedResult);
            return new PagedResultDto<JobListDTO>(totalcount, jobmapped);
        }

        public PagedResultDto<JobListDTO> GetNotAppliedJobs(GetAllJobsInput input)
        {
            var jobIds = _appliedJobsRepository
            .GetAll()
            .Where(t => t.CreatorUserId == AbpSession.UserId)
            .Select(t => t.JobId)
            .ToList();

            input.ExcludeJobsId = jobIds;

             return GetAllPaginatedJobs(input);

        }




    }
}

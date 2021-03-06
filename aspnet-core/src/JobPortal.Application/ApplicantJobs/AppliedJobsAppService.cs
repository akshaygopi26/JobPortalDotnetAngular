using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using JobPortal.ApplicantJobs.DTO;
using JobPortal.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.ApplicantJobs
{

    [AbpAuthorize(PermissionNames.Pages_Applicants)]
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
               .Select(t =>new AppliedJobListDTO { AppliedJobId = t.Id, CompanyName= t.JobInfo.CompanyName, Position =t.JobInfo.Position , Eligibility=t.JobInfo.Eligibility, SkillsRequired= t.JobInfo.SkillsRequired, MinimumExperienceRequired=t.JobInfo.MinimumExperienceRequired })
               .ToListAsync();


            //var m = await _appliedJobsRepository.GetAll()
            //   .Where(t => t.CreatorUserId == input.CreatorUserId)
            //   .Select(t => new AppliedJobListDTO { t.Id, t.JobInfo.CompanyName, t.JobInfo.Position, t.JobInfo.Eligibility, t.JobInfo.SkillsRequired, t.JobInfo.MinimumExperienceRequired })
            //   .ToListAsync();

            var applied = ObjectMapper.Map<List<AppliedJobListDTO>>(m);
            return new ListResultDto<AppliedJobListDTO>(m);

        }


        [AbpAuthorize(PermissionNames.Pages_Applicants_Jobs_Apply)]
        public void CreateApplyJob(CreateAppliedJob input)
        {
            var m = _appliedJobsRepository.GetAll()
               .WhereIf(AbpSession.UserId != null, t => t.CreatorUserId == AbpSession.UserId)
               .Where(t=> t.JobId ==input.JobId)
               .Count<AppliedJobs>();
            
           // var job;

            if (m >= 1)
            {
                throw new Abp.UI.UserFriendlyException("You have already applied to this job!!");
            }
            else
            {
                var job = ObjectMapper.Map<AppliedJobs>(input);
                _appliedJobsRepository.Insert(job);
            }
            
        }

        [AbpAuthorize(PermissionNames.Pages_Applicants_AppliedJobs_Delete)]
        public async Task DeleteJob(DeleteAppliedJobDTO input)
        {
            await _appliedJobsRepository.DeleteAsync(input.Id);
        }


        [AbpAuthorize(PermissionNames.Pages_Applicants_AppliedJobs_View)]
        public  PagedResultDto<AppliedJobListDTO> GetAppliedJobs(GetAllAppliedJobsInput input)
        {
            var jobAppliedQuery = _appliedJobsRepository
            .GetAll()
            .Where(t => t.CreatorUserId == input.CreatorUserId)
            .Select(t => new AppliedJobListDTO
            {
                AppliedJobId = t.Id,
                CompanyName = t.JobInfo.CompanyName,
                Position = t.JobInfo.Position,
                Eligibility = t.JobInfo.Eligibility,
                SkillsRequired = t.JobInfo.SkillsRequired,
                MinimumExperienceRequired = t.JobInfo.MinimumExperienceRequired
            });
            

            
            var pagedResult = jobAppliedQuery.OrderByDescending(p => p.AppliedJobId)
             .Skip(input.SkipCount)
             .Take(input.MaxResultCount)
             .ToList();


            var totalcount = jobAppliedQuery.Count();
            var jobmapped = ObjectMapper.Map<List<AppliedJobListDTO>>(pagedResult);
            return new PagedResultDto<AppliedJobListDTO>(totalcount, jobmapped);
        }

    }
}

using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using JobPortal.Applicant;
using JobPortal.Models.Recruiters;
using JobPortal.Recruiters.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Recruiters
{
    public class RecruiterAppService : JobPortalAppServiceBase, IRecruiterAppService
    {

        private readonly IRepository<RecruiterDetails> _recruiterRepository;

        private readonly IRepository<ApplicantDetails> _applicantRepository;

        public RecruiterAppService(IRepository<RecruiterDetails> recruiterRepository, IRepository<ApplicantDetails> applicantRepository)
        {
            _recruiterRepository = recruiterRepository;
            _applicantRepository = applicantRepository;
        }

        public  void CreateRecruiter(CreateRecruiterDTO input)
        {
            var m =  _applicantRepository.GetAll()
                .WhereIf(AbpSession.UserId!=null, t => t.CreatorUserId == AbpSession.UserId)
                .Count<ApplicantDetails>();
            if (m >= 1)
            {
                throw new Abp.UI.UserFriendlyException("Already Exists");
            }
            else
            {
                var recruiter = ObjectMapper.Map<RecruiterDetails>(input);
                _recruiterRepository.Insert(recruiter);
            }
        }
    }
}

using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using JobPortal.Applicant.DTO;
using JobPortal.Models.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Applicant
{
    public class ApplicantAppService : JobPortalAppServiceBase, IApplicantAppService
    {

        private readonly IRepository<RecruiterDetails> _recruiterRepository;

        private readonly IRepository<ApplicantDetails> _applicantRepository;

        public ApplicantAppService(IRepository<RecruiterDetails> recruiterRepository, IRepository<ApplicantDetails> applicantRepository = null)
        {
            _recruiterRepository = recruiterRepository;
            _applicantRepository = applicantRepository;
        }


        public void CreateApplicant(CreateApplicantDTO input)
        {
            var m = _recruiterRepository.GetAll()
                .WhereIf(AbpSession.UserId != null, t => t.CreatorUserId == AbpSession.UserId)
                .Count<RecruiterDetails>();
            if (m >= 1)
            {
                throw new Abp.UI.UserFriendlyException("Already Exists");
            }
            else
            {
                var applicant = ObjectMapper.Map<ApplicantDetails>(input);
                _applicantRepository.Insert(applicant);
            }
        }
    }
}

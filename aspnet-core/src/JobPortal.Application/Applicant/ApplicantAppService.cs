using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using JobPortal.Applicant.DTO;
using JobPortal.Authorization;
using JobPortal.Authorization.Roles;
using JobPortal.Authorization.Users;
using JobPortal.Models.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Applicant
{

    //[AbpAuthorize(PermissionNames.Pages_Applicants)]
    public class ApplicantAppService : JobPortalAppServiceBase, IApplicantAppService
    {

        private readonly IRepository<RecruiterDetails> _recruiterRepository;

        private readonly IRepository<ApplicantDetails> _applicantRepository;
        
        private readonly UserManager _userManager;


        private readonly RoleManager _roleManager;

        private readonly IRepository<UserRole, long> _userRolesRepository;

        public ApplicantAppService(IRepository<RecruiterDetails> recruiterRepository, IRepository<ApplicantDetails> applicantRepository = null, UserManager userManager = null, RoleManager roleManager = null, IRepository<UserRole, long> userRolesRepository = null)
        {
            _recruiterRepository = recruiterRepository;
            _applicantRepository = applicantRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRolesRepository = userRolesRepository;
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



        public async void SetRoleApplicant()
        {
            string[] roles = { "APPLICANT" };

            var user = await _userManager.GetUserByIdAsync((int)AbpSession.UserId);
            var _userId = user.Id;
            var _tenantId = AbpSession.TenantId;

            var role = await _roleManager.FindByNameAsync("APPLICANT");


            _userRolesRepository.Insert(new UserRole(_tenantId, _userId, role.Id));


        }
    }
}

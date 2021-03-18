using Abp.Authorization.Users;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using JobPortal.Applicant;
using JobPortal.Authorization.Roles;
using JobPortal.Authorization.Users;
using JobPortal.Models.Recruiters;
using JobPortal.Recruiters.DTO;
using JobPortal.Users.Dto;
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

        private readonly IRepository<UserRole,long> _userRolesRepository;

        private readonly UserManager _userManager;

        private readonly RoleManager _roleManager;

        public RecruiterAppService(IRepository<RecruiterDetails> recruiterRepository, IRepository<ApplicantDetails> applicantRepository, UserManager userManager, IRepository<UserRole, long> userRolesRepository, RoleManager roleManager)
        {
            _recruiterRepository = recruiterRepository;
            _applicantRepository = applicantRepository;
            _userManager = userManager;
            _userRolesRepository = userRolesRepository;
            _roleManager = roleManager;
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

        public async Task SetRole(String input)
        {
           

            var _userId = (int)AbpSession.UserId;
            var _tenantId = AbpSession.TenantId;

            var role = await _roleManager.FindByNameAsync(input);


            _userRolesRepository.InsertAndGetId(new UserRole(_tenantId, _userId, role.Id));
            
        }

        


    }
}

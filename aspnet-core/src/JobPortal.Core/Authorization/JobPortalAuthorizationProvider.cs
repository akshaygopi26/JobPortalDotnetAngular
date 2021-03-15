using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace JobPortal.Authorization
{
    public class JobPortalAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            context.CreatePermission(PermissionNames.Pages_Jobs_View, L("JobsView"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_Recruiters, L("Recruiters"),multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Recruiters_Jobs_View, L("RecruitersJobsView"),multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Recruiters_Jobs_Create, L("RecruitersJobsCreate"),multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Recruiters_Jobs_Edit, L("RecruitersJobsEdit"),multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Recruiters_Jobs_Delete, L("RecruitersJobsDelete"),multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_Applicants, L("Applicant"),multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Applicants_Jobs_View, L("ApplicantJobsView"),multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Applicants_Jobs_Apply, L("ApplicantJobsApply"),multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Applicants_AppliedJobs_View, L("ApplicantAppliedJobsView"),multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Applicants_AppliedJobs_Delete, L("ApplicantAppliedJobsDelete"),multiTenancySides: MultiTenancySides.Tenant);




        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, JobPortalConsts.LocalizationSourceName);
        }
    }
}

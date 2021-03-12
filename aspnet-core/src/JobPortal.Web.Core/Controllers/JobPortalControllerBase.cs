using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Controllers
{
    public abstract class JobPortalControllerBase: AbpController
    {
        protected JobPortalControllerBase()
        {
            LocalizationSourceName = JobPortalConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

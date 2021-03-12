using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JobPortal.EntityFrameworkCore;
using JobPortal.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace JobPortal.Web.Tests
{
    [DependsOn(
        typeof(JobPortalWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class JobPortalWebTestModule : AbpModule
    {
        public JobPortalWebTestModule(JobPortalEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JobPortalWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(JobPortalWebMvcModule).Assembly);
        }
    }
}
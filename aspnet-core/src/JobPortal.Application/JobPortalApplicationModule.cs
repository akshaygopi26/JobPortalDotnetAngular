using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JobPortal.Authorization;

namespace JobPortal
{
    [DependsOn(
        typeof(JobPortalCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class JobPortalApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<JobPortalAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(JobPortalApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

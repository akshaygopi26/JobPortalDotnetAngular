using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JobPortal.Configuration;

namespace JobPortal.Web.Host.Startup
{
    [DependsOn(
       typeof(JobPortalWebCoreModule))]
    public class JobPortalWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public JobPortalWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JobPortalWebHostModule).GetAssembly());
        }
    }
}

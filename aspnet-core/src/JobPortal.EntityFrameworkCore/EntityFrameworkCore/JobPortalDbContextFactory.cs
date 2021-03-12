using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using JobPortal.Configuration;
using JobPortal.Web;

namespace JobPortal.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class JobPortalDbContextFactory : IDesignTimeDbContextFactory<JobPortalDbContext>
    {
        public JobPortalDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<JobPortalDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            JobPortalDbContextConfigurer.Configure(builder, configuration.GetConnectionString(JobPortalConsts.ConnectionStringName));

            return new JobPortalDbContext(builder.Options);
        }
    }
}

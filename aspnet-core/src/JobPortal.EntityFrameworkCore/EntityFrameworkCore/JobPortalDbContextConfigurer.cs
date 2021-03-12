using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.EntityFrameworkCore
{
    public static class JobPortalDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<JobPortalDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<JobPortalDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

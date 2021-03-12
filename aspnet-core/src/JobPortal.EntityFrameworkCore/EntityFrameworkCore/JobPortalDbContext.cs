using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using JobPortal.Authorization.Roles;
using JobPortal.Authorization.Users;
using JobPortal.MultiTenancy;
using JobPortal.Jobs;
using JobPortal.ApplicantJobs;
using JobPortal.Models.Recruiters;
using JobPortal.Applicant;

namespace JobPortal.EntityFrameworkCore
{
    public class JobPortalDbContext : AbpZeroDbContext<Tenant, Role, User, JobPortalDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasOne<RecruiterDetails>(s => s.Recruiter)
                .WithOne(ad => ad.CreatorUser)
                .HasForeignKey<RecruiterDetails>(ad => ad.CreatorUserId);

            modelBuilder.Entity<User>()
                .HasOne<ApplicantDetails>(s => s.Applicant)
                .WithOne(ad => ad.CreatorUser)
                .HasForeignKey<ApplicantDetails>(ad => ad.CreatorUserId);
        }


        public DbSet<JobDetails> JobDetails { get; set; }

        public DbSet<AppliedJobs> AppliedJobs { get; set; }

        public DbSet<RecruiterDetails> RecruiterDetails { get; set; }

        public DbSet<ApplicantDetails> ApplicantDetails { get; set; }

    }
}

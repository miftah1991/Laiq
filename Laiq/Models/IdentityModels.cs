using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Laiq.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DABSConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<LaiqApplicants> LaiqApplicants { get; set; }
        public DbSet<LaiqApplicantEdu> LaiqApplicantEdu { get; set; }
        public DbSet<LaiqApplicantLang> LaiqApplicantLang { get; set; }
        public DbSet<LaiqApplicantSoftSkils> LaiqApplicantSoftSkils { get; set; }
        public DbSet<LaiqApplicantCompSkills> LaiqApplicantCompSkills { get; set; }
        public DbSet<LaiqApplicantUploads> LaiqApplicantUploads { get; set; }
        public DbSet<zYear> zYear { get; set; }
        
        public DbSet<zLangLevel> zLangLevel { get; set; }
        
        public DbSet<Language> Language { get; set; }
        public DbSet<EduField> EduField { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<zQualificationArea> zQualificationArea { get; set; }
        public DbSet<zExpYear> zExpYear { get; set; }
        public DbSet<zExpStaff> zExpStaff { get; set; }
        public DbSet<zExpLevel> zExpLevel { get; set; }
        public DbSet<zComputerSkills> zComputerSkills { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<LaiqQuestionary> LaiqQuestionary { get; set; }
        public DbSet<zCertification> zCertification { get; set; }
        public DbSet<LaiqApplicantCertification> LaiqApplicantCertification { get; set; }
        public DbSet<ApplicantCategory> ApplicantCategory { get; set; }
        public DbSet<ApplicantJobDetail> ApplicantJobDetail { get; set; }
        public DbSet<zDuration> zDuration { get; set; }
        public DbSet<PhoneInterview> PhoneInterview { get; set; }
        public DbSet<PhoneInterviewDetail> PhoneInterviewDetail { get; set; }
        public DbSet<GroupDiscussion> GroupDiscussion { get; set; }
        public DbSet<GroupApplicants> GroupApplicants { get; set; }
        public DbSet<GroupPanel> GroupPanel { get; set; }
        public DbSet<GroupDiscResult> GroupDiscResult { get; set; }
        public DbSet<GroupDisCategory> GroupDisCategory { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public DbSet<PackageApplicants> PackageApplicants { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<ApplicantRecruited> ApplicantRecruited { get; set; }
        

    }
}
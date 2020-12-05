using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VOOQQ_APP.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
            public System.Data.Entity.DbSet<VOOQQ_APP.Models.RazorPayPaymentDetails> RazorPayPaymentDetails { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.M_AgeCategory> M_AgeCategory { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.M_MaritalStatus> M_MaritalStatus { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.M_PhysicalStatus> M_PhysicalStatus { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.M_BodySkinTone> M_BodySkinTone { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.MaritalStatus> MaritalStatus { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.MatrimonyCategory> MatrimonyCategory { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.PlanMasters> PlanMasters { get; set; }
        
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.RCategory> RCategory { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Subject> Subject { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.T_Gender> T_Gender { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.T_QualifiedLevels> T_QualifiedLevels { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.RealEstate> RealEstates { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.R_PostedBy> R_PostedBy { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.R_Bathrooms> R_Bathrooms { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.R_Condition> R_Condition { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.R_Category> R_Category { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.R_Type> R_Type { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.R_Bedrooms> R_Bedrooms { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.R_Direction> R_Direction { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.R_SquareFeet> R_SquareFeet { get; set; }
        //public System.Data.Entity.DbSet<VOOQQ_APP.Models.M_Category> M_Category { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.M_Type> M_Type { get; set; }
        //public System.Data.Entity.DbSet<VOOQQ_APP.Models.Mobiles> Mobiles { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Car> Cars { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Forsale> Forsales { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.BusinessCategory> BusinessCategory { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Business> Business { get; set; }

    
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.PhysicalStatus> PhysicalStatus { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.BodySkinTone> BodySkinTone { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Religion> Religion { get; set; }
       
           public System.Data.Entity.DbSet<VOOQQ_APP.Models.Matrimony> Matrimony { get; set; }

        //public System.Data.Entity.DbSet<VOOQQ_APP.Models.Pet> Pets { get; set; }

        public System.Data.Entity.DbSet<VOOQQ_APP.Models.CabsTaxi> CabsTaxis { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.VehicleCategory> VehicleCategory { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.VehicleType> VehicleType { get; set; }

        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Auditoriums> Auditoriums { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.AuditoriumCategory> AuditoriumCategory { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.AuditoriumType> AuditoriumType { get; set; }

        public System.Data.Entity.DbSet<VOOQQ_APP.Models.DoctorCategory> DoctorCategory { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Doctors> Doctors { get; set; }

        public System.Data.Entity.DbSet<VOOQQ_APP.Models.EducationCategory> EducationCategory { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Education> Educations { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.HotelRoomPropertyType> HotelRoomPropertyType { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.HotelRoomInternetType> HotelRoomInternetType { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.HotelRoomClassType> HotelRoomClassType { get; set; }

        public System.Data.Entity.DbSet<VOOQQ_APP.Models.HotelRooms> HotelRooms { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.JobCategory> JobCategory { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.JobPostedBy> JobPostedBy { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.JobStatus> JobStatus { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.JobLookingfor> JobLookingfor { get; set; }

        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Services> Services { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.ServiceCategory> ServiceCategory { get; set; }

        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Teacher> Teachers { get; set; }

        public System.Data.Entity.DbSet<VOOQQ_APP.Models.RepairMechanic> RepairMechanics { get; set; }

        public System.Data.Entity.DbSet<VOOQQ_APP.Models.Plans> Plans { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.VooqCategory> vooqCategories { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.EducationType> educationTypes { get; set; }
        public System.Data.Entity.DbSet<VOOQQ_APP.Models.T_Availability> t_Availabilities { get; set; }
    }
}
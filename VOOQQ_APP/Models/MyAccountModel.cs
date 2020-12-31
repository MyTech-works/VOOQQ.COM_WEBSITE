using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{

    public class DoctorModel
    {


        public long DoctorId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        public string DoctorCategoryName { get; set; }

        public string Title { get; set; }

        public long DoctorCategoryId { get; set; }

        public string Location { get; set; }
        public long YearsofExperience { get; set; }
        public string Mobile { get; set; }
        public string LandPhone { get; set; }

        public string Email { get; set; }
        public string Description { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public DateTime Date { get; set; }

        public double Views { get; set; }

        public bool Status { get; set; }
        public bool Prime { get; set; }

    }



    public class TeachersModel
    {

        public long TeacherId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }

        public string Title { get; set; }

        public long QualifiedTeachinglevelsId { get; set; }

        public long GenderId { get; set; }

        public long SubjectId { get; set; }

        public string QName { get; set; }
        public string GName { get; set; }
        public string SName { get; set; }


        public string YearsOfExperience { get; set; }
        public string LandPhone { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public DateTime Date { get; set; }

        public double Views { get; set; }

        public bool Status { get; set; }
        public bool Prime { get; set; }

    }


    public class RepairMechanicModel
    {


        public long RepairMechanicId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public long RCategoryId { get; set; }
        public string EducationCategoryName { get; set; }

        public string MobileNumber { get; set; }
        public string LandPhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public DateTime Date { get; set; }
        public double Views { get; set; }
        public bool Status { get; set; }
        public bool Prime { get; set; }
    }
    public class EducationModel
    {
        public long EducationId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }

        public string NameofInstitute { get; set; }
        public string EducationCategoryName { get; set; }

        public long EducationCategoryId { get; set; }

        public string Address { get; set; }

        public string Location { get; set; }
        public string LandPhone { get; set; }
        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string About { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }
        public DateTime Date { get; set; }
        public double Views { get; set; }
        public bool Status { get; set; }
        public bool Prime { get; set; }
    }
    public class AuditoriumModel
    {


        public long AuditoriumId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }

        public string PropertyName { get; set; }

        public long AuditoriumCategoryId { get; set; }
        public string AuditoriumTypeName { get; set; }
        public string AuditoriumCategoryName { get; set; }
        public string Location { get; set; }

        public double Price { get; set; }

        public string SeatingCapacity { get; set; }

        public string DiningCapacity { get; set; }

        public string ParkingCapacity { get; set; }

        public long AuditoriumTypeId { get; set; }

        public string MobileNumber { get; set; }

        public string LandPhone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string About { get; set; }


        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }
        public DateTime Date { get; set; }
        public double Views { get; set; }
        public bool Status { get; set; }
        public bool Prime { get; set; }
    }

    public class CarsTaxiModel
    {

        public long CabTaxiId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public long VehicleCategoryId { get; set; }
        public long VehicleTypeId { get; set; }
        public string VehicleTypes { get; set; }
        public string VehicleCategoryName { get; set; }
        public string Location { get; set; }
        public long DriverAge { get; set; }
        public long YearofExperience { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleModelName { get; set; }
        public long VehicleYear { get; set; }
        public long SeatingCapacity { get; set; }
        public long MinimumCharge { get; set; }
        public long MobileNumber { get; set; }
        public long LandPhone { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public DateTime Date { get; set; }
        public double Views { get; set; }
        public bool Status { get; set; }
        public bool Prime { get; set; }
    }
    public class HotelRoomsModel
    {


        public long HotelRoomId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string Location { get; set; }

        public long PropertyTypeId { get; set; }


        public long ClassId { get; set; }

        public string CheckIn { get; set; }

        public string CheckOut { get; set; }

        public string PropertyTypeName { get; set; }
        public string ClassTypeName { get; set; }
        public string HotelRoomInternetTypes { get; set; }

        public long InternetTypeID { get; set; }

        public bool IsParking { get; set; }

        public string InternetTypeName { get; set; }
        public bool IsBreakfast { get; set; }

        public bool IsEscalator { get; set; }

        public bool IsRoomService { get; set; }

        public bool IsRestaurant { get; set; }

        public bool IsBar { get; set; }

        public bool IsSpaMassage { get; set; }

        public bool IsSwimmingPool { get; set; }

        public double Price { get; set; }

        public string LandPhone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }
        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public DateTime Date { get; set; }

        public double Views { get; set; }

        public bool Status { get; set; }
        public bool Prime { get; set; }
    }

    public class ServiceModel
    {

        public long ServiceId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        public string Tiltle { get; set; }
        public long ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public string Location { get; set; }
        public string YearofExperience { get; set; }
        public string MobileNumber { get; set; }
        public string LandPhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public DateTime Date { get; set; }

        public double Views { get; set; }

        public bool Status { get; set; }
        public bool Prime { get; set; }
    }


    public class ForsaleModels
    {
        [Key]
        public long ForsaleId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Category")]
        public long CategoryId { get; set; }
        [Required]
        [Display(Name = "Type")]
        public long TypeId { get; set; }
        [Required]
        [Display(Name = "Condition")]
        public long ConditionId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [Display(Name = "About")]
        public string Description { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        [Required]
        public string Location { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public DateTime Date { get; set; }

        public double Views { get; set; }

        public bool Status { get; set; }
        public bool Prime { get; set; }
    }

    public class JobModels
    {
       
    public long JobId { get; set; }
    public long VId { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    
    public long JobCategoryId { get; set; }
    public double Salary { get; set; }
        
    public long PostedById { get; set; }
        public string JobStatusName { get; set; }
        public long StatusId { get; set; }
        public string JobLookingforName { get; set; }
        public long LookingforId { get; set; }
        public string MobileNumber { get; set; }
        public string JobCategoryName  { get; set; }
        public string JobPostedByName { get; set; }
        
    public string LandPhone { get; set; }
   
    public string Email { get; set; }
   
    public string Description { get; set; }
    
    public string Location { get; set; }
        public bool Prime { get; set; }
        public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
    public DateTime Date { get; set; }

    public double Views { get; set; }

    public bool Status { get; set; }
}
    public class MyAccountModel
    {
       
       
        public string BusinessId { get; set; }
        public string VId { get; set; }
        public string Title { get; set; }
        public string BusinessCategoryId { get; set; }
        public string Description { get; set; }
        public string Mobile { get; set; }
        public string Location { get; set; }
        public string Image1 { get; set; }
        public string UserId { get; set; }
        public string status { get; set; }
         public bool Prime  { get; set; }

    }
    public class MyAccountModelcount
    {


        public string BusinessId { get; set; }
        public string VId { get; set; }
        public string Title { get; set; }
        public string BusinessCategoryId { get; set; }
        public string Description { get; set; }
        public string Mobile { get; set; }
        public string Location { get; set; }
        public string Image1 { get; set; }
        public string UserId { get; set; }
        public string views { get; set; }
        public string status { get; set; }

    }
    public class MyAccountModel1
    {
        
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
      


    }
    public class BusinessModel
    {
        public long BusinessId { get; set; }
        public long VId { get; set; }
        public string Title { get; set; }
        public long BusinessCategoryId { get; set; }
        public string Description { get; set; }
        public string Mobile { get; set; }
        public string Location { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public DateTime Date { get; set; }
        public double Views { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
        public string LandPhone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string BusinessCategoryName { get; set; }
        public bool Prime { get; set; }
    }
    public class MatrimoniesModel
    {
        public long MatrimonyId { get; set; }
        public long VId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long MatrimonyCategoryId { get; set; }
        public long M_AgeCategoryId { get; set; }
        public long M_MaritalStatusId { get; set; }
        public long M_PhysicalStatusId { get; set; }
        public long M_BodySkinToneId { get; set; }
        public long ReligionId { get; set; }
        public string M_AgeCategoryName { get; set; }
        public string M_PhysicalStatusName { get; set; }
        public string M_MaritalStatusName { get; set; }
        public string MatrimonyCategoryName { get; set; }
        public string Name { get; set; }
        public string M_BodySkinToneName { get; set; }
        public string ReligionName { get; set; }
        public string Community { get; set; }
        public string SubCommunity { get; set; }
        public string Nakshatra { get; set; }
        public string Job { get; set; }
        public string Qualification { get; set; }
        public string Languages { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string LandPhone { get; set; }
        public string Mobile { get; set; }
        public string Location { get; set; }
        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public DateTime Date { get; set; }

        public double Views { get; set; }

        public bool Status { get; set; }
        public bool Prime { get; set; }
    }
}
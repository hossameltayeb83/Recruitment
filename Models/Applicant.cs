using Recruitment.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.Models
{
    public class Applicant
    {
        public decimal Id { get; set; }
        public bool IsDoctor { get; set; }
        public decimal? ErpDepartmentPositionID { get; set; }

        [Spaces(1, ErrorMessage = "Many Spaces")]
        [StringLength(20, ErrorMessage = "The name exceeds the maximum allowed length.")]
        [Required(ErrorMessage = "First Name is Required")]
        [RegularExpression(@"^[\p{L} ]+$", ErrorMessage = "The input can only contain letters")]
        public string FirstName { get; set; }

        [Spaces(1, ErrorMessage = "Many Spaces")]
        [StringLength(20, ErrorMessage = "The name exceeds the maximum allowed length.")]
        [RegularExpression(@"^[\p{L} ]+$", ErrorMessage = "The input can only contain letters")]
        [Required(ErrorMessage = "Second Name is Required")]
        public string SecondName { get; set; }

        [Spaces(1, ErrorMessage = "Many Spaces")]
        [StringLength(20, ErrorMessage = "The name exceeds the maximum allowed length.")]
        [Required(ErrorMessage = "Third Name is Required")]
        [RegularExpression(@"^[\p{L} ]+$", ErrorMessage = "The input can only contain letters")]
        public string ThirdName { get; set; }

        [Spaces(1, ErrorMessage = "Many Spaces")]
        [StringLength(20, ErrorMessage = "The Title exceeds the maximum allowed length.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public decimal? GenderID { get; set; }

        [NotAllowFutureDate(ErrorMessage = "Future date is not allowed")]
        [MinimumAge(15, ErrorMessage = "You must be older than 15 years old to apply.")]
        [Required(ErrorMessage = "Birth date is Required")]
        public DateTime? BirthDate { get; set; }
        
        [StringLength(20, ErrorMessage = "The Phone exceeds the maximum allowed length.")]
        //[RegularExpression(@"^[0-9]+$", ErrorMessage = "NumbersOnly")]
        [RegularExpression(@"^\d{11,}$", ErrorMessage = "Phone number must contain only numbers and be at least 11 digits long.")]
        [Required(ErrorMessage = "Phonen number is Required")]
        public string PhoneNumber { get; set; }

        [StringLength(200, ErrorMessage = "The Address exceeds the maximum allowed length.")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Area is Required")]
        public decimal? ErpAreaCityID { get; set; }

        [StringLength(254, ErrorMessage = "The email address exceeds the maximum allowed length of 254 characters.")]
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
        //[EmailAddress] 
        public string Email { get; set; }

        [Required(ErrorMessage = "Martial status is Required")]
        public decimal? ErpMartialStatusID { get; set; }

        [Required(ErrorMessage = "Militry status is Required")]
        public decimal? ErpMilitryStatusID { get; set; }
        
        public string CV { get; set; }

        [Required(ErrorMessage = "GraduationYear is Required")]
        [CustomYearRange(1980, ErrorMessage = "Graduation Year must be between 1980 and the current year.")]
        public int? GraduationYear { get; set; }
        
        [Required(ErrorMessage = "University is Required")]
        public decimal? ErpUniversityID { get; set; }

        [Required(ErrorMessage = "Doctor degree is Required")]
        public decimal? ErpDoctorDegreeID { get; set; }

        [Required(ErrorMessage = "Branch is Required")]
        public decimal? ErpBranchID { get; set; }

        [Required(ErrorMessage = "Specialty is Required")]
        public decimal? ErpSpecialtyID { get; set; }
        
        public decimal? ErpOtherSpecialtyID { get; set; }
        
        public DateTime? DoctorDegreeDate { get; set; }

        public string ApplicantNotes { get; set; }
        
        public bool IsNew { get; set; }
        
        public bool SentToErp { get; set; }
    }
}

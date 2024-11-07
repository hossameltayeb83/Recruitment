using Recruitment.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.Models
{
    public class Applicant
    {
        public decimal Id { get; set; }
        public bool IsDoctor { get; set; }
        public decimal? ErpDepartmentPositionID { get; set; }

        [Spaces(1, ErrorMessage = "ManySpaces")]
        [StringLength(20, ErrorMessage = "RecruitmentStringLength")]
        [Required(ErrorMessage = "First Name is Required")]
        [RegularExpression(@"^[\p{L}\p{N} ]+$", ErrorMessage = "LettersOrNumbersOnly")]
        public string FirstName { get; set; }

        [Spaces(1, ErrorMessage = "ManySpaces")]
        [StringLength(20, ErrorMessage = "RecruitmentStringLength")]
        [RegularExpression(@"^[\p{L}\p{N} ]+$", ErrorMessage = "LettersOrNumbersOnly")]
        [Required(ErrorMessage = "Second Name is Required")]
        public string SecondName { get; set; }

        [Spaces(1, ErrorMessage = "ManySpaces")]
        [StringLength(20, ErrorMessage = "RecruitmentStringLength")]
        [Required(ErrorMessage = "Third Name is Required")]
        [RegularExpression(@"^[\p{L}\p{N} ]+$", ErrorMessage = "LettersOrNumbersOnly")]
        public string ThirdName { get; set; }

        [Spaces(1, ErrorMessage = "ManySpaces")]
        [StringLength(20, ErrorMessage = "RecruitmentStringLength")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public decimal? GenderID { get; set; }

        [NotAllowFutureDate(ErrorMessage = "FutureDate")]
        [MinimumAge(15, ErrorMessage = "RecruitmentAgeLimit")]
        [Required(ErrorMessage = "Birth date is Required")]
        public DateTime? BirthDate { get; set; }
        
        [StringLength(20, ErrorMessage = "RecruitmentStringLength")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "NumbersOnly")]
        [Required(ErrorMessage = "Phonen number is Required")]
        public string PhoneNumber { get; set; }

        [StringLength(200, ErrorMessage = "AddressStringLength")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Area is Required")]
        public decimal? ErpAreaCityID { get; set; }

        [StringLength(200, ErrorMessage = "EmailStringLength")]
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress] 
        public string Email { get; set; }

        [Required(ErrorMessage = "Martial status is Required")]
        public decimal? ErpMartialStatusID { get; set; }

        [Required(ErrorMessage = "Militry status is Required")]
        public decimal? ErpMilitryStatusID { get; set; }
        
        public string CV { get; set; }

        [Display(Name = "YearOfGraduation")]
        [Required(ErrorMessage = "GraduationYear is Required")]
        [Range(1900, 2100, ErrorMessage = "GraduationYear")]
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

        [Display(Name = "Experience")]
        public string ApplicantNotes { get; set; }
        
        public bool IsNew { get; set; }
        
        public bool SentToErp { get; set; }
    }
}

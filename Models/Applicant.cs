using Recruitment.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.Models
{
    public class Applicant
    {
        [Key]
        public decimal ApiApplicantId { get; set; }

        public bool IsDoctor { get; set; }

        public decimal? ErpDepartmentPositionID { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string? Title { get; set; }

        public decimal? GenderID { get; set; }

        public DateTime? BirthDate { get; set; }
        
        public string PhoneNumber { get; set; }

        public string? Address { get; set; }

        public decimal? ErpAreaCityID { get; set; }

        public string? Email { get; set; }

        public decimal? ErpMartialStatusID { get; set; }

        public decimal? ErpMilitryStatusID { get; set; }
        
        public string? CV { get; set; }

        public int? GraduationYear { get; set; }
        
        public decimal? ErpUniversityID { get; set; }

        public decimal? ErpDoctorDegreeID { get; set; }

        public decimal? ErpBranchID { get; set; }

        public decimal? ErpSpecialtyID { get; set; }
        
        public decimal? ErpOtherSpecialtyID { get; set; }
        
        public DateTime? DoctorDegreeDate { get; set; }

        public string? ApplicantNotes { get; set; }
        
        public bool SentToErp { get; set; }
    }
}

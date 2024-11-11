using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recruitment.Attributes;
using Recruitment.Dtos;
using Recruitment.Helper;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.Models
{
    public class Applicant
    {
        public Applicant()
        {
            
        }
        public Applicant(ApplicantDto Dto)
        {
            ApiApplicantId = Dto.ApiApplicantId;
            IsDoctor=Dto.IsDoctor;
            ErpDepartmentPositionID=Dto.ErpDepartmentPositionID;
            FirstName = Dto.FirstName;
            SecondName = Dto.SecondName;
            ThirdName = Dto.ThirdName;
            Title = Dto.Title;
            GenderID = Dto.GenderID;
            BirthDate = Dto.BirthDate;
            PhoneNumber = Dto.PhoneNumber;
            Address = Dto.Address;
            ErpAreaCityID = Dto.ErpAreaCityID;
            Email =Dto.Email;
            ErpMartialStatusID = Dto.ErpMartialStatusID;
            ErpMilitryStatusID =Dto.ErpMilitryStatusID;
            CvFileName =Dto.CvFileName;
            CV =Dto.CV;
            GraduationYear = Dto.GraduationYear;
            ErpUniversityID = Dto.ErpUniversityID;
            ErpDoctorDegreeID = Dto.ErpDoctorDegreeID;
            ErpBranchID = Dto.ErpBranchID;
            ErpSpecialtyID = Dto.ErpSpecialtyID;
            ErpOtherSpecialtyID = Dto.ErpOtherSpecialtyID;
            DoctorDegreeDate = Dto.DoctorDegreeDate;
            ApplicantNotes = Dto.ApplicantNotes;
            SentToErp = false;
        }
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
        
        public string? CvFileName { get; set; }
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

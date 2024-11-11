using Recruitment.Attributes;
using Recruitment.Localization;
using System.ComponentModel.DataAnnotations;
using Recruitment.Models;

namespace Recruitment.Dtos
{
    
    public class ApplicantDto
    {
        public ApplicantDto()
        {
            
        }
        public ApplicantDto(Applicant applicant)
        {
            ApiApplicantId = applicant.ApiApplicantId;
            IsDoctor = applicant.IsDoctor;
            ErpDepartmentPositionID = applicant.ErpDepartmentPositionID;
            FirstName = applicant.FirstName;
            SecondName = applicant.SecondName;
            ThirdName = applicant.ThirdName;
            Title = applicant.Title;
            GenderID = applicant.GenderID;
            BirthDate = applicant.BirthDate;
            PhoneNumber = applicant.PhoneNumber;
            Address = applicant.Address;
            ErpAreaCityID = applicant.ErpAreaCityID;
            Email = applicant.Email;
            ErpMartialStatusID = applicant.ErpMartialStatusID;
            ErpMilitryStatusID = applicant.ErpMilitryStatusID;
            CvFileName = applicant.CvFileName;
            CV = applicant.CV;
            GraduationYear = applicant.GraduationYear;
            ErpUniversityID = applicant.ErpUniversityID;
            ErpDoctorDegreeID = applicant.ErpDoctorDegreeID;
            ErpBranchID = applicant.ErpBranchID;
            ErpSpecialtyID = applicant.ErpSpecialtyID;
            ErpOtherSpecialtyID = applicant.ErpOtherSpecialtyID;
            DoctorDegreeDate = applicant.DoctorDegreeDate;
            ApplicantNotes = applicant.ApplicantNotes;
        }
        public decimal ApiApplicantId { get; set; }
        public bool IsDoctor { get; set; }
        public decimal? ErpDepartmentPositionID { get; set; }

        [LocalizedCustomValidation.Spaces(1, "SpacesError")]
        [LocalizedCustomValidation.LocalizedStringLength(20, "MaxLegnthError")]
        [LocalizedCustomValidation.LocalizedRequired("Required")]
        [LocalizedCustomValidation.LocalizedRegularExpression(@"^[\p{L} ]+$", "LettersError")]
        public string FirstName { get; set; }

        [LocalizedCustomValidation.Spaces(1, "SpacesError")]
        [LocalizedCustomValidation.LocalizedStringLength(20, "MaxLegnthError")]
        [LocalizedCustomValidation.LocalizedRequired("Required")]
        [LocalizedCustomValidation.LocalizedRegularExpression(@"^[\p{L} ]+$", "LettersError")]
        public string SecondName { get; set; }

        [LocalizedCustomValidation.Spaces(1, "SpacesError")]
        [LocalizedCustomValidation.LocalizedStringLength(20, "MaxLegnthError")]
        [LocalizedCustomValidation.LocalizedRequired("Required")]
        [LocalizedCustomValidation.LocalizedRegularExpression(@"^[\p{L} ]+$", "LettersError")]
        public string ThirdName { get; set; }

        [LocalizedCustomValidation.Spaces(1, "SpacesError")]
        [LocalizedCustomValidation.LocalizedStringLength(20, "MaxLegnthError")]
        public string Title { get; set; }

        [LocalizedCustomValidation.LocalizedRequired("Required")]
        public decimal? GenderID { get; set; }

        [LocalizedCustomValidation.NotAllowFutureDate("FutureError")]
        [LocalizedCustomValidation.MinimumAge(15, "AgeError")]
        [LocalizedCustomValidation.LocalizedRequired("Required")]
        public DateTime? BirthDate { get; set; }

        [LocalizedCustomValidation.LocalizedStringLength(20, "MaxLegnthError")]
        [LocalizedCustomValidation.LocalizedRegularExpression(@"^\d{11,}$", "PhoneNumberError")]
        [LocalizedCustomValidation.LocalizedRequired("Required")]
        public string PhoneNumber { get; set; }

        [LocalizedCustomValidation.LocalizedStringLength(200, "MaxLegnthError")]
        [LocalizedCustomValidation.LocalizedRequired("Required")]
        public string Address { get; set; }

        [LocalizedCustomValidation.LocalizedRequired("Required")]
        public decimal? ErpAreaCityID { get; set; }

        [LocalizedCustomValidation.LocalizedStringLength(254, "MaxLegnthError")]
        [LocalizedCustomValidation.LocalizedRequired("Required")]
        [LocalizedCustomValidation.LocalizedRegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", "EmailError")]
        public string Email { get; set; }

        [LocalizedCustomValidation.LocalizedRequired("Required")]
        public decimal? ErpMartialStatusID { get; set; }

        [LocalizedCustomValidation.LocalizedRequired("Required")]
        public decimal? ErpMilitryStatusID { get; set; }
        public string CvFileName { get; set; }
        public string CV { get; set; }

        [LocalizedCustomValidation.LocalizedRequired("Required")]
        [LocalizedCustomValidation.CustomYearRange(1980, "GraduationYearError")]
        public int? GraduationYear { get; set; }

        [LocalizedCustomValidation.LocalizedRequired("Required")]
        public decimal? ErpUniversityID { get; set; }

        [LocalizedCustomValidation.LocalizedRequired("Required")]
        public decimal? ErpDoctorDegreeID { get; set; }

        [LocalizedCustomValidation.LocalizedRequired("Required")]
        public decimal? ErpBranchID { get; set; }

        [LocalizedCustomValidation.LocalizedRequired("Required")]
        public decimal? ErpSpecialtyID { get; set; }

        public decimal? ErpOtherSpecialtyID { get; set; }

        public DateTime? DoctorDegreeDate { get; set; }

        public string ApplicantNotes { get; set; }
    }
}

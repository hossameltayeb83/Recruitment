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
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Title { get; set; }
        public decimal? GenderID { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal? ErpAreaCityID { get; set; }
        public string Email { get; set; }
        public decimal? ErpMartialStatusID { get; set; }
        public decimal? ErpMilitryStatusID { get; set; }
        public string CvFileName { get; set; }
        public string CV { get; set; }
        public int? GraduationYear { get; set; }
        public decimal? ErpUniversityID { get; set; }
        public decimal? ErpDoctorDegreeID { get; set; }
        public decimal? ErpBranchID { get; set; }
        public decimal? ErpSpecialtyID { get; set; }
        public decimal? ErpOtherSpecialtyID { get; set; }
        public DateTime? DoctorDegreeDate { get; set; }
        public string ApplicantNotes { get; set; }
    }
}

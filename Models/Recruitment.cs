using Recruitment.Dtos;
using Recruitment.Enums;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.Models
{
    public class Recruitment
    {
        public Recruitment()
        {
            
        }
        public Recruitment(RecruitmentDto dto)
        {
            ErpDepartmentPositionID = dto.ErpDepartmentPositionID;
            ErpEmployeeCategoryID= dto.ErpEmployeeCategoryID;
            PositionName = dto.PositionName;
            PositionSummary = dto.PositionSummary;
            PositionDetails = dto.PositionDetails;
            PositionRequirements = dto.PositionRequirements;
            OrganizationName = dto.OrganizationName;
            OrganizationVision = dto.OrganizationVision;
            OrganizationMission = dto.OrganizationMission;
            LinkExpiryDate = dto.LinkExpiryDate;
        }
        [Key]
        public decimal ErpDepartmentPositionID { get; set; }
        public decimal ErpEmployeeCategoryID { get; set; }
        public string PositionName { get; set; }
        public string? PositionSummary { get; set; }
        public string? PositionDetails { get; set; }
        public string? PositionRequirements { get; set; }
        public string OrganizationName { get; set; }
        public string? OrganizationVision { get; set; }
        public string? OrganizationMission { get; set; }
        public DateTime LinkExpiryDate { get; set; }
    }
}

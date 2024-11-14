using Recruitment.Enums;

namespace Recruitment.Dtos
{
    public class PositionDto
    {
        public EventType EventType { get; set; }
        public decimal ErpDepartmentPositionID { get; set; }
        public decimal ErpEmployeeCategoryID { get; set; }
        public string EmployeeCategoryName { get; set; }
        public bool IsDoctor { get; set; }
        public string PositionName { get; set; }
        public string PositionSummary { get; set; }
        public string PositionDetails { get; set; }
        public string PositionRequirements { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationVision { get; set; }
        public string OrganizationMission { get; set; }
        public DateTime LinkExpiryDate { get; set; }
    }
}

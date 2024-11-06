﻿using Recruitment.Enums;

namespace Recruitment.Dtos
{
    public class RecruitmentDto
    {
        public EventType EventType { get; set; }
        public decimal DepartmentPositionID { get; set; }
        public decimal EmployeeCategoryID { get; set; }
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
﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruitment.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApiApplicantId = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDoctor = table.Column<bool>(type: "INTEGER", nullable: false),
                    ErpDepartmentPositionID = table.Column<decimal>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    SecondName = table.Column<string>(type: "TEXT", nullable: false),
                    ThirdName = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    GenderID = table.Column<decimal>(type: "TEXT", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    ErpAreaCityID = table.Column<decimal>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    ErpMartialStatusID = table.Column<decimal>(type: "TEXT", nullable: true),
                    ErpMilitryStatusID = table.Column<decimal>(type: "TEXT", nullable: true),
                    CvFileName = table.Column<string>(type: "TEXT", nullable: true),
                    CV = table.Column<string>(type: "TEXT", nullable: true),
                    GraduationYear = table.Column<int>(type: "INTEGER", nullable: true),
                    ErpUniversityID = table.Column<decimal>(type: "TEXT", nullable: true),
                    ErpDoctorDegreeID = table.Column<decimal>(type: "TEXT", nullable: true),
                    ErpBranchID = table.Column<decimal>(type: "TEXT", nullable: true),
                    ErpSpecialtyID = table.Column<decimal>(type: "TEXT", nullable: true),
                    ErpOtherSpecialtyID = table.Column<decimal>(type: "TEXT", nullable: true),
                    DoctorDegreeDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ApplicantNotes = table.Column<string>(type: "TEXT", nullable: true),
                    SentToErp = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApiApplicantId);
                });

            migrationBuilder.CreateTable(
                name: "AreaCities",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValueAr = table.Column<string>(type: "TEXT", nullable: true),
                    ValueEn = table.Column<string>(type: "TEXT", nullable: true),
                    HasParent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValueAr = table.Column<string>(type: "TEXT", nullable: true),
                    ValueEn = table.Column<string>(type: "TEXT", nullable: true),
                    HasParent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorDegrees",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValueAr = table.Column<string>(type: "TEXT", nullable: true),
                    ValueEn = table.Column<string>(type: "TEXT", nullable: true),
                    HasParent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDegrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValueAr = table.Column<string>(type: "TEXT", nullable: true),
                    ValueEn = table.Column<string>(type: "TEXT", nullable: true),
                    HasParent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MartialStatuses",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValueAr = table.Column<string>(type: "TEXT", nullable: true),
                    ValueEn = table.Column<string>(type: "TEXT", nullable: true),
                    HasParent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MartialStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryStatuses",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValueAr = table.Column<string>(type: "TEXT", nullable: true),
                    ValueEn = table.Column<string>(type: "TEXT", nullable: true),
                    HasParent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recruitments",
                columns: table => new
                {
                    ErpDepartmentPositionID = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDoctor = table.Column<bool>(type: "INTEGER", nullable: false),
                    PositionName = table.Column<string>(type: "TEXT", nullable: false),
                    PositionSummary = table.Column<string>(type: "TEXT", nullable: true),
                    PositionDetails = table.Column<string>(type: "TEXT", nullable: true),
                    PositionRequirements = table.Column<string>(type: "TEXT", nullable: true),
                    OrganizationName = table.Column<string>(type: "TEXT", nullable: false),
                    OrganizationVision = table.Column<string>(type: "TEXT", nullable: true),
                    OrganizationMission = table.Column<string>(type: "TEXT", nullable: true),
                    LinkExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruitments", x => x.ErpDepartmentPositionID);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValueAr = table.Column<string>(type: "TEXT", nullable: true),
                    ValueEn = table.Column<string>(type: "TEXT", nullable: true),
                    HasParent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValueAr = table.Column<string>(type: "TEXT", nullable: true),
                    ValueEn = table.Column<string>(type: "TEXT", nullable: true),
                    HasParent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "AreaCities");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "DoctorDegrees");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "MartialStatuses");

            migrationBuilder.DropTable(
                name: "MilitaryStatuses");

            migrationBuilder.DropTable(
                name: "Recruitments");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
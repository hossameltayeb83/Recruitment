﻿using Microsoft.EntityFrameworkCore;
using Recruitment.Data;
using Recruitment.Dtos;
using Recruitment.Enums;
using System.Security.Cryptography;

namespace Recruitment.Services
{
    public class RecruitmentService : IRecruitmentService
    {

        public List<Models.Recruitment> dtos = new List<Models.Recruitment>
        {
            new Models.Recruitment
            {
                ErpDepartmentPositionID = 101,
                IsDoctor = true,
                PositionName = "Software Engineer",
                PositionSummary = "Develop and maintain software applications.",
                PositionDetails = "Design, implement, and test software solutions, ensure code quality.",
                PositionRequirements = "Bachelor's degree in Computer Science or related field. 3+ years of experience in software development.",
                OrganizationName = "Tech Solutions Inc.",
                OrganizationVision = "Innovating for the future with cutting-edge technology.",
                OrganizationMission = "To provide reliable and scalable software solutions to businesses.",
                LinkExpiryDate = DateTime.Now.AddMonths(1)
            },
            new Models.Recruitment
            {
                ErpDepartmentPositionID = 638003011108621225.57196928M,
                IsDoctor = true,
                PositionName = "Product Manager",
                PositionSummary = "Lead product development teams, drive the product roadmap.",
                PositionDetails = "Work with cross-functional teams to develop product strategies, define features, and deliver products.",
                PositionRequirements = "Master's degree in Business Administration or related field. 5+ years of product management experience.",
                OrganizationName = "Creative Solutions Ltd.",
                OrganizationVision = "Empowering businesses to grow through innovative products.",
                OrganizationMission = "Creating products that solve real-world problems.",
                LinkExpiryDate = DateTime.Now.AddMonths(2)
            },
            new Models.Recruitment
            {
                ErpDepartmentPositionID = 635430293896600369.96598774M,
                IsDoctor = true,
                PositionName = "Senior Software Engineer",
                PositionSummary = "Lead technical teams and mentor junior engineers.",
                PositionDetails = "Lead design and development efforts for complex projects. Provide technical leadership and mentoring.",
                PositionRequirements = "5+ years of experience in software development with a proven track record of leadership.",
                OrganizationName = "Tech Solutions Inc.",
                OrganizationVision = "Innovating for the future with cutting-edge technology.",
                OrganizationMission = "To provide reliable and scalable software solutions to businesses.",
                LinkExpiryDate = DateTime.Now.AddMonths(3)
            },
            new Models.Recruitment
            {
                ErpDepartmentPositionID = 103,
                IsDoctor = true,
                PositionName = "Sales Manager",
                PositionSummary = "Manage sales operations and drive revenue growth.",
                PositionDetails = "Develop and implement sales strategies, oversee sales teams, and manage client relationships.",
                PositionRequirements = "Bachelor's degree in Business Administration. 4+ years in sales management.",
                OrganizationName = "Global Enterprises",
                OrganizationVision = "Connecting businesses with the right customers worldwide.",
                OrganizationMission = "Helping companies grow by providing innovative sales solutions.",
                LinkExpiryDate = DateTime.Now.AddMonths(1)
            }
        };
        private readonly ApplicationDbContext _context;
        public RecruitmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal? ExtractPositionDepartmentFromLink(string link)
        {
            return null;
        }

        //public async Task<RecruitmentDto> GetRecruitmentFromLinkAsync(string link)
        //{
        //    decimal.TryParse(link, out var departmentPositionID);
        //    return await Task.FromResult(dtos.FirstOrDefault(e => e.ErpDepartmentPositionID == departmentPositionID));
        //}



        public async Task<List<decimal>> GetRecruitmentIds()
        {
           return await _context.Recruitments.Select(e => e.ErpDepartmentPositionID).ToListAsync();
        }

        public async Task<Models.Recruitment> GetRecruitmentFromLinkAsync(string link)
        {
            var stringLink = DecryptGeneric(link);
            decimal.TryParse(stringLink, out var departmentPositionID);
            var x = await _context.Recruitments.ToListAsync();
            return _context.Recruitments.FirstOrDefault(e => e.ErpDepartmentPositionID == departmentPositionID);
        }
        public async Task HandleRecruitmentsSentFromErp(List<RecruitmentDto> recruitments)
        {
            foreach (var dto in recruitments)
            {
                if (dto.EventType == EventType.Added)
                {
                    var recruitmentToAdd = new Models.Recruitment(dto);
                    _context.Recruitments.Add(recruitmentToAdd);
                }
                else
                {
                    var recruitmentToModify = await _context.Recruitments.FindAsync(dto.ErpDepartmentPositionID);
                    if (recruitmentToModify != null)
                    {
                        if (dto.EventType == EventType.Modified)
                        {
                            //recruitmentToModify
                            _context.Recruitments.Update(recruitmentToModify);
                        }
                        if (dto.EventType == EventType.Deleted)
                        {
                            _context.Recruitments.Remove(recruitmentToModify);
                        }
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        internal static string DecryptGeneric(string Message)
        {
            return DecryptString(Message, "SystemCZ310");
        }

        internal static string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

    }
}

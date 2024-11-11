using Microsoft.EntityFrameworkCore;
using Recruitment.Data;
using Recruitment.Dtos;
using Recruitment.Enums;
using System.Security.Cryptography;

namespace Recruitment.Services
{
    public class RecruitmentService : IRecruitmentService
    {

        private readonly ApplicationDbContext _context;
        public RecruitmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal? ExtractPositionDepartmentFromLink(string link)
        {
            return null;
        }

        public async Task<List<decimal>> GetRecruitmentIds()
        {
           return await _context.Recruitments.Select(e => e.ErpDepartmentPositionID).ToListAsync();
        }

        public async Task<Models.Recruitment> GetRecruitmentFromLinkAsync(string link)
        {
            var stringLink = DecryptGeneric(link);
            decimal.TryParse(stringLink, out var departmentPositionID);
            var v = await _context.Recruitments.ToListAsync();
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
                    else
                    {
                        if (dto.EventType == EventType.Modified)
                        {
                            var recruitmentToAdd = new Models.Recruitment(dto);
                            _context.Recruitments.Add(recruitmentToAdd);
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

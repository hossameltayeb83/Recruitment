using Microsoft.EntityFrameworkCore;
using Recruitment.Data;
using Recruitment.Dtos;
using Recruitment.Helper;
using Recruitment.Models;

namespace Recruitment.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly ApplicationDbContext _context;
        public ApplicantService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task ChangeSentToErp(List<decimal> ids)
        {
           var applicants= await _context.Applicants.Where(e => ids.Contains(e.ApiApplicantId)).ToListAsync();
           foreach(var applicant in applicants)
           {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CVs", applicant.CvFileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                applicant.SentToErp = true;
           }
           await _context.SaveChangesAsync();
        }

        public async Task<List<ApplicantDto>> GetAllApplicants()
        {
            var applicants=await _context.Applicants.Where(e => e.SentToErp==false).ToListAsync();
            List<ApplicantDto> result=new();
            foreach(var applicant in applicants)
            {
                if (applicant.CvFileName != null)
                {
                    var path= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CVs", applicant.CvFileName);
                    if (File.Exists(path))
                    {
                        var pdf= File.ReadAllBytes(path);
                        applicant.CV = Convert.ToBase64String(pdf);
                    }
                    result.Add(new ApplicantDto(applicant));
                }
            }
            return result;
        }

        public decimal GetNewId()
        {
            return DecimalHelper.NewID();
        }

        public async Task SaveApplicant(ApplicantDto applicantDto)
        {
            var applicant = new Applicant(applicantDto);
            await _context.AddAsync(applicant);
            await _context.SaveChangesAsync();
        }
    }
}

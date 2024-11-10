using Microsoft.EntityFrameworkCore;
using Recruitment.Data;
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
           var applicants= await _context.Applicants.Where(e => ids.Contains(e.Id)).ToListAsync();
           foreach(var applicant in applicants)
           {
                applicant.SentToErp = true;
           }
           await _context.SaveChangesAsync();
        }

        public async Task<List<Applicant>> GetAllApplicants()
        {
            return await _context.Applicants.Where(e => e.SentToErp==false).ToListAsync();
        }

        public async Task SaveApplicant(Applicant applicant)
        {
            await _context.AddAsync(applicant);
            await _context.SaveChangesAsync();
        }
    }
}

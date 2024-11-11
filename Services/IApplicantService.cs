using Recruitment.Dtos;
using Recruitment.Models;

namespace Recruitment.Services
{
    public interface IApplicantService
    {
        Task<List<ApplicantDto>> GetAllApplicants();
        public decimal GetNewId();
        public Task ChangeSentToErp(List<decimal> ids);
        public Task SaveApplicant(ApplicantDto applicant);
    }
}

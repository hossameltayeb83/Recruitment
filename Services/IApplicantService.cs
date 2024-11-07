using Recruitment.Models;

namespace Recruitment.Services
{
    public interface IApplicantService
    {
        Task<List<Applicant>> GetAllApplicants();

        public Task ChangeSentToErp(List<decimal> ids);
        public Task SaveApplicant(Applicant applicant);
    }
}

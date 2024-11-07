using Recruitment.Dtos;

namespace Recruitment.Services
{
    public interface IRecruitmentService
    {
        public Task HandleRecruitmentsSentFromErp(List<RecruitmentDto> recruitments);
        public Task<List<decimal>> GetRecruitmentIds();
        public Task<Models.Recruitment> GetRecruitmentFromLinkAsync(string link);
    }
}

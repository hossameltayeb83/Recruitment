using Recruitment.Dtos;

namespace Recruitment.Services
{
    public interface IRecruitmentService
    {
        public Task HandleRecruitmentsSentFromErp(List<RecruitmentDto> recruitments);
        public Task<List<decimal>> GetRecruitmentIds();
        public Task<Models.Recruitment> GetRecruitmentFromLinkAsync(string link);
        string GenerateRecruitmentLink(decimal departmentPositionId);
        public Task<List<KeyValue>> GetAvailableRecruitments(string? positionName,decimal? employeCategoryId);
        public Task<List<KeyValue>> GetAvailableRecruitments();
        public Task<List<KeyValue>> GetAvailableCategories();
    }
}

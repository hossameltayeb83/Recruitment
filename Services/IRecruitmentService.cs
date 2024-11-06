namespace Recruitment.Services
{
    public interface IRecruitmentService
    {
        public Task ChangeSentToErp(List<decimal> ids);
        public Task<List<decimal>> GetRecruitmentIds();
        public Task UpdateRecruitment(Models.Recruitment recruitment);
        public Task CreateRecruitment(Models.Recruitment recruitment);
        public Task<Models.Recruitment> GetRecruitmentFromLinkAsync(string link);
        public Task DeleteRecruitment(decimal erpDepartmentPosition);
    }
}

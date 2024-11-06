using Recruitment.Models;

namespace Recruitment.Services
{
    public interface ISetupKeyValueService
    {
        public Task<List<Gender>> GetGenderAsync();
        public Task<List<MartialStatus>> GetMartialStatusAsync();
        public Task<List<MilitaryStatus>> GetMilitaryStatusAsync();
    }
}

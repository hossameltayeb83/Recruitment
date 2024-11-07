using Recruitment.Models;

namespace Recruitment.Services
{
    public interface ISetupKeyValueService
    {
        public Task<List<Branch>> GetBranchAsync();
        public Task<List<DoctorDegree>> GetDoctorDegreeAsync();
        public Task<List<Gender>> GetGenderAsync();
        public Task<List<MartialStatus>> GetMartialStatusAsync();
        public Task<List<MilitaryStatus>> GetMilitaryStatusAsync();
        public Task<List<Speciality>> GetSpecialityAsync();
        public Task<List<University>> GetUniversitiesAsync();
    }
}

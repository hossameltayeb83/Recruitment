using Microsoft.EntityFrameworkCore;
using Recruitment.Data;
using Recruitment.Models;

namespace Recruitment.Services
{
    public class SetupKeyValueService : ISetupKeyValueService
    {
        private Dictionary<decimal, Type> _Documents = new Dictionary<decimal, Type>
        {
            {1m,typeof(Gender)},{2m,typeof(Branch)}
        };

        private readonly ApplicationDbContext _context;

        public SetupKeyValueService(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get-Methods

        public async Task<List<Branch>> GetBranchAsync()
        {
            return Branches.Select(e => new Branch
            {
                Id = e.Id,
                Value = e.Value,
            }).ToList();
        }

        public async Task<List<DoctorDegree>> GetDoctorDegreeAsync()
        {
            return DoctorDegrees.Select(e => new DoctorDegree
            {
                Id = e.Id,
                Value = e.Value,
            }).ToList();
        }

        public async Task<List<Gender>> GetGenderAsync()
        {
            return Genders.Select(e => new Gender
            {
                Id = e.Id,
                Value = e.Value,
            }).ToList();
        }

        public async Task<List<MartialStatus>> GetMartialStatusAsync()
        {
            return MartialStatuses.Select(e => new MartialStatus
            {
                Id = e.Id,
                Value = e.Value,
            }).ToList();
        }

        public async Task<List<MilitaryStatus>> GetMilitaryStatusAsync()
        {
            return MilitaryStatuses.Select(e => new MilitaryStatus
            {
                Id = e.Id,
                Value = e.Value,
            }).ToList();
        }

        public async Task<List<Speciality>> GetSpecialityAsync()
        {
            return Specialities.Select(e => new Speciality
            {
                Id = e.Id,
                Value = e.Value,
            }).ToList();
        }

        public async Task<List<University>> GetUniversitiesAsync()
        {
            return Universities.Select(e => new University
            {
                Id = e.Id,
                Value = e.Value,
            }).ToList();
        }

        #endregion


        #region Lists

        public List<Branch> Branches = new List<Branch>
        {
            new Branch
            {
                Id = 1,
                Value= "Branch1"
            },
            new Branch
            {
                Id = 2,
                Value= "Branch2"
            },
        };

        public List<DoctorDegree> DoctorDegrees = new List<DoctorDegree>
        {
            new DoctorDegree
            {
                Id = 1,
                Value= "Consultant"
            },
            new DoctorDegree
            {
                Id = 1,
                Value= "Specialist"
            },
        };

        public List<Gender> Genders = new List<Gender>
        {
            new Gender
            {
                Id = 1,
                Value= "Male"
            },
            new Gender
            {
                Id = 2,
                Value= "Female"
            },
        };

        public List<MartialStatus> MartialStatuses = new List<MartialStatus>
        {
            new MartialStatus
            {
                Id = 1,
                Value = "Married",
            },new MartialStatus
            {
                Id = 2,
                Value = "Single",
            },new MartialStatus
            {
                Id = 3,
                Value = "Engadged",
            },new MartialStatus
            {
                Id = 4,
                Value = "Broken",
            },
        };

        public List<MilitaryStatus> MilitaryStatuses = new List<MilitaryStatus>
        {
            new MilitaryStatus {Id=1, Value="Served" },
            new MilitaryStatus {Id=2, Value="Gamed" },
            new MilitaryStatus {Id=3, Value="H" },
            new MilitaryStatus {Id=4, Value="Complete" },
        };

        public List<Speciality> Specialities = new List<Speciality>
        {
            new Speciality {Id=1, Value="Dermatology" },
            new Speciality {Id=2, Value="Urology" },
            new Speciality {Id=3, Value="Andrology" },
            new Speciality {Id=4, Value="Pediatrics" },
        };

        public List<University> Universities = new List<University>
        {
            new University
            {
                Id = 1,
                Value= "Alex"
            },
            new University
            {
                Id = 2,
                Value= "Cairo"
            },
        };

        #endregion

    }
}

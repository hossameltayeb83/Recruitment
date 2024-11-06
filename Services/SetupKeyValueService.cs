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

        #region Lists

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

        #endregion

    }
}

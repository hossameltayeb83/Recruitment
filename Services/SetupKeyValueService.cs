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
            _context=context;
        }
    }
}

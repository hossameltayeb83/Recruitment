using Recruitment.Common;
using Recruitment.Dtos;
using Recruitment.Enums;
using Recruitment.Models;

namespace Recruitment.Services
{
    public interface ISetupKeyValueService
    {
        Task HandleSetup(List<SetupKeyValueDto> dtos);
        Task<List<TSetup>> GetKeyValueList<TSetup>() where TSetup : SetupKeyValue;
    }
}

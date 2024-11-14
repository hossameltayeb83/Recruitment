using Recruitment.Dtos;
using Recruitment.Models;

namespace Recruitment.Services
{
    public interface IPositionService
    {
        public Task HandlePositionsSentFromErp(List<PositionDto> position);
        public Task<List<decimal>> GetPositionIds();
        public Task<Position> GetPositionFromLinkAsync(string link);
        string GeneratePositionLink(decimal departmentPositionId);
        public Task<List<KeyValue>> GetAvailablePositions();
    }
}

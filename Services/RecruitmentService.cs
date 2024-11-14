using Microsoft.EntityFrameworkCore;
using Recruitment.Data;
using Recruitment.Dtos;
using Recruitment.Enums;
using Recruitment.Helper;
using Recruitment.Models;
using System.Web;

namespace Recruitment.Services
{
    public class RecruitmentService : IPositionService
    {

        private readonly ApplicationDbContext _context;
        public RecruitmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<decimal>> GetPositionIds()
        {
           return await _context.Positions.Select(e => e.ErpDepartmentPositionID).ToListAsync();
        }
        public string GeneratePositionLink(decimal departmentPositionId)
        {
            return HttpUtility.UrlEncode(GenericHelper.EncryptString(departmentPositionId.ToString()));
        }
        public async Task<Position> GetPositionFromLinkAsync(string link)
        {
            var decodedLink = GenericHelper.DecryptGeneric(link);
            decimal.TryParse(decodedLink, out var departmentPositionID);
            return await _context.Positions.FirstOrDefaultAsync(e=>e.ErpDepartmentPositionID == departmentPositionID);
        }
        public async Task HandlePositionsSentFromErp(List<PositionDto> positions)
        {
            foreach (var dto in positions)
            {
                if (dto.EventType == EventType.Added)
                {
                    var positionToAdd = new Position(dto);
                    _context.Positions.Add(positionToAdd);
                }
                else
                {
                    var positionToModify = await _context.Positions.FindAsync(dto.ErpDepartmentPositionID);
                    if (positionToModify != null)
                    {
                        if (dto.EventType == EventType.Modified)
                        {
                            //positionToModify
                            _context.Positions.Update(positionToModify);
                        }
                        if (dto.EventType == EventType.Deleted)
                        {
                            _context.Positions.Remove(positionToModify);
                        }
                    }
                    else
                    {
                        if (dto.EventType == EventType.Modified)
                        {
                            var positionToAdd = new Position(dto);
                            _context.Positions.Add(positionToAdd);
                        }
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        

        

        public async Task<List<KeyValue>> GetAvailablePositions(string? positionName, decimal? employeCategoryId)
        {
            var query = _context.Positions.Where(e => e.LinkExpiryDate > DateTime.Now);
            if (positionName != null)
                query = query.Where(e => positionName.Contains(e.PositionName));
            if (employeCategoryId != null)
                query = query.Where(e => e.ErpEmployeeCategoryID==employeCategoryId );
            return await query.Select(e => new KeyValue { Id =e.ErpDepartmentPositionID, Value = e.PositionName }).ToListAsync();
        }

        public Task<List<KeyValue>> GetAvailablePositions()
        {
            return GetAvailablePositions(null,null);
        }

        public Task<List<KeyValue>> GetAvailableCategories()
        {
            throw new NotImplementedException();
        }
    }
}

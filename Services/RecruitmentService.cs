using Microsoft.EntityFrameworkCore;
using Recruitment.Data;
using Recruitment.Dtos;
using Recruitment.Enums;
using Recruitment.Helper;
using Recruitment.Models;
using System.Web;

namespace Recruitment.Services
{
    public class RecruitmentService(ApplicationDbContext context) : IPositionService
    {
        public async Task<List<decimal>> GetPositionIds()
        {
           return await context.Positions.Select(e => e.ErpDepartmentPositionID).ToListAsync();
        }
        public string GeneratePositionLink(decimal departmentPositionId)
        {
            return HttpUtility.UrlEncode(GenericHelper.EncryptString(departmentPositionId.ToString()));
        }
        public async Task<Position> GetPositionFromLinkAsync(string link)
        {
            var decodedLink = GenericHelper.DecryptGeneric(link);
            decimal.TryParse(decodedLink, out var departmentPositionID);
            return await context.Positions.FirstOrDefaultAsync(e=>e.ErpDepartmentPositionID == departmentPositionID);
        }
        public async Task HandlePositionsSentFromErp(List<PositionDto> positions)
        {
            foreach (var dto in positions)
            {
                if (dto.EventType == EventType.Added)
                {
                    var positionToAdd = new Position(dto);
                    context.Positions.Add(positionToAdd);
                }
                else
                {
                    var positionToModify = await context.Positions.FindAsync(dto.ErpDepartmentPositionID);
                    if (positionToModify != null)
                    {
                        if (dto.EventType == EventType.Modified)
                        {
                            //positionToModify
                            context.Positions.Update(positionToModify);
                        }
                        if (dto.EventType == EventType.Deleted)
                        {
                            context.Positions.Remove(positionToModify);
                        }
                    }
                    else
                    {
                        if (dto.EventType == EventType.Modified)
                        {
                            var positionToAdd = new Position(dto);
                            context.Positions.Add(positionToAdd);
                        }
                    }
                }
            }
            await context.SaveChangesAsync();
        }

        

        

        public async Task<List<KeyValue>> GetAvailablePositions()
        {
            var query = context.Positions.Where(e => e.LinkExpiryDate > DateTime.Now);
            return await query.Select(e => new KeyValue { Id =e.ErpDepartmentPositionID, Value = e.PositionName }).ToListAsync();
        }


    }
}

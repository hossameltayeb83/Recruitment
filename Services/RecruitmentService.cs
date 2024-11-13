using Microsoft.EntityFrameworkCore;
using Recruitment.Data;
using Recruitment.Dtos;
using Recruitment.Enums;
using Recruitment.Helper;
using System.Web;

namespace Recruitment.Services
{
    public class RecruitmentService : IRecruitmentService
    {

        private readonly ApplicationDbContext _context;
        public RecruitmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<decimal>> GetRecruitmentIds()
        {
           return await _context.Recruitments.Select(e => e.ErpDepartmentPositionID).ToListAsync();
        }
        public string GenerateRecruitmentLink(decimal departmentPositionId)
        {
            return HttpUtility.UrlEncode(GenericHelper.EncryptString(departmentPositionId.ToString()));
        }
        public async Task<Models.Recruitment> GetRecruitmentFromLinkAsync(string link)
        {
            var decodedLink = GenericHelper.DecryptGeneric(link);
            decimal.TryParse(decodedLink, out var departmentPositionID);
            return await _context.Recruitments.FirstOrDefaultAsync(e=>e.ErpDepartmentPositionID == departmentPositionID);
        }
        public async Task HandleRecruitmentsSentFromErp(List<RecruitmentDto> recruitments)
        {
            foreach (var dto in recruitments)
            {
                if (dto.EventType == EventType.Added)
                {
                    var recruitmentToAdd = new Models.Recruitment(dto);
                    _context.Recruitments.Add(recruitmentToAdd);
                }
                else
                {
                    var recruitmentToModify = await _context.Recruitments.FindAsync(dto.ErpDepartmentPositionID);
                    if (recruitmentToModify != null)
                    {
                        if (dto.EventType == EventType.Modified)
                        {
                            //recruitmentToModify
                            _context.Recruitments.Update(recruitmentToModify);
                        }
                        if (dto.EventType == EventType.Deleted)
                        {
                            _context.Recruitments.Remove(recruitmentToModify);
                        }
                    }
                    else
                    {
                        if (dto.EventType == EventType.Modified)
                        {
                            var recruitmentToAdd = new Models.Recruitment(dto);
                            _context.Recruitments.Add(recruitmentToAdd);
                        }
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        

        

        public async Task<List<KeyValue>> GetAvailableRecruitments(string? positionName, decimal? employeCategoryId)
        {
            var query = _context.Recruitments.Where(e => e.LinkExpiryDate > DateTime.Now);
            if (positionName != null)
                query = query.Where(e => positionName.Contains(e.PositionName));
            if (employeCategoryId != null)
                query = query.Where(e => e.ErpEmployeeCategoryID==employeCategoryId );
            return await query.Select(e => new KeyValue { Id =e.ErpDepartmentPositionID, Value = e.PositionName }).ToListAsync();
        }

        public Task<List<KeyValue>> GetAvailableRecruitments()
        {
            return GetAvailableRecruitments(null,null);
        }

        public Task<List<KeyValue>> GetAvailableCategories()
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Recruitment.Data;
using Recruitment.Models;
using Recruitment.Common;
using System.Reflection;
using Recruitment.Enums;
using Recruitment.Dtos;
namespace Recruitment.Services
{
    public class SetupKeyValueService : ISetupKeyValueService
    {
        private Dictionary<Document, Type> _Documents = new Dictionary<Document, Type>
        {
            {Document.Gender,typeof(Gender)}
        };
        private readonly ApplicationDbContext _context;
        public SetupKeyValueService(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task HandleSetup(List<SetupKeyValueDto> dtos)
        {
            var method = typeof(SetupKeyValueService).GetMethod(nameof(HandleSetup), BindingFlags.NonPublic | BindingFlags.Instance);
            foreach(var dto in  dtos)
            {
                var setupType= _Documents[dto.DocumentType] ;
                var handleMethod = method.MakeGenericMethod(setupType);
                await (Task)handleMethod.Invoke(this, [dto.EventType, dto.ErpKey, dto.Value]);
            }
            await _context.SaveChangesAsync();
        }
        private async Task HandleSetup<TSetup>(EventType eventType, decimal erpKey,string value) where TSetup: SetupKeyValue , new()
        {
            if (eventType == EventType.Added)
            {
                var entityToAdd = new TSetup() { Id = erpKey, Value = value };
                _context.Set<TSetup>().Add(entityToAdd);
            }
            else
            {
                var entityToModify= await _context.Set<TSetup>().FindAsync(erpKey);
                if (entityToModify != null)
                {
                    if(eventType== EventType.Modified)
                    {
                        entityToModify.Value = value;
                        _context.Set<TSetup>().Update(entityToModify);
                    }
                    if(eventType == EventType.Deleted)
                    {
                        _context.Set<TSetup>().Remove(entityToModify);
                    }
                }
            }
            
        }
        public async Task<List<TSetup>> GetKeyValueList<TSetup>() where TSetup: SetupKeyValue
        {
           return await _context.Set<TSetup>().ToListAsync();
        }
        public async Task<List<Gender>> GetGenders()
        {
            return await _context.Genders.ToListAsync();
        }
    }
}

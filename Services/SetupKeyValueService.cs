using Microsoft.EntityFrameworkCore;
using Recruitment.Data;
using Recruitment.Models;
using Recruitment.Common;
using System.Reflection;
using Recruitment.Enums;
using Recruitment.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Recruitment.Services
{
    public class SetupKeyValueService : ISetupKeyValueService
    {
        private Dictionary<Document, Type> _Documents = new Dictionary<Document, Type>
        {
            {Document.Gender,typeof(Gender)},
            {Document.University,typeof(University)},
            {Document.Branch,typeof(Branch)},
            {Document.Military,typeof(MilitaryStatus)},
            {Document.Martial,typeof(MartialStatus)},
            {Document.AreaCity,typeof(AreaCity)},
            {Document.Speciality,typeof(Speciality)},
            {Document.DoctorDegree,typeof(DoctorDegree)}
        };

        private readonly ApplicationDbContext _context;

        public SetupKeyValueService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task HandleSetup(List<SetupKeyValueDto> dtos)
        {
            var method = typeof(SetupKeyValueService).GetMethod(nameof(HandleSetup), BindingFlags.NonPublic | BindingFlags.Instance);
            foreach(var dto in  dtos)
            {
                var setupType= _Documents[dto.DocumentType] ;
                var handleMethod = method.MakeGenericMethod(setupType);
                await (Task)handleMethod.Invoke(this, [dto]);
            }
            await _context.SaveChangesAsync();
        }
        private async Task HandleSetup<TSetup>(SetupKeyValueDto dto) where TSetup: SetupKeyValue , new()
        {
            if (dto.EventType == EventType.Added)
            {
                var entityToAdd = new TSetup() { Id = dto.ErpKey, ValueAr = dto.ValueAr ,ValueEn= dto.ValueEn,HasParent=dto.HasParent };
                _context.Set<TSetup>().Add(entityToAdd);
            }
            else
            {
                try
                {

                    var entityToModify= await _context.Set<TSetup>().FindAsync(dto.ErpKey);
                
                    if (entityToModify != null)
                    {
                        if(dto.EventType== EventType.Modified)
                        {
                            entityToModify.ValueAr = dto.ValueAr;
                            entityToModify.ValueEn = dto.ValueEn;
                            _context.Set<TSetup>().Update(entityToModify);
                        }
                        if(dto.EventType == EventType.Deleted)
                        {
                            _context.Set<TSetup>().Remove(entityToModify);
                        }
                    }
                    else
                    {
                        if (dto.EventType == EventType.Modified)
                        {
                            var entityToAdd = new TSetup() { Id = dto.ErpKey, ValueAr = dto.ValueAr, ValueEn = dto.ValueEn, HasParent = dto.HasParent };
                            _context.Set<TSetup>().Add(entityToAdd);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            
        }
        public async Task<List<KeyValue>> GetKeyValueList<TSetup>(string lang,bool hasParent=false) where TSetup: SetupKeyValue
        {
            return await _context.Set<TSetup>().Where(e=>e.HasParent==hasParent).Select(e=> PrepareKeyValue(e,lang)).ToListAsync();
        }
        private static KeyValue PrepareKeyValue(SetupKeyValue setupKeyValue,string lang)
        {
            var keyValue=new KeyValue() { Id=setupKeyValue.Id}; 
            if (lang == null || lang == "ar")
            {
                if (!string.IsNullOrEmpty(setupKeyValue.ValueAr))
                {
                    keyValue.Value = setupKeyValue.ValueAr;
                }
                else
                {
                    keyValue.Value = setupKeyValue.ValueEn;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(setupKeyValue.ValueEn))
                {
                    keyValue.Value = setupKeyValue.ValueEn;
                }
                else
                {
                    keyValue.Value = setupKeyValue.ValueAr;
                }
            }
            return keyValue;
        }
        public async Task<List<Gender>> GetGenders()
        {
            return await _context.Genders.ToListAsync();
        }

    }
}

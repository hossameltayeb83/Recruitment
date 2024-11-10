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
            return await _context.Set<TSetup>().Where(e=>e.HasParent==hasParent).Select(e=> PrepareKeyValue(e,lang,hasParent)).ToListAsync();
        }
        private static KeyValue PrepareKeyValue(SetupKeyValue setupKeyValue,string lang,bool hasParent)
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

        #region Get-Methods

        //public async Task<List<Branch>> GetBranchAsync()
        //{
        //    return Branches.Select(e => new Branch
        //    {
        //        Id = e.Id,
        //        Value = e.Value,
        //    }).ToList();
        //}

        //public async Task<List<DoctorDegree>> GetDoctorDegreeAsync()
        //{
        //    return DoctorDegrees.Select(e => new DoctorDegree
        //    {
        //        Id = e.Id,
        //        Value = e.Value,
        //    }).ToList();
        //}

        //public async Task<List<Gender>> GetGenderAsync()
        //{
        //    return Genders.Select(e => new Gender
        //    {
        //        Id = e.Id,
        //        Value = e.Value,
        //    }).ToList();
        //}

        //public async Task<List<MartialStatus>> GetMartialStatusAsync()
        //{
        //    return MartialStatuses.Select(e => new MartialStatus
        //    {
        //        Id = e.Id,
        //        Value = e.Value,
        //    }).ToList();
        //}

        //public async Task<List<MilitaryStatus>> GetMilitaryStatusAsync()
        //{
        //    return MilitaryStatuses.Select(e => new MilitaryStatus
        //    {
        //        Id = e.Id,
        //        Value = e.Value,
        //    }).ToList();
        //}

        //public async Task<List<Speciality>> GetSpecialityAsync()
        //{
        //    return Specialities.Select(e => new Speciality
        //    {
        //        Id = e.Id,
        //        Value = e.Value,
        //    }).ToList();
        //}

        //public async Task<List<University>> GetUniversitiesAsync()
        //{
        //    return Universities.Select(e => new University
        //    {
        //        Id = e.Id,
        //        Value = e.Value,
        //    }).ToList();
        //}

        #endregion


        #region Lists

        //public List<Branch> Branches = new List<Branch>
        //{
        //    new Branch
        //    {
        //        Id = 1,
        //        Value= "Branch1"
        //    },
        //    new Branch
        //    {
        //        Id = 2,
        //        Value= "Branch2"
        //    },
        //};

        //public List<DoctorDegree> DoctorDegrees = new List<DoctorDegree>
        //{
        //    new DoctorDegree
        //    {
        //        Id = 1,
        //        Value= "Consultant"
        //    },
        //    new DoctorDegree
        //    {
        //        Id = 1,
        //        Value= "Specialist"
        //    },
        //};

        //public List<Gender> Genders = new List<Gender>
        //{
        //    new Gender
        //    {
        //        Id = 1,
        //        Value= "Male"
        //    },
        //    new Gender
        //    {
        //        Id = 2,
        //        Value= "Female"
        //    },
        //};

        //public List<MartialStatus> MartialStatuses = new List<MartialStatus>
        //{
        //    new MartialStatus
        //    {
        //        Id = 1,
        //        Value = "Married",
        //    },new MartialStatus
        //    {
        //        Id = 2,
        //        Value = "Single",
        //    },new MartialStatus
        //    {
        //        Id = 3,
        //        Value = "Engadged",
        //    },new MartialStatus
        //    {
        //        Id = 4,
        //        Value = "Broken",
        //    },
        //};

        //public List<MilitaryStatus> MilitaryStatuses = new List<MilitaryStatus>
        //{
        //    new MilitaryStatus {Id=1, Value="Served" },
        //    new MilitaryStatus {Id=2, Value="Gamed" },
        //    new MilitaryStatus {Id=3, Value="H" },
        //    new MilitaryStatus {Id=4, Value="Complete" },
        //};

        //public List<Speciality> Specialities = new List<Speciality>
        //{
        //    new Speciality {Id=1, Value="Dermatology" },
        //    new Speciality {Id=2, Value="Urology" },
        //    new Speciality {Id=3, Value="Andrology" },
        //    new Speciality {Id=4, Value="Pediatrics" },
        //};

        //public List<University> Universities = new List<University>
        //{
        //    new University
        //    {
        //        Id = 1,
        //        Value= "Alex"
        //    },
        //    new University
        //    {
        //        Id = 2,
        //        Value= "Cairo"
        //    },
        //};

        #endregion

    }
}

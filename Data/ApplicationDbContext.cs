using Microsoft.EntityFrameworkCore;
using Recruitment.Dtos;
using Recruitment.Models;
namespace Recruitment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set;}
        public DbSet<AreaCity> AreaCities { get; set;}
        public DbSet<Branch> Branches { get; set;}
        public DbSet<DoctorDegree> DoctorDegrees { get; set;}
        public DbSet<Gender> Genders { get; set;}
        public DbSet<MartialStatus> MartialStatuses { get; set;}
        public DbSet<MilitaryStatus> MilitaryStatuses { get; set;}
        public DbSet<Position> Positions { get; set;}
        public DbSet<Speciality> Specialities { get; set;}
        public DbSet<University> Universities { get; set;}
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}

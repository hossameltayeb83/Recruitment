using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Recruitment.Components;
using Recruitment.Data;
using Recruitment.Localization;
using Recruitment.Security;
using Recruitment.Services;
using System.Globalization;

namespace Recruitment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            
            builder.Services.AddCors(
                options => options.AddPolicy("Erp", policy => policy.WithOrigins(builder.Configuration["Erp"]!).AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(policy => true)));
            
            builder.Services.AddHostedService<StartingService>();
            builder.Services.ConfigureLocalization();
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            
            builder.Services.AddScoped<IRecruitmentService,RecruitmentService>();
            builder.Services.AddScoped<IApplicantService,ApplicantService>();
            builder.Services.AddScoped<ISetupKeyValueService,SetupKeyValueService>();
            
            var app = builder.Build();
            ServiceProviderHelper.ServiceProvider = app.Services;
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("Erp");

            app.UseRequestLocalization();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();
            app.MapControllers();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

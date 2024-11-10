using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recruitment.Helper;
using static Recruitment.Localization.Localizer;
using System.Globalization;
using System.Reflection.Metadata;

namespace Recruitment.Localization
{
    public class StartingService : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<StartingService> _logger;
        private readonly IServiceProvider _provider;

        static StartingService()
        {
        }
        //private readonly LicenseService _licenseService;

        public StartingService(IConfiguration configuration,
            IServiceProvider provider, ILogger<StartingService> logger,
            IWebHostEnvironment environment /*, LicenseService licenseService*/
        )
        {
            _configuration = configuration;
            _provider = provider;
            _logger = logger;
            _environment = environment;
            // _licenseService = licenseService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Start Load Localizer");
            var path = Path.Combine(_environment.ContentRootPath, "Files/Localization.csv");
            using (var reader = new StreamReader(path))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //{
            //    var records = new List<LocalizationRecord>();
            //    await foreach (var item in csv.GetRecordsAsync<LocalizationRecord>())
            //        records.Add(item);
            //    LoadStrings(records);
            //}

            _logger.LogInformation("End Load Localizer");
        }
    }
}

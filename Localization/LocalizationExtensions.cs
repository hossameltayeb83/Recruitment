using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Recruitment.Localization
{
    public static class LocalizationExtensions
    {
        public static IServiceCollection ConfigureLocalization(this IServiceCollection services)
        {
            return services.Configure<RequestLocalizationOptions>(options =>
            {
                var enUsCulture = new CultureInfo("en-US");
                var arEgCulture = new CultureInfo("ar-EG") { NumberFormat = { NumberDecimalSeparator = "." } };
                //in Linux all decimal numbers translated to , and gives a problems in parsing and conversion
                //the following line is the solution

                var supportedCultures = new[] { enUsCulture, arEgCulture };
                options.DefaultRequestCulture = new RequestCulture(arEgCulture, arEgCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(context =>
                {
                    var userCulture = enUsCulture.Name;
                    context.Request.Headers.TryGetValue("UserCulture", out var userCultures);
                    if (userCultures.Any())
                        userCulture = userCultures.First();
                    // return new ProviderCultureResult("en");
                    return Task.FromResult(new ProviderCultureResult(userCulture));
                }));
            });
        }
    }
}

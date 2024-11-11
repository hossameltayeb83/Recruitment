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

                var supportedCultures = new[] { enUsCulture, arEgCulture };
                options.DefaultRequestCulture = new RequestCulture(arEgCulture, arEgCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(context =>
                {
                    var path = context.Request.Path.Value; // Get the full URL path
                    string? userCulture;
                    if (path.Contains("/ar/") || path.Contains("/en/"))
                    {
                        userCulture = path.Contains("/en/") ? "en-US" : "ar-EG";
                        context.Request.Headers.TryGetValue("UserCulture", out var userCultures);
                        if (userCultures.Any())
                            userCulture = userCultures.First();
                        Console.WriteLine($"Request Path: {path}");
                        Console.WriteLine($"User Culture: {userCulture}");
                        
                        context.Response.Cookies.Append("UserCulture", userCulture, new CookieOptions
                        {
                            Expires = DateTimeOffset.UtcNow.AddDays(1), // Set the expiration time
                            HttpOnly = true, // Make the cookie HttpOnly for security
                            Secure = context.Request.IsHttps // Set cookie to secure if the request is over HTTPS
                        });
                    }
                    else
                    {
                        userCulture = context.Request.Cookies["UserCulture"];
                        userCulture ??= "en-US";
                    }

                    return Task.FromResult(new ProviderCultureResult(userCulture));
                }));
            });
        }
    }
}

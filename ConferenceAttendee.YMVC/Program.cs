using ConferenceAttendees.YMVC.Services.Base;
using Serilog;

namespace ConferenceAttendees.YMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //1
            builder.Services.AddHttpClient();
            //2
            builder.Services.AddScoped<Services.Base.IClient, Services.Base.Client>(services =>
            {
                //var configuration = services.GetRequiredService<IConfiguration>();
                //var baseUrl = configuration["Api:BaseApiUrl"]!;

                var baseUrl = builder.Configuration["ConferenceAttendeesApi:BaseApiUrl"] ?? throw new Exception("ConferenceAttendeesApi:BaseApiUrl is not configured");

                var httpClientFactory = services.GetRequiredService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient();

                return new Client(baseUrl, httpClient);
            });

            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration)
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingSystemApi.Data;

namespace ParkingSystemApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                });

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ParkingDbContext>(options =>
                options.UseNpgsql(connectionString));

            // Add other services and dependencies
            // services.AddScoped<IYourService, YourService>();

            // using (var serviceProvider = services.BuildServiceProvider())
            // {
            //     using (var scope = serviceProvider.CreateScope())
            //     {
            //         var dbContext = scope.ServiceProvider.GetRequiredService<ParkingDbContext>();

            //         // Create the database
            //         dbContext.Database.Migrate();

            //         // Drop the database (optional)
            //         dbContext.Database.EnsureDeleted();
            //     }
            // }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

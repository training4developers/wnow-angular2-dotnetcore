using System.Text;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Training4Developers.Interfaces;
using Training4Developers.Data;
using Training4Developers.Models;
using DataModels = Training4Developers.Data.Models;

namespace Training4Developers
{
    public class Startup
    {
        public Startup(IHostingEnvironment env) {

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }


        public void SeedNewDatabase(IApplicationBuilder app) { 

            using (var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>()) {

                if (context.Database.EnsureCreated()) {

                    context.AddRange(
                        new DataModels.User { FirstName = "Bob", LastName = "Thomas", EmailAddress = "bob@localhost", HashedPassword = "test" },
                        new DataModels.User { FirstName = "Jane", LastName = "Thomas", EmailAddress = "jane@localhost", HashedPassword = "test" },
                        new DataModels.Widget { Name = "Red Small Widget", Description = "A red small widget.", Color = "red", Size = "small", Quantity = 4, Price = 3.45M },
                        new DataModels.Widget { Name = "Blue Medium Widget", Description = "A blue medium widget.", Color = "blue", Size = "medium", Quantity = 6, Price = 2.75M },
                        new DataModels.Widget { Name = "Orange Large Widget", Description = "A orange large widget.", Color = "orange", Size = "large", Quantity = 10, Price = 13.65M },
                        new DataModels.Widget { Name = "Yellow Small Widget", Description = "A yellow small widget.", Color = "yellow", Size = "small", Quantity = 3, Price = 9.55M }
                    );

                    context.SaveChanges();
                }
            }

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // SQLite DbContext
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
            services.AddMvc();
            services.AddOptions();
            
            services.Configure<JwtOptions>(options =>
            {
                options.Secret = Configuration.GetSection("JwtOptions:Secret").Value;
            });
            
            // add concrete implementation for repo interfaces
            // added for a scoped lifetime
            // options are
            // transient - created each time per request
            // scoped - created each request
            // singleton - created once
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IWidgetRepo, WidgetRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // seeds the database if the startup creates the database
            SeedNewDatabase(app);
            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //secretKey contains a secret passphrase only your server knows
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                Configuration.GetSection("JwtOptions:Secret").Value));            

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey
            };
            
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });

            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("spa-fallback", "{*anything}", new { controller = "Home", action = "Index" });
            });
        }
    }
}

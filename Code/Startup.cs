using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PathApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PathApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var availableDatabases = Configuration.GetSection("AvailableDatabases");
            if (availableDatabases != null)
            {
                var listAvailableDatabases = availableDatabases.GetChildren();
                if (listAvailableDatabases != null)
                {
                    foreach (var obj in listAvailableDatabases)
                    {
                        if (obj.Key == Configuration.GetSection("SelectedDatabase").Value)
                        {
                            var driver = obj.GetSection("driver");
                            string connectionstring = obj.GetSection("connectionstring").Value;
                            string databasename = obj.GetSection("databasename").Value;
                            System.Text.StringBuilder sbconnectionString = new System.Text.StringBuilder();
                            sbconnectionString.Append(connectionstring);
                            sbconnectionString.Replace("<%DATABASE%>", databasename);
                            if (driver.Value == "Postgres")
                            {
                                services.AddDbContext<PercorsiContext>(options =>
                                      options.UseNpgsql(sbconnectionString.ToString()));
                            }
                            else if (driver.Value == "mysql")
                            {
                                services.AddDbContext<PercorsiContext>(options =>
                                      options.UseMySql(sbconnectionString.ToString()));
                            }
                        }
                    }
                }
            }
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<PercorsiContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Search}/{action=Index}");
                endpoints.MapRazorPages();
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PercorsiContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}

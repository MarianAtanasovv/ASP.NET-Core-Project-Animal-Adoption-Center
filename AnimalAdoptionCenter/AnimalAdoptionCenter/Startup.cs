using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Infrastructure;
using AnimalAdoptionCenter.Services;
using AnimalAdoptionCenter.Services.Adoption;
using AnimalAdoptionCenter.Services.Animals;
using AnimalAdoptionCenter.Services.Comments;
using AnimalAdoptionCenter.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalAdoptionCenter
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });
            services.AddTransient<IDogService, DogService>();
            services.AddTransient<IAdoptionService, AdoptionService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<ICommentsService, CommentService>();
            services.AddTransient<IUserService, UserService>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
               
                app.UseHsts();
            }

            app
                 .UseHttpsRedirection()
                 .UseStaticFiles()
                 .UseRouting()
                 .UseAuthentication()
                 .UseAuthorization()
                 .UseEndpoints(endpoints =>
                 {
                     endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
                     endpoints.MapDefaultControllerRoute();
                     endpoints.MapRazorPages();
            });
        }
    }
}

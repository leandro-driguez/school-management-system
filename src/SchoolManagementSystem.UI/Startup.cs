
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;

namespace SchoolManagementSystem.UI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IRepository<Classroom>, ClassroomRepository>();
        
        services.AddControllersWithViews();
        
        services.AddDbContext<SchoolContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("SchoolContextSQLite")));
        
        services.AddDatabaseDeveloperPageExceptionFilter();
    }
    
    // public void Configure(WebApplication app)
    // {
        // if (app.Environment.IsDevelopment())
        // {
        //     app.UseDeveloperExceptionPage();
        // }
    //     if (!app.Environment.IsDevelopment())
    //     {
    //         app.UseExceptionHandler("/Home/Error");
    //         // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //         app.UseHsts();
    //     }
    //
    //     using (var scope = app.Services.CreateScope())
    //     {
    //         var services = scope.ServiceProvider;
    //
    //         var context = services.GetRequiredService<SchoolContext>();
    //         context.Database.EnsureCreated();
    //         DbInitializer.Initialize(context);
    //     }
    //
    //     app.UseHttpsRedirection();
    //     app.UseStaticFiles();
    //
    //     app.UseRouting();
    //
    //     app.UseAuthorization();
    //
    //     app.MapControllerRoute(
    //         name: "default",
    //         pattern: "{controller=Home}/{action=Index}/{id?}");
    // }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
        
            var context = services.GetRequiredService<SchoolContext>();
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
        
        // app.MapControllerRoute(
        //     name: "default",
        //     pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}

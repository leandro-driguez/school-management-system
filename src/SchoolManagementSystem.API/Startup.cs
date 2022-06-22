using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.Services_Implementations.Entities;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories.Entities;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;

namespace SchoolManagementSystem.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddDbContext<SchoolContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("SchoolContextSQLite")));

        services.AddAutoMapper(typeof(Program));

        // ClassRooms
        services.AddScoped<IClassroomRepository, ClassroomRepository>();
        services.AddScoped<IClassroomService, ClassroomService>();
        
        // BasicMeans
        services.AddScoped<IBasicMeanRepository, BasicMeanRepository>();
        services.AddScoped<IBasicMeanService, BasicMeanService>();
        // Positions
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<IService<Position>, PositionService>();
        // Workers
        services.AddScoped<IWorkerRepository, WorkerRepository>();
        services.AddScoped<IWorkerService, WorkerService>();
        // Expenses
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IExpenseService, ExpenseService>();
        // Students
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentService, StudentService>();
        // Courses
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseService, CourseService>();
        // CourseGroups
        services.AddScoped<ICourseGroupRepository, CourseGroupRepository>();
        services.AddScoped<ICourseGroupService, CourseGroupService>();
        // Teachers
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ITeacherService, TeacherService>();
        // Tuitors
        services.AddScoped<ITuitorRepository, TuitorRepository>();
        services.AddScoped<ITuitorService, TuitorService>();
        // Resources
        services.AddScoped<IResourceRepository, ResourceRepository>();
        services.AddScoped<IResourceService, ResourceService>();

        services.AddScoped<IObjectContext, SchoolContext>();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
        });
        
        // services.AddDefaultIdentity<IdentityUser>(options =>
        //         options.SignIn.RequireConfirmedAccount = false)
        //     .AddEntityFrameworkStores<SchoolContext>();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Management System", Version = "v1" });
        });
        
        // services.AddDatabaseDeveloperPageExceptionFilter();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(options =>
            options.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod());

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "School Management System v1"));
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
            endpoints.MapControllers();
        });
    } 
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.Services_Implementations;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Infrastructure.Persistence;
using SchoolManagementSystem.Infrastructure.Repositories;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;

using SchoolManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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

        services.Configure<JWT>(Configuration.GetSection("JWT"));

        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("IdentityContextSQLite")));

        // For Identity
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>();
            // .AddDefaultTokenProviders();

        // Adding Authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })

        // Adding Jwt Bearer
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = Configuration["JWT:Issuer"],
                ValidAudience = Configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
            };
        });

        services.AddAutoMapper(typeof(Program));

        //Injection of deendencies with reflection
        MyDependencyInjections.SetUpMyServicesDependencyInjections(services, Configuration);

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
        
            var schoolContext = services.GetRequiredService<SchoolContext>();
            schoolContext.Database.EnsureCreated();
            DbInitializer.Initialize(schoolContext);

            var identityContext = services.GetRequiredService<IdentityContext>();
            identityContext.Database.EnsureCreated();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        // app.UseAuthentication();
        // app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    } 
}

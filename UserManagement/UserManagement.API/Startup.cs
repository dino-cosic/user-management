using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UserManagement.Core.Helpers;
using UserManagement.Core.Interfaces;
using UserManagement.Core.MappingProfiles;
using UserManagement.Core.Profiles;
using UserManagement.Core.Services;
using UserManagement.DAL;
using UserManagement.DAL.Interfaces;
using UserManagement.DAL.Repositories;
using UserManagement.EF;

namespace UserManagement.API
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
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddAutoMapper(typeof(Startup), typeof(UserProfile), typeof(PermissionProfile));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserManagement", Version = "v1" });
            });

            services.AddDbContext<UserManagementDbContext>();

            // Repositories
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IUserPermissionRepository, UserPermissionRepository>();

            // Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserPermissionService, UserPermissionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserManagement v1"));
            }

            app.UseCors("ApiCorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            // global exception handler
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

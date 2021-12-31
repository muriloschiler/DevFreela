using DevFreela.API.Filters;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Services.Implemations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Validator;
using DevFreela.Core.IAuth;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DevFreela.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /*
        Criacao de uma migration e update no banco: 
            O -s se refere ao projeto que contem as configuracoes de conexao do DbContext
              
            dotnet ef migrations add InitialMigration -s ../DevFreela.API/DevFreela.API.csproj -o ./Persistence/Migrations  
            dotnet ef database update -s ../DevFreela.API/DevFreela.API.csproj 
        */
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DevFreelaDbContext>(
                                options => options.UseSqlite(Configuration.GetConnectionString("SQLite")));
            services.AddScoped<ISkillService,SkillService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddScoped<IAuthService,AuthService>();

            services.AddControllers(options=>options.Filters.Add(typeof(ValidatorFilter)))
                    .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<CreateProjectCommandValidator>());
            
            services.AddMediatR(typeof(CreateProjectCommand));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

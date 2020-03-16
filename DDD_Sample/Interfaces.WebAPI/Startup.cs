using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain.Leave.Repository.Facade;
using Domain.Leave.Repository.Persistence;
using Domain.Leave.Service;
using Domain.Person.Repository.Facade;
using Domain.Person.Repository.Persistence;
using Domain.Person.Service;
using Domain.Rule.Repository.facade;
using Domain.Rule.Repository.persistence;
using Domain.Rule.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Interfaces.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPersonFactory, PersonFactory>();
            services.AddScoped<ILeaveFactory, LeaveFactory>();

            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IApprovalRuleRepository, ApprovalRuleRepository>();

            services.AddScoped<ILeaveApplicationService, LeaveApplicationService>();
            services.AddScoped<IPersonApplicationService, PersonApplicationService>();
            services.AddScoped<ILoginApplicationService, LoginApplicationService>();
            services.AddScoped<ILeaveDomainService, LeaveDomainService>();
            services.AddScoped<IPersonDomainService, PersonDomainService>();
            services.AddScoped<IApprovalRuleDomainService, ApprovalRuleDomainService>();
            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

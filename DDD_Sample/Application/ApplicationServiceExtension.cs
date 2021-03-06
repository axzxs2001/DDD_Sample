﻿using Domain;
using Domain.Leave.Repository.Facade;
using Domain.Leave.Repository.Persistence;
using Domain.Leave.Service;
using Domain.Person.Repository.Facade;
using Domain.Person.Repository.Persistence;
using Domain.Person.Service;
using Domain.Rule.Repository.facade;
using Domain.Rule.Repository.persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application
{
    public static class ApplicationServiceExtension
    {
        public static void AddApplicationService(this IServiceCollection services, string connectionString)
        {
            services.AddDomainService();
            services.AddScoped(typeof(IDbConnection), (pro => new Npgsql.NpgsqlConnection(connectionString)));
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IApprovalRuleRepository, ApprovalRuleRepository>();
            services.AddScoped<IPersonFactory, PersonFactory>();
            services.AddScoped<ILeaveFactory, LeaveFactory>();
        }
    }
}

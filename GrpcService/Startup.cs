using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcService.Services;
using Dislinkt.Jobs.Persistence.Neo4j.Factory;
using Dislinkt.Jobs.Persistance.MongoDB.Common;
using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Persistance.MongoDB.Repositories;
using Dislinkt.Jobs.Persistence.Neo4j.Common;
using Dislinkt.Jobs.Persistence.Neo4j.Repositories;

namespace GrpcService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            // Dislinkt.Connections.Persistence.MongoDB
            services.AddScoped <Dislinkt.Jobs.Persistance.MongoDB.Factories.IDatabaseFactory, Dislinkt.Jobs.Persistance.MongoDB.Factories.DatabaseFactory > ();
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
            services.AddScoped<Dislinkt.Jobs.Persistance.MongoDB.Common.IQueryExecutor, Dislinkt.Jobs.Persistance.MongoDB.Common.QueryExecutor>();
            services.AddScoped<Dislinkt.Jobs.Persistence.Neo4j.Common.IQueryExecutor, Dislinkt.Jobs.Persistence.Neo4j.Common.QueryExecutor>();
            services.AddScoped<IJobRepository,JobRepository>();
            services.AddScoped<IJobGraphRepository, JobGraphRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<Dislinkt.Jobs.Persistance.MongoDB.Common.MongoDbContext>();
            services.AddScoped<Neo4jDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<AddSkillService>();
                endpoints.MapGrpcService<AddUserService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}

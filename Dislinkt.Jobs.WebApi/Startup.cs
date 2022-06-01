using Dislinkt.Jobs.Application.AddJobOffer.Commands;
using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Persistance.MongoDB.Common;
using Dislinkt.Jobs.Persistance.MongoDB.Factories;
using Dislinkt.Jobs.Persistance.MongoDB.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Dislinkt.Jobs.WebApi
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup init
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// IConfiguration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            services.AddMvcCore();
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }).AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Jobs API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);

            });
            services.Configure<MongoSettings>(options =>
            {
                options.Connection = Configuration.GetSection("MongoSettings:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection("MongoSettings:DatabaseName").Value;
            });
            services.AddMediatR(typeof(AddJobOfferCommand).GetTypeInfo().Assembly);
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
            services.AddScoped<IQueryExecutor, QueryExecutor>();
            services.AddScoped<IJobRepository, JobRepository>();

            services.AddScoped<MongoDbContext>();

            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jobs API V1");
                });

            }

            app.UseHttpsRedirection();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Credyty.Aplication.Implementation;
using Credyty.Aplication.Interfaces;
using Credyty.Domain.Implementation;
using Credyty.Domain.Interfaces;
using Credyty.Infraestructure.DataAccess;
using Credyty.Infraestructure.Interfaces;
using Credyty.Infraestructure.Repositories;
using Credyty.Transversal.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace Credyty.Services.API
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        #region Globals
        readonly string myPolicy = "PolicyCredyty";
        #endregion

        #region Builder
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }
        #endregion        

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection();
            services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            #region Configuración Mapper           
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Configuration CORS
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            var appSettingsSection = Configuration.GetSection("Config");
            #endregion

            #region configuration swagger 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Credyty Test",
                    Description = "Prueba técnica credyty",
                    Contact = new OpenApiContact
                    {
                        Name = "Jefferson Camacho Mejía",
                        Email = "jcam8225@gmail.com"
                    }
                });                              

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            #endregion         

            #region Dependency injection
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IContextDb, ContextDb>();     
            services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));
            services.AddScoped<ICreditRequestAplication, CreditRequestAplication>();
            services.AddScoped<IGeneralDataAplication, GeneralDataAplication>();
            services.AddScoped<IPersonAplication, PersonAplication>();
            services.AddScoped<ICreditRequestDomain, CreditRequestDomain>();
            services.AddScoped<IGeneralDataDomain, GeneralDataDomain>();
            services.AddScoped<IPersonDomain, PersonDomain>();           
            #endregion
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
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Credyty Test");
                });
            }
            else
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Credyty Test");
                });
            }

            app.UseRouting();
            app.UseCors(myPolicy);
            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
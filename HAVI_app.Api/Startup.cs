using HAVI_app.Api.DatabaseClasses;

using HAVI_app.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api
{
    public class Startup
    {
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment CurrentEnvironment { get; }
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnvironment)
        {
            Configuration = configuration;
            CurrentEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (CurrentEnvironment.IsEnvironment("Testing"))
            {
                services.AddDbContext<HAVIdatabaseContext>(options => options.UseInMemoryDatabase("TestingDB"));
            }
            else
            {
                services.AddDbContext<HAVIdatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }

            services.AddScoped<ProfileRepository>();
            services.AddScoped<SupplierRepository>();
            services.AddScoped<DepartmentIdRepository>();
            services.AddScoped<FreightResponsibilityRepository>();
            services.AddScoped<ILOSSortGroupRepository>();
            services.AddScoped<LocationRepository>();
            services.AddScoped<PackagingGroupRepository>();
            services.AddScoped<QIPNumberRepository>();
            services.AddScoped<SalesUnitRepository>();
            services.AddScoped<SetCurrencyRepository>();
            services.AddScoped<ILOSCategoryRepository>();
            services.AddScoped<ILOSOrderpickgroupRepository>();
            services.AddScoped<InformCostTypeRepository>();
            services.AddScoped<PrimaryDCILOSCodeRepository>();
            services.AddScoped<SupplierDeliveryUnitRepository>();
            services.AddScoped<VailedForCustomerRepository>();
            services.AddScoped<VatTaxCodeRepository>();
            services.AddScoped<ArticleRepository>();
            services.AddScoped<ArticleInformationRepository>();
            services.AddScoped<BundleRepository>();
            services.AddScoped<CompanyCodeRepository>();
            services.AddScoped<CountryRepository>();
            services.AddScoped<CreationCodeRepository>();
            services.AddScoped<InternalArticleInformationRepository>();
            services.AddScoped<OtherCostsForArticleRepository>();
            services.AddScoped<PurchaserRepository>();
            services.AddScoped<QIPNumberRepository>();
            services.AddScoped<SAPPlantRepository>();
            //services.AddScoped<AuthenticationStateProvider>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HAVI_app.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HAVI_app.Api v1"));
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

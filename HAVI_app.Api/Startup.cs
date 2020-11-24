using HAVI_app.Api.DatabaseClasses;
using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.AspNetCore.Builder;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HAVIdatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IArticleBundleRepository, ArticleBundleRepository>();
            services.AddScoped<IDepartmentIdRepository, DepartmentIdRepository>();
            services.AddScoped<IFreightResponsibilityRepository, FreightResponsibilityRepository>();
            services.AddScoped<IILOSSortGroupRepository, ILOSSortGroupRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IPackagingGroupRepository, PackagingGroupRepository>();
            services.AddScoped<IQIPNumberRepository, QIPNumberRepository>();
            services.AddScoped<ISalesUnitRepository, SalesUnitRepository>();
            services.AddScoped<ISetCurrencyRepository, SetCurrencyRepository>();
            services.AddScoped<IILOSCategoryRepository, ILOSCategoryRepository>();
            services.AddScoped<IILOSOrderpickgroupRepository, ILOSOrderpickgroupRepository>();
            services.AddScoped<IInformCostTypeRepository, InformCostTypeRepository>();
            services.AddScoped<IPrimaryDCILOSCodeRepository, PrimaryILOSDCCodeRepository>();
            services.AddScoped<ISupplierDeliveryUnitRepository, SupplierDeliveryUnitRepository>();
            services.AddScoped<IVailedForCustomerRepository, VailedForCustomerRepository>();
            services.AddScoped<IVatTaxCodeRepository, VatTaxCodeRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleInformationRepository, ArticleInformationRepository>();
            services.AddScoped<IBundleRepository, BundleRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICreationCodeRepository, CreationCodeRepository>();
            services.AddScoped<IInternalArticleInformationRepository, InternalArticleInformationRepository>();
            services.AddScoped<IOtherCostsForArticleRepository, OtherCostsForArticleRepository>();
            services.AddScoped<IPurchaserRepository, PurchaserRepository>();
            services.AddScoped<IQIPNumberRepository, QIPNumberRepository>();
            services.AddScoped<ISAPPlantRepository, SAPPlantRepository>();

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

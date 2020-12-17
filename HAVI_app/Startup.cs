using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HAVI_app.Models;
using HAVI_app.Services.Classes;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using HAVI_app.Classes;

namespace HAVI_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDbContext<HAVIdatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HAVIdatabaseContext")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton<InternalArticleInformation>();
            services.AddSingleton<Excel>();
            services.AddScoped<ArticleInformation>();

            #region AddHttpClient service for all the tables in the database
            services.AddHttpClient<ArticleInformationService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<ArticleService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<BundleService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<CompanyCodeService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<CountryService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<CreationCodeService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<DepartmentIdService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<FreightResponsibilityService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<ILOSCategoriesService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<ILOSOrderpickgroupService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<ILOSSortGroupService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<InformCostTypeService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<InternalArticleInformationService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<LocationService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<PackagingGroupService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<PrimaryDCILOSCodeService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<ProfileService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<PurchaserService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<QIPNumberService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<SalesUnitService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<SetCurrencyService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<SupplierDeliveryUnitService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<SupplierService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<VailedForCustomerService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<VatTaxCodeService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Structure");
            });
        }
    }
}
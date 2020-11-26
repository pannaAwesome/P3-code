using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HAVI_app.Models;
using HAVI_app.Services.Classes;
using System.Net.Http;

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

            services.AddHttpClient<SupplierService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<PurchaserService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<ProfileService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<CountryService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<ArticleBundleService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<ArticleInformationService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
            services.AddHttpClient<ArticleService>(client =>
            {
                client.BaseAddress = new System.Uri("https://localhost:44394");
            });
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

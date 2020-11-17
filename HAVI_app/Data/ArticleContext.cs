using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HAVI_app.Models;

namespace HAVI_app.Data
{
    public class ArticleContext : DbContext
    {
        public ArticleContext (DbContextOptions<ArticleContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<OtherCostsForArticle> OtherCostsForArticles { get; set; }
        public DbSet<PrimaryDCILOSCode> PrimaryDCILOSCodes { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Purchaser> Purchasers { get; set; }
        public DbSet<QIP> QIPs { get; set; }
        public DbSet<QIPNumber> QIPNumbers { get; set; }
        public DbSet<SalesUnit> SalesUnits { get; set; }
        public DbSet<SAPPlant> SAPPlants { get; set; }
        public DbSet<SetCurrency> SetCurrencies { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierDeliveryUnit> SupplierDeliveryUnits { get; set; }
        public DbSet<VailedForCustomer> VailedForCustomers { get; set; }
        public DbSet<VatTaxCode> VatTaxCodes { get; set; }
        public DbSet<ArticleBundle> ArticleBundles { get; set; }
        public DbSet<ArticleInformation> ArticleInformations { get; set; }
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DepartmentId> DepartmentIds { get; set; }
        public DbSet<FreightResponsibility> FreightResposibilities { get; set; }
        public DbSet<ILOSCategory> ILOSCategories { get; set; }
        public DbSet<ILOSOrderpickgroup> ILOSOrderpickgroups { get; set; }
        public DbSet<ILOSSortGroup> ILOSSortGroups { get; set; }
        public DbSet<InformCostType> InformCostTypes { get; set; }
        public DbSet<InternalArticleInformation> InternalArticleInformations { get; set; }
        public DbSet<Location> Locations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().ToTable("Article");
            modelBuilder.Entity<ArticleBundle>().ToTable("ArticleBundle");
            modelBuilder.Entity<ArticleInformation>().ToTable("ArticleInformation");
            modelBuilder.Entity<Bundle>().ToTable("Bundle");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<DepartmentId>().ToTable("DepartmentId");
            modelBuilder.Entity<FreightResponsibility>().ToTable("FreightResponsibility");
            modelBuilder.Entity<ILOSCategory>().ToTable("ILOSCategory");
            modelBuilder.Entity<ILOSOrderpickgroup>().ToTable("ILOSOrderpickgroup");
            modelBuilder.Entity<ILOSSortGroup>().ToTable("ILOSSortgroup");
            modelBuilder.Entity<InformCostType>().ToTable("InformCostType");
            modelBuilder.Entity<InternalArticleInformation>().ToTable("InternalArticleInformation");
            modelBuilder.Entity<VatTaxCode>().ToTable("VatTaxCode");
            modelBuilder.Entity<VailedForCustomer>().ToTable("VailedForCustomer");
            modelBuilder.Entity<SupplierDeliveryUnit>().ToTable("SupplierDeliveryUnit");
            modelBuilder.Entity<SetCurrency>().ToTable("SetCurrency");
            modelBuilder.Entity<SalesUnit>().ToTable("SalesUnit");
            modelBuilder.Entity<QIPNumber>().ToTable("QIPNumber");
            modelBuilder.Entity<QIP>().ToTable("QIP");
            modelBuilder.Entity<Purchaser>().ToTable("Purchaser");
            modelBuilder.Entity<Profile>().ToTable("Profile");
            modelBuilder.Entity<PrimaryDCILOSCode>().ToTable("PrimaryDCILOSCode");
            modelBuilder.Entity<OtherCostsForArticle>().ToTable("OtherCostsForArticle");
            modelBuilder.Entity<Location>().ToTable("Location");
        }
    }
}

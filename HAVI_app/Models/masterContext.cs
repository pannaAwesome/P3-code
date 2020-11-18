using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HAVI_app.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleBundle> ArticleBundles { get; set; }
        public virtual DbSet<ArticleInformation> ArticleInformations { get; set; }
        public virtual DbSet<Bundle> Bundles { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DeparmentId> DeparmentIds { get; set; }
        public virtual DbSet<FreightResponsibility> FreightResponsibilities { get; set; }
        public virtual DbSet<Iloscategory> Iloscategories { get; set; }
        public virtual DbSet<Ilosorderpickgroup> Ilosorderpickgroups { get; set; }
        public virtual DbSet<IlossortGroup> IlossortGroups { get; set; }
        public virtual DbSet<InformCostType> InformCostTypes { get; set; }
        public virtual DbSet<InternalArticleInformation> InternalArticleInformations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<OtherCostsForArticle> OtherCostsForArticles { get; set; }
        public virtual DbSet<PrimaryDciloscode> PrimaryDciloscodes { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Purchaser> Purchasers { get; set; }
        public virtual DbSet<Qip> Qips { get; set; }
        public virtual DbSet<Qipnumber> Qipnumbers { get; set; }
        public virtual DbSet<SalesUnit> SalesUnits { get; set; }
        public virtual DbSet<Sapplant> Sapplants { get; set; }
        public virtual DbSet<SetCurrency> SetCurrencies { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierDeliveryUnit> SupplierDeliveryUnits { get; set; }
        public virtual DbSet<VailedForCustomer> VailedForCustomers { get; set; }
        public virtual DbSet<VatTaxCode> VatTaxCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.HasIndex(e => e.Id, "UQ__Article__3214EC26DE96D619")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ArticleInformationId).HasColumnName("ArticleInformationID");

                entity.Property(e => e.ArticleState).HasColumnType("text");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ErrorMessage).HasColumnType("text");

                entity.Property(e => e.ErrorOwner).HasColumnType("text");

                entity.Property(e => e.InternalArticleInformationId).HasColumnName("InternalArticleInformationID");

                entity.Property(e => e.PurchaserId).HasColumnName("PurchaserID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.VailedForCustomer).HasColumnType("text");

                entity.HasOne(d => d.ArticleInformation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.ArticleInformationId)
                    .HasConstraintName("FK__Article__Article__55DFB4D9");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Article__Country__54EB90A0");

                entity.HasOne(d => d.InternalArticleInformation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.InternalArticleInformationId)
                    .HasConstraintName("FK__Article__Interna__57C7FD4B");

                entity.HasOne(d => d.Purchaser)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.PurchaserId)
                    .HasConstraintName("FK__Article__Purchas__56D3D912");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__Article__Supplie__58BC2184");
            });

            modelBuilder.Entity<ArticleBundle>(entity =>
            {
                entity.ToTable("ArticleBundle");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bundle).HasColumnType("text");
            });

            modelBuilder.Entity<ArticleInformation>(entity =>
            {
                entity.ToTable("ArticleInformation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArticleName).HasColumnType("text");

                entity.Property(e => e.Class).HasColumnType("text");

                entity.Property(e => e.ClassificationCode).HasColumnType("text");

                entity.Property(e => e.CompanyLocation).HasColumnType("text");

                entity.Property(e => e.CompanyName).HasColumnType("text");

                entity.Property(e => e.CountryOfOrigin).HasColumnType("text");

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.FreightResponsibility).HasColumnType("text");

                entity.Property(e => e.Gtinnumber).HasColumnName("GTINNumber");

                entity.Property(e => e.ImportedFrom).HasColumnType("text");

                entity.Property(e => e.Salesunit).HasColumnType("text");

                entity.Property(e => e.SetCurrency).HasColumnType("text");

                entity.Property(e => e.SpecialInformation).HasColumnType("text");

                entity.Property(e => e.SupplierArticleName).HasColumnType("text");

                entity.Property(e => e.TollTarifNumber).HasColumnType("text");
            });

            modelBuilder.Entity<Bundle>(entity =>
            {
                entity.ToTable("Bundle");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArticleBundle).HasColumnType("text");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryCode).HasColumnType("text");

                entity.Property(e => e.CountryName).HasColumnType("text");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");
            });

            modelBuilder.Entity<DeparmentId>(entity =>
            {
                entity.ToTable("DeparmentId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Department).HasColumnType("text");
            });

            modelBuilder.Entity<FreightResponsibility>(entity =>
            {
                entity.ToTable("FreightResponsibility");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Responsibility).HasColumnType("text");
            });

            modelBuilder.Entity<Iloscategory>(entity =>
            {
                entity.ToTable("ILOSCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category).HasColumnType("text");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");
            });

            modelBuilder.Entity<Ilosorderpickgroup>(entity =>
            {
                entity.ToTable("ILOSOrderpickgroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Orderpickgroup).HasColumnType("text");
            });

            modelBuilder.Entity<IlossortGroup>(entity =>
            {
                entity.ToTable("ILOSSortGroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SortGroup).HasColumnType("text");
            });

            modelBuilder.Entity<InformCostType>(entity =>
            {
                entity.ToTable("InformCostType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CostType).HasColumnType("text");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");
            });

            modelBuilder.Entity<InternalArticleInformation>(entity =>
            {
                entity.ToTable("InternalArticleInformation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BosSap).HasColumnName("BOS_SAP");

                entity.Property(e => e.Bosnumber).HasColumnName("BOSNumber");

                entity.Property(e => e.Carlanumber).HasColumnName("CARLANumber");

                entity.Property(e => e.ClassificationCode).HasColumnType("text");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("text")
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.EanSap).HasColumnName("EAN_SAP");

                entity.Property(e => e.Eannumber).HasColumnName("EANNumber");

                entity.Property(e => e.GrinSap).HasColumnName("GRIN_SAP");

                entity.Property(e => e.Grinnumber).HasColumnName("GRINNumber");

                entity.Property(e => e.Gtinnumber).HasColumnName("GTINNumber");

                entity.Property(e => e.Iloscategory)
                    .HasColumnType("text")
                    .HasColumnName("ILOSCategory");

                entity.Property(e => e.IlosorderPickGroup)
                    .HasColumnType("text")
                    .HasColumnName("ILOSOrderPickGroup");

                entity.Property(e => e.IlossortGroup)
                    .HasColumnType("text")
                    .HasColumnName("ILOSSortGroup");

                entity.Property(e => e.InnerPackingIlos)
                    .HasColumnType("text")
                    .HasColumnName("InnerPackingILOS");

                entity.Property(e => e.Lrinnumber).HasColumnName("LRINNumber");

                entity.Property(e => e.NewIlosarticleNumber).HasColumnName("NewILOSArticleNumber");

                entity.Property(e => e.PackagingGroup).HasColumnType("text");

                entity.Property(e => e.PrimaryDcIloscode).HasColumnName("PrimaryDC_ILOSCode");

                entity.Property(e => e.ReferenceIlosnumber).HasColumnName("ReferenceILOSNumber");

                entity.Property(e => e.ReferenceSapmaterial).HasColumnName("ReferenceSAPMaterial");

                entity.Property(e => e.Sprnnumber).HasColumnName("SPRNNumber");

                entity.Property(e => e.SupplierIdIlos).HasColumnName("SupplierID_ILOS");

                entity.Property(e => e.TextPurchaseNumber).HasColumnType("text");

                entity.Property(e => e.VatTaxcode)
                    .HasColumnType("text")
                    .HasColumnName("VAT_TAXCode");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country).HasColumnType("text");
            });

            modelBuilder.Entity<OtherCostsForArticle>(entity =>
            {
                entity.ToTable("OtherCostsForArticle");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArticleInformationId).HasColumnName("ArticleInformationID");

                entity.Property(e => e.InformCostType).HasColumnType("text");
            });

            modelBuilder.Entity<PrimaryDciloscode>(entity =>
            {
                entity.ToTable("PrimaryDCILOSCode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.PrimaryCode).HasColumnType("text");

                entity.Property(e => e.Sapplant)
                    .HasColumnType("text")
                    .HasColumnName("SAPPlant");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.PrimaryDciloscodes)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__PrimaryDC__Count__4A6E022D");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password).HasColumnType("text");

                entity.Property(e => e.Username).HasColumnType("text");
            });

            modelBuilder.Entity<Purchaser>(entity =>
            {
                entity.ToTable("Purchaser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Purchasers)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Purchaser__Count__4E3E9311");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Purchasers)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK__Purchaser__Profi__4D4A6ED8");
            });

            modelBuilder.Entity<Qip>(entity =>
            {
                entity.ToTable("QIP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InternalArticleInformationId).HasColumnName("InternalArticleInformationID");

                entity.Property(e => e.QipanswerOptions)
                    .HasColumnType("text")
                    .HasColumnName("QIPAnswerOptions");

                entity.Property(e => e.Qipdescription)
                    .HasColumnType("text")
                    .HasColumnName("QIPDescription");

                entity.Property(e => e.Qipfrequency)
                    .HasColumnType("text")
                    .HasColumnName("QIPFrequency");

                entity.Property(e => e.QipfrequencyType)
                    .HasColumnType("text")
                    .HasColumnName("QIPFrequencyType");

                entity.Property(e => e.QiphighBoundary)
                    .HasColumnType("text")
                    .HasColumnName("QIPHighBoundary");

                entity.Property(e => e.QiplowBoundary)
                    .HasColumnType("text")
                    .HasColumnName("QIPLowBoundary");

                entity.Property(e => e.QipnameNumber)
                    .HasColumnType("text")
                    .HasColumnName("QIPNameNumber");

                entity.Property(e => e.Qipokvalue)
                    .HasColumnType("text")
                    .HasColumnName("QIPOKValue");

                entity.Property(e => e.QipsetAnswer)
                    .HasColumnType("text")
                    .HasColumnName("QIPSetAnswer");
            });

            modelBuilder.Entity<Qipnumber>(entity =>
            {
                entity.ToTable("QIPNumber");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnswerOptions).HasColumnType("text");

                entity.Property(e => e.Qipdesribtion)
                    .HasColumnType("text")
                    .HasColumnName("QIPDesribtion");

                entity.Property(e => e.QipnumberName)
                    .HasColumnType("text")
                    .HasColumnName("QIPNumberName");
            });

            modelBuilder.Entity<SalesUnit>(entity =>
            {
                entity.ToTable("SalesUnit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Unit).HasColumnType("text");
            });

            modelBuilder.Entity<Sapplant>(entity =>
            {
                entity.ToTable("SAPPlant");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InternalArticleInformationId).HasColumnName("InternalArticleInformationID");

                entity.Property(e => e.SapplantName)
                    .HasColumnType("text")
                    .HasColumnName("SAPPlantName");

                entity.Property(e => e.SapplantValue).HasColumnName("SAPPlantValue");
            });

            modelBuilder.Entity<SetCurrency>(entity =>
            {
                entity.ToTable("SetCurrency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Currency).HasColumnType("text");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyLocation).HasColumnType("text");

                entity.Property(e => e.CompanyName).HasColumnType("text");

                entity.Property(e => e.FreightResponsibility).HasColumnType("text");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");
            });

            modelBuilder.Entity<SupplierDeliveryUnit>(entity =>
            {
                entity.ToTable("SupplierDeliveryUnit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Unit).HasColumnType("text");
            });

            modelBuilder.Entity<VailedForCustomer>(entity =>
            {
                entity.ToTable("VailedForCustomer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Customer).HasColumnType("text");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.VailedForCustomers)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__VailedFor__Count__511AFFBC");
            });

            modelBuilder.Entity<VatTaxCode>(entity =>
            {
                entity.ToTable("VatTaxCode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasColumnType("text");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

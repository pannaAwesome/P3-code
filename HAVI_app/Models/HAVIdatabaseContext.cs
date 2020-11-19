using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HAVI_app.Models
{
    public partial class HAVIdatabaseContext : DbContext
    {
        public HAVIdatabaseContext()
        {
        }

        public HAVIdatabaseContext(DbContextOptions<HAVIdatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleBundle> ArticleBundles { get; set; }
        public virtual DbSet<ArticleInformation> ArticleInformations { get; set; }
        public virtual DbSet<Bundle> Bundles { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DepartmentId> DeparmentIds { get; set; }
        public virtual DbSet<PackagingGroup> PackagingGroups { get; set; }
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
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=HAVIdatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.HasIndex(e => e.Id, "UQ__Article__3214EC26473E7B8A")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ArticleInformationId).HasColumnName("ArticleInformationID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ErrorMessage).HasColumnType("text");

                entity.Property(e => e.ErrorOwner).HasColumnType("text");

                entity.Property(e => e.InternalArticleInformationId).HasColumnName("InternalArticleInformationID");

                entity.Property(e => e.PurchaserId).HasColumnName("PurchaserID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.VailedForCustomer)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.ArticleInformation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.ArticleInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Article__Article__34C8D9D1");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Article__Country__35BCFE0A");

                entity.HasOne(d => d.InternalArticleInformation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.InternalArticleInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Article__Interna__36B12243");

                entity.HasOne(d => d.Purchaser)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.PurchaserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Article__Purchas__37A5467C");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Article__Supplie__38996AB5");
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

                entity.Property(e => e.CompanyLocation)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CountryOfOrigin).HasColumnType("text");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FreightResponsibility)
                    .IsRequired()
                    .HasColumnType("text");

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

                entity.Property(e => e.InternalArticleInformationId).HasColumnName("InternalArticleInformationID");

                entity.HasOne(d => d.InternalArticleInformation)
                    .WithMany(p => p.Bundles)
                    .HasForeignKey(d => d.InternalArticleInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bundle__Internal__3D5E1FD2");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CreationCode)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Country__Profile__267ABA7A");
            });

            modelBuilder.Entity<DepartmentId>(entity =>
            {
                entity.ToTable("DepartmentId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Department).HasColumnType("text");
            });

            modelBuilder.Entity<PackagingGroup>(entity =>
            {
                entity.ToTable("PackagingGroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Group).HasColumnType("text");
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

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Iloscategories)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ILOSCateg__Count__440B1D61");
            });

            modelBuilder.Entity<Ilosorderpickgroup>(entity =>
            {
                entity.ToTable("ILOSOrderpickgroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Orderpickgroup).HasColumnType("text");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Ilosorderpickgroups)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ILOSOrder__Count__46E78A0C");
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

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.InformCostTypes)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InformCos__Count__4BAC3F29");
            });

            modelBuilder.Entity<InternalArticleInformation>(entity =>
            {
                entity.ToTable("InternalArticleInformation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bosnumber).HasColumnName("BOSNumber");

                entity.Property(e => e.Carlanumber).HasColumnName("CARLANumber");

                entity.Property(e => e.ClassificationCode).HasColumnType("text");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("text")
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.Eannumber).HasColumnName("EANNumber");

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

                entity.Property(e => e.InsertBosSap).HasColumnName("Insert_BOS_SAP");

                entity.Property(e => e.InsertEanSap).HasColumnName("Insert_EAN_SAP");

                entity.Property(e => e.InsertGrinSap).HasColumnName("Insert_GRIN_SAP");

                entity.Property(e => e.Lrinnumber).HasColumnName("LRINNumber");

                entity.Property(e => e.NewIlosarticleNumber)
                    .HasColumnType("text")
                    .HasColumnName("NewILOSArticleNumber");

                entity.Property(e => e.PackagingGroup).HasColumnType("text");

                entity.Property(e => e.PrimaryDcIloscode).HasColumnName("PrimaryDC_ILOSCode");

                entity.Property(e => e.ReferenceIlosnumber)
                    .HasColumnType("text")
                    .HasColumnName("ReferenceILOSNumber");

                entity.Property(e => e.ReferenceSapmaterial).HasColumnName("ReferenceSAPMaterial");

                entity.Property(e => e.Sprnnumber).HasColumnName("SPRNNumber");

                entity.Property(e => e.SupplierDeliveryUnit).HasColumnType("text");

                entity.Property(e => e.SupplierIdIlos).HasColumnName("SupplierID_ILOS");

                entity.Property(e => e.TransitTimeForHavi).HasColumnName("TransitTimeForHAVI");

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

                entity.HasOne(d => d.ArticleInformation)
                    .WithMany(p => p.OtherCostsForArticles)
                    .HasForeignKey(d => d.ArticleInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OtherCost__Artic__5070F446");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PrimaryDC__Count__534D60F1");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("text");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Purchaser__Count__29572725");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Purchasers)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Purchaser__Profi__2A4B4B5E");
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

                entity.HasOne(d => d.InternalArticleInformation)
                    .WithMany(p => p.Qips)
                    .HasForeignKey(d => d.InternalArticleInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__QIP__InternalArt__5629CD9C");
            });

            modelBuilder.Entity<Qipnumber>(entity =>
            {
                entity.ToTable("QIPNumber");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnswerOptions).HasColumnType("text");
                entity.Property(e => e.SetAnswer).HasColumnName("SetAnswer");
                entity.Property(e => e.OKValue).HasColumnName("OKValue");
                entity.Property(e => e.LowBoundary).HasColumnName("LowBoundary");
                entity.Property(e => e.HighBoundary).HasColumnName("HighBoundary");
                entity.Property(e => e.FrequencyType).HasColumnName("FrequencyType");
                entity.Property(e => e.Frequency).HasColumnName("Frequency");

                entity.Property(e => e.Qipdescription)
                    .HasColumnType("text")
                    .HasColumnName("QIPDescription");

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

                entity.HasOne(d => d.InternalArticleInformation)
                    .WithMany(p => p.Sapplants)
                    .HasForeignKey(d => d.InternalArticleInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SAPPlant__Intern__5CD6CB2B");
            });

            modelBuilder.Entity<SetCurrency>(entity =>
            {
                entity.ToTable("SetCurrency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyLocation)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FreightResponsibility)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Supplier__Profil__2D27B809");
            });

            modelBuilder.Entity<SupplierDeliveryUnit>(entity =>
            {
                entity.ToTable("SupplierDeliveryUnit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Unit).HasColumnType("text");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.SupplierDeliveryUnits)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplierD__Count__619B8048");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VailedFor__Count__6477ECF3");
            });

            modelBuilder.Entity<VatTaxCode>(entity =>
            {
                entity.ToTable("VatTaxCode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasColumnType("text");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.VatTaxCodes)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VatTaxCod__Count__6754599E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

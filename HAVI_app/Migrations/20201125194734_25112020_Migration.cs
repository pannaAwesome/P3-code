using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HAVI_app.Migrations
{
    public partial class _25112020_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleBundle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bundle = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleBundle", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArticleInformation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    CompanyLocation = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PalletExchange = table.Column<int>(type: "int", nullable: false),
                    FreightResponsibility = table.Column<string>(type: "text", nullable: false),
                    SpecialInformation = table.Column<string>(type: "text", nullable: true),
                    TransportBooking = table.Column<int>(type: "int", nullable: true),
                    TransitTime = table.Column<int>(type: "int", nullable: true),
                    DangerousGoods = table.Column<int>(type: "int", nullable: true),
                    Class = table.Column<string>(type: "text", nullable: true),
                    ClassificationCode = table.Column<string>(type: "text", nullable: true),
                    ArticleName = table.Column<string>(type: "text", nullable: true),
                    Salesunit = table.Column<string>(type: "text", nullable: true),
                    ArticlesPerSalesunit = table.Column<int>(type: "int", nullable: true),
                    SupplierArticleName = table.Column<string>(type: "text", nullable: true),
                    GTINNumber = table.Column<int>(type: "int", nullable: true),
                    Shelflife = table.Column<int>(type: "int", nullable: true),
                    MinimumShelflife = table.Column<int>(type: "int", nullable: true),
                    OrganicArticle = table.Column<int>(type: "int", nullable: true),
                    LengthPerSalesunit = table.Column<double>(type: "float", nullable: true),
                    WidthPerSalesunit = table.Column<double>(type: "float", nullable: true),
                    HeightPerSalesunit = table.Column<double>(type: "float", nullable: true),
                    NetWeightPerSalesunit = table.Column<double>(type: "float", nullable: true),
                    GrossWeightPerSalesunit = table.Column<double>(type: "float", nullable: true),
                    CartonsPerPallet = table.Column<int>(type: "int", nullable: true),
                    CartonsPerLayer = table.Column<int>(type: "int", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "text", nullable: true),
                    ImportedFrom = table.Column<string>(type: "text", nullable: true),
                    TollTarifNumber = table.Column<string>(type: "text", nullable: true),
                    MinimumOrderQuantity = table.Column<int>(type: "int", nullable: true),
                    TemperatureTransportationMin = table.Column<double>(type: "float", nullable: true),
                    TemperatureTransportationMax = table.Column<double>(type: "float", nullable: true),
                    TemperatureStorageMin = table.Column<double>(type: "float", nullable: true),
                    TemperatureStorageMax = table.Column<double>(type: "float", nullable: true),
                    LeadTime = table.Column<int>(type: "int", nullable: true),
                    SetCurrency = table.Column<string>(type: "text", nullable: true),
                    PurchasePrice = table.Column<double>(type: "float", nullable: true),
                    OtherCosts = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleInformation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CreationCode",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreationCode", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentId",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentId", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FreightResponsibility",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Responsibility = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreightResponsibility", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ILOSSortGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortGroup = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ILOSSortGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InternalArticleInformation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierID_ILOS = table.Column<int>(type: "int", nullable: true),
                    CompanyCode = table.Column<int>(type: "int", nullable: true),
                    SupplierDeliveryUnit = table.Column<string>(type: "text", nullable: true),
                    RemainShelfStore = table.Column<int>(type: "int", nullable: true),
                    ILOSOrderPickGroup = table.Column<string>(type: "text", nullable: true),
                    ILOSSortGroup = table.Column<string>(type: "text", nullable: true),
                    NewILOSArticleNumber = table.Column<string>(type: "text", nullable: true),
                    ReferenceILOSNumber = table.Column<string>(type: "text", nullable: true),
                    ReferenceSAPMaterial = table.Column<int>(type: "int", nullable: true),
                    ILOSCategory = table.Column<string>(type: "text", nullable: true),
                    VAT_TAXCode = table.Column<string>(type: "text", nullable: true),
                    DepartmentID = table.Column<string>(type: "text", nullable: true),
                    InnerPackingILOS = table.Column<string>(type: "text", nullable: true),
                    CurrencyRate = table.Column<double>(type: "float", nullable: true),
                    PriceInCountryCurrency = table.Column<double>(type: "float", nullable: true),
                    TextPurchaseNumber = table.Column<int>(type: "int", nullable: true),
                    RegisterShelfLife = table.Column<int>(type: "int", nullable: true),
                    ClassificationCode = table.Column<string>(type: "text", nullable: true),
                    PackagingGroup = table.Column<string>(type: "text", nullable: true),
                    Insert_EAN_SAP = table.Column<int>(type: "int", nullable: true),
                    Insert_GRIN_SAP = table.Column<int>(type: "int", nullable: true),
                    Insert_BOS_SAP = table.Column<int>(type: "int", nullable: true),
                    EANNumber = table.Column<int>(type: "int", nullable: true),
                    GRINNumber = table.Column<int>(type: "int", nullable: true),
                    BOSNumber = table.Column<int>(type: "int", nullable: true),
                    GTINNumber = table.Column<int>(type: "int", nullable: true),
                    LRINNumber = table.Column<int>(type: "int", nullable: true),
                    SPRNNumber = table.Column<int>(type: "int", nullable: true),
                    CARLANumber = table.Column<int>(type: "int", nullable: true),
                    PrimaryDC_ILOSCode = table.Column<int>(type: "int", nullable: true),
                    TransitTimeForHAVI = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalArticleInformation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PackagingGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagingGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QIPNumber",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QIPNumberName = table.Column<string>(type: "text", nullable: true),
                    QIPDescription = table.Column<string>(type: "text", nullable: true),
                    AnswerOptions = table.Column<string>(type: "text", nullable: true),
                    SetAnswer = table.Column<int>(type: "int", nullable: false),
                    OKValue = table.Column<int>(type: "int", nullable: false),
                    LowBoundary = table.Column<int>(type: "int", nullable: false),
                    HighBoundary = table.Column<int>(type: "int", nullable: false),
                    FrequencyType = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QIPNumber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SalesUnit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesUnit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SetCurrency",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetCurrency", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileID = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    CompanyLocation = table.Column<string>(type: "text", nullable: false),
                    PalletExchange = table.Column<int>(type: "int", nullable: false),
                    FreightResponsibility = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OtherCostsForArticle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleInformationID = table.Column<int>(type: "int", nullable: false),
                    InformCostType = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCostsForArticle", x => x.ID);
                    table.ForeignKey(
                        name: "FK__OtherCost__Artic__5070F446",
                        column: x => x.ArticleInformationID,
                        principalTable: "ArticleInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bundle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalArticleInformationID = table.Column<int>(type: "int", nullable: false),
                    ArticleBundle = table.Column<string>(type: "text", nullable: true),
                    ArticleBundleQuantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundle", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Bundle__Internal__3D5E1FD2",
                        column: x => x.InternalArticleInformationID,
                        principalTable: "InternalArticleInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QIP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalArticleInformationID = table.Column<int>(type: "int", nullable: false),
                    QIPNameNumber = table.Column<string>(type: "text", nullable: true),
                    QIPDescription = table.Column<string>(type: "text", nullable: true),
                    QIPAnswerOptions = table.Column<string>(type: "text", nullable: true),
                    QIPSetAnswer = table.Column<string>(type: "text", nullable: true),
                    QIPOKValue = table.Column<string>(type: "text", nullable: true),
                    QIPLowBoundary = table.Column<string>(type: "text", nullable: true),
                    QIPHighBoundary = table.Column<string>(type: "text", nullable: true),
                    QIPFrequencyType = table.Column<string>(type: "text", nullable: true),
                    QIPFrequency = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QIP", x => x.ID);
                    table.ForeignKey(
                        name: "FK__QIP__InternalArt__5629CD9C",
                        column: x => x.InternalArticleInformationID,
                        principalTable: "InternalArticleInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SAPPlant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalArticleInformationID = table.Column<int>(type: "int", nullable: false),
                    SAPPlantName = table.Column<string>(type: "text", nullable: true),
                    SAPPlantValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAPPlant", x => x.ID);
                    table.ForeignKey(
                        name: "FK__SAPPlant__Intern__5CD6CB2B",
                        column: x => x.InternalArticleInformationID,
                        principalTable: "InternalArticleInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaserID = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    ArticleInformationID = table.Column<int>(type: "int", nullable: false),
                    InternalArticleInformationID = table.Column<int>(type: "int", nullable: false),
                    VailedForCustomer = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    ArticleInformationCompleted = table.Column<int>(type: "int", nullable: false),
                    InternalArticalInformationCompleted = table.Column<int>(type: "int", nullable: false),
                    ArticleState = table.Column<int>(type: "int", nullable: false),
                    ErrorReported = table.Column<int>(type: "int", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    ErrorOwner = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Article__Article__34C8D9D1",
                        column: x => x.ArticleInformationID,
                        principalTable: "ArticleInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Article__Interna__36B12243",
                        column: x => x.InternalArticleInformationID,
                        principalTable: "InternalArticleInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Article__Supplie__38996AB5",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ILOSCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "text", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ILOSCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ILOSOrderpickgroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orderpickgroup = table.Column<string>(type: "text", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ILOSOrderpickgroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InformCostType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostType = table.Column<string>(type: "text", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformCostType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryDCILOSCode",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryCode = table.Column<string>(type: "text", nullable: true),
                    SAPPlant = table.Column<string>(type: "text", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryDCILOSCode", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Purchaser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileID = table.Column<int>(type: "int", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchaser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Usertype = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Purchaser__Profi__2A4B4B5E",
                        column: x => x.ID,
                        principalTable: "Purchaser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Supplier__Profil__2D27B809",
                        column: x => x.ID,
                        principalTable: "Supplier",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileID = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "text", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Country__Profile__267ABA7A",
                        column: x => x.ProfileID,
                        principalTable: "Profile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierDeliveryUnit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierDeliveryUnit", x => x.ID);
                    table.ForeignKey(
                        name: "FK__SupplierD__Count__619B8048",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VailedForCustomer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(type: "text", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VailedForCustomer", x => x.ID);
                    table.ForeignKey(
                        name: "FK__VailedFor__Count__6477ECF3",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VatTaxCode",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatTaxCode", x => x.ID);
                    table.ForeignKey(
                        name: "FK__VatTaxCod__Count__6754599E",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_ArticleInformationID",
                table: "Article",
                column: "ArticleInformationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Article_CountryID",
                table: "Article",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Article_InternalArticleInformationID",
                table: "Article",
                column: "InternalArticleInformationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Article_PurchaserID",
                table: "Article",
                column: "PurchaserID");

            migrationBuilder.CreateIndex(
                name: "IX_Article_SupplierID",
                table: "Article",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "UQ__Article__3214EC26473E7B8A",
                table: "Article",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__ArticleBundle__25112020",
                table: "ArticleBundle",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__ArticleInformation__25112020",
                table: "ArticleInformation",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bundle_InternalArticleInformationID",
                table: "Bundle",
                column: "InternalArticleInformationID");

            migrationBuilder.CreateIndex(
                name: "UQ__Bundle__25112020",
                table: "Bundle",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_ProfileID",
                table: "Country",
                column: "ProfileID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Country__25112020",
                table: "Country",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__CreationCode__25112020",
                table: "CreationCode",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__DepartmentId__3214EC26473E7B8A",
                table: "DepartmentId",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Freight__3214EC26473E7B8A",
                table: "FreightResponsibility",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ILOSCategory_CountryID",
                table: "ILOSCategory",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "UQ__Category__3214EC26473E7B8A",
                table: "ILOSCategory",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ILOSOrderpickgroup_CountryID",
                table: "ILOSOrderpickgroup",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "UQ__Orderpickgroup__3214EC26473E7B8A",
                table: "ILOSOrderpickgroup",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Sortgroup__3214EC26473E7B8A",
                table: "ILOSSortGroup",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformCostType_CountryID",
                table: "InformCostType",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "UQ__InformCostType__3214EC26473E7B8A",
                table: "InformCostType",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Internal__3214EC26473E7B8A",
                table: "InternalArticleInformation",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Location__3214EC26473E7B8A",
                table: "Location",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtherCostsForArticle_ArticleInformationID",
                table: "OtherCostsForArticle",
                column: "ArticleInformationID");

            migrationBuilder.CreateIndex(
                name: "UQ__OtherCosts__3214EC26473E7B8A",
                table: "OtherCostsForArticle",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__PackagingGroup__25112020",
                table: "PackagingGroup",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryDCILOSCode_CountryID",
                table: "PrimaryDCILOSCode",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "UQ__PrimaryCode__3214EC26473E7B8A",
                table: "PrimaryDCILOSCode",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Profile__3214EC26473E7B8A",
                table: "Profile",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchaser_CountryID",
                table: "Purchaser",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "UQ__Purchaser__3214EC26473E7B8A",
                table: "Purchaser",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QIP_InternalArticleInformationID",
                table: "QIP",
                column: "InternalArticleInformationID");

            migrationBuilder.CreateIndex(
                name: "UQ__QIP__3214EC26473E7B8A",
                table: "QIP",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__QIPNumber__3214EC26473E7B8A",
                table: "QIPNumber",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__SalesUnit__3214EC26473E7B8A",
                table: "SalesUnit",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SAPPlant_InternalArticleInformationID",
                table: "SAPPlant",
                column: "InternalArticleInformationID");

            migrationBuilder.CreateIndex(
                name: "UQ__SapPlant__3214EC26473E7B8A",
                table: "SAPPlant",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Currency__3214EC26473E7B8A",
                table: "SetCurrency",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Supplier__3214EC26473E7B8A",
                table: "Supplier",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierDeliveryUnit_CountryID",
                table: "SupplierDeliveryUnit",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "UQ__DeliveryUnit__3214EC26473E7B8A",
                table: "SupplierDeliveryUnit",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VailedForCustomer_CountryID",
                table: "VailedForCustomer",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__3214EC26473E7B8A",
                table: "VailedForCustomer",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VatTaxCode_CountryID",
                table: "VatTaxCode",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "UQ__VatTaxCode__3214EC26473E7B8A",
                table: "VatTaxCode",
                column: "ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Article__Country__35BCFE0A",
                table: "Article",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Article__Purchas__37A5467C",
                table: "Article",
                column: "PurchaserID",
                principalTable: "Purchaser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__ILOSCateg__Count__440B1D61",
                table: "ILOSCategory",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__ILOSOrder__Count__46E78A0C",
                table: "ILOSOrderpickgroup",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__InformCos__Count__4BAC3F29",
                table: "InformCostType",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__PrimaryDC__Count__534D60F1",
                table: "PrimaryDCILOSCode",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Purchaser__Count__29572725",
                table: "Purchaser",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Purchaser__Count__29572725",
                table: "Purchaser");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "ArticleBundle");

            migrationBuilder.DropTable(
                name: "Bundle");

            migrationBuilder.DropTable(
                name: "CreationCode");

            migrationBuilder.DropTable(
                name: "DepartmentId");

            migrationBuilder.DropTable(
                name: "FreightResponsibility");

            migrationBuilder.DropTable(
                name: "ILOSCategory");

            migrationBuilder.DropTable(
                name: "ILOSOrderpickgroup");

            migrationBuilder.DropTable(
                name: "ILOSSortGroup");

            migrationBuilder.DropTable(
                name: "InformCostType");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "OtherCostsForArticle");

            migrationBuilder.DropTable(
                name: "PackagingGroup");

            migrationBuilder.DropTable(
                name: "PrimaryDCILOSCode");

            migrationBuilder.DropTable(
                name: "QIP");

            migrationBuilder.DropTable(
                name: "QIPNumber");

            migrationBuilder.DropTable(
                name: "SalesUnit");

            migrationBuilder.DropTable(
                name: "SAPPlant");

            migrationBuilder.DropTable(
                name: "SetCurrency");

            migrationBuilder.DropTable(
                name: "SupplierDeliveryUnit");

            migrationBuilder.DropTable(
                name: "VailedForCustomer");

            migrationBuilder.DropTable(
                name: "VatTaxCode");

            migrationBuilder.DropTable(
                name: "ArticleInformation");

            migrationBuilder.DropTable(
                name: "InternalArticleInformation");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Purchaser");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}

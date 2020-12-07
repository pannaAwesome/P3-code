using Syncfusion.Drawing;
using Syncfusion.XlsIO;
using System.IO;
using HAVI_app.Models;
namespace HAVI_app.Classes
{
    public class Excel
    {
        /// <summary>
        /// Create a simple Excel document
        /// </summary>
        /// <returns>Return the created excel document as stream</returns>
        public MemoryStream CreateXlsIO(Article version)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;
                
                IWorkbook workbook = application.Workbooks.Create(2);
                IWorksheet sheet = workbook.Worksheets[1];
                #region Generate Excel
                sheet.Range["B3"].Number = version.InternalArticleInformation.CompanyCode;
                sheet.Range["B4"].Number = version.InternalArticleInformation.SupplierIdIlos;
                sheet.Range["B5"].Text = version.InternalArticleInformation.SupplierDeliveryUnit;
                sheet.Range["B6"].Number = version.InternalArticleInformation.RemainShelfStore;
                sheet.Range["B7"].Text = version.InternalArticleInformation.IlosorderPickGroup;
                sheet.Range["B8"].Text = version.InternalArticleInformation.IlossortGroup;
                sheet.Range["B9"].Text = version.InternalArticleInformation.NewIlosarticleNumber;
                sheet.Range["B10"].Text = version.InternalArticleInformation.ReferenceIlosnumber;
                sheet.Range["B11"].Number = version.InternalArticleInformation.ReferenceSapmaterial;
                sheet.Range["B12"].Text =  version.InternalArticleInformation.Iloscategory;
                sheet.Range["B13"].Text = version.InternalArticleInformation.VatTaxcode;
                sheet.Range["B14"].Text = version.InternalArticleInformation.DepartmentId;
                sheet.Range["B15"].Text =  version.InternalArticleInformation.InnerPackingIlos;
                sheet.Range["B16"].Number =  version.InternalArticleInformation.PriceInCountryCurrency;
                sheet.Range["B17"].Number =  version.InternalArticleInformation.TextPurchaseNumber;
                sheet.Range["B18"].Text =  version.InternalArticleInformation.InsertEanSap == 1 ? "yes" : "no";
                sheet.Range["B19"].Text =  version.InternalArticleInformation.InsertGrinSap == 1 ? "yes" : "no";
                sheet.Range["B20"].Text =  version.InternalArticleInformation.InsertBosSap == 1 ? "yes" : "no";

                sheet.Range["B25"].Number =  version.InternalArticleInformation.PrimaryDcIloscode;

                int cur = 26;
                foreach(Sapplant plant in version.InternalArticleInformation.Sapplants)
                {
                    sheet.Range["A" + cur].Text = plant.SapplantName;
                    sheet.Range["B" + cur].Text = plant.SapplantValue == 1 ? "yes" : "no";
                    cur++;
                }

                sheet.Range["B31"].Number = version.InternalArticleInformation.TransitTimeForHavi;


                sheet.Range["E8"].Text =  version.InternalArticleInformation.RegisterShelfLife == 1 ? "yes" : "no";

                sheet.Range["E26"].Text =  version.InternalArticleInformation.Eannumber;
                sheet.Range["E27"].Text =  version.InternalArticleInformation.Grinnumber;
                sheet.Range["E28"].Text =  version.InternalArticleInformation.Bosnumber;
                sheet.Range["E29"].Text = version.InternalArticleInformation.Gtinnumber;
                sheet.Range["E30"].Text = version.InternalArticleInformation.Lrinnumber;
                sheet.Range["E31"].Text = version.InternalArticleInformation.Sprnnumber;
                sheet.Range["E32"].Text = version.InternalArticleInformation.Carlanumber;


                sheet.Range["G7"].Text = version.InternalArticleInformation.Bundles[0].ArticleBundle;
                sheet.Range["G8"].Text = version.InternalArticleInformation.Bundles[1].ArticleBundle;
                sheet.Range["G9"].Text = version.InternalArticleInformation.Bundles[2].ArticleBundle;

                sheet.Range["H7"].Number = version.InternalArticleInformation.Bundles[0].ArticleBundleQuantity;
                sheet.Range["H8"].Number = version.InternalArticleInformation.Bundles[1].ArticleBundleQuantity;
                sheet.Range["H9"].Number = version.InternalArticleInformation.Bundles[2].ArticleBundleQuantity;


                sheet.Range["G16"].Text = version.InternalArticleInformation.Qips[0].QipnameNumber;
                sheet.Range["H16"].Text = version.InternalArticleInformation.Qips[0].Qipdescription;
                sheet.Range["I16"].Text = version.InternalArticleInformation.Qips[0].QipanswerOptions;
                sheet.Range["J16"].Text = version.InternalArticleInformation.Qips[0].QipsetAnswer;
                sheet.Range["K16"].Number = version.InternalArticleInformation.Qips[0].Qipokvalue;
                sheet.Range["L16"].Number = version.InternalArticleInformation.Qips[0].QiplowBoundary;
                sheet.Range["M16"].Number = version.InternalArticleInformation.Qips[0].QiphighBoundary;
                sheet.Range["N16"].Number = version.InternalArticleInformation.Qips[0].QipfrequencyType;
                sheet.Range["O16"].Number = version.InternalArticleInformation.Qips[0].Qipfrequency;

                sheet.Range["G17"].Text = version.InternalArticleInformation.Qips[1].QipnameNumber;
                sheet.Range["H17"].Text = version.InternalArticleInformation.Qips[1].Qipdescription;
                sheet.Range["I17"].Text = version.InternalArticleInformation.Qips[1].QipanswerOptions;
                sheet.Range["J17"].Text = version.InternalArticleInformation.Qips[1].QipsetAnswer;
                sheet.Range["K17"].Number = version.InternalArticleInformation.Qips[1].Qipokvalue;
                sheet.Range["L17"].Number = version.InternalArticleInformation.Qips[1].QiplowBoundary;
                sheet.Range["M17"].Number = version.InternalArticleInformation.Qips[1].QiphighBoundary;
                sheet.Range["N17"].Number = version.InternalArticleInformation.Qips[1].QipfrequencyType;
                sheet.Range["O17"].Number = version.InternalArticleInformation.Qips[1].Qipfrequency;

                sheet.Range["G18"].Text = version.InternalArticleInformation.Qips[2].QipnameNumber;
                sheet.Range["H18"].Text = version.InternalArticleInformation.Qips[2].Qipdescription;
                sheet.Range["I18"].Text = version.InternalArticleInformation.Qips[2].QipanswerOptions;
                sheet.Range["J18"].Text = version.InternalArticleInformation.Qips[2].QipsetAnswer;
                sheet.Range["K18"].Number = version.InternalArticleInformation.Qips[2].Qipokvalue;
                sheet.Range["L18"].Number = version.InternalArticleInformation.Qips[2].QiplowBoundary;
                sheet.Range["M18"].Number = version.InternalArticleInformation.Qips[2].QiphighBoundary;
                sheet.Range["N18"].Number = version.InternalArticleInformation.Qips[2].QipfrequencyType;
                sheet.Range["O18"].Number = version.InternalArticleInformation.Qips[2].Qipfrequency;

                sheet.Range["G19"].Text = version.InternalArticleInformation.Qips[3].QipnameNumber;
                sheet.Range["H19"].Text = version.InternalArticleInformation.Qips[3].Qipdescription;
                sheet.Range["I19"].Text = version.InternalArticleInformation.Qips[3].QipanswerOptions;
                sheet.Range["J19"].Text = version.InternalArticleInformation.Qips[3].QipsetAnswer;
                sheet.Range["K19"].Number = version.InternalArticleInformation.Qips[3].Qipokvalue;
                sheet.Range["L19"].Number = version.InternalArticleInformation.Qips[3].QiplowBoundary;
                sheet.Range["M19"].Number = version.InternalArticleInformation.Qips[3].QiphighBoundary;
                sheet.Range["N19"].Number = version.InternalArticleInformation.Qips[3].QipfrequencyType;
                sheet.Range["O19"].Number = version.InternalArticleInformation.Qips[3].Qipfrequency;

                sheet.Range["G20"].Text = version.InternalArticleInformation.Qips[4].QipnameNumber;
                sheet.Range["H20"].Text = version.InternalArticleInformation.Qips[4].Qipdescription;
                sheet.Range["I20"].Text = version.InternalArticleInformation.Qips[4].QipanswerOptions;
                sheet.Range["J20"].Text = version.InternalArticleInformation.Qips[4].QipsetAnswer;
                sheet.Range["K20"].Number = version.InternalArticleInformation.Qips[4].Qipokvalue;
                sheet.Range["L20"].Number = version.InternalArticleInformation.Qips[4].QiplowBoundary;
                sheet.Range["M20"].Number = version.InternalArticleInformation.Qips[4].QiphighBoundary;
                sheet.Range["N20"].Number = version.InternalArticleInformation.Qips[4].QipfrequencyType;
                sheet.Range["O20"].Number = version.InternalArticleInformation.Qips[4].Qipfrequency;

                sheet.Range["G21"].Text = version.InternalArticleInformation.Qips[5].QipnameNumber;
                sheet.Range["H21"].Text = version.InternalArticleInformation.Qips[5].Qipdescription;
                sheet.Range["I21"].Text = version.InternalArticleInformation.Qips[5].QipanswerOptions;
                sheet.Range["J21"].Text = version.InternalArticleInformation.Qips[5].QipsetAnswer;
                sheet.Range["K21"].Number = version.InternalArticleInformation.Qips[5].Qipokvalue;
                sheet.Range["L21"].Number = version.InternalArticleInformation.Qips[5].QiplowBoundary;
                sheet.Range["M21"].Number = version.InternalArticleInformation.Qips[5].QiphighBoundary;
                sheet.Range["N21"].Number = version.InternalArticleInformation.Qips[5].QipfrequencyType;
                sheet.Range["O21"].Number = version.InternalArticleInformation.Qips[5].Qipfrequency;

                sheet.Range["G22"].Text = version.InternalArticleInformation.Qips[6].QipnameNumber;
                sheet.Range["H22"].Text = version.InternalArticleInformation.Qips[6].Qipdescription;
                sheet.Range["I22"].Text = version.InternalArticleInformation.Qips[6].QipanswerOptions;
                sheet.Range["J22"].Text = version.InternalArticleInformation.Qips[6].QipsetAnswer;
                sheet.Range["K22"].Number = version.InternalArticleInformation.Qips[6].Qipokvalue;
                sheet.Range["L22"].Number = version.InternalArticleInformation.Qips[6].QiplowBoundary;
                sheet.Range["M22"].Number = version.InternalArticleInformation.Qips[6].QiphighBoundary;
                sheet.Range["N22"].Number = version.InternalArticleInformation.Qips[6].QipfrequencyType;
                sheet.Range["O22"].Number = version.InternalArticleInformation.Qips[6].Qipfrequency;

                sheet.Range["G23"].Text = version.InternalArticleInformation.Qips[7].QipnameNumber;
                sheet.Range["H23"].Text = version.InternalArticleInformation.Qips[7].Qipdescription;
                sheet.Range["I23"].Text = version.InternalArticleInformation.Qips[7].QipanswerOptions;
                sheet.Range["J23"].Text = version.InternalArticleInformation.Qips[7].QipsetAnswer;
                sheet.Range["K23"].Number = version.InternalArticleInformation.Qips[7].Qipokvalue;
                sheet.Range["L23"].Number = version.InternalArticleInformation.Qips[7].QiplowBoundary;
                sheet.Range["M23"].Number = version.InternalArticleInformation.Qips[7].QiphighBoundary;
                sheet.Range["N23"].Number = version.InternalArticleInformation.Qips[7].QipfrequencyType;
                sheet.Range["O23"].Number = version.InternalArticleInformation.Qips[7].Qipfrequency;

                sheet.Range["G24"].Text = version.InternalArticleInformation.Qips[8].QipnameNumber;
                sheet.Range["H24"].Text = version.InternalArticleInformation.Qips[8].Qipdescription;
                sheet.Range["I24"].Text = version.InternalArticleInformation.Qips[8].QipanswerOptions;
                sheet.Range["J24"].Text = version.InternalArticleInformation.Qips[8].QipsetAnswer;
                sheet.Range["K24"].Number = version.InternalArticleInformation.Qips[8].Qipokvalue;
                sheet.Range["L24"].Number = version.InternalArticleInformation.Qips[8].QiplowBoundary;
                sheet.Range["M24"].Number = version.InternalArticleInformation.Qips[8].QiphighBoundary;
                sheet.Range["N24"].Number = version.InternalArticleInformation.Qips[8].QipfrequencyType;
                sheet.Range["O24"].Number = version.InternalArticleInformation.Qips[8].Qipfrequency;

                sheet.Range["G25"].Text = version.InternalArticleInformation.Qips[9].QipnameNumber;
                sheet.Range["H25"].Text = version.InternalArticleInformation.Qips[9].Qipdescription;
                sheet.Range["I25"].Text = version.InternalArticleInformation.Qips[9].QipanswerOptions;
                sheet.Range["J25"].Text = version.InternalArticleInformation.Qips[9].QipsetAnswer;
                sheet.Range["K25"].Number = version.InternalArticleInformation.Qips[9].Qipokvalue;
                sheet.Range["L25"].Number = version.InternalArticleInformation.Qips[9].QiplowBoundary;
                sheet.Range["M25"].Number = version.InternalArticleInformation.Qips[9].QiphighBoundary;
                sheet.Range["N25"].Number = version.InternalArticleInformation.Qips[9].QipfrequencyType;
                sheet.Range["O25"].Number = version.InternalArticleInformation.Qips[9].Qipfrequency;

                //Supplier ark
                sheet = workbook.Worksheets[0];

                sheet.Range["B3"].Text = version.VailedForCustomer;

                sheet.Range["B14"].Text = version.ArticleInformation.Salesunit;
                sheet.Range["B15"].Text = version.ArticleInformation.ArticleName;

                sheet.Range["B17"].Number =  version.ArticleInformation.LengthPrSalesunit;
                sheet.Range["B18"].Number =  version.ArticleInformation.WidthPrSalesunit;
                sheet.Range["B19"].Number =  version.ArticleInformation.HeightPrSalesunit;
                sheet.Range["B20"].Number =  version.ArticleInformation.NetWeightPrSalesunit;
                sheet.Range["B21"].Number =  version.ArticleInformation.GrossWeightPrSalesunit;
                sheet.Range["B22"].Text =  version.ArticleInformation.Gtinnumber;

                sheet.Range["B26"].Number =  version.ArticleInformation.Shelflife;
                sheet.Range["B27"].Number =  version.ArticleInformation.MinimumShelflife;

                sheet.Range["B43"].Text =  version.ArticleInformation.DangerousGoods == 1 ? "yes" : "no";

                sheet.Range["B47"].Text =  version.ArticleInformation.Class;
                sheet.Range["B48"].Text =  version.ArticleInformation.ClassificationCode;


                sheet.Range["E15"].Number =  version.ArticleInformation.CartonsPerPallet;
                sheet.Range["E16"].Number =  version.ArticleInformation.CartonsPerLayer;
                sheet.Range["E17"].Text =  version.ArticleInformation.CountryOfOrigin;
                sheet.Range["E18"].Text =  version.ArticleInformation.ImportedFrom;
                sheet.Range["E19"].Text =  version.ArticleInformation.TollTarifNumber;
                sheet.Range["E20"].Number =  version.ArticleInformation.MinimumOrderQuantity;
                sheet.Range["E22"].Number =  version.ArticleInformation.LeadTime;

                sheet.Range["E46"].Text = version.ArticleInformation.TransportBooking == 1 ? "yes" : "no";

                sheet.Range["E48"].Number = version.ArticleInformation.TransitTime;
                   
                #endregion
                using (MemoryStream stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream;
                }
            }
        }
    }
}

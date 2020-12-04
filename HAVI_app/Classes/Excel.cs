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
                IWorksheet sheet = workbook.Worksheets[0];
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
                sheet.Range["B16"].Number =  version.InternalArticleInformation.AmountInForeignCurrency;
                sheet.Range["B17"].Number =  version.InternalArticleInformation.TextPurchaseNumber;
                sheet.Range["B18"].Number =  version.InternalArticleInformation.InsertEanSap;
                sheet.Range["B19"].Number =  version.InternalArticleInformation.InsertGrinSap;
                sheet.Range["B20"].Number =  version.InternalArticleInformation.InsertBosSap;
                sheet.Range["B25"].Number =  version.InternalArticleInformation.PrimaryDcIloscode;
                sheet.Range["E8"].Number =  version.InternalArticleInformation.RegisterShelfLife;
                sheet.Range["E25"].Text =  version.InternalArticleInformation.Eannumber;
                sheet.Range["E26"].Text =  version.InternalArticleInformation.Grinnumber;
                sheet.Range["E27"].Text =  version.InternalArticleInformation.Bosnumber;


                //Supplier ark
                sheet = workbook.Worksheets[1];

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
                sheet.Range["B43"].Number =  version.ArticleInformation.DangerousGoods;
                sheet.Range["B47"].Text =  version.ArticleInformation.Class;
                sheet.Range["B48"].Text =  version.ArticleInformation.ClassificationCode;
                sheet.Range["E15"].Number =  version.ArticleInformation.CartonsPerPallet;
                sheet.Range["E16"].Number =  version.ArticleInformation.CartonsPerLayer;
                sheet.Range["E17"].Text =  version.ArticleInformation.CountryOfOrigin;
                sheet.Range["E18"].Text =  version.ArticleInformation.ImportedFrom;
                sheet.Range["E19"].Text =  version.ArticleInformation.TollTarifNumber;
                sheet.Range["E20"].Number =  version.ArticleInformation.MinimumOrderQuantity;
                sheet.Range["E22"].Number =  version.ArticleInformation.LeadTime;
                sheet.Range["E23"].Number =  version.ArticleInformation.OrganicArticle;
                sheet.Range["E26"].Number =  version.ArticleInformation.TemperatureStorageMin;
                sheet.Range["E27"].Number =  version.ArticleInformation.TemperatureTransportationMin;
                   
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

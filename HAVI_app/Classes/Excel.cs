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
                sheet.Range["B6"].Text = "Remain Shelf Store value"; version.InternalArticleInformation.RemainShelfStore;
                sheet.Range["B7"].Text = "ILOS Orderpick Group"; version.InternalArticleInformation.IlosorderPickGroup;
                sheet.Range["B8"].Text = "ILOS Temp group"; version.InternalArticleInformation.IlossortGroup;
                sheet.Range["B9"].Text = "New IOS Article number"; version.InternalArticleInformation.NewIlosarticleNumber;
                sheet.Range["B10"].Text = "Ref ILOS number"; version.InternalArticleInformation.ReferenceIlosnumber;
                sheet.Range["B11"].Text = "Ref SAP mat Number"; version.InternalArticleInformation.ReferenceSapmaterial;
                sheet.Range["B12"].Text = "ILOS catagory/Account"; version.InternalArticleInformation.Iloscategory;
                sheet.Range["B13"].Text = "VAT/tax Code"; version.InternalArticleInformation.VatTaxcode;
                sheet.Range["B14"].Text = "Department ID"; version.InternalArticleInformation.DepartmentId;
                sheet.Range["B15"].Text = "Innerpacking ILOS"; version.InternalArticleInformation.InnerPackingIlos;
                sheet.Range["B16"].Text = "If forign currency "; version.InternalArticleInformation.AmountInForeignCurrency;
                sheet.Range["B17"].Text = "Text Purchase members"; version.InternalArticleInformation.TextPurchaseNumber;
                sheet.Range["B18"].Text = "Insert EAN in SAP"; version.InternalArticleInformation.InsertEanSap;
                sheet.Range["B19"].Text = "Insert GRIN in SAP"; version.InternalArticleInformation.InsertGrinSap;
                sheet.Range["B20"].Text = "Insert BOS in SAP"; version.InternalArticleInformation.InsertBosSap;
                sheet.Range["B25"].Text = "Primary DC ILOS code"; version.InternalArticleInformation.PrimaryDcIloscode;
                sheet.Range["E8"].Text = "Register Shelvelife"; version.InternalArticleInformation.RegisterShelfLife;
                sheet.Range["E25"].Text = "Alias EAN"; version.InternalArticleInformation.Eannumber;
                sheet.Range["E26"].Text = "Alias GRIN"; version.InternalArticleInformation.Grinnumber;
                sheet.Range["E27"].Text = "Alias BOS"; version.InternalArticleInformation.Bosnumber;


                //Supplier ark
                sheet = workbook.Worksheets[1];

                sheet.Range["B3"].Text = "Valid for costumer"; version.VailedForCustomer;
                sheet.Range["B14"].Text = "Salesunit"; version.ArticleInformation.Salesunit;
                sheet.Range["B15"].Text = "Article number"; version.ArticleInformation.ArticleName;
                sheet.Range["B17"].Text = "Length"; version.ArticleInformation.LengthPrSalesunit;
                sheet.Range["B18"].Text = "Width"; version.ArticleInformation.WidthPrSalesunit;
                sheet.Range["B19"].Text = "Height"; version.ArticleInformation.HeightPrSalesunit;
                sheet.Range["B20"].Text = "Net Weight"; version.ArticleInformation.NetWeightPrSalesunit;
                sheet.Range["B21"].Text = "Gross Weight"; version.ArticleInformation.GrossWeightPrSalesunit;
                sheet.Range["B22"].Text = "GTIN Number"; version.ArticleInformation.Gtinnumber;
                sheet.Range["B26"].Text = "Shelv life"; version.ArticleInformation.Shelflife;
                sheet.Range["B27"].Text = "Shelve Life HAVI"; version.ArticleInformation.MinimumShelflife;
                sheet.Range["B43"].Text = "Register Dangerous goods"; version.ArticleInformation.DangerousGoods;
                sheet.Range["B47"].Text = "Class"; version.ArticleInformation.Class;
                sheet.Range["B48"].Text = "clasificationcode"; version.ArticleInformation.ClassificationCode;
                sheet.Range["E15"].Text = "Cartons pr pallet"; version.ArticleInformation.CartonsPerPallet;
                sheet.Range["E16"].Text = "Cartons pr layer "; version.ArticleInformation.CartonsPerLayer;
                sheet.Range["E17"].Text = "Country of origin"; version.ArticleInformation.CountryOfOrigin;
                sheet.Range["E18"].Text = "Imported from"; version.ArticleInformation.ImportedFrom;
                sheet.Range["E19"].Text = "Toll tariff nr"; version.ArticleInformation.TollTarifNumber;
                sheet.Range["E20"].Text = "Min order quantity"; version.ArticleInformation.MinimumOrderQuantity;
                sheet.Range["E21"].Text = "Min order Type"; version.ArticleInformation.;
                sheet.Range["E22"].Text = "Lead Time"; version.ArticleInformation.LeadTime;
                sheet.Range["E23"].Text = "Organic article"; version.ArticleInformation.OrganicArticle;
                sheet.Range["E26"].Text = "min storage"; version.ArticleInformation.TemperatureStorageMin;
                sheet.Range["E27"].Text = "min transport"; version.ArticleInformation.TemperatureTransportationMin;
                   
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

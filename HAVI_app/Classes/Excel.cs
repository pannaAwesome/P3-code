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
                sheet.Range["B5"].Text = "Supplier Delivery Unit";
                sheet.Range["B6"].Text = "Remain Shelf Store value";
                sheet.Range["B7"].Text = "ILOS Orderpick Group";
                sheet.Range["B8"].Text = "ILOS Temp group";
                sheet.Range["B9"].Text = "New IOS Article number";
                sheet.Range["B10"].Text = "Ref ILOS number";
                sheet.Range["B11"].Text = "Ref SAP mat Number";
                sheet.Range["B12"].Text = "ILOS catagory/Account";
                sheet.Range["B13"].Text = "VAT/tax Code";
                sheet.Range["B14"].Text = "Department ID";
                sheet.Range["B15"].Text = "Innerpacking ILOS";
                sheet.Range["B16"].Text = "If forign currency ";
                sheet.Range["B17"].Text = "Text Purchase members";
                sheet.Range["B18"].Text = "Insert EAN in SAP";
                sheet.Range["B19"].Text = "Insert GRIN in SAP";
                sheet.Range["B20"].Text = "Insert BOS in SAP";
                sheet.Range["B25"].Text = "Primary DC ILOS code";
                sheet.Range["E8"].Text = "Register Shelvelife";
                sheet.Range["E25"].Text = "Alias EAN";
                sheet.Range["E26"].Text = "Alias GRIN";
                sheet.Range["E27"].Text = "Alias BOS";


                //Supplier ark
                sheet = workbook.Worksheets[1];

                sheet.Range["B3"].Text = "Valid for costumer";
                sheet.Range["B14"].Text = "Salesunit";
                sheet.Range["B15"].Text = "Article number";
                sheet.Range["B17"].Text = "Length";
                sheet.Range["B18"].Text = "Width";
                sheet.Range["B19"].Text = "Height";
                sheet.Range["B20"].Text = "Net Weight";
                sheet.Range["B21"].Text = "Gross Weight";
                sheet.Range["B22"].Text = "GTIN Number";
                sheet.Range["B26"].Text = "Shelv life";
                sheet.Range["B27"].Text = "Shelve Life HAVI";
                sheet.Range["B43"].Text = "Register Shelvelife";
                sheet.Range["B47"].Text = "Class";
                sheet.Range["B48"].Text = "clasificationcode";
                sheet.Range["E15"].Text = "Cartons pr pallet";
                sheet.Range["E16"].Text = "Cartons pr layer ";
                sheet.Range["E17"].Text = "Country of origin";
                sheet.Range["E18"].Text = "Imported from";
                sheet.Range["E19"].Text = "Toll tariff nr";
                sheet.Range["E20"].Text = "Min order quantity";
                sheet.Range["E21"].Text = "Min order Type";
                sheet.Range["E22"].Text = "Lead Time";
                sheet.Range["E23"].Text = "Organic article";
                sheet.Range["E26"].Text = "min storage";
                sheet.Range["E27"].Text = "min transport";
                   
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

using Syncfusion.Drawing;
using Syncfusion.XlsIO;
using System;
using System.Globalization;
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
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.
            //Step 1 : Instantiate the spreadsheet creation engine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Step 2 : Instantiate the excel application object
                IApplication application = excelEngine.Excel;
                //Set the default version
                    application.DefaultVersion = ExcelVersion.Excel2016;
                
                //Creating new workbook
                IWorkbook workbook = application.Workbooks.Create(3);
                IWorksheet sheet = workbook.Worksheets[0];
                #region Generate Excel
                sheet.Range["A2"].ColumnWidth = 30;
                sheet.Range["B2"].ColumnWidth = 30;
                sheet.Range["C2"].ColumnWidth = 30;
                sheet.Range["D2"].ColumnWidth = 30;
                sheet.Range["A2:D2"].Merge(true);
                //Inserting sample text into the first cell of the first sheet
                sheet.Range["A2"].CellStyle.Font.FontName = "Verdana";
                sheet.Range["A2"].CellStyle.Font.Bold = true;
                sheet.Range["A2"].CellStyle.Font.Size = 28;
                sheet.Range["A2"].CellStyle.Font.RGBColor = Color.FromArgb(0, 0, 112, 192);
                sheet.Range["A2"].HorizontalAlignment = ExcelHAlign.HAlignCenter;
                sheet.Range["A4:B7"].CellStyle.Font.FontName = "Verdana";
                sheet.Range["A4:B7"].CellStyle.Font.Bold = true;
                sheet.Range["A4:B7"].CellStyle.Font.Size = 11;
                sheet.Range["A4:A7"].CellStyle.Font.RGBColor = Color.FromArgb(0, 128, 128, 128);
                sheet.Range["A4:A7"].HorizontalAlignment = ExcelHAlign.HAlignLeft;
                sheet.Range["B4:B7"].CellStyle.Font.RGBColor = Color.FromArgb(0, 174, 170, 170);
                sheet.Range["B4:B7"].HorizontalAlignment = ExcelHAlign.HAlignRight;
                sheet.Range["A9:D20"].CellStyle.Font.FontName = "Verdana";
                sheet.Range["A9:D20"].CellStyle.Font.Size = 11;

                sheet.Range["B3"].Text = "Company code";
                sheet.Range["B4"].Text = "Supplier ID";
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
                sheet.Range["B47"].Text = "Alias EAN";
                sheet.Range["B48"].Text = "Alias GRIN";
                    

                sheet.Range["E15"].Text = "Cartons pr pallet";
                sheet.Range["E16"].Text = "Cartons pr layer ";
                sheet.Range["E17"].Text = "Country of origin";
                sheet.Range["E18"].Text = "Imported from";
                sheet.Range["E19"].Text = "Toll tariff nr";
                sheet.Range["E20"].Text = "Min order quantity";
                sheet.Range["E21"].Text = "Min order Type";
                sheet.Range["E22"].Text = "Lead Time";
                sheet.Range["E23"].Text = "Organic article";
                sheet.Range["E25"].Text = "Alias EAN";
                sheet.Range["E26"].Text = "Alias GRIN";
                sheet.Range["E27"].Text = "Alias BOS";
                sheet.Range["E43"].Text = "Alias BOS";




                sheet.Range["A20:D20"].CellStyle.Color = Color.FromArgb(0, 0, 112, 192);
                sheet.Range["A20:D20"].CellStyle.Font.Color = ExcelKnownColors.White;
                sheet.Range["A20:D20"].CellStyle.Font.Bold = true;
                IStyle style = sheet["B9:D9"].CellStyle;
                style.VerticalAlignment = ExcelVAlign.VAlignCenter;
                style.HorizontalAlignment = ExcelHAlign.HAlignRight;
                style.Color = Color.FromArgb(0, 0, 112, 192);
                style.Font.Bold = true;
                style.Font.Color = ExcelKnownColors.White;
                   
                #endregion
                //Save the document as a stream and retrun the stream
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream
                    workbook.SaveAs(stream);
                    return stream;
                }
            }
        }
    }
}

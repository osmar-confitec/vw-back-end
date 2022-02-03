using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VolksCalls.Infra.CrossCutting.Documents
{
    public class ExcelDocument : Document
    {
        public ExcelDocument(LNotifications notifications, string patch)
            : base(notifications, patch)
        {


        }

        public System.Data.DataSet ReadExcelFileInLine(int linesIgnore = 0, List<string> ReadSheets = null)
        {
            try
            {


       
            var dataSetReturn = new System.Data.DataSet();

            //Lets open the existing excel file and read through its content . Open the excel using openxml sdk
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(Patch, false))
            {
                //create the object for workbook part  
                WorkbookPart workbookPart = doc.WorkbookPart;
                Sheets thesheetcollection = workbookPart.Workbook.GetFirstChild<Sheets>();

                //using for each loop to get the sheet from the sheetcollection  
                foreach (Sheet thesheet in thesheetcollection)
                {

                    if (ReadSheets != null
                        && ReadSheets.Any()
                        && !ReadSheets.Contains(thesheet.Name))
                        continue;

                    DataTable sheetDataTable = new DataTable(thesheet.Name);
                    Dictionary<int, string> columnsExcel = new Dictionary<int, string>();
                    bool header = true;
                    //statement to get the worksheet object by using the sheet id  
                    Worksheet theWorksheet = ((WorksheetPart)workbookPart.GetPartById(thesheet.Id)).Worksheet;
                    SheetData thesheetdata = (SheetData)theWorksheet.GetFirstChild<SheetData>();


                    var idxColumns = 0;
                    foreach (Row thecurrentrow in thesheetdata)
                    {
                        if (linesIgnore > 0)
                        {
                            linesIgnore--;
                            continue;
                        }

                        if (linesIgnore == 0)
                        {
                            foreach (Cell cell in thecurrentrow)
                            {
                                idxColumns++;
                                string currentcellvalue = string.Empty;
                                currentcellvalue = GetCellValue(workbookPart, cell);
                                columnsExcel.Add(idxColumns, currentcellvalue);
                                sheetDataTable.Columns.Add(currentcellvalue, typeof(string));
                            }
                            idxColumns = 0;
                            linesIgnore--;
                        }

                        if (!header)
                        {
                            DataRow row = sheetDataTable.NewRow();
                            foreach (Cell thecurrentcell in thecurrentrow)
                            {
                                string currentcellvalue = string.Empty;
                                currentcellvalue = GetCellValue(workbookPart, thecurrentcell);
                                idxColumns++;
                                row[columnsExcel.FirstOrDefault(x => x.Key == idxColumns).Value] = currentcellvalue ?? "";
                            }
                            sheetDataTable.Rows.Add(row);
                            idxColumns = 0;

                        }
                        header = false;
                    }
                    dataSetReturn.Tables.Add(sheetDataTable);
                }
            }
            return dataSetReturn;
            }
            catch (Exception EX)
            {

                throw;
            }
        }

        string GetCellValue(WorkbookPart workbookPart,
                                Cell thecurrentcell)
        {
            if (thecurrentcell.DataType != null)
            {

                if (thecurrentcell.DataType == CellValues.Number)
                {
                    return thecurrentcell.InnerText;
                }
                else

                if (thecurrentcell.DataType == CellValues.SharedString)
                {
                    int id;
                    if (Int32.TryParse(thecurrentcell.InnerText, out id))
                    {


                        SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);



                        if (item.Text != null)
                        {
                            return item.Text.Text;
                        }
                        else if (item.InnerText != null)
                        {
                            return item.InnerText;
                        }
                        else if (item.InnerXml != null)
                        {
                            return item.InnerXml;
                        }
                    }
                }

            }
            else
            {
                return thecurrentcell.InnerText;
            }
            return string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VolksCalls.Infra.CrossCutting.Documents
{
    public class TxtDocument : Document
    {
        public TxtDocument(LNotifications _notifications, string patch)
            : base(_notifications, patch)
        {


        }


      public  DataTable LoadTxtDelemiterDataTable(string delemiter, List<string> columns)
        {
            var tableReturn = new DataTable();
            foreach (var item in columns)
            {
                tableReturn.Columns.Add(new DataColumn(item, typeof(string)));
            }

            var allLines = System.IO.File.ReadAllLines(Patch);

            foreach (var line in allLines)
            {
                DataRow dataRowInsert = tableReturn.NewRow();
                var columnsLine = line.Split(delemiter).ToList();
                foreach (var col in columnsLine)
                {
                    var idx = columnsLine.IndexOf(col);
                    dataRowInsert[columns[idx]] = col;
                }
                tableReturn.Rows.Add(dataRowInsert);
            }
            return tableReturn;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbf
{
    static class codes2
    {
        public static void runthread()
        {

        }
        public static void ExportToExcel1(DataTable DataTable, string ExcelFilePath)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            var total_cells = (DataTable.Columns.Count + 1) * (DataTable.Rows.Count + 1);
            var rel_cells = 0;
            int ColumnsCount;

            if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");

            // load excel, and create a new workbook
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbooks.Add();
            //Excel.Visible = true;
            // single worksheet
            Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;

            object[] Header = new object[ColumnsCount];
            var stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            // column headings               
            for (int i = 0; i < ColumnsCount; i++)
                Header[i] = DataTable.Columns[i].ColumnName;

            Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
            HeaderRange.Value = Header;
            HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            HeaderRange.Font.Bold = true;

            // DataCells
            int RowsCount = DataTable.Rows.Count;
            object[,] Cells = new object[RowsCount, ColumnsCount];

            for (int j = 0; j < RowsCount; j++)
            {
                for (int i = 0; i < ColumnsCount; i++)
                {
                    Cells[j, i] = DataTable.Rows[j][i];

                }
                rel_cells = 0;
                rel_cells = ColumnsCount * j;
                var time = stopwatch.ElapsedMilliseconds;
                var speed = (rel_cells / time);
                Console.WriteLine("Speed:" + speed + "cells/sec");
            }
            Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value2 = Cells;
            stopwatch.Stop();
            var final_speed = (total_cells / stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Completed At Speed:" + final_speed + "cells/sec");
            if (string.IsNullOrEmpty(ExcelFilePath) || File.Exists(ExcelFilePath))
            {

                Excel.Visible = true;
            }
            else
            { // no file path is given
                try
                {
                    Worksheet.SaveAs(ExcelFilePath);
                    Excel.Quit();
                    MessageBox.Show("Excel file saved!");
                }
                catch (Exception ex)
                {
                    throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                        + ex.Message);
                }
            }
            Marshal.FinalReleaseComObject(Worksheet);
            Marshal.FinalReleaseComObject(HeaderRange);
            Marshal.FinalReleaseComObject(Excel);
            System.Windows.MessageBox.Show("Excel file saved!");

        }


        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}

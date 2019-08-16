using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace dbf
{
    class codes
    {
        DataTable dt = new DataTable();
        DataGridView dataGridView1 = new DataGridView();
        string dbf_filename = ""; string dbf_constring1 = "";string dbf_filepath = "";
        protected void dbf_file_open()
        {
            string os = getOSInfo();
            switch (os)
            {
                case "Windows XP":
                    dbf_constring1 = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + @Path.GetDirectoryName(dbf_filepath) + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 7":
                    dbf_constring1 = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + @Path.GetDirectoryName(dbf_filepath) + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows Vista":
                    dbf_constring1 = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + @Path.GetDirectoryName(dbf_filepath) + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 8":
                    dbf_constring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + @Path.GetDirectoryName(dbf_filepath) + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 8.1":
                    dbf_constring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + @Path.GetDirectoryName(dbf_filepath) + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 10":
                    dbf_constring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + @Path.GetDirectoryName(dbf_filepath) + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                default:
                    dbf_constring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + @Path.GetDirectoryName(dbf_filepath) + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
            }
            //get_dbfdata();
            get_dbf_database();
        }

        protected string getOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else if (vs.Minor == 1)
                            operatingSystem = "7";
                        else if (vs.Minor == 2)
                            operatingSystem = "8";
                        else
                            operatingSystem = "8.1";
                        break;
                    case 10:
                        operatingSystem = "10";
                        break;
                    default:
                        break;
                }
            }
            //Make sure we actually got something in our OS check
            //We don't want to just return " Service Pack 2" or " 32-bit"
            //That information is useless without the OS version.
            if (operatingSystem != "")
            {
                //Got something.  Let's prepend "Windows" and get more info.
                operatingSystem = "Windows " + operatingSystem;
                //See if there's a service pack installed.

                /*if (os.ServicePack != "")
                {
                    //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                    operatingSystem += " " + os.ServicePack;
                }*/

                //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                //operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
            }
            //Return the information we've gathered.
            return operatingSystem;
        }

        protected void get_dbf_database()
        {
            string[] filePaths = Directory.GetFiles(Path.GetDirectoryName(dbf_filepath), "*.dbf");
            foreach (string s in filePaths)
            {
                MessageBox.Show(s);
                string excelFilename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + s + ".xlsx";
                string xml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + s + ".xml";
                string xml_schema = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + s + "_schema.xml";
                string s_without_ext = Path.GetFileNameWithoutExtension(s);

                //Path.GetFileNameWithoutExtension(dbf_filepath);
                try
                {

                    OleDbConnection connection = new OleDbConnection(dbf_constring1);
                    string sql = "SELECT * FROM " + s_without_ext;
                    //string sql = "SELECT COUNT(),* FROM " + dbf_filename;

                    OleDbCommand cmd1 = new OleDbCommand(sql, connection);
                    connection.Open();
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd1);
                    DA.Fill(dt);
                    //DA.Update(dt);
                    connection.Close();
                    //excel_data_interop.DataTableToExcel(dt, Path.GetDirectoryName(s) + @"\" + Path.GetFileNameWithoutExtension(s));
                }
                catch (OleDbException e)
                {
                    MessageBox.Show("Error : " + e.Message);
                }
            }
        }

        protected void get_dbfdata()
        {
            
            string excelFilename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + dbf_filename + ".xlsx";
            string xml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + dbf_filename + ".xml";
            string xml_schema = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + dbf_filename + "_schema.xml";
            try
            {

                OleDbConnection connection = new OleDbConnection(dbf_constring1);
                string sql = "SELECT * FROM " + dbf_filename;
                //string sql = "SELECT COUNT(),* FROM " + dbf_filename;
                
                OleDbCommand cmd1 = new OleDbCommand(sql, connection);
                connection.Open();
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd1);
                DA.Fill(dt);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;
                dataGridView1.DataSource = bsource;
                //DA.Update(dt);
                connection.Close();

                DataSet ds4 = new DataSet("data_set");
                ds4.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                //DA.Fill(dt);
                //ds4.Tables.Add(dt);
                ds4.Tables.Add(dt);
                //ExcelLibrary.DataSetHelper.CreateWorkBook(excelFilename, ds4);
                convert_to_xls(dt, excelFilename);
                //ds4.WriteXmlSchema(xml_schema);
                //dt.WriteXml(xml);
                //WorksheetPart worksheet = new WorksheetPart();
                //WriteDataTableToExcelWorksheet(dt, worksheet);

                //export_xls(ds4);
                //export_xls2(ds1);
                //export_xls3(@excelFilename,ds4)
                //export_xls3(@excelFilename,ds4)
                //export_xls5(ds4);


            }
            catch (OleDbException e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
        }

        protected void convert_to_xls(DataTable xdt, string x)
        {
            //My_DataTable_Extensions.ExportToExcel(xdt, x);
            //ExportToExcel2(xdt, x);
            //ExportToExcel(xdt, x);
            //ExportToExcel(xdt, x);
            //codes2.ExportToExcel1(xdt, x);
            //excel_data_interop.DataTableToExcel(xdt, x);
            /*System.Windows.Controls.ProgressBar progress1 = new System.Windows.Controls.ProgressBar();
            var t = 0;
            progress1.Visibility = System.Windows.Visibility.Visible;
            excel_data_interop.DataTableToExcelWithProgressBar(xdt, x, progress1, label3.Text,t);*/

        }

        public void ExportToExcel(DataTable DataTable, string ExcelFilePath)
        {
            try
            {
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

                }
                Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value2 = Cells;

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
                        MessageBox.Show(ex.Message, "Error..!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Marshal.FinalReleaseComObject(Worksheet);
                Marshal.FinalReleaseComObject(HeaderRange);
                Marshal.FinalReleaseComObject(Excel);
                System.Windows.MessageBox.Show("Excel file saved!");
            }
            catch (Exception cd)
            {

                MessageBox.Show(cd.Message, "Error..!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void ExportToExcel1(DataTable DataTable, string ExcelFilePath)
        {
            //AttachConsole(ATTACH_PARENT_PROCESS);
            var total_cells = (DataTable.Columns.Count + 1) * (DataTable.Rows.Count + 1);
            var rel_cells = 0;
            int ColumnsCount;

            if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");

            // load excel, and create a new workbook
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbooks.Add();
            Excel.Visible = true;
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
            Worksheet.SaveAs(ExcelFilePath);
            Excel.Quit();
            Marshal.FinalReleaseComObject(Worksheet);
            Marshal.FinalReleaseComObject(HeaderRange);
            Marshal.FinalReleaseComObject(Excel);
            System.Windows.MessageBox.Show("Excel file saved!");

        }




        public void ExportToExcel2(DataTable DataTable, string ExcelFilePath)
        {
            var total_cells = (DataTable.Columns.Count + 1) * (DataTable.Rows.Count + 1);
            var rel_cells = 0;
            int ColumnsCount;

            if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");

            // load excel, and create a new workbook
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbooks.Add();
            Excel.Visible = true;
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
                Debug.WriteLine("Speed:" + speed + "cells/sec");
            }
            Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value2 = Cells;
            stopwatch.Stop();
            var final_speed = (total_cells / stopwatch.ElapsedMilliseconds);
            Debug.WriteLine("Completed At Speed:" + final_speed + "cells/sec");
            Worksheet.SaveAs(ExcelFilePath);
            Excel.Quit();
            Marshal.FinalReleaseComObject(Worksheet);
            Marshal.FinalReleaseComObject(HeaderRange);
            Marshal.FinalReleaseComObject(Excel);
            System.Windows.MessageBox.Show("Excel file saved!");

        }

        public void ExportToExcel3(DataTable DataTable, string ExcelFilePath)
        {
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
               
            }
            Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value2 = Cells;
            
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

        private void MeasureOverIncreasingSize(Workbooks workbooks, int blockSize, Stopwatch stopwatch, Action<int, int, Worksheet> method)
        {
            for (int size = 1; size <= 10; size++)
            {
                var workbook = workbooks.Add(Type.Missing);
                var worksheets = workbook.Sheets;
                var worksheet = (Worksheet)worksheets[1];

                var rows = blockSize * size;
                var columns = blockSize;

                stopwatch.Reset();
                stopwatch.Start();

                method(rows, columns, worksheet);

                stopwatch.Stop();

                WriteEvaluation(stopwatch, rows, columns);
                workbook.Close(false, Type.Missing, Type.Missing);
            }
        }

        private void WriteEvaluation(Stopwatch stopwatch, int rows, int columns)
        {
            var cells = rows * columns;
            var time = stopwatch.ElapsedMilliseconds;
            var timePerCell = Math.Round((double)time / (double)cells, 5);

            Console.WriteLine(string.Format("Writing {0} values took {1} ms or {2} ms/cell.", cells, time, timePerCell));
        }

        private void ExportToExcel4(System.Data.DataTable dt, string ExcelFilePath = null)
            {

            /*Set up work book, work sheets, and excel application*/
            Microsoft.Office.Interop.Excel.Application oexcel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Workbook obook = oexcel.Workbooks.Add(misValue);
                Microsoft.Office.Interop.Excel.Worksheet osheet = new Microsoft.Office.Interop.Excel.Worksheet();

                oexcel.Visible = true;
                //  obook.Worksheets.Add(misValue);

                osheet = (Microsoft.Office.Interop.Excel.Worksheet)obook.Sheets["Sheet1"];
                int colIndex = 0;
                int rowIndex = 1;
                foreach (DataColumn dc in dt.Columns)
                {
                    colIndex++;
                    osheet.Cells[1, colIndex] = dc.ColumnName;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    rowIndex++;
                    colIndex = 0;

                    foreach (DataColumn dc in dt.Columns)
                    {
                        colIndex++;
                        osheet.Cells[rowIndex, colIndex] = dr[dc.ColumnName];
                    }
                }

                osheet.Columns.AutoFit();
                string filepath = ExcelFilePath;

                //Release and terminate excel

                obook.SaveAs(filepath);
                obook.Close();
                oexcel.Quit();
                releaseObject(osheet);

                releaseObject(obook);

                releaseObject(oexcel);
                GC.Collect();
            }
            catch (Exception ex)
            {
                oexcel.Quit();

                //log.AddToErrorLog(ex, this.Name);
            }
        }

        private void releaseObject(object o) { try { while (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0) { } } catch { } finally { o = null; } }

        protected void export_xls(DataSet ds, string x)
        {
            Microsoft.Office.Interop.Excel.Application objXL = null;

            //Workbook refrence

            Microsoft.Office.Interop.Excel.Workbook objWB = null;

            /*try

            {*/

            //Instancing Excel using COM services

            objXL = new Microsoft.Office.Interop.Excel.Application();
            objXL.Visible = true;

            //Adding WorkBook

            objWB = objXL.Workbooks.Add(ds.Tables.Count);

            //Variable to keep sheet count

            int sheetcount = 1;

            //Do I need to explain this ??? If yes please close my website and learn abc of .net .

            foreach (DataTable dt in ds.Tables)

            {

                //Adding sheet to workbook for each datatable

                Microsoft.Office.Interop.Excel.Worksheet objSHT = (Microsoft.Office.Interop.Excel.Worksheet)objWB.Sheets.Add();

                //Naming sheet as SheetData1.SheetData2 etc....

                objSHT.Name = "SheetData" + sheetcount.ToString();


                for (int j = 0; j < dt.Rows.Count; j++)

                {

                    for (int i = 0; i < dt.Columns.Count; i++)

                    {

                        //Condition to put column names in 1st row

                        //Excel work book indexes start from 1,1 and not 0,0

                        if (j == 0)

                        {

                            objSHT.Cells[1, i + 1] = dt.Columns[i].ColumnName.ToString();

                        }

                        //Writing down data

                        objSHT.Cells[j + 2, i + 1] = dt.Rows[j][i].ToString();

                    }

                }

                //Incrementing sheet count

                sheetcount++;

            }

            //Saving the work book

            objWB.Saved = true;

            objWB.SaveCopyAs(x);

            //Closing work book

            objWB.Close();

            //Closing excel application

            objXL.Quit();

            MessageBox.Show("Data Saved Successfully", "DBF to XLS Conversion Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}

            /*catch (Exception ex)

            {

                objWB.Saved = true;

                //Closing work book

                objWB.Close();

                //Closing excel application

                objXL.Quit();


                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        protected void using_closedxml()
        {

        }

        protected void execute(DataSet ds,string x)
        {
            Microsoft.Office.Interop.Excel.Application objXL = null;
            Microsoft.Office.Interop.Excel.Workbook objWB = null;
            objXL = new Microsoft.Office.Interop.Excel.Application();
            objXL.Visible = true;
            objWB = objXL.Workbooks.Add(ds.Tables.Count);
            int sheetcount = 1;
            foreach (DataTable dt in ds.Tables)
            {
                Microsoft.Office.Interop.Excel.Worksheet objSHT = (Microsoft.Office.Interop.Excel.Worksheet)objWB.Sheets.Add();

                String[,] arr = null;

                objSHT = objXL.ActiveSheet;
                Microsoft.Office.Interop.Excel.Range sheetCells = objSHT.Cells;
                Microsoft.Office.Interop.Excel.Range cellFirst = sheetCells[1, 1] as Microsoft.Office.Interop.Excel.Range;
                Microsoft.Office.Interop.Excel.Range cellLast = sheetCells[dt.Rows.Count, dt.Columns.Count] as Microsoft.Office.Interop.Excel.Range;
                Microsoft.Office.Interop.Excel.Range theRange = objSHT.get_Range(cellFirst, cellLast);

                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (j == 0)

                        {
                            if (dt.Columns[i].ColumnName.ToString().Equals(null))
                            {
                                arr[0, i] = string.Empty;
                            }
                            else
                                arr[0, i] = dt.Columns[i].ColumnName.ToString();

                        }

                        if (dt.Rows[j][i].ToString().Equals(null))
                        {
                            arr[j + 1, i] = string.Empty;
                        }
                        else
                            arr[j + 1, i] = dt.Rows[j][i].ToString();
                    }
                    theRange.set_Value(Type.Missing, arr);
                    //Incrementing sheet count

                    sheetcount++;
                }
            }
            objWB.Saved = true;

            objWB.SaveCopyAs(x);

            //Closing work book

            objWB.Close();

            //Closing excel application

            objXL.Quit();

            MessageBox.Show("Data Saved Successfully", "DBF to XLS Conversion Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void export_xls5(DataSet ds,string x)
        {
            try
            {
                execute(ds,x);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        protected void export_xls6(DataSet ds, string x)
        {
            Microsoft.Office.Interop.Excel.Application objXL = null;

            //Workbook refrence

            Microsoft.Office.Interop.Excel.Workbook objWB = null;

            /*try

            {*/

            //Instancing Excel using COM services

            objXL = new Microsoft.Office.Interop.Excel.Application();
            objXL.Visible = true;

            //Adding WorkBook

            objWB = objXL.Workbooks.Add(ds.Tables.Count);

            //Variable to keep sheet count

            int sheetcount = 1;

            //Do I need to explain this ??? If yes please close my website and learn abc of .net .

            foreach (DataTable dt in ds.Tables)
            {
                //Adding sheet to workbook for each datatable

                Microsoft.Office.Interop.Excel.Worksheet objSHT = (Microsoft.Office.Interop.Excel.Worksheet)objWB.Sheets.Add();

                //Naming sheet as SheetData1.SheetData2 etc....

                objSHT.Name = "SheetData" + sheetcount.ToString();

                String[,] arr = null;

                objSHT = objXL.ActiveSheet;
                Microsoft.Office.Interop.Excel.Range sheetCells = objSHT.Cells;
                Microsoft.Office.Interop.Excel.Range cellFirst = sheetCells[1, 1] as Microsoft.Office.Interop.Excel.Range;
                Microsoft.Office.Interop.Excel.Range cellLast = sheetCells[dt.Rows.Count, dt.Columns.Count] as Microsoft.Office.Interop.Excel.Range;
                Microsoft.Office.Interop.Excel.Range theRange = objSHT.get_Range(cellFirst, cellLast);


                for (int j = 0; j < dt.Rows.Count; j++)

                {

                    for (int i = 0; i < dt.Columns.Count; i++)

                    {

                        //Condition to put column names in 1st row

                        //Excel work book indexes start from 1,1 and not 0,0

                        if (j == 0)

                        {
                            if (dt.Columns[i].ColumnName.ToString().Equals(null))
                            {
                                arr[0, i] = string.Empty;
                            }
                            else
                                arr[0, i] = dt.Columns[i].ColumnName.ToString();

                        }

                        if (dt.Rows[j][i].ToString().Equals(null))
                        {
                            arr[j + 1, i] = string.Empty;
                        }
                        else
                            arr[j + 1, i] = dt.Rows[j][i].ToString();

                    }

                }

                theRange.set_Value(Type.Missing, arr);
                //Incrementing sheet count

                sheetcount++;
            }

            //Saving the work book

            objWB.Saved = true;

            objWB.SaveCopyAs(x);

            //Closing work book

            objWB.Close();

            //Closing excel application

            objXL.Quit();

            System.Windows.Forms.MessageBox.Show("Data Saved Successfully", "DBF to XLS Conversion Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}

            /*catch (Exception ex)

            {

                objWB.Saved = true;

                //Closing work book

                objWB.Close();

                //Closing excel application

                objXL.Quit();


                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }


        /*[DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();*/




        /*
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Products");
            var totalCols = GridView1.Rows[0].Cells.Count;
            var totalRows = GridView1.Rows.Count;
            var headerRow = GridView1.HeaderRow;
            for (var i = 1; i <= totalCols; i++ )
            {
                workSheet.Cells[1, i].Value = headerRow.Cells[i - 1].Text;
            }
            for (var j = 1; j <= totalRows; j++ )
            {
                for (var i = 1; i <= totalCols; i++)
                {
                    var product = products.ElementAt(j-1);
                    workSheet.Cells[j + 1, i].Value = product.GetType().GetProperty(headerRow.Cells[i - 1].Text).GetValue(product, null);
                }
            }
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=products.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
            */




        /*
                        string odbcconnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+@Path.GetDirectoryName(@dbf_filepath)+";Extended Properties=dBASE IV;";
                        string odbcconnectionString1 = @"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" + @Path.GetDirectoryName(@dbf_filepath) + ";";
                        string odbcconnectionString2 = @"DRIVER={Driver do Microsoft dBase (*.dbf)};DriverID=277;Dbq=" + @Path.GetDirectoryName(@dbf_filepath) + ";";
                        string odbcconnectionString3 = @"DRIVER={Driver do Microsoft dBase (*.dbf)};Dbq=" + @Path.GetDirectoryName(@dbf_filepath) + ";";
                        string odbcconnectionString4 = @"DRIVER={Microsoft dBase Driver (*.dbf)};DriverID=277;Dbq=" + @Path.GetDirectoryName(@dbf_filepath) + ";";
                        string odbcconnectionString5 = @"DRIVER={Microsoft dBase Driver (*.dbf)}DriverID=277;Dbq=" + @Path.GetDirectoryName(@dbf_filepath) + ";";

                        OdbcConnection con = new OdbcConnection();


                        con.ConnectionString = "DRIVER={Microsoft dBase Driver (*.dbf)};" +
                          "Driverid=277;" +
                          "Dsn="+Path.GetDirectoryName(dbf_filepath);

                        string sql = "SELECT * FROM " + dbf_filename;
                        OdbcCommand cmd = new OdbcCommand(sql, con);
                        con.Open();
                        OdbcDataAdapter DB = new OdbcDataAdapter(cmd);
                        DB.Fill(dtData);
                        dataGridView1.DataSource = DB;
                        con.Close();


            string odbcconnectionString5 = @"DRIVER={Microsoft dBase Driver (*.dbf)}DriverID=277;Dbq=" + @Path.GetDirectoryName(@dbf_filepath) + ";Extended Properties=dBase IV;User ID=;Password=";

                        OdbcConnection con = new OdbcConnection(odbcconnectionString5);




                        string sql = "SELECT * FROM " + dbf_filename_withext;
                        OdbcCommand cmd = new OdbcCommand(sql, con);
                        con.Open();
                        OdbcDataAdapter DB = new OdbcDataAdapter(cmd);
                        DB.Fill(ds);
                        con.Close();
             */
        /**/

        /*con.ConnectionString = "DRIVER={Microsoft dBase Driver (*.dbf)};" +
        "Driverid=277;" +
        "Dsn=" + Path.GetDirectoryName(dbf_filepath);*/

        //string constring = @"Provider = VFPOLEDB.1; Data Source = " + Path.GetDirectoryName(dbf_filepath) + "Extended Properties=dBase IV";
        //string constring = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + @Path.GetDirectoryName(dbf_filepath) + ";Extended Properties=dBase IV;User ID=;Password=";
    }
}

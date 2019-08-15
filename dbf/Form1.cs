using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data.Odbc;
//using xl=Microsoft.Office.Interop.Excel;
//using ClosedXML.Excel;
//using ExcelLibrary.SpreadSheet;
//using ExcelLibrary.CompoundDocumentFormat;
//using ExcelLibrary.BinaryFileFormat;
//using ExcelLibrary.BinaryDrawingFormat;
//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
using System.Diagnostics;
using System.Runtime.InteropServices;
using frontlook;
using System.Threading;

namespace dbf
{
    public partial class Form1 : Form
    {
        string dbf_filepath,dbf_filename,dbf_filename_withext;
        DataSet ds = new DataSet("new_dataset1");
        DataSet ds1 = new DataSet("new_dataset2");
        DataSet ds2 = new DataSet("new_dataset3");
        DataSet ds3 = new DataSet("new_dataset4");
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        
        string dbf_constring, dbf_constring1, dbf_constring2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //dbf_selection();
            //backgroundWorker1.RunWorkerAsync();
            dbf_folder_selection();

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //dbf_selection();
            
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int prog = e.ProgressPercentage;
            progress.Value = prog;
            progress.Update();
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }


        protected void dbf_folder_selection()
        {

            OpenFileDialog dbfselect = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                Filter = "DBF files (*.dbf)|*.dbf|All files (*.*)|*.*",
                FilterIndex = 1,
                Title = "Select DBF File",
                CheckFileExists = true,
                CheckPathExists = true,
                //ReadOnlyChecked = true,
                //ShowReadOnly = true,
                DefaultExt = "dbf",
            };
            //dbfselect.ShowDialog();

            if (dbfselect.ShowDialog() == DialogResult.OK)
            {
                //dataGridView1.Rows.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dbf_filepath = dbfselect.FileName;
                dbf_filename_withext = Path.GetFileNameWithoutExtension(dbf_filepath) + Path.GetExtension(dbf_filepath);
                dbf_filename = Path.GetFileNameWithoutExtension(dbf_filepath);
                label2.Text = dbf_filepath + "    " + dbf_filename;
                panel1.Visible = true;

                
                FileInfo fileInfo = new FileInfo(dbf_filepath);
                string directoryFullPath = fileInfo.DirectoryName;
                string x = Path.GetDirectoryName(dbf_filepath);

                excel_data_interop.dbf_to_xls_series(dbf_filepath);
            }
        }

        protected void dbf_selection()
        {
            OpenFileDialog dbfselect = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                Filter = "DBF files (*.dbf)|*.dbf|All files (*.*)|*.*",
                FilterIndex = 1,
                Title = "Select DBF File",
                CheckFileExists = true,
                CheckPathExists= true,
                DefaultExt = "dbf",
            };
            //dbfselect.ShowDialog();

            if(dbfselect.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dbf_filepath = dbfselect.FileName;
                dbf_filename_withext = Path.GetFileNameWithoutExtension(dbf_filepath)+Path.GetExtension(dbf_filepath);
                dbf_filename = Path.GetFileNameWithoutExtension(dbf_filepath);
                label2.Text = dbf_filepath + "    " +dbf_filename;
                panel1.Visible = true;
                excel_data_interop.dbf_to_xls_series(dbf_filepath);
                //dbf_file_open();
            }
        }

        


        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}


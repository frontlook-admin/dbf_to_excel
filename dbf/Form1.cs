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
using System.Diagnostics;
using System.Runtime.InteropServices;
using frontlook_csharp_library.excel_data_interop;
using frontlook_csharp_library.dbf_helper;
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
        
        string dbf_constring, dbf_constring1, dbf_constring2,s_without_ext;
        string[] filePaths;

        public Form1()
        {
            InitializeComponent();
            dbf_filepath = string.Empty;
            dbf_filename = string.Empty;
            dbf_filename_withext = string.Empty;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //dbf_selection();
            //backgroundWorker1.RunWorkerAsync();
            dbf_folder_selection();

        }

        private void View_db_Click(object sender, EventArgs e)
        {
            //dbf_folder_selection();
            if(dbf_filepath.Equals("")|| dbf_filepath.Equals(string.Empty))
            {
                
                dbf_folder_selection();
                dataGridView1.DataSource = "";
                dataGridView1.Refresh();
                view_db_in_grid();
            }
            else
            {
                dataGridView1.DataSource = "";
                dataGridView1.Refresh();
                view_db_in_grid();
            }
        }


        private void Db_viewer_DoWork(object sender, DoWorkEventArgs e)
        {
            try_1();
        }


        private void Db_viewer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }


        private void Db_viewer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }



        private void Dbf_to_excel_series_Click(object sender, EventArgs e)
        {
            //dbf_folder_selection();
            if (dbf_filepath.Equals("") || dbf_filepath.Equals(string.Empty))
            {
                dbf_folder_selection();
                if (!dbf_to_excel_series_worker.IsBusy)
                {
                    dbf_to_excel_series_worker.WorkerReportsProgress = true;
                    dbf_to_excel_series_worker.RunWorkerAsync();
                }
            }
            else
            {
                
                if (!dbf_to_excel_series_worker.IsBusy)
                {
                    dbf_to_excel_series_worker.WorkerReportsProgress = true;
                    dbf_to_excel_series_worker.RunWorkerAsync();
                }
            }
            
        }

        
        private void Dbf_to_excel_series_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            dbf_to_excel_series_worker.ReportProgress((5));
            int i = 0;
            int j = filePaths.Length;
            foreach (string dbf_filepath_series in filePaths)
            {
                i =i+1;
                label2.Invoke((MethodInvoker)delegate {
                    label2.Text = dbf_filepath_series;
                });
                DataTable dt = data_to_excel.fl_data_to_xls_with_datatable(dbf_filepath_series);
                dataGridView1.Invoke((MethodInvoker)delegate {
                    dataGridView1.DataSource = dt;
                });
                //dataGridView1.DataSource = dbf_helper.fl_dbf_datatable(dbf_filepath_series);
                //label2.Text = dbf_filepath_series;
                dbf_to_excel_series_worker.ReportProgress((i * 100 / j));
            }
            
            //excel_data_interop.dbf_to_xls_series(dbf_filepath);
        }

        
        private void Dbf_to_excel_series_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label3.Text = e.ProgressPercentage + "%";
            progress.Value = e.ProgressPercentage;
        }

        
        private void Dbf_to_excel_series_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Done..!!", "Work Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //dbf_to_excel_series_worker.ReportProgress(0);
            progress.Value = 0;
        }

        private void Dbf_to_excel_single_Click(object sender, EventArgs e)
        {
            if (dbf_filepath.Equals("") || dbf_filepath.Equals(string.Empty))
            {
                dbf_folder_selection();
                if (!db_to_excel_single_worker.IsBusy)
                {
                    db_to_excel_single_worker.RunWorkerAsync();
                }
            }
            else
            {
                
                if (!db_to_excel_single_worker.IsBusy)
                {
                    db_to_excel_single_worker.RunWorkerAsync();
                }
            }
            
        }



        private void Db_to_excel_single_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            data_to_excel.fl_data_to_xls(dbf_filepath);
        }

        private void Db_to_excel_single_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

         private void Db_to_excel_single_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }


        private void Clear_Click(object sender, EventArgs e)
        {
            dbf_filepath = string.Empty;
            dbf_filename = string.Empty;
            dbf_filename_withext = string.Empty;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
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
                MessageBox.Show(dbf_filename);
                //label2.Text = dbf_filepath + "    " + dbf_filename;
                panel1.Visible = true;

                
                FileInfo fileInfo = new FileInfo(dbf_filepath);
                string directoryFullPath = fileInfo.DirectoryName;
                string x = Path.GetDirectoryName(dbf_filepath);
                string[] filePaths1;
                //string[] filepath_null;
                filePaths1 = Directory.GetFiles(x, "*.dbf");
                filePaths = filePaths1;
                //excel_data_interop.dbf_to_xls_series(dbf_filepath);
            }
            else if(dbfselect.ShowDialog() == DialogResult.Cancel|| dbfselect.ShowDialog() == DialogResult.None)
            {
                dbf_filepath = string.Empty;
                dbf_filename_withext = string.Empty;
                dbf_filename = string.Empty;
                //filePaths = string[] filepath_null;
            }
            else
            {
                dbf_filepath = string.Empty;
                dbf_filename_withext = string.Empty;
                dbf_filename = string.Empty;

            }
        }

        private void Test_Click(object sender, EventArgs e)
        {
            if (dbf_filepath.Equals("") || dbf_filepath.Equals(string.Empty))
            {

                dbf_folder_selection();
                try_1();
                //db_viewer.RunWorkerAsync();
            }
            else
            {
                dataGridView1.DataSource = "";
                try_1();
                //db_viewer.RunWorkerAsync();
            }
        }



        protected void view_db_in_grid()
        {
            s_without_ext = "";
            s_without_ext = Path.GetFileNameWithoutExtension(dbf_filename);
            /*var datastring = frontlook_csharp_library.data_helper.data_helper1.constring(dbf_filepath);
            DataTable dtx = new DataTable();
            try
            {

                OleDbConnection connection = new OleDbConnection(datastring);
                string sql = "SELECT * FROM " + s_without_ext;
                MessageBox.Show(sql + "     \n" + datastring+"    "+s_without_ext+"    "+ dbf_filepath + "    ");
                OleDbCommand cmd1 = new OleDbCommand(sql, connection);
                connection.Open();
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd1);
                DA.Fill(dtx);
                
                //DA.Update(dt);
                connection.Close();
                dataGridView1.DataSource = dtx;
                //BackgroundWorker bgw = new BackgroundWorker();

            }
            catch (OleDbException e)
            {
                MessageBox.Show("Error : " + e.Message);
            }*/
            dataGridView1.DataSource = dbf_helper.fl_dbf_datatable(dbf_filepath);
        }

        /*protected void dbf_selection()
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
                if (!dbf_to_excel_series_worker.IsBusy)
                {

                    dbf_to_excel_series_worker.RunWorkerAsync();
                }
                //data_to_excel.dbf_to_xls_series(dbf_filepath);
                //dbf_file_open();
            }
        }*/


        protected void try_1()
        {
            //data_to_excel.fl_data_to_xls(dbf_filepath);
            data_to_excel.fl_data_to_xls_multiple_datatable_in_single_excel_file(dbf_filepath);
         //   MessageBox.Show(frontlook_csharp_library.database_helper.database_helper.fl_odbc_execute_command());
            /*FileInfo fileInfo = new FileInfo(dbf_filepath);
            string directoryFullPath = fileInfo.DirectoryName;
            string x = Path.GetDirectoryName(dbf_filepath);
            string[] filePaths;
            filePaths = Directory.GetFiles(x, "*.dbf");
            foreach(string s in filePaths)
            {
                MessageBox.Show("Ok"+"   "+fl_dbf_helper.get_os()+"   "+fl_dbf_helper.constring(dbf_filepath));
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = fl_dbf_helper.data(s);
                
            }*/
            //view_db_in_grid();
        }
    }
}


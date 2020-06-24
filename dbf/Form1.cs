﻿using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using frontlook_csharp_library.FL_Dbf_Helper;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        
        public List<compList> CompList { get; set; }

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



        

        
        

        
        


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString());
            MessageBox.Show("OS Version: "+frontlook_csharp_library.FL_General.FL_Os_Helper.FL_get_os());
           /* var ci = new CultureInfo("en-IN");
            var cu = CultureInfo.CurrentUICulture.DateTimeFormat.FullDateTimePattern;
            var cd = CultureInfo.CurrentCulture.DateTimeFormat.GetAllDateTimePatterns();
            MessageBox.Show(Thread.CurrentThread.CurrentCulture.ToString());
            MessageBox.Show(CultureInfo.CurrentCulture.Name + "1");
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            var cf_d = currentCulture.DateTimeFormat.ShortDatePattern;
            var cf_t = currentCulture.DateTimeFormat.LongTimePattern;
            MessageBox.Show(cf_d + " 1 "+cf_t+" 2 "+ currentCulture.DateTimeFormat.FullDateTimePattern+" 3 "+ 
                currentCulture.DateTimeFormat.SortableDateTimePattern+" 4 "+ currentCulture.DateTimeFormat.LongDatePattern);*/
            //MessageBox.Show(DateTime.ParseExact(DateTime.Now.ToString(),cf_d+" "+cf_t,ci,DateTimeStyles.AssumeLocal).ToString());
        }

        protected void dbf_folder_selection()
        {

            OpenFileDialog dbfselect = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                Filter = "Comp DBF files|comp.dbf|DBF files|*.dbf|All files (*.*)|*.*",
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
            //var ci = new CultureInfo("en-IN");
            //MessageBox.Show(frontlook_csharp_library.database_helper.database_helper.FL_get_os());
            if (dbf_filepath.Equals("") || dbf_filepath.Equals(string.Empty))
            {
                
                dbf_folder_selection();
                try_1();
                fast_report();
                //db_viewer.RunWorkerAsync();
            }
            else
            {
                dataGridView1.DataSource = "";
                try_1();
                
            }
        }


        public void fast_report()
        {
            string query1 = "SELECT " +
                            "smast.SDES as SDES,bill.DT,billmed.VNO,billmed.BATCH,billmed.EXPDT, bill.MPT,aconf.ADD1,aconf.ADD2,aconf.ADD3," +
                            "(SELECT smast.SDES FROM [smast],[bill] WHERE bill.LCOD=smast.SCOD AND bill.VNO='00534' AND bill.MPT='M') AS TRANSPORT_SDES " +
                            "FROM " +
                            "[billmed],[bill],[smast],[aconf] WHERE billmed.VNO = bill.VNO AND bill.SCOD=smast.SCOD AND bill.MPT='M' AND bill.SCOD=aconf.GCOD " +
                            "AND " +
                            "bill.VNO='00534'";
            /*
             SELECT smast.SDES as SDES,bill.DT,billmed.VNO,billmed.BATCH,billmed.EXPDT, bill.MPT,aconf.ADD1,aconf.ADD2,aconf.ADD3, (SELECT smast.SDES FROM [smast],[bill] WHERE bill.LCOD=smast.SCOD AND bill.VNO='00534' AND bill.MPT='M') AS TRANSPORT_SDES FROM [billmed],[bill],[smast],[aconf] WHERE billmed.VNO = bill.VNO AND bill.SCOD=smast.SCOD AND bill.MPT='M' AND bill.SCOD=aconf.GCOD AND bill.VNO='00534'
             */
            DataSet ds = new DataSet("client info");
            ds.Tables.Add(FL_Dbf_Manager.FL_dbf_datatable(dbf_filepath, query1));
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            //ReportViewer rv = new ReportViewer();
            rv.ShowPrintButton = true;
            rv.ShowProgress=true;
            //Report r = new LocalReport();
            //r.DisplayName = "BILL";
            //rv.LocalReport.DataSources = ds.Tables[0];

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
            var dt = FL_Dbf_Manager.FL_dbf_datatable(dbf_filepath,
                "SELECT datapath,ccod FROM `" + s_without_ext + "`;");
            var d = new List<compList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(dt.Rows[i]["datapath"].ToString()))
                {
                    var _cl = new compList
                    {
                        dataList = dt.Rows[i]["datapath"].ToString(),
                        ccod = dt.Rows[i]["ccod"].ToString()
                    };
                    d.Add(_cl);
                    checkedListBox1.Items.Add(Path.Combine(_cl.dataList,_cl.ccod).ToString());
                }
            }
            

            dataGridView1.DataSource = dt;
        }
        private static List<compList> ConvertDataTable<T>(DataTable dt)
        {
            List<compList> data = new List<compList>();
            foreach (DataRow row in dt.Rows)
            {
                compList item = GetItem<compList>(row);
                data.Add(item);
            }
            return data;
        }

        private static compList GetItem<compList>(DataRow dr)
        {
            Type temp = typeof(compList);
            compList obj = Activator.CreateInstance<compList>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
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
            /*SELECTED VNO AND ALL BATCH*/
            //SELECT bill.DT,billmed.VNO,billmed.BATCH,billmed.EXPDT, bill.MPT,smast.SDES,aconf.ADD1,aconf.ADD2,aconf.ADD3,(SELECT smast.SDES FROM [smast],[bill] WHERE bill.LCOD=smast.SCOD AND bill.VNO='00530' AND bill.MPT='M') AS SDES FROM [billmed],[bill],[smast],[aconf] WHERE billmed.VNO = bill.VNO AND bill.SCOD=smast.SCOD AND bill.mpt='M' AND bill.SCOD=aconf.GCOD AND bill.VNO='00530'

            /*SELECTED VNO AND BATCH*/
            //SELECT bill.DT,billmed.VNO,billmed.BATCH,billmed.EXPDT, bill.MPT,smast.SDES AS SDES,aconf.ADD1,aconf.ADD2,aconf.ADD3,(SELECT smast.SDES FROM [smast],[bill] WHERE bill.LCOD=smast.SCOD AND bill.VNO='00533' AND bill.MPT='M') AS TSDES FROM [billmed],[bill],[smast],[aconf] WHERE billmed.VNO = bill.VNO AND bill.SCOD=smast.SCOD AND bill.mpt='M' AND bill.SCOD=aconf.GCOD AND bill.VNO='00533' AND billmed.BATCH='904'



            string query1 = "SELECT " +
                "smast.SDES as SDES,bill.DT,billmed.VNO,billmed.BATCH,billmed.EXPDT, bill.MPT,aconf.ADD1,aconf.ADD2,aconf.ADD3," +
                "(SELECT smast.SDES FROM [smast],[bill] WHERE bill.LCOD=smast.SCOD AND bill.VNO='00534' AND bill.MPT='M') AS TRANSPORT_SDES " +
                "FROM " +
                "[billmed],[bill],[smast],[aconf] WHERE billmed.VNO = bill.VNO AND bill.SCOD=smast.SCOD AND bill.MPT='M' AND bill.SCOD=aconf.GCOD " +
                "AND " +
                "bill.VNO='00534'";

            //query.Text = query1;

            dataGridView1.DataSource = FL_Dbf_Manager.FL_dbf_datatable(dbf_filepath, query.Text.ToString().Trim());
            //dataGridView1.DataSource = 
            
            
            
            /*DataSet all_ds = dbf_helper.get_all_datatable_in_dataset(filePaths);
            var a = "SELECT * FROM '" + all_ds + "'.BILLMED";
            all_ds.Tables[0].Select()
            */



            //data_to_excel.FL_data_to_xls(dbf_filepath);
            //data_to_excel.FL_data_to_xls_multiple_datatable_in_single_excel_file(dbf_filepath);
            //   MessageBox.Show(frontlook_csharp_library.database_helper.database_helper.FL_odbc_execute_command());
            /*FileInfo fileInfo = new FileInfo(dbf_filepath);
            string directoryFullPath = fileInfo.DirectoryName;
            string x = Path.GetDirectoryName(dbf_filepath);
            string[] filePaths;
            filePaths = Directory.GetFiles(x, "*.dbf");
            foreach(string s in filePaths)
            {
                MessageBox.Show("Ok"+"   "+FL_dbf_helper.get_os()+"   "+FL_dbf_helper.constring(dbf_filepath));
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = FL_dbf_helper.data(s);
                
            }*/
            //view_db_in_grid();
        }
    }

    public class compList
    {
        public string dataList { get; set; }
        public string ccod { get; set; }
        public string _path { get; set; }
    }
}


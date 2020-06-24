using System;
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
        string dbf_filepath, dbf_filename, dbf_filename_withext;
        DataSet ds = new DataSet("new_dataset1");
        DataSet ds1 = new DataSet("new_dataset2");
        DataSet ds2 = new DataSet("new_dataset3");
        DataSet ds3 = new DataSet("new_dataset4");
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

        public List<compList> CompList { get; set; }

        string dbf_constring, dbf_constring1, dbf_constring2, s_without_ext;
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
            if (dbf_filepath.Equals("") || dbf_filepath.Equals(string.Empty))
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

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;
            //MessageBox.Show(folderBrowserDialog1.SelectedPath);
            textBox1.Text = folderBrowserDialog1.SelectedPath;

        }

        private void Test_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString());
            MessageBox.Show("OS Version: " + frontlook_csharp_library.FL_General.FL_Os_Helper.FL_get_os());
        }

        private void save_Click(object sender, EventArgs e)
        {

        }


        public void generateScheduler()
        {

        }



        private void ExecuteQuery_Click(object sender, EventArgs e)
        {
            //var ci = new CultureInfo("en-IN");
            //MessageBox.Show(frontlook_csharp_library.database_helper.database_helper.FL_get_os());
            if (dbf_filepath.Equals("") || dbf_filepath.Equals(string.Empty))
            {

                dbf_folder_selection();
                try_2();
                //db_viewer.RunWorkerAsync();
            }
            else
            {
                dataGridView1.DataSource = "";
                try_2();

            }
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
            else if (dbfselect.ShowDialog() == DialogResult.Cancel || dbfselect.ShowDialog() == DialogResult.None)
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


        protected void view_db_in_grid()
        {
            s_without_ext = "";
            s_without_ext = Path.GetFileNameWithoutExtension(dbf_filename);
            dt = FL_Dbf_Manager.FL_dbf_datatable(dbf_filepath,
                "SELECT datapath,ccod FROM `" + s_without_ext + "`;");
            DataTableToDataList();
        }

        public List<compList> DataTableToDataList()
        {
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
                    checkedListBox1.Items.Add(Path.Combine(_cl.dataList, _cl.ccod).ToString());
                }
            }

            dataGridView1.DataSource = dt;
            return d;
        }

        protected void try_2()
        {

            string query1 = "";

            query.Text = query1;

            dt = FL_Dbf_Manager.FL_dbf_datatable(dbf_filepath, query.Text.ToString().Trim());

            DataTableToDataList();
        }
    }

    

public class compList
    {
        public string dataList { get; set; }
        public string ccod { get; set; }
        public string _path { get; set; }
    }
}


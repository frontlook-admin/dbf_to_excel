namespace dbf
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dbf_to_excel_series_worker = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.dbf_to_excel_single = new System.Windows.Forms.Button();
            this.dbf_to_excel_series = new System.Windows.Forms.Button();
            this.view_db = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.db_viewer = new System.ComponentModel.BackgroundWorker();
            this.db_to_excel_single_worker = new System.ComponentModel.BackgroundWorker();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.query = new System.Windows.Forms.RichTextBox();
            this.rv = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 42);
            this.label1.TabIndex = 7;
            this.label1.Text = "DBF Manager";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // dbf_to_excel_series_worker
            // 
            this.dbf_to_excel_series_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Dbf_to_excel_series_worker_DoWork);
            this.dbf_to_excel_series_worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Dbf_to_excel_series_worker_ProgressChanged);
            this.dbf_to_excel_series_worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Dbf_to_excel_series_worker_RunWorkerCompleted);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.test);
            this.panel2.Controls.Add(this.stop);
            this.panel2.Controls.Add(this.clear);
            this.panel2.Controls.Add(this.dbf_to_excel_single);
            this.panel2.Controls.Add(this.dbf_to_excel_series);
            this.panel2.Controls.Add(this.view_db);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 483);
            this.panel2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 418);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 53);
            this.button2.TabIndex = 0;
            this.button2.Text = "TEST";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(3, 357);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(162, 53);
            this.test.TabIndex = 0;
            this.test.Text = "EXECUTE QUERY";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.Test_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(1, 298);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(167, 53);
            this.stop.TabIndex = 0;
            this.stop.Text = "STOP FUNCTION";
            this.stop.UseVisualStyleBackColor = true;
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(1, 239);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(167, 53);
            this.clear.TabIndex = 0;
            this.clear.Text = "CLEAR";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // dbf_to_excel_single
            // 
            this.dbf_to_excel_single.Location = new System.Drawing.Point(1, 180);
            this.dbf_to_excel_single.Name = "dbf_to_excel_single";
            this.dbf_to_excel_single.Size = new System.Drawing.Size(167, 53);
            this.dbf_to_excel_single.TabIndex = 0;
            this.dbf_to_excel_single.Text = "SAVE SELECTED DBF TO EXCEL";
            this.dbf_to_excel_single.UseVisualStyleBackColor = true;
            this.dbf_to_excel_single.Click += new System.EventHandler(this.Dbf_to_excel_single_Click);
            // 
            // dbf_to_excel_series
            // 
            this.dbf_to_excel_series.Location = new System.Drawing.Point(0, 121);
            this.dbf_to_excel_series.Name = "dbf_to_excel_series";
            this.dbf_to_excel_series.Size = new System.Drawing.Size(167, 53);
            this.dbf_to_excel_series.TabIndex = 0;
            this.dbf_to_excel_series.Text = "SAVE ALL DBF TO EXCLE";
            this.dbf_to_excel_series.UseVisualStyleBackColor = true;
            this.dbf_to_excel_series.Click += new System.EventHandler(this.Dbf_to_excel_series_Click);
            // 
            // view_db
            // 
            this.view_db.Location = new System.Drawing.Point(1, 62);
            this.view_db.Name = "view_db";
            this.view_db.Size = new System.Drawing.Size(167, 53);
            this.view_db.TabIndex = 0;
            this.view_db.Text = "VIEW DATABASE";
            this.view_db.UseVisualStyleBackColor = true;
            this.view_db.Click += new System.EventHandler(this.View_db_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "SELECT DATABASE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1251, 483);
            this.panel1.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(174, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1077, 483);
            this.panel4.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(1077, 483);
            this.dataGridView1.TabIndex = 2;
            // 
            // db_viewer
            // 
            this.db_viewer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Db_viewer_DoWork);
            this.db_viewer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Db_viewer_ProgressChanged);
            this.db_viewer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Db_viewer_RunWorkerCompleted);
            // 
            // db_to_excel_single_worker
            // 
            this.db_to_excel_single_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Db_to_excel_single_worker_DoWork);
            this.db_to_excel_single_worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Db_to_excel_single_worker_ProgressChanged);
            this.db_to_excel_single_worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Db_to_excel_single_worker_RunWorkerCompleted);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(552, 16);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(388, 23);
            this.progress.Step = 1;
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(947, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Query";
            // 
            // query
            // 
            this.query.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.query.ForeColor = System.Drawing.Color.Crimson;
            this.query.Location = new System.Drawing.Point(67, 45);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(1172, 149);
            this.query.TabIndex = 13;
            this.query.Text = "";
            // 
            // rv
            // 
            this.rv.Location = new System.Drawing.Point(0, 0);
            this.rv.Name = "ReportViewer";
            this.rv.ServerReport.BearerToken = null;
            this.rv.Size = new System.Drawing.Size(396, 246);
            this.rv.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 683);
            this.Controls.Add(this.query);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker dbf_to_excel_series_worker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button dbf_to_excel_single;
        private System.Windows.Forms.Button dbf_to_excel_series;
        private System.Windows.Forms.Button view_db;
        private System.Windows.Forms.Button clear;
        private System.ComponentModel.BackgroundWorker db_viewer;
        private System.ComponentModel.BackgroundWorker db_to_excel_single_worker;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox query;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Microsoft.Reporting.WinForms.ReportViewer rv;
        private System.Windows.Forms.Button button2;
    }
}


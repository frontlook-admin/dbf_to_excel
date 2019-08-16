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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dbf_to_excel_series_worker = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.clear = new System.Windows.Forms.Button();
            this.dbf_to_excel_single = new System.Windows.Forms.Button();
            this.dbf_to_excel_series = new System.Windows.Forms.Button();
            this.view_db = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.db_viewer = new System.ComponentModel.BackgroundWorker();
            this.db_to_excel_single_worker = new System.ComponentModel.BackgroundWorker();
            this.stop = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Location = new System.Drawing.Point(170, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(164, 477);
            this.panel3.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(0, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Set Parameters";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 483);
            this.panel1.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(340, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(717, 483);
            this.panel4.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridView1.Size = new System.Drawing.Size(717, 483);
            this.dataGridView1.TabIndex = 2;
            // 
            // db_to_excel_single_worker
            // 
            this.db_to_excel_single_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Db_to_excel_single_worker_DoWork);
            this.db_to_excel_single_worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Db_to_excel_single_worker_ProgressChanged);
            this.db_to_excel_single_worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Db_to_excel_single_worker_RunWorkerCompleted);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 528);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button dbf_to_excel_single;
        private System.Windows.Forms.Button dbf_to_excel_series;
        private System.Windows.Forms.Button view_db;
        private System.Windows.Forms.Button clear;
        private System.ComponentModel.BackgroundWorker db_viewer;
        private System.ComponentModel.BackgroundWorker db_to_excel_single_worker;
        private System.Windows.Forms.Button stop;
    }
}


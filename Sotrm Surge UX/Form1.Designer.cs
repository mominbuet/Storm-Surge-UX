namespace Sotrm_Surge_UX
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDist = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbThana = new System.Windows.Forms.ComboBox();
            this.cmbScenerio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUnionID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUnion = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmdExport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lbllog = new System.Windows.Forms.Label();
            this.txtareaLoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtobsLoc = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataFolder = new System.Windows.Forms.TextBox();
            this.lblEquation = new System.Windows.Forms.Label();
            this.btnDataLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "District";
            // 
            // cmbDist
            // 
            this.cmbDist.FormattingEnabled = true;
            this.cmbDist.Location = new System.Drawing.Point(70, 11);
            this.cmbDist.Name = "cmbDist";
            this.cmbDist.Size = new System.Drawing.Size(121, 21);
            this.cmbDist.TabIndex = 26;
            this.cmbDist.SelectedIndexChanged += new System.EventHandler(this.cmbDistChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Thana";
            // 
            // cmbThana
            // 
            this.cmbThana.FormattingEnabled = true;
            this.cmbThana.Location = new System.Drawing.Point(70, 38);
            this.cmbThana.Name = "cmbThana";
            this.cmbThana.Size = new System.Drawing.Size(121, 21);
            this.cmbThana.TabIndex = 24;
            // 
            // cmbScenerio
            // 
            this.cmbScenerio.FormattingEnabled = true;
            this.cmbScenerio.Location = new System.Drawing.Point(70, 121);
            this.cmbScenerio.Name = "cmbScenerio";
            this.cmbScenerio.Size = new System.Drawing.Size(121, 21);
            this.cmbScenerio.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Scenerio";
            // 
            // cmbUnionID
            // 
            this.cmbUnionID.FormattingEnabled = true;
            this.cmbUnionID.Location = new System.Drawing.Point(70, 94);
            this.cmbUnionID.Name = "cmbUnionID";
            this.cmbUnionID.Size = new System.Drawing.Size(121, 21);
            this.cmbUnionID.TabIndex = 21;
            this.cmbUnionID.SelectedIndexChanged += new System.EventHandler(this.cmbUnionID_changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "NGEOCode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Union";
            // 
            // cmbUnion
            // 
            this.cmbUnion.FormattingEnabled = true;
            this.cmbUnion.Location = new System.Drawing.Point(70, 65);
            this.cmbUnion.Name = "cmbUnion";
            this.cmbUnion.Size = new System.Drawing.Size(121, 21);
            this.cmbUnion.TabIndex = 18;
            this.cmbUnion.SelectedIndexChanged += new System.EventHandler(this.cmbUnion_changed);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(203, 11);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(820, 368);
            this.chart1.TabIndex = 28;
            this.chart1.Text = "chart1";
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(538, 404);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(75, 23);
            this.cmdExport.TabIndex = 31;
            this.cmdExport.Text = "Export";
            this.cmdExport.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(619, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Generate graph";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.generate_graph_click);
            // 
            // lbllog
            // 
            this.lbllog.AutoSize = true;
            this.lbllog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllog.ForeColor = System.Drawing.Color.Coral;
            this.lbllog.Location = new System.Drawing.Point(14, 385);
            this.lbllog.Name = "lbllog";
            this.lbllog.Size = new System.Drawing.Size(35, 17);
            this.lbllog.TabIndex = 32;
            this.lbllog.Text = "Log";
            // 
            // txtareaLoc
            // 
            this.txtareaLoc.Location = new System.Drawing.Point(14, 278);
            this.txtareaLoc.Name = "txtareaLoc";
            this.txtareaLoc.Size = new System.Drawing.Size(183, 20);
            this.txtareaLoc.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Area excel file location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Observation excel file location:";
            // 
            // txtobsLoc
            // 
            this.txtobsLoc.Location = new System.Drawing.Point(14, 323);
            this.txtobsLoc.Name = "txtobsLoc";
            this.txtobsLoc.Size = new System.Drawing.Size(183, 20);
            this.txtobsLoc.TabIndex = 35;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(70, 167);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Landfall Location";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Data Folder";
            // 
            // txtDataFolder
            // 
            this.txtDataFolder.Location = new System.Drawing.Point(14, 239);
            this.txtDataFolder.Name = "txtDataFolder";
            this.txtDataFolder.Size = new System.Drawing.Size(183, 20);
            this.txtDataFolder.TabIndex = 39;
            // 
            // lblEquation
            // 
            this.lblEquation.AutoSize = true;
            this.lblEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquation.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblEquation.Location = new System.Drawing.Point(200, 414);
            this.lblEquation.Name = "lblEquation";
            this.lblEquation.Size = new System.Drawing.Size(0, 13);
            this.lblEquation.TabIndex = 41;
            // 
            // btnDataLoad
            // 
            this.btnDataLoad.Location = new System.Drawing.Point(457, 404);
            this.btnDataLoad.Name = "btnDataLoad";
            this.btnDataLoad.Size = new System.Drawing.Size(75, 23);
            this.btnDataLoad.TabIndex = 42;
            this.btnDataLoad.Text = "Load Data";
            this.btnDataLoad.UseVisualStyleBackColor = true;
            this.btnDataLoad.Click += new System.EventHandler(this.brnLoadClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 439);
            this.Controls.Add(this.btnDataLoad);
            this.Controls.Add(this.lblEquation);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDataFolder);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtobsLoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtareaLoc);
            this.Controls.Add(this.lbllog);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbDist);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbThana);
            this.Controls.Add(this.cmbScenerio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbUnionID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbUnion);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbThana;
        private System.Windows.Forms.ComboBox cmbScenerio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbUnionID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUnion;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lbllog;
        private System.Windows.Forms.TextBox txtareaLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtobsLoc;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDataFolder;
        private System.Windows.Forms.Label lblEquation;
        private System.Windows.Forms.Button btnDataLoad;

    }
}


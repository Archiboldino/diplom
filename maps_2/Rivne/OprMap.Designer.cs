namespace Odessa
{
    partial class OprMap
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
            this.components = new System.ComponentModel.Container();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.x = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFromDB = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnStartPoint = new System.Windows.Forms.Button();
            this.btnEndPoint = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbIssue = new System.Windows.Forms.ComboBox();
            this.lbCalculation = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbParams = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.ContextMenuStrip = this.contextMenuStrip2;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(18, 18);
            this.gMapControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(1457, 826);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.gMapControl_OnPolygonClick);
            this.gMapControl.Load += new System.EventHandler(this.gMapControl_Load);
            this.gMapControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseDoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(184, 94);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(183, 30);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(183, 30);
            this.toolStripMenuItem4.Text = "Refresh map";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(183, 30);
            // 
            // x
            // 
            this.x.AutoSize = true;
            this.x.Location = new System.Drawing.Point(274, 888);
            this.x.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(0, 20);
            this.x.TabIndex = 18;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(221, 64);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(220, 30);
            this.toolStripMenuItem1.Text = "New company";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(220, 30);
            this.toolStripMenuItem2.Text = "View emmissions";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(1535, 243);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(380, 248);
            this.dataGridView1.TabIndex = 37;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "lattitude";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "langitude";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(1924, 500);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // btnFromDB
            // 
            this.btnFromDB.Location = new System.Drawing.Point(1531, 163);
            this.btnFromDB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFromDB.Name = "btnFromDB";
            this.btnFromDB.Size = new System.Drawing.Size(370, 35);
            this.btnFromDB.TabIndex = 40;
            this.btnFromDB.Text = "відобразити обраний полігон";
            this.btnFromDB.UseVisualStyleBackColor = true;
            this.btnFromDB.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1483, 23);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(39, 35);
            this.button10.TabIndex = 41;
            this.button10.Text = "+";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(1483, 68);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(39, 35);
            this.button11.TabIndex = 42;
            this.button11.Text = "-";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1531, 223);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "таблиця з точками";
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(1535, 550);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(370, 35);
            this.btnDel.TabIndex = 44;
            this.btnDel.Text = "видалити останню точку";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.button12_Click);
            // 
            // btnStartPoint
            // 
            this.btnStartPoint.Location = new System.Drawing.Point(1535, 505);
            this.btnStartPoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartPoint.Name = "btnStartPoint";
            this.btnStartPoint.Size = new System.Drawing.Size(132, 35);
            this.btnStartPoint.TabIndex = 45;
            this.btnStartPoint.Text = "почати";
            this.btnStartPoint.UseVisualStyleBackColor = true;
            this.btnStartPoint.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEndPoint
            // 
            this.btnEndPoint.Location = new System.Drawing.Point(1676, 505);
            this.btnEndPoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEndPoint.Name = "btnEndPoint";
            this.btnEndPoint.Size = new System.Drawing.Size(112, 35);
            this.btnEndPoint.TabIndex = 46;
            this.btnEndPoint.Text = "завершити";
            this.btnEndPoint.UseVisualStyleBackColor = true;
            this.btnEndPoint.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(1559, 631);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(316, 35);
            this.button3.TabIndex = 47;
            this.button3.Text = "Square";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbIssue
            // 
            this.cbIssue.FormattingEnabled = true;
            this.cbIssue.Location = new System.Drawing.Point(1531, 47);
            this.cbIssue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbIssue.Name = "cbIssue";
            this.cbIssue.Size = new System.Drawing.Size(373, 28);
            this.cbIssue.TabIndex = 48;
            this.cbIssue.SelectedIndexChanged += new System.EventHandler(this.cbCalc_SelectedIndexChanged);
            // 
            // lbCalculation
            // 
            this.lbCalculation.AutoSize = true;
            this.lbCalculation.Location = new System.Drawing.Point(1531, 22);
            this.lbCalculation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCalculation.Name = "lbCalculation";
            this.lbCalculation.Size = new System.Drawing.Size(126, 20);
            this.lbCalculation.TabIndex = 49;
            this.lbCalculation.Text = "Оберіть задачу";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1796, 505);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 54;
            this.button1.Text = "зберегти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // cbParams
            // 
            this.cbParams.Enabled = false;
            this.cbParams.FormattingEnabled = true;
            this.cbParams.Location = new System.Drawing.Point(1531, 122);
            this.cbParams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbParams.Name = "cbParams";
            this.cbParams.Size = new System.Drawing.Size(373, 28);
            this.cbParams.TabIndex = 52;
            this.cbParams.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1531, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Оберіть параметр";
            this.label1.Visible = false;
            // 
            // OprMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 862);
            this.ContextMenuStrip = this.contextMenuStrip2;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbParams);
            this.Controls.Add(this.lbCalculation);
            this.Controls.Add(this.cbIssue);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnEndPoint);
            this.Controls.Add(this.btnStartPoint);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.btnFromDB);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.x);
            this.Controls.Add(this.gMapControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OprMap";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Map_Load);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Label x;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFromDB;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnStartPoint;
        private System.Windows.Forms.Button btnEndPoint;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbIssue;
        private System.Windows.Forms.Label lbCalculation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbParams;
        private System.Windows.Forms.Label label1;
    }
}


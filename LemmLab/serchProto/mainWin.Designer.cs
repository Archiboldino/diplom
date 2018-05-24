namespace experts_jurist
{
    partial class mainWin
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.RozrahTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.ResultTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.RedaktTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.проМодульToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.проблемыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RozrahTSM,
            this.ResultTSM,
            this.RedaktTSM,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.проМодульToolStripMenuItem,
            this.проблемыToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(962, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// RozrahTSM
			// 
			this.RozrahTSM.Name = "RozrahTSM";
			this.RozrahTSM.Size = new System.Drawing.Size(132, 20);
			this.RozrahTSM.Text = "Запропонувати захід";
			this.RozrahTSM.Click += new System.EventHandler(this.offer_Click);
			// 
			// ResultTSM
			// 
			this.ResultTSM.Name = "ResultTSM";
			this.ResultTSM.Size = new System.Drawing.Size(222, 20);
			this.ResultTSM.Text = "Перегляід та оцінка існуючих заходів";
			this.ResultTSM.Click += new System.EventHandler(this.estimate_Click);
			// 
			// RedaktTSM
			// 
			this.RedaktTSM.Name = "RedaktTSM";
			this.RedaktTSM.Size = new System.Drawing.Size(175, 20);
			this.RedaktTSM.Text = "Пошук по законодавчій базі";
			this.RedaktTSM.Click += new System.EventHandler(this.search_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(103, 20);
			this.toolStripMenuItem2.Text = "Новий шаблон";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.newTemplateToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(112, 20);
			this.toolStripMenuItem3.Text = "Змiнити Шаблон";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.alterTemplateToolStripMenuItem_Click);
			// 
			// проМодульToolStripMenuItem
			// 
			this.проМодульToolStripMenuItem.Name = "проМодульToolStripMenuItem";
			this.проМодульToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
			this.проМодульToolStripMenuItem.Text = "Про модуль";
			this.проМодульToolStripMenuItem.Click += new System.EventHandler(this.проМодульToolStripMenuItem_Click);
			// 
			// проблемыToolStripMenuItem
			// 
			this.проблемыToolStripMenuItem.Name = "проблемыToolStripMenuItem";
			this.проблемыToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
			this.проблемыToolStripMenuItem.Text = "Проблеми";
			this.проблемыToolStripMenuItem.Click += new System.EventHandler(this.проблемыToolStripMenuItem_Click);
			// 
			// mainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(962, 423);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "mainWin";
			this.Text = "Головна";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.mainWin_Load);
			this.Shown += new System.EventHandler(this.mainWin_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem RozrahTSM;
        private System.Windows.Forms.ToolStripMenuItem ResultTSM;
        private System.Windows.Forms.ToolStripMenuItem RedaktTSM;
        private System.Windows.Forms.ToolStripMenuItem проМодульToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem проблемыToolStripMenuItem;
	}
}
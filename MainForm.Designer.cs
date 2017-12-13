namespace oprForm
{
	partial class MainForm
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
			this.eventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventsToolStripMenuItem,
            this.statsToolStripMenuItem,
            this.reportToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(655, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// eventsToolStripMenuItem
			// 
			this.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem";
			this.eventsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
			this.eventsToolStripMenuItem.Text = "Мероприятия";
			this.eventsToolStripMenuItem.Click += new System.EventHandler(this.eventToolStripMenuItem_Click);
			// 
			// statsToolStripMenuItem
			// 
			this.statsToolStripMenuItem.Name = "statsToolStripMenuItem";
			this.statsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
			this.statsToolStripMenuItem.Text = "Статистика";
			// 
			// reportToolStripMenuItem
			// 
			this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
			this.reportToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.reportToolStripMenuItem.Text = "Отчеты";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(655, 370);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem statsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
	}
}


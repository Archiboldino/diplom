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
            this.шаблониToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переглядПроблемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ресурсиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заходиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переглядЗаходiвToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.змiнитиШаблонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шаблониToolStripMenuItem,
            this.переглядПроблемToolStripMenuItem,
            this.ресурсиToolStripMenuItem,
            this.заходиToolStripMenuItem,
            this.змiнитиШаблонToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(982, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // шаблониToolStripMenuItem
            // 
            this.шаблониToolStripMenuItem.Name = "шаблониToolStripMenuItem";
            this.шаблониToolStripMenuItem.Size = new System.Drawing.Size(146, 29);
            this.шаблониToolStripMenuItem.Text = "Новий шаблон";
            this.шаблониToolStripMenuItem.Click += new System.EventHandler(this.шаблониToolStripMenuItem_Click);
            // 
            // переглядПроблемToolStripMenuItem
            // 
            this.переглядПроблемToolStripMenuItem.Name = "переглядПроблемToolStripMenuItem";
            this.переглядПроблемToolStripMenuItem.Size = new System.Drawing.Size(110, 29);
            this.переглядПроблемToolStripMenuItem.Text = "Проблеми";
            this.переглядПроблемToolStripMenuItem.Click += new System.EventHandler(this.переглядПроблемToolStripMenuItem_Click);
            // 
            // ресурсиToolStripMenuItem
            // 
            this.ресурсиToolStripMenuItem.Name = "ресурсиToolStripMenuItem";
            this.ресурсиToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.ресурсиToolStripMenuItem.Text = "Ресурси";
            this.ресурсиToolStripMenuItem.Click += new System.EventHandler(this.ресурсиToolStripMenuItem_Click);
            // 
            // заходиToolStripMenuItem
            // 
            this.заходиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переглядЗаходiвToolStripMenuItem,
            this.toolStripMenuItem2,
            this.eventsToolStripMenuItem});
            this.заходиToolStripMenuItem.Name = "заходиToolStripMenuItem";
            this.заходиToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.заходиToolStripMenuItem.Text = "Заходи";
            // 
            // переглядЗаходiвToolStripMenuItem
            // 
            this.переглядЗаходiвToolStripMenuItem.Name = "переглядЗаходiвToolStripMenuItem";
            this.переглядЗаходiвToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.переглядЗаходiвToolStripMenuItem.Text = "Перегляд заходiв";
            this.переглядЗаходiвToolStripMenuItem.Click += new System.EventHandler(this.переглядЗаходiвToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(238, 30);
            this.toolStripMenuItem2.Text = "Змiнити Захiд";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // eventsToolStripMenuItem
            // 
            this.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem";
            this.eventsToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.eventsToolStripMenuItem.Text = "Новий захiд";
            this.eventsToolStripMenuItem.Click += new System.EventHandler(this.eventsToolStripMenuItem_Click);
            // 
            // змiнитиШаблонToolStripMenuItem
            // 
            this.змiнитиШаблонToolStripMenuItem.Name = "змiнитиШаблонToolStripMenuItem";
            this.змiнитиШаблонToolStripMenuItem.Size = new System.Drawing.Size(159, 29);
            this.змiнитиШаблонToolStripMenuItem.Text = "Змiнити Шаблон";
            this.змiнитиШаблонToolStripMenuItem.Click += new System.EventHandler(this.змiнитиШаблонToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 569);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Головне меню";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem переглядПроблемToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шаблониToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ресурсиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заходиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переглядЗаходiвToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem змiнитиШаблонToolStripMenuItem;
    }
}


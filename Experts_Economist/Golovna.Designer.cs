namespace Experts_Economist
{
	partial class Golovna
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
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip2 = new System.Windows.Forms.MenuStrip();
			this.шаблониToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.переглядПроблемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ресурсиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.заходиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.переглядЗаходiвToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.eventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.змiнитиШаблонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.user_redakt_button = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.menuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.RozrahTSM,
			this.ResultTSM,
			this.RedaktTSM});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1404, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// RozrahTSM
			// 
			this.RozrahTSM.Name = "RozrahTSM";
			this.RozrahTSM.Size = new System.Drawing.Size(82, 20);
			this.RozrahTSM.Text = "Розрахунок";
			this.RozrahTSM.Click += new System.EventHandler(this.RozrahTSM_Click);
			// 
			// ResultTSM
			// 
			this.ResultTSM.Name = "ResultTSM";
			this.ResultTSM.Size = new System.Drawing.Size(136, 20);
			this.ResultTSM.Text = "Перегляд результатів";
			this.ResultTSM.Click += new System.EventHandler(this.ResultTSM_Click);
			// 
			// RedaktTSM
			// 
			this.RedaktTSM.Name = "RedaktTSM";
			this.RedaktTSM.Size = new System.Drawing.Size(117, 20);
			this.RedaktTSM.Text = "Редактор формул";
			this.RedaktTSM.Visible = false;
			this.RedaktTSM.Click += new System.EventHandler(this.RedaktTSM_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(736, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Id експерта";
			// 
			// menuStrip2
			// 
			this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.шаблониToolStripMenuItem,
			this.переглядПроблемToolStripMenuItem,
			this.ресурсиToolStripMenuItem,
			this.заходиToolStripMenuItem,
			this.змiнитиШаблонToolStripMenuItem});
			this.menuStrip2.Location = new System.Drawing.Point(0, 24);
			this.menuStrip2.Name = "menuStrip2";
			this.menuStrip2.Size = new System.Drawing.Size(1404, 24);
			this.menuStrip2.TabIndex = 5;
			this.menuStrip2.Text = "menuStrip2";
			// 
			// шаблониToolStripMenuItem
			// 
			this.шаблониToolStripMenuItem.Name = "шаблониToolStripMenuItem";
			this.шаблониToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
			this.шаблониToolStripMenuItem.Text = "Новий шаблон";
			this.шаблониToolStripMenuItem.Click += new System.EventHandler(this.шаблониToolStripMenuItem_Click);
			// 
			// переглядПроблемToolStripMenuItem
			// 
			this.переглядПроблемToolStripMenuItem.Name = "переглядПроблемToolStripMenuItem";
			this.переглядПроблемToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.переглядПроблемToolStripMenuItem.Text = "Задачі";
			this.переглядПроблемToolStripMenuItem.Click += new System.EventHandler(this.переглядПроблемToolStripMenuItem_Click);
			// 
			// ресурсиToolStripMenuItem
			// 
			this.ресурсиToolStripMenuItem.Name = "ресурсиToolStripMenuItem";
			this.ресурсиToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
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
			this.заходиToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.заходиToolStripMenuItem.Text = "Заходи";
			// 
			// переглядЗаходiвToolStripMenuItem
			// 
			this.переглядЗаходiвToolStripMenuItem.Name = "переглядЗаходiвToolStripMenuItem";
			this.переглядЗаходiвToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.переглядЗаходiвToolStripMenuItem.Text = "Перегляд заходiв";
			this.переглядЗаходiвToolStripMenuItem.Click += new System.EventHandler(this.переглядЗаходiвToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 22);
			this.toolStripMenuItem2.Text = "Змiнити Захiд";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// eventsToolStripMenuItem
			// 
			this.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem";
			this.eventsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.eventsToolStripMenuItem.Text = "Новий захiд";
			this.eventsToolStripMenuItem.Click += new System.EventHandler(this.eventsToolStripMenuItem_Click);
			// 
			// змiнитиШаблонToolStripMenuItem
			// 
			this.змiнитиШаблонToolStripMenuItem.Name = "змiнитиШаблонToolStripMenuItem";
			this.змiнитиШаблонToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
			this.змiнитиШаблонToolStripMenuItem.Text = "Змiнити Шаблон";
			this.змiнитиШаблонToolStripMenuItem.Click += new System.EventHandler(this.змiнитиШаблонToolStripMenuItem_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(736, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Експерт";
			// 
			// user_redakt_button
			// 
			this.user_redakt_button.Location = new System.Drawing.Point(707, 9);
			this.user_redakt_button.Name = "user_redakt_button";
			this.user_redakt_button.Size = new System.Drawing.Size(23, 22);
			this.user_redakt_button.TabIndex = 9;
			this.user_redakt_button.Text = "+";
			this.user_redakt_button.UseVisualStyleBackColor = true;
			this.user_redakt_button.Visible = false;
			this.user_redakt_button.Click += new System.EventHandler(this.user_redakt_button_Click);
			// 
			// Golovna
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1404, 681);
			this.Controls.Add(this.user_redakt_button);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip2);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Golovna";
			this.Text = "Головна";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Golovna_FormClosed);
			this.Load += new System.EventHandler(this.Golovna_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.menuStrip2.ResumeLayout(false);
			this.menuStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem RozrahTSM;
		private System.Windows.Forms.ToolStripMenuItem ResultTSM;
		private System.Windows.Forms.ToolStripMenuItem RedaktTSM;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuStrip menuStrip2;
		private System.Windows.Forms.ToolStripMenuItem шаблониToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem переглядПроблемToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ресурсиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem заходиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem переглядЗаходiвToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem змiнитиШаблонToolStripMenuItem;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button user_redakt_button;
	}
}
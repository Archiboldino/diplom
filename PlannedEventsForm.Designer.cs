namespace oprForm
{
	partial class PlannedEventsForm
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
			this.eventsLB = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.addBtn = new System.Windows.Forms.Button();
			this.eventListGrid = new System.Windows.Forms.DataGridView();
			this.Resource = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.eventListGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// eventsLB
			// 
			this.eventsLB.FormattingEnabled = true;
			this.eventsLB.Location = new System.Drawing.Point(12, 36);
			this.eventsLB.Name = "eventsLB";
			this.eventsLB.Size = new System.Drawing.Size(111, 264);
			this.eventsLB.TabIndex = 0;
			this.eventsLB.SelectedIndexChanged += new System.EventHandler(this.eventsLB_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Event List";
			// 
			// addBtn
			// 
			this.addBtn.Location = new System.Drawing.Point(16, 306);
			this.addBtn.Name = "addBtn";
			this.addBtn.Size = new System.Drawing.Size(107, 23);
			this.addBtn.TabIndex = 3;
			this.addBtn.Text = "Add";
			this.addBtn.UseVisualStyleBackColor = true;
			this.addBtn.Click += new System.EventHandler(this.button1_Click);
			// 
			// eventListGrid
			// 
			this.eventListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.eventListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Resource,
            this.Description,
            this.Value});
			this.eventListGrid.Location = new System.Drawing.Point(129, 36);
			this.eventListGrid.Name = "eventListGrid";
			this.eventListGrid.Size = new System.Drawing.Size(301, 264);
			this.eventListGrid.TabIndex = 4;
			this.eventListGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.commitValue);
			// 
			// Resource
			// 
			this.Resource.HeaderText = "Resource";
			this.Resource.Name = "Resource";
			this.Resource.ReadOnly = true;
			// 
			// Description
			// 
			this.Description.HeaderText = "Description";
			this.Description.Name = "Description";
			// 
			// Value
			// 
			this.Value.HeaderText = "Value";
			this.Value.Name = "Value";
			// 
			// PlannedEventsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(436, 341);
			this.Controls.Add(this.eventListGrid);
			this.Controls.Add(this.addBtn);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.eventsLB);
			this.Name = "PlannedEventsForm";
			this.Text = "PlannedEventsForm";
			this.Load += new System.EventHandler(this.PlannedEventsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.eventListGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox eventsLB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button addBtn;
		private System.Windows.Forms.DataGridView eventListGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn Resource;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
	}
}
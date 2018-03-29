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
            this.descTB = new System.Windows.Forms.TextBox();
            this.evNameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addGB = new System.Windows.Forms.GroupBox();
            this.issuesCB = new System.Windows.Forms.ComboBox();
            this.onlyExpCB = new System.Windows.Forms.CheckBox();
            this.resLB = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.eventListGrid)).BeginInit();
            this.addGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventsLB
            // 
            this.eventsLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.eventsLB.FormattingEnabled = true;
            this.eventsLB.ItemHeight = 20;
            this.eventsLB.Location = new System.Drawing.Point(18, 55);
            this.eventsLB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventsLB.Name = "eventsLB";
            this.eventsLB.Size = new System.Drawing.Size(164, 404);
            this.eventsLB.TabIndex = 0;
            this.eventsLB.SelectedIndexChanged += new System.EventHandler(this.eventsLB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Шаблони заходiв";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(7, 19);
            this.addBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(160, 35);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Додати";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // eventListGrid
            // 
            this.eventListGrid.AllowUserToAddRows = false;
            this.eventListGrid.AllowUserToDeleteRows = false;
            this.eventListGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Resource,
            this.Description,
            this.Value});
            this.eventListGrid.Location = new System.Drawing.Point(183, 52);
            this.eventListGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventListGrid.Name = "eventListGrid";
            this.eventListGrid.Size = new System.Drawing.Size(474, 404);
            this.eventListGrid.TabIndex = 4;
            this.eventListGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.commitValue);
            // 
            // Resource
            // 
            this.Resource.HeaderText = "Resource";
            this.Resource.Name = "Resource";
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
            // descTB
            // 
            this.descTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descTB.Location = new System.Drawing.Point(333, 23);
            this.descTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.descTB.Name = "descTB";
            this.descTB.Size = new System.Drawing.Size(356, 26);
            this.descTB.TabIndex = 5;
            this.descTB.Text = "Description";
            // 
            // evNameTB
            // 
            this.evNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.evNameTB.Location = new System.Drawing.Point(177, 23);
            this.evNameTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.evNameTB.Name = "evNameTB";
            this.evNameTB.Size = new System.Drawing.Size(214, 26);
            this.evNameTB.TabIndex = 6;
            this.evNameTB.Text = "Event Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Список ресурсiв";
            // 
            // addGB
            // 
            this.addGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addGB.Controls.Add(this.issuesCB);
            this.addGB.Controls.Add(this.descTB);
            this.addGB.Controls.Add(this.addBtn);
            this.addGB.Controls.Add(this.evNameTB);
            this.addGB.Location = new System.Drawing.Point(18, 467);
            this.addGB.Name = "addGB";
            this.addGB.Size = new System.Drawing.Size(838, 66);
            this.addGB.TabIndex = 8;
            this.addGB.TabStop = false;
            this.addGB.Visible = false;
            // 
            // issuesCB
            // 
            this.issuesCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.issuesCB.FormattingEnabled = true;
            this.issuesCB.Location = new System.Drawing.Point(630, 23);
            this.issuesCB.Name = "issuesCB";
            this.issuesCB.Size = new System.Drawing.Size(199, 28);
            this.issuesCB.TabIndex = 7;
            // 
            // onlyExpCB
            // 
            this.onlyExpCB.AutoSize = true;
            this.onlyExpCB.Location = new System.Drawing.Point(165, 20);
            this.onlyExpCB.Name = "onlyExpCB";
            this.onlyExpCB.Size = new System.Drawing.Size(248, 24);
            this.onlyExpCB.TabIndex = 9;
            this.onlyExpCB.Text = "Тільки есперта користувача";
            this.onlyExpCB.UseVisualStyleBackColor = true;
            this.onlyExpCB.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // resLB
            // 
            this.resLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resLB.FormattingEnabled = true;
            this.resLB.ItemHeight = 20;
            this.resLB.Location = new System.Drawing.Point(664, 52);
            this.resLB.Name = "resLB";
            this.resLB.Size = new System.Drawing.Size(192, 404);
            this.resLB.TabIndex = 10;
            this.resLB.DoubleClick += new System.EventHandler(this.resLB_DoubleClick);
            // 
            // PlannedEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 547);
            this.Controls.Add(this.resLB);
            this.Controls.Add(this.onlyExpCB);
            this.Controls.Add(this.addGB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eventListGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eventsLB);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PlannedEventsForm";
            this.Text = "Новий захiд";
            this.Load += new System.EventHandler(this.PlannedEventsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventListGrid)).EndInit();
            this.addGB.ResumeLayout(false);
            this.addGB.PerformLayout();
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
		private System.Windows.Forms.TextBox descTB;
		private System.Windows.Forms.TextBox evNameTB;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox addGB;
        private System.Windows.Forms.CheckBox onlyExpCB;
        private System.Windows.Forms.ComboBox issuesCB;
        private System.Windows.Forms.ListBox resLB;
    }
}
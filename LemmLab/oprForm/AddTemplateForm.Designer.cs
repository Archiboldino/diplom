namespace oprForm
{
    partial class AddTemplateForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.materialListGrid = new System.Windows.Forms.DataGridView();
			this.Resource = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameTB = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.descTB = new System.Windows.Forms.TextBox();
			this.addBtn = new System.Windows.Forms.Button();
			this.resourcesLB = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.materialListGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 323);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Назва шаблону";
			// 
			// materialListGrid
			// 
			this.materialListGrid.AllowUserToAddRows = false;
			this.materialListGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.materialListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.materialListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Resource});
			this.materialListGrid.Location = new System.Drawing.Point(111, 2);
			this.materialListGrid.Name = "materialListGrid";
			this.materialListGrid.ReadOnly = true;
			this.materialListGrid.Size = new System.Drawing.Size(445, 303);
			this.materialListGrid.TabIndex = 5;
			// 
			// Resource
			// 
			this.Resource.HeaderText = "Ресурс";
			this.Resource.Name = "Resource";
			this.Resource.ReadOnly = true;
			// 
			// nameTB
			// 
			this.nameTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nameTB.Location = new System.Drawing.Point(202, 321);
			this.nameTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.nameTB.Name = "nameTB";
			this.nameTB.Size = new System.Drawing.Size(133, 20);
			this.nameTB.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(61, 346);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Опис";
			// 
			// descTB
			// 
			this.descTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.descTB.Location = new System.Drawing.Point(202, 344);
			this.descTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.descTB.Name = "descTB";
			this.descTB.Size = new System.Drawing.Size(133, 20);
			this.descTB.TabIndex = 8;
			// 
			// addBtn
			// 
			this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.addBtn.Location = new System.Drawing.Point(480, 323);
			this.addBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.addBtn.Name = "addBtn";
			this.addBtn.Size = new System.Drawing.Size(63, 25);
			this.addBtn.TabIndex = 9;
			this.addBtn.Text = "Додати";
			this.addBtn.UseVisualStyleBackColor = true;
			this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
			// 
			// resourcesLB
			// 
			this.resourcesLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.resourcesLB.FormattingEnabled = true;
			this.resourcesLB.Location = new System.Drawing.Point(9, 22);
			this.resourcesLB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.resourcesLB.Name = "resourcesLB";
			this.resourcesLB.Size = new System.Drawing.Size(99, 277);
			this.resourcesLB.TabIndex = 10;
			this.resourcesLB.DoubleClick += new System.EventHandler(this.resourcesLB_DoubleClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 5);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Ресурси";
			// 
			// AddTemplateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(557, 366);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.resourcesLB);
			this.Controls.Add(this.addBtn);
			this.Controls.Add(this.descTB);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.nameTB);
			this.Controls.Add(this.materialListGrid);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "AddTemplateForm";
			this.Text = "Додати шаблон";
			this.Load += new System.EventHandler(this.AddTemplateForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.materialListGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView materialListGrid;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descTB;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ListBox resourcesLB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resource;
    }
}
namespace oprForm
{
    partial class AlterEventForm
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
            this.resLB = new System.Windows.Forms.ListBox();
            this.alterGB = new System.Windows.Forms.GroupBox();
            this.delBtn = new System.Windows.Forms.Button();
            this.issuesCB = new System.Windows.Forms.ComboBox();
            this.descTB = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.evNameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.eventListGrid = new System.Windows.Forms.DataGridView();
            this.Resource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.eventsLB = new System.Windows.Forms.ListBox();
            this.alterGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventListGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // resLB
            // 
            this.resLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resLB.FormattingEnabled = true;
            this.resLB.ItemHeight = 20;
            this.resLB.Location = new System.Drawing.Point(733, 37);
            this.resLB.Name = "resLB";
            this.resLB.Size = new System.Drawing.Size(203, 424);
            this.resLB.TabIndex = 17;
            this.resLB.DoubleClick += new System.EventHandler(this.addMaterial);
            // 
            // alterGB
            // 
            this.alterGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alterGB.Controls.Add(this.delBtn);
            this.alterGB.Controls.Add(this.issuesCB);
            this.alterGB.Controls.Add(this.descTB);
            this.alterGB.Controls.Add(this.addBtn);
            this.alterGB.Controls.Add(this.evNameTB);
            this.alterGB.Location = new System.Drawing.Point(12, 472);
            this.alterGB.Name = "alterGB";
            this.alterGB.Size = new System.Drawing.Size(932, 96);
            this.alterGB.TabIndex = 15;
            this.alterGB.TabStop = false;
            this.alterGB.Visible = false;
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(7, 61);
            this.delBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(160, 35);
            this.delBtn.TabIndex = 8;
            this.delBtn.Text = "Видалити";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // issuesCB
            // 
            this.issuesCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.issuesCB.FormattingEnabled = true;
            this.issuesCB.Location = new System.Drawing.Point(630, 23);
            this.issuesCB.Name = "issuesCB";
            this.issuesCB.Size = new System.Drawing.Size(293, 28);
            this.issuesCB.TabIndex = 7;
            // 
            // descTB
            // 
            this.descTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descTB.Location = new System.Drawing.Point(333, 23);
            this.descTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.descTB.Name = "descTB";
            this.descTB.Size = new System.Drawing.Size(450, 26);
            this.descTB.TabIndex = 5;
            this.descTB.Text = "Description";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(7, 19);
            this.addBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(160, 35);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Зберегти";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // evNameTB
            // 
            this.evNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.evNameTB.Location = new System.Drawing.Point(177, 23);
            this.evNameTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.evNameTB.Name = "evNameTB";
            this.evNameTB.Size = new System.Drawing.Size(308, 26);
            this.evNameTB.TabIndex = 6;
            this.evNameTB.Text = "Event Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(729, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Список ресурсiв";
            // 
            // eventListGrid
            // 
            this.eventListGrid.AllowUserToAddRows = false;
            this.eventListGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Resource,
            this.Description,
            this.Value});
            this.eventListGrid.Location = new System.Drawing.Point(169, 37);
            this.eventListGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventListGrid.Name = "eventListGrid";
            this.eventListGrid.Size = new System.Drawing.Size(557, 427);
            this.eventListGrid.TabIndex = 13;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Заходи";
            // 
            // eventsLB
            // 
            this.eventsLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.eventsLB.FormattingEnabled = true;
            this.eventsLB.ItemHeight = 20;
            this.eventsLB.Location = new System.Drawing.Point(4, 40);
            this.eventsLB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventsLB.Name = "eventsLB";
            this.eventsLB.Size = new System.Drawing.Size(164, 424);
            this.eventsLB.TabIndex = 11;
            this.eventsLB.SelectedIndexChanged += new System.EventHandler(this.eventsLB_SelectedIndexChanged);
            // 
            // AlterEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 580);
            this.Controls.Add(this.resLB);
            this.Controls.Add(this.alterGB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eventListGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eventsLB);
            this.Name = "AlterEventForm";
            this.Text = "Змiнити захiд";
            this.alterGB.ResumeLayout(false);
            this.alterGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventListGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox resLB;
        private System.Windows.Forms.GroupBox alterGB;
        private System.Windows.Forms.ComboBox issuesCB;
        private System.Windows.Forms.TextBox descTB;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox evNameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView eventListGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox eventsLB;
        private System.Windows.Forms.Button delBtn;
    }
}
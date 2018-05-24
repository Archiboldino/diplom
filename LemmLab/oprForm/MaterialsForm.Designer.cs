namespace oprForm
{
    partial class MaterialsForm
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
            this.resDGV = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // resDGV
            // 
            this.resDGV.AllowUserToAddRows = false;
            this.resDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCol,
            this.descCol});
            this.resDGV.Location = new System.Drawing.Point(12, 12);
            this.resDGV.Name = "resDGV";
            this.resDGV.RowTemplate.Height = 28;
            this.resDGV.Size = new System.Drawing.Size(420, 275);
            this.resDGV.TabIndex = 0;
            this.resDGV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.cacheResFromFirstCol);
            this.resDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.commitValue);
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "Назва";
            this.nameCol.Name = "nameCol";
            // 
            // descCol
            // 
            this.descCol.HeaderText = "Опис";
            this.descCol.Name = "descCol";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 308);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(99, 37);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Зберегти";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(130, 308);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(99, 37);
            this.delBtn.TabIndex = 2;
            this.delBtn.Text = "Видалити";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(251, 308);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(99, 37);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Додати";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // MaterialsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 357);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.resDGV);
            this.Name = "MaterialsForm";
            this.Text = "Ресурси";
            ((System.ComponentModel.ISupportInitialize)(this.resDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn descCol;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button addBtn;
    }
}
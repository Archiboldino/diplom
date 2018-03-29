namespace MedicForm
{
    partial class Result
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
            this.resultGroupBox = new System.Windows.Forms.GroupBox();
            this.issueDesc = new System.Windows.Forms.Label();
            this.issueName = new System.Windows.Forms.Label();
            this.delPokaz = new System.Windows.Forms.Button();
            this.delSeriaButt = new System.Windows.Forms.Button();
            this.descSeria = new System.Windows.Forms.Label();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.seriaNumber = new System.Windows.Forms.Label();
            this.seriesBox = new System.Windows.Forms.ComboBox();
            this.resultGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // resultGroupBox
            // 
            this.resultGroupBox.Controls.Add(this.issueDesc);
            this.resultGroupBox.Controls.Add(this.issueName);
            this.resultGroupBox.Controls.Add(this.delPokaz);
            this.resultGroupBox.Controls.Add(this.delSeriaButt);
            this.resultGroupBox.Controls.Add(this.descSeria);
            this.resultGroupBox.Controls.Add(this.dataGridViewResult);
            this.resultGroupBox.Controls.Add(this.seriaNumber);
            this.resultGroupBox.Controls.Add(this.seriesBox);
            this.resultGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultGroupBox.Location = new System.Drawing.Point(29, 12);
            this.resultGroupBox.Name = "resultGroupBox";
            this.resultGroupBox.Size = new System.Drawing.Size(479, 359);
            this.resultGroupBox.TabIndex = 33;
            this.resultGroupBox.TabStop = false;
            this.resultGroupBox.Text = "Перегляд результатів розрахунків";
            // 
            // issueDesc
            // 
            this.issueDesc.AutoSize = true;
            this.issueDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.issueDesc.Location = new System.Drawing.Point(6, 114);
            this.issueDesc.Name = "issueDesc";
            this.issueDesc.Size = new System.Drawing.Size(39, 16);
            this.issueDesc.TabIndex = 31;
            this.issueDesc.Text = "опис";
            // 
            // issueName
            // 
            this.issueName.AutoSize = true;
            this.issueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.issueName.Location = new System.Drawing.Point(6, 87);
            this.issueName.Name = "issueName";
            this.issueName.Size = new System.Drawing.Size(33, 18);
            this.issueName.TabIndex = 30;
            this.issueName.Text = "ім\'я";
            // 
            // delPokaz
            // 
            this.delPokaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delPokaz.Location = new System.Drawing.Point(155, 146);
            this.delPokaz.Name = "delPokaz";
            this.delPokaz.Size = new System.Drawing.Size(171, 23);
            this.delPokaz.TabIndex = 29;
            this.delPokaz.Text = "Видалити показник";
            this.delPokaz.UseVisualStyleBackColor = true;
            this.delPokaz.Click += new System.EventHandler(this.delPokaz_Click);
            // 
            // delSeriaButt
            // 
            this.delSeriaButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delSeriaButt.Location = new System.Drawing.Point(6, 146);
            this.delSeriaButt.Name = "delSeriaButt";
            this.delSeriaButt.Size = new System.Drawing.Size(148, 23);
            this.delSeriaButt.TabIndex = 28;
            this.delSeriaButt.Text = "Видалити серію";
            this.delSeriaButt.UseVisualStyleBackColor = true;
            this.delSeriaButt.Click += new System.EventHandler(this.delSeriaButt_Click);
            // 
            // descSeria
            // 
            this.descSeria.AutoSize = true;
            this.descSeria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descSeria.Location = new System.Drawing.Point(133, 53);
            this.descSeria.Name = "descSeria";
            this.descSeria.Size = new System.Drawing.Size(71, 16);
            this.descSeria.TabIndex = 27;
            this.descSeria.Text = "опис серії";
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewResult.Location = new System.Drawing.Point(3, 175);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.ReadOnly = true;
            this.dataGridViewResult.Size = new System.Drawing.Size(473, 181);
            this.dataGridViewResult.TabIndex = 25;
            // 
            // seriaNumber
            // 
            this.seriaNumber.AutoSize = true;
            this.seriaNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seriaNumber.Location = new System.Drawing.Point(3, 31);
            this.seriaNumber.Name = "seriaNumber";
            this.seriaNumber.Size = new System.Drawing.Size(323, 16);
            this.seriaNumber.TabIndex = 21;
            this.seriaNumber.Text = "Виберіть номер серії для перегляду результатів";
            // 
            // seriesBox
            // 
            this.seriesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seriesBox.FormattingEnabled = true;
            this.seriesBox.Location = new System.Drawing.Point(6, 50);
            this.seriesBox.Name = "seriesBox";
            this.seriesBox.Size = new System.Drawing.Size(121, 24);
            this.seriesBox.TabIndex = 20;
            this.seriesBox.SelectedIndexChanged += new System.EventHandler(this.seriesBox_SelectedIndexChanged);
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 368);
            this.Controls.Add(this.resultGroupBox);
            this.Name = "Result";
            this.Text = "Result";
            this.Load += new System.EventHandler(this.Result_Load);
            this.resultGroupBox.ResumeLayout(false);
            this.resultGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox resultGroupBox;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.Label seriaNumber;
        private System.Windows.Forms.ComboBox seriesBox;
        private System.Windows.Forms.Button delSeriaButt;
        private System.Windows.Forms.Label descSeria;
        private System.Windows.Forms.Button delPokaz;
        private System.Windows.Forms.Label issueDesc;
        private System.Windows.Forms.Label issueName;
    }
}
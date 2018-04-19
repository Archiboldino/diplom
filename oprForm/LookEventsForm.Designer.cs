namespace oprForm
{
	partial class LookEventsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.eventListGrid = new System.Windows.Forms.DataGridView();
            this.Resource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.eventsLB = new System.Windows.Forms.ListBox();
            this.eventDescLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.approveBtn = new System.Windows.Forms.Button();
            this.disaproveBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dmApprLbl = new System.Windows.Forms.Label();
            this.lawyerApprLbl = new System.Windows.Forms.Label();
            this.approveGB = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.totalPriceLbl = new System.Windows.Forms.Label();
            this.issueLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.onlyDisCB = new System.Windows.Forms.CheckBox();
            this.docsLB = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.expertsLB = new System.Windows.Forms.ListBox();
            this.issuesLB = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.issueCostLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eventListGrid)).BeginInit();
            this.approveGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(766, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ресурси";
            // 
            // eventListGrid
            // 
            this.eventListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Resource,
            this.Description,
            this.Value,
            this.unitsCol,
            this.priceCol,
            this.totalPriceCol});
            this.eventListGrid.Location = new System.Drawing.Point(533, 58);
            this.eventListGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventListGrid.Name = "eventListGrid";
            this.eventListGrid.Size = new System.Drawing.Size(709, 406);
            this.eventListGrid.TabIndex = 10;
            // 
            // Resource
            // 
            this.Resource.HeaderText = "Назва";
            this.Resource.Name = "Resource";
            this.Resource.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Опис";
            this.Description.Name = "Description";
            // 
            // Value
            // 
            this.Value.HeaderText = "Кількість";
            this.Value.Name = "Value";
            // 
            // unitsCol
            // 
            this.unitsCol.HeaderText = "Одиниці Виміру";
            this.unitsCol.Name = "unitsCol";
            // 
            // priceCol
            // 
            this.priceCol.HeaderText = "Ціна";
            this.priceCol.Name = "priceCol";
            // 
            // totalPriceCol
            // 
            this.totalPriceCol.HeaderText = "Повна Ціна";
            this.totalPriceCol.Name = "totalPriceCol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Список заходiв";
            // 
            // eventsLB
            // 
            this.eventsLB.FormattingEnabled = true;
            this.eventsLB.ItemHeight = 20;
            this.eventsLB.Location = new System.Drawing.Point(361, 60);
            this.eventsLB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventsLB.Name = "eventsLB";
            this.eventsLB.Size = new System.Drawing.Size(164, 404);
            this.eventsLB.TabIndex = 8;
            this.eventsLB.SelectedIndexChanged += new System.EventHandler(this.eventsLB_SelectedIndexChanged);
            // 
            // eventDescLabel
            // 
            this.eventDescLabel.AutoSize = true;
            this.eventDescLabel.Location = new System.Drawing.Point(225, 28);
            this.eventDescLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.eventDescLabel.Name = "eventDescLabel";
            this.eventDescLabel.Size = new System.Drawing.Size(0, 20);
            this.eventDescLabel.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Опис";
            // 
            // approveBtn
            // 
            this.approveBtn.Location = new System.Drawing.Point(718, 19);
            this.approveBtn.Name = "approveBtn";
            this.approveBtn.Size = new System.Drawing.Size(122, 38);
            this.approveBtn.TabIndex = 14;
            this.approveBtn.Text = "Підтвердити";
            this.approveBtn.UseVisualStyleBackColor = true;
            this.approveBtn.Click += new System.EventHandler(this.approveBtn_Click);
            // 
            // disaproveBtn
            // 
            this.disaproveBtn.Location = new System.Drawing.Point(726, 66);
            this.disaproveBtn.Name = "disaproveBtn";
            this.disaproveBtn.Size = new System.Drawing.Size(114, 38);
            this.disaproveBtn.TabIndex = 15;
            this.disaproveBtn.Text = "Відхилити";
            this.disaproveBtn.UseVisualStyleBackColor = true;
            this.disaproveBtn.Click += new System.EventHandler(this.disaproveBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Пiдтверждення аналiтика";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 120);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Пiдтверждення юриста";
            // 
            // dmApprLbl
            // 
            this.dmApprLbl.AutoSize = true;
            this.dmApprLbl.Location = new System.Drawing.Point(225, 89);
            this.dmApprLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dmApprLbl.Name = "dmApprLbl";
            this.dmApprLbl.Size = new System.Drawing.Size(0, 20);
            this.dmApprLbl.TabIndex = 18;
            // 
            // lawyerApprLbl
            // 
            this.lawyerApprLbl.AutoSize = true;
            this.lawyerApprLbl.Location = new System.Drawing.Point(225, 120);
            this.lawyerApprLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lawyerApprLbl.Name = "lawyerApprLbl";
            this.lawyerApprLbl.Size = new System.Drawing.Size(0, 20);
            this.lawyerApprLbl.TabIndex = 19;
            // 
            // approveGB
            // 
            this.approveGB.Controls.Add(this.label9);
            this.approveGB.Controls.Add(this.totalPriceLbl);
            this.approveGB.Controls.Add(this.issueLbl);
            this.approveGB.Controls.Add(this.label6);
            this.approveGB.Controls.Add(this.approveBtn);
            this.approveGB.Controls.Add(this.lawyerApprLbl);
            this.approveGB.Controls.Add(this.eventDescLabel);
            this.approveGB.Controls.Add(this.dmApprLbl);
            this.approveGB.Controls.Add(this.label3);
            this.approveGB.Controls.Add(this.label5);
            this.approveGB.Controls.Add(this.disaproveBtn);
            this.approveGB.Controls.Add(this.label4);
            this.approveGB.Location = new System.Drawing.Point(20, 472);
            this.approveGB.Name = "approveGB";
            this.approveGB.Size = new System.Drawing.Size(1125, 178);
            this.approveGB.TabIndex = 20;
            this.approveGB.TabStop = false;
            this.approveGB.Visible = false;
            this.approveGB.Enter += new System.EventHandler(this.approveGB_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 142);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Необхідно грошей";
            // 
            // totalPriceLbl
            // 
            this.totalPriceLbl.AutoSize = true;
            this.totalPriceLbl.Location = new System.Drawing.Point(225, 140);
            this.totalPriceLbl.Name = "totalPriceLbl";
            this.totalPriceLbl.Size = new System.Drawing.Size(0, 20);
            this.totalPriceLbl.TabIndex = 22;
            // 
            // issueLbl
            // 
            this.issueLbl.AutoSize = true;
            this.issueLbl.Location = new System.Drawing.Point(225, 63);
            this.issueLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.issueLbl.Name = "issueLbl";
            this.issueLbl.Size = new System.Drawing.Size(0, 20);
            this.issueLbl.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Проблема";
            // 
            // onlyDisCB
            // 
            this.onlyDisCB.AutoSize = true;
            this.onlyDisCB.Location = new System.Drawing.Point(537, 29);
            this.onlyDisCB.Name = "onlyDisCB";
            this.onlyDisCB.Size = new System.Drawing.Size(205, 24);
            this.onlyDisCB.TabIndex = 22;
            this.onlyDisCB.Text = "Тільки не затверждені";
            this.onlyDisCB.UseVisualStyleBackColor = true;
            this.onlyDisCB.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // docsLB
            // 
            this.docsLB.FormattingEnabled = true;
            this.docsLB.ItemHeight = 20;
            this.docsLB.Location = new System.Drawing.Point(1250, 29);
            this.docsLB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.docsLB.Name = "docsLB";
            this.docsLB.Size = new System.Drawing.Size(164, 564);
            this.docsLB.TabIndex = 23;
            this.docsLB.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.docsLB_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1246, -3);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Документи";
            // 
            // expertsLB
            // 
            this.expertsLB.FormattingEnabled = true;
            this.expertsLB.ItemHeight = 20;
            this.expertsLB.Location = new System.Drawing.Point(238, 60);
            this.expertsLB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.expertsLB.Name = "expertsLB";
            this.expertsLB.Size = new System.Drawing.Size(115, 404);
            this.expertsLB.TabIndex = 25;
            this.expertsLB.SelectedIndexChanged += new System.EventHandler(this.expertsLB_SelectedIndexChanged);
            // 
            // issuesLB
            // 
            this.issuesLB.FormattingEnabled = true;
            this.issuesLB.ItemHeight = 20;
            this.issuesLB.Location = new System.Drawing.Point(13, 60);
            this.issuesLB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.issuesLB.Name = "issuesLB";
            this.issuesLB.Size = new System.Drawing.Size(217, 364);
            this.issuesLB.TabIndex = 26;
            this.issuesLB.SelectedIndexChanged += new System.EventHandler(this.issuesLB_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(237, 35);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "Список експертів";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 35);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "Список проблем";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 446);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Вартість проблеми";
            // 
            // issueCostLbl
            // 
            this.issueCostLbl.AutoSize = true;
            this.issueCostLbl.Location = new System.Drawing.Point(174, 446);
            this.issueCostLbl.Name = "issueCostLbl";
            this.issueCostLbl.Size = new System.Drawing.Size(0, 20);
            this.issueCostLbl.TabIndex = 30;
            // 
            // LookEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 669);
            this.Controls.Add(this.issueCostLbl);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.issuesLB);
            this.Controls.Add(this.expertsLB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.docsLB);
            this.Controls.Add(this.onlyDisCB);
            this.Controls.Add(this.approveGB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eventListGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eventsLB);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LookEventsForm";
            this.Text = "Перегляд заходiв";
            this.Load += new System.EventHandler(this.LookEventsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventListGrid)).EndInit();
            this.approveGB.ResumeLayout(false);
            this.approveGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView eventListGrid;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox eventsLB;
		private System.Windows.Forms.Label eventDescLabel;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button approveBtn;
        private System.Windows.Forms.Button disaproveBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label dmApprLbl;
        private System.Windows.Forms.Label lawyerApprLbl;
        private System.Windows.Forms.GroupBox approveGB;
        private System.Windows.Forms.CheckBox onlyDisCB;
        private System.Windows.Forms.Label issueLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox docsLB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitsCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceCol;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label totalPriceLbl;
        private System.Windows.Forms.ListBox expertsLB;
        private System.Windows.Forms.ListBox issuesLB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label issueCostLbl;
    }
}
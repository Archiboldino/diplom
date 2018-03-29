namespace MedicForm
{
    partial class Main
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
            this.funcComboBox = new System.Windows.Forms.ComboBox();
            this.funcLabel = new System.Windows.Forms.Label();
            this.dataGridViewParam = new System.Windows.Forms.DataGridView();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.calcButton = new System.Windows.Forms.Button();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.calcBox = new System.Windows.Forms.GroupBox();
            this.editButt = new System.Windows.Forms.Button();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.resultButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.calcPanel = new System.Windows.Forms.Panel();
            this.calcBoxButton = new System.Windows.Forms.Button();
            this.calcLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.editLabel = new System.Windows.Forms.Label();
            this.aboutText = new System.Windows.Forms.Label();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.chartButt = new System.Windows.Forms.Button();
            this.chartLabel = new System.Windows.Forms.Label();
            this.chartsList = new System.Windows.Forms.ComboBox();
            this.chartsLabel = new System.Windows.Forms.Label();
            this.chartBox = new System.Windows.Forms.GroupBox();
            this.newChartButt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParam)).BeginInit();
            this.calcBox.SuspendLayout();
            this.resultPanel.SuspendLayout();
            this.calcPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.chartPanel.SuspendLayout();
            this.chartBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // funcComboBox
            // 
            this.funcComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.funcComboBox.FormattingEnabled = true;
            this.funcComboBox.Location = new System.Drawing.Point(107, 21);
            this.funcComboBox.Name = "funcComboBox";
            this.funcComboBox.Size = new System.Drawing.Size(305, 24);
            this.funcComboBox.TabIndex = 0;
            // 
            // funcLabel
            // 
            this.funcLabel.AutoSize = true;
            this.funcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.funcLabel.Location = new System.Drawing.Point(21, 24);
            this.funcLabel.Name = "funcLabel";
            this.funcLabel.Size = new System.Drawing.Size(80, 16);
            this.funcLabel.TabIndex = 13;
            this.funcLabel.Text = "Показники";
            // 
            // dataGridViewParam
            // 
            this.dataGridViewParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParam.Location = new System.Drawing.Point(24, 128);
            this.dataGridViewParam.Name = "dataGridViewParam";
            this.dataGridViewParam.Size = new System.Drawing.Size(398, 150);
            this.dataGridViewParam.TabIndex = 18;
            this.dataGridViewParam.Visible = false;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(33, 75);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(0, 16);
            this.descriptionLabel.TabIndex = 27;
            // 
            // calcButton
            // 
            this.calcButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calcButton.Location = new System.Drawing.Point(136, 51);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(195, 40);
            this.calcButton.TabIndex = 28;
            this.calcButton.Text = "Порахувати обраний показник";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            // 
            // calcBox
            // 
            this.calcBox.Controls.Add(this.funcLabel);
            this.calcBox.Controls.Add(this.funcComboBox);
            this.calcBox.Controls.Add(this.descriptionLabel);
            this.calcBox.Controls.Add(this.dataGridViewParam);
            this.calcBox.Controls.Add(this.calcButton);
            this.calcBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calcBox.Location = new System.Drawing.Point(473, 327);
            this.calcBox.Name = "calcBox";
            this.calcBox.Size = new System.Drawing.Size(420, 123);
            this.calcBox.TabIndex = 33;
            this.calcBox.TabStop = false;
            this.calcBox.Visible = false;
            // 
            // editButt
            // 
            this.editButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editButt.Location = new System.Drawing.Point(125, 49);
            this.editButt.Name = "editButt";
            this.editButt.Size = new System.Drawing.Size(53, 26);
            this.editButt.TabIndex = 29;
            this.editButt.Text = "→";
            this.editButt.UseVisualStyleBackColor = true;
            this.editButt.Click += new System.EventHandler(this.editButt_Click);
            // 
            // resultPanel
            // 
            this.resultPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultPanel.Controls.Add(this.resultButton);
            this.resultPanel.Controls.Add(this.resultLabel);
            this.resultPanel.Location = new System.Drawing.Point(114, 94);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(287, 100);
            this.resultPanel.TabIndex = 34;
            // 
            // resultButton
            // 
            this.resultButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultButton.Location = new System.Drawing.Point(124, 49);
            this.resultButton.Name = "resultButton";
            this.resultButton.Size = new System.Drawing.Size(53, 26);
            this.resultButton.TabIndex = 1;
            this.resultButton.Text = "→";
            this.resultButton.UseVisualStyleBackColor = false;
            this.resultButton.Click += new System.EventHandler(this.resultButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultLabel.Location = new System.Drawing.Point(3, 12);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(278, 18);
            this.resultLabel.TabIndex = 0;
            this.resultLabel.Text = "Перегляд результатів розрахунків";
            // 
            // calcPanel
            // 
            this.calcPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calcPanel.Controls.Add(this.calcBoxButton);
            this.calcPanel.Controls.Add(this.calcLabel);
            this.calcPanel.Location = new System.Drawing.Point(473, 221);
            this.calcPanel.Name = "calcPanel";
            this.calcPanel.Size = new System.Drawing.Size(287, 100);
            this.calcPanel.TabIndex = 35;
            // 
            // calcBoxButton
            // 
            this.calcBoxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calcBoxButton.Location = new System.Drawing.Point(125, 53);
            this.calcBoxButton.Name = "calcBoxButton";
            this.calcBoxButton.Size = new System.Drawing.Size(53, 26);
            this.calcBoxButton.TabIndex = 1;
            this.calcBoxButton.Text = "→";
            this.calcBoxButton.UseVisualStyleBackColor = true;
            this.calcBoxButton.Click += new System.EventHandler(this.calcBoxButton_Click);
            // 
            // calcLabel
            // 
            this.calcLabel.AutoSize = true;
            this.calcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calcLabel.Location = new System.Drawing.Point(3, 12);
            this.calcLabel.Name = "calcLabel";
            this.calcLabel.Size = new System.Drawing.Size(271, 18);
            this.calcLabel.TabIndex = 0;
            this.calcLabel.Text = "Розрахунок медичних показників";
            this.calcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.editLabel);
            this.panel3.Controls.Add(this.editButt);
            this.panel3.Location = new System.Drawing.Point(473, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(287, 100);
            this.panel3.TabIndex = 36;
            // 
            // editLabel
            // 
            this.editLabel.AutoSize = true;
            this.editLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editLabel.Location = new System.Drawing.Point(77, 15);
            this.editLabel.Name = "editLabel";
            this.editLabel.Size = new System.Drawing.Size(151, 18);
            this.editLabel.TabIndex = 30;
            this.editLabel.Text = "Редактор формул";
            // 
            // aboutText
            // 
            this.aboutText.AutoSize = true;
            this.aboutText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutText.Location = new System.Drawing.Point(111, 24);
            this.aboutText.Name = "aboutText";
            this.aboutText.Size = new System.Drawing.Size(192, 18);
            this.aboutText.TabIndex = 37;
            this.aboutText.Text = "Програма Експерт Медик ";
            // 
            // chartPanel
            // 
            this.chartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartPanel.Controls.Add(this.chartButt);
            this.chartPanel.Controls.Add(this.chartLabel);
            this.chartPanel.Location = new System.Drawing.Point(114, 221);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(287, 100);
            this.chartPanel.TabIndex = 38;
            // 
            // chartButt
            // 
            this.chartButt.Location = new System.Drawing.Point(124, 53);
            this.chartButt.Name = "chartButt";
            this.chartButt.Size = new System.Drawing.Size(53, 26);
            this.chartButt.TabIndex = 1;
            this.chartButt.Text = "→";
            this.chartButt.UseVisualStyleBackColor = true;
            this.chartButt.Click += new System.EventHandler(this.chartButt_Click);
            // 
            // chartLabel
            // 
            this.chartLabel.AutoSize = true;
            this.chartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartLabel.Location = new System.Drawing.Point(113, 12);
            this.chartLabel.Name = "chartLabel";
            this.chartLabel.Size = new System.Drawing.Size(82, 18);
            this.chartLabel.TabIndex = 0;
            this.chartLabel.Text = "Графіки  ";
            this.chartLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chartsList
            // 
            this.chartsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartsList.FormattingEnabled = true;
            this.chartsList.Location = new System.Drawing.Point(75, 11);
            this.chartsList.Name = "chartsList";
            this.chartsList.Size = new System.Drawing.Size(212, 24);
            this.chartsList.TabIndex = 39;
            // 
            // chartsLabel
            // 
            this.chartsLabel.AutoSize = true;
            this.chartsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartsLabel.Location = new System.Drawing.Point(9, 16);
            this.chartsLabel.Name = "chartsLabel";
            this.chartsLabel.Size = new System.Drawing.Size(60, 16);
            this.chartsLabel.TabIndex = 40;
            this.chartsLabel.Text = "Графіки";
            // 
            // chartBox
            // 
            this.chartBox.Controls.Add(this.newChartButt);
            this.chartBox.Controls.Add(this.chartsLabel);
            this.chartBox.Controls.Add(this.chartsList);
            this.chartBox.Location = new System.Drawing.Point(114, 327);
            this.chartBox.Name = "chartBox";
            this.chartBox.Size = new System.Drawing.Size(297, 100);
            this.chartBox.TabIndex = 41;
            this.chartBox.TabStop = false;
            this.chartBox.Visible = false;
            // 
            // newChartButt
            // 
            this.newChartButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newChartButt.Location = new System.Drawing.Point(87, 51);
            this.newChartButt.Name = "newChartButt";
            this.newChartButt.Size = new System.Drawing.Size(180, 23);
            this.newChartButt.TabIndex = 41;
            this.newChartButt.Text = "Відобразити графік";
            this.newChartButt.UseVisualStyleBackColor = true;
            this.newChartButt.Click += new System.EventHandler(this.newChartButt_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(907, 461);
            this.Controls.Add(this.chartBox);
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.aboutText);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.calcPanel);
            this.Controls.Add(this.resultPanel);
            this.Controls.Add(this.calcBox);
            this.Name = "Main";
            this.Text = "Головне меню";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParam)).EndInit();
            this.calcBox.ResumeLayout(false);
            this.calcBox.PerformLayout();
            this.resultPanel.ResumeLayout(false);
            this.resultPanel.PerformLayout();
            this.calcPanel.ResumeLayout(false);
            this.calcPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.chartPanel.ResumeLayout(false);
            this.chartPanel.PerformLayout();
            this.chartBox.ResumeLayout(false);
            this.chartBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox funcComboBox;
        private System.Windows.Forms.Label funcLabel;
        private System.Windows.Forms.DataGridView dataGridViewParam;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.GroupBox calcBox;
        private System.Windows.Forms.Button editButt;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button resultButton;
        private System.Windows.Forms.Panel calcPanel;
        private System.Windows.Forms.Button calcBoxButton;
        private System.Windows.Forms.Label calcLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label editLabel;
        private System.Windows.Forms.Label aboutText;
        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.Button chartButt;
        private System.Windows.Forms.Label chartLabel;
        private System.Windows.Forms.ComboBox chartsList;
        private System.Windows.Forms.Label chartsLabel;
        private System.Windows.Forms.GroupBox chartBox;
        private System.Windows.Forms.Button newChartButt;
    }
}


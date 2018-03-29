namespace MedicForm
{
    partial class Calculate
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
            this.button1 = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.seria = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.parameterGroupBox = new System.Windows.Forms.GroupBox();
            this.calcName = new System.Windows.Forms.TextBox();
            this.calcLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.descBox = new System.Windows.Forms.RichTextBox();
            this.addSeria = new System.Windows.Forms.Button();
            this.setSeria = new System.Windows.Forms.Button();
            this.issueLabel = new System.Windows.Forms.Label();
            this.issueList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.seria)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Порахувати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.result.Location = new System.Drawing.Point(496, 71);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(20, 22);
            this.result.TabIndex = 8;
            this.result.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(438, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 26);
            this.label6.TabIndex = 9;
            this.label6.Text = "Введіть номер серії для \r\nякої ви хочете порахувати\r\n";
            // 
            // seria
            // 
            this.seria.Location = new System.Drawing.Point(583, 15);
            this.seria.Name = "seria";
            this.seria.Size = new System.Drawing.Size(120, 20);
            this.seria.TabIndex = 10;
            this.seria.ValueChanged += new System.EventHandler(this.seria_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(441, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Результат";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(522, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Зберегти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // parameterGroupBox
            // 
            this.parameterGroupBox.Location = new System.Drawing.Point(0, -1);
            this.parameterGroupBox.Name = "parameterGroupBox";
            this.parameterGroupBox.Size = new System.Drawing.Size(435, 208);
            this.parameterGroupBox.TabIndex = 13;
            this.parameterGroupBox.TabStop = false;
            this.parameterGroupBox.Text = "groupBox1";
            // 
            // calcName
            // 
            this.calcName.Location = new System.Drawing.Point(539, 134);
            this.calcName.Name = "calcName";
            this.calcName.Size = new System.Drawing.Size(100, 20);
            this.calcName.TabIndex = 14;
            // 
            // calcLabel
            // 
            this.calcLabel.AutoSize = true;
            this.calcLabel.Location = new System.Drawing.Point(441, 137);
            this.calcLabel.Name = "calcLabel";
            this.calcLabel.Size = new System.Drawing.Size(92, 13);
            this.calcLabel.TabIndex = 15;
            this.calcLabel.Text = "Введіть ім\'я серії";
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(441, 165);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(189, 13);
            this.descLabel.TabIndex = 16;
            this.descLabel.Text = "Введіть опис серії (до 150 символів)";
            // 
            // descBox
            // 
            this.descBox.Location = new System.Drawing.Point(444, 181);
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(226, 89);
            this.descBox.TabIndex = 17;
            this.descBox.Text = "";
            // 
            // addSeria
            // 
            this.addSeria.Location = new System.Drawing.Point(444, 276);
            this.addSeria.Name = "addSeria";
            this.addSeria.Size = new System.Drawing.Size(89, 23);
            this.addSeria.TabIndex = 18;
            this.addSeria.Text = "Додати серію";
            this.addSeria.UseVisualStyleBackColor = true;
            this.addSeria.Click += new System.EventHandler(this.addSeria_Click);
            // 
            // setSeria
            // 
            this.setSeria.Location = new System.Drawing.Point(539, 276);
            this.setSeria.Name = "setSeria";
            this.setSeria.Size = new System.Drawing.Size(91, 23);
            this.setSeria.TabIndex = 19;
            this.setSeria.Text = "Змінити серію";
            this.setSeria.UseVisualStyleBackColor = true;
            this.setSeria.Click += new System.EventHandler(this.setSeria_Click);
            // 
            // issueLabel
            // 
            this.issueLabel.AutoSize = true;
            this.issueLabel.Location = new System.Drawing.Point(441, 110);
            this.issueLabel.Name = "issueLabel";
            this.issueLabel.Size = new System.Drawing.Size(103, 13);
            this.issueLabel.TabIndex = 20;
            this.issueLabel.Text = "Виберіть проблему";
            // 
            // issueList
            // 
            this.issueList.FormattingEnabled = true;
            this.issueList.Location = new System.Drawing.Point(549, 107);
            this.issueList.Name = "issueList";
            this.issueList.Size = new System.Drawing.Size(121, 21);
            this.issueList.TabIndex = 21;
            // 
            // Calculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(715, 311);
            this.Controls.Add(this.issueList);
            this.Controls.Add(this.issueLabel);
            this.Controls.Add(this.setSeria);
            this.Controls.Add(this.addSeria);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.calcLabel);
            this.Controls.Add(this.calcName);
            this.Controls.Add(this.seria);
            this.Controls.Add(this.parameterGroupBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.result);
            this.Controls.Add(this.button1);
            this.Name = "Calculate";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Розрахунок";
            this.Load += new System.EventHandler(this.Calculate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown seria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox parameterGroupBox;
        private System.Windows.Forms.TextBox calcName;
        private System.Windows.Forms.Label calcLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.RichTextBox descBox;
        private System.Windows.Forms.Button addSeria;
        private System.Windows.Forms.Button setSeria;
        private System.Windows.Forms.Label issueLabel;
        private System.Windows.Forms.ComboBox issueList;
    }
}
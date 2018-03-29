namespace MedicForm
{
    partial class Seria
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
            this.issueList = new System.Windows.Forms.ComboBox();
            this.issueLabel = new System.Windows.Forms.Label();
            this.setSeria = new System.Windows.Forms.Button();
            this.addSeria = new System.Windows.Forms.Button();
            this.descBox = new System.Windows.Forms.RichTextBox();
            this.descLabel = new System.Windows.Forms.Label();
            this.calcLabel = new System.Windows.Forms.Label();
            this.calcName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // issueList
            // 
            this.issueList.FormattingEnabled = true;
            this.issueList.Location = new System.Drawing.Point(212, 18);
            this.issueList.Name = "issueList";
            this.issueList.Size = new System.Drawing.Size(121, 21);
            this.issueList.TabIndex = 29;
            // 
            // issueLabel
            // 
            this.issueLabel.AutoSize = true;
            this.issueLabel.Location = new System.Drawing.Point(104, 21);
            this.issueLabel.Name = "issueLabel";
            this.issueLabel.Size = new System.Drawing.Size(103, 13);
            this.issueLabel.TabIndex = 28;
            this.issueLabel.Text = "Виберіть проблему";
            // 
            // setSeria
            // 
            this.setSeria.Location = new System.Drawing.Point(202, 187);
            this.setSeria.Name = "setSeria";
            this.setSeria.Size = new System.Drawing.Size(91, 23);
            this.setSeria.TabIndex = 27;
            this.setSeria.Text = "Змінити серію";
            this.setSeria.UseVisualStyleBackColor = true;
            // 
            // addSeria
            // 
            this.addSeria.Location = new System.Drawing.Point(107, 187);
            this.addSeria.Name = "addSeria";
            this.addSeria.Size = new System.Drawing.Size(89, 23);
            this.addSeria.TabIndex = 26;
            this.addSeria.Text = "Додати серію";
            this.addSeria.UseVisualStyleBackColor = true;
            // 
            // descBox
            // 
            this.descBox.Location = new System.Drawing.Point(107, 92);
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(226, 89);
            this.descBox.TabIndex = 25;
            this.descBox.Text = "";
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(104, 76);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(189, 13);
            this.descLabel.TabIndex = 24;
            this.descLabel.Text = "Введіть опис серії (до 150 символів)";
            // 
            // calcLabel
            // 
            this.calcLabel.AutoSize = true;
            this.calcLabel.Location = new System.Drawing.Point(104, 48);
            this.calcLabel.Name = "calcLabel";
            this.calcLabel.Size = new System.Drawing.Size(92, 13);
            this.calcLabel.TabIndex = 23;
            this.calcLabel.Text = "Введіть ім\'я серії";
            // 
            // calcName
            // 
            this.calcName.Location = new System.Drawing.Point(202, 45);
            this.calcName.Name = "calcName";
            this.calcName.Size = new System.Drawing.Size(100, 20);
            this.calcName.TabIndex = 22;
            // 
            // Seria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 256);
            this.Controls.Add(this.issueList);
            this.Controls.Add(this.issueLabel);
            this.Controls.Add(this.setSeria);
            this.Controls.Add(this.addSeria);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.calcLabel);
            this.Controls.Add(this.calcName);
            this.Name = "Seria";
            this.Text = "Серія";
            this.Load += new System.EventHandler(this.Seria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox issueList;
        private System.Windows.Forms.Label issueLabel;
        private System.Windows.Forms.Button setSeria;
        private System.Windows.Forms.Button addSeria;
        private System.Windows.Forms.RichTextBox descBox;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label calcLabel;
        private System.Windows.Forms.TextBox calcName;
    }
}
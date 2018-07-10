namespace oprForm
{
    partial class SetDateForm
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
            this.respTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startDP = new System.Windows.Forms.DateTimePicker();
            this.endDP = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // respTB
            // 
            this.respTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.respTB.Location = new System.Drawing.Point(191, 129);
            this.respTB.Name = "respTB";
            this.respTB.Size = new System.Drawing.Size(200, 26);
            this.respTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Відповідальний";
            // 
            // startDP
            // 
            this.startDP.Location = new System.Drawing.Point(191, 24);
            this.startDP.Name = "startDP";
            this.startDP.Size = new System.Drawing.Size(200, 26);
            this.startDP.TabIndex = 2;
            // 
            // endDP
            // 
            this.endDP.Location = new System.Drawing.Point(191, 80);
            this.endDP.Name = "endDP";
            this.endDP.Size = new System.Drawing.Size(200, 26);
            this.endDP.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Кінець";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Початок";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Підтвердити";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 32);
            this.button2.TabIndex = 7;
            this.button2.Text = "Відміна";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SetDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 246);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endDP);
            this.Controls.Add(this.startDP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.respTB);
            this.Name = "SetDateForm";
            this.Text = "Підтвердження заходу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox respTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker startDP;
        private System.Windows.Forms.DateTimePicker endDP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
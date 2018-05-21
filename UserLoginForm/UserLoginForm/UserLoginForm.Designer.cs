namespace UserLoginForm
{
	partial class UserLoginForm
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
            this.loginTB = new System.Windows.Forms.TextBox();
            this.passTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginTB
            // 
            this.loginTB.Location = new System.Drawing.Point(104, 66);
            this.loginTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loginTB.Name = "loginTB";
            this.loginTB.Size = new System.Drawing.Size(148, 26);
            this.loginTB.TabIndex = 0;
            // 
            // passTB
            // 
            this.passTB.Location = new System.Drawing.Point(104, 106);
            this.passTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passTB.Name = "passTB";
            this.passTB.PasswordChar = '*';
            this.passTB.Size = new System.Drawing.Size(148, 26);
            this.passTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Iм\'я";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(70, 146);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(112, 35);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "Увiйти";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // UserLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 209);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passTB);
            this.Controls.Add(this.loginTB);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserLoginForm";
            this.Text = "Форма входу";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox loginTB;
		private System.Windows.Forms.TextBox passTB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button loginBtn;
	}
}


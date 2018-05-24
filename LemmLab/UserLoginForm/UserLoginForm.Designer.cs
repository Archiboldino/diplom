namespace UserLoginForm
{
	partial class UserLogin
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
			this.loginTB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.loginTB.Location = new System.Drawing.Point(105, 47);
			this.loginTB.Name = "loginTB";
			this.loginTB.Size = new System.Drawing.Size(100, 20);
			this.loginTB.TabIndex = 0;
			// 
			// passTB
			// 
			this.passTB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.passTB.Location = new System.Drawing.Point(105, 73);
			this.passTB.Name = "passTB";
			this.passTB.PasswordChar = '*';
			this.passTB.Size = new System.Drawing.Size(100, 20);
			this.passTB.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(48, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Ім\'я";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(48, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Пароль";
			// 
			// loginBtn
			// 
			this.loginBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.loginBtn.Location = new System.Drawing.Point(75, 99);
			this.loginBtn.Name = "loginBtn";
			this.loginBtn.Size = new System.Drawing.Size(82, 23);
			this.loginBtn.TabIndex = 4;
			this.loginBtn.Text = "Авторизація";
			this.loginBtn.UseVisualStyleBackColor = true;
			this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
			// 
			// UserLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(261, 151);
			this.Controls.Add(this.loginBtn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.passTB);
			this.Controls.Add(this.loginTB);
			this.Name = "UserLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Авторизація";
			this.Load += new System.EventHandler(this.UserLogin_Load);
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


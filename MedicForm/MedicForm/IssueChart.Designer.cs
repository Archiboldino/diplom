namespace MedicForm
{
    partial class IssueChart
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
            this.chartIssueGroup = new System.Windows.Forms.GroupBox();
            this.diagIssueButt = new System.Windows.Forms.Button();
            this.chartIssueButt = new System.Windows.Forms.Button();
            this.removeIssueSeria = new System.Windows.Forms.Button();
            this.addIssueSeria = new System.Windows.Forms.Button();
            this.addedIssueSerias = new System.Windows.Forms.ListBox();
            this.issueSerias = new System.Windows.Forms.ListBox();
            this.issueSeriasLabel = new System.Windows.Forms.Label();
            this.problemBox = new System.Windows.Forms.ComboBox();
            this.problemLabel = new System.Windows.Forms.Label();
            this.seriaInfo = new System.Windows.Forms.GroupBox();
            this.seriaDescription = new System.Windows.Forms.Label();
            this.seriaName = new System.Windows.Forms.Label();
            this.chartIssueGroup.SuspendLayout();
            this.seriaInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartIssueGroup
            // 
            this.chartIssueGroup.Controls.Add(this.diagIssueButt);
            this.chartIssueGroup.Controls.Add(this.chartIssueButt);
            this.chartIssueGroup.Controls.Add(this.removeIssueSeria);
            this.chartIssueGroup.Controls.Add(this.addIssueSeria);
            this.chartIssueGroup.Controls.Add(this.addedIssueSerias);
            this.chartIssueGroup.Controls.Add(this.issueSerias);
            this.chartIssueGroup.Controls.Add(this.issueSeriasLabel);
            this.chartIssueGroup.Controls.Add(this.problemBox);
            this.chartIssueGroup.Controls.Add(this.problemLabel);
            this.chartIssueGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartIssueGroup.Location = new System.Drawing.Point(80, 12);
            this.chartIssueGroup.Name = "chartIssueGroup";
            this.chartIssueGroup.Size = new System.Drawing.Size(326, 337);
            this.chartIssueGroup.TabIndex = 38;
            this.chartIssueGroup.TabStop = false;
            this.chartIssueGroup.Text = "Графік проблеми";
            // 
            // diagIssueButt
            // 
            this.diagIssueButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diagIssueButt.Location = new System.Drawing.Point(32, 235);
            this.diagIssueButt.Name = "diagIssueButt";
            this.diagIssueButt.Size = new System.Drawing.Size(130, 23);
            this.diagIssueButt.TabIndex = 47;
            this.diagIssueButt.Text = "Діаграма";
            this.diagIssueButt.UseVisualStyleBackColor = true;
            this.diagIssueButt.Click += new System.EventHandler(this.diagIssueButt_Click);
            // 
            // chartIssueButt
            // 
            this.chartIssueButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartIssueButt.Location = new System.Drawing.Point(168, 235);
            this.chartIssueButt.Name = "chartIssueButt";
            this.chartIssueButt.Size = new System.Drawing.Size(130, 23);
            this.chartIssueButt.TabIndex = 46;
            this.chartIssueButt.Text = "Графік";
            this.chartIssueButt.UseVisualStyleBackColor = true;
            this.chartIssueButt.Click += new System.EventHandler(this.chartIssueButt_Click);
            // 
            // removeIssueSeria
            // 
            this.removeIssueSeria.Location = new System.Drawing.Point(143, 157);
            this.removeIssueSeria.Name = "removeIssueSeria";
            this.removeIssueSeria.Size = new System.Drawing.Size(37, 23);
            this.removeIssueSeria.TabIndex = 45;
            this.removeIssueSeria.Text = "←";
            this.removeIssueSeria.UseVisualStyleBackColor = true;
            this.removeIssueSeria.Click += new System.EventHandler(this.removeIssueSeria_Click);
            // 
            // addIssueSeria
            // 
            this.addIssueSeria.Location = new System.Drawing.Point(143, 119);
            this.addIssueSeria.Name = "addIssueSeria";
            this.addIssueSeria.Size = new System.Drawing.Size(37, 23);
            this.addIssueSeria.TabIndex = 44;
            this.addIssueSeria.Text = "→";
            this.addIssueSeria.UseVisualStyleBackColor = true;
            this.addIssueSeria.Click += new System.EventHandler(this.addIssueSeria_Click);
            // 
            // addedIssueSerias
            // 
            this.addedIssueSerias.FormattingEnabled = true;
            this.addedIssueSerias.ItemHeight = 16;
            this.addedIssueSerias.Location = new System.Drawing.Point(195, 108);
            this.addedIssueSerias.Name = "addedIssueSerias";
            this.addedIssueSerias.Size = new System.Drawing.Size(120, 100);
            this.addedIssueSerias.TabIndex = 43;
            // 
            // issueSerias
            // 
            this.issueSerias.FormattingEnabled = true;
            this.issueSerias.ItemHeight = 16;
            this.issueSerias.Location = new System.Drawing.Point(8, 108);
            this.issueSerias.Name = "issueSerias";
            this.issueSerias.Size = new System.Drawing.Size(120, 100);
            this.issueSerias.TabIndex = 42;
            this.issueSerias.SelectedIndexChanged += new System.EventHandler(this.issueSerias_SelectedIndexChanged);
            // 
            // issueSeriasLabel
            // 
            this.issueSeriasLabel.AutoSize = true;
            this.issueSeriasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.issueSeriasLabel.Location = new System.Drawing.Point(6, 89);
            this.issueSeriasLabel.Name = "issueSeriasLabel";
            this.issueSeriasLabel.Size = new System.Drawing.Size(245, 16);
            this.issueSeriasLabel.TabIndex = 41;
            this.issueSeriasLabel.Text = "Виберіть серії які треба відобразити";
            // 
            // problemBox
            // 
            this.problemBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.problemBox.FormattingEnabled = true;
            this.problemBox.Location = new System.Drawing.Point(6, 50);
            this.problemBox.Name = "problemBox";
            this.problemBox.Size = new System.Drawing.Size(229, 24);
            this.problemBox.TabIndex = 1;
            this.problemBox.SelectedIndexChanged += new System.EventHandler(this.problemBox_SelectedIndexChanged);
            // 
            // problemLabel
            // 
            this.problemLabel.AutoSize = true;
            this.problemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.problemLabel.Location = new System.Drawing.Point(6, 31);
            this.problemLabel.Name = "problemLabel";
            this.problemLabel.Size = new System.Drawing.Size(134, 16);
            this.problemLabel.TabIndex = 0;
            this.problemLabel.Text = "Виберіть проблему";
            // 
            // seriaInfo
            // 
            this.seriaInfo.Controls.Add(this.seriaDescription);
            this.seriaInfo.Controls.Add(this.seriaName);
            this.seriaInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seriaInfo.Location = new System.Drawing.Point(412, 12);
            this.seriaInfo.Name = "seriaInfo";
            this.seriaInfo.Size = new System.Drawing.Size(200, 100);
            this.seriaInfo.TabIndex = 39;
            this.seriaInfo.TabStop = false;
            this.seriaInfo.Text = "Інформація про серію";
            // 
            // seriaDescription
            // 
            this.seriaDescription.AutoSize = true;
            this.seriaDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seriaDescription.Location = new System.Drawing.Point(6, 45);
            this.seriaDescription.Name = "seriaDescription";
            this.seriaDescription.Size = new System.Drawing.Size(0, 16);
            this.seriaDescription.TabIndex = 1;
            // 
            // seriaName
            // 
            this.seriaName.AutoSize = true;
            this.seriaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seriaName.Location = new System.Drawing.Point(6, 18);
            this.seriaName.Name = "seriaName";
            this.seriaName.Size = new System.Drawing.Size(0, 16);
            this.seriaName.TabIndex = 0;
            // 
            // IssueChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 374);
            this.Controls.Add(this.seriaInfo);
            this.Controls.Add(this.chartIssueGroup);
            this.Name = "IssueChart";
            this.Text = "IssueChart";
            this.chartIssueGroup.ResumeLayout(false);
            this.chartIssueGroup.PerformLayout();
            this.seriaInfo.ResumeLayout(false);
            this.seriaInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox chartIssueGroup;
        private System.Windows.Forms.Button diagIssueButt;
        private System.Windows.Forms.Button chartIssueButt;
        private System.Windows.Forms.Button removeIssueSeria;
        private System.Windows.Forms.Button addIssueSeria;
        private System.Windows.Forms.ListBox addedIssueSerias;
        private System.Windows.Forms.ListBox issueSerias;
        private System.Windows.Forms.Label issueSeriasLabel;
        private System.Windows.Forms.ComboBox problemBox;
        private System.Windows.Forms.Label problemLabel;
        private System.Windows.Forms.GroupBox seriaInfo;
        private System.Windows.Forms.Label seriaDescription;
        private System.Windows.Forms.Label seriaName;
    }
}
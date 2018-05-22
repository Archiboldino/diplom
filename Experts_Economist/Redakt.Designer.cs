namespace Experts_Economist
{
    partial class Redakt
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
            this.components = new System.ComponentModel.Container();
            this.del1 = new System.Windows.Forms.Button();
            this.update1 = new System.Windows.Forms.Button();
            this.add1 = new System.Windows.Forms.Button();
            this.formula_nameTB = new System.Windows.Forms.TextBox();
            this.formula_explTB = new System.Windows.Forms.RichTextBox();
            this.formulasLB = new System.Windows.Forms.ListBox();
            this.formulas_idLB = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Bind = new System.Windows.Forms.Button();
            this.Unbind = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.del2 = new System.Windows.Forms.Button();
            this.update2 = new System.Windows.Forms.Button();
            this.add2 = new System.Windows.Forms.Button();
            this.component_nameTB = new System.Windows.Forms.TextBox();
            this.component_explTB = new System.Windows.Forms.RichTextBox();
            this.componentLB = new System.Windows.Forms.ListBox();
            this.componentidLB = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.component_measureTB = new System.Windows.Forms.TextBox();
            this.bind_compLB = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.formula_measureTB = new System.Windows.Forms.TextBox();
            this.search_formula = new System.Windows.Forms.TextBox();
            this.search_parametr = new System.Windows.Forms.TextBox();
            this.experts_CB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.оновитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // del1
            // 
            this.del1.Location = new System.Drawing.Point(132, 345);
            this.del1.Name = "del1";
            this.del1.Size = new System.Drawing.Size(76, 23);
            this.del1.TabIndex = 24;
            this.del1.Text = "Видалити";
            this.del1.UseVisualStyleBackColor = true;
            this.del1.Click += new System.EventHandler(this.del1_Click);
            // 
            // update1
            // 
            this.update1.Location = new System.Drawing.Point(132, 316);
            this.update1.Name = "update1";
            this.update1.Size = new System.Drawing.Size(76, 23);
            this.update1.TabIndex = 23;
            this.update1.Text = "Змінити";
            this.update1.UseVisualStyleBackColor = true;
            this.update1.Click += new System.EventHandler(this.update1_Click);
            // 
            // add1
            // 
            this.add1.Location = new System.Drawing.Point(132, 287);
            this.add1.Name = "add1";
            this.add1.Size = new System.Drawing.Size(76, 23);
            this.add1.TabIndex = 22;
            this.add1.Text = "Додати";
            this.add1.UseVisualStyleBackColor = true;
            this.add1.Click += new System.EventHandler(this.add1_Click);
            // 
            // formula_nameTB
            // 
            this.formula_nameTB.Location = new System.Drawing.Point(15, 303);
            this.formula_nameTB.Name = "formula_nameTB";
            this.formula_nameTB.Size = new System.Drawing.Size(100, 20);
            this.formula_nameTB.TabIndex = 21;
            // 
            // formula_explTB
            // 
            this.formula_explTB.Location = new System.Drawing.Point(15, 379);
            this.formula_explTB.Name = "formula_explTB";
            this.formula_explTB.Size = new System.Drawing.Size(184, 48);
            this.formula_explTB.TabIndex = 19;
            this.formula_explTB.Text = "";
            // 
            // formulasLB
            // 
            this.formulasLB.FormattingEnabled = true;
            this.formulasLB.Location = new System.Drawing.Point(12, 56);
            this.formulasLB.Name = "formulasLB";
            this.formulasLB.Size = new System.Drawing.Size(196, 225);
            this.formulasLB.TabIndex = 18;
            this.formulasLB.SelectedIndexChanged += new System.EventHandler(this.formulasLB_SelectedIndexChanged);
            this.formulasLB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formulasLB_MouseMove);
            // 
            // formulas_idLB
            // 
            this.formulas_idLB.FormattingEnabled = true;
            this.formulas_idLB.Location = new System.Drawing.Point(210, 56);
            this.formulas_idLB.Name = "formulas_idLB";
            this.formulas_idLB.Size = new System.Drawing.Size(27, 225);
            this.formulas_idLB.TabIndex = 20;
            this.formulas_idLB.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Ім\'я формули";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Короткий опис";
            // 
            // Bind
            // 
            this.Bind.Location = new System.Drawing.Point(360, 108);
            this.Bind.Name = "Bind";
            this.Bind.Size = new System.Drawing.Size(34, 27);
            this.Bind.TabIndex = 38;
            this.Bind.Text = "←";
            this.toolTip1.SetToolTip(this.Bind, "Пов\'язує параметр з формулою ");
            this.Bind.UseVisualStyleBackColor = true;
            this.Bind.Click += new System.EventHandler(this.Bind_Click);
            // 
            // Unbind
            // 
            this.Unbind.Location = new System.Drawing.Point(360, 141);
            this.Unbind.Name = "Unbind";
            this.Unbind.Size = new System.Drawing.Size(34, 27);
            this.Unbind.TabIndex = 39;
            this.Unbind.Text = "→";
            this.toolTip1.SetToolTip(this.Unbind, "Прибирає зв\'язку параметра та формули");
            this.Unbind.UseVisualStyleBackColor = true;
            this.Unbind.Click += new System.EventHandler(this.Unbind_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Короткий опис";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Ім\'я параметра";
            // 
            // del2
            // 
            this.del2.Location = new System.Drawing.Point(508, 345);
            this.del2.Name = "del2";
            this.del2.Size = new System.Drawing.Size(76, 23);
            this.del2.TabIndex = 33;
            this.del2.Text = "Видалити";
            this.del2.UseVisualStyleBackColor = true;
            this.del2.Click += new System.EventHandler(this.del2_Click);
            // 
            // update2
            // 
            this.update2.Location = new System.Drawing.Point(508, 316);
            this.update2.Name = "update2";
            this.update2.Size = new System.Drawing.Size(76, 23);
            this.update2.TabIndex = 32;
            this.update2.Text = "Змінити";
            this.update2.UseVisualStyleBackColor = true;
            this.update2.Click += new System.EventHandler(this.update2_Click);
            // 
            // add2
            // 
            this.add2.Location = new System.Drawing.Point(508, 287);
            this.add2.Name = "add2";
            this.add2.Size = new System.Drawing.Size(76, 23);
            this.add2.TabIndex = 31;
            this.add2.Text = "Додати";
            this.add2.UseVisualStyleBackColor = true;
            this.add2.Click += new System.EventHandler(this.add2_Click);
            // 
            // component_nameTB
            // 
            this.component_nameTB.Location = new System.Drawing.Point(394, 303);
            this.component_nameTB.Name = "component_nameTB";
            this.component_nameTB.Size = new System.Drawing.Size(100, 20);
            this.component_nameTB.TabIndex = 30;
            // 
            // component_explTB
            // 
            this.component_explTB.Location = new System.Drawing.Point(394, 379);
            this.component_explTB.Name = "component_explTB";
            this.component_explTB.Size = new System.Drawing.Size(256, 48);
            this.component_explTB.TabIndex = 28;
            this.component_explTB.Text = "";
            // 
            // componentLB
            // 
            this.componentLB.FormattingEnabled = true;
            this.componentLB.Location = new System.Drawing.Point(394, 56);
            this.componentLB.MultiColumn = true;
            this.componentLB.Name = "componentLB";
            this.componentLB.Size = new System.Drawing.Size(256, 225);
            this.componentLB.TabIndex = 27;
            this.componentLB.SelectedIndexChanged += new System.EventHandler(this.componentLB_SelectedIndexChanged);
            this.componentLB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.componentLB_MouseMove);
            // 
            // componentidLB
            // 
            this.componentidLB.FormattingEnabled = true;
            this.componentidLB.Location = new System.Drawing.Point(656, 56);
            this.componentidLB.Name = "componentidLB";
            this.componentidLB.Size = new System.Drawing.Size(27, 225);
            this.componentidLB.TabIndex = 29;
            this.componentidLB.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Одиниці вимірювання";
            // 
            // component_measureTB
            // 
            this.component_measureTB.Location = new System.Drawing.Point(394, 340);
            this.component_measureTB.Name = "component_measureTB";
            this.component_measureTB.Size = new System.Drawing.Size(100, 20);
            this.component_measureTB.TabIndex = 36;
            // 
            // bind_compLB
            // 
            this.bind_compLB.FormattingEnabled = true;
            this.bind_compLB.Location = new System.Drawing.Point(238, 56);
            this.bind_compLB.MultiColumn = true;
            this.bind_compLB.Name = "bind_compLB";
            this.bind_compLB.Size = new System.Drawing.Size(122, 225);
            this.bind_compLB.TabIndex = 40;
            this.bind_compLB.SelectedIndexChanged += new System.EventHandler(this.bind_compLB_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Формули";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(391, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Всі параметри";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Параметри обраної формули";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 326);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Одиниці вимірювання";
            // 
            // formula_measureTB
            // 
            this.formula_measureTB.Location = new System.Drawing.Point(15, 340);
            this.formula_measureTB.Name = "formula_measureTB";
            this.formula_measureTB.Size = new System.Drawing.Size(100, 20);
            this.formula_measureTB.TabIndex = 44;
            // 
            // search_formula
            // 
            this.search_formula.Location = new System.Drawing.Point(12, 30);
            this.search_formula.Name = "search_formula";
            this.search_formula.Size = new System.Drawing.Size(100, 20);
            this.search_formula.TabIndex = 46;
            this.search_formula.TextChanged += new System.EventHandler(this.search_formula_TextChanged);
            // 
            // search_parametr
            // 
            this.search_parametr.Location = new System.Drawing.Point(394, 30);
            this.search_parametr.Name = "search_parametr";
            this.search_parametr.Size = new System.Drawing.Size(100, 20);
            this.search_parametr.TabIndex = 47;
            this.search_parametr.TextChanged += new System.EventHandler(this.search_parametr_TextChanged);
            // 
            // experts_CB
            // 
            this.experts_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.experts_CB.FormattingEnabled = true;
            this.experts_CB.Location = new System.Drawing.Point(642, 6);
            this.experts_CB.Name = "experts_CB";
            this.experts_CB.Size = new System.Drawing.Size(121, 21);
            this.experts_CB.TabIndex = 48;
            this.experts_CB.SelectedIndexChanged += new System.EventHandler(this.experts_CB_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(552, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Вибір експерта";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оновитиToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 26);
            // 
            // оновитиToolStripMenuItem
            // 
            this.оновитиToolStripMenuItem.Name = "оновитиToolStripMenuItem";
            this.оновитиToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.оновитиToolStripMenuItem.Text = "Оновити";
            this.оновитиToolStripMenuItem.Click += new System.EventHandler(this.оновитиToolStripMenuItem_Click);
            // 
            // Redakt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.experts_CB);
            this.Controls.Add(this.search_parametr);
            this.Controls.Add(this.search_formula);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.formula_measureTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bind_compLB);
            this.Controls.Add(this.Unbind);
            this.Controls.Add(this.Bind);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.component_measureTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.del2);
            this.Controls.Add(this.update2);
            this.Controls.Add(this.add2);
            this.Controls.Add(this.component_nameTB);
            this.Controls.Add(this.component_explTB);
            this.Controls.Add(this.componentLB);
            this.Controls.Add(this.componentidLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.del1);
            this.Controls.Add(this.update1);
            this.Controls.Add(this.add1);
            this.Controls.Add(this.formula_nameTB);
            this.Controls.Add(this.formula_explTB);
            this.Controls.Add(this.formulasLB);
            this.Controls.Add(this.formulas_idLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Redakt";
            this.Text = "Редактор формул";
            this.Load += new System.EventHandler(this.Redakt_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button del1;
        private System.Windows.Forms.Button update1;
        private System.Windows.Forms.Button add1;
        private System.Windows.Forms.TextBox formula_nameTB;
        private System.Windows.Forms.RichTextBox formula_explTB;
        private System.Windows.Forms.ListBox formulasLB;
        private System.Windows.Forms.ListBox formulas_idLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button del2;
        private System.Windows.Forms.Button update2;
        private System.Windows.Forms.Button add2;
        private System.Windows.Forms.TextBox component_nameTB;
        private System.Windows.Forms.RichTextBox component_explTB;
        private System.Windows.Forms.ListBox componentLB;
        private System.Windows.Forms.ListBox componentidLB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox component_measureTB;
        private System.Windows.Forms.Button Bind;
        private System.Windows.Forms.Button Unbind;
        private System.Windows.Forms.ListBox bind_compLB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox formula_measureTB;
        private System.Windows.Forms.TextBox search_formula;
        private System.Windows.Forms.TextBox search_parametr;
        private System.Windows.Forms.ComboBox experts_CB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem оновитиToolStripMenuItem;
    }
}
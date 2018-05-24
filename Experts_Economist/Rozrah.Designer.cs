namespace Experts_Economist
{
    partial class Rozrah
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.formulasLB = new System.Windows.Forms.ListBox();
            this.formulasDGV = new System.Windows.Forms.DataGridView();
            this.Param_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param_measure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.param_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Save_values = new System.Windows.Forms.Button();
            this.formulas_idLB = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.series_over = new System.Windows.Forms.Button();
            this.showLog = new System.Windows.Forms.Button();
            this.number_of_calcL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calc_numbCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.desc_of_seriesTB = new System.Windows.Forms.RichTextBox();
            this.Iterations = new System.Windows.Forms.ComboBox();
            this.for_i = new System.Windows.Forms.Label();
            this.issueL = new System.Windows.Forms.Label();
            this.issueTB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.experts_CB = new System.Windows.Forms.ComboBox();
            this.name_of_seriesCB = new System.Windows.Forms.ComboBox();
            this.form_desc_L = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.оновитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logTb = new System.Windows.Forms.RichTextBox();
            this.logL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.formulasDGV)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formulasLB
            // 
            this.formulasLB.FormattingEnabled = true;
            this.formulasLB.Location = new System.Drawing.Point(12, 28);
            this.formulasLB.Name = "formulasLB";
            this.formulasLB.Size = new System.Drawing.Size(171, 381);
            this.formulasLB.TabIndex = 1;
            this.formulasLB.SelectedIndexChanged += new System.EventHandler(this.FormulasLB_SelectedIndexChanged);
            this.formulasLB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formulasLB_MouseMove);
            // 
            // formulasDGV
            // 
            this.formulasDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.formulasDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Param_name,
            this.Param_value,
            this.Param_measure,
            this.param_desc});
            this.formulasDGV.Location = new System.Drawing.Point(476, 25);
            this.formulasDGV.Name = "formulasDGV";
            this.formulasDGV.Size = new System.Drawing.Size(619, 238);
            this.formulasDGV.TabIndex = 2;
            this.formulasDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.formulasDGV_CellFormatting);
            this.formulasDGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.formulasDGV_EditingControlShowing);
            // 
            // Param_name
            // 
            this.Param_name.HeaderText = "Назва парамерту";
            this.Param_name.Name = "Param_name";
            this.Param_name.ReadOnly = true;
            this.Param_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Param_name.Width = 80;
            // 
            // Param_value
            // 
            this.Param_value.HeaderText = "Значення";
            this.Param_value.Name = "Param_value";
            this.Param_value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Param_value.Width = 80;
            // 
            // Param_measure
            // 
            this.Param_measure.HeaderText = "Одиниця вимірювання";
            this.Param_measure.Name = "Param_measure";
            this.Param_measure.ReadOnly = true;
            this.Param_measure.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Param_measure.Width = 80;
            // 
            // param_desc
            // 
            this.param_desc.HeaderText = "Опис параметру";
            this.param_desc.Name = "param_desc";
            this.param_desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.param_desc.Width = 440;
            // 
            // Save_values
            // 
            this.Save_values.Location = new System.Drawing.Point(476, 270);
            this.Save_values.Name = "Save_values";
            this.Save_values.Size = new System.Drawing.Size(94, 35);
            this.Save_values.TabIndex = 3;
            this.Save_values.Text = "Порахувати та зберегти";
            this.toolTip1.SetToolTip(this.Save_values, "Рахує значення формули та записує його то Бази даних");
            this.Save_values.UseVisualStyleBackColor = true;
            this.Save_values.Click += new System.EventHandler(this.Save_values_Click);
            // 
            // formulas_idLB
            // 
            this.formulas_idLB.FormattingEnabled = true;
            this.formulas_idLB.Location = new System.Drawing.Point(189, 28);
            this.formulas_idLB.Name = "formulas_idLB";
            this.formulas_idLB.Size = new System.Drawing.Size(27, 381);
            this.formulas_idLB.TabIndex = 10;
            this.formulas_idLB.Visible = false;
            // 
            // series_over
            // 
            this.series_over.Location = new System.Drawing.Point(582, 270);
            this.series_over.Name = "series_over";
            this.series_over.Size = new System.Drawing.Size(94, 35);
            this.series_over.TabIndex = 25;
            this.series_over.Text = "Закінчити серію";
            this.toolTip1.SetToolTip(this.series_over, "Зберігає опис серії, ставить наступний номер серії");
            this.series_over.UseVisualStyleBackColor = true;
            this.series_over.Click += new System.EventHandler(this.series_over_Click);
            // 
            // showLog
            // 
            this.showLog.Location = new System.Drawing.Point(912, 425);
            this.showLog.Name = "showLog";
            this.showLog.Size = new System.Drawing.Size(29, 24);
            this.showLog.TabIndex = 59;
            this.showLog.Text = ">";
            this.toolTip1.SetToolTip(this.showLog, "Зберігає опис серії, ставить наступний номер серії");
            this.showLog.UseVisualStyleBackColor = true;
            this.showLog.Click += new System.EventHandler(this.showLog_Click);
            // 
            // number_of_calcL
            // 
            this.number_of_calcL.AutoSize = true;
            this.number_of_calcL.Location = new System.Drawing.Point(691, 272);
            this.number_of_calcL.Name = "number_of_calcL";
            this.number_of_calcL.Size = new System.Drawing.Size(111, 13);
            this.number_of_calcL.TabIndex = 14;
            this.number_of_calcL.Text = "Серія розрахунків №";
            this.number_of_calcL.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Список формул";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Список параметрів даної формули";
            // 
            // calc_numbCB
            // 
            this.calc_numbCB.FormattingEnabled = true;
            this.calc_numbCB.Location = new System.Drawing.Point(808, 269);
            this.calc_numbCB.Name = "calc_numbCB";
            this.calc_numbCB.Size = new System.Drawing.Size(100, 21);
            this.calc_numbCB.TabIndex = 18;
            this.calc_numbCB.Visible = false;
            this.calc_numbCB.TextChanged += new System.EventHandler(this.calc_numbCB_TextChanged);
            this.calc_numbCB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.calc_numbCB_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Назва серії";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Опис серії";
            // 
            // desc_of_seriesTB
            // 
            this.desc_of_seriesTB.Location = new System.Drawing.Point(476, 307);
            this.desc_of_seriesTB.Name = "desc_of_seriesTB";
            this.desc_of_seriesTB.Size = new System.Drawing.Size(246, 78);
            this.desc_of_seriesTB.TabIndex = 22;
            this.desc_of_seriesTB.Text = "";
            // 
            // Iterations
            // 
            this.Iterations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Iterations.FormattingEnabled = true;
            this.Iterations.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.Iterations.Location = new System.Drawing.Point(220, 90);
            this.Iterations.Name = "Iterations";
            this.Iterations.Size = new System.Drawing.Size(100, 21);
            this.Iterations.TabIndex = 23;
            this.Iterations.Visible = false;
            this.Iterations.SelectedIndexChanged += new System.EventHandler(this.Iterations_SelectedIndexChanged);
            this.Iterations.VisibleChanged += new System.EventHandler(this.Iterations_VisibleChanged);
            // 
            // for_i
            // 
            this.for_i.AutoSize = true;
            this.for_i.Location = new System.Drawing.Point(186, 62);
            this.for_i.Name = "for_i";
            this.for_i.Size = new System.Drawing.Size(117, 13);
            this.for_i.TabIndex = 24;
            this.for_i.Text = "Кількість забрудників";
            this.for_i.Visible = false;
            // 
            // issueL
            // 
            this.issueL.AutoSize = true;
            this.issueL.Location = new System.Drawing.Point(405, 398);
            this.issueL.Name = "issueL";
            this.issueL.Size = new System.Drawing.Size(145, 13);
            this.issueL.TabIndex = 27;
            this.issueL.Text = "Задача, пов\'язана з серією";
            // 
            // issueTB
            // 
            this.issueTB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.issueTB.FormattingEnabled = true;
            this.issueTB.Location = new System.Drawing.Point(476, 418);
            this.issueTB.Name = "issueTB";
            this.issueTB.Size = new System.Drawing.Size(246, 21);
            this.issueTB.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 420);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "Вибір експерта";
            this.label10.Visible = false;
            // 
            // experts_CB
            // 
            this.experts_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.experts_CB.FormattingEnabled = true;
            this.experts_CB.Location = new System.Drawing.Point(102, 417);
            this.experts_CB.Name = "experts_CB";
            this.experts_CB.Size = new System.Drawing.Size(121, 21);
            this.experts_CB.TabIndex = 52;
            this.experts_CB.Visible = false;
            this.experts_CB.SelectedIndexChanged += new System.EventHandler(this.experts_CB_SelectedIndexChanged);
            // 
            // name_of_seriesCB
            // 
            this.name_of_seriesCB.FormattingEnabled = true;
            this.name_of_seriesCB.Location = new System.Drawing.Point(189, 28);
            this.name_of_seriesCB.Name = "name_of_seriesCB";
            this.name_of_seriesCB.Size = new System.Drawing.Size(281, 21);
            this.name_of_seriesCB.TabIndex = 54;
            this.name_of_seriesCB.SelectedIndexChanged += new System.EventHandler(this.name_of_seriesCB_SelectedIndexChanged);
            // 
            // form_desc_L
            // 
            this.form_desc_L.AutoSize = true;
            this.form_desc_L.Location = new System.Drawing.Point(189, 123);
            this.form_desc_L.MaximumSize = new System.Drawing.Size(250, 0);
            this.form_desc_L.Name = "form_desc_L";
            this.form_desc_L.Size = new System.Drawing.Size(87, 13);
            this.form_desc_L.TabIndex = 55;
            this.form_desc_L.Text = "Опис формули :";
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
            // logTb
            // 
            this.logTb.Location = new System.Drawing.Point(947, 296);
            this.logTb.Name = "logTb";
            this.logTb.ReadOnly = true;
            this.logTb.Size = new System.Drawing.Size(148, 153);
            this.logTb.TabIndex = 57;
            this.logTb.Text = "";
            this.logTb.Visible = false;
            // 
            // logL
            // 
            this.logL.AutoSize = true;
            this.logL.Location = new System.Drawing.Point(944, 280);
            this.logL.Name = "logL";
            this.logL.Size = new System.Drawing.Size(107, 13);
            this.logL.TabIndex = 58;
            this.logL.Text = "Останні розрахунки";
            this.logL.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(751, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Показати останні розрахунки";
            // 
            // Rozrah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 461);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.showLog);
            this.Controls.Add(this.logL);
            this.Controls.Add(this.logTb);
            this.Controls.Add(this.form_desc_L);
            this.Controls.Add(this.name_of_seriesCB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.experts_CB);
            this.Controls.Add(this.issueL);
            this.Controls.Add(this.issueTB);
            this.Controls.Add(this.series_over);
            this.Controls.Add(this.for_i);
            this.Controls.Add(this.Iterations);
            this.Controls.Add(this.desc_of_seriesTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calc_numbCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.number_of_calcL);
            this.Controls.Add(this.Save_values);
            this.Controls.Add(this.formulasDGV);
            this.Controls.Add(this.formulasLB);
            this.Controls.Add(this.formulas_idLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Rozrah";
            this.Text = "Економіст_розрахунки";
            this.Load += new System.EventHandler(this.Rozrah_Load);
            ((System.ComponentModel.ISupportInitialize)(this.formulasDGV)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox formulasLB;
        private System.Windows.Forms.DataGridView formulasDGV;
        private System.Windows.Forms.Button Save_values;
        private System.Windows.Forms.ListBox formulas_idLB;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label number_of_calcL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox calc_numbCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox desc_of_seriesTB;
        private System.Windows.Forms.ComboBox Iterations;
        private System.Windows.Forms.Label for_i;
        private System.Windows.Forms.Button series_over;
        private System.Windows.Forms.Label issueL;
        private System.Windows.Forms.ComboBox issueTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox experts_CB;
        private System.Windows.Forms.ComboBox name_of_seriesCB;
        private System.Windows.Forms.Label form_desc_L;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param_value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param_measure;
        private System.Windows.Forms.DataGridViewTextBoxColumn param_desc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem оновитиToolStripMenuItem;
        private System.Windows.Forms.RichTextBox logTb;
        private System.Windows.Forms.Label logL;
        private System.Windows.Forms.Button showLog;
        private System.Windows.Forms.Label label6;
    }
}


using FileBase;
using System;
using System.Windows.Forms;

namespace oprForm
{
    public partial class DocumentViewForm : Form
    {
        public DocumentViewForm(String file)
        {
            InitializeComponent();
            var fm = new FileBaseManager("/FB");
            webBrowser1.DocumentText = fm.GetHtm(file);
        }
    }
}
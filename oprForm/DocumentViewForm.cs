using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileBase;

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

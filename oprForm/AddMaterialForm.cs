using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oprForm
{
    public partial class AddMaterialForm : Form
    {
        DBManager db = new DBManager();

        public AddMaterialForm()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            db.Connect();
            string[] fields = { "name", "description" };
            string[] values = { DBUtil.AddQuotes(nameTB.Text), DBUtil.AddQuotes(descTB.Text) };
            db.InsertToBD("resource", fields, values);
            db.Disconnect();
            this.Close();
        }
    }
}

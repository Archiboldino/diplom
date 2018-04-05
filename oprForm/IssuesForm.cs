﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Data.Entity;

namespace oprForm
{
    public partial class IssuesForm : Form
    {
        private DBManagerNikita db = new DBManagerNikita();
        private String user = "Vasya";

        public IssuesForm()
        {
            InitializeComponent();
            RefreshIssues();
        }

        private void RefreshIssues()
        {
            issuesLB.Items.Clear();
            db.Connect();
            var obj = db.GetRows("issues", "*", "");
            var issues = new List<Issue>();
            foreach (var row in obj)
            {
                issues.Add(IssueMapper.Map(row));
            }


            issuesLB.Items.AddRange(issues.ToArray());
            db.Disconnect();
        }

        private void issuesLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (issuesLB.SelectedItem is Issue)
            {
                alterBtn.Visible = true;
                Issue issue = issuesLB.SelectedItem as Issue;
                ShowIssue(issue);

                //if (issue.seriesId.Length != 0)
                //{
                //    db.Connect();
                //    var calc = db.GetValue("calculations_description", "calculation_name", "calculation_number=" + issue.seriesId);
                //    seriesLbl.Text = calc.ToString();
                //    db.Disconnect();
                //}
                //else
                //{
                //    seriesLbl.Text = "Без серii";
                //}
            }
        }

        private void ShowIssue(Issue issue)
        {
            nameLbl.Text = issue.name;
            descrLbl.Text = issue.description;
            dateLbl.Text = issue.creationDate.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new AddIssueForm();
            form.ShowDialog(this);
            RefreshIssues();
        }

        private void IssuesForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new AlterIssueForm(issuesLB.SelectedItem as Issue);
            form.ShowDialog(this);
            ShowIssue(issuesLB.SelectedItem as Issue);
            RefreshIssues();
        }
    }
}
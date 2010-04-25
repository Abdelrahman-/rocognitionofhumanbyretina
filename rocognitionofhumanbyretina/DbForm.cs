using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rocognitionofhumanbyretina
{
    public partial class DbForm : Form
    {
        private AddForm addForm = null;

        public DbForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DbForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.test' table. You can move, or remove it, as needed.
            this.testTableAdapter.Fill(this.database1DataSet.test);

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addForm = new AddForm();
            addForm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rocognitionofhumanbyretina.DB;

namespace rocognitionofhumanbyretina
{
    public partial class Form1 : Form
    {
        private Connector dbConnector;

        public Form1()
        {
            InitializeComponent();
            dbConnector = new Connector();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Connector con = new Connector();
            con.init();
        }
    }
}
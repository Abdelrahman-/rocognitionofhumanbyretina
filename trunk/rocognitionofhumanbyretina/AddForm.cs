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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Image imageFirst= pictureBox1.Image;
            System.Drawing.Image imageSecond = pictureBox2.Image;
            Connector con = new Connector();
            //con.addRecordToDB(11, textBox1.Text, textBox2.Text, imageFirst, imageSecond, 24, 3);
            con.AddRecordLinqToSQL(textBox1.Text, textBox2.Text, textBox3.Text, imageFirst, imageSecond, 1, 1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(openFileDialog1.FileName);
            }
        }


    }
}

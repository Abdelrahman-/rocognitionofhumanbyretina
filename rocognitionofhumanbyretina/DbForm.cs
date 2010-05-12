using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rocognitionofhumanbyretina.DB;
using rocognitionofhumanbyretina.common;
using rocognitionofhumanbyretina.common.enums;
using System.IO;

namespace rocognitionofhumanbyretina
{
    public partial class DbForm : Form
    {

        public DbForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DbForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.test' table. You can move, or remove it, as needed.
            Connector cn = new Connector();

            List<Human> humans = cn.GetAllHumansInfo();

            for (int i = 0; i < humans.Count; i++)
            {
                if (i < humans.Count - 1)
                    this.dataGridView2.Rows.Add(1);
                this.dataGridView2.Rows[i].Cells[0].Value = humans[i].Name;
                this.dataGridView2.Rows[i].Cells[1].Value = humans[i].SecondName;
                this.dataGridView2.Rows[i].Cells[2].Value = humans[i].SurName;
                this.dataGridView2.Rows[i].Cells[3].Tag = humans[i].HumanId;
                this.comboBox1.Items.Add(humans[i].HumanId);
                this.comboBox2.Items.Add(cn.GetHumansInfo(humans[i].HumanId).SecondName);
            }
            radioButton1.Checked = true;
            comboBox1.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) //Assuming the button column as second column, if not can change the index
            {
                //check if anything needs to be validated here
                BitmapService bmpServ = new BitmapService();

                byte[] imageBytes = null;
                Image tempImage = null;

                Connector cn = new Connector();

                List<Peoples> peoples = cn.ConnectLinqDBInterface();
                Human human = cn.GetHumansInfo(Int32.Parse(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString()));

                ImageList imageList1 = new ImageList();
                imageList1.ImageSize = new Size(100, 100);
                imageList1.Images.Clear();

                listView1.Items.Clear();
                listView1.LargeImageList = imageList1;
                listView1.BeginUpdate();

                for (int i = 0; i < human.Peoples.Count; i++)
                {
                    imageBytes = (byte[])peoples[i].ImageFull;
                    tempImage = bmpServ.ByteToBmp(imageBytes);

                    imageList1.Images.Add((Image)tempImage);

                    ListViewItem listViewItem = new ListViewItem("Eye Picture: " + human.Peoples[i].EyeType + "\n "
                        + human.Peoples[i].Token1D_AttrOne + "\n " +
                        human.Peoples[i].Token1D_AttrTwo + "\n " +
                        human.Peoples[i].Token2D_AttrOne + "\n " +
                        human.Peoples[i].Token2D_AttrTwo + "\n ", i);
                    listViewItem.Tag = human.Peoples[i].id;
                    listView1.Items.Add(listViewItem);
                }

                listView1.EndUpdate();

                ImageList imageList2 = new ImageList();
                imageList2.ImageSize = new Size(100, 100);
                imageList2.Images.Clear();

                listView2.Items.Clear();
                listView2.LargeImageList = imageList2;
                listView2.BeginUpdate();

                for (int i = 0; i < human.Peoples.Count; i++)
                {
                    imageBytes = (byte[])peoples[i].ImagePart;
                    tempImage = bmpServ.ByteToBmp(imageBytes);
                    imageList2.Images.Add((Image)tempImage);

                    ListViewItem listViewItem = new ListViewItem("Part of Eye Picture: " + human.Peoples[i].EyeType + "\n "
                        + human.Peoples[i].Token1D_AttrOne + "\n " +
                        human.Peoples[i].Token1D_AttrTwo + "\n " +
                        human.Peoples[i].Token2D_AttrOne + "\n " +
                        human.Peoples[i].Token2D_AttrTwo + "\n ", i);
                    listViewItem.Tag = human.Peoples[i].id;
                    listViewItem.Tag = human.Peoples[i].id;
                    listView2.Items.Add(listViewItem);
                }

                listView2.EndUpdate();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connector cn = new Connector();
            comboBox2.Text = cn.GetHumansInfo(Int32.Parse(comboBox1.Text)).SecondName;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connector cn = new Connector();
            comboBox1.Text = cn.GetHumansInfoBySecondName(comboBox2.Text).HumanId.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Image imageFirst = this.pictureBox1.Image;
            Image imageSecond = this.pictureBox2.Image;

            Connector con = new Connector();

            EyeTypes eyeType;
            if (radioButton1.Checked)
                eyeType = EyeTypes.LEFT;
            else
                eyeType = EyeTypes.RIGHT;

            Gabor2D gabor2d = new Gabor2D();
            GaborResult gabor2dResult = gabor2d.GaborTransform(new Bitmap(imageSecond));

            double gabor1dRe = 0;
            double gabor1dIm = 0;
            double gabor2dRe = gabor2dResult.Avg;
            double gabor2dIm = gabor2dResult.Deta;

            con.addNewHumanInfoToDB(Int32.Parse(comboBox1.Text), imageFirst, imageSecond, gabor1dRe, gabor1dIm,
                gabor2dRe, gabor2dIm, eyeType.ToString());

            MessageBox.Show("Added new eye");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connector con = new Connector();
            con.addNewHumanToDB(textBox1.Text, textBox2.Text, textBox3.Text);
        }


    }
}

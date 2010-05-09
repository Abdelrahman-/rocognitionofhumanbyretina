using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rocognitionofhumanbyretina.DB;
using System.IO;
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
            this.Close();
        }

        private void DbForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.test' table. You can move, or remove it, as needed.
            MemoryStream msOne = null;
            byte[] bArrOne = null;
            MemoryStream msTwo = new MemoryStream();
            Image firstIm = null;
            byte[] bArrTwo = null;
            Image secIm = null;
            Connector cn=new Connector();
           /* List<Peoples> peoples = cn.ConnectLinqDBInterface();
            for(int i=0; i<cn.ConnectLinqDBInterface().Count;i++)
            {
                this.dataGridView1.Rows.Add(1);
                //this.dataGridView1.Rows[i].Cells[0].Value = peoples[i].Name;
                //this.dataGridView1.Rows[i].Cells[1].Value = peoples[i].SecondName;
                //this.dataGridView1.Rows[i].Cells[2].Value = peoples[i].SurName;
                bArrOne = (byte[])peoples[i].ImageFull;
                msOne=new MemoryStream(bArrOne);
                firstIm = new Bitmap(msOne);
                this.dataGridView1.Rows[i].Cells[4].Value = firstIm;
                bArrTwo = (byte[])peoples[i].ImagePart;
                msTwo = new MemoryStream(bArrTwo);
                secIm = new Bitmap(msTwo);
                this.dataGridView1.Rows[i].Cells[5].Value = secIm;
                this.dataGridView1.Rows[i].Cells[6].Value = peoples[i].Token1D_AttrOne;
                this.dataGridView1.Rows[i].Cells[7].Value = peoples[i].Token2D_AttrOne;
                }

            */

            
            
            List<Human> humans=cn.GetAllHumansInfo();

            for(int i=0;i<humans.Count;i++)
            {
                if(i<humans.Count-1)
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
            addForm = new AddForm();
            addForm.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) //Assuming the button column as second column, if not can change the index
            {                
                //check if anything needs to be validated here

                MemoryStream msOne = null;
                byte[] bArrOne = null;
                MemoryStream msTwo = new MemoryStream();
                Image firstIm = null;
                byte[] bArrTwo = null;
                Image secIm = null;
                Connector cn = new Connector();
                List<Peoples> peoples = cn.ConnectLinqDBInterface();
                Human human = cn.GetHumansInfo(Int32.Parse(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString()));

                ImageList imageList1 = new ImageList();
                imageList1.ImageSize = new Size(100, 100);
                imageList1.Images.Clear();



                listView1.Items.Clear();
                listView1.LargeImageList = imageList1;
                listView1.BeginUpdate();

                for (int i = 0; i<human.Peoples.Count; i++)
                {
                    bArrOne = (byte[])peoples[i].ImageFull;
                    msOne = new MemoryStream(bArrOne);
                    firstIm = new Bitmap(msOne);
                    
                    imageList1.Images.Add((Image)firstIm);
 
                    ListViewItem listViewItem = new ListViewItem("Eye Picture: "+human.Peoples[i].EyeType+"\n "
                        +human.Peoples[i].Token1D_AttrOne+"\n "+
                        human.Peoples[i].Token1D_AttrTwo+"\n "+
                        human.Peoples[i].Token2D_AttrOne+"\n "+
                        human.Peoples[i].Token2D_AttrTwo+"\n ", i);
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
                    bArrTwo = (byte[])peoples[i].ImagePart;
                    msTwo = new MemoryStream(bArrTwo);
                    secIm = new Bitmap(msTwo);
                    msTwo.Flush();
                    imageList2.Images.Add((Image)secIm);


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
            Connector cn=new Connector();
            comboBox2.Text=cn.GetHumansInfo(Int32.Parse(comboBox1.Text)).SecondName;
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
            System.Drawing.Image imageFirst = this.pictureBox1.Image;
            System.Drawing.Image imageSecond = this.pictureBox2.Image;
            Connector con = new Connector();
             string eyeType="left";
            if(radioButton1.Checked)
                eyeType="left";
            else if(radioButton2.Checked)
                eyeType="right";
            con.addNewHumanInfoToDB(Int32.Parse(comboBox1.Text), imageFirst, imageSecond, 1, 2, 3, 4, eyeType);
            
            //pictureBox3.Image = imageFirst;
            //MemoryStream msOne = null;
            //byte[] bArrOne = null;
            //MemoryStream msTwo = new MemoryStream();
            //Image firstIm = null;
            //byte[] bArrTwo = null;
            //Image secIm = null;
            //Connector cn = new Connector();
            //List<Peoples> peoples = cn.GetAllImages();
            //Human human = cn.GetHumansInfo(1);

            //ImageList imageList1 = new ImageList();
            //imageList1.ImageSize = new Size(100, 100);
            //imageList1.Images.Clear();


            //listView3.Items.Clear();
            //listView3.LargeImageList = imageList1;
            //listView3.BeginUpdate();

            //for (int i = 0; i < peoples.Count; i++)
            //{
            //    bArrOne = (byte[])peoples[i].ImagePart;
            //    msOne = new MemoryStream(bArrOne);
            //    firstIm = new Bitmap(msOne);
            //    msOne.Flush();
            //    imageList1.Images.Add((Image)firstIm);


            //    ListViewItem listViewItem = new ListViewItem("Eye Picture: " /*+ human.Peoples[i].EyeType +*/+ "\n "
            //        + human.Peoples[i].Token1D_AttrOne + "\n " +
            //        human.Peoples[i].Token1D_AttrTwo + "\n " +
            //        human.Peoples[i].Token2D_AttrOne + "\n " +
            //        human.Peoples[i].Token2D_AttrTwo + "\n ", i);
            //    listViewItem.Tag = human.Peoples[i].id;
            //    listView3.Items.Add(listViewItem);
            //}

            //listView3.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connector con = new Connector();
            con.addNewHumanToDB(textBox1.Text, textBox2.Text, textBox3.Text);
        }


    }
}

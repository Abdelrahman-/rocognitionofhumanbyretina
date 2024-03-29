﻿using System;
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
using System.Drawing.Imaging;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace rocognitionofhumanbyretina
{
    public partial class DbForm : Form
    {
        private List<Image> SelectedForCompareItems=new List<Image>();

        private BitmapService bmpService = new BitmapService();

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
            Connector cn = new Connector();

            List<Human> humans = cn.GetAllHumansInfo();
            this.comboBox1.Items.Clear();
            this.comboBox2.Items.Clear();
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
            if (e.ColumnIndex == 3 && e.RowIndex >= 0) //Assuming the button column as second column, if not can change the index
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
                        imageBytes = (byte[])human.Peoples[i].ImageFull;
                        tempImage = bmpServ.ByteToBmp(imageBytes);

                        imageList1.Images.Add((Image)tempImage);

                        ListViewItem listViewItem = new ListViewItem("Eye Picture: " + human.Peoples[i].EyeType + "\n ", i);
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
                    comboBox3.Items.Clear();
                    for (int i = 0; i < human.Peoples.Count; i++)
                    {
                        imageBytes = (byte[])human.Peoples[i].ImagePart;
                        tempImage = bmpServ.ByteToBmp(imageBytes);
                        imageList2.Images.Add((Image)tempImage);

                        ListViewItem listViewItem = new ListViewItem("Part of Eye Picture: " + human.Peoples[i].EyeType + "\n " + "Image ID: " + human.Peoples[i].id.ToString(), i);
                        listViewItem.Tag = human.Peoples[i].id;
                        listViewItem.Tag = human.Peoples[i].id;
                        listView2.Items.Add(listViewItem);
                        comboBox3.Items.Add(human.Peoples[i].id.ToString());
                    }

                    listView2.EndUpdate();
            }
            else if (e.ColumnIndex == 4 && e.RowIndex >= 0) //Assuming the button column as second column, if not can change the index
            {
                // Use a connection string.
                DataContext db = new DataContext(System.Windows.Forms.Application.StartupPath + "\\resources\\PeopleDB.mdf");

                // Get a typed table to run queries.
                Table<Peoples> peo = db.GetTable<Peoples>();
                Table<Human> hum = db.GetTable<Human>();
                
                IQueryable<Peoples> custQuery =
                from cust in peo
                where cust.HumanId == Int32.Parse(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Tag.ToString())
                select cust;

                db.ExecuteCommand("delete from Peoples where Peoples.HumanID=" + dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Tag.ToString());
                db.SubmitChanges();

                IQueryable<Human> humQuery =
                from h in hum
                where h.HumanId == Int32.Parse(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Tag.ToString())
                select h;

                foreach (Human hu in humQuery)
                {
                    hum.DeleteOnSubmit(hu);
                }
                db.SubmitChanges();

                dataGridView2.Rows.Clear();

                Connector cn = new Connector();

                List<Human> humans = cn.GetAllHumansInfo();
                this.comboBox1.Items.Clear();
                this.comboBox2.Items.Clear();
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

                db.Connection.Close();
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
            Gabor1D gabor1d = new Gabor1D(imageSecond as Bitmap);
            Gabor2D gabor2d = new Gabor2D(imageSecond as Bitmap);
            gabor1d.CalculateKernel1D(gabor1d.Image, 45, 32, imageSecond.Width, imageSecond.Height);
            gabor2d.CalculateKernel2D(gabor2d.Image,45, 32, imageSecond.Width, imageSecond.Height);//10 5
            
            //1 1
            //2 3
            
            //GaborResult gabor2dResult = gabor2d.GaborTransform(new Bitmap(imageSecond));

            Image gabor1dRe=new Bitmap(gabor1d.GaborRealCodeArray);
            Image gabor1dIm = new Bitmap(gabor1d.GaborImCodeArray);
            Image gabor2dRe = new Bitmap(gabor2d.GaborRealCodeArray);
            Image gabor2dIm = new Bitmap(gabor2d.GaborImCodeArray);



            
            byte[] bArrOne = bmpService.bmpToByte(gabor1dRe);
            
            
            byte[] bArrTwo = bmpService.bmpToByte(gabor1dIm);

            byte[] bArrThree = bmpService.bmpToByte(gabor2dRe);

            byte[] bArrFour = bmpService.bmpToByte(gabor2dIm);
            
            con.addNewHumanInfoToDB(Int32.Parse(comboBox1.Text), imageFirst, imageSecond, bArrOne, bArrTwo,
                            bArrThree, bArrFour, eyeType.ToString());

            MessageBox.Show("Added new eye");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connector con = new Connector();
            con.addNewHumanToDB(textBox1.Text, textBox2.Text, textBox3.Text);

            dataGridView2.Rows.Clear();

            Connector cn = new Connector();

            List<Human> humans = cn.GetAllHumansInfo();
            this.comboBox1.Items.Clear();
            this.comboBox2.Items.Clear();
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
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                int img_id = Convert.ToInt32(listView2.SelectedItems[0].Tag);

                Connector cn = new Connector();
                Peoples peo=cn.GetImagesDataByHumanID(img_id);

                ImageList imageList3 = new ImageList();
                imageList3.ImageSize = new Size(250, 50);
                imageList3.Images.Clear();

                listView3.Items.Clear();
                listView3.LargeImageList = imageList3;
                listView3.BeginUpdate();

                BitmapService bms = new BitmapService();

                imageList3.Images.Add(bms.ByteToBmp(peo.Token1D_AttrOne));
                imageList3.Images.Add(bms.ByteToBmp(peo.Token1D_AttrTwo));
                imageList3.Images.Add(bms.ByteToBmp(peo.Token2D_AttrOne));
                imageList3.Images.Add(bms.ByteToBmp(peo.Token2D_AttrTwo));


                    ListViewItem listViewItem1 = new ListViewItem("Code part: 1D RealCodeImage", 0);
                    ListViewItem listViewItem2 = new ListViewItem("Code part: 1D ImaginaryCodeImage", 1);
                    ListViewItem listViewItem3 = new ListViewItem("Code part: 2D RealCodeImage", 2);
                    ListViewItem listViewItem4 = new ListViewItem("Code part: 2D ImaginaryCodeImage", 3);

                    listViewItem1.Tag = peo.id;
                    listViewItem2.Tag = peo.id;
                    listViewItem3.Tag = peo.id;
                    listViewItem4.Tag = peo.id;
                    listView3.Items.Add(listViewItem1);
                    listView3.Items.Add(listViewItem2);
                    listView3.Items.Add(listViewItem3);
                    listView3.Items.Add(listViewItem4);
                listView3.EndUpdate();



            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedForCompareItems.Count == 2)
                {
                    MessageBox.Show("Внимание! Сравнивать можно только по два изображения! Выберите два изображения заново и сравните их!");
                    SelectedForCompareItems.Clear();
                }
                SelectedForCompareItems.Add(listView3.SelectedItems[0].ImageList.Images[listView3.SelectedItems[0].Index]);
                MessageBox.Show("Изображение добавлено!");
            }
            catch (Exception exc)
            {
                //MessageBox.Show("Выберите пожалуйста шаблон сперва, затем второй - и нажмите кнопку 'Сравнить изображения'!");
                MessageBox.Show(exc.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ImageComparisonForm icf = new ImageComparisonForm();
            icf.Activate();
            icf.Show();


            icf.GetFirstListBox.Items.Clear();
            icf.GetSecondListBox.Items.Clear();
            int differences=0;
            for (int i = 0; i < 250; i++)
            {
                icf.GetFirstListBox.Items.Add("");
                icf.GetSecondListBox.Items.Add("");
                for (int j = 0; j < 50; j++)
                {

                    icf.GetFirstListBox.Items[i] = icf.GetFirstListBox.Items[i] + ((SelectedForCompareItems[0] as Bitmap).GetPixel(i, j).R / 255).ToString() + " ";

                    
                    icf.GetSecondListBox.Items[i] = icf.GetSecondListBox.Items[i] + ((SelectedForCompareItems[1] as Bitmap).GetPixel(i, j).R / 255).ToString() + " ";
                    if (((SelectedForCompareItems[0] as Bitmap).GetPixel(i, j).R / 255) != ((SelectedForCompareItems[1] as Bitmap).GetPixel(i, j).R / 255))
                    differences++;
                }
            }
            icf.Text=icf.Text+" "+differences+"diff was found";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 0)
            {
                DataContext db = new DataContext(System.Windows.Forms.Application.StartupPath + "\\resources\\PeopleDB.mdf");

                Table<Peoples> peo = db.GetTable<Peoples>();
                db.ExecuteCommand("delete from Peoples where id=" + comboBox3.Text);
                db.SubmitChanges();
            }
        }


    }
}

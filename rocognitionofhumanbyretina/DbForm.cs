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
            List<Peoples> peoples = cn.ConnectLinqDBInterface();
            for(int i=0; i<cn.ConnectLinqDBInterface().Count;i++)
            {
                this.dataGridView1.Rows.Add(1);
                //this.dataGridView1.Rows[i].Cells[0].Value = peoples[i].Name;
                //this.dataGridView1.Rows[i].Cells[1].Value = peoples[i].SecondName;
                //this.dataGridView1.Rows[i].Cells[2].Value = peoples[i].SurName;
                bArrOne = (byte[])peoples[i].ImageFull;
                msOne=new MemoryStream(bArrOne);
                firstIm = new Bitmap(msOne);
                this.dataGridView1.Rows[i].Cells[3].Value = firstIm;
                bArrTwo = (byte[])peoples[i].ImagePart;
                msTwo = new MemoryStream(bArrTwo);
                secIm = new Bitmap(msTwo);
                this.dataGridView1.Rows[i].Cells[4].Value = secIm;
                this.dataGridView1.Rows[i].Cells[5].Value = peoples[i].Token1D;
                this.dataGridView1.Rows[i].Cells[6].Value = peoples[i].Token2D;
                }

            TreeNode root = new TreeNode();
            ImageList imageList=new ImageList();
            imageList.Images.Add(secIm);
            root.ImageIndex = 0;

            (this.dataGridView1.Rows[1].Cells[7]as DataGridViewComboBoxCell).Items.Add(imageList.Images[0]);
            treeView1.ImageList = imageList;
            treeView1.Nodes.Add(new TreeNode());
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addForm = new AddForm();
            addForm.Show();
        }


    }
}

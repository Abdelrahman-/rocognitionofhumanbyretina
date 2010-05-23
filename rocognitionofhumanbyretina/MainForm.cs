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
    public partial class MainForm : Form
    {
        private DbForm dbForm = new DbForm();
        private GraphForm graphForm = new GraphForm();

        private Connector dbConnector;

        public static bool clicked = false;
        public static Point startPoint;
        public static Point finishPoint;

        public MainForm()
        {
            InitializeComponent();
            dbConnector = new Connector();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxMain.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Connector con = new Connector();
            //con.init();
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            startPoint.X = e.X;
            startPoint.Y = e.Y;
        }

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
            finishPoint.X = e.X;
            finishPoint.Y = e.Y;
            pictureBoxMain.Refresh();
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                finishPoint.X = e.X;
                finishPoint.Y = e.Y;
                pictureBoxMain.Refresh();
            }
        }

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            if (finishPoint.X > startPoint.X && finishPoint.Y > startPoint.Y)
            {
                graph.DrawRectangle(new Pen(Color.Red), startPoint.X, startPoint.Y, finishPoint.X - startPoint.X, finishPoint.Y - startPoint.Y);
            }
            else if (finishPoint.X > startPoint.X && finishPoint.Y < startPoint.Y)
            {
                graph.DrawRectangle(new Pen(Color.Red), startPoint.X, finishPoint.Y, finishPoint.X - startPoint.X, startPoint.Y - finishPoint.Y);
            }
            else if (finishPoint.X < startPoint.X && finishPoint.Y > startPoint.Y)
            {
                graph.DrawRectangle(new Pen(Color.Red), finishPoint.X, startPoint.Y, startPoint.X - finishPoint.X, finishPoint.Y - startPoint.Y);
            }
            else
            {
                graph.DrawRectangle(new Pen(Color.Red), finishPoint.X, finishPoint.Y, startPoint.X - finishPoint.X, startPoint.Y - finishPoint.Y);
            }
        }

        private void dbButton_Click(object sender, EventArgs e)
        {

            dbForm = new DbForm();
            dbForm.Activate();
            dbForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connector cn = new Connector();
            cn.ConnectLinqDBInterface();

            // Attach the log to show generated SQL.
            //db.Log = Console.Out;

            // Query for customers in London.


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Connector cn = new Connector();
            //cn.AddRecordLinqToSQL();
        }

        private void graphButton_Click(object sender, EventArgs e)
        {
            graphForm.Show();
        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    Gabor2D gab = new Gabor2D();

        //    //int[,] testIm = {{12,23,56,122,221,13,14,89,159,243},
        //    //                {12,23,56,122,0,13,14,89,0,243},
        //    //                {12,23,56,0,221,13,14,89,159,243},
        //    //                {12,23,56,122,0,13,14,89,0,243},
        //    //                {12,23,56,122,221,13,14,89,159,243},
        //    //                {12,0,56,122,221,13,14,89,159,243},
        //    //                {12,23,56,0,221,13,14,89,159,0},
        //    //                {12,23,56,122,221,13,14,89,159,243},
        //    //                {12,23,56,122,221,13,14,89,159,0},
        //    //                {12,23,56,122,0,13,14,89,0,243},
        //    //                {12,23,56,122,221,13,14,89,159,243},};


        //    int[,] testIm = {{0,0,0,0,255,0,0,0,0,0},
        //                    {0,0,0,0,255,0,0,0,0,0},
        //                    {0,0,0,0,255,0,0,0,0,0},
        //                    {0,0,0,0,255,0,0,0,0,0},
        //                   {0,0,0,0,0,255,0,0,0,0},
        //                    {255,255,255,255,255,255,255,255,255,255},
        //                    {0,0,0,0,255,0,0,0,0,0},
        //                    {0,0,0,0,255,0,0,0,0,0},
        //                    {0,0,0,0,255,0,0,0,0,0},
        //                   {0,0,0,0,0,255,0,0,0,0},
        //                   {0,0,0,0,0,255,0,0,0,0},};


        //    int[,] arr=gab.CalculateKernel1D(testIm,0,0,10,10);
        //    int[,] arrSec = gab.CalculateKernel2D(testIm, 0, 0, 10, 10);
        //    //for (int i = 0; i < 10;i++ )
        //    //    dataGridView1.Columns.Add(new DataGridViewColumn());
        //        for (int i = 0; i < 10; i++)
        //        {
        //            dataGridView1.Rows.Add(1);
        //            dataGridView2.Rows.Add(1);
        //            for (int j = 0; j < 10; j++)
        //            {
        //                //if (i == 0)
                            
        //                dataGridView1.Rows[i].Cells[j].Value = arr[i, j];
        //                dataGridView2.Rows[i].Cells[j].Value = arrSec[i, j];
        //            }
        //        }
        //}
    }
}
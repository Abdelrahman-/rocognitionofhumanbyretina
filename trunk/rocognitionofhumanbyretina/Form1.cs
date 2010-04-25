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

        public static bool clicked = false;
        public static Point startPoint;
        public static Point finishPoint;

        public Form1()
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
            con.init();
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
    }
}
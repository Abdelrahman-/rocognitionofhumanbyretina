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

namespace rocognitionofhumanbyretina
{
    public partial class MainForm : Form
    {
        private DbForm dbForm = null;
        private GraphForm graphForm = null;

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
            if (dbForm == null)
            {
                dbForm = new DbForm();
            }
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Connector cn = new Connector();
        }

        private void graphButton_Click(object sender, EventArgs e)
        {
            if (graphForm == null)
            {
                graphForm = new GraphForm();
            }
            graphForm.Show();
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            GaborTypes type = GaborTypes.WAVELET1D;

            if (radioButton1D.Checked)
            {
                type = GaborTypes.WAVELET1D;
            }
            else if (radioButton2D.Checked)
            {
                type = GaborTypes.WAVELET2D;
            }

            if (pictureBoxMain.Image == null)
            {
                MessageBox.Show("Не выбран шаблон!");
            }
            else
            {               
                Recognification recognif = new Recognification();
                Peoples people = recognif.start(type, new Bitmap(pictureBoxMain.Image));

                if (people == null)
                {
                    MessageBox.Show("Данная сетчатка не распознана!");
                    return;
                }
                else
                {

                    Connector cn = new Connector();
                    Human hm = cn.GetHumansInfo(people.HumanId);

                    MessageBox.Show("Наиболее вероятно, что этот глаз пренадлежит: \n" + hm.Name + " " + hm.SurName + " " + hm.SecondName);
                }
            }
        }
    }
}
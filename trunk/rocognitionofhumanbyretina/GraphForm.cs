using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using rocognitionofhumanbyretina.common;
using rocognitionofhumanbyretina.DB;

namespace rocognitionofhumanbyretina
{
    public partial class GraphForm : Form
    {
        private GraphService graphService = new GraphService();
        private BitmapService bmpService = new BitmapService();

        public GraphForm()
        {
            InitializeComponent();
            init();
            DrawGraphs();
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private double f(double x)
        {
            if (x == 0)
            {
                return 1;
            }

            return Math.Sin(x) / x;
        }

        private void DrawGraphs()
        {
            // Получим панель для рисования
            GraphPane pane = zedGraphControl1.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            foreach (LineItem line in graphService.LinesList)
            {
                // Создадим кривые
                pane.AddCurve(line.Label.Text, line.Points, line.Color, line.Symbol.Type);
            }
            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphControl1.AxisChange();

            // Обновляем график
            zedGraphControl1.Invalidate();
        }

   
        private void GraphForm_Shown(object sender, EventArgs e)
        {
        }

        private void init()
        {
            Connector cn = new Connector();
            List<Peoples> peoples = cn.GetAllImages();

            List<Point> my1d = new List<Point>();
            List<Point> dontMy1d = new List<Point>();

            List<Point> my2d = new List<Point>();
            List<Point> dontMy2d = new List<Point>();
            List<Int32>[] list1 = new List<Int32>[100000];
            List<Int32>[] list2 = new List<Int32>[100000];
            int _1d,_2d;
            int[] arr = new int[1000000];
            int[] arr1 = new int[1000000];

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();


            for (int x = 0, i = 0; i <100000; i++)
            {
                    list1[i] = new List<Int32>();
                    list2[i] = new List<Int32>();
            }

            Int32[,] temp = new Int32[peoples.Count - 1, peoples.Count];
            Int32[,] temp1= new Int32[peoples.Count - 1, peoples.Count];


            for (int x=0,i = 0; i < peoples.Count - 1; i++)
            {
                for (int j = i + 1; j < peoples.Count; j++,x++)
                {

                    _1d=((int)bmpService.HD(peoples[i].Token1D_AttrOne, peoples[j].Token1D_AttrOne) +
                                (int)bmpService.HD(peoples[i].Token1D_AttrTwo, peoples[j].Token1D_AttrTwo));
                    _2d=((int)bmpService.HD(peoples[i].Token2D_AttrOne, peoples[j].Token2D_AttrOne) +
                                        (int)bmpService.HD(peoples[i].Token2D_AttrTwo, peoples[j].Token2D_AttrTwo));
                    temp[i, j] = _1d;
                    temp1[i, j] = _2d;

                    list1[_1d].Add(1);
                    list2[_2d].Add(1);

                    listBox1.Items.Add("Count= " + list1[_1d].Count.ToString()+"Value= "+_1d.ToString());
                    listBox2.Items.Add("Count= " + list2[_2d].Count.ToString() + "Value= " + _2d.ToString());


                    //if (peoples[i].HumanId == peoples[j].HumanId && peoples[i].EyeType == peoples[j].EyeType)
                    //{

                    //    my1d.Add(new Point(_1d,list1[_1d].Count()));
                    //    my2d.Add(new Point(_2d,list2[_2d].Count()));
                    //}
                    //else
                    //{
                    //    dontMy1d.Add(new Point(_1d,
                    //        list1[_1d].Count()));
                    //    dontMy2d.Add(new Point(_2d,
                    //        list2[_2d].Count()));
                    //}



                    //if ((int)bmpService.HD(peoples[i].Token1D_AttrOne, peoples[j].Token1D_AttrOne) +
                      //              (int)bmpService.HD(peoples[i].Token1D_AttrTwo, peoples[j].Token1D_AttrTwo) == 
                        //            (int)bmpService.HD(peoples[k].Token1D_AttrOne, peoples[l].Token1D_AttrOne) +
                          //      (int)bmpService.HD(peoples[k].Token1D_AttrTwo, peoples[l].Token1D_AttrTwo))
                    /*for (int k = 0; k < peoples.Count - 1; k++)
                    {
                        for(int l=0;l<peoples.Count;l++)
                        {
                            if ((int)bmpService.HD(peoples[i].Token1D_AttrOne, peoples[j].Token1D_AttrOne) +
                                    (int)bmpService.HD(peoples[i].Token1D_AttrTwo, peoples[j].Token1D_AttrTwo) == 
                                    (int)bmpService.HD(peoples[k].Token1D_AttrOne, peoples[l].Token1D_AttrOne) +
                                (int)bmpService.HD(peoples[k].Token1D_AttrTwo, peoples[l].Token1D_AttrTwo))

                        arr[(int)bmpService.HD(peoples[i].Token1D_AttrOne, peoples[j].Token1D_AttrOne) +
                                (int)bmpService.HD(peoples[i].Token1D_AttrTwo, peoples[j].Token1D_AttrTwo)]++;
                        }
                    }*/
                }
            }


            /*for (int i = 0; i < peoples.Count - 1; i++)
            {
                for (int j = i + 1; j < peoples.Count; j++)
                {
                    for (int k = 0; k < peoples.Count - 1; k++)
                    {
                        for (int l = 0; l < peoples.Count; l++)
                        {
                            if ((int)bmpService.HD(peoples[i].Token2D_AttrOne, peoples[j].Token2D_AttrOne) +
                                    (int)bmpService.HD(peoples[i].Token2D_AttrTwo, peoples[j].Token2D_AttrTwo) ==
                                    (int)bmpService.HD(peoples[k].Token2D_AttrOne, peoples[l].Token2D_AttrOne) +
                                (int)bmpService.HD(peoples[k].Token2D_AttrTwo, peoples[l].Token2D_AttrTwo))

                                arr[(int)bmpService.HD(peoples[i].Token2D_AttrOne, peoples[j].Token2D_AttrOne) +
                                        (int)bmpService.HD(peoples[i].Token2D_AttrTwo, peoples[j].Token2D_AttrTwo)]++;
                        }
                    }
                }
            }*/

            /*for (int i = 0; i < peoples.Count - 1; i++)
            {
                for (int j = i + 1; j < peoples.Count; j++)
                {
                    if (peoples[i].HumanId == peoples[j].HumanId && peoples[i].EyeType == peoples[j].EyeType)
                    {
                        
                        my1d.Add(new Point((int)bmpService.HD(peoples[i].Token1D_AttrOne, peoples[j].Token1D_AttrOne) +
                            (int)bmpService.HD(peoples[i].Token1D_AttrTwo, peoples[j].Token1D_AttrTwo),
                            arr[(int)bmpService.HD(peoples[i].Token1D_AttrOne, peoples[j].Token1D_AttrOne) +
                                (int)bmpService.HD(peoples[i].Token1D_AttrTwo, peoples[j].Token1D_AttrTwo)]));
                        my2d.Add(new Point((int)bmpService.HD(peoples[i].Token2D_AttrOne, peoples[j].Token2D_AttrOne) +
                            (int)bmpService.HD(peoples[i].Token2D_AttrTwo, peoples[j].Token2D_AttrTwo),
                            arr1[(int)bmpService.HD(peoples[i].Token2D_AttrOne, peoples[j].Token2D_AttrOne) +
                                (int)bmpService.HD(peoples[i].Token2D_AttrTwo, peoples[j].Token2D_AttrTwo)]));
                    }
                    else
                    {
                        dontMy1d.Add(new Point((int)bmpService.HD(peoples[i].Token1D_AttrOne, peoples[j].Token1D_AttrOne) +
                            (int)bmpService.HD(peoples[i].Token1D_AttrTwo, peoples[j].Token1D_AttrTwo),
                            arr[(int)bmpService.HD(peoples[i].Token1D_AttrOne, peoples[j].Token1D_AttrOne) +
                                (int)bmpService.HD(peoples[i].Token1D_AttrTwo, peoples[j].Token1D_AttrTwo)]));
                        dontMy2d.Add(new Point((int)bmpService.HD(peoples[i].Token2D_AttrOne, peoples[j].Token2D_AttrOne) +
                            (int)bmpService.HD(peoples[i].Token2D_AttrTwo, peoples[j].Token2D_AttrTwo),
                            arr1[(int)bmpService.HD(peoples[i].Token2D_AttrOne, peoples[j].Token2D_AttrOne) +
                                (int)bmpService.HD(peoples[i].Token2D_AttrTwo, peoples[j].Token2D_AttrTwo)]));
                    }
                }
            }*/

            for (int x = 0, i = 0; i < peoples.Count - 1; i++)
            {
                for (int j = i + 1; j < peoples.Count; j++, x++)
                {

                    if (peoples[i].HumanId == peoples[j].HumanId && peoples[i].EyeType == peoples[j].EyeType)
                    {

                        my1d.Add(new Point(temp[i, j], list1[temp[i, j]].Count()));
                        my2d.Add(new Point(temp1[i, j], list2[temp1[i, j]].Count()));
                    }
                    else
                    {
                        dontMy1d.Add(new Point(temp[i, j],
                            list1[temp[i, j]].Count()));
                        dontMy2d.Add(new Point(temp1[i, j],
                            list2[temp1[i, j]].Count()));
                    }
                }
            }



            graphService.addLine("1d their", my1d.ToArray(), Color.Red);
            graphService.addLine("1d zhuchie", dontMy1d.ToArray(), Color.Blue);

            graphService.addLine("2d their", my2d.ToArray(), Color.Green);
            graphService.addLine("2d zhuchie", dontMy2d.ToArray(), Color.Black);
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}

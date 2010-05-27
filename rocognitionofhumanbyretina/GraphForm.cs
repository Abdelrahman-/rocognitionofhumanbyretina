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
                //pane.AddCurve(line.Label.Text, line.Points, line.Color, line.Symbol.Type);
                
                pane.AddStick(line.Label.Text, line.Points, line.Color);
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

            List<PointD> my1d = new List<PointD>();
            List<PointD> dontMy1d = new List<PointD>();

            List<PointD> my2d = new List<PointD>();
            List<PointD> dontMy2d = new List<PointD>();
            List<Double>[] list1 = new List<Double>[100000];
            List<Double>[] list2 = new List<Double>[100000];
            Double _1d, _2d;
            Double[] arr = new Double[1000000];
            Double[] arr1 = new Double[1000000];

            listBox1.Items.Clear();
            listBox2.Items.Clear();
///            listBox3.Items.Clear();
///            listBox4.Items.Clear();


            for (int i = 0; i <100000; i++)
            {
                list1[i] = new List<Double>();
                list2[i] = new List<Double>();
            }

            Double[,] temp = new Double[peoples.Count - 1, peoples.Count];
            Double[,] temp1 = new Double[peoples.Count - 1, peoples.Count];


            for (int x=0,i = 0; i < peoples.Count - 1; i++)
            {
                for (int j = i + 1; j < peoples.Count; j++,x++)
                {

                    _1d = ((Double)bmpService.HD(peoples[i].Token1D_AttrOne, peoples[j].Token1D_AttrOne) +
                                (Double)bmpService.HD(peoples[i].Token1D_AttrTwo, peoples[j].Token1D_AttrTwo));
                    _2d = ((Double)bmpService.HD(peoples[i].Token2D_AttrOne, peoples[j].Token2D_AttrOne) +
                                        (Double)bmpService.HD(peoples[i].Token2D_AttrTwo, peoples[j].Token2D_AttrTwo));
                    temp[i, j] = _1d;
                    temp1[i, j] = _2d;

                    list1[(int)_1d].Add(1);
                    list2[(int)_2d].Add(1);
                }
            }


            for (int x = 0, i = 0; i < peoples.Count - 1; i++)
            {
                for (int j = i + 1; j < peoples.Count; j++, x++)
                {



                    if (peoples[i].HumanId == peoples[j].HumanId && peoples[i].EyeType == peoples[j].EyeType)
                    {
                        listBox1.Items.Add("RED Count= " + list1[(int)temp[i, j]].Count.ToString() + "Value= " + temp[i, j].ToString());
                        listBox2.Items.Add("BLUE Count= " + list2[(int)temp1[i, j]].Count.ToString() + "Value= " + temp1[i, j].ToString());

                        my1d.Add(new PointD(temp[i, j], list1[(int)temp[i, j]].Count()));
                        my2d.Add(new PointD(temp1[i, j], list2[(int)temp1[i, j]].Count()));
                    }
                    else
                    {
                        listBox3.Items.Add("GREEN Count= " + list1[(int)temp[i, j]].Count.ToString() + "Value= " + temp[i, j].ToString());
                        listBox4.Items.Add("BLACK Count= " + list2[(int)temp1[i, j]].Count.ToString() + "Value= " + temp1[i, j].ToString());

                        dontMy1d.Add(new PointD(temp[i, j],
                            list1[(int)temp[i, j]].Count()));
                        dontMy2d.Add(new PointD(temp1[i, j],
                            list2[(int)temp1[i, j]].Count()));
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

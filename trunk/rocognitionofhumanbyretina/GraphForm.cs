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

            for (int i = 0; i < peoples.Count - 1; i++)
            {
                for (int j = i + 1; j < peoples.Count; j++)
                {
                    if (peoples[i].HumanId == peoples[j].HumanId && peoples[i].EyeType == peoples[j].EyeType)
                    {
                        my1d.Add(new Point(peoples[i].HumanId, (int)bmpService.HD(peoples[i].Token1D_AttrOne, peoples[j].Token1D_AttrOne) +
                            (int)bmpService.HD(peoples[i].Token1D_AttrTwo, peoples[j].Token1D_AttrTwo)));
                        my2d.Add(new Point(peoples[i].HumanId, (int)bmpService.HD(peoples[i].Token2D_AttrOne, peoples[j].Token2D_AttrOne) +
                            (int)bmpService.HD(peoples[i].Token2D_AttrTwo, peoples[j].Token2D_AttrTwo)));
                    }
                    else
                    {
                        dontMy1d.Add(new Point(peoples[i].HumanId, (int)bmpService.HD(peoples[i].Token1D_AttrOne, peoples[j].Token1D_AttrOne) +
                            (int)bmpService.HD(peoples[i].Token1D_AttrTwo, peoples[j].Token1D_AttrTwo)));
                        dontMy2d.Add(new Point(peoples[i].HumanId, (int)bmpService.HD(peoples[i].Token2D_AttrOne, peoples[j].Token2D_AttrOne) +
                            (int)bmpService.HD(peoples[i].Token2D_AttrTwo, peoples[j].Token2D_AttrTwo)));
                    }
                }
            }

            graphService.addLine("1d their", my1d.ToArray(), Color.Red);
            graphService.addLine("1d zhuchie", dontMy1d.ToArray(), Color.Blue);

            graphService.addLine("2d their", my2d.ToArray(), Color.Green);
            graphService.addLine("2d zhuchie", dontMy2d.ToArray(), Color.Black);
        }

    }
}

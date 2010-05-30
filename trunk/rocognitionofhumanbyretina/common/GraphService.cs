using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ZedGraph;

namespace rocognitionofhumanbyretina.common
{
    class GraphService
    {
        private List<LineItem> linesList = new List<LineItem>();

        public void addLine(String lineName, PointD[] points, Color color)
        {
            PointPairList list = new PointPairList();

            // Заполняем список точек
            foreach (PointD p in points)
            {
                // добавим в список точку
                list.Add(p.X,p.Y);
            }

            LineItem line = new LineItem(lineName, list, color, SymbolType.None);
            //line.Line.Fill = new Fill(Color.White, color, 45F);
            linesList.Add(line);
        }

        public List<LineItem> LinesList
        {
            get
            {
                return linesList;
            }
        }
    }
}

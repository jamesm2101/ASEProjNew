using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEProjNew
{
    class Canvas
    {
        Graphics g;
        Pen pen;
        int xAxis;
        int yAxis;

        public Canvas(Graphics g)
        {
            this.g = g;
            xAxis = yAxis = 0;
            pen = new Pen(Color.Blue, 1);
        }

        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(pen,xAxis,yAxis,toX,toY);
            xAxis = toX; 
            yAxis = toY;
        }

        public void DrawSquare(int width)
        {
            g.DrawRectangle(pen,xAxis,yAxis,xAxis + width, yAxis + width);
        }
    }

    
}

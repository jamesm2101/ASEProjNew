using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEProjNew
{
    public class Canvas
    {
        Graphics g, cursorg;
        Pen pen;
        int xAxis;
        int yAxis;
        public int xPos, yPos;
        protected Color color = Color.DarkGray;

        public bool fill = false;

        const int xsize = 400;
        const int ysize = 400;

        Form callingform;
        
        Point penPosition = new Point(10,10);
        Color pencolour;

        public Canvas()
        {
            xAxis = xsize;
            yAxis = ysize;
        }
        public Canvas(Form CallingForm, Graphics gin, Graphics cursorg)
        {
            this.g = gin;
            this.cursorg = cursorg;
            xAxis = xsize;
            yAxis = ysize;
            xPos = yPos = 0;
            pen = new Pen(Color.Blue, 3);
            this.callingform = CallingForm;
        }

        public Canvas(Form CallingForm, Graphics gin, int xAxis, int yAxis)
        {
            this.g = gin;
            xAxis = xsize;
            yAxis = ysize;
            xPos = yPos = 0;
            pen = new Pen(Color.Blue, 3);
            this.callingform = CallingForm;
        }

        public int XPos
        {
            get
            {
                return xPos;
            }
        }

        public int YPos
        {
            get
            {
                return yPos;
            }
        }

        public void UpdateCursor()
        {
            cursorg.Clear(Color.Transparent);
            Pen p = new Pen(Color.Blue, 3);
            cursorg.DrawEllipse(p, xAxis, yAxis, 4, 4);
            callingform.Refresh();
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

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
            pen = new Pen(Color.Blue, 2);
            this.callingform = CallingForm;
        }

        public Canvas(Form CallingForm, Graphics gin, int xsize, int ysize)
        {
            this.g = gin;
            xAxis = xsize;
            yAxis = ysize;
            xPos = yPos = 0;
            pen = new Pen(Color.Blue, 2);
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
            cursorg.DrawRectangle(p, xPos, yPos, 2, 2);
            callingform.Refresh();
        }

        public void moveto(int x, int y)
        {
            penPosition = new Point(x, y);
            if (x < 0 || x > xAxis || y < 0 || y > yAxis)
                throw new Exception("Cannot use moveto to that position");
            xPos = x;
            yPos = y;
        }
        public void drawto(int toX, int toY)
        {
            if (toX < 0 || toX > xAxis || toY < 0 || toY > yAxis)
                throw new Exception("Cannot use drawto method to that coordinate");
            if (g != null)
            {
                g.DrawLine(pen, xPos, yPos, toX, toY);
            }

            xPos = toX;
            yPos = toY;
        }

        public void DrawSquare(int width)
        {
            g.DrawRectangle(pen,xAxis,yAxis,xAxis + width, yAxis + width);
        }

        public void ShapeFill(string input)
        {
            if (input.Equals("on") == true)
            {
                fill = true;
            }
            else if (input.Equals("off") == true)
            {
                fill = false;
            }
            else
                throw new Exception("Enter on or off after fill command");
        }

        public void ColourRedPen()
        {
            pen = new Pen(Color.Red, 3);
        }

        public void ColourGreenPen()
        {
            pen = new Pen(Color.Green, 3);
        }

        public void ColourBluePen()
        {
            pen = new Pen(Color.Blue, 3);
        }

        public void ColourBlackPen()
        {
            pen = new Pen(Color.Black, 3);
        }

        public void Reset()
        {
            xPos = 0; yPos = 0;
        }

        public void Clear()
        {
            g.Clear(color);
        }

        public void SetColour(int red, int green, int blue)
        {
            if (red > 255 || green > 255 || blue > 255)
                throw new Exception("Enter valid RGB numbers ranging from 0 to 255");
            pencolour = Color.FromArgb(red, green, blue);
            pen = new Pen(pencolour, 3);
        }

        public void DrawCircle (int radius)
        {
            if (radius < 0) throw new Exception("Please enter a valid radius");

            g.DrawEllipse(pen, xPos - radius, yPos - radius, radius*2, radius*2);
        }

        public void DrawRectangle (int  width, int height)
        {
            if (width < 0 || height < 0) throw new Exception("Please enter a valid width or height");

            g.DrawRectangle(pen, xPos - width/2, yPos - height/2, width, height);
        }

    }

    
}

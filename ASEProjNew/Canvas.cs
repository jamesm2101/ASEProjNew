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


        //Size of the canvas based on the graphics area
        const int xsize = 400;
        const int ysize = 400;

        Form callingform;
        
        //Pen position and colour are set
        Point penPosition = new Point(10,10);
        Color pencolour = Color.Blue;


        public Canvas()
        {
            xAxis = xsize;
            yAxis = ysize;
        }

        /// <summary>
        /// Calling form for creating the set cursor
        /// </summary>
        /// <param name="CallingForm"></param>
        /// <param name="gin"></param>
        /// <param name="cursorg"></param>
        public Canvas(Form CallingForm, Graphics gin, Graphics cursorg)
        {
            this.g = gin;
            this.cursorg = cursorg;
            xAxis = xsize;
            yAxis = ysize;
            xPos = yPos = 0;
            pen = new Pen(pencolour, 2);
            this.callingform = CallingForm;
        }

        /// <summary>
        /// Calling form for creating a set size of canvas
        /// </summary>
        /// <param name="CallingForm"></param>
        /// <param name="gin"></param>
        /// <param name="xsize"></param>
        /// <param name="ysize"></param>
        public Canvas(Form CallingForm, Graphics gin, int xsize, int ysize)
        {
            this.g = gin;
            xAxis = xsize;
            yAxis = ysize;
            xPos = yPos = 0;
            pen = new Pen(pencolour, 2);
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

        /// <summary>
        /// Updating cursor when moved or recoloured
        /// </summary>
        public void UpdateCursor()
        {
            cursorg.Clear(Color.Transparent);
            Pen p = new Pen(pencolour, 3);
            cursorg.DrawRectangle(p, xPos, yPos, 2, 2);
            callingform.Refresh();
        }

        /// <summary>
        /// Method to move the cursor to a set dimension
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <exception cref="Exception"></exception>
        public void moveto(int x, int y)
        {
            penPosition = new Point(x, y);
            //x and y values must fit within the axis
            if (x < 0 || x > xAxis || y < 0 || y > yAxis)
                throw new Exception("Cannot use moveto to that position");
            //x and y values given a variable name for future use
            xPos = x;
            yPos = y;
        }
        public void drawto(int toX, int toY)
        {
            //x and y values must fit within the axis
            if (toX < 0 || toX > xAxis || toY < 0 || toY > yAxis)
                throw new Exception("Cannot use drawto method to that coordinate");

            //Draw the line from current to new dimensions
            if (g != null)
            {
                g.DrawLine(pen, xPos, yPos, toX, toY);
            }

            //New dimensions set for the positioning of x and y
            xPos = toX;
            yPos = toY;
        }

        /// <summary>
        /// Draw square method (not working)
        /// </summary>
        /// <param name="width"></param>
        public void DrawSquare(int width)
        {
            g.DrawRectangle(pen,xAxis,yAxis,xAxis + width, yAxis + width);
        }

        /// <summary>
        /// Change the pen colour to red
        /// </summary>
        public void ColourRedPen()
        {
            pencolour = Color.Red;
            pen = new Pen(pencolour, 3);
        }

        /// <summary>
        /// Change pen colour to green
        /// </summary>
        public void ColourGreenPen()
        {
            pencolour = Color.Green;
            pen = new Pen(pencolour, 3);
        }

        /// <summary>
        /// Change pen colour to blue
        /// </summary>
        public void ColourBluePen()
        {
            pencolour = Color.Blue;
            pen = new Pen(pencolour, 3);
        }

        /// <summary>
        /// Change pen colour to black
        /// </summary>
        public void ColourBlackPen()
        {
            pencolour = Color.Black;
            pen = new Pen(pencolour, 3);
        }

        /// <summary>
        /// Reset the cursor to its original position
        /// </summary>
        public void Reset()
        {
            xPos = 0; yPos = 0;
        }

        /// <summary>
        /// Clear the graphics area
        /// </summary>
        public void Clear()
        {
            g.Clear(color);
        }

        /// <summary>
        /// Ability to use RGB to change to a set colour
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <exception cref="Exception"></exception>
        public void SetColour(int red, int green, int blue)
        {
            ///Values of RGB must be below 255
            if (red > 255 || green > 255 || blue > 255)
                throw new Exception("Enter valid RGB numbers ranging from 0 to 255");
            pencolour = Color.FromArgb(red, green, blue);
            pen = new Pen(pencolour, 3);
        }

        /// <summary>
        /// Method to change the fill setting depending on user input
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Method to draw a circle around the dimensions of the cursor
        /// </summary>
        /// <param name="radius"></param>
        /// <exception cref="Exception"></exception>
        public void DrawCircle (int radius)
        {
            //Radius must not be negative
            if (radius < 0) throw new Exception("Please enter a valid radius");

            g.DrawEllipse(pen, xPos - radius, yPos - radius, radius*2, radius*2);

            //Fill the circle if the setting is on
            if (fill == true)
            {
                g.FillEllipse(pen.Brush, xPos - radius, yPos - radius, radius*2, radius*2);
            }
        }

        /// <summary>
        /// Method to draw a rectangle around the dimensions of the cursor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <exception cref="Exception"></exception>
        public void DrawRectangle (int  width, int height)
        {
            //Width and height must be above 0
            if (width < 0 || height < 0) throw new Exception("Please enter a valid width or height");

            g.DrawRectangle(pen, xPos - width/2, yPos - height/2, width, height);

            //Fill the rectangle if the setting is on
            if (fill == true)
            {
                g.FillRectangle(pen.Brush, xPos - width / 2, yPos - height / 2, width, height);
            }
        }

        /// <summary>
        /// Method to draw a triangle around the dimensions of the cursor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <exception cref="Exception"></exception>
        public void DrawTriangle (int width, int height)
        {
            // Width and Height must be above 0
            if (width < 0 || height < 0) throw new Exception("Please enter new width or height for the triangle");

            //Three points are created
            Point point1 = new Point(xPos + width / 2, yPos + height / 2);
            Point point2 = new Point(xPos, yPos - height / 2);
            Point point3 = new Point(xPos - width / 2, yPos + height / 2);

            //Three points connected together
            Point[] triPoints = { point1, point2, point3};
            g.DrawPolygon(pen, triPoints);
            
            //Fill the triangle if the setting is on
            if (fill == true)
            {
                g.FillPolygon(pen.Brush, triPoints);
            }
        }
    }

    
}

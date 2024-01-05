using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEProjNew
{
    public class Rectangle:Shape
    {
        int width;
        int height;
        public Rectangle(int x, int y, int width, int height) : base(x, y)
        {
            this.width = width;
            this.height = height;
        }

        public override void draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 2);
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawRectangle(pen, x, y, width, height);
            //g.FillRectangle(brush, x, y, width, height);
            //throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ASEProjNew
{
    public class Circle : Shape
    {
        int radius;

        public Circle(int x, int y, int radius) : base(x, y)
        {
            this.radius = radius;
        }

        public override void draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 2);
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawEllipse(pen, x, y, radius, radius);
            g.FillEllipse(brush, new Rectangle(x, y, radius, radius));

        }
    }
}

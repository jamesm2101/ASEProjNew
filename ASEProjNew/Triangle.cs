using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ASEProjNew
{
    public class Triangle
    {
        public void DrawPolygonPoint(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 4);

            Point point1 = new Point(Parameter1, Parameter2);
            Point point2 = new Point(Parameter3, Parameter4);
            Point point3 = new Point(Parameter5, Parameter6);

            Point[] curvePoints = { point1, point2, point3 };

            e.Graphics.DrawPolygon(pen, curvePoints);
        }
    }

    
}

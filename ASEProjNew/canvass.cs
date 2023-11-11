using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEProjNew
{
    internal class canvass:Form1
    {
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Red, 2);
            g.DrawLine(p, 0, 0, 1, 1);
        }

    }
}

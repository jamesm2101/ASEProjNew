using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEProjNew
{
    public abstract class Shape
    {
        protected int x, y;

        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public abstract void draw(Graphics g);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class Shape
    {
        protected int Sides { get; set; }
    }

    public class Square : Shape
    {
        public int GetSides()
        {
            return this.Sides;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    [Serializable]
    public class Circle : Shape
    {
        public double Radius { set; get; }

        public double PI = 3.14;
        public override string Color { get => base.Color; set => base.Color = value; }
        public override double Area => PI * Radius * Radius;
        public override string Name => GetType().Name;
    }
}

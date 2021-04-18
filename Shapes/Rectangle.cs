using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    [Serializable]
    public class Rectangle : Shape
    {
        public double Height { set; get; }
        public double Width { set; get; }

        public override string Color { get => base.Color; set => base.Color = value; }
        public override string Name => GetType().Name;
        public override double Area => Height * Width;
    }
}

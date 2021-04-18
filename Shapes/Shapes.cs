using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Shapes
{
    [Serializable]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Circle))]
    public class Shape
    {
        [XmlElement]
        public virtual string Name { get; }
        [XmlElement]
        public virtual double Area { get; }
        [XmlElement]
        public virtual string Color { get; set; }
    }
}

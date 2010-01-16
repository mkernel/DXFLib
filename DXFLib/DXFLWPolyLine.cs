using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [Entity("LWPOLYLINE")]
    public class DXFLWPolyLine : DXFEntity
    {
        public int VertexCount { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            closed = 1,
            plinegen = 128
        }

        public FlagsEnum Flags { get; set; }

        public double? ConstantWidth { get; set; }
        public double Elevation { get; set; }
        public double Thickness { get; set; }

        public class Element
        {
            private DXFPoint vertex = new DXFPoint();
            public DXFPoint Vertex { get { return vertex; } }
            public double StartWidth { get; set; }
            public double EndWidth { get; set; }
            public double Bulge { get; set; }
        }

        private List<Element> elements = new List<Element>();
        public List<Element> Elements { get { return elements; } }

        private Element LastElement
        {
            get
            {
                if (Elements.Count == 0)
                    return null;
                return Elements[Elements.Count - 1];
            }
            set
            {
                Elements.Add(value);
            }
        }

        private DXFPoint extrusion = new DXFPoint();
        public DXFPoint ExtrusionDirection { get { return extrusion; } }

        public override void ParseGroupCode(int groupcode, string value)
        {
            base.ParseGroupCode(groupcode, value);
            switch (groupcode)
            {
                case 90:
                    VertexCount = int.Parse(value);
                    break;
                case 70:
                    Flags = (FlagsEnum)Enum.Parse(typeof(FlagsEnum), value);
                    break;
                case 43:
                    ConstantWidth = double.Parse(value);
                    break;
                case 38:
                    Elevation = double.Parse(value);
                    break;
                case 39:
                    Thickness = double.Parse(value);
                    break;
                case 10:
                    if (LastElement == null || LastElement.Vertex.X != null)
                        LastElement = new Element();
                    LastElement.Vertex.X = double.Parse(value);
                    break;
                case 20:
                    if (LastElement == null || LastElement.Vertex.Y != null)
                        LastElement = new Element();
                    LastElement.Vertex.Y = double.Parse(value);
                    break;
                case 40:
                    LastElement.StartWidth = double.Parse(value);
                    break;
                case 41:
                    LastElement.EndWidth = double.Parse(value);
                    break;
                case 42:
                    LastElement.Bulge = double.Parse(value);
                    break;
                case 210:
                    ExtrusionDirection.X = double.Parse(value);
                    break;
                case 220:
                    ExtrusionDirection.Y = double.Parse(value);
                    break;
                case 230:
                    ExtrusionDirection.Z = double.Parse(value);
                    break;
            }
        }
    }
}

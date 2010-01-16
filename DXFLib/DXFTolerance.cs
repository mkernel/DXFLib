using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [Entity("TOLERANCE")]
    public class DXFTolerance : DXFEntity
    {
        public string DimensionStyle { get; set; }
        private DXFPoint insertion = new DXFPoint();
        public DXFPoint InsertionPoint { get { return insertion; } }
        private DXFPoint extrusion = new DXFPoint();
        public DXFPoint ExtrusionDirection { get { return extrusion; } }
        private DXFPoint direction = new DXFPoint();
        public DXFPoint Direction { get { return direction; } }

        public override void ParseGroupCode(int groupcode, string value)
        {
            base.ParseGroupCode(groupcode, value);
            switch (groupcode)
            {
                case 3:
                    DimensionStyle = value;
                    break;
                case 10:
                    InsertionPoint.X = double.Parse(value);
                    break;
                case 20:
                    InsertionPoint.Y = double.Parse(value);
                    break;
                case 30:
                    InsertionPoint.Z = double.Parse(value);
                    break;
                case 11:
                    Direction.X = double.Parse(value);
                    break;
                case 21:
                    Direction.Y = double.Parse(value);
                    break;
                case 31:
                    Direction.Z = double.Parse(value);
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

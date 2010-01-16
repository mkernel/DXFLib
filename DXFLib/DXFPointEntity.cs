using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [Entity("POINT")]
    public class DXFPointEntity : DXFEntity
    {
        private DXFPoint location = new DXFPoint();
        public DXFPoint Location { get { return location; } }

        public double Thickness { get; set; }

        private DXFPoint extrusion = new DXFPoint();
        public DXFPoint ExtrusionDirection { get { return extrusion; } }

        public double XAxisAngle { get; set; }

        public override void ParseGroupCode(int groupcode, string value)
        {
            base.ParseGroupCode(groupcode, value);
            switch (groupcode)
            {
                case 10:
                    Location.X = double.Parse(value);
                    break;
                case 20:
                    Location.Y = double.Parse(value);
                    break;
                case 30:
                    Location.Z = double.Parse(value);
                    break;
                case 39:
                    Thickness = double.Parse(value);
                    break;
                case 50:
                    XAxisAngle = double.Parse(value);
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

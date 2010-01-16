using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [Entity("TRACE")]
    public class DXFTrace : DXFEntity
    {
        private DXFPoint extrusion = new DXFPoint();
        public DXFPoint ExtrusionDirection { get { return extrusion; } }
        private DXFPoint[] corners = new DXFPoint[] { new DXFPoint(), new DXFPoint(), new DXFPoint() };
        public DXFPoint[] Corners { get { return corners; } }

        public double Thickness { get; set; }

        public override void ParseGroupCode(int groupcode, string value)
        {
            base.ParseGroupCode(groupcode, value);
            if (groupcode >= 10 && groupcode <= 33)
            {
                int idx = groupcode % 10;
                int component = groupcode / 10;
                switch (component)
                {
                    case 1:
                        Corners[idx].X = double.Parse(value);
                        break;
                    case 2:
                        Corners[idx].Y = double.Parse(value);
                        break;
                    case 3:
                        Corners[idx].Z = double.Parse(value);
                        break;
                }
            }

            switch (groupcode)
            {
                case 39:
                    Thickness = double.Parse(value);
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

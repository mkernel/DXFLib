using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [Entity("RAY")]
    public class DXFRay : DXFEntity
    {
        private DXFPoint startpoint = new DXFPoint();
        public DXFPoint Start { get { return startpoint; } }

        private DXFPoint direction = new DXFPoint();
        public DXFPoint Direction { get { return direction; } }

        public override void ParseGroupCode(int groupcode, string value)
        {
            base.ParseGroupCode(groupcode, value);
            switch (groupcode)
            {
                case 10:
                    Start.X = double.Parse(value);
                    break;
                case 20:
                    Start.Y = double.Parse(value);
                    break;
                case 30:
                    Start.Z = double.Parse(value);
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
            }
        }
    }

    [Entity("XLINE")]
    public class DXFXLine : DXFRay
    {
    }
}

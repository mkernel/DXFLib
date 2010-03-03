using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [Entity("INSERT")]
    public class DXFInsert : DXFEntity
    {
        public string BlockName { get; set; }
        private DXFPoint insertionPoint = new DXFPoint();
        public DXFPoint InsertionPoint { get { return insertionPoint; } }
        private DXFPoint scaling = new DXFPoint();
        public DXFPoint Scaling { get { return scaling; } }
        public double? RotationAngle { get; set; }
        private DXFPoint extrusionDirection = new DXFPoint();
        public DXFPoint ExtrusionDirection { get { return extrusionDirection; } }

        public override void ParseGroupCode(int groupcode, string value)
        {
            base.ParseGroupCode(groupcode, value);
            switch (groupcode)
            {
                case 2:
                    BlockName = value;
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
                case 41:
                    Scaling.X = double.Parse(value);
                    break;
                case 42:
                    Scaling.Y = double.Parse(value);
                    break;
                case 43:
                    Scaling.Z = double.Parse(value);
                    break;
            }
        }
    }
}

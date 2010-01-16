using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    public class DXFViewRecord : DXFRecord
    {
        public string ViewPortName { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        private DXFPoint center = new DXFPoint();
        public DXFPoint Center { get { return center; } }
        private DXFPoint direction = new DXFPoint();
        public DXFPoint Direction { get { return direction; } }
        private DXFPoint target = new DXFPoint();
        public DXFPoint Target { get { return target; } }

        public double FrontClippingPlane { get; set; }
        public double BackClippingPlane { get; set; }
        public double TwistAngle { get; set; }
        public double LensLength { get; set; }
        public int ViewMode { get; set; }
    }

    class DXFViewRecordParser : DXFRecordParser
    {
        private DXFViewRecord _record;
        protected override DXFRecord currentRecord
        {
            get { return _record; }
        }

        protected override void createRecord(DXFDocument doc)
        {
            _record = new DXFViewRecord();
            doc.Tables.Views.Add(_record);
        }

        public override void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            base.ParseGroupCode(doc, groupcode, value);
            switch (groupcode)
            {
                case 2:
                    _record.ViewPortName = value;
                    break;
                case 40:
                    _record.Height = double.Parse(value);
                    break;
                case 41:
                    _record.Width = double.Parse(value);
                    break;
                case 10:
                    _record.Center.X = double.Parse(value);
                    break;
                case 20:
                    _record.Center.Y = double.Parse(value);
                    break;
                case 11:
                    _record.Direction.X = double.Parse(value);
                    break;
                case 21:
                    _record.Direction.Y = double.Parse(value);
                    break;
                case 31:
                    _record.Direction.Z = double.Parse(value);
                    break;
                case 12:
                    _record.Target.X = double.Parse(value);
                    break;
                case 22:
                    _record.Target.Y = double.Parse(value);
                    break;
                case 32:
                    _record.Target.Z = double.Parse(value);
                    break;
                case 42:
                    _record.LensLength = double.Parse(value);
                    break;
                case 43:
                    _record.FrontClippingPlane = double.Parse(value);
                    break;
                case 44:
                    _record.BackClippingPlane = double.Parse(value);
                    break;
                case 50:
                    _record.TwistAngle = double.Parse(value);
                    break;
                case 71:
                    _record.ViewMode = int.Parse(value);
                    break;
            }
        }
    }

}

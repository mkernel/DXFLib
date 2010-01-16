using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    public class DXFVPortRecord : DXFRecord
    {
        public string VPortName { get; set; }
        private DXFPoint lowerleft = new DXFPoint();
        public DXFPoint LowerLeftCorner { get { return lowerleft; } }
        private DXFPoint upperright = new DXFPoint();
        public DXFPoint UpperRightCorner { get { return upperright; } }
        private DXFPoint center = new DXFPoint();
        public DXFPoint Center { get { return center; } }
        private DXFPoint snapbase = new DXFPoint();
        public DXFPoint SnapBase { get { return snapbase; } }
        private DXFPoint snapspacing = new DXFPoint();
        public DXFPoint SnapSpacing { get { return snapspacing; } }
        private DXFPoint gridspacing = new DXFPoint();
        public DXFPoint GridSpacing { get { return gridspacing; } }
        private DXFPoint direction = new DXFPoint();
        public DXFPoint Direction { get { return direction; } }
        private DXFPoint target = new DXFPoint();
        public DXFPoint Target { get { return target; } }

        public double Height { get; set; }
        public double AspectRatio { get; set; }
        public double LensLength { get; set; }
        public double FrontClippingPlane { get; set; }
        public double BackClippingPlane { get; set; }
        public double SnapRotationAngle { get; set; }
        public double TwistAngle { get; set; }
        public int ViewMode { get; set; }
        public int CircleZoomPercent { get; set; }
        public int FastZoomSetting { get; set; }
        public int UCSICONSetting { get; set; }
        public int SnapEnabled { get; set; }
        public int GridEnabled { get; set; }
        public int SnapStyle { get; set; }
        public int SnapIsoPair { get; set; }

    }

    class DXFVPortRecordParser : DXFRecordParser
    {
        private DXFVPortRecord _record;
        protected override DXFRecord currentRecord
        {
            get { return _record; }
        }

        protected override void createRecord(DXFDocument doc)
        {
            _record = new DXFVPortRecord();
            doc.Tables.VPorts.Add(_record);
        }

        public override void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            base.ParseGroupCode(doc, groupcode, value);
            switch (groupcode)
            {
                case 2:
                    _record.VPortName = value;
                    break;
                case 10:
                    _record.LowerLeftCorner.X = double.Parse(value);
                    break;
                case 20:
                    _record.LowerLeftCorner.Y = double.Parse(value);
                    break;
                case 11:
                    _record.UpperRightCorner.X = double.Parse(value);
                    break;
                case 21:
                    _record.UpperRightCorner.Y = double.Parse(value);
                    break;
                case 12:
                    _record.Center.X = double.Parse(value);
                    break;
                case 22:
                    _record.Center.Y = double.Parse(value);
                    break;
                case 13:
                    _record.SnapBase.X = double.Parse(value);
                    break;
                case 23:
                    _record.SnapBase.Y = double.Parse(value);
                    break;
                case 14:
                    _record.SnapSpacing.X = double.Parse(value);
                    break;
                case 24:
                    _record.SnapSpacing.Y = double.Parse(value);
                    break;
                case 15:
                    _record.GridSpacing.X = double.Parse(value);
                    break;
                case 25:
                    _record.GridSpacing.Y = double.Parse(value);
                    break;
                case 16:
                    _record.Direction.X = double.Parse(value);
                    break;
                case 26:
                    _record.Direction.Y = double.Parse(value);
                    break;
                case 36:
                    _record.Direction.Z = double.Parse(value);
                    break;
                case 17:
                    _record.Target.X = double.Parse(value);
                    break;
                case 27:
                    _record.Target.Y = double.Parse(value);
                    break;
                case 37:
                    _record.Target.Z = double.Parse(value);
                    break;
                case 40:
                    _record.Height = double.Parse(value);
                    break;
                case 41:
                    _record.AspectRatio = double.Parse(value);
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
                    _record.SnapRotationAngle = double.Parse(value);
                    break;
                case 51:
                    _record.TwistAngle = double.Parse(value);
                    break;
                case 71:
                    _record.ViewMode = int.Parse(value);
                    break;
                case 72:
                    _record.CircleZoomPercent = int.Parse(value);
                    break;
                case 73:
                    _record.FastZoomSetting = int.Parse(value);
                    break;
                case 74:
                    _record.UCSICONSetting = int.Parse(value);
                    break;
                case 75:
                    _record.SnapEnabled = int.Parse(value);
                    break;
                case 76:
                    _record.GridEnabled = int.Parse(value);
                    break;
                case 77:
                    _record.SnapStyle = int.Parse(value);
                    break;
                case 78:
                    _record.SnapIsoPair = int.Parse(value);
                    break;
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    public class DXFUCSRecord : DXFRecord
    {
        public string UCSName { get; set; }
        private DXFPoint origin = new DXFPoint();
        public DXFPoint Origin { get { return origin; } }
        private DXFPoint xaxis=new DXFPoint();
        public DXFPoint XAxis { get { return xaxis; } }
        private DXFPoint yaxis = new DXFPoint();
        public DXFPoint YAxis { get { return yaxis; } }
    }

    class DXFUCSRecordParser : DXFRecordParser
    {
        private DXFUCSRecord _record;
        protected override DXFRecord currentRecord
        {
            get { return _record; }
        }

        protected override void createRecord(DXFDocument doc)
        {
            _record = new DXFUCSRecord();
            doc.Tables.UCS.Add(_record);
        }

        public override void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            base.ParseGroupCode(doc, groupcode, value);
            switch (groupcode)
            {
                case 2:
                    _record.UCSName = value;
                    break;
                case 10:
                    _record.Origin.X = double.Parse(value);
                    break;
                case 20:
                    _record.Origin.Y = double.Parse(value);
                    break;
                case 30:
                    _record.Origin.Z = double.Parse(value);
                    break;
                case 11:
                    _record.XAxis.X = double.Parse(value);
                    break;
                case 21:
                    _record.XAxis.Y = double.Parse(value);
                    break;
                case 31:
                    _record.XAxis.Z = double.Parse(value);
                    break;
                case 12:
                    _record.YAxis.X = double.Parse(value);
                    break;
                case 22:
                    _record.YAxis.Y = double.Parse(value);
                    break;
                case 32:
                    _record.YAxis.Z = double.Parse(value);
                    break;
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    public class DXFLineTypeRecord : DXFRecord
    {
        public string LineTypeName { get; set; }
        public string Description { get; set; }
        public int AlignmentCode { get; set; }

        [Flags]
        public enum ElementFlags
        {
            None=0,
            AbsoluteRotation=1,
            IsString=2,
            IsShape=4
        }

        public class LineTypeElement
        {
            public double Length { get; set; }
            public ElementFlags Flags { get; set; }
            public int? ShapeNumber { get; set; }
            public string Shape { get; set; }
            private List<double> scalings = new List<double>();
            public List<double> Scalings { get { return scalings; } }
            public double? Rotation { get; set; }
            private List<double> xoffsets = new List<double>();
            public List<double> XOffsets { get { return xoffsets; } }
            private List<double> yoffsets = new List<double>();
            public List<double> YOffsets { get { return yoffsets; } }

            public string Text { get; set; }
        }

        private List<LineTypeElement> elements = new List<LineTypeElement>();
        public List<LineTypeElement> Elements { get { return elements; } }
        public int ElementCount { get; set; }
        public double PatternLength { get; set; }
    }

    class DXFLineTypeRecordParser : DXFRecordParser
    {
        private DXFLineTypeRecord _record;
        private DXFLineTypeRecord.LineTypeElement _subrecord;

        protected override DXFRecord currentRecord
        {
            get { return _record; }
        }

        protected override void createRecord(DXFDocument doc)
        {
            _record = new DXFLineTypeRecord();
            doc.Tables.LineTypes.Add(_record);
        }

        public override void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            base.ParseGroupCode(doc, groupcode, value);
            switch (groupcode)
            {
                case 2:
                    _record.LineTypeName = value;
                    break;
                case 3:
                    _record.Description = value;
                    break;
                case 72:
                    _record.AlignmentCode = int.Parse(value);
                    break;
                case 73:
                    _record.ElementCount = int.Parse(value);
                    break;
                case 40:
                    _record.PatternLength = double.Parse(value);
                    break;
                case 49:
                    _subrecord = new DXFLineTypeRecord.LineTypeElement();
                    _record.Elements.Add(_subrecord);
                    _subrecord.Length = double.Parse(value);
                    break;
                case 74:
                    _subrecord.Flags = (DXFLineTypeRecord.ElementFlags)Enum.Parse(typeof(DXFLineTypeRecord.ElementFlags), value);
                    break;
                case 75:
                    _subrecord.ShapeNumber = int.Parse(value);
                    break;
                case 340:
                    _subrecord.Shape = value;
                    break;
                case 46:
                    _subrecord.Scalings.Add(double.Parse(value));
                    break;
                case 50:
                    _subrecord.Rotation = double.Parse(value);
                    break;
                case 44:
                    _subrecord.XOffsets.Add(double.Parse(value));
                    break;
                case 45:
                    _subrecord.YOffsets.Add(double.Parse(value));
                    break;
                case 9:
                    _subrecord.Text = value;
                    break;
            }
        }
    }

}

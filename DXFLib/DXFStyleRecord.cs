using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    public class DXFStyleRecord : DXFRecord
    {
        public string StyleName { get; set; }
        public double FixedHeight { get; set; }
        public double WidthFactor { get; set; }
        public double ObliqueAngle { get; set; }
        [Flags]
        public enum TextGenerationFlags
        {
            MirrorX=2,
            MirrorY=4
        }

        public TextGenerationFlags GenerationFlags { get; set; }

        public double LastUsedHeight { get; set; }
        public string FontFileName { get; set; }
        public string BigFontFileName { get; set; }
    }

    class DXFStyleRecordParser : DXFRecordParser
    {
        DXFStyleRecord _record;

        protected override DXFRecord currentRecord
        {
            get { return _record; }
        }

        protected override void createRecord(DXFDocument doc)
        {
            _record = new DXFStyleRecord();
            doc.Tables.Styles.Add(_record);
        }

        public override void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            base.ParseGroupCode(doc, groupcode, value);
            switch (groupcode)
            {
                case 2:
                    _record.StyleName = value;
                    break;
                case 40:
                    _record.FixedHeight = double.Parse(value);
                    break;
                case 41:
                    _record.WidthFactor = double.Parse(value);
                    break;
                case 50:
                    _record.ObliqueAngle = double.Parse(value);
                    break;
                case 71:
                    _record.GenerationFlags = (DXFStyleRecord.TextGenerationFlags)Enum.Parse(typeof(DXFStyleRecord.TextGenerationFlags), value);
                    break;
                case 42:
                    _record.LastUsedHeight = double.Parse(value);
                    break;
                case 3:
                    _record.FontFileName = value;
                    break;
                case 4:
                    _record.BigFontFileName = value;
                    break;
            }
        }
    }

}

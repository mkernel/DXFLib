using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    public class DXFLayerRecord : DXFRecord
    {
        public string LayerName { get; set; }
        public int Color { get; set; }
        public string LineType { get; set; }
    }

    class DXFLayerRecordParser : DXFRecordParser
    {
        private DXFLayerRecord _record;
        protected override DXFRecord currentRecord
        {
            get { return _record; }
        }

        protected override void createRecord(DXFDocument doc)
        {
            _record = new DXFLayerRecord();
            doc.Tables.Layers.Add(_record);
        }

        public override void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            base.ParseGroupCode(doc, groupcode, value);
            switch (groupcode)
            {
                case 2:
                    _record.LayerName = value;
                    break;
                case 62:
                    _record.Color = int.Parse(value);
                    break;
                case 6:
                    _record.LineType = value;
                    break;
            }
        }
    }



}

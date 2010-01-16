using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    public class DXFDimStyleRecord : DXFRecord
    {
        public string StyleName { get; set; }
        //TODO: weitere Felder unterstützen
    }

    class DXFDimStyleRecordParser : DXFRecordParser
    {
        private DXFDimStyleRecord _record;
        protected override DXFRecord currentRecord
        {
            get { return _record; }
        }

        protected override void createRecord(DXFDocument doc)
        {
            _record = new DXFDimStyleRecord();
            doc.Tables.DimStyles.Add(_record);
        }

        public override void ParseGroupCode(DXFDocument doc, int groupcode, string value)
        {
            base.ParseGroupCode(doc, groupcode, value);
            if (groupcode == 2)
                _record.StyleName = value;
        }
    }

}

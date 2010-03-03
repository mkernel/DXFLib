using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    public class DXFGenericEntity : DXFEntity
    {
        public class Entry
        {
            public int GroupCode { get; set; }
            public string Value { get; set; }
            public Entry()
            {
            }

            public Entry(int g, string v)
            {
                GroupCode = g;
                Value = v;
            }
        }

        private List<Entry> entries = new List<Entry>();
        public List<Entry> Entries { get { return entries; } }

        public override void ParseGroupCode(int groupcode, string value)
        {
            base.ParseGroupCode(groupcode, value);
            Entries.Add(new Entry(groupcode, value));
        }
    }

    [Entity("3DSOLID")]
    public class DXF3DSolid : DXFGenericEntity
    {
    }

    [Entity("ACAD_PROXY_ENTITY")]
    public class DXF3DAcadProxy : DXFGenericEntity
    {
    }

    [Entity("ATTDEF")]
    public class DXFAttributeDefinition : DXFGenericEntity
    {
    }

    [Entity("ATTRIB")]
    public class DXFAttribute : DXFGenericEntity
    {
    }

    [Entity("BODY")]
    public class DXFBody : DXFGenericEntity
    {
    }

    [Entity("DIMENSION")]
    public class DXFDimension : DXFGenericEntity
    {
    }

    [Entity("HATCH")]
    public class DXFHatch : DXFGenericEntity
    {
    }

    [Entity("IMAGE")]
    public class DXFImage : DXFGenericEntity
    {
    }

    [Entity("LEADER")]
    public class DXFLeader : DXFGenericEntity
    {
    }

    [Entity("MLINE")]
    public class DXFMLine : DXFGenericEntity
    {
    }

    [Entity("MTEXT")]
    public class DXFMText : DXFGenericEntity
    {
    }

    [Entity("OLEFRAME")]
    public class DXFOleFrame : DXFGenericEntity
    {
    }

    [Entity("OLE2FRAME")]
    public class DXFOle2Frame : DXFGenericEntity
    {
    }

    [Entity("REGION")]
    public class DXFRegion : DXFGenericEntity
    {
    }

    [Entity("TEXT")]
    public class DXFText : DXFGenericEntity
    {
    }

    [Entity("VIEWPORT")]
    public class DXFViewPort : DXFGenericEntity
    {
    }

}

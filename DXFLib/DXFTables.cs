using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    public class DXFTables
    {
        private List<DXFAppIDRecord> appids = new List<DXFAppIDRecord>();
        [Table("APPID",typeof(DXFAppIDParser))]
        public List<DXFAppIDRecord> AppIDs { get { return appids; } }

        private List<DXFBlockRecord> blocks = new List<DXFBlockRecord>();
        [Table("BLOCK_RECORD", typeof(DXFBlockRecordParser))]
        public List<DXFBlockRecord> Blocks { get { return blocks; } }

        private List<DXFDimStyleRecord> dimstyles = new List<DXFDimStyleRecord>();
        [Table("DIMSTYLE", typeof(DXFDimStyleRecordParser))]
        public List<DXFDimStyleRecord> DimStyles { get { return dimstyles; } }

        private List<DXFLayerRecord> layers = new List<DXFLayerRecord>();
        [Table("LAYER", typeof(DXFLayerRecordParser))]
        public List<DXFLayerRecord> Layers { get { return layers; } }

        private List<DXFLineTypeRecord> linetypes = new List<DXFLineTypeRecord>();
        [Table("LTYPE", typeof(DXFLineTypeRecordParser))]
        public List<DXFLineTypeRecord> LineTypes { get { return linetypes; } }

        private List<DXFStyleRecord> styles = new List<DXFStyleRecord>();
        [Table("STYLE", typeof(DXFStyleRecordParser))]
        public List<DXFStyleRecord> Styles { get { return styles; } }

        private List<DXFUCSRecord> ucs = new List<DXFUCSRecord>();
        [Table("UCS", typeof(DXFUCSRecordParser))]
        public List<DXFUCSRecord> UCS { get { return ucs; } }

        private List<DXFViewRecord> views = new List<DXFViewRecord>();
        [Table("VIEW", typeof(DXFViewRecordParser))]
        public List<DXFViewRecord> Views { get { return views; } }

        private List<DXFVPortRecord> vports = new List<DXFVPortRecord>();
        [Table("VPORT", typeof(DXFVPortRecordParser))]
        public List<DXFVPortRecord> VPorts { get { return vports; } }
    }
}

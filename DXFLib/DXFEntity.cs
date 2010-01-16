using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    public class DXFEntity
    {
        public string EntityType { get; set; }
        public string Handle { get; set; }
        private List<string> classhierarchy = new List<string>();
        public List<string> ClassHierarchy { get { return classhierarchy; } }
        public bool IsInPaperSpace { get; set; }
        public string LayerName { get; set; }
        public string LineType { get; set; }
        public int ColorNumber { get; set; }
        public double LineTypeScale { get; set; }
        public bool IsInvisible { get; set; }

        public virtual bool HasChildren { get { return false; } }
        private List<DXFEntity> children = new List<DXFEntity>();
        public List<DXFEntity> Children { get { return children; } }

        public virtual void ParseGroupCode(int groupcode, string value)
        {
            switch (groupcode)
            {
                case 0:
                    EntityType = value;
                    break;
                case 5:
                    Handle = value;
                    break;
                case 100:
                    ClassHierarchy.Add(value);
                    break;
                case 67:
                    IsInPaperSpace = int.Parse(value) == 1;
                    break;
                case 8:
                    LayerName = value;
                    break;
                case 6:
                    LineType = value;
                    break;
                case 62:
                    ColorNumber = int.Parse(value);
                    break;
                case 48:
                    LineTypeScale = double.Parse(value);
                    break;
                case 60:
                    IsInvisible = int.Parse(value) == 1;
                    break;
            }
        }
    }
}

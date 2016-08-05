using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [Entity("3DFACE")]
    public class DXF3DFace : DXFEntity
    {
        private DXFPoint[] corners = new DXFPoint[] { new DXFPoint(), new DXFPoint(), new DXFPoint() };
        public DXFPoint[] Corners { get { return corners; } }

        [Flags]
        public enum FlagsEnum
        {
            FirstEdgeInvisible = 1,
            SecondEdgeInvisible = 2,
            ThirdEdgeInvisible = 4,
            FourthEdgeInvisible = 8
        }

        public FlagsEnum Flags { get; set; }

        public override void ParseGroupCode(int groupcode, string value)
        {
            base.ParseGroupCode(groupcode, value);
            if (groupcode >= 10 && groupcode <= 33)
            {
                int idx = groupcode % 10;
                //check if we need to increase the corners array and if so, do so.
                if(idx >= corners.Length) {
                    int oldLength=corners.Length;
                    Array.Resize(ref corners, idx+1);
                    for(int i=oldLength-1;i<idx+1) {
                        corners[i]=new DXFPoint();
                    }
                }
                int component = groupcode / 10;
                switch (component)
                {
                    case 1:
                        Corners[idx].X = double.Parse(value);
                        break;
                    case 2:
                        Corners[idx].Y = double.Parse(value);
                        break;
                    case 3:
                        Corners[idx].Z = double.Parse(value);
                        break;
                }
            }
            else if (groupcode == 70)
            {
                Flags = (FlagsEnum)Enum.Parse(typeof(FlagsEnum), value);
            }
        }
    }
}

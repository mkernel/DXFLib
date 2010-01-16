using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [Entity("VERTEX")]
    public class DXFVertex : DXFEntity
    {
        private DXFPoint location = new DXFPoint();
        public DXFPoint Location { get { return location; } }
        public double StartWidth { get; set; }
        public double EndWidth { get; set; }
        public double Buldge { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            IsExtraVertex = 1,
            CurveFitTangentDefined = 2,
            NotUsed = 4,
            SplineVertexCreatedForSplineFitting = 8,
            SplineFrameControlPoint = 16,
            PolyLineVertex = 32,
            PolyLineMesh = 64,
            PolyFaceMesh = 128
        }

        public FlagsEnum Flags { get; set; }

        private int[] indices = { 0, 0, 0, 0 };
        public int[] PolyfaceIndices { get { return indices; } }

        public double CurveFitTangentDirection { get; set; }

        public override void ParseGroupCode(int groupcode, string value)
        {
            base.ParseGroupCode(groupcode, value);
            switch (groupcode)
            {
                case 10:
                    Location.X = double.Parse(value);
                    break;
                case 20:
                    Location.Y = double.Parse(value);
                    break;
                case 30:
                    Location.Z = double.Parse(value);
                    break;
                case 40:
                    StartWidth = double.Parse(value);
                    break;
                case 41:
                    EndWidth = double.Parse(value);
                    break;
                case 42:
                    Buldge = double.Parse(value);
                    break;
                case 70:
                    Flags = (FlagsEnum)Enum.Parse(typeof(FlagsEnum), value);
                    break;
                case 50:
                    CurveFitTangentDirection = double.Parse(value);
                    break;
                case 71:
                case 72:
                case 73:
                case 74:
                    {
                        int idx = groupcode % 10;
                        idx--;
                        PolyfaceIndices[idx] = int.Parse(value);
                    }
                    break;
            }
        }
    }
}

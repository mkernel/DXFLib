using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [Entity("POLYLINE")]
    public class DXFPolyLine : DXFEntity
    {
        public double Elevation { get; set; }
        public double Thickness { get; set; }
        [Flags]
        public enum FlagsEnum
        {
            closed = 1,
            CurveFitVerticesAdded = 2,
            SplineFitVerticesAdded = 4,
            Is3DPolyLine = 8,
            Is3DPolyMesh = 16,
            MeshIsClosed = 32,
            IsPolyFace = 64,
            LineTypePatternContinous = 128
        }

        public FlagsEnum Flags { get; set; }
        public double DefaultStartWidth { get; set; }
        public double DefaultEndWidth { get; set; }
        public int MVertexCount { get; set; }
        public int NVertexCount { get; set; }
        public int SurfaceMDensity { get; set; }
        public int SurfaceNDensity { get; set; }
        public int CurvesAndSmoothSurfaceType { get; set; }

        private DXFPoint extrusion = new DXFPoint();
        public DXFPoint ExtrusionDirection { get { return extrusion; } }

        public override bool HasChildren
        {
            get
            {
                return true;
            }
        }

        public override void ParseGroupCode(int groupcode, string value)
        {
            base.ParseGroupCode(groupcode, value);
            switch (groupcode)
            {
                case 30:
                    Elevation = double.Parse(value);
                    break;
                case 39:
                    Thickness = double.Parse(value);
                    break;
                case 70:
                    Flags = (FlagsEnum)Enum.Parse(typeof(FlagsEnum), value);
                    break;
                case 40:
                    DefaultStartWidth = double.Parse(value);
                    break;
                case 41:
                    DefaultEndWidth = double.Parse(value);
                    break;
                case 71:
                    MVertexCount = int.Parse(value);
                    break;
                case 72:
                    NVertexCount = int.Parse(value);
                    break;
                case 73:
                    SurfaceMDensity = int.Parse(value);
                    break;
                case 74:
                    SurfaceNDensity = int.Parse(value);
                    break;
                case 75:
                    CurvesAndSmoothSurfaceType = int.Parse(value);
                    break;
                case 210:
                    ExtrusionDirection.X = double.Parse(value);
                    break;
                case 220:
                    ExtrusionDirection.Y = double.Parse(value);
                    break;
                case 230:
                    ExtrusionDirection.Z = double.Parse(value);
                    break;
            }
        }
    }
}

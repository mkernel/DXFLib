using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    [Entity("SPLINE")]
    public class DXFSpline : DXFEntity
    {
        private DXFPoint normal = new DXFPoint();
        public DXFPoint Normal { get { return normal; } }

        [Flags]
        public enum FlagsEnum
        {
            Closed = 1,
            Periodic = 2,
            Rational = 4,
            Planar = 8,
            Linear = 16
        }
        public FlagsEnum Flags { get; set; }

        public int Degree { get; set; }
        public int KnotCount { get; set; }
        public int ControlPointCount { get; set; }
        public int FitPointCount { get; set; }

        public double KnotTolerance { get; set; }
        public double ControlPointTolerance { get; set; }
        public double FitPointTolerance { get; set; }

        private DXFPoint starttangent = new DXFPoint();
        public DXFPoint StartTangent { get { return starttangent; } }

        private DXFPoint endtangent = new DXFPoint();
        public DXFPoint EndTangent { get { return endtangent; } }

        private List<double> knotvalues = new List<double>();
        public List<double> KnotValues { get { return knotvalues; } }

        public double Weight { get; set; }

        private List<DXFPoint> controlpoints = new List<DXFPoint>();
        public List<DXFPoint> ControlPoints { get { return controlpoints; } }

        private List<DXFPoint> fitpoints = new List<DXFPoint>();
        public List<DXFPoint> FitPoints { get { return fitpoints; } }

        private DXFPoint LastControlPoint
        {
            get
            {
                if (ControlPoints.Count == 0) return null;
                return ControlPoints[ControlPoints.Count - 1];
            }
            set
            {
                ControlPoints.Add(value);
            }
        }

        private DXFPoint LastFitPoint
        {
            get
            {
                if (FitPoints.Count == 0) return null;
                return FitPoints[FitPoints.Count - 1];
            }
            set
            {
                FitPoints.Add(value);
            }
        }

        public override void ParseGroupCode(int groupcode, string value)
        {
            base.ParseGroupCode(groupcode, value);
            switch (groupcode)
            {
                case 210:
                    Normal.X = double.Parse(value);
                    break;
                case 220:
                    Normal.Y = double.Parse(value);
                    break;
                case 230:
                    Normal.Z = double.Parse(value);
                    break;
                case 70:
                    Flags = (FlagsEnum)Enum.Parse(typeof(FlagsEnum), value);
                    break;
                case 71:
                    Degree = int.Parse(value);
                    break;
                case 72:
                    KnotCount = int.Parse(value);
                    break;
                case 73:
                    ControlPointCount = int.Parse(value);
                    break;
                case 74:
                    FitPointCount = int.Parse(value);
                    break;
                case 42:
                    KnotTolerance = double.Parse(value);
                    break;
                case 43:
                    ControlPointTolerance = double.Parse(value);
                    break;
                case 44:
                    FitPointTolerance = double.Parse(value);
                    break;
                case 12:
                    StartTangent.X = double.Parse(value);
                    break;
                case 22:
                    StartTangent.Y = double.Parse(value);
                    break;
                case 32:
                    StartTangent.Z = double.Parse(value);
                    break;
                case 13:
                    EndTangent.X = double.Parse(value);
                    break;
                case 23:
                    EndTangent.Y = double.Parse(value);
                    break;
                case 33:
                    EndTangent.Z = double.Parse(value);
                    break;
                case 40:
                    KnotValues.Add(double.Parse(value));
                    break;
                case 41:
                    Weight = double.Parse(value);
                    break;
                case 10:
                    if (LastControlPoint==null || LastControlPoint.X != null)
                        LastControlPoint = new DXFPoint();
                    LastControlPoint.X = double.Parse(value);
                    break;
                case 20:
                    if (LastControlPoint == null || LastControlPoint.Y != null)
                        LastControlPoint = new DXFPoint();
                    LastControlPoint.Y = double.Parse(value);
                    break;
                case 30:
                    if (LastControlPoint == null || LastControlPoint.Z != null)
                        LastControlPoint = new DXFPoint();
                    LastControlPoint.Z = double.Parse(value);
                    break;
                case 11:
                    if (LastFitPoint == null || LastFitPoint.X != null)
                        LastFitPoint = new DXFPoint();
                    LastFitPoint.X = double.Parse(value);
                    break;
                case 21:
                    if (LastFitPoint == null || LastFitPoint.Y != null)
                        LastFitPoint = new DXFPoint();
                    LastFitPoint.Y = double.Parse(value);
                    break;
                case 31:
                    if (LastFitPoint == null || LastFitPoint.Z != null)
                        LastFitPoint = new DXFPoint();
                    LastFitPoint.Z = double.Parse(value);
                    break;
            }
        }
    }
}

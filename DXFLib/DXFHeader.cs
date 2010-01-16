using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXFLib
{
    public class DXFHeader
    {
        [Header("$ACADMAINTVER")]
        public int? MaintenanceVersionNumber { get; set; }

        [Header("$ACADVER")]
        public string AutoCADVersion { get; set; }

        [Header("$ANGBASE")]
        public double? AngleBase { get; set; }

        public enum Direction
        {
            CounterClockWise=0,
            ClockWise=1
        }

        [Header("$ANGDIR")]
        public Direction? AngleDirection { get; set; }

        [Header("$ATTDIA")]
        public bool? AttributeDialogs { get; set; }

        public enum AttribVisibility
        {
            None = 0,
            Normal = 1,
            All = 2
        }

        [Header("$ATTMODE")]
        public AttribVisibility? AttributeVisibility { get; set; }

        [Header("$ATTREQ")]
        public bool? RequestAttributesDuringInsert { get; set; }

        [Header("$AUINTS")]
        public int? AngleUnits { get; set; }

        [Header("$AUPREC")]
        public int? AngleUnitPrecision { get; set; }

        [Header("$BLIPMODE")]
        public int? BlipMode { get; set; }

        public enum ColorEntity
        {
            ByBlock = 0,
            ByLayer = 256
        }

        [Header("$CECOLOR")]
        public ColorEntity? CurrentEntityColor { get; set; }

        [Header("$CELTSCALE")]
        public double? CurrentEntityLinetypeScale { get; set; }

        [Header("$CELTYPE")]
        public string EntityLinetypeName { get; set; }

        [Header("$CHAMFERA")]
        public double? FirstChamferDistance { get; set; }

        [Header("$CHAMFERB")]
        public double? SecondChamferDistance { get; set; }

        [Header("$CHAMFERC")]
        public double? ChamferLength { get; set; }

        [Header("$CHAMFERD")]
        public double? ChamferAngle { get; set; }

        [Header("$CLAYER")]
        public string CurrentLayer { get; set; }

        public enum MultilineJustification
        {
            Top = 0,
            Middle = 1,
            Bottom = 2
        }

        [Header("$CMLJUST")]
        public MultilineJustification? CurrentMultilineJustification { get; set; }

        [Header("$CMLSCALE")]
        public double? CurrentMultilineScale { get; set; }

        [Header("$CMLSTYLE")]
        public string CurrentMultilineStyle { get; set; }

        public enum CoordinateDisplay
        {
            Static = 0,
            UpdateContinuous = 1,
            DLessAFormat = 2
        }

        [Header("$COORDS")]
        public CoordinateDisplay? CoordinateUpdateSetting { get; set; }

        public enum DeletePolicy
        {
            Deleted = 0,
            Retained = 1
        }

        [Header("$DELOBJ")]
        public DeletePolicy? DeletionPolicy { get; set; }

        [Header("$DIMALT")]
        public int? AlternateUnitConversionIfNonzero { get; set; }

        [Header("$DIMALTD")]
        public int? AlternateUnitDecimalPlaces { get; set; }

        [Header("$DIMALTF")]
        public double? AlternateUnitScaleFactor { get; set; }

        [Header("$DIMALTTD")]
        public int? AlternateUnitToleranceDecimals { get; set; }

        public enum SuppressionZeroPolicy
        {
            SuppressZeroFeetKeepInches = 0,
            IncludeZeroFeetKeepInchs = 1,
            IncludeZeroFeetSuppressInches = 2,
            IncludeZeroInchesSupressFeet = 3
        }

        [Header("$DIMALTTZ")]
        public SuppressionZeroPolicy? AlternateUnitSuppressionPolicyForTolerances { get; set; }

        public enum UnitType
        {
            Scientific = 1,
            Decimal = 2,
            Engineering = 3,
            ArchitecturalStacked = 4,
            FractionalStacked = 5,
            Architectural = 6,
            Fractional = 7
        }

        [Header("$DIMALTU")]
        public UnitType? AlternateUnitFormat { get; set; }

        [Header("$DIMALTZ")]
        public SuppressionZeroPolicy? ALternateUnitSuppressionPolicyForValues { get; set; }

        [Header("$DIMAPOST")]
        public string AlternateUnitSuffix { get; set; }

        public enum EntityGroupingPolicy
        {
            CreateAssociations = 1,
            DrawIndividual = 0
        }

        [Header("$DIMASO")]
        public EntityGroupingPolicy? EntityGrouping { get; set; }

        [Header("$DIMASZ")]
        public double? DimensioningArrowSize { get; set; }

        public enum Angletype
        {
            DecimalDegree = 0,
            DegreeMinutesSeconds = 1,
            Gradians = 2,
            Radians = 3,
            SurveyoursUnits = 4
        }

        [Header("$DIMAUNIT")]
        public Angletype? AlternateUnitAngleType { get; set; }

        [Header("$DIMBLK")]
        public string ArrowBlockName { get; set; }

        [Header("$DIMBLK1")]
        public string FirstArrowBlockName { get; set; }

        [Header("$DIMBLK2")]
        public string SecondArrowBlockName { get; set; }

        [Header("$DIMCEN")]
        public double? MarkLinesSizeCenter { get; set; }

        [Header("$DIMCLRD")]
        public int? DimensionLineColor { get; set; }

        [Header("$DIMCLRE")]
        public int? DimensionExtensionLineColor { get; set; }

        [Header("$DIMCLRT")]
        public string DimensionLineTextColor { get; set; }

        [Header("$DIMDEC")]
        public int? ToleranceDecimalsForPrimaryunit { get; set; }

        [Header("$DIMDLE")]
        public double? DimensionLineExtension { get; set; }

        [Header("$DIMDLI")]
        public double? DimensionLineIncrement { get; set; }

        [Header("$DIMEXE")]
        public double? ExtensionLineExtension { get; set; }

        [Header("$DIMEXO")]
        public double? ExtensionLineOffset { get; set; }

        [Header("$DIMFIT")]
        public int? TextAndArrowPlacement { get; set; }

        [Header("$DIMGAP")]
        public double? DimensionLineGap { get; set; }

        public enum TextPositionings
        {
            AboveDimensionLineAndCenterJustifiedBetweenExtensionLines = 0,
            AboveDimensionLineAndNextToFirstExtensionLine = 1,
            AboveDimensionLineAndNextToSecondExtensionLine = 2,
            AboveAndCenterJustifiedToFirstExtensionLine = 3,
            AboveAndCenterJustifiedToSecondExtensionLine = 4
        }

        [Header("$DIMJUST")]
        public TextPositionings? HorizontalTextPosition { get; set; }

        [Header("$DIMLFAC")]
        public double? LinearMeasurementScaleFactor { get; set; }

        [Header("$DIMLIM")]
        public int? DimensionLimitsIfNonZero { get; set; }

        [Header("$DIMPOST")]
        public string DimensionSuffix { get; set; }

        [Header("$DIMRND")]
        public double? DimensionDistanceRounding { get; set; }

        [Header("$DIMSAH")]
        public int? UseSeparateArrowsBlocksIfNonZero { get; set; }

        [Header("$DIMSCALE")]
        public double? DimensioningScale { get; set; }

        public enum SuppressionSettings
        {
            NotSuppressed = 0,
            Suppressed = 1
        }

        [Header("$DIMSD1")]
        public SuppressionSettings? SuppressionOfFirstExtensionLine { get; set; }

        [Header("$DIMSD2")]
        public SuppressionSettings? SuppressionOfSecondExtensionLine { get; set; }

        [Header("$DIMSE1")]
        public int? SuppressFirstExtensionLineIfNonZero { get; set; }

        [Header("$DIMSE2")]
        public int? SuppressSecondExtensionLineIfNonZero { get; set; }

        public enum DraggingPolicy
        {
            RecomputeDimensionsWhileDragging = 0,
            DragOriginalImage = 1
        }

        [Header("$DIMSHO")]
        public DraggingPolicy? DraggingSettings { get; set; }

        [Header("$DIMSOXD")]
        public int? SuppressOutsideExtensionLinesIfNonZero { get; set; }

        [Header("$DIMSTYLE")]
        public string DimensionStyleName { get; set; }

        [Header("$DIMTAD")]
        public int? TextAboveDimensionLineIfNonZero { get; set; }

        [Header("$DIMTDEC")]
        public int? NumberOfDimensionToleranceDecimals { get; set; }

        [Header("$DIMTFAC")]
        public double? DimensionToleranceScaleFactor { get; set; }

        [Header("$DIMTIH")]
        public int? TextInsideHorizontalIfNonZero { get; set; }

        [Header("$DIMTIX")]
        public int? ForceTextInsideExtensionsIfNonZero { get; set; }

        [Header("$DIMTM")]
        public double? MinusTolerance { get; set; }

        [Header("$DIMTOFL")]
        public int? IfTextOutsideExtensionsForceLineExtensionsBetweenExtensionsIfNonZero { get; set; }

        [Header("$DIMTOH")]
        public int? TextOutsideHorizontalIfNonZero { get; set; }

        [Header("$DIMTOL")]
        public int? DimensionTolerancesGeneratedIfNonZero { get; set; }

        [Header("$DIMTOLJ")]
        public MultilineJustification? ToleranceJustification { get; set; }

        [Header("$DIMTP")]
        public double? PlusTolerance { get; set; }

        [Header("$DIMTSZ")]
        public double? DimensioningTickSize { get; set; }

        [Header("$DIMTVP")]
        public double? TextVerticalPosition { get; set; }

        [Header("$DIMTXSTY")]
        public string DimensionTextStyle { get; set; }

        [Header("$DIMTXT")]
        public double? DimensionTextHeight { get; set; }

        [Header("$DIMTZIN")]
        public SuppressionZeroPolicy? SuppressionOfZerosForToleranceValues { get; set; }

        [Header("$DIMUNIT")]
        public UnitType? DimensionUnitType { get; set; }

        public enum CursorControl
        {
            OnlyDimensionLine = 0,
            TextAndDimensionLine = 1
        }

        [Header("$DIMUPT")]
        public CursorControl? CursorSetting { get; set; }

        [Header("$DIMZIN")]
        public SuppressionZeroPolicy? SuppressionOfZerosForPrimaryUnitValues { get; set; }

        public enum DisplaySilhouettePolicy
        {
            DontDraw = 0,
            Draw = 1
        }

        [Header("$DISPSILH")]
        public DisplaySilhouettePolicy? DisplaySilhoutteInGridMode { get; set; }

        public enum DraggingMode
        {
            off = 0,
            on = 1,
            auto = 2
        }

        [Header("$DRAGMODE")]
        public DraggingMode? DraggingEnabled { get; set; }

        [Header("$DWGCODEPAGE")]
        public string CodePage { get; set; }

        [Header("$ELEVATION")]
        public double? Elevation { get; set; }

        [Header("$EXTMAX")]
        public DXFPoint DrawingExtendsUpperRight { get; set; }

        [Header("$EXTMIN")]
        public DXFPoint DrawingExtendsLowerRight { get; set; }

        [Header("$FILLETRAD")]
        public double? FilletRadius { get; set; }

        [Header("$FILLMODE")]
        public int? FillModeIfNonZero { get; set; }

        [Header("$HANDLING")]
        public int? NextAvailableHandle { get; set; }

        [Header("$HANDSEED")]
        public string HandleSeed { get; set; }

        [Header("$INSBASE")]
        public DXFPoint InsertionBase { get; set; }

        [Header("$LIMCHECK")]
        public int? CheckLimitsIfNonZero { get; set; }

        [Header("$LIMMAX")]
        public DXFPoint LimitsUpperRight { get; set; }

        [Header("$LIMMIN")]
        public DXFPoint LimitsLowerLeft { get; set; }

        [Header("$LTSCALE")]
        public double? LineTypeScale { get; set; }

        [Header("$LUNITS")]
        public int? UnitsForCoordinatesAndDistances { get; set; }

        [Header("$LUPREC")]
        public int? UnitPrecisionForCoordinatesAndDistances { get; set; }

        [Header("$MAXACTVP")]
        public int MaximumNumberOfViewPorts { get; set; }

        public enum DrawingUnits
        {
            English = 0,
            Metric = 1
        }

        [Header("$MEASUREMENT")]
        public DrawingUnits? MeasurementUnits { get; set; }

        [Header("$MENU")]
        public string MenuFileName { get; set; }

        [Header("$MIRRTEXT")]
        public int? MirrorTextIfNonZero { get; set; }

        [Header("$ORTHOMODE")]
        public int? OrthogonalModeOnIfNonZero { get; set; }

        [Header("$OSMODE")]
        public int? RunningObjectSnapModes { get; set; }

        [Header("$PDMODE")]
        public int? PointDisplayMode { get; set; }

        [Header("$PDSIZE")]
        public double? PointDisplaySize { get; set; }

        [Header("$PELEVATION")]
        public double? PaperElevation { get; set; }

        [Header("$PEXTMAX")]
        public DXFPoint PaperExtensionUpperRight { get; set; }

        [Header("$PEXTMIN")]
        public DXFPoint PaperExtensionLowerLeft { get; set; }

        public enum SelectionPolicy
        {
            NoGroupingAtAll = 0,
            GroupSelection = 1,
            AssociativeHatchSelection = 2,
            Both = 3
        }

        [Header("$PICKSTYLE")]
        public SelectionPolicy? SelectionBehaviour { get; set; }

        [Header("$PINSBASE")]
        public DXFPoint PaperSpaceInsertionBase { get; set; }

        [Header("$PLIMCHECK")]
        public int? PaperSpaceLimitCheckingIfNonZero { get; set; }

        [Header("$PLIMMAX")]
        public DXFPoint PaperSpaceUpperRightLimit { get; set; }

        [Header("$PLIMMIN")]
        public DXFPoint PaperSpaceLowerLeftLimit { get; set; }

        public enum PolyLineGeneration
        {
            EachVertexADash = 0,
            ContinousPatternAroundVertices = 1
        }

        [Header("$PLINEGEN")]
        public PolyLineGeneration? PolyLineBehaviour { get; set; }

        [Header("$PLINEWID")]
        public double? PolyLineWidth { get; set; }

        [Header("$PROXYGRAPHICS")]
        public int? ProxyGraphics { get; set; }

        public enum LinetypeScaling
        {
            ViewportScaling = 0,
            NoScaling = 1
        }

        [Header("$PSLTSCALE")]
        public LinetypeScaling? PaperSpaceLinetypeScaling { get; set; }

        [Header("$PUCSNAME")]
        public string PaperSpaceUCSName { get; set; }

        [Header("$PUCSORG")]
        public DXFPoint PaperSpaceUCSOrigin { get; set; }

        [Header("$PUCSXDIR")]
        public DXFPoint PaperSpaceUCSXAxis { get; set; }

        [Header("$PUCSYDIR")]
        public DXFPoint PaperSpaceUCSYAxis { get; set; }

        [Header("$QTEXTMODE")]
        public int? QuickTextModeIfNonZero { get; set; }

        [Header("$REGENMODE")]
        public int? RegenAutoIfNonZero { get; set; }

        public enum ShadingOptions
        {
            ShadeFaces = 0,
            ShadeFacesHighlightEdgesInBlack = 1,
            DontFillFacesAndEdgesInEntityColor = 2,
            FacesInEntityColorEdgesInBlack = 3
        }

        [Header("$SHADEDGE")]
        public ShadingOptions? ShadingSettings { get; set; }

        [Header("$SHADEDIF")]
        public int? ShadingAmbientLight { get; set; }

        [Header("$SKETCHINC")]
        public double SketchRecordIncrement { get; set; }

        [Header("$SKPOLY")]
        public int? SketchLinesIfZeroPolylinesIfOne { get; set; }

        [Header("$SPLFRAME")]
        public int? DrawSplineControlPolygonIfOne { get; set; }

        [Header("$SPLINESEGS")]
        public int? NumberOfLineSegmentsPerSplinePatch { get; set; }

        [Header("$SPLINETYPE")]
        public int? SplineTypeForPEDITSpline { get; set; }

        [Header("$SURFTAB1")]
        public int? NumberOfMeshTabulationsInFirstDirection { get; set; }

        [Header("$SURFTAB2")]
        public int? NumberOfMeshTabulationsInSecondDirection { get; set; }

        [Header("$SURFTYPE")]
        public int? SurfaceTypeForPEDITSmooth { get; set; }

        [Header("$SURFU")]
        public int? SurfaceDensityForPEDITSmoothInM { get; set; }

        [Header("$SURFV")]
        public int? SurfaceDensityForPEDITSmoothInN { get; set; }

        [Header("$TDCREATE")]
        public double? CreationDate { get; set; }

        [Header("$TDINDWG")]
        public double? TotalEditingTime { get; set; }

        [Header("$TDUPDATE")]
        public double? UpdateDate { get; set; }

        [Header("$TDUSRTIMER")]
        public double? UserElapsedTimer { get; set; }

        [Header("$TEXTSIZE")]
        public double? DefaultTextSize { get; set; }

        [Header("$TEXTSTYLE")]
        public string DefaultTextStyle { get; set; }

        [Header("$THICKNESS")]
        public double? Thickness { get; set; }

        [Header("$TILEMODE")]
        public int? ReleaseCompatibilityTileModeIfOne { get; set; }

        [Header("$TRACEWID")]
        public double? TraceWidth { get; set; }

        [Header("$TREEDEPTH")]
        public int? MaximumDepthOfSpatialIndex { get; set; }

        [Header("$UCSNAME")]
        public string UCSName { get; set; }

        [Header("$UCSORG")]
        public DXFPoint UCSOrigin { get; set; }

        [Header("$UCSXDIR")]
        public DXFPoint UCSXAxis { get; set; }

        [Header("$UCSYDIR")]
        public DXFPoint UCSYAxis { get; set; }

        [Header("$UNITMODE")]
        public int? UnitMode { get; set; }

        [Header("$USERI1")]
        public int? UserInt1 { get; set; }

        [Header("$USERI2")]
        public int? UserInt2 { get; set; }

        [Header("$USERI3")]
        public int? UserInt3 { get; set; }

        [Header("$USERI4")]
        public int? UserInt4 { get; set; }

        [Header("$USERI5")]
        public int? UserInt5 { get; set; }

        [Header("$USERR1")]
        public double? UserReal1 { get; set; }

        [Header("$USERR2")]
        public double? UserReal2 { get; set; }

        [Header("$USERR3")]
        public double? UserReal3 { get; set; }

        [Header("$USERR4")]
        public double? UserReal4 { get; set; }

        [Header("$USERR5")]
        public double? UserReal5 { get; set; }

        [Header("$USRTIMER")]
        public int? UserTimerEnabledIfOne { get; set; }

        [Header("$VISRETAIN")]
        public int? RetainVisibleXRefDependendVisibilitySettingsIfOne { get; set; }

        [Header("$WORLDVIEW")]
        public int? SetUCSToWCSDuringVIEWIfOne { get; set; }

    }
}

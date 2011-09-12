using System;
#if useFullGeoAPI
using GeoAPI.Geometries;
#else
using ICoordinate = NetTopologySuite.Geometries.Coordinate;
using IEnvelope = NetTopologySuite.Geometries.Envelope;
using IGeometry = NetTopologySuite.Geometries.Geometry;
using IPoint = NetTopologySuite.Geometries.Point;
using ILineString = NetTopologySuite.Geometries.LineString;
using ILinearRing = NetTopologySuite.Geometries.LinearRing;
using IPolygon = NetTopologySuite.Geometries.Polygon;
using IGeometryCollection = NetTopologySuite.Geometries.GeometryCollection;
using IMultiPoint = NetTopologySuite.Geometries.MultiPoint;
using IMultiLineString = NetTopologySuite.Geometries.MultiLineString;
using IMultiPolygon = NetTopologySuite.Geometries.MultiPolygon;
using IGeometryFactory = NetTopologySuite.Geometries.GeometryFactory;
using IPrecisionModel = NetTopologySuite.Geometries.PrecisionModel;
#endif
using NetTopologySuite.Geometries;

namespace NetTopologySuite.Triangulate
{

    /// <summary>
    /// Models a constraint segment in a triangulation.
    /// A constraint segment is an oriented straight line segment between a start point
    /// and an end point.
    /// 
    /// @author David Skea
    /// @author Martin Davis
    ///
    public class Segment
    {
        private readonly LineSegment _ls;
        private Object _data;

        /// <summary> 
        /// Creates a new instance for the given ordinates.
        /// </summary>
        public Segment(double x1, double y1, double z1, double x2, double y2, double z2)
            :this(new Coordinate(x1, y1, z1), new Coordinate(x2, y2, z2))
        {
        }

        /// <summary> 
        /// Creates a new instance for the given ordinates,  with associated external data. 
        /// </summary>
        public Segment(double x1, double y1, double z1, double x2, double y2, double z2, Object data)
            : this(new Coordinate(x1, y1, z1), new Coordinate(x2, y2, z2), data)
        {
        }

        /// <summary> 
        /// Creates a new instance for the given points, with associated external data.
        /// </summary>
        /// <param name="p0">the start point</param>
        /// <param name="p1">the end point</param>
        /// <param name="data">an external data object</param>
        public Segment(ICoordinate p0, ICoordinate p1, Object data)
        {
            _ls = new LineSegment(p0, p1);
            _data = data;
        }

        /// <summary> 
        /// Creates a new instance for the given points.
        /// </summary>
        /// <param name="p0">the start point</param>
        /// <param name="p1">the end point</param>
        public Segment(ICoordinate p0, ICoordinate p1)
        {
            _ls = new LineSegment(p0, p1);
        }

        /// <summary>
        /// Gets the start coordinate of the segment
        /// </summary>
        /// <remarks>a Coordinate</remarks>
        public ICoordinate Start
        {
            get {return _ls.GetCoordinate(0);}
        }

        /// <summary>
        /// Gets the end coordinate of the segment
        /// </summary>
        /// <remarks>a Coordinate</remarks>
        public ICoordinate End
        {
            get {return _ls.GetCoordinate(1);}
        }

        /// <summary>
        /// Gets the start X ordinate of the segment
        /// </summary>
        /// <remarks>the X ordinate value</remarks>
        public double StartX
        {
            get
            {
                var p = _ls.GetCoordinate(0);
                return p.X;
            }
        }

        /// <summary>
        /// Gets the start Y ordinate of the segment
        /// </summary>
        /// <remarks>the Y ordinate value</remarks>
        public double StartY
        {
            get
            {
                var p = _ls.GetCoordinate(0);
                return p.Y;
            }
        }

        /// <summary>
        /// Gets the start Z ordinate of the segment
        /// </summary>
        /// <remarks>the Z ordinate value</remarks>
        public double StartZ
        {
            get
            {
                var p = _ls.GetCoordinate(0);
                return p.Z;
            }
        }

        /// <summary>
        /// Gets the end X ordinate of the segment
        /// </summary>
        /// <remarks>the X ordinate value</remarks>
        public double EndX
        {
            get
            {
                var p = _ls.GetCoordinate(1);
                return p.X;
            }
        }

        /// <summary>
        /// Gets the end Y ordinate of the segment
        /// </summary>
        /// <remarks>he Y ordinate value</remarks>
        public double EndY
        {
            get
            {
                var p = _ls.GetCoordinate(1);
                return p.Y;
            }
        }

        /// <summary>
        /// Gets the end Z ordinate of the segment
        /// </summary>
        /// <remarks>the Z ordinate value</remarks>
        public double EndZ
        {
            get
            {
                var p = _ls.GetCoordinate(1);
                return p.Z;
            }
        }

        /// <summary>
        /// Gets a <tt>LineSegment</tt> modelling this segment.
        /// </summary>
        /// <remarks>a LineSegment</remarks>
        public LineSegment LineSegment
        {
           get {return _ls;}
        }

        /// <summary>
        /// Gets or sets the external data associated with this segment
        /// </summary>
        /// <remarks>a data object</remarks>
        public Object Data
        {
            get {return _data;}
            set
            {
                _data = value;
            }
        }

        /// <summary>
        /// Determines whether two segments are topologically equal.
        /// I.e. equal up to orientation.
        /// </summary>
        /// <param name="s">a segment</param>
        /// <returns>true if the segments are topologically equal</returns>
        public bool EqualsTopologically(Segment s)
        {
            return _ls.EqualsTopologically(s.LineSegment);
        }

        /// <summary>
        /// Computes the intersection point between this segment and another one.
        /// </summary>
        /// <param name="s">a segment</param>
        /// <returns>the intersection point, or <code>null</code> if there is none</returns>
        public ICoordinate Intersection(Segment s)
        {
            return _ls.Intersection(s.LineSegment);
        }

        /// <summary>
        /// Computes a string representation of this segment.
        /// </summary>
        /// <returns>a string</returns>
        public override String ToString()
        {
            return _ls.ToString();
        }
    }
}
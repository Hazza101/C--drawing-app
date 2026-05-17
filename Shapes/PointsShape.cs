using GrafPack.Utils;
namespace GrafPack.Shapes
{
    public class PointsShape : Shape
    {
        
        public PointF[] points {get; set;}
        
        
        public PointsShape(PointF[] points)
        {
            this.points = points;
        }

        public override void Draw(Graphics g, object drawingObject)
        {
            Brush brush = drawingObject as Brush;
            foreach(PointF point in this.points)
            {
                g.FillRectangle(brush, point.X, point.Y, 1, 1);
            }
        }

        public override bool Contains(PointF point)
        {
            float xMax = this.points.Max(p => p.X);
            float yMax = this.points.Max(p => p.Y);

            float xMin = this.points.Min(p => p.X);
            float yMin = this.points.Min(p => p.Y);
            return point.X <= xMax && point.X >= xMin && point.Y <= yMax && point.Y >= yMin;
        }

        public override PointF GetCenter()
        {
            float centerX = this.points.Average(p => p.X);
            float centerY = this.points.Average(p => p.Y);

            return new PointF(centerX, centerY);
        }

        public override PointF GetNearestPoint(PointF point)
        {
            PointF nearestPoint = this.points[0];
            float minDistance = MathsOps.distanceSquared(point, nearestPoint);

            foreach(PointF pt in this.points)
            {
                float curDistance = MathsOps.distanceSquared(point, pt);
                if (curDistance < minDistance)
                {
                    minDistance = curDistance;
                    nearestPoint = pt;
                }
            }
            return nearestPoint;
        }
    }
}
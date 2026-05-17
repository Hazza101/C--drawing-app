using GrafPack.Utils;

namespace GrafPack.Shapes
{
    public class Polygon : Shape
    {
        public PointF[] points {get; set;}
        
        public Polygon(PointF[] points)
        {
            this.type = "&Polygon";
            this.drawType = "Pen";
            
            float centerX = points.Average(p => p.X);
            float centerY = points.Average(p => p.Y);
            PointF center = new PointF(centerX, centerY);



            this.points = points.OrderBy(p => Math.Atan2(p.Y - center.Y, p.X - center.X)).ToArray();

        }

        public override void Draw(Graphics g, Object drawingObject)
        {
            
            int numOfPoints = this.points.Count();
            Pen pen = drawingObject as Pen;
            for (int cur = 0; cur < numOfPoints; cur++)
            {
                int next = (cur + 1) % numOfPoints;
                
                g.DrawLine(
                    pen,
                    points[cur],
                    points[next]
                );
            }
        }
    
        
        
        
       
        public override bool Contains(PointF point)
        {
            int intersects = 0;
            int numOfPoints = this.points.Length;
            for (int i = 0; i < numOfPoints; i++)
            {
                PointF vertexOne = this.points[i];
                PointF vertextTwo = this.points[(i + 1) % numOfPoints]; 
                bool isBetweenYOfVertices = (vertexOne.Y > point.Y) != (vertextTwo.Y > point.Y);
                bool isOnStraightHorizontalEdge = vertexOne.Y == point.Y && vertextTwo.Y == point.Y;
                if ( isBetweenYOfVertices ) 
                {
                    float xInterceptOfRay = (point.Y - vertexOne.Y) * (vertextTwo.X - vertexOne.X) / (vertextTwo.Y - vertexOne.Y) + vertexOne.X;
                    bool isToTheRightOfRay = xInterceptOfRay > point.X;
                    
                    if ( isToTheRightOfRay )
                    {
                        intersects++;
                    }
                }
                else if ( isOnStraightHorizontalEdge )
                {
                    bool isOnEdge = (vertexOne.X <= point.X && vertextTwo.X >= point.X) || (vertexOne.X >= point.X && vertextTwo.X <= point.X);
                    if ( isOnEdge )
                    {
                        return true;
                    }
                }
            } 
            return intersects % 2 != 0;
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
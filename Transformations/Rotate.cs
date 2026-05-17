using GrafPack.Shapes;
using GrafPack.Utils;
namespace GrafPack.Transformations
{
    
    public static class Rotation
    {
        public static PointF Rotate(PointF point, float angle)
        {
            
            
            float[,] rotationArray = new float[2, 2]
            {
                {(float)Math.Cos(angle), (float)-Math.Sin(angle)},
                {(float)Math.Sin(angle), (float)Math.Cos(angle)}
            };

            
            Matrix2D rotation = new Matrix2D(rotationArray);
            return MatrixMultiplier.Multiplies(point, rotation);
        }

        public static PointF Rotate(PointF point, float angle, PointF pivot)
        {
            PointF translatedPoint = MatrixMultiplier.Subtract(point, pivot);

            PointF rotatedPoint = Rotate(translatedPoint, angle);
            
            return MatrixMultiplier.Add(rotatedPoint, pivot);
        }

        public static LargePoint Rotate(LargePoint point, float angle)
        {
            int size = point.size;
            PointF newPoint = Rotate(point.point, angle);
            return new LargePoint(newPoint, size);
        }

        public static LargePoint Rotate(LargePoint point, float angle, PointF pivot)
        {
            int size = point.size;
            

            PointF rotatedPoint = Rotate(point.point, angle, pivot);
            
            return new LargePoint( rotatedPoint );
        }

        public static void Rotate(Quadrilateral rectangle, float angle, PointF pivot)
        {
            Rotate(rectangle.polygon, angle, pivot);
        }

        public static void Rotate(Triangle rectangle, float angle, PointF pivot)
        {
            Rotate(rectangle.polygon, angle, pivot);
        }

        public static void Rotate(Square rectangle, float angle, PointF pivot)
        {
            Rotate(rectangle.polygon, angle, pivot);
        }

        public static void Rotate(Polygon polygon, float angle, PointF pivot)
        {
            PointF[] points = polygon.points;
            for (int i = 0; i < points.Count(); i++)
            {
                points[i] = Rotate(points[i], angle, pivot);

            }
        }

        public static void Rotate(PointsShape pointsShape, float angle, PointF pivot)
        {
            PointF[] points = pointsShape.points;
            for (int i = 0; i < points.Count(); i++)
            {
                points[i] = Rotate(points[i], angle, pivot);

            }
        }

        public static void Rotate(Circle circle, float angle, PointF pivot)
        {
            Rotate(circle.baseShape, angle, pivot);
        }

        public static void Rotate(Ellipse ellipse, float angle, PointF pivot)
        {
            Rotate(ellipse.baseShape, angle, pivot);
        }

        public static void Rotate(Shape shape, float angle, PointF pivot)
        {
            switch (shape)
            {
                case Polygon polygon:
                    Rotate(polygon, angle, pivot);
                    break;
                
                case Square square:
                    Rotate(square, angle, pivot);
                    break;
                
                case Triangle tri:
                    Rotate(tri, angle, pivot);
                    break;
                
                case Quadrilateral rect:
                    Rotate(rect, angle, pivot);
                    break;
                
                case Circle circle:
                    Rotate(circle, angle, pivot);
                    break;

                case Ellipse ellipse:
                    Rotate(ellipse, angle, pivot);
                    break;
                default:
                    break;
            }
            
            
        }
        
        
    }
    
}
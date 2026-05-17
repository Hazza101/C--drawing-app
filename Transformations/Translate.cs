using GrafPack.Utils;
using GrafPack.Shapes;

namespace GrafPack.Transformations
{
    
    public static class Translation
    {
        public static PointF Translate(PointF point, PointF origin, PointF target)
        {
            
            PointF offset = MatrixMultiplier.Subtract(point, origin);
            return MatrixMultiplier.Add(target, offset);
            
        }

        public static void Translate(Polygon polygon, PointF origin, PointF target)
        {
            PointF[] points = polygon.points;
            for (int i = 0; i < points.Count(); i++)
            {
                points[i] = Translate(points[i], origin, target);

            }
        }
    

        public static void Translate(Quadrilateral rectangle, PointF origin, PointF target)
        {
            Translate(rectangle.polygon, origin, target);
        }

        public static void Translate(Triangle rectangle, PointF origin, PointF target)
        {
            Translate(rectangle.polygon, origin, target);
        }

        public static void Translate(Square rectangle, PointF origin, PointF target)
        {
            Translate(rectangle.polygon, origin, target);
        }

        public static void Translate(PointsShape pointsShape, PointF origin, PointF target)
        {
            PointF[] points = pointsShape.points;
            for (int i = 0; i < points.Count(); i++)
            {
                points[i] = Translate(points[i], origin, target);

            }
        }

        public static void Translate(Circle circle, PointF origin, PointF target)
        {
            Translate(circle.baseShape, origin, target);
        }

        public static void Translate(Ellipse ellipse, PointF origin, PointF target)
        {
            Translate(ellipse.baseShape, origin, target);
        }

        

        public static void Translate(Shape shape, PointF origin, PointF target)
        {
            switch (shape)
            {
                case Polygon polygon:
                    Translate(polygon, origin, target);
                    break;
                
                case Square square:
                    Translate(square, origin, target);
                    break;
                
                case Triangle tri:
                    Translate(tri, origin, target);
                    break;
                
                case Quadrilateral rect:
                    Translate(rect, origin, target);
                    break;
                
                case Circle circle:
                    Translate(circle, origin, target);
                    break;

                case Ellipse ellipse:
                    Translate(ellipse, origin, target);
                    break;

                default:
                    break;
            }
            
            
        }


    }
}
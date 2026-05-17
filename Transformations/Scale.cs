using System.Windows.Forms.VisualStyles;
using GrafPack.Shapes;
using GrafPack.Utils;
namespace GrafPack.Transformations
{
    
    public static class Scaling
    {
        public static PointF Scale(PointF point, PointF scale)
        {
            
            PointF scaledPoint = new(
                point.X * scale.X,
                point.Y * scale.Y
            );

            return scaledPoint;
            
            
        }

        // add option for single float scale

        public static void Scale(PointF[] points, PointF scale, PointF hook)
        {
            for (int i = 0; i < points.Count(); i++)
            {
                PointF normalisedPoint = MatrixMultiplier.Subtract(points[i], hook);
                points[i] = MatrixMultiplier.Add(Scale(normalisedPoint, scale), hook);
            }
        }

        public static void Scale(Shape shape, PointF scale, PointF hook)
        {
            switch (shape)
            {
                case Polygon polygon:
                    Scale(polygon.points, scale, hook);
                    break;
                
                case Square square:
                    Scale(square.polygon.points, scale, hook);
                    break;
                
                case Triangle tri:
                    Scale(tri.polygon.points, scale, hook);
                    break;
                
                case Quadrilateral rect:
                    Scale(rect.polygon.points, scale, hook);
                    break;
                case Circle circle:
                    Scale(circle.baseShape.points, scale, hook);
                    break;

                case Ellipse ellipse:
                    Scale(ellipse.baseShape.points, scale, hook);
                    break;
                default:
                    break;
            }
            
            
        }

        

        public static void Scale(Quadrilateral rectangle, PointF scale)
        {
            Scale(rectangle.polygon, scale);
        }

        public static void Scale(Triangle rectangle, PointF scale)
        {
            Scale(rectangle.polygon, scale);
        }

        public static void Scale(Square rectangle, PointF scale)
        {
            Scale(rectangle.polygon, scale);
        }

        public static void Scale(Polygon polygon, PointF scale)
        {
            PointF[] points = polygon.points;
            for (int i = 0; i < points.Count(); i++)
            {
                points[i] = Scale(points[i], scale);

            }
        }

        public static void Scale(PointsShape pointsShape, PointF scale)
        {
            PointF[] points = pointsShape.points;
            for (int i = 0; i < points.Count(); i++)
            {
                points[i] = Scale(points[i], scale);

            }
        }

        public static void Scale(Circle circle, PointF scale)
        {
            Scale(circle.baseShape, scale);
        }

        public static void Scale(Ellipse ellipse, PointF scale)
        {
            Scale(ellipse.baseShape, scale);
        }

        public static void Scale(Shape shape, PointF scale)
        {
            switch (shape)
            {
                case Polygon polygon:
                    Scale(polygon, scale);
                    break;
                
                case Square square:
                    Scale(square, scale);
                    break;
                
                case Triangle tri:
                    Scale(tri, scale);
                    break;
                
                case Quadrilateral rect:
                    Scale(rect, scale);
                    break;
                case Circle circle:
                    Scale(circle, scale);
                    break;

                case Ellipse ellipse:
                    Scale(ellipse, scale);
                    break;
                default:
                    break;
            }
            
            
        }
        
        
    }
    
}
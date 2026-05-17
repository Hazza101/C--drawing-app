using System.CodeDom;
using System.Reflection;
using GrafPack.Shapes;
using GrafPack.Utils;

namespace GrafPack.Transformations
{
    
    
    public static class Reflection
    {
        //https://www.youtube.com/watch?v=SD_qew7vOtw&t=804s
        public static PointF Reflect(PointF point, Line line)
        {
            Dictionary<char, float> equation = line.GetEquation();
            float A = equation['A'];
            float B = equation['B'];
            
            PointF yTransform = new PointF(0, -B);
            
            PointF translatedPoint = MatrixMultiplier.Add(point, yTransform);

            float angle = (float)Math.Atan(A);
            float[,] negativeRotationArray = new float[2, 2]
            {
                {(float)Math.Cos(angle), (float)Math.Sin(angle)},
                {(float)-Math.Sin(angle), (float)Math.Cos(angle)}
            };

            
            Matrix2D negativeRotation = new Matrix2D(negativeRotationArray);
            PointF negativelyRotatedPoint = MatrixMultiplier.Multiplies(translatedPoint, negativeRotation);

            float[,] xAxisReflectionArray =
            {
                {1, 0},
                {0, -1},
            };
            Matrix2D xAxisReflection = new Matrix2D(xAxisReflectionArray);
            PointF reflectedPoint = MatrixMultiplier.Multiplies(negativelyRotatedPoint, xAxisReflection);

            float[,] rotationArray = new float[2, 2]
            {
                {(float)Math.Cos(angle), (float)-Math.Sin(angle)},
                {(float)Math.Sin(angle), (float)Math.Cos(angle)}
            };

            
            Matrix2D rotation = new Matrix2D(rotationArray);
            PointF rotatedPoint = MatrixMultiplier.Multiplies(reflectedPoint, rotation);

            yTransform = new PointF(0, B);

            
            
            return MatrixMultiplier.Add(rotatedPoint, yTransform);
        }


        public static LargePoint Reflect(LargePoint point, Line line)
        {
            int size = point.size;
            PointF newPoint = Reflect(point.point, line);
            return new LargePoint(newPoint, size);
        }
    
        
        public static void Reflect(Polygon polygon, Line line)
        {
            PointF[] points = polygon.points;
            for (int i = 0; i < points.Count(); i++)
            {
                points[i] = Reflect(points[i], line);

            }
        }
        
        
        public static void Reflect(Quadrilateral rectangle, Line line)
        {
            Reflect(rectangle.polygon, line);
        }

        public static void Reflect(Triangle rectangle, Line line)
        {
            Reflect(rectangle.polygon, line);
        }

        public static void Reflect(Square rectangle, Line line)
        {
            Reflect(rectangle.polygon, line);
        }

        public static void Reflect(PointsShape pointsShape, Line line)
        {
            PointF[] points = pointsShape.points;
            for (int i = 0; i < points.Count(); i++)
            {
                points[i] = Reflect(points[i], line);

            }
        }

        public static void Reflect(Circle circle, Line line)
        {
            Reflect(circle.baseShape, line);
        }

        public static void Reflect(Ellipse ellipse, Line line)
        {
            Reflect(ellipse.baseShape, line);
        }

        public static void Reflect(Shape shape, Line line)
        {
            switch (shape)
            {
                case Polygon polygon:
                    Reflect(polygon, line);
                    break;
                
                case Square square:
                    Reflect(square, line);
                    break;
                
                case Triangle tri:
                    Reflect(tri, line);
                    break;
                
                case Quadrilateral rect:
                    Reflect(rect, line);
                    break;
                case Circle circle:
                    Reflect(circle, line);
                    break;

                case Ellipse ellipse:
                    Reflect(ellipse, line);
                    break;

                default:
                    break;
            }
            
            
        }
    
    }
}
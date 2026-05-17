

namespace GrafPack.Shapes
{
    public class Circle : Shape
    {
        
        PointF center;
        float radius;
        public PointsShape baseShape {get; set;}
        public Circle(PointF one, PointF two)
        {
            this.type = "&Circle";
            this.drawType = "Brush";
            center = new PointF(one.X, one.Y);
            radius = (float)Math.Sqrt(Math.Pow(Math.Abs(one.X - two.X), 2)  + Math.Pow(Math.Abs(one.Y - two.Y), 2));

            float x = 0, y = this.radius;
            float d = 3 - 2 * this.radius;
            float xc = this.center.X, yc = this.center.Y;
            List<PointF> points = new List<PointF>();
            while (y >= x){
                points.Add(new PointF( x + xc, y + yc ));
                points.Add(new PointF( -x + xc, y + yc ));
                points.Add(new PointF( x + xc, -y + yc ));
                points.Add(new PointF( -x + xc, -y + yc ));
                points.Add(new PointF( y + xc, x + yc ));
                points.Add(new PointF( -y + xc, x + yc ));
                points.Add(new PointF( y + xc, -x + yc ));
                points.Add(new PointF( -y + xc, -x + yc ));

                if (d > 0){
                    y--;
                    d = d + 4 * (x - y) + 10;
                } else{
                    d = d + 4 * x + 6;
                }
                x++;
            }
            this.baseShape = new PointsShape(points.ToArray());



        }

        public override bool Contains(PointF point)
        {
            return this.baseShape.Contains(point);
        }

        public override PointF GetCenter()
        {
             return this.baseShape.GetCenter();
        }

        public override PointF GetNearestPoint(PointF point)
        {
            return this.baseShape.GetNearestPoint(point);
        }

        public override void Draw(Graphics g, Object drawingObject)
        {
         
            this.baseShape.Draw(g, drawingObject);
         
        }
    }
}
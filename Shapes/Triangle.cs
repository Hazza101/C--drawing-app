using System.ComponentModel.Design;

namespace GrafPack.Shapes
{
    public class Triangle : Shape
    {
        
        PointF one, two;
        PointF[] points;
        public Polygon polygon {get;}
        
        public Triangle(PointF one, PointF two)
        {
            this.type = "&Triangle";
            this.drawType = "Pen";
            List<PointF> points = new List<PointF>();
            if (one.X < two.X && one.Y < two.Y)
            {
                points.Add(new PointF(two.X, two.Y));
                points.Add(new PointF(one.X, two.Y));
                points.Add(new PointF((one.X + two.X) / 2, one.Y));
            } else if (one.X < two.X && one.Y > two.Y)
            {
                points.Add(new PointF(one.X, one.Y));
                points.Add(new PointF(two.X, one.Y));
                points.Add(new PointF((one.X + two.X) / 2, two.Y));
            } else if (one.X > two.X && one.Y < two.Y)
            {
                points.Add(new PointF(two.X, two.Y));
                points.Add(new PointF(one.X, two.Y));
                points.Add(new PointF((one.X + two.X) / 2, one.Y));
            } else {
                points.Add(new PointF(one.X, one.Y));
                points.Add(new PointF(two.X, one.Y));
                points.Add(new PointF((one.X + two.X) / 2, two.Y));
            }
            this.polygon = new Polygon(points.ToArray());
            this.points = points.ToArray();

        }

        public override void Draw(Graphics g, Object drawingObject)
        {
            this.polygon.Draw(g, drawingObject);
        }

        public override bool Contains(PointF point)
        {
            return this.polygon.Contains(point);
        }

        public override PointF GetCenter()
        {
            return this.polygon.GetCenter();
        }

        public override PointF GetNearestPoint(PointF point)
        {
            return this.polygon.GetNearestPoint(point);
        }
    }
}
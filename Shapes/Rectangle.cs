using System.ComponentModel.Design;

namespace GrafPack.Shapes
{
    public class Quadrilateral : Shape
    {   
        public PointF one {get;}
        public PointF two {get;}
        PointF[] points;
        public Polygon polygon {get;}
        public Quadrilateral(PointF one, PointF two)
        {
            this.type = "&Rectangle";
            this.drawType = "Pen";
            this.points =
            [
                new PointF(one.X, one.Y),
                new PointF(one.X, two.Y),
                new PointF(two.X, one.Y),
                new PointF(two.X, two.Y),
            ];
            this.one = new PointF(one.X, one.Y);
            this.two = new PointF(two.X, two.Y);
            this.polygon = new Polygon(this.points);
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
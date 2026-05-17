namespace GrafPack.Shapes
{
    public class Square : Shape
    {
        Point keyPt, oppPt;
        PointF[] points;
        public Polygon polygon {get;}
        public Square(PointF keyPt, PointF oppPt)   
        {
            this.type = "&Square";
            this.drawType = "Pen";
            List<PointF> points = new List<PointF>();
            double xDiff, yDiff, xMid, yMid;  

            xDiff = oppPt.X - keyPt.X;
            yDiff = oppPt.Y - keyPt.Y;
            xMid = (oppPt.X + keyPt.X) / 2;
            yMid = (oppPt.Y + keyPt.Y) / 2;

            points.Add(new PointF(keyPt.X, keyPt.Y));
            points.Add(new PointF((float)(xMid + yDiff / 2), (float)(yMid - xDiff / 2)));
            points.Add(new PointF(oppPt.X, oppPt.Y));
            points.Add(new PointF((float)(xMid - yDiff / 2), (float)(yMid + xDiff / 2)));

            this.polygon = new Polygon(points.ToArray());
            this.points = points.ToArray();
            
           

            
        }

       	public override void  Draw(Graphics g, Object drawingObject)
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
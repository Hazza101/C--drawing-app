namespace GrafPack.Shapes
{
    public class LargePoint
    {
        public PointF point {get;}
        public int size {get;}
        public LargePoint(PointF point, int size = 3)
        {
            this.point = point;
            this.size = size;
        }

        public void Draw(Graphics g, Brush brush)
        {
            float halfSize = size / 2;
            g.FillRectangle(brush, this.point.X - halfSize, this.point.Y - halfSize, this.size, this.size);

        }
    }
}
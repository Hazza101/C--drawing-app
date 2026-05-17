

namespace GrafPack.Transformations
{
    public class Line
    {
        PointF start, end;

        public static readonly Line Empty = new Line(PointF.Empty, PointF.Empty);
        
        public Line(PointF start, PointF end)
        {
            
            if (start.X > end.X)
            {
                this.end = new PointF(start.X, start.Y);
                this.start = new PointF(end.X, end.Y);
            } else
            {
                this.start = new PointF(start.X, start.Y);
                this.end = new PointF(end.X, end.Y);
            }
            
        }

        public void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, this.start, this.end);
        }

        // source https://bobobobo.wordpress.com/2008/01/07/solving-linear-equations-ax-by-c-0/
        
        public Dictionary<char, float> GetLinearEquation()
        {
            float A = this.start.Y - this.end.Y;
            float B = this.end.X - this.start.X;
            float C = this.start.X * this.end.Y - this.end.X * this.start.Y;
            Dictionary<char, float> equation = new Dictionary<char, float>
            {
                { 'A', A },
                { 'B', B },
                { 'C', C }
            };
            return equation;

            
            
        }

        public Dictionary<char, float> GetEquation()
        {
            float A = (this.end.Y - this.start.Y) / (this.end.X - this.start.X);
            float B = this.start.Y - this.start.X * A;
            Dictionary<char, float> equation = new Dictionary<char, float>
            {
                { 'A', A },
                { 'B', B },
            };
            return equation;

        }
    }
}
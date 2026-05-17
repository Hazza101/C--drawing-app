

using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

namespace GrafPack.Shapes
{
    public class Ellipse : Shape
    {
        
        PointF center;
        //float semiMajor, semiMinor;
        //int majorAxis;
        float rx, ry;

        public PointsShape baseShape {get; set;}
        
        
        public Ellipse(PointF one, PointF two)
        {
            
            this.type = "&Ellipse";
            this.drawType = "Brush";
            this.ry = (Math.Max(one.Y, two.Y) - Math.Min(one.Y, two.Y)) / 2;
            this.rx = (Math.Max(one.X, two.X) - Math.Min(one.X, two.X)) / 2;
            center = new PointF(
                (Math.Max(one.X, two.X) - Math.Min(one.X, two.X)) / 2 + Math.Min(one.X, two.X),
                (Math.Max(one.Y, two.Y) - Math.Min(one.Y, two.Y)) / 2 + Math.Min(one.Y, two.Y)
            );


            float x = 0;
            float y = this.ry;

            float d1 = (float) ((this.ry * this.ry) - (this.rx * this.rx * this.ry) + (0.25 * this.rx * this.rx));
            float dx = 2 * this.ry * this.ry * x;
            float dy = 2 * rx * rx * y;
            float xc = this.center.X, yc = this.center.Y;
            List<PointF> points = new List<PointF>();

            while (dx < dy)
            {
                points.Add(new PointF( x + xc, y + yc));
                points.Add(new PointF( -x + xc, y + yc));
                points.Add(new PointF( x + xc, -y + yc));
                points.Add(new PointF( -x + xc, -y + yc));

                if (d1 < 0)
                {
                    x += 1;
                    dx = dx + (2 * ry * ry);
                    d1 = d1 + dx + (ry * ry);

                } else
                {
                    x += 1;
                    y -= 1;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d1 = d1 + dx - dy + (ry * ry); 
                }

            }

            float d2 = (float) (Math.Pow(ry, 2) * Math.Pow(x + 0.5, 2) + Math.Pow(rx, 2) * Math.Pow(y -1, 2)) - (rx * rx * ry * ry);
            while (y >= 0)
            {
                points.Add(new PointF( x + xc, y + yc));
                points.Add(new PointF( -x + xc, y + yc));
                points.Add(new PointF( x + xc, -y + yc));
                points.Add(new PointF( -x + xc, -y + yc));

                if (d2 > 0)
                {
                    y -= 1;
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + (rx * rx) - dy;
                } else
                {
                    y -= 1;
                    x += 1;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + dx - dy + (rx * rx);
                }
            }

            this.baseShape = new PointsShape(points.ToArray());
            // MessageBox.Show(points.Count().ToString());
            

        }

        public override bool Contains(PointF point)
        {
            return this.baseShape.Contains(point);
        }

        public override PointF GetCenter()
        {
            return this.baseShape.GetCenter();
        }

        public override void Draw(Graphics g, Object drawingObject)
        {
            
            this.baseShape.Draw(g, drawingObject);
            
        }
    
        public override PointF GetNearestPoint(PointF point)
        {
            return this.baseShape.GetNearestPoint(point);
        }
    
    }
}
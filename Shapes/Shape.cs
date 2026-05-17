namespace GrafPack.Shapes
{
    abstract public class Shape
    {
        
        public Shape()   
        {            
        }
        public abstract void Draw(Graphics g, Object drawingObject);
        public abstract bool Contains(PointF point);
        public string type;
        public string drawType;
        public abstract PointF GetCenter();
        public abstract PointF GetNearestPoint(PointF point);

        
        
    }
}
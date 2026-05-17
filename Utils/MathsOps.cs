namespace GrafPack.Utils
{
    public static class MathsOps {
        
        public static float distanceSquared(PointF point1, PointF point2)
        {
            float dx = point1.X - point2.X;
            float dy = point1.Y - point2.Y;

            return dx * dx + dy * dy;
        }

    }
}
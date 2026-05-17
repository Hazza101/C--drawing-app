
using System.CodeDom;
using System.Numerics;

namespace GrafPack.Utils
{
    public static class MatrixMultiplier
    {
        
        public static PointF Add(PointF point1, PointF point2)
        {
            float xNew = point1.X + point2.X;
            float yNew = point1.Y + point2.Y;
            return new PointF(xNew, yNew);
        }

        public static PointF Subtract(PointF point1, PointF point2)
        {
            float xNew = point1.X - point2.X;
            float yNew = point1.Y - point2.Y;
            return new PointF(xNew, yNew);
        }
        
        public static PointF Multiplies(PointF point, Matrix2D matrix)
        {
            float X = point.X;
            float Y = point.Y;

            float xNew = matrix.GetElementAt(0, 0) * X + matrix.GetElementAt(0, 1) * Y;
            float yNew = matrix.GetElementAt(1, 0) * X + matrix.GetElementAt(1, 1) * Y;
            return new PointF(xNew, yNew);
        }
        
        public static Matrix2D Multiplies(Matrix2D first, Matrix2D second) 
        {
            
            int M1 = first.GetNumberOfRows();
            int M2 = second.GetNumberOfRows();
            int N1 = first.GetNumberOfCols();
            int N2 = second.GetNumberOfCols();

            if (N1 != M2) {
                throw new ArgumentException("Number of colums in A must equal number of rows in B");
            }
            
           
            float[,] result = new float[M1, N2];
            
            for (int rowNumber = 0; rowNumber < M1; rowNumber++) {
                float[] row = first.GetRow(rowNumber);
                for (int colNumber = 0; colNumber < N2; colNumber++) {
                    float[] col = second.GetColumn(colNumber);
                    
                    result[rowNumber, colNumber] = DotProduct(row, col);
                }
            }
            
            return new Matrix2D(result);
        }

        public static float DotProduct(float[] row, float[] col) {
            float result = 0;
            if (row.Length != col.Length) {
                throw new ArgumentException("Size of row must equal size of Column");
            }
            for (int i = 0; i < row.Length; i++) {
                result += row[i] * col[i];
            }
            return result;

        }
    }
}
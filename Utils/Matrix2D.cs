using System.Text;
namespace GrafPack.Utils
{
    public class Matrix2D {

        private float[,] foo;
        public Matrix2D(float[,] foo) {
            this.foo = foo;
        }

        public float GetElementAt(int A, int B)
        {
            return this.foo[A,B];
        }

        public int GetNumberOfRows() {
            return this.foo.GetLength(0);
        }

        public float[] GetRow(int rowNumber) {
            int rows = this.foo.GetLength(0);
            int cols = this.foo.GetLength(1);
            float[] desiredRow = new float[cols];
            for (int row = 0; row < rows; row++) {
                
                for (int col = 0; col < cols; col++) {
                    if (row == rowNumber) {
                        desiredRow[col] = this.foo[row, col];
                    }
                }
                

            }
            return desiredRow;
            
        }

        public float[] GetColumn(int colNumber) {
            int rows = this.foo.GetLength(0);
            int cols = this.foo.GetLength(1);
            float[] desiredCol = new float[rows];
            for (int row = 0; row < rows; row++) {
                
                for (int col = 0; col < cols; col++) {
                    if (col == colNumber) {
                        desiredCol[row] = this.foo[row, col];
                    }
                }
                

            }
            return desiredCol;
            
        }

        public int GetNumberOfCols() {
            return this.foo.GetLength(1);
        }

        public float[,] To2DArray() {
            return this.foo;
        }

        public void Print() {
            int rows = this.foo.GetLength(0);
            int cols = this.foo.GetLength(1);
            StringBuilder output = new StringBuilder();
            for (int row = 0; row < rows; row++) {
                
                for (int col = 0; col < cols; col++) {
                    output.Append($"{this.foo[row, col]} ");
                }
                output.Append("\n");
            }
            Console.WriteLine(output);
        }
    }
}


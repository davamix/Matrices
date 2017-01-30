using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrices
{
    public class Multiplication
    {
        public Multiplication()
        {
        }

        private void Multiply(int[,] m1, int[,] m2)
        {
            //if (AreCompatible(m1, m2))
                //GetValuesToMultiply
        }

        /// <summary>
        /// The number of columns of the first matrix must equal the number of rows of the second
        /// </summary>
        public bool AreCompatible(int[,] m1, int[,] m2)
        {
            var lengthM1 = m1.GetLength(1);
            var lengthM2 = m2.GetLength(0);

            return lengthM1 == lengthM2;
        }

        public int[,] GetValuesToMultiply(int[,] matrix, bool isFirstMatrix)
        {
            if (isFirstMatrix)
                return matrix;

            return GetValuesToMultiplyFromSecondMatrix(matrix);
        }

        private int[,] GetValuesToMultiplyFromSecondMatrix(int[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);

            var newMatrix = new int[columns, rows];

            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    newMatrix[r, c] = matrix[c, r];
                }
            }

            return newMatrix;
        }
    }
}

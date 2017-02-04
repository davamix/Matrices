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
            return;

            // Steps

            int[,] m1 = new int[,] { };
            int[,] m2 = new int[,] { };

            if (AreCompatible(m1, m2))
            {
                var transposeM2 = TransposeMatrix(m2);

                // TODO: Do the calculation for each array in the same dimension of the matrices
                var result = Multiply(m1, transposeM2);
            }
        }
        private int[,] Multiply(int[,] m1, int[,] m2)
        {
            var result = new int[,] { };

            var dimensions = m1.Rank;

            for (var d = 0; d < dimensions; d++)
            {
                for (var x = 0; x < m1.GetLength(d); x++)
                {
                    // Multiply same index on both arrays and sum the values
                    // try to do some recursivity stuff.
                }
            }

            return result;
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

        public int[,] TransposeMatrix(int[,] matrix)
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

        /// <summary>
        /// Multiply the values with the same indexes on both arrays 
        /// and sum the value with the calculation of the next index
        /// </summary>
        /// <param name="rowM1">Row of the first matrix</param>
        /// <param name="rowMt">Row of the second matrix (transposed matrix) </param>
        /// <param name="index">Index od the array to make calculations. Start at 0</param>
        /// <returns>Calculated value for correlated rows in matrices</returns>
        public int CalculateArrays(int[] rowM1, int[] rowMt, int index = 0)
        {
            var total = 0;

            if (index < rowM1.Length - 1)
                total = CalculateArrays(rowM1, rowMt, index + 1);

            total += rowM1[index] * rowMt[index];

            return total;
        }
    }
}

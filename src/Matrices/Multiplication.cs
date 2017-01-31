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

            int[,] m1 = new int[,] {};
            int[,] m2 = new int[,] {};

            if (AreCompatible(m1, m2))
            {
                var valuesM1 = GetValuesToMultiply(m1, true);
                var valuesM2 = GetValuesToMultiply(m2, false);

                // TODO: Do the calculation for each array in the same dimension of the matrices
                var result = Multiply(valuesM1, valuesM2);
            }
        }
        private int[,] Multiply(int[,] m1, int[,] m2)
        {
            var result = new int[,] {};

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="isFirstMatrix"></param>
        /// <returns></returns>
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

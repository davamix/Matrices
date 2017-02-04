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

                var result = Multiply(m1, transposeM2);
            }
        }

        public int[,] Multiply(int[,] m1, int[,] m2)
        {
            var matrixT = new int[m1.Rank, m2.GetLength(0)];

            for (int im2 = 0; im2 < m2.GetLength(0); im2++)
            {
                for (int im1 = 0; im1 < m1.GetLength(0); im1++)
                {
                    var arrayM1 = GetArrayFromRow(m1, im1);
                    var arrayM2 = GetArrayFromRow(m2, im2);

                    matrixT[im1, im2] = CalculateArrayValues(arrayM1, arrayM2);
                }
            }

            return matrixT;
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
        /// Get an the array of values from the specified row of the matrix
        /// </summary>
        /// <param name="matrix">A matrix with the values</param>
        /// <param name="row">Tow to extract the array of values</param>
        /// <returns>Array with the values</returns>
        public int[] GetArrayFromRow(int[,] matrix, int row)
        {
            if (matrix == null || row < 0) return null;

            var array = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                array[i] = matrix[row, i];
            }

            return array;
        }

        /// <summary>
        /// Multiply the values with the same indexes on both arrays 
        /// and sum the value with the calculation of the next index
        /// </summary>
        /// <param name="rowM1">Row of the first matrix</param>
        /// <param name="rowMt">Row of the second matrix (transposed matrix) </param>
        /// <param name="index">Index od the array to make calculations. Start at 0</param>
        /// <returns>Calculated value for correlated rows in matrices</returns>
        public int CalculateArrayValues(int[] rowM1, int[] rowMt, int index = 0)
        {
            var total = 0;

            if (index < rowM1.Length - 1)
                total = CalculateArrayValues(rowM1, rowMt, index + 1);

            total += rowM1[index] * rowMt[index];

            return total;
        }
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Matrices;
using Xunit;

namespace MatricesTests
{
    public class MultiplicationTests
    {
        private Multiplication _multiplication;

        private static int[,] MatrixA => new[,]
                                         {
                                             {3, 4},
                                             {2, 5}
                                         };

        private static int[,] MatrixB => new[,]
                                         {
                                             {1, 3},
                                             {6, 2}
                                         };

        private static int[,] MatrixB_Transposed => new[,]
                                                 {
                                                     {1, 6},
                                                     {3, 2}
                                                 };

        private static int[,] MatrixAxB_Transposed => new[,]
                                                      {
                                                          {27, 17},
                                                          {32, 16}
                                                      };

        private static int[,] MatrixC => new[,]
                                         {
                                             {2, 5, 6},
                                             {4, 7, 1},
                                             {0, 3, 2}
                                         };

        private static int[,] MatrixD => new[,]
                                         {
                                             {1, 5},
                                             {4, 2},
                                             {5, 3}
                                         };


        public MultiplicationTests()
        {
            _multiplication = new Multiplication();
        }

        #region Input data functions

        private static IEnumerable<object[]> GetMatricesToCheckCompatibility()
        {
            // {Matrix 1, Matrix 2, isCompatible}
            return new[]
                   {
                       new object[] {MatrixA, MatrixB, true},
                       new object[] {MatrixA, MatrixC, false},
                       new object[] {MatrixC, MatrixD, true}
                   };
        }

        // Get the array of values from the first row of MatrixA and MatrixB_Transposed
        private static IEnumerable<object[]> GetDataToCalculateFirstValueOfMatrixT()
        {
            var arrayMA = new int[MatrixA.GetLength(1)];
            var arrayBt = new int[MatrixB_Transposed.GetLength(1)];
            var total = 27;

            for (int x = 0; x < MatrixA.GetLength(1); x++)
            {
                arrayMA[x] = MatrixA[0, x];
                arrayBt[x] = MatrixB_Transposed[0, x];
            }

            return new[]
                   {
                       new object[] {arrayMA, arrayBt, total}
                   };
        }

        private static IEnumerable<object[]> GetDataToGetArrayOfFirstRowFromMatrixA()
        {
            var row = 0;
            var array = new[] {3, 4};

            return new[]
                   {
                       new object[] {MatrixA, row, array}
                   };
        }

        #endregion

        [Theory]
        [MemberData(nameof(GetMatricesToCheckCompatibility))]
        public void AreMatrixCompatible(int[,] m1, int[,] m2, bool areCompatible)
        {
            Assert.Equal(_multiplication.AreCompatible(m1, m2), areCompatible);
        }

        [Fact]
        public void GetValuesToMultiply()
        {
            var transposed = _multiplication.TransposeMatrix(MatrixB);

            Assert.True(CompareMatricesValues(transposed, MatrixB_Transposed));
        }

        [Theory]
        [MemberData(nameof(GetDataToCalculateFirstValueOfMatrixT))]
        public void CalculateFirstValueOfMatrixT(int[] arrayA, int[] arrayBt, int total)
        {
            var value = _multiplication.CalculateArrayValues(arrayA, arrayBt);

            Assert.Equal(total, value);
        }

        [Theory]
        [MemberData(nameof(GetDataToGetArrayOfFirstRowFromMatrixA))]
        public void GetArrayOfFirstRowFromMatrixA(int[,] matrix,int row, int[] expected)
        {
            var result = _multiplication.GetArrayFromRow(matrix, row);
            Assert.True(expected.SequenceEqual(result));
        }

        [Fact]
        public void MultiplyMatrixAWithMatrixBt()
        {
            var result = _multiplication.Multiply(MatrixA, MatrixB_Transposed);

            Assert.True(CompareMatricesValues(MatrixAxB_Transposed, result));
        }

        #region Auxiliar functions

        /// <summary>
        /// Compare the values of two matrices. http://stackoverflow.com/a/12446807
        /// </summary>
        /// <returns>TRUE if all values are equal; otherwise return FALSE</returns>
        private bool CompareMatricesValues(int[,] m1, int[,] m2)
        {
            return m1.Rank == m2.Rank
                   && Enumerable.Range(0, m1.Rank)
                                .All(dimension => m1.GetLength(dimension) == m2.GetLength(dimension))
                   && m1.Cast<int>().SequenceEqual(m2.Cast<int>());

        }

        #endregion
    }
}

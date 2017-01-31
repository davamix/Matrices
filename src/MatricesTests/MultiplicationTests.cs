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

        private static int[,] MatrixB_Reverse => new[,]
                                                 {
                                                     {1, 6},
                                                     {3, 2}
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

        private static IEnumerable<object[]> GetMatricesToMultiplyWithReverse()
        {
            // {Matrix values, Matrix result, is first matrix}
            return new[]
                   {
                       //First matrix
                       new object[] {MatrixA, MatrixA, true},
                       //Second matrix
                       new object[] {MatrixB, MatrixB_Reverse, false}
                   };
        }

        #endregion

        [Theory]
        [MemberData(nameof(GetMatricesToCheckCompatibility))]
        public void AreMatrixCompatible(int[,] m1, int[,] m2, bool areCompatible)
        {
            Assert.Equal(_multiplication.AreCompatible(m1, m2), areCompatible);
        }

        [Theory]
        [MemberData(nameof(GetMatricesToMultiplyWithReverse))]
        public void GetValuesToMultiply(int[,] m1, int[,] m2, bool isFirstMatrix)
        {
            var valuesM1 = _multiplication.GetValuesToMultiply(m1, isFirstMatrix);

            Assert.True(CompareMatricesValues(valuesM1, m2));
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

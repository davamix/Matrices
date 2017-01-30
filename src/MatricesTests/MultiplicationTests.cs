using System;
using System.Collections;
using System.Collections.Generic;
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

        private static IEnumerable<object[]> GetMatricesToCheckCompatibility()
        {
            return new[]
                   {
                       new object[] {MatrixA, MatrixB, true},
                       new object[] {MatrixA, MatrixC, false},
                       new object[] {MatrixC, MatrixD, true}
                   };
        }

        [Theory]
        [MemberData(nameof(GetMatricesToCheckCompatibility))]
        public void AreMatrixCompatible(int[,] m1, int[,] m2, bool areCompatible)
        {
            Assert.Equal(_multiplication.AreCompatible(m1, m2), areCompatible);
        }

        private static IEnumerable<object[]> GetMatricesToMultiplyWithReverse()
        {
            return new[]
                   {
                       new object[] {MatrixA, MatrixA},
                       new object[] {MatrixB, MatrixB_Reverse}
                   };
        }
        [Theory]
        [MemberData(nameof(GetMatricesToMultiplyWithReverse))]
        public void GetValuesToMultiply()
        {
            //Create a function to check each value in the matrix, same position.
            // for MatrixB and MatrixB_Reverse
        }


        [Fact]
        public void GetValuesToMultiplyFromMatrixA()
        {
            Assert.Equal(4, 2 + 2);
        }
    }
}

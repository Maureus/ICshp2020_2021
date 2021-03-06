using System;
using Fei.BaseLib;
using Xunit;

namespace BaseLib.Tests {
    public class ExtraMathTest {
        [Fact]
        public void SolveQuadraticEquationAssertTrue() {
            Assert.True(ExtraMath.SolveQuadraticEquation(1, 2, 1, out var x1, out var x2));
        }

        [Fact]
        public void SolveQuadraticEquationAssertFalse() {
            Assert.False(ExtraMath.SolveQuadraticEquation(-1, 2, -2, out var x1, out var x2));
        }

        [Fact]
        public void SolveQuadraticEquationAssertNull() {
            ExtraMath.SolveQuadraticEquation(1, 2, 2, out var x1, out var x2);
            Assert.Null(x1);
            Assert.Null(x2);
        }

        [Fact]
        public void SolveQuadraticEquationAssertEquals() {
            ExtraMath.SolveQuadraticEquation(1, 2, 1, out var x1, out var x2);
            Assert.Equal(-1, x1);
            Assert.Equal(-1, x2);
        }

        [Fact]
        public void SolveQuadraticEquationAssertThrows() {
            Assert.Throws<ArgumentException>(() => ExtraMath.SolveQuadraticEquation(0, 2, 1, out var x1, out var x2));
        }

        [Fact]
        public void AssertRandomDoubleNumberIsInRange() {
            const double minDouble = 5.0;
            const double maxDouble = 15.0;
            for (var i = 0; i < 50; i++) {
                Assert.InRange(ExtraMath.RandomDoubleFromRange(minDouble, maxDouble), minDouble, maxDouble);
            }
        }
    }
}
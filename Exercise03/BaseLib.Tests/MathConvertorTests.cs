using System;
using Fei.BaseLib;
using Xunit;

namespace BaseLib.Tests {
    public class MathConvertorTests {
        [Fact]
        public void AssertEqualResultOfConvertInt32ToRomanNumberString() {
            Assert.Equal("MMMDLV", MathConvertor.ConvertInt32ToRomanNumberString(3555));
        }

        [Fact]
        public void AssertIfConvertInt32ToRomanNumberStringThrowsArgumentOutOfRange() {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathConvertor.ConvertInt32ToRomanNumberString(4001));
        }
        
        [Fact]
        public void AssertEqualResultOfConvertRomanNumeralStringToInt32() {
            Assert.Equal(3555, MathConvertor.ConvertRomanNumeralStringToInt32("MMMDLV"));
        }

        [Fact]
        public void AssertIfConvertRomanNumeralStringToInt32ThrowsArgumentException() {
            Assert.Throws<ArgumentException>(() => MathConvertor.ConvertRomanNumeralStringToInt32("IIL"));
        }
    }
}
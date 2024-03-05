using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests_v2
{
    [TestClass]
    public class TestTests
    {
        [TestMethod]
        public void Test1()
        {
            Func<int, int, int> PlusFunc = (a,b) => a + b;
            Func<int, int, int> MinusFunc = (a, b) => a - b;

            var five = PlusFunc(2, 3);
            var two = MinusFunc(5, 3);

            Assert.AreEqual(five, 5);
            Assert.AreEqual(two, 2);
        }

        [TestMethod]
        public void Test2()
        {
            var defaultValueForString = Sss<string>.GetDefaultValue();
            var defaultValueForDouble = Sss<double>.GetDefaultValue();
        }
        
        public static class Sss<T>
        {
            public static T GetDefaultValue()
            {
                return default(T);
            }
        }
    }
}

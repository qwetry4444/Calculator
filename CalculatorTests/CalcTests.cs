using System;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void CalcIsStarted()
        {
            var calc = new Calc();
        }

        [TestMethod]
        public void Calc_ShouldShowZero_WhenStarted()
        {
            var calc = new Calc();
            Assert.AreEqual(calc.Display, 0);
        }

        [TestMethod]
        public void Calc_ДолженПоказыватьЦифру_КогдаВведенаЦифра()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);

            Assert.AreEqual(calc.Display, 3);
        }

        [TestMethod]
        public void Calc_ДолженПоказыватьЧисло_КогдаВведеноЧисло()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Three);

            Assert.AreEqual(calc.Display, 33);
        }

        [TestMethod]
        public void Calc_ДолженСкладывать2Числа()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 36);
        }

        [TestMethod]
        public void Calc_ДолженПроводитьСложениеNРаз()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Plus);

            Assert.AreEqual(calc.Display, 36);

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 39);
        }

        [TestMethod]
        public void Calc_ПовторныйВводРавно()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 39);
        }

        [TestMethod]
        public void Calc_ДолженПроводитьПовторноеВычисление()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);

            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 10);
        }

        [TestMethod]
        public void Calc_ВычислениеБез2Числа()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 4);
        }

        [TestMethod]
        public void Calc_ДобавлениеВПамять()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemoryPlus);
            calc.InputCommand.Execute(MathOperations.Five);
            calc.InputCommand.Execute(MathOperations.MemoryRead);

            Assert.AreEqual(calc.Display, 2);
        }

        [TestMethod]
        public void Calc_ВычитаниеИзПамяти()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemoryPlus);
            calc.InputCommand.Execute(MathOperations.One);
            calc.InputCommand.Execute(MathOperations.MemoryMinus);
            calc.InputCommand.Execute(MathOperations.MemoryRead);

            Assert.AreEqual(calc.Display, 1);
        }
    }
}
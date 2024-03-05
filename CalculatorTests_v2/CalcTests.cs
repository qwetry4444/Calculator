using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        public void Calc_MemorySet()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Five);
            calc.InputCommand.Execute(MathOperations.MemoryRead);

            Assert.AreEqual(calc.Display, 2);
        }

        [TestMethod]
        public void Calc_MemoryClear()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Six);
            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.MemoryClear);
            calc.InputCommand.Execute(MathOperations.MemoryRead);

            Assert.AreEqual(calc.Display, 0);
        }

        [TestMethod]
        public void Calc_ПослеРавноЗаписываетсяНовоеЧисло()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.One);
            calc.InputCommand.Execute(MathOperations.Equal);
            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 2);
        }

        [TestMethod]
        public void Calc_HistoryIsWork()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.Equal);
            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.Equal);
            calc.InputCommand.Execute(MathOperations.Equal);
            calc.ListItemReadCommand.Execute(calc.HistoryList[0]);

            Assert.AreEqual(calc.Display, 7);
            Assert.AreEqual(calc.HistoryList.Count, 3);
            Assert.AreEqual(calc.HistoryList[0].Value, 7);
            Assert.AreEqual(calc.HistoryList[1].Value, 7);
            Assert.AreEqual(calc.HistoryList[2].Value, 3);
        }

        [TestMethod]
        public void Calc_ДобавлениеПамятиВСписок()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            Assert.AreEqual(calc.MemoryList[0].Value, 2);
        }

        [TestMethod]
        public void Calc_ОчисткаПамяти()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.MemoryClear);
            Assert.AreEqual(calc.MemoryList.Count, 0);
        }

        [TestMethod]
        public void Calc_ЭлементПамятиПрибавляетЧисло()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.MemoryPlus);
            Assert.AreEqual(calc.MemoryList[0].Value, 5);
        }

        [TestMethod]
        public void Calc_ЭлементПамятиВычитаетЧисло()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Three);
            calc.InputCommand.Execute(MathOperations.MemoryMinus);
            Assert.AreEqual(calc.MemoryList[0].Value, -1);
        }

        [TestMethod]
        public void Calc_ЭлементПамятиПрибавляетЧислоВКнопке()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Two);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Seven);
            calc.MemoryPlusCommand.Execute(calc.MemoryList[0]);
            Assert.AreEqual(calc.MemoryList[0].Value, 9);
        }

        [TestMethod]
        public void Calc_ЭлементПамятиВычитаетЧислоВКнопке()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Two);
            calc.MemoryMinusCommand.Execute(calc.MemoryList[0]);
            Assert.AreEqual(calc.MemoryList[0].Value, 5);
        }

        [TestMethod]
        public void Calc_ЭлементУдаляетсяВКнопке()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Four);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.ListItemDeleteCommand.Execute(calc.MemoryList[0]);
            Assert.AreEqual(calc.MemoryList[0].Value, 7);
        }

        [TestMethod]
        public void Calc_ВводитсяNЗначноеЧислоПослеMS()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.MemorySet);
            calc.InputCommand.Execute(MathOperations.Four);
            calc.InputCommand.Execute(MathOperations.Five);
            calc.InputCommand.Execute(MathOperations.Two);
            
            Assert.AreEqual(calc.Display, 452);
        }

        [TestMethod]
        public void Calc_ВтороеСлагаемоеВводитсяПослеВводаНуля()
        {
            var calc = new Calc();

            calc.InputCommand.Execute(MathOperations.Seven);
            calc.InputCommand.Execute(MathOperations.Plus);
            calc.InputCommand.Execute(MathOperations.Zero);
            calc.InputCommand.Execute(MathOperations.Five);
            calc.InputCommand.Execute(MathOperations.Equal);

            Assert.AreEqual(calc.Display, 12);
        }
    }
}
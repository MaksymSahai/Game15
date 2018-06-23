using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game15.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void StartTest()
        {
            Game _game = new Game(4);
            _game.Start();
            Assert.AreEqual(1, _game.GetDigitAt(0, 0));
            Assert.AreEqual(2, _game.GetDigitAt(1, 0));
            Assert.AreEqual(5, _game.GetDigitAt(0, 1));
            Assert.AreEqual(15, _game.GetDigitAt(2, 3));
            Assert.AreEqual(0, _game.GetDigitAt(3, 3));
        }

        [TestMethod()]
        public void PressAtTest()
        {
            Game _game = new Game(4);
            _game.Start();
            _game.PressAt(2, 3);
            Assert.AreEqual(0, _game.GetDigitAt(2, 3));
            Assert.AreEqual(15, _game.GetDigitAt(3, 3));
            _game.PressAt(2, 2);
            Assert.AreEqual(0, _game.GetDigitAt(2, 2));
            Assert.AreEqual(11, _game.GetDigitAt(2, 3));
        }

        [TestMethod()]
        public void GetDigitAtTest()
        {
            Game _game = new Game(4);
            _game.Start();
            _game.PressAt(2, 3);
            Assert.AreEqual(0, _game.GetDigitAt(-5, -34));
            Assert.AreEqual(0, _game.GetDigitAt(15, 64));
        }

        [TestMethod()]
        public void SolvedTest()
        {
            Game _game = new Game(4);
            _game.Start();
            Assert.IsTrue(_game.Solved());
            _game.PressAt(2, 3);
            Assert.IsFalse(_game.Solved());
            _game.PressAt(3, 3);
            Assert.IsTrue(_game.Solved());

        }
    }
}
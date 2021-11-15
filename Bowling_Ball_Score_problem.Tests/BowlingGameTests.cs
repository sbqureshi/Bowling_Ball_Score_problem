using Bowling_Ball_Score_problem.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace Bowling_Ball_Score_problem.Tests
{
    [TestClass]
    public class BowlingGameTests
    {
        private  IBowlingGame game;

        [TestInitialize]
        public void Setup()
        {
            game = new BowlingGame();
        }

        [TestMethod]
        public void CanCreateGame()
        {
            var game = new BowlingGame();
            Assert.IsNotNull(game);
        }

        [TestMethod]
        public void CanRollGutterGame()
        {
            RollMany(0, 20);
            Assert.AreEqual(0, game.Score);
        }

        [TestMethod]
        public void CanRollAllOnes()
        {
            RollMany(1, 20);
            Assert.AreEqual(20, game.Score);
        }
        [TestMethod]
        public void CanRollSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(0, 17);
            Assert.AreEqual(16, game.Score);

        }
        [TestMethod]
        public void CanRollStrike()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            Assert.AreEqual(24, game.Score);

        }

        [TestMethod]
        public void CanRollPerfectGame()
        {
            RollMany(10, 12);
            Assert.AreEqual(300, game.Score);
        }

        private void RollMany(int pins, int rolls)
        {
            for (int i = 0; i < rolls; i++)
                game.Roll(pins);
        }
    }
}

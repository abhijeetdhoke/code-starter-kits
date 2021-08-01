using NUnit.Framework;
using Remotion.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Tests
{
    [TestFixture]
    public class BowlingTest
    {
        Game game;

        public BowlingTest(Game game)
        {
            this.game = game;
        }

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [Test]
        public void GutterBalls()
        {
            ManyOpenFrames(10, 0, 0);
            Assertion.Equals(0, game.Score());
        }

        [Test]
        public void Threes()
        {
            ManyOpenFrames(10, 3, 3);
            Assertion.Equals(60, game.Score());
        }

        [Test]
        public void Spare()
        {
            game.Spare(4, 6);
            game.OpenFrame(3, 5);
            ManyOpenFrames(8, 0, 0);
            Assertion.Equals(21, game.Score());
        }

        [Test]
        public void Spare2()
        {
            game.Spare(4, 6);
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);
            Assertion.Equals(23, game.Score());
        }

        [Test]
        public void Strike()
        {
            game.Strike();
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);
            Assertion.Equals(26, game.Score());
        }

        [Test]
        public void StrikeFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Strike();
            game.BonusRoll(5);
            game.BonusRoll(3);
            Assertion.Equals(18, game.Score()); 
        }

        [Test]
        public void SpareFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Spare(4, 6);
            game.BonusRoll(5);
            Assertion.Equals(15, game.Score());
        }

        [Test]
        public void Perfect()
        {
            for (int i = 0; i < 10; i++)
                game.Strike();
            game.BonusRoll(10);
            game.BonusRoll(10);
            Assertion.Equals(300, game.Score());
        }

        [Test]
        public void Alternating()
        {
            for (int i = 0; i < 5; i++)
            {
                game.Strike();
                game.Spare(4, 6);
            }
            game.BonusRoll(10);
            Assertion.Equals(200, game.Score());
        }

        private void ManyOpenFrames(int count, int firstThrow, int secondThrow)
        {
            for (int frameNumber = 0; frameNumber < count; frameNumber++)
                game.OpenFrame(firstThrow, secondThrow);
        }
    }
}

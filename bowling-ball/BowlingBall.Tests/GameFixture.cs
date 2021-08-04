using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using BowlingBall;
using System.Collections.Generic;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        Game game;

        //[SetUp]
        public GameFixture()
        {
            game = new Game();
        }

        [TestMethod]
        public void GutterBalls()
        {
            ManyOpenFrames(10, 0, 0);
            NUnit.Framework.Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void RollPins()
        {
            List<Tuple<int, int>> FrameWithRoll = new List<Tuple<int, int>>();
            //Frame 1
            FrameWithRoll.Add(new Tuple<int, int>(8, 1));
            //Frame 2
            FrameWithRoll.Add(new Tuple<int, int>(0, 9));
            //Frame 3
            FrameWithRoll.Add(new Tuple<int, int>(2, 8));
            //Frame 4
            FrameWithRoll.Add(new Tuple<int, int>(10, 0));
            //Frame 5
            FrameWithRoll.Add(new Tuple<int, int>(6, 3));
            //Frame 6
            FrameWithRoll.Add(new Tuple<int, int>(7, 0));
            //Frame 7
            FrameWithRoll.Add(new Tuple<int, int>(5, 2));
            //Frame 8
            FrameWithRoll.Add(new Tuple<int, int>(10, 0));
            //Frame 9
            FrameWithRoll.Add(new Tuple<int, int>(0, 6));
            //Frame 10
            FrameWithRoll.Add(new Tuple<int, int>(2, 8));
            // Below is Bonus call
            FrameWithRoll.Add(new Tuple<int, int>(10, 0));

            game.RollPin(FrameWithRoll);
            NUnit.Framework.Assert.AreEqual(122, game.Score());
        }

        [TestMethod]
        public void RollPins1()
        {
            List<Tuple<int, int>> FrameWithRoll = new List<Tuple<int, int>>();
            //Frame 1
            FrameWithRoll.Add(new Tuple<int, int>(5, 5));
            //Frame 2
            FrameWithRoll.Add(new Tuple<int, int>(4, 5));
            //Frame 3
            FrameWithRoll.Add(new Tuple<int, int>(8, 2));
            //Frame 4
            FrameWithRoll.Add(new Tuple<int, int>(10, 0));
            //Frame 5
            FrameWithRoll.Add(new Tuple<int, int>(0, 10));
            //Frame 6
            FrameWithRoll.Add(new Tuple<int, int>(7, 0));
            //Frame 7
            FrameWithRoll.Add(new Tuple<int, int>(5, 2));
            //Frame 8
            FrameWithRoll.Add(new Tuple<int, int>(10, 0));
            //Frame 9
            FrameWithRoll.Add(new Tuple<int, int>(0, 6));
            //Frame 10
            FrameWithRoll.Add(new Tuple<int, int>(2, 8));
            // Below is Bonus call
            FrameWithRoll.Add(new Tuple<int, int>(10, 0));
            //Task to do: Yet to test this games
            game.RollPin(FrameWithRoll);
            NUnit.Framework.Assert.AreEqual(122, game.Score());
        }

        //[TestMethod]
        //public void Threes()
        //{
        //    ManyOpenFrames(10, 3, 3);
        //    NUnit.Framework.Assert.AreEqual(60, game.Score());
        //}

        //[TestMethod]
        //public void Spare()
        //{
        //    game.Spare(4, 6);
        //    game.OpenFrame(3, 5);
        //    ManyOpenFrames(8, 0, 0);
        //    NUnit.Framework.Assert.AreEqual(21, game.Score());
        //}

        //[TestMethod]
        //public void OpenFrame2()
        //{
        //    game.OpenFrame(8, 1);
        //    game.OpenFrame(0, 9);
        //    ManyOpenFrames(8, 0, 0);
        //    NUnit.Framework.Assert.AreEqual(18, game.Score());
        //}


        //[TestMethod]
        //public void Spare2()
        //{
        //    game.Spare(4, 6);
        //    game.OpenFrame(5, 3);
        //    ManyOpenFrames(8, 0, 0);
        //    NUnit.Framework.Assert.AreEqual(23, game.Score());
        //}

        //[TestMethod]
        //public void Strike()
        //{
        //    game.Strike();
        //    game.OpenFrame(5, 3);
        //    ManyOpenFrames(8, 0, 0);
        //    NUnit.Framework.Assert.AreEqual(26, game.Score());
        //}

        //[TestMethod]
        //public void StrikeFinalFrame()
        //{
        //    ManyOpenFrames(9, 0, 0);
        //    game.Strike();
        //    game.BonusRoll(5);
        //    game.BonusRoll(3);
        //    NUnit.Framework.Assert.AreEqual(18, game.Score());
        //}

        //[TestMethod]
        //public void Frame10Game()
        //{
        //    game.OpenFrame(8, 1);
        //    game.OpenFrame(0, 9);
        //    game.Spare(2, 8);
        //    game.Strike();
        //    game.OpenFrame(6, 3);
        //    game.OpenFrame(7, 0);
        //    game.OpenFrame(5, 2);
        //    game.Strike();
        //    game.OpenFrame(0, 6);
        //    game.Spare(2, 8);
        //    game.BonusRoll(10);
        //    NUnit.Framework.Assert.AreEqual(122, game.Score());
        //}

        //[TestMethod]
        //public void SpareFinalFrame()
        //{
        //    ManyOpenFrames(9, 0, 0);
        //    game.Spare(4, 6);
        //    game.BonusRoll(5);
        //    NUnit.Framework.Assert.AreEqual(15, game.Score());
        //}

        //[TestMethod]
        //public void Perfect()
        //{
        //    for (int i = 0; i < 10; i++)
        //        game.Strike();
        //    game.BonusRoll(10);
        //    game.BonusRoll(10);
        //    NUnit.Framework.Assert.AreEqual(300, game.Score());
        //}

        //[TestMethod]
        //public void Alternating()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        game.Strike();
        //        game.Spare(4, 6);
        //    }
        //    game.BonusRoll(10);
        //    NUnit.Framework.Assert.AreEqual(200, game.Score());
        //}

        private void ManyOpenFrames(int count, int firstThrow, int secondThrow)
        {
            for (int frameNumber = 0; frameNumber < count; frameNumber++)
                game.OpenFrame(firstThrow, secondThrow);
        }
    }
}

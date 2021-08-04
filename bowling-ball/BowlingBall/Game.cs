using System;
using System.Collections;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {

        ArrayList throws;
        ArrayList frames;

        public Game()
        {
            throws = new ArrayList();
            frames = new ArrayList();
        }

        private void OpenFrame(int firstThrow, int secondThrow)
        {
            frames.Add(new OpenFrame(throws, firstThrow, secondThrow));
        }

        private void Spare(int firstThrow, int secondThrow)
        {
            frames.Add(new SpareFrame(throws, firstThrow, secondThrow));
        }

        private void Strike()
        {
            frames.Add(new StrikeFrame(throws));
        }

        private void BonusRoll(int roll)
        {
            frames.Add(new BonusRoll(throws, roll));
        }

        public int Score()
        {
            int total = 0;
            foreach (Frame frame in frames)
                total += frame.Score();
            return total;
        }

        public void RollPin(List<Tuple<int, int>> frameWithRoll)
        {
            for (int i = 0; i < frameWithRoll.Count; i++)
            {
                var takeTwoThrow = frameWithRoll[i].Item1 + frameWithRoll[i].Item2;

                //this is Spare because
                // If you knock out the first and second ball with total 10 then its Spare
                if (takeTwoThrow == 10 && (frameWithRoll[i].Item1 != 0 && frameWithRoll[i].Item2 != 0))
                {
                    Spare(frameWithRoll[i].Item1, frameWithRoll[i].Item2);
                }
                //this is Spare because
                //• If you knock down all the pins with the second ball, it is called a "spare"
                else if (frameWithRoll[i].Item1 == 0 && frameWithRoll[i].Item2 == 10)
                {
                    Spare(frameWithRoll[i].Item1, frameWithRoll[i].Item2);
                }
                // If you knock down first and second ball with total less than 10 then its open frame
                //Open frames are frames without a strike or spare
                else if (takeTwoThrow < 10)
                {
                    OpenFrame(frameWithRoll[i].Item1, frameWithRoll[i].Item2);
                }
                // This is specifically for bonusRoll, so here we are taking only first time which is 21th
                if (i == 10)
                {
                   BonusRoll(frameWithRoll[i].Item1);
                   break;
                }
                // this is final 10th frame 
                if (i == 9)
                {
                    if (frameWithRoll[i].Item1 == 10)
                    {
                        Strike();
                    }
                    if (frameWithRoll[i].Item2 == 10)
                    {
                        Strike();
                    }
                }
                else
                {
                    if (frameWithRoll[i].Item1 == 10)
                    {
                        Strike();
                    }
                }

            }
        }
    }
}

using System.Collections.Generic;

namespace BowlingScoreLibrary
{
    public class BowlingScorer
    {
        //Constants for hardcoded numbers for readability and easy changing
        //The length of a standard bowling game is 10 frames, with an 11th bonus frame
        private const int BONUS_FRAME = 10;
        private const int MAX_PINS = 10;

        public BowlingScorer()
        {
        }

        //Calculates the score of all frames in the frameCollection
        public int GetScore(ScoreCard gameState)
        {
            List<Frame> frameCollection = gameState.frameCollection;
            int totalScore = 0;
            
            int numberOfFrames = frameCollection.Count;

            for (int currentFrameIndex = 0; currentFrameIndex < numberOfFrames; currentFrameIndex++)
            {
                if(currentFrameIndex != BONUS_FRAME)
                {
                    Frame currentFrame = frameCollection[currentFrameIndex];
                    int nextFrameIndex = currentFrameIndex + 1;

                    totalScore += FrameScore(currentFrame);

                    if (IsStrike(currentFrame) && nextFrameIndex != numberOfFrames)
                    {
                        totalScore += StrikePoints(nextFrameIndex, frameCollection);
                    }
                    else if (IsSpare(currentFrame) && nextFrameIndex != numberOfFrames)
                    {
                        totalScore += SparePoints(frameCollection[nextFrameIndex]);
                    }
                }
            }

            return totalScore;
        }

        public int GetScore(ScoreCard gameState, int numberOfFrames)
        {
            List<Frame> frameCollection = gameState.frameCollection;
            int totalScore = 0;

            for (int currentFrameIndex = 0; currentFrameIndex < numberOfFrames; currentFrameIndex++)
            {
                if (currentFrameIndex != BONUS_FRAME)
                {
                    Frame currentFrame = frameCollection[currentFrameIndex];
                    int nextFrameIndex = currentFrameIndex + 1;

                    totalScore += FrameScore(currentFrame);

                    if (IsStrike(currentFrame) && nextFrameIndex != numberOfFrames)
                    {
                        totalScore += StrikePoints(nextFrameIndex, frameCollection);
                    }
                    else if (IsSpare(currentFrame) && nextFrameIndex != numberOfFrames)
                    {
                        totalScore += SparePoints(frameCollection[nextFrameIndex]);
                    }
                }
            }

            return totalScore;
        }

        public bool IsStrike(Frame currentFrame)
        {
            bool strike = false;
            if (currentFrame.Roll1 == MAX_PINS)
                strike = true;
            return strike;
        }

        public bool IsSpare(Frame currentFrame)
        {
            bool spare = false;
            if (FrameScore(currentFrame) == MAX_PINS)
                spare = true;
            return spare;
        }

        public int FrameScore(Frame currentFrame)
        {
            return currentFrame.Roll1 + currentFrame.Roll2;
        }        

        private int StrikePoints(int currentFrameIndex, List<Frame> frameCollection)
        {
            int points = 0;
            if (IsStrike(frameCollection[currentFrameIndex]) && currentFrameIndex != BONUS_FRAME)
                points += MAX_PINS + frameCollection[currentFrameIndex + 1].Roll1;
            else
                points += FrameScore(frameCollection[currentFrameIndex]);
            return points;
        }

        private int SparePoints(Frame currentFrame)
        {
            return currentFrame.Roll1;
        }
    }
}

using System;
using System.Collections.Generic;

namespace BowlingScoreLibrary
{
    public class ScoreCard
    {
        //Constants for hardcoded numbers for readability and easy changing
        private const int GAME_LENGTH = 11;
        private const int BONUS_FRAME = 10;
        private const int MAX_PINS = 10;

        public int currentFrame { get; set; }

        public List<Frame> frameCollection { get;}
        public string playerName { get; set; }
        public DateTime gameDate { get; }

        public ScoreCard()
        {
            frameCollection = new List<Frame>();
            for (int i = 0; i < GAME_LENGTH; i++)
                frameCollection.Add(new Frame());
            playerName = "";
            gameDate = DateTime.Now;
        }

        public ScoreCard(string name)
        {
            frameCollection = new List<Frame>();
            for (int i = 0; i < GAME_LENGTH; i++)
                frameCollection.Add(new Frame());
            playerName = name;
            gameDate = DateTime.Now;
        }

        public ScoreCard(List<Frame> frameState)
        { 
            int numberOfFrames = frameState.Count;
            int lastFrameIndex = numberOfFrames - 1;
            if (lastFrameIndex >= 0 && (frameState[lastFrameIndex].current_roll == 1 || frameState[lastFrameIndex].current_roll == 2))
                currentFrame = lastFrameIndex;
            else
                currentFrame = numberOfFrames;
            //if bigger than the game length trim it down
            if (numberOfFrames > GAME_LENGTH)
                frameState.RemoveRange(GAME_LENGTH, frameState.Count - GAME_LENGTH);

            //if smaller than game length fill with empty frames
            if (numberOfFrames < GAME_LENGTH)
            {
                for (int i = 0; i < GAME_LENGTH - numberOfFrames; i++)
                    frameState.Add(new Frame());
            }

            frameCollection = frameState;
            playerName = "";
        }

        public ScoreCard(List<Frame> frameState, string name)
        {
            int numberOfFrames = frameState.Count;
            if (numberOfFrames - 1 >= 0 && (frameState[numberOfFrames - 1].current_roll == 1 || frameState[numberOfFrames - 1].current_roll == 2))
                currentFrame = numberOfFrames - 1;
            else
                currentFrame = numberOfFrames;
            //if bigger than the game length trim it down
            if (numberOfFrames > GAME_LENGTH)
                frameState.RemoveRange(GAME_LENGTH, frameState.Count - GAME_LENGTH);

            //if smaller than game length fill with empty frames
            if (numberOfFrames < GAME_LENGTH)
            {
                for (int i = 0; i < GAME_LENGTH - numberOfFrames; i++)
                    frameState.Add(new Frame());
            }

            frameCollection = frameState;
            playerName = name;
        }

        public void RecordNextRoll(int pins)
        {
            //Ensure the user is not recording more rolls then there are available in the frames and no more pins then the max amount of pins in one roll
            if (currentFrame < GAME_LENGTH && pins <= MAX_PINS)
            {
                if (frameCollection[currentFrame].current_roll == 1 && pins == MAX_PINS && currentFrame != BONUS_FRAME)
                {
                    frameCollection[currentFrame].Roll1 = pins;
                    frameCollection[currentFrame].current_roll = 0;
                    currentFrame++;
                }
                else if (frameCollection[currentFrame].current_roll == 1)
                {
                    frameCollection[currentFrame].Roll1 = pins;
                }
                else
                {
                    frameCollection[currentFrame].Roll2 = pins;
                    currentFrame++;
                }
            }
        }
    }
}

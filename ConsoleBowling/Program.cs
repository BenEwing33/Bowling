using System;
using System.Collections.Generic;
using BowlingScoreLibrary;

namespace ConsoleBowling
{
    class Program
    {
        static int rollCount;
        static int[] scores;

        static void Main(string[] args)
        {

            List<Frame> f = new List<Frame>();
            BowlingGame g = new BowlingGame(f);
            rollCount = 0;
            scores = new int[12];
            while (rollCount < 22)
            {
                Console.WriteLine("Enter Number of Pins: ");
                int newRoll = Convert.ToInt32(Console.ReadLine());
                g.RecordNextRoll(newRoll);
                Console.Clear();
                if (newRoll != 10 || newRoll == 10 && rollCount == 20)
                    rollCount++;
                else
                    rollCount += 2;
                printFrames(g, f);
                if (rollCount == 20 && newRoll != 10)
                {
                    rollCount = 22;
                    Console.WriteLine("Your Final Score is " + scores[10]);
                }
                else if (rollCount == 22)
                    Console.WriteLine("Your Final Score is " + scores[11]);
            }
        }

        static void printFrames(BowlingGame game, List<Frame> frameCollection)
        {
            if(rollCount % 2 == 0)
                scores[rollCount/2] = game.GetScore();
            string frameOutput = "";
            for (int i = 0; i < frameCollection.Count; i++)
                frameOutput += "----------  ";
            frameOutput += "\n";
            for (int i = 0; i < frameCollection.Count; i++)
            {
                if (frameCollection[i].roll1 != 10)
                    frameOutput += $"|   |{frameCollection[i].roll1} |{frameCollection[i].roll2}|  ";
                else
                    frameOutput += $"|   |{frameCollection[i].roll1}|{frameCollection[i].roll2}|  ";
            }
                
            frameOutput += "\n";
            for (int i = 0; i < frameCollection.Count; i++)
            {
                if (i < rollCount / 2)
                {
                    if(frameCollection[i].roll1 == 10)
                        frameOutput += "|X  -----|  ";
                    else if (frameCollection[i].roll1+frameCollection[i].roll2 == 10)
                        frameOutput += "|/  -----|  ";
                    else if (scores[i+1]/10 == 0)
                        frameOutput += $"|{scores[i + 1]}  -----|  ";
                    else if (scores[i+1]/100 == 0)
                        frameOutput += $"|{scores[i + 1]} -----|  ";
                    else
                        frameOutput += $"|{scores[i + 1]}-----|  ";
                }
                else
                    frameOutput += "|   -----|  ";
            }
            frameOutput += "\n";
            for (int i = 0; i < frameCollection.Count;i++)
                frameOutput += "----------  ";
            frameOutput += "\n";
            Console.Write(frameOutput);
        }
    }
}

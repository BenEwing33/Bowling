using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScoreLibrary
{
    public class UserStatistics
    {
        IDataAccess dataAccess;
        public UserStatistics()
        {
            dataAccess = new DataAccess();
        }

        public UserStatistics(IDataAccess dataAccessInterface)
        {
            dataAccess = dataAccessInterface;
        }

        public bool IsDatabaseOn()
        {
            return dataAccess.IsDatabaseOn();
        }

        public string IsGoodTopScore(string name)
        {
            int top_score = dataAccess.GetTopScore(name);
            string response = "";
            if (top_score < 100)
                response = "Not Good";
            else if (top_score < 200)
                response = "Decent Try";
            else if (top_score < 300)
                response = "Good Try";
            else
                response = "Amazing Score";
            return response;
        }

        public string StoreRecord(Record record)
        {
            bool result = dataAccess.StoreRecord(record);
            string message;
            if (result)
                message = "Success";
            else
                message = "Failure";
            return message;
        }
        /*
        public int GetScoreCardFirstRoll(string name)
        {
            ScoreCard sc = dataAccess.GetScoreCard(name);

            return sc.frameCollection[0].Roll1;
        }

        public string WhosBetter(string name1, string name2)
        {
            Record firstSc = dataAccess.GetRecord(name1);
            Record secondSc = dataAccess.GetRecord(name2);

            string winner;

            if (firstSc.score > secondSc.score)
                winner = $"{name1} is better";
            else if (firstSc.score < secondSc.score)
                winner = $"{name2} is better";
            else
                winner = "You guys are equals";

            return winner;
        }*/

        public string WhoWonOnSpecificDate(DateTime date)
        {
            string winner = "";
            int topScore = 0;
            List<Record> records = dataAccess.GetRecordsOnDate(date);
            foreach (Record record in records)
            {
                int currentScore = record.score;
                if (topScore < currentScore)
                {
                    topScore = currentScore;
                    winner = record.name;
                }
            }
            return winner;
        }

        public List<Record> GetLeaderBoard(int numberOfScores)
        {
            List<Record> allRecords = dataAccess.GetAllRecords();

            List<Record> leaderboard = allRecords.OrderByDescending(x => x.score).Take(numberOfScores).ToList<Record>();
            

            return leaderboard;
        }

        public List<Record> GetRecordsForName(string name)
        {
            return dataAccess.GetRecords(name).OrderByDescending(x => x.score).ToList<Record>();
        }

        public List<Record> GetRecordsForDate(DateTime date)
        {
            return dataAccess.GetRecordsOnDate(date).OrderByDescending(x => x.score).ToList<Record>();
        }
    }
}

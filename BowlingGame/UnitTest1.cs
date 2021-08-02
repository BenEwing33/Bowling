using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BowlingScoreLibrary;
using FakeItEasy;
using System.Linq;
using System;

namespace BowlingProject
{

    [TestClass]
    public class BowlingGameTest
    {
        [TestMethod]
        public void Gutter_Game_0_Expected()
        {
            //Arrange
            BowlingScorer g = new BowlingScorer();
            ScoreCard sc = new ScoreCard("Name");
            //Assign
            for (int rollNumber = 0; rollNumber < 20; rollNumber++)
                sc.RecordNextRoll(0);

            //Assert
            Assert.AreEqual(0, g.GetScore(sc));

        }

        [TestMethod]
        public void One_Pin_Per_Roll_20_Expected()
        {
            //Arrange
            BowlingScorer g = new BowlingScorer();
            ScoreCard sc = new ScoreCard("Name");

            //Assign
            for (int rollNumber = 0; rollNumber < 20; rollNumber++)
                sc.RecordNextRoll(1);

            //Assert
            Assert.AreEqual(20, g.GetScore(sc));

        }

        [TestMethod]
        public void Spare_Then_3_Pins_Then_All_Miss_16_Expected()
        {
            //Arrange
            BowlingScorer g = new BowlingScorer();
            ScoreCard sc = new ScoreCard("Name");

            //Assign
            sc.RecordNextRoll(6);
            sc.RecordNextRoll(4);
            sc.RecordNextRoll(3);

            //Assert
            Assert.AreEqual(16, g.GetScore(sc));

        }

        [TestMethod]
        public void Strike_Then_3_Then_4_Then_All_Miss_24_Expected()
        {
            //Arrange
            BowlingScorer g = new BowlingScorer();
            ScoreCard sc = new ScoreCard("Name");

            //Assign
            sc.RecordNextRoll(10);
            sc.RecordNextRoll(3);
            sc.RecordNextRoll(4);

            //Assert
            Assert.AreEqual(24, g.GetScore(sc));

        }

        [TestMethod]
        public void All_Strikes_Game_300_Expected()
        {
            //Arrange
            BowlingScorer g = new BowlingScorer();
            ScoreCard sc = new ScoreCard("Name");

            //Assign
            for (int i = 0; i < 12; i++)
                sc.RecordNextRoll(10);

            //Assert
            Assert.AreEqual(300, g.GetScore(sc));

        }

        [TestMethod]
        public void Manual_Creation_Of_10_Frames_Of_Four_And_6_Then_3_and_3_for_bonus_139_Expected()
        {
            List<Frame> f = new List<Frame>();
            for(int i = 0; i < 10; i++)
            {
                f.Add(new Frame(4,6));
            }

            //Arrange
            BowlingScorer g = new BowlingScorer();
            ScoreCard sc = new ScoreCard(f,"Name");
            sc.RecordNextRoll(3);
            sc.RecordNextRoll(3);

            //Assert
            Assert.AreEqual(139, g.GetScore(sc));

        }

        [TestMethod]
        public void Manual_Creation_Too_Many_Frames_Of_4_and_4_80_Expected()
        {
            List<Frame> f = new List<Frame>();
            for (int i = 0; i < 20; i++)
            {
                f.Add(new Frame(4, 4));
            }

            //Arrange
            BowlingScorer g = new BowlingScorer();
            ScoreCard sc = new ScoreCard(f, "Name");


            //Assert
            Assert.AreEqual(80, g.GetScore(sc));
        }

        [TestMethod]
        public void Manual_Creation_Only_4_Frames_Of_1s_8_expected()
        {
            List<Frame> f = new List<Frame>();
            for (int i = 0; i < 4; i++)
            {
                f.Add(new Frame(1, 1));
            }

            BowlingScorer g = new BowlingScorer();
            ScoreCard sc = new ScoreCard(f, "Name");


            //Assert
            Assert.AreEqual(8, g.GetScore(sc));
        }

        [TestMethod]
        public void No_Name_Passed_Empty_String_Expected()
        {
            ScoreCard sc = new ScoreCard();

            Assert.AreEqual("", sc.playerName);
        }

        [TestMethod]
        public void No_Scores_Recorded_0_Expected()
        {
            List<Frame> f = new List<Frame>();

            //Arrange
            BowlingScorer g = new BowlingScorer();
            ScoreCard sc = new ScoreCard(f, "Name");


            //Assert
            Assert.AreEqual(0, g.GetScore(sc));
        }

        [TestMethod]
        public void One_Frame_Of_2_And_2_Then_Empty_Frame_Then_Frame_Of_2_And_2_8_expected()
        {
            List<Frame> f = new List<Frame>();
            f.Add(new Frame(2, 2));
            f.Add(new Frame());
            f.Add(new Frame(2, 2));

            //Arrange
            BowlingScorer g = new BowlingScorer();
            ScoreCard sc = new ScoreCard(f, "Name");


            //Assert
            Assert.AreEqual(8, g.GetScore(sc));
        }

        [TestMethod]
        public void Record_15_Pins_In_One_Roll_0_Expected()
        {
            ScoreCard sc = new ScoreCard("Name");
            sc.RecordNextRoll(15);

            BowlingScorer g = new BowlingScorer();

            Assert.AreEqual(0, g.GetScore(sc));
        }

        [TestMethod]
        public void Start_With_1_Roll_Of_3_Then_Use_RecordRoll_For_19_4s_79_Expected()
        {
            List<Frame> f = new List<Frame>();
            f.Add(new Frame(3));
            ScoreCard sc = new ScoreCard(f, "Name");
            for (int i = 0; i < 19; i++)
                sc.RecordNextRoll(4);

            BowlingScorer g = new BowlingScorer();

            Assert.AreEqual(79, g.GetScore(sc));
        }

        [TestMethod]
        public void Start_With_4_Frames_Of_3_Then_Use_RecordRoll_For_12_2s_48_Expected()
        {
            List<Frame> f = new List<Frame>();
            for(int i = 0; i < 4;i++)
                f.Add(new Frame(3,3));
            ScoreCard sc = new ScoreCard(f, "Name");
            for (int i = 0; i < 12; i++)
                sc.RecordNextRoll(2);

            BowlingScorer g = new BowlingScorer();

            Assert.AreEqual(48, g.GetScore(sc));
        }

        [TestMethod]
        public void Start_With_9_Frames_Of_10_Then_Frame_Of_2_and_2_250_Expected()
        {
            List<Frame> f = new List<Frame>();
            for (int i = 0; i < 9; i++)
                f.Add(new Frame(10));
            ScoreCard sc = new ScoreCard(f, "Name");
            sc.RecordNextRoll(2);
            sc.RecordNextRoll(2);

            BowlingScorer g = new BowlingScorer();

            Assert.AreEqual(250, g.GetScore(sc));
        }

        [TestMethod]
        public void Is_Database_On_No()
        {
            //Arrange
            var iDataAccess = A.Fake<IDataAccess>();
            A.CallTo(() => iDataAccess.IsDatabaseOn()).Returns(false);

            UserStatistics us = new UserStatistics(iDataAccess);
            //Assign
            bool result = us.IsDatabaseOn();

            //Assert
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        public void Get_Top_Score_When_Top_Is_300()
        {
            //Arrange
            var iDataAccess = A.Fake<IDataAccess>();
            A.CallTo(() => iDataAccess.GetTopScore(A<string>.Ignored)).Returns(300);

            UserStatistics us = new UserStatistics(iDataAccess);
            //Assign
            string result = us.IsGoodTopScore("Ben");

            //Assert
            Assert.AreEqual("Amazing Score", result);

        }

        [TestMethod]
        public void Get_Top_Score_When_Top_Is_250()
        {
            //Arrange
            var iDataAccess = A.Fake<IDataAccess>();
            A.CallTo(() => iDataAccess.GetTopScore("Chris")).Returns(250);

            UserStatistics us = new UserStatistics(iDataAccess);
            //Assign
            string result = us.IsGoodTopScore("Chris");

            //Assert
            Assert.AreEqual("Good Try", result);

        }

        [TestMethod]
        public void Get_Top_Score_When_Top_Is_150()
        {
            //Arrange
            var iDataAccess = A.Fake<IDataAccess>();
            A.CallTo(() => iDataAccess.GetTopScore("John")).Returns(150);

            UserStatistics us = new UserStatistics(iDataAccess);
            //Assign
            string result = us.IsGoodTopScore("John");

            //Assert
            Assert.AreEqual("Decent Try", result);

        }

        [TestMethod]
        public void Store_ScoreCard_Db_Fails()
        {
            //Arrange
            var iDataAccess = A.Fake<IDataAccess>();
            Record record = new Record();
            //A.CallTo(() => iDataAccess.StoreScoreCard(sc)).Returns(false);

            UserStatistics us = new UserStatistics(iDataAccess);
            //Assign
            string result = us.StoreRecord(record);

            //Assert
            Assert.AreEqual("Failure", result);

        }

        [TestMethod]
        public void Store_ScoreCard_Db_Succeeds()
        {
            //Arrange
            var iDataAccess = A.Fake<IDataAccess>();
            Record record = new Record();
            A.CallTo(() => iDataAccess.IsDatabaseOn()).Returns(true);
            A.CallTo(() => iDataAccess.StoreRecord(record)).Returns(iDataAccess.IsDatabaseOn());

            UserStatistics us = new UserStatistics(iDataAccess);
            //Assign
            string result = us.StoreRecord(record);

            //Assert
            Assert.AreEqual("Success", result);

        }

        [TestMethod]
        public void Who_Won_On_Todays_Date_Its_Ben()
        {
            //Arrange
            var iDataAccess = A.Fake<IDataAccess>();
            DateTime date = DateTime.Now;
            Record r1 = new Record();
            r1.name = "Doug";
            r1.date = date;
            r1.score = 100;
            Record r2 = new Record();
            r2.name = "Ben";
            r2.date = date;
            r2.score = 150;
            Record r3 = new Record();
            r3.name = "Steve";
            r3.date = date;
            r3.score = 120;

            List<Record> records = new List<Record>();
            records.Add(r1);
            records.Add(r2);
            records.Add(r3);

            A.CallTo(() => iDataAccess.GetRecordsOnDate(date)).Returns(records);



            UserStatistics us = new UserStatistics(iDataAccess);
            //Assign
            string result = us.WhoWonOnSpecificDate(date);

            //Assert
            Assert.AreEqual("Ben", result);

        }

       /* [TestMethod]
        public void Get_Top_5_LeaderBoard_Ben_Chris_Doug_Joe_Phil()
        {

            //Create test data
            var iDataAccess = A.Fake<IDataAccess>();
            List<Frame> f1 = new List<Frame>();
            for (int i = 0; i < 11; i++)
                f1.Add(new Frame(5, 2));
            ScoreCard sc1 = new ScoreCard(f1, "Doug");

            List<Frame> f2 = new List<Frame>();
            for (int i = 0; i < 11; i++)
                f2.Add(new Frame(5, 5));
            ScoreCard sc2 = new ScoreCard(f2, "Chris");

            List<Frame> f3 = new List<Frame>();
            for (int i = 0; i < 11; i++)
                f3.Add(new Frame(10));
            ScoreCard sc3 = new ScoreCard(f3, "Ben");

            List<Frame> f4 = new List<Frame>();
            for (int i = 0; i < 11; i++)
                f4.Add(new Frame(4,2));
            ScoreCard sc4 = new ScoreCard(f4, "Joe");

            List<Frame> f5 = new List<Frame>();
            for (int i = 0; i < 11; i++)
                f5.Add(new Frame(3,2));
            ScoreCard sc5 = new ScoreCard(f5, "Phil");

            List<Frame> f6 = new List<Frame>();
            for (int i = 0; i < 11; i++)
                f6.Add(new Frame(2, 2));
            ScoreCard sc6 = new ScoreCard(f6, "Phil");

            List<ScoreCard> scoreCards = new List<ScoreCard>();

            scoreCards.Add(sc3);
            scoreCards.Add(sc2);
            scoreCards.Add(sc1);
            scoreCards.Add(sc4);
            scoreCards.Add(sc5);
            scoreCards.Add(sc6);

            A.CallTo(() => iDataAccess.GetAllScoreCards()).Returns(scoreCards);



            UserStatistics us = new UserStatistics(iDataAccess);
            //Assign
            IEnumerable<(int, string)> result = us.GetLeaderBoard(5);
            List<string> leaderboardNames = new List<string>();
            bool compare = true;
            foreach((int,string) nameScorePair in result)
            {
                leaderboardNames.Add(nameScorePair.Item2);
            }
            List<string> expected = new List<string>(){ "Ben", "Chris", "Doug", "Joe", "Phil" };
            //Compare the expected with the results for the assert
            for (int i = 0; i < 5; i++)
                compare &= (leaderboardNames[i] == expected[i]);

            //Assert
            Assert.AreEqual(true, compare);

        }*/

        [TestMethod]
        public void Get_Records()
        {
            DataAccess da = new DataAccess();
            List<Record> result = da.GetRecords("Ben");
            int x = 0;
        }

        [TestMethod]
        public void set_Record()
        {
            DataAccess da = new DataAccess();
            Record record = new Record();
            record.name = "Steve";
            record.score = 300;
            record.date = DateTime.Now;
            da.StoreRecord(record);
            List<Record> result = da.GetRecords("Steve");
            int x = 0;
        }
    }
}

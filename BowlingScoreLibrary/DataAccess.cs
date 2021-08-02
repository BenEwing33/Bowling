using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BowlingScoreLibrary
{
    public class DataAccess : IDataAccess
    {
        public List<Record> GetRecords(string name)
        {
            using (var csv = new CsvReader(new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\file.csv"), CultureInfo.InvariantCulture))
            {
                List<Record> playerRecords = new List<Record>();

                var records = csv.GetRecords<Record>();

                playerRecords = records.Where(record => record.name == name).ToList<Record>();

                return playerRecords;
            }
        }

        public Record GetRecord(string name, DateTime date)
        {
            using (var csv = new CsvReader(new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\file.csv"), CultureInfo.InvariantCulture))
            {
                Record playerRecord = new Record();

                var records = csv.GetRecords<Record>();

                playerRecord = (Record)records.Where(record => record.name == name).Where(record => record.date.Date == date.Date).ToArray()[0];

                return playerRecord;
            }
        }

        public int GetTopScore(string name)
        {
            using (var csv = new CsvReader(new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\file.csv"), CultureInfo.InvariantCulture))
            {
                int topScore = -1;

                var records = csv.GetRecords<Record>();

                topScore = records.OrderByDescending(record => record.score).Take(1).ToArray()[0].score;

                return topScore;
            }
        }

        public bool IsDatabaseOn()
        {
            return true;
        }

        public bool StoreRecord(Record record)
        {
            bool success;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var csv = new CsvWriter(new StreamWriter(File.Open(AppDomain.CurrentDomain.BaseDirectory + "\\file.csv", FileMode.Append)), config))
            {                
                csv.NextRecord();

                csv.WriteRecord(record);
            }
            success = IsDatabaseOn();
            return success;
        }

        public List<Record> GetRecordsOnDate(DateTime date)
        {
            using (var csv = new CsvReader(new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\file.csv"), CultureInfo.InvariantCulture))
            {
                List<Record> result = new List<Record>();

                var records = csv.GetRecords<Record>();

                result = records.Where(record => record.date.Date == date.Date).ToList<Record>();

                return result;
            }
        }

        public List<Record> GetAllRecords()
        {
            using (var csv = new CsvReader(new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\file.csv"), CultureInfo.InvariantCulture))
            {
                List<Record> result = new List<Record>();

                var records = csv.GetRecords<Record>();

                result = records.ToList<Record>();

                return result;
            }
        }

    }
}

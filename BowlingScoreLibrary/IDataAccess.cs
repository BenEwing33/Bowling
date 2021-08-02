using System.Collections.Generic;

namespace BowlingScoreLibrary
{
    public interface IDataAccess
    {
        bool IsDatabaseOn();

        bool StoreRecord(Record record);

        List<Record> GetRecordsOnDate(System.DateTime date);
        List<Record> GetRecords(string name);
        Record GetRecord(string name, System.DateTime date);
        int GetTopScore(string name);
        List<Record> GetAllRecords();
    }
}
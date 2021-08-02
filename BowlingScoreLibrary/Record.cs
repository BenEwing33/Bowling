using System;

namespace BowlingScoreLibrary
{
    public class Record
    {
        public string name { get; set; }
        public DateTime date {get;set;}
        public int score { get; set; }
        public string serializedFrameCollection { get; set; }
    }
}

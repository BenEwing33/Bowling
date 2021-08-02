using System;
using System.Collections.Generic;

namespace BowlingScoreLibrary
{
    public class TestInterface
    {
        IDataAccess dataAccess;
        public TestInterface()
        {
            dataAccess = new DataAccess();
        }

        public TestInterface(IDataAccess dataAccessInterface)
        {
            dataAccess = dataAccessInterface;
        }

    }
}

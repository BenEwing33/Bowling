

namespace BowlingScoreLibrary
{
    public class Frame
    {
        private int roll1;
        public int Roll1
        {
            get
            {
                return roll1;
            }
            set
            {
                roll1 = value;
                current_roll = 2;
            }
        }
        private int roll2;
        public int Roll2
        {
            get
            {
                return roll2;
            }
            set
            {
                roll2 = value;
                current_roll = 0;
            }
        }

        public int current_roll { get; set; }
        public Frame()
        {
            current_roll = 1;
        }

        public Frame(int roll1)
        {
            this.roll1 = roll1;
            if (roll1 == 10)
                current_roll = 0;
            else
                current_roll = 2;
        }

        public Frame(int roll1, int roll2)
        {
            this.roll1 = roll1;
            this.roll2 = roll2;
            current_roll = 0;
        }
    }
}

namespace MIVS3
{
    internal class Indicators
    {
        private int dolgi;
        private int sleep;
        private int passedLabs;
        private int days;

        public Indicators()
        {
            dolgi = 0;
            sleep = 0;
            passedLabs = 0;
            days = 0;
        }

        public Indicators(int hu, int s, int a)
        {
            dolgi = hu;
            sleep = s;
            passedLabs = a;
            days = 0;
        }

        public int Dolgi
        {
            get { return dolgi; }
            set { dolgi = value; }
        }
        public int Sleep
        {
            get { return sleep; }
            set { sleep = value; }
        }
        public int PassedLabs
        {
            get { return passedLabs; }
            set { passedLabs = value; }
        }
        public int Days
        {
            get { return days; }
            set { days = value; }
        }
    }
}
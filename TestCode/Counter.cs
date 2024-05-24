namespace TestCode
{
    internal class Counter
    {
        public int Seconds { get; set; }

        public static implicit operator Counter(int x)
        {
            return new Counter { Seconds = x };
        }

        public static explicit operator int(Counter counter) //явное
        {
            return counter.Seconds;
        }

        public static explicit operator string(Counter counter3)
        {
            return "You are pidor";
        }

        


    }
}

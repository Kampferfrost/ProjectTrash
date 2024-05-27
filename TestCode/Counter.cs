namespace TestCode
{
    internal class Counter
    {
        public int Seconds { get; set; }

        public static implicit operator Counter(int x) //скрытый
        {
            return new Counter { Seconds = x };
        }

        public static explicit operator int(Counter counter) //явное
        {
            return counter.Seconds;
        }    

    }
}

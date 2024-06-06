namespace TestCode
{
    public delegate void AccountHandler(string message);
    internal class Account
    {
        private int _sum;
        public void Add(int sum) => _sum += sum;
        public void Take(int sum)
        {
            if (_sum >= sum) _sum = sum;
        }
    }
}

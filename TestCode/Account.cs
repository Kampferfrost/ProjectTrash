namespace TestCode
{
    public delegate void AccountHandler(string message);
    internal class Account
    {
        AccountHandler? taken;
        private int _sum;
        public Account(int sum) => _sum = sum;

        public void RegisterHandler(AccountHandler del)
        {
            taken = del;
        }
        public void Add(int sum) => _sum += sum;
        public void Take(int sum)
        {
            if (_sum >= sum) _sum = sum;
        }
    }
}

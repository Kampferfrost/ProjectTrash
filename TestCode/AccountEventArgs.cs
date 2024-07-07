namespace TestCode
{
    public class AccountEventArgs
    {
        public string Message { get; private set; }
        public int Sum { get; private set; }
        public AccountEventArgs(string message, int sum)
        {
            Message = message;
            Sum = sum;
        }
    }
}

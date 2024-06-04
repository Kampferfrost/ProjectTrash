namespace TestCode
{

    internal class Account
    {
        public int Sum { get; private set; }
        public Account(int sum) => Sum = sum;

        public void Put(int sum) => Sum += sum;
        public void Take (int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
            }
        }


    }
}

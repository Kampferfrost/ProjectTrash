// написал классы которые принимают, Action, func
namespace ClassPersonWithActionAndFunc
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n1 = 5;
            int n2 = 7;
            int result = 0; // когда методы используют эти переменные это называется замыканием

            var p = new Person<int, int, int>((x, y) => x + y); // принимает func с 2 числами и возврат , 2  числа и возвращает выражение: x + y

            var p2 = new Person<int>(() => n1 + n2);  //  принимает func без ничего, и только возвращает
            var p3 = new Person<int>(() => Sum(n1, n2));  // принимает func без ничего, и только возвращает

            Console.WriteLine(p.Execute(n1, n2));
            Console.WriteLine(p2.Execute());
            Console.WriteLine(p3.Execute());

            var p4 = new Person(() => { result = n1 * n2; }); // принимает Action без ничего, ничего не возвращает
            p4.Execute();
            Console.WriteLine(result);

            var personAction = new PersonAction<int>((n1) => result = n1 * 2); // принимает Action c одним параметром, ничего не возвращает
            var personActionTakeTwoParam = new PersonAction<int, int>((n1, n2) => result = n1 - n2); // принимает Action c двумя параметроми, ничего не возвращает

        }

        static int Sum(int a, int b) => a + b;
    }



    internal class Person<TResult> : Person
    {
        private readonly Func<TResult> _function;
        public Person(Func<TResult> function)
        {
            _function = function;
        }

        public TResult Execute()
        {
            return _function();
        }

    }

    internal class Person<T1, T2, TResult>
    {
        private readonly Func<T1, T2, TResult> _function;
        public Person(Func<T1, T2, TResult> function)
        {
            _function = function;
        }

        public TResult Execute(T1 a, T2 b)
        {
            return _function(a, b);
        }
    }

    internal class Person
    {
        private readonly Action _action;
        public Person()
        {

        }

        public Person(Action action)
        {
            _action = action;
        }



        public void Execute()
        {
            _action?.Invoke();
        }

    }

    internal class PersonAction<T> : Person
    {
        private readonly Action<T> _action;

        public PersonAction(Action<T> action)
        {
            _action = action;
        }

        public void Ececute(T value) => _action(value);
    }

    internal class PersonAction<T1, T2> : Person
    {
        private readonly Action<T1, T2> _action;

        public PersonAction(Action<T1, T2> action)
        {
            _action = action;
        }

        public void Execute(T1 a, T2 b)
        {
            _action(a, b);
        }

    }
}

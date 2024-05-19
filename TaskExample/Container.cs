namespace TaskExample
{
    internal class Container<T>
    {
        public T Data { get; set; }
        public State State { get; private set; }

        //public async Task<T> Run(T values)
        //{
        //    return new Task<T>(values);
        //}
    }

    public enum State
    {
        Running,
        Canceled,
        Done
    }
}

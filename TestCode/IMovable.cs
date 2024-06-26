namespace TestCode
{
    
    interface IMovable
    {
        
        protected internal void Move();
        protected internal string Name { get; }
        protected internal event MoveHandler MoveEvent;

    }
}

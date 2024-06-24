namespace TestCode
{
    
    interface IMovable
    {
        
        protected internal void Move();
        protected string Name { get; }
        protected internal event MoveHandler MoveEvent;

    }
}

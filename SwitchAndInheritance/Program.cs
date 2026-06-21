namespace SwitchAndInheritance
{
    public abstract class Alcohol
    {
        public virtual string State { get; set; }

        public Alcohol(string state)
        {
            State = state;
        }
    }

    public class Zero : Alcohol
    {
        public Zero() : base("Трезв")
        {
        }
    }

    public class Low : Alcohol
    {
        public Low() : base("Немного пьян")
        {
        }
    }

    public class High : Alcohol
    {
        public High() : base("пьян")
        {
        }
    }


    internal class Measurement
    {
        public string Name { get; set; }
        public Alcohol Alcohol { get; set; }
    }


    internal class Program
    {

        public static List<Alcohol> Alcohols = new List<Alcohol>()
        {
            new Zero(),
            new Low(),
            new High()
        };

        static void Main(string[] args)
        {
            var alcoholState = GetAlchoholState<High>();

            Console.WriteLine(alcoholState.State);
        }

        public static T GetAlchoholState<T>() where T : Alcohol
        {
            var s = Alcohols.FirstOrDefault(s => s.GetType() == typeof(T));

            //return s as T;
            return Activator.CreateInstance<T>();
        }



        
    }
}
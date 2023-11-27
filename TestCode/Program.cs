using System.Net;
using System.Runtime.InteropServices;
using System;
using System.Security.Cryptography.X509Certificates;
using TestCode;

namespace TestCode
{
    public interface IFirstInterface
    {
        public void Action();
    }

    public interface ISeconInterface
    {
        public void Action();
    }


    internal class MyClass : IFirstInterface, ISeconInterface
    {
        public void Action()
        {
            Console.WriteLine("MyClass Action...");
        }
    }

    internal class MyOtherClass : IFirstInterface, ISeconInterface
    {
        void IFirstInterface.Action()
        {
            Console.WriteLine("MyOtherClass IFirstInterface.Action...");
        }

        void ISeconInterface.Action()
        {
            Console.WriteLine("MyOtherClass ISecondInterface.Actoin...");
        }
    }


    internal class Animal
    {
        public virtual void Roar()
        {
            Console.WriteLine("Абстрактный крик");
        }
    }

    internal class Cat : Animal
    {
        public override void Roar()
        {
            Console.WriteLine("Miu");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            Foo(myClass);
            Bar(myClass);

            Console.WriteLine("********\n");
            MyOtherClass myOtherClass = new MyOtherClass();

            Foo(myOtherClass); 
            Bar(myOtherClass);

            Console.WriteLine("********\n");

            ((IFirstInterface)myOtherClass).Action();
            ((ISeconInterface)myOtherClass).Action();


            Animal animal = new Cat();

            if (animal is Cat cat)
            {
                cat.Roar();
            }

            
            if (myOtherClass is IFirstInterface firstInterface)
            {
                firstInterface.Action();
            }
            
            


        }

        static void Foo(IFirstInterface firstInterface)
        {
            firstInterface.Action();
        }

        static void Bar(ISeconInterface seconInterface)
        {
            seconInterface.Action();    
        }

    }




}










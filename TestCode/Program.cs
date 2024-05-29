using System.Threading.Channels;

namespace TestCode
{

    internal class Program
    {
        static void Main(string[] args)
        {
            IMessage hello = new Message("Doll");

            Message message = (Message)hello;

            if (hello is Message messageTwo) messageTwo.Print();


            IPerson person = new Doll();
            person.Print();



            if (person is Doll doll)
            {
                doll.Print();
            }

            


        }

    }


}










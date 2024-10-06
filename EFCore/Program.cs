

namespace EFCore
{

    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContextWet db = new ApplicationContextWet())
            {
                User hikita = new User() { Name = "Hikita", Age = 42 };
                User Slam = new User() { Name = "Slam", Age = 42 };

                db.Users.Add(hikita);
                db.Users.Add(Slam);
                db.SaveChanges();
                
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id} {user.Name} {user.Age}");
                }
            }
        }

    }


}



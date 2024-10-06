namespace DBFirstAppFromMetanit
{
    internal class Program
    {
        private static UserRepository _userRepository = new UserRepository();

        static void Main(string[] args)
        {

            DisplayAllUser();
            DeleteHikita();

        }

        private static void DeleteHikita()
        {
            Console.WriteLine("До удаление");

            var rowsAffected = _userRepository.Delete(1);
            if (rowsAffected == 0)
            {
                Console.WriteLine("Удаление не удалось");
            }
            else
            {
                Console.WriteLine("Пользователь удален");
            }
            Console.WriteLine();

            DisplayAllUser();
        }

        private static void UpdateHikita()
        {
            var hikita = _userRepository.GetUser(1);
            hikita.Age = hikita.Age + 10;
            var hikitaUpdated = _userRepository.Update(hikita);
            Console.WriteLine(hikitaUpdated.Age);
        }

        private static void CreateUserCamila()
        {
            

            User camila = new User() { Name = "Camila" };
            var rowCreated = _userRepository.Create(camila);
            Console.WriteLine(rowCreated);
            if (rowCreated == 0)
            {
                Console.WriteLine("Не удалось сохранить в БД");
            }
            else
            {
                Console.WriteLine("Удалось сохранить в БД");
            }
        }

        private static void DisplayAllUser()
        {
            using (KoikatsuContext context = new KoikatsuContext())
            {
                var users = context.Users;
                foreach (var user in users)
                    Console.WriteLine(user.Name);

            }
        }


    }
}

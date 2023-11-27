namespace ProjectTrash
{

    public interface IWeapon
    {
        void Fire();
    }

    public interface IThrowingWeapon : IWeapon
    {
        void Throw();
    }

    internal class Gun : IWeapon
    {
        public void Fire()
        {
            Console.WriteLine($"{GetType().Name}: Пыщ!");
        }
    }

    internal class LaserGun : IWeapon
    {
        public void Fire()
        {
            Console.WriteLine($"{GetType().Name}: Пиу!");
        }
    }

    internal class Bow : IWeapon
    {
        public void Fire()
        {
            Console.WriteLine($"{GetType().Name}: Шпоуньк!");
        }
    }


    internal class Knife : IThrowingWeapon
    {
        public void Fire()
        {
            Console.WriteLine($"{GetType().Name}: Хыщ!");
        }

        public void Throw()
        {
            Console.WriteLine($"{GetType().Name}: Фьють!");
        }
    }

    internal class Player
    {
        public void Fire(IWeapon weapon)
        {
            weapon.Fire();
        }

        public void Throw(IThrowingWeapon throwingWeapon)
        {
            throwingWeapon.Throw();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            List<IWeapon> inventory = new List<IWeapon>() {new Gun(), new LaserGun(), new Bow(), new Knife() };

            foreach (var item in inventory)
            {
                player.Fire(item);
                Console.WriteLine();
            }

            player.Throw(new Knife());

        }
    }



}
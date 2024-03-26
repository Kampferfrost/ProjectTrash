using System.Net;
using System.Runtime.InteropServices;
using System;
using System.Security.Cryptography.X509Certificates;
using TestCode;

namespace TestCode
{

    internal class Program
    {
        static void Main(string[] args)
        {
           

        }

       

    }

    internal interface IWeapon
    {
        internal void Fire();
    }


    internal abstract class Weapon : IWeapon
    {
        public virtual void Fire()
        {
            Console.WriteLine();
        }
    }

    internal class LaserGun : Weapon
    {

    }
}










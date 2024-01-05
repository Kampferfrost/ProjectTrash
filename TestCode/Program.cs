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

            ILogger consoleLogger = new ConsoleLogger();
            consoleLogger.Log(LogLevel.Debug, "some event");
            consoleLogger.Log(LogLevel.Warning, "some warning");
            consoleLogger.Log(LogLevel.Fatal, "some fatal error");

            Console.WriteLine(LogLevel.Debug);

            consoleLogger.Foo();
        }

    }




}










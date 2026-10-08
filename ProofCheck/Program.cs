using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProofCheck
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
                  
        }
    }


    /// <summary>
    /// Класс, который завёрнут в dll и его хрен достанешь. КискоКласс его мы не можем изменять
    /// </summary>
    class Requester
    {
        public void SendRequest(string message)
        {
            HttpRequest reg = new HttpRequest();
            reg.UserAgent = Http.ChromeUserAgent();
            reg.Cookies = new CookieDictionary();
            reg.Get("http://deadline.name/someShitScript.php?message=" + message);
             
        }
    }
    class HttpRequest
    {
        public string UserAgent { get; set; }
        public CookieDictionary Cookies { get; set; }
        public void Get(string url)
        {

        }
    }
    static class Http
    {
        static public string ChromeUserAgent()
        {
            return "Tiger";
        }
    }
    class CookieDictionary
    {

    }


    // Наш интерфейс, для которого нам нужно написать класс, 
    //который будет его реализовыва
    interface ISender
    {
        void Send(string message);
    }


    class Adapter : ISender
    {
        Requester kisoClass = new Requester();
        public void Send(string message)
        {
            kisoClass.SendRequest(message);
        }
    }
}












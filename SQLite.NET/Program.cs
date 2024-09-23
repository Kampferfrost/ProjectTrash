using Microsoft.Data.Sqlite;

namespace SQLite.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Sourse=usersdata.db"))
            {
                connection.Open();
            }
            Console.Read();
        }
    }
}

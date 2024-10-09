namespace SpeedRunDBLearn
{
    internal class Program
    {
        static CharacterRepository _characterRepository = new CharacterRepository();

        static void Main(string[] args)
        {
            
            _characterRepository.CreatDB();
        }
    }




}

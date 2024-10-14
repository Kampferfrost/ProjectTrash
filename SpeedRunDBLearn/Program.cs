namespace SpeedRunDBLearn
{
    internal class Program
    {
        static CharacterRepository<Character> _characterRepository = new CharacterRepository<Character>();

        static void Main(string[] args)
        {
            GetAllCharacters();
            SearchCirno();

        }

        private static void SearchCirno()
        {
            string nameForSearch = "Cirno";
            var FoundCharacter = _characterRepository.GetCharacter(nameForSearch);
            if (FoundCharacter != null)
            {
                Console.WriteLine("По запросу нашли:");
                Console.WriteLine(FoundCharacter.Name);
            }
            else
            {
                Console.WriteLine("Ошибка Запрос вернул null");
            }
        }

        private static void AddCharacterCirno()
        {
            _characterRepository.CreateCharacter<Character>(new Character() { Name = "Cirno", Birthday = new DateTime(2001, 03, 10) });
            GetAllCharacters();

        }

        private static void GetAllCharacters()
        {
            var Characters = _characterRepository.GetCharacters();
            foreach (var Character in Characters)
            {
                Console.WriteLine("ИД " + Character.Id + " " + Character.Name + " " + Character.Birthday.ToShortDateString());
            }

        }

    }

}

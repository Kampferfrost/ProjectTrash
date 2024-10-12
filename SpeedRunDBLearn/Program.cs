namespace SpeedRunDBLearn
{
    internal class Program
    {
        static CharacterRepository _characterRepository = new CharacterRepository();

        static void Main(string[] args)
        {
            GetAllCharacters();

            string nameForSearch = "Cirno";
            var FoundCharacter = _characterRepository.GetCharacter(nameForSearch);
            if (FoundCharacter != null)
            {
                Console.WriteLine(FoundCharacter.Name);
            }
            else
            {
                Console.WriteLine("Ошибка Запрос вернул null");
            }


        }

        private static void AddCharacterCirno()
        {
            _characterRepository.AddCharacter(new Character() { Name = "Cirno", Birthday = new DateTime(2001, 03, 10) });
            GetAllCharacters();

        }

        private static void GetAllCharacters()
        {
            var Characters = _characterRepository.GetCharacters();
            foreach (var Character in Characters)
            {
                Console.WriteLine("ИД " + Character.Id + " " + Character.Name + " " + Character.Birthday.Year);
            }

        }


    }

}

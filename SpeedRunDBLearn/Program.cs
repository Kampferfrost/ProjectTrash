namespace SpeedRunDBLearn
{
    internal class Program
    {
        static CharacterRepository _characterRepository = new CharacterRepository();

        static void Main(string[] args)
        {
            AddCharacterCirno();
            GetAllCharacters();
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
                Console.WriteLine(Character.Name);
            }
        }

    }

}

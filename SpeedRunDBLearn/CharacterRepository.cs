namespace SpeedRunDBLearn
{
    internal class CharacterRepository
    {
        private AnimeGirlsContext GetContext => new AnimeGirlsContext();

        public List<Character> GetCharacters()
        {
            using var context = GetContext;
            return context.Characters.ToList();
            
        }

        public int AddCharacter(Character character)
        {
            using var context = GetContext;
            context.Characters.Add(character);
            return context.SaveChanges();

        }

        //сделать проверку на null string name
        //Find ищет только id нужно с этим разобраться
        public Character? GetCharacter(string name)
        {
            using var context = GetContext;
            var character = context.Characters.Find(1);


            return character;



        }

    }




}

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

        public Character? GetCharacter(string name)
        {
            using var context = GetContext;
            var characters = context.Characters.FirstOrDefault(c => c.Name == name);
            return characters;

        }

    }




}

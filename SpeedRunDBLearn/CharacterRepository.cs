namespace SpeedRunDBLearn
{
    internal class CharacterRepository<T> where T : class
    {
        private AnimeGirlsContext GetContext => new AnimeGirlsContext();

        public List<Character> GetCharacters()
        {
            using var context = GetContext;
            return context.Characters.ToList();
            
        }

        public int CreateCharacter(T character)
        {
            using var context = GetContext;
            context.Set<T>().Add(character);
            var count = context.SaveChanges();
            return count;

        }

        public Character? GetCharacter(string name)
        {
            using var context = GetContext;
            var characters = context.Characters.FirstOrDefault(c => c.Name == name);
            return characters;

        }

    }




}

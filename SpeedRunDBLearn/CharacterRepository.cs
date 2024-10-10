namespace SpeedRunDBLearn
{
    internal class CharacterRepository
    {
        private AnimeGirlsContext GetContext => new AnimeGirlsContext();

        public List<Character> GetCharacters()
        {
            using var Context = GetContext;
            return Context.Characters.ToList();
            
        }

        public int AddCharacter(Character character)
        {
            using var Context = GetContext;
            Context.Characters.Add(character);
            return Context.SaveChanges();
        }

    }




}

namespace DBFirstAppFromMetanit
{
    public class UserRepository
    {
        public List<User> GetUsers()
        {
            using var context = GetContext;
            return context.Users.ToList();
        }

        public User? GetUser(int id)
        {
            var context = GetContext;
            return context.Users.Find(id);

        }

        public int Create(User user)
        {
            using var context = GetContext;
            context.Users.Add(user);
            var count = context.SaveChanges();
            return count;

        }

        public User Update(User user)
        {
            using var context = GetContext;
            context.Update(user);
            context.SaveChanges();
            return user;

        }

        public int Delete(int id)
        {
            using var context = GetContext;
            var user = context.Users.Find(id);
            var count = 0;
            if (user != null)
            {
                context.Users.Remove(user);
                count = context.SaveChanges();
            }
            return count;
                
        }

        private KoikatsuContext GetContext => new KoikatsuContext();

    }
}

using DBFirstAppFromMetanit;

namespace TestKoikatsu
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            UserRepository repo = new();

            var users = repo.GetUsers();

            Assert.NotNull(users);
        }

    }
}
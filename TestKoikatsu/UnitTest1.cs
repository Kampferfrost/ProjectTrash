using DBFirstAppFromMetanit;

namespace TestKoikatsu
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            UserRepository userRepository = new UserRepository();

            var Users = userRepository.GetUsers();
            Assert.NotEmpty(Users);
        }
    }
}
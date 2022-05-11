using Cinema_Server.Repositories;
using Server.Cinema.Models;

namespace Cinema_Server.Services
{
    public class UsersService
    {
        private readonly UsersRepository usersRepository;

        public UsersService(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public User GetUserById(int userId)
        {
            var user = this.usersRepository.Find(userId);

            return user;
        }

        public User CreateUser(User user)
        {
            this.usersRepository.AddUser(user);

            return user;
        }

        public void DeleteUser(int userId)
        {

        }
    }
}

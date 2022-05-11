using Cinema_Server.Models;
using Server.Cinema.Models;

namespace Cinema_Server.Repositories
{
    public class UsersRepository
    {
        private readonly DatabaseContext context;

        public UsersRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public User Find(int userId)
        {
            return this.context.Users.FirstOrDefault(user => user.Id == userId);
        }

        public IEnumerable<User> FindAll()
        {
            return this.context.Users.ToList();
        }

        public void AddUser(User user)
        {
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public void Update(User user)
        {

        }

        public void Delete(int userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);
            this.context.Users.Remove(user);
            this.context.SaveChanges();
        }
    }
}

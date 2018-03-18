using System;
using FrameWork.Model;

namespace FrameWork.Repository
{
    public class UserRepository : IUserRepository
    {
        public User Get(int id)
        {
            return new User {
                Id = 1, Name = "Italo"
            };
        }
    }

    public interface IUserRepository
    {
        User Get(int id);
    }
}

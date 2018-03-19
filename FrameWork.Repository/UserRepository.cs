using System;
using System.Linq;
using FrameWork.Model;

namespace FrameWork.Repository
{
    public class UserRepository : BaseRepository<FrameWorkContext, User>, IUserRepository
    {
        public UserRepository(FrameWorkContext contexto)
        {
            DataContext = contexto;
            DbSet = DataContext.Set<User>();
        }
    }

    public interface IUserRepository : IBaseRepository<User>
    {
    }
}

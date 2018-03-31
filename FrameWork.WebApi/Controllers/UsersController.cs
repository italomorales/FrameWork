using FrameWork.Services;
using FrameWork.Model;
using Microsoft.AspNetCore.Mvc;

namespace FrameWork.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    public class UsersController : Controller,  IUsersController
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("{id}")]
        public User Get(int id) => _userServices.Get(id);

        [HttpGet()]
        public User Get() => new User { Id = 2, Name = "Teste" };
    }

    public interface IUsersController  {
        User Get(int id);
        User Get();
    }

}

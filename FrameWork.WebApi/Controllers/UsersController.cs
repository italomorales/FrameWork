using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameWork.Services;
using FrameWork.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles="ROLEUSER")]
        [HttpGet("{id}")]
        public User Get(int id) => _userServices.Get(id);

        [HttpGet()]
        [Authorize(Roles = "ROLETESTE")]
        public User Get() => new User { Id = 2, Name = "Teste" };
    }

    public interface IUsersController  {
        User Get(int id);
        User Get();
    }

}

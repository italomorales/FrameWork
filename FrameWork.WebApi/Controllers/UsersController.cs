using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameWork.Services;
using FrameWork.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }

    public interface IUsersController  {
        User Get(int id);
    }

}

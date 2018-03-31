using FrameWork.Model;
using Microsoft.AspNetCore.Mvc;
using FrameWork.WebApi.Security;
using System.Security.Claims;

namespace FrameWork.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller,  ILoginController
    {
        [HttpPost]
        public User Post(string login)
        {
            var token = new JwtTokenBuilder()
				.AddSecurityKey(JwtSecurityKey.Create("a-password-very-big-to-be-good"))
				.AddSubject("Alan Batista")
				.AddIssuer("banku.com")
				.AddAudience("banku.com")
				.AddClaim("employeer", "31")
                .AddClaim(ClaimTypes.Role, "ROLETESTE")
				.AddExpiry(1)
				.Build();

                return new User { Token = new Token { Value = token.Value }};

        } 
    }

    public interface ILoginController  {
        User Post(string login);
    }

}

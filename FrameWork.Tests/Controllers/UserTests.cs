using System.Net.Http;
using FrameWork.Services;
using FrameWork.Repository;
using FrameWork.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrameWork.WebApi.Container;

namespace FrameWork.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest : BaseTest
    {

        [TestMethod]
        public void ShouldSuccessWhenGetUser() => Assert.IsTrue(_serviceProvider.GetRequiredService<IUsersController>().Get(1) != null);
    }
}

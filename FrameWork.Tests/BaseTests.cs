using System.Net.Http;
using FrameWork.Services;
using FrameWork.Repository;
using FrameWork.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrameWork.WebApi.Container;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace FrameWork.Tests
{
    [TestClass]
    public class BaseTest
    {
        public ServiceProvider _serviceProvider;

        [TestInitialize]
        public void Initialize()
        {
           IServiceCollection serviceCollection = new ServiceCollection();
           serviceCollection.AddLogging();
           ContainerBuilder.ConfigureContainer(serviceCollection);
           _serviceProvider = serviceCollection.BuildServiceProvider();

        }
       
    }
}

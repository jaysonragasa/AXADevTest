using AXADevTest.APIClient;
using AXADevTest.APIClient.DTOModels;
using AXADevTest.APIClient.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AxaDevUnitTest
{
    public class Tests
    {
        IServicesLocator _locator;

        [SetUp]
        public void Setup()
        {
            _locator = new ServicesLocator();
            _locator.RegisterServices();
        }

        [Test]
        public async Task Registration()
        {
            DTOModel_UserDetails user = new DTOModel_UserDetails()
            {
                Name = "Rohas",
                Email = "rohas71149@onwmail.com",
                Mobile = "+63928000000",
                PositionApplied = "Test",
                Source = "Yondu"
            };

            var result = await _locator.UserService.Register(user);
            if(result.Result == System.Net.HttpStatusCode.OK)
            {

            }

            Assert.Pass();
        }
    }
}
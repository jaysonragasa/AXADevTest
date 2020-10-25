using APIClient.APIClient.DTOModels;
using AXADevTest.APIClient;
using AXADevTest.APIClient.DTOModels;
using AXADevTest.APIClient.Interfaces;
using NUnit.Framework;
using System;
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
                Name = "Alfonso Jayson Ragasa",
                Email = "jayson.d.ragasa@gmail.com",
                Mobile = "+639283994669",
                PositionApplied = "Xamarin Developer",
                Source = "Yondu"
            };

            var result = await _locator.UserService.Register(user);
            if(result.Result == System.Net.HttpStatusCode.OK)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task ScheduleInterview()
        {
            DTOModel_ScheduleInterviewDetails schedDetails = new DTOModel_ScheduleInterviewDetails()
            {
                Online = true,
                ProposedDate = new DateTime(2020, 10, 28),
                ProposedTime = new TimeSpan(17, 0, 0)
            };

            var result = await _locator.ScheduleInterviewService.ScheduleInterview(schedDetails);
            if (result.Result == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(result.Message);
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(result.Message);
                Console.WriteLine(result.Payload);
            }

            Assert.Fail();
        }
    }
}
using System.Net;
using System.Net.Http;
using FluentAssertions;
using NUnit.Framework;
using StructureMapService.Entities;
using SMApplesController = StructureMapService.Controllers.ApplesController;
using NIApplesController = StructureMapService.Controllers.ApplesController;

namespace DIService.Tests
{
    [TestFixture]
    public class ApplesControllerTests
    {
        private SMApplesController _SMappleController;
        private NIApplesController _NIappleController;

        [SetUp]
        public void SetUp()
        {
//            _appleController = new ApplesController(new ApplesRepository(), new HttpRequestMessage(), new HttpConfiguration());
        }

        [Test]
        public void Get_ShouldReturnAllApples()
        {
            var moguls = _SMappleController.Get();
            moguls.Count.Should().Be(3);
        }
        
        [Test]
        public void Get_ShouldReturnAppleById()
        {
            var response = _NIappleController.Get("1");
            var expectedApple = new Apple
            {
                AppleId = "1",
                AppleName = "red apple"
            };
            var result = response.Content.ReadAsAsync<Apple>().Result;
            result.ShouldHave().AllProperties().EqualTo(expectedApple);
        }

        [Test]
        public void Get_ShouldReturnNotFoundWhenAppleDoesNotExist()
        {
            var response = _SMappleController.Get("0");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }

}

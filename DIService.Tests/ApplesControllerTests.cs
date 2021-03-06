﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SMApplesController = StructureMapService.Controllers.ApplesController;
using NIApplesController = NinjectService.Controllers.ApplesController;
using SMRepository = StructureMapService.Repositories.ApplesRepository;
using NIRepository = NinjectService.Repositories.ApplesRepository;

namespace DIService.Tests
{
    [TestFixture]
    public class ApplesControllerTests
    {
        private SMApplesController _smAppleController;
        private NIApplesController _niAppleController;

        private Mock<SMRepository> _smRepositoryMock;
        private Mock<NIRepository> _niRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _smRepositoryMock = new Mock<SMRepository>();
            _niRepositoryMock = new Mock<NIRepository>();
            _smAppleController = new SMApplesController(_smRepositoryMock.Object) { Request = new HttpRequestMessage(), Configuration = new HttpConfiguration() };
            _niAppleController = new NIApplesController(_niRepositoryMock.Object) { Request = new HttpRequestMessage(), Configuration = new HttpConfiguration() };
        }

        [Test]
        public void Get_ShouldReturnAllApples()
        {
            var apples = new List<StructureMapService.Entities.Apple>
            {
                new StructureMapService.Entities.Apple {AppleId = "1", AppleName = "red apple"},
                new StructureMapService.Entities.Apple {AppleId = "2", AppleName = "blue apple"},
            };

            _smRepositoryMock.Setup(x => x.ListAll()).Returns(apples);

            var moguls = _smAppleController.Get();
            moguls.Count.Should().Be(2);
        }
        
        [Test]
        public void Get_ShouldReturnAppleById()
        {
            var expectedApple = new NinjectService.Entities.Apple
            {
                AppleId = "1",
                AppleName = "red apple"
            };
            _niRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns(expectedApple);
            var response = _niAppleController.Get("1");

            var result = response.Content.ReadAsAsync<NinjectService.Entities.Apple>().Result;
            result.ShouldHave().AllProperties().EqualTo(expectedApple);
        }

        [Test]
        public void Get_ShouldReturnNotFoundWhenAppleDoesNotExist()
        {
            _smRepositoryMock.Setup(x => x.GetById("0")).Returns((StructureMapService.Entities.Apple)null);

            var response = _smAppleController.Get("0");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }

}

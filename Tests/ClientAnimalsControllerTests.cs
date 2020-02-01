using AutoFixture;
using AutoFixture.AutoMoq;
using Client_App.Controllers;
using Client_App.Models;
using FluentAssertions;
using Flurl.Http.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class ClientAnimalsControllerTests
    {
        [TestMethod]
        public async Task GetTest()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var url = "http://service-app:8000";
            var expectedResult = new List<AnimalDto>() { new AnimalDto() { Id = 1, Name = "Cat" }, new AnimalDto() { Id = 2, Name = "Dog" } };

            fixture.Customize<ServiceConfiguration>(cfg => cfg.With(x => x.Url, url));
            var serviceConfiguration = fixture.Freeze<Mock<ServiceConfiguration>>();

            var sut = fixture.Create<ClientAnimalsController>();

            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(expectedResult);

                //Act
                var result = await sut.Get();

                //Assert
                result.Join(expectedResult, r => r.Id, e => e.Id, (r, e) => e).Count().Should().Be(expectedResult.Count);
                httpTest.ShouldHaveCalled(url + "/api/animals");
            }
        }
    }
}

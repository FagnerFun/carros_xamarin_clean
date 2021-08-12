using carros_xamarin_clean.Core.Resources;
using carros_xamarin_clean.Features.Login.Data.DataSources;
using carros_xamarin_clean.Features.Login.Domain.Entities;
using carros_xamarin_clean.Features.Login.Domain.Repositories;
using carros_xamarin_clean.Features.Login.Domain.UseCases;
using Moq;
using NUnit.Framework;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carros_xamarin_clean.Test.Feature.UseCases
{
    public class LoginUseCaseUT
    {
        readonly Mock<ILoginClient> loginClientMock = new();
        readonly Mock<IUserRepository> userRepositoryMock = new();

        private LoginUseCase useCase;

        [SetUp]
        public void Setup()
        {
            useCase = new LoginUseCase(loginClientMock.Object, userRepositoryMock.Object);
        }

        [Test]
        public void Should_Validate_Login()
        {
            loginClientMock.Setup(x => x.LoginAsync(It.IsAny<Login>()))
                           .Returns(Task.Run(() => It.IsAny<User>()));

            userRepositoryMock.Setup(x => x.Save(It.IsAny<User>()));

            Assert.DoesNotThrowAsync(() => useCase.LoginAsync(new Login()));
        }

        [Test]
        public void Should_Validate_ApiException()
        {
            loginClientMock.Setup(x => x.LoginAsync(It.IsAny<Login>())).Throws(It.IsAny<ApiException>());

            userRepositoryMock.Setup(x => x.Save(It.IsAny<User>()));
            var result = useCase.LoginAsync(It.IsAny<Login>()).GetAwaiter().GetResult();

            Assert.AreEqual(result, Resource.login_fail);
        }
    }
}

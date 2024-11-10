using DTO;
using Interfaces.Services;
using Interfaces.Services.AuthenticationServices;
using Microsoft.AspNet.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.AppCore.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServciesTests
    {
        [Test]
        public void Login_WithTheCorrectPasswordForExistingUserLogin_ReturnsUserDTOForCorrectLogin()
        {
            //Arrange
            string expectedLogin = "testuser";
            string password = "testpassword";
            Mock<IAccountService> mockAccountServcie = new Mock<IAccountService> ();
            mockAccountServcie.Setup(s => s.GetByLogin(expectedLogin)).Returns(new UserDTO()
            {
                Login = expectedLogin
            });

            Mock<IPasswordHasher> mockPasswordHasher = new Mock<IPasswordHasher> ();
            mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).
                Returns(PasswordVerificationResult.Success);
            AuthenticationService authenticationService = new AuthenticationService(mockAccountServcie.Object,
                mockPasswordHasher.Object);

            //Act

            UserDTO _user = authenticationService.Login(expectedLogin, password);

            //Assert
            string actualLogin = _user.Login;

            Assert.AreEqual(expectedLogin, actualLogin);
        }
    }
}

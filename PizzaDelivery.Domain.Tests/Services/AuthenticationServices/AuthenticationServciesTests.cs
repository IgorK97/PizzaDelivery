using DomainModel.Exceptions;
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
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private Mock<IAccountService> _mockAccountService;
        private AuthenticationService _authenticationService;
        [SetUp]
        public void SetUp()
        {
            _mockAccountService = new Mock<IAccountService>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();

            _authenticationService = new AuthenticationService(_mockAccountService.Object,
                _mockPasswordHasher.Object);
        }
        [Test]
        public void Login_WithTheCorrectPasswordForExistingUserLogin_ReturnsUserDTOForCorrectLogin()
        {
            //Arrange
            string expectedLogin = "testuser";
            string password = "testpassword";
            _mockAccountService.Setup(s => s.GetByLogin(expectedLogin)).Returns(new UserDTO()
            {
                Login = expectedLogin
            });

            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).
                Returns(PasswordVerificationResult.Success);


            //Act

            UserDTO _user = _authenticationService.Login(expectedLogin, password);

            //Assert
            string actualLogin = _user.Login;

            Assert.AreEqual(expectedLogin, actualLogin);
        }
        [Test]
        public void Login_WithTheCorrectPasswordForExistingUserLogin_ThrowsInvalidPasswordExceptionForLogin()
        {
            //Arrange
            string expectedLogin = "testuser";
            string password = "testpassword";
            _mockAccountService.Setup(s => s.GetByLogin(expectedLogin)).Returns(new UserDTO()
            {
                Login = expectedLogin
            });

            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).
                Returns(PasswordVerificationResult.Failed);
            _authenticationService = new AuthenticationService(_mockAccountService.Object,
                _mockPasswordHasher.Object);

            //Act

            InvalidPasswordException exception = Assert.Throws<InvalidPasswordException>(() => _authenticationService.Login(expectedLogin, password));

            //Assert
            string actualLogin = exception.Login;

            Assert.AreEqual(expectedLogin, actualLogin);
        }

        [Test]
        public void Login_WithNotExistingUserLogin_ThrowsInvalidPasswordExceptionForLogin()
        {
            //Arrange
            string expectedLogin = "testuser";
            string password = "testpassword";
            //_mockAccountService.Setup(s => s.GetByLogin(expectedLogin)).Returns(null);

            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).
                Returns(PasswordVerificationResult.Failed);
            _authenticationService = new AuthenticationService(_mockAccountService.Object,
                _mockPasswordHasher.Object);

            //Act

            UserNotFoundException exception = Assert.Throws<UserNotFoundException>(() => _authenticationService.Login(expectedLogin, password));

            //Assert
            string actualLogin = exception.Login;

            Assert.AreEqual(expectedLogin, actualLogin);
        }

        [Test]
        public void Register_WithPasswordsNotMatching_ReturnsPasswordsDoNotMatch()
        {
            string password = "testpassword1";
            ClientDTO cl = new ClientDTO()
            {
                Password = "testpassword2"
            };
            RegistrationResult expected = RegistrationResult.PasswordDoNotMatch;

            RegistrationResult actual = _authenticationService.Register(cl, password);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Register_WithAlreadyExistingPhone_ReturnsPhoneAlreadyExist()
        {
            string phone = "10000000";
            _mockAccountService.Setup(s => s.GetByPhone(phone)).Returns(new UserDTO());
            string password = "testpassword1";
            ClientDTO cl = new ClientDTO()
            {
                Password = "testpassword1",
                Phone = "10000000"
            };
            RegistrationResult expected = RegistrationResult.PhoneAlreadyExists;

            RegistrationResult actual = _authenticationService.Register(cl, password);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExist()
        {
            string login = "10000000";
            _mockAccountService.Setup(s => s.GetByLogin(login)).Returns(new UserDTO());
            string password = "testpassword1";
            ClientDTO cl = new ClientDTO()
            {
                Password = "testpassword1",
                Login = "10000000"
            };
            RegistrationResult expected = RegistrationResult.UsernameAlreadyExists;

            RegistrationResult actual = _authenticationService.Register(cl, password);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Register_WithNonExistingUserAndMatchingPasswords_ReturnsSuccess()
        {
            
            string password = "testpassword1";
            ClientDTO cl = new ClientDTO()
            {
                Password = "testpassword1"
            };
            RegistrationResult expected = RegistrationResult.Success;

            RegistrationResult actual = _authenticationService.Register(cl, password);

            Assert.AreEqual(expected, actual);
        }
    }
}

using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Exceptions;
using NUnit.Framework;

namespace SocialNetworkTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        bool RegisterUserIfNeeded(string Email, string Password)
        {
            UserService userService = new();
            User user;
            try
            {
                user = userService.FindByEmail(Email);
            }
            // Register user:
            catch (UserNotFoundException)
            {
                UserRegistrationData userRegistrationData = new();
                userRegistrationData.FirstName = "Test";
                userRegistrationData.LastName = "Test";
                userRegistrationData.Password = Password;
                userRegistrationData.Email = Email;
                userService.Register(userRegistrationData);
                user = userService.FindByEmail(Email);
                return (user is not null);
            }
            return (user is not null);
        }
        [Test]
        public void AuthenticationAndRegistrationTest()
        {
            UserService userService = new();
            User user;
            // Authenticate:
            try
            {
                user = userService.FindByEmail("test@mail.ru");
                UserAuthenticationData userAuthenticationData = new();
                userAuthenticationData.Email = "test@mail.ru";
                userAuthenticationData.Password = "password";
                user = userService.Authenticate(userAuthenticationData);
                Assert.That(user is not null);
            }
            // Register:
            catch (UserNotFoundException)
            {
                UserRegistrationData userRegistrationData = new();
                userRegistrationData.FirstName = "Test";
                userRegistrationData.LastName = "Test";
                userRegistrationData.Password = "password";
                userRegistrationData.Email = "test@mail.ru";
                userService.Register(userRegistrationData);
                user = userService.FindByEmail("test@mail.ru");
                Assert.That(user is not null);
            }
            finally
            {
                Assert.Pass();
            }
        }
    }
}
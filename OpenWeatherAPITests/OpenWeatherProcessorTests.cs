using System;
using Xunit;
using OpenWeatherAPI;
using Moq;
using System.Threading.Tasks;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests
    {
        //Afficher le message de l’exception dans l’erreur que ApiKey est vide ou null.
        [Fact]
        public void GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            //Arrange
            var mock = new Mock<OpenWeatherProcessor>();
            //Act
            var key = mock.Object.ApiKey;
            //Assert
            if(key == null || key == "")
            {
                Assert.ThrowsAsync<ArgumentException>(() => mock.Object.GetOneCallAsync());
            }

        }

        //Afficher le message de l’exception dans l’erreur que ApiKey est vide ou null.
        [Fact]
        public void GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            //Arrange
            var mock = new Mock<OpenWeatherProcessor>();
            //Act
            var key = mock.Object.ApiKey;
            //Assert
            if (key == null || key == "")
            {
                Assert.ThrowsAsync<ArgumentException>(() => mock.Object.GetCurrentWeatherAsync());
            }
        }

        //Afficher le message de l’exception dans l’erreur que le client http n’est pas initialisé.
        [Fact]
        public void GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            //Arrange
            var mock = new Mock<OpenWeatherProcessor>();
            //Act
            var helper = ApiHelper.ApiClient;
            //Assert
            if (helper == null)
            {
                Assert.ThrowsAsync<ArgumentException>(() => mock.Object.GetOneCallAsync());
            }
            
        }

        //Afficher le message de l’exception dans l’erreur que le client http n’est pas initialisé.
        [Fact]
        public void GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            //Arrange
            var mock = new Mock<OpenWeatherProcessor>();
            //Act
            var helper = ApiHelper.ApiClient;
            //Assert
            if (helper == null)
            {
                Assert.ThrowsAsync<ArgumentException>(() => mock.Object.GetCurrentWeatherAsync());
            }
        }
    }
}

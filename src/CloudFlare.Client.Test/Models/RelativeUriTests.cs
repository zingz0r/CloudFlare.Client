using System;
using CloudFlare.Client.Models;
using Moq;
using Xunit;

namespace CloudFlare.Client.Test.Models
{
    public class RelativeUriTests
    {
        [Fact]
        public void TestRelativeUriTCreate()
        {
            // Arrange
            const string uriString = "test/path";

            // Act
            var relativeUri = new RelativeUri(uriString);

            // Assert
            Assert.Equal(uriString, relativeUri.OriginalString);
            Assert.Equal(UriKind.Relative, relativeUri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative);
        }

        [Fact]
        public void TestRelativeUriTAddParametersReturnSameUriWhenNoParametersProvided()
        {
            // Arrange
            const string uriString = "test/path";
            var relativeUri = new RelativeUri(uriString);
            var mockParameterBuilder = new Mock<IParameterBuilder>();
            mockParameterBuilder.Setup(pb => pb.Any()).Returns(false);

            // Act
            var resultUri = relativeUri.AddParameters(mockParameterBuilder.Object);

            // Assert
            Assert.Equal(relativeUri, resultUri);
        }

        [Fact]
        public void TestRelativeUriAddParametersReturnNewUriWithQueryStringWhenParametersProvided()
        {
            // Arrange
            const string uriString = "test/path";
            var relativeUri = new RelativeUri(uriString);
            var mockParameterBuilder = new Mock<IParameterBuilder>();
            mockParameterBuilder.Setup(pb => pb.Any()).Returns(true);
            mockParameterBuilder.Setup(pb => pb.ToString()).Returns("param1=value1&param2=value2");

            // Act
            var resultUri = relativeUri.AddParameters(mockParameterBuilder.Object);

            // Assert
            Assert.NotEqual(relativeUri, resultUri);
            Assert.Equal("test/path?param1=value1&param2=value2", resultUri.OriginalString);
        }
    }
}

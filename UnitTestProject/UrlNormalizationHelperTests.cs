using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTestProject
{
    public class UrlNormalizationHelperTests
    {
        private readonly IUrlNormalizationHelper _urlNormalizationHelper;

        public UrlNormalizationHelperTests()
        {
            _urlNormalizationHelper = new UrlNormalizationHelper();
        }


        [Fact]
        public void CountUniqueUrls_NullInput_ReturnsZero()
        {
            // Act
            var result = _urlNormalizationHelper.CountUniqueUrls(null);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountUniqueUrls_EmptyArrayInput_ReturnsZero()
        {
            // Act
            var result = _urlNormalizationHelper.CountUniqueUrls(new string[0]);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountUniqueUrls_DuplicateUrls_ReturnsUniqueCount()
        {
            // Arrange
            var urls = new string[] { "http://example.com", "http://example.com", "http://example.org" };

            // Act
            var result = _urlNormalizationHelper.CountUniqueUrls(urls);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void CountUniqueUrlsPerTopLevelDomain_NullInput_ReturnsEmptyDictionary()
        {
            // Act
            var result = _urlNormalizationHelper.CountUniqueUrlsPerTopLevelDomain(null);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void CountUniqueUrlsPerTopLevelDomain_EmptyArrayInput_ReturnsEmptyDictionary()
        {
            // Act
            var result = _urlNormalizationHelper.CountUniqueUrlsPerTopLevelDomain(new string[0]);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void CountUniqueUrls_ShouldReturnCorrectCount()
        {
            // Arrange
            string[] inputUrls1 = { "https://example.com", "https://example.com/" };
            string[] inputUrls2 = { "https://example.com", "http://example.com" };
            string[] inputUrls3 = { "https://example.com?", "https://example.com" };
            string[] inputUrls4 = { "https://example.com?a=1&b=2", "https://example.com?b=2&a=1" };

            // Act
            var result1 = _urlNormalizationHelper.CountUniqueUrls(inputUrls1);
            var result2 = _urlNormalizationHelper.CountUniqueUrls(inputUrls2);
            var result3 = _urlNormalizationHelper.CountUniqueUrls(inputUrls3);
            var result4 = _urlNormalizationHelper.CountUniqueUrls(inputUrls4);

            // Assert
            Assert.Equal(1, result1);
            Assert.Equal(2, result2);
            Assert.Equal(1, result3);
            Assert.Equal(1, result4);
        }

    }
}

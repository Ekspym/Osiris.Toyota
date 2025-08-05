using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Entities;
using Osiris.Toyota.Core.Enums;
using Osiris.Toyota.Infrastructure.Connectors;
using Osiris.Toyota.Infrastructure.DTOs;
using Osiris.Toyota.Infrastructure.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Osiris.Toyota.Infrastructure.Tests.Services
{
    public class LoadServiceTests
    {
        private readonly Mock<TOneConnector> _connectorMock;
        private readonly Mock<IGenericMapper> _mapperMock;
        private readonly LoadService _service;

        public LoadServiceTests()
        {
            // Create minimal required dependencies
            var system = new ExternalSystem { EndpointUrl = "http://test.com" };
            var httpClient = new HttpClient();
            var dataProtection = Mock.Of<IDataProtectionProvider>();
            var loggerFactory = Mock.Of<ILoggerFactory>();

            // Create the mock with CallBase = true
            _connectorMock = new Mock<TOneConnector>(
                system,
                httpClient,
                dataProtection,
                loggerFactory)
            {
                CallBase = true 
            };

            _mapperMock = new Mock<IGenericMapper>();
            _service = new LoadService(_connectorMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetLoadAsync_ValidId_ReturnsLoadDto()
        {
            // Arrange
            var loadId = "LOAD123";
            var response = new object();
            var expectedDto = new LoadDto();

            // Override just the SendRequestAsync method
            _connectorMock.Protected()
                .Setup<Task<object>>(
                    "SendRequestAsync<object>",
                    HttpMethod.Get,
                    $"/api/v1/loads/{loadId}",
                    ItExpr.IsAny<object>())
                .ReturnsAsync(response);

            _mapperMock.Setup(x => x.Map<object, LoadDto>(response))
                .Returns(expectedDto);

            // Act
            var result = await _service.GetLoadAsync(loadId);

            // Assert
            Assert.Equal(expectedDto, result);
        }

        [Fact]
        public async Task GetLoadAsync_InvalidId_ThrowsException()
        {
            // Arrange
            var loadId = "";

            _connectorMock.Protected()
                .Setup<Task<object>>(
                    "SendRequestAsync<object>",
                    ItExpr.IsAny<HttpMethod>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<object>())
                .ThrowsAsync(new ArgumentException());

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.GetLoadAsync(loadId));
        }

        [Fact]
        public async Task UpdateLoadStatus_ValidInput_ThrowsNotImplemented()
        {
            // Arrange
            var loadId = "LOAD123";
            var newState = LoadState.Reserved;

            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(
                () => _service.UpdateLoadStatus(loadId, newState));
        }
    }
}
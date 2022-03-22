using devices.Application.Services;
using devices.Domain.Contracts;
using devices_back.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using Xunit;

namespace devices.API.Tests
{
    public class DevicesControllerTests
    {
        private readonly DevicesController _sut;
        private readonly ILogger<DevicesController> _fakelogger = Substitute.For<ILogger<DevicesController>>();
        private readonly IDeviceService _fakeDeviceService = Substitute.For<IDeviceService>();

        public DevicesControllerTests()
        {
            _sut = new DevicesController(_fakelogger, _fakeDeviceService);
        }

        [Fact]
        public void DevicesController_GetAllDevices_ReturnsBadResponse()
        {
            _fakeDeviceService.GetAllDevices().Returns(x => null);

            var response = _sut.Get();

            var result = response as BadRequestObjectResult;
            result.Should().BeNull();
        }

        [Fact]
        public void DevicesController_GetDeviceById_ReturnsValidResponse()
        {
            Guid deviceGuid = Guid.NewGuid();
            var device = new DeviceContract()
            {
                Id = deviceGuid,
                Status = Domain.Common.DeviceStatus.Available,
                Type = Domain.Common.DeviceType.IPhoneTablet,
                Name = "Device 16",
                RelatedDevices = new[] { new Guid(), new Guid() }
            };

            _fakeDeviceService.GetDeviceById(deviceGuid).Returns(x => device);

            var response = _sut.Get(deviceGuid);

            var result = response as OkObjectResult;
            result.Value.Should().NotBeNull();
            result.Value.Should().Be(device);
        }


        [Fact]
        public void DevicesController_GetDeviceById_DeviceNotFound()
        {
            Guid deviceGuid = Guid.NewGuid();
            var device = new DeviceContract()
            {
                Id = deviceGuid,
                Status = Domain.Common.DeviceStatus.Available,
                Type = Domain.Common.DeviceType.IPhoneTablet,
                Name = "Device 16",
                RelatedDevices = new[] { new Guid(), new Guid() }
            };

            _fakeDeviceService.GetDeviceById(deviceGuid).Returns(x => device);

            var response = _sut.Get(new Guid());

            var result = response as BadRequestObjectResult;
            result.Value.Should().Be("DeviceId is incorrect");
            result.StatusCode.Should().Be(400);
        }
    }
}

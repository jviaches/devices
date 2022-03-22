using devices.Application.Services;
using devices.Domain.Contracts;
using devices.Persistance;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace devices.Application.Tests
{
    public class BookServicesTests
    {
        private readonly DeviceService _sut;
        private readonly IDatabaseService _fakeDbService = Substitute.For<IDatabaseService>();

        public BookServicesTests()
        {
            _sut = new DeviceService(_fakeDbService);
        }

        [Fact]
        public void DevicesController_GetAllDevices_ReturnsValidResponse()
        {
            _fakeDbService.GetDevices().Returns(getTestDevices());
            var result = _sut.GetAllDevices();

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(getTestDevices());
        }

        [Fact]
        public void DevicesController_GetDevicesById_ReturnsValidResponse()
        {
            var guid = new Guid("5ef49b35-2ccc-4bfb-af53-2ac3d2ca1991");
            _fakeDbService.GetDeviceById(guid).Returns(getTestDevices()[1]);
            var result = _sut.GetDeviceById(guid);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(getTestDevices()[1]);
        }


        private DeviceContract[] getTestDevices()
        {
            var deviceList = new DeviceContract[]
{
                new DeviceContract()
                {
                    Id = new Guid("38402495-ad2e-4c9d-b65b-a8c8548ffb01"),
                    Name = "Device #1",
                    Type = Domain.Common.DeviceType.Desktop,
                    Status = Domain.Common.DeviceStatus.Online,
                    RelatedDevices = new List<Guid>()
                },
                new DeviceContract()
                {
                    Id = new Guid("5ef49b35-2ccc-4bfb-af53-2ac3d2ca1991"),
                    Name = "Device #2",
                    Type = Domain.Common.DeviceType.Desktop,
                    Status = Domain.Common.DeviceStatus.Online,
                    RelatedDevices = new List<Guid>() { new Guid("38402495-ad2e-4c9d-b65b-a8c8548ffb01") }
                }
};
            return deviceList;
        }
    }
}

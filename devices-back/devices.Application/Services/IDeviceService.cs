using devices.Domain.Contracts;
using devices.Domain.Entities;
using System;

namespace devices.Application.Services
{
    public interface IDeviceService
    {
        DeviceContract[] GetAllDevices();
        DeviceContract GetDeviceById(Guid deviceID);
    }
}
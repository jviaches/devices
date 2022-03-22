using devices.Domain.Contracts;
using System;

namespace devices.Persistance
{
    public interface IDatabaseService
    {
        DeviceContract[] GetDevices();
        DeviceContract GetDeviceById(Guid deviceId);
        int SaveChanges();
    }
}

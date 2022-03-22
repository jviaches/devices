using devices.Persistance;
using System.Linq;
using devices.Domain.Entities;
using devices.Domain.Contracts;
using System;

namespace devices.Application.Services
{
   
    public class DeviceService : IDeviceService
    {
        private readonly IDatabaseService _databaseService;

        public DeviceService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // Technically those devices should be retrieved by user or entity that "owns" it (depends on architecture).
        // Since lack of information, all devices will be retrieved.
        
        // Also this method i reality should return contarct rather that Db entity
        // But for simplicity and demo purposes it will be skipped.
        public DeviceContract[] GetAllDevices()
        {
            return _databaseService.GetDevices();
        }

        public DeviceContract GetDeviceById(Guid deviceId)
        {
            return _databaseService.GetDeviceById(deviceId);
        }
    }
}

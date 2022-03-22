using devices.Persistance;
using devices.Domain.Common;
using devices.Domain.Contracts;
using devices.Domain.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace devices.Persistance
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DbSet<Device> Devices { get; set; }

        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Devices
            var device1 = new Device { Id = Guid.NewGuid(), Name = "Device 1", DeviceType = DeviceType.Unknown, DeviceStatus = DeviceStatus.Available, RelatedDevices = { } };
            var device2 = new Device { Id = Guid.NewGuid(), Name = "Device 2", DeviceType = DeviceType.IPhoneMobile, DeviceStatus = DeviceStatus.Offline, RelatedDevices = { } };
            var device3 = new Device { Id = Guid.NewGuid(), Name = "Device 3", DeviceType = DeviceType.IPhoneTablet, DeviceStatus = DeviceStatus.Available, RelatedDevices = { } };
            var device4 = new Device { Id = Guid.NewGuid(), Name = "Device 4", DeviceType = DeviceType.Desktop, DeviceStatus = DeviceStatus.Available, RelatedDevices = { } };

            modelBuilder.Entity<Device>().HasData(device1);
            modelBuilder.Entity<Device>().HasData(device2);
            modelBuilder.Entity<Device>().HasData(device3);
            modelBuilder.Entity<Device>().HasData(device4);

            device1.RelatedDevices = new[] { device2.Id, device2.Id, device4.Id };
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

        DeviceContract[] IDatabaseService.GetDevices()
        {
            return Devices.Select(device => new DeviceContract()
            {
                Id = device.Id,
                Name = device.Name,
                Type = device.DeviceType,
                Status = device.DeviceStatus,
                RelatedDevices = device.RelatedDevices
            }).ToArray();
        }

        public DeviceContract GetDeviceById(Guid deviceId)
        {
            return Devices.Where(dev => dev.Id == deviceId)
                .Select(device => new DeviceContract()
                {
                    Id = device.Id,
                    Name = device.Name,
                    Type = device.DeviceType,
                    Status = device.DeviceStatus,
                    RelatedDevices = device.RelatedDevices
                }).FirstOrDefault();
        }
    }
}

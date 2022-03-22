using devices.Domain.Common;
using System;
using System.Collections.Generic;

namespace devices.Domain.Contracts
{
    public class DeviceContract
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DeviceType Type { get; set; }
        public DeviceStatus Status { get; set; }
        public virtual IEnumerable<Guid> RelatedDevices { get; set; }
    }
}

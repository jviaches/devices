using devices.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace devices.Domain.Entities
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DeviceType DeviceType { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
        public virtual Guid[] RelatedDevices { get; set; }
    }
}

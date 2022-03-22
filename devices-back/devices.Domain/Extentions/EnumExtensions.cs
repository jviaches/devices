using devices.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace devices.Domain.Extentions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Usage: DeviceType deviceType = DeviceType.IPhoneMobile;  print(deviceType.ToDescriptionString()); --> "IPhone Mobile"
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToDescriptionString(this DeviceType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}

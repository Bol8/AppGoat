using System.Collections.Generic;

namespace AppGoat.Application.Utils.Notifications
{
    internal class DeviceKeys
    {
        internal List<string> AndroidDeviceKeys { get; set; }
        internal List<string> IOSDeviceKeys { get; set; }

        public DeviceKeys()
        {
            AndroidDeviceKeys = new List<string>();
            IOSDeviceKeys = new List<string>();
        }
    }
}
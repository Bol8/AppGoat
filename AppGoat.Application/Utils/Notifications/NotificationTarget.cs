using System.Collections.Generic;

namespace AppGoat.Application.Utils.Notifications
{
    internal class NotificationTarget
    {
        public string type { get; set; }

        public List<string> devices { get; set; }
    }
}
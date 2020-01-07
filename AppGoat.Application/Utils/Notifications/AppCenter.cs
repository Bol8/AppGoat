using AppGoat.Application.Constants;
using AppGoat.Application.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppGoat.Application.Utils.Notifications
{
    public class AppCenter
    {
        private readonly DeviceKeys _deviceKeys;

        public AppCenter() { }

        public AppCenter(Dictionary<Guid, string> dicInstallIdPlatform)
        {
            _deviceKeys = new DeviceKeys();

            foreach (Guid key in dicInstallIdPlatform.Keys)
            {
                switch (dicInstallIdPlatform[key])
                {
                    case "Android":
                        _deviceKeys.AndroidDeviceKeys.Add(key.ToString());

                        break;

                    case "iOS":
                        _deviceKeys.IOSDeviceKeys.Add(key.ToString());

                        break;
                }
            }
        }


        public async Task<bool> SendPushNotificationAsync(string title, string message, CustomData customData)
        {
            bool notificationResult = false;

            if (_deviceKeys == null)
            {
                notificationResult = await SendPushNotificationByAllDevices(title, message, customData);
            }
            else
            {
                notificationResult = await SendPushNotificationByAllDevices(title, message, customData);
            }

            return notificationResult;
        }

        private async Task<bool> SendPushNotificationByAllDevices(string title, string message, CustomData customData)
        {
            bool notificationResult = false;

            var pushNotification = GetPushNotificationObject(title, message, customData, null);
            var url = GetPushNotificationUrl(AppCenterKeys.AndroidAppName);
            notificationResult = await SendPushNotification(pushNotification, url);

            return notificationResult;
        }

        private async Task<bool> SendPushNotificationByDevices(string title, string message, CustomData customData)
        {
            bool notificationResult = false;

            if (_deviceKeys.AndroidDeviceKeys.Any())
            {
                var pushNotification = GetPushNotificationObject(title, message, customData, _deviceKeys.AndroidDeviceKeys);
                var url = GetPushNotificationUrl(AppCenterKeys.AndroidAppName);
                notificationResult = await SendPushNotification(pushNotification, url);
            }

            if (_deviceKeys.IOSDeviceKeys.Any())
            {
                var pushNotification = GetPushNotificationObject(title, message, customData, _deviceKeys.IOSDeviceKeys);
                var url = GetPushNotificationUrl(AppCenterKeys.IOSAppName);
                notificationResult = await SendPushNotification(pushNotification, url);
            }

            return notificationResult;
        }

        private string GetPushNotificationUrl(string appName)
        {
            return $"{AppCenterKeys.Url}/{AppCenterKeys.OwnerName}/{appName}/{AppCenterKeys.ApiNotification}";
        }

        private PushNotification GetPushNotificationObject(string title, string message, CustomData customData,
            List<string> devices)
        {
            NotificationTarget notificationTarget = null;

            if (devices != null)
            {
                notificationTarget = new NotificationTarget
                {
                    type = AppCenterKeys.DeviceTargetName,
                    devices = devices
                };
            }
          

            var notificationContent = new NotificationContent
            {
                body = message,
                name = "Notificacion Promo",
                title = title,
                CustomData = new CustomData()
            };

            var pushNotification = new PushNotification
            {
                notification_target = notificationTarget,
                notification_content = notificationContent
            };

            return pushNotification;
        }

        private async Task<bool> SendPushNotification(PushNotification pushNotification, string url)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add(AppCenterKeys.ApiKeyName, AppCenterKeys.AppCenterAPIKey);

                var stringContent = pushNotification.AsJson();

                var httpResponse = await httpClient.PostAsync(url, stringContent);

                if (httpResponse.IsSuccessStatusCode)
                {
                    return true;
                }

                if (httpResponse.StatusCode == HttpStatusCode.BadRequest || httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var json = httpResponse.Content.ReadAsStringAsync();
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return false;
        }
    }
}
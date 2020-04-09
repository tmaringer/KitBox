using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace ShopInterface
{
    class NotificationToast
    {
        public static void SimpleNotification(string title)
        {
            string source = "ms-appdata:///Assets/StoreLogo.png";
            // Construct the visuals of the toast
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = title
                        },
                    },

                    AppLogoOverride = new ToastGenericAppLogo()
                    {
                        Source = source,
                        HintCrop = ToastGenericAppLogoCrop.Circle
                    }
                }
            };
            ToastContent toastContent = new ToastContent()
            {
                Visual = visual
            };
            // And create the toast notification
            var toast = new ToastNotification(toastContent.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}

using Plugin.LocalNotification;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorldProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
            InitializeComponent();
            /// event trigger if a notification is send
            LocalNotificationCenter.Current.NotificationReceived += Current_NotificationReceived;
        }

        private void Current_NotificationReceived(Plugin.LocalNotification.EventArgs.NotificationEventArgs e)
        {
            /// its only possible to display alerts inside the main thread
            Device.BeginInvokeOnMainThread(() =>
            {
                /// displays an simple alert if an notification is send
                DisplayAlert(e.Request.Title, e.Request.Description, "OK");
            });
        }

        private void sendNot_Clicked(object sender, EventArgs e)
        {
            /// create a notification with description, title, ...
            var notification = new NotificationRequest();
            notification.BadgeNumber = 1;
            notification.Description = "Test Description";
            notification.Title = "Message";
            notification.ReturningData = "Test Data";
            notification.NotificationId = 1;
            notification.Schedule.NotifyTime = DateTime.Now.AddSeconds(3);

            ///show this notification after 3 seconds (notify time)
            LocalNotificationCenter.Current.Show(notification);
        }
    }
}
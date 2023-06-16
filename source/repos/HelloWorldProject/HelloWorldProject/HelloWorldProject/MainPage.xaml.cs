using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorldProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string username = nameEntry.Text;
            string greeting = "Hello " + username;
            greetingName.Text = greeting;
        }
        private void btCameraPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CameraPage());
        }

        private void btMapsPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapsPage());
        }

        private void btSensoricPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SensorPage());
        }

        private void btNotifiPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotificationPage());
        }

    }
}

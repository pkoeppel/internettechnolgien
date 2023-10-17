using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorldProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ///open MainPage
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

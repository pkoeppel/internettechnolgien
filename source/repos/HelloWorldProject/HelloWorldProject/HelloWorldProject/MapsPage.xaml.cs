using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorldProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        /// create member variables of longitude and latitude
        double loc_lon;
        double loc_lat;
        /// create member variables of Glauchau
        double loc_lon_Glauchau;
        double loc_lat_Glauchau;

        public MapsPage()
        {
            InitializeComponent();
            /// initialize all member variables
            loc_lon = 0;
            loc_lat = 0;
            loc_lon_Glauchau = 12.5452;
            loc_lat_Glauchau = 50.8188;
        }

        async void openSelLoc_Clicked(object sender, EventArgs e)
        {
            /// try to convert entry text to member variables of longitude and latidude
            /// if not possible get the current location and write back to entries
            try
            {
                loc_lon = Convert.ToDouble(longitude.Text);
                loc_lat = Convert.ToDouble(latitude.Text);
            }
            catch
            {
                getCurrentLocationAsync();
                longitude.Text = loc_lon.ToString();
                latitude.Text = loc_lat.ToString();
            }

            /// create a location from member variables of longitude and latitude
            var location = new Location(loc_lat, loc_lon);
            /// open location in map asynchron
            await Map.OpenAsync(location);
        }

        private void currLocation_Clicked(object sender, EventArgs e)
        {
            getCurrentLocationAsync();
            /// fill entries with member variables of longitude and latitude
            longitude.Text = loc_lon.ToString();
            latitude.Text = loc_lat.ToString();
        }

        private void locOfGlauchau_Clicked(object sender, EventArgs e)
        {
            /// change member variables of longitude and latitude to Glauchau
            loc_lon = loc_lon_Glauchau;
            loc_lat = loc_lat_Glauchau;

            /// fill entries with member variables of Glauchau
            longitude.Text = loc_lon_Glauchau.ToString();
            latitude.Text = loc_lat_Glauchau.ToString();
        }

        private async void getCurrentLocationAsync()
        {
            /// get the current location from Xamarin.Essentials
            var curLoc = await Geolocation.GetLastKnownLocationAsync();
            /// save current location to member variables of longitude and latitude
            loc_lon = curLoc.Longitude;
            loc_lat = curLoc.Latitude;
        }

        private async void dirGlauchauCur_Clicked(object sender, EventArgs e)
        {
            getCurrentLocationAsync();
            /// create location of Glauchau longitude and latitude
            var location = new Location(loc_lat_Glauchau, loc_lon_Glauchau);
            /// initial map options with the name and mode (e.g. by car, bike, ...)
            var mapLaunch = new MapLaunchOptions();
            mapLaunch.Name = "Glauchau";
            mapLaunch.NavigationMode = NavigationMode.Default;
            /// open map with the navigation from current place to Glauchau
            await Map.OpenAsync(location, mapLaunch);

        }

        private async void showGlauchau_Clicked(object sender, EventArgs e)
        {
            /// create a placemark for Glauchau with the country name and the locality
            Placemark placemark = new Placemark();
            placemark.CountryName = "Germany";
            placemark.Locality = "Glauchau";
            /// open placement in map
            await placemark.OpenMapsAsync();
        }
    }
}
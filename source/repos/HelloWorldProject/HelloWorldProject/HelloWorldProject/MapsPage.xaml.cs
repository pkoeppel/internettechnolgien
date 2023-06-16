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
        /// create member variables of Berlin
        double loc_lon_Berlin;
        double loc_lat_Berlin;

        public MapsPage()
        {
            InitializeComponent();
            /// initialize all member variables
            loc_lon = 0;
            loc_lat = 0;
            loc_lon_Berlin = 13.3777;
            loc_lat_Berlin = 52.5162;
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

        private void locOfBerlin_Clicked(object sender, EventArgs e)
        {
            /// change member variables of longitude and latitude to Berlin
            loc_lon = loc_lon_Berlin;
            loc_lat = loc_lat_Berlin;

            /// fill entries with member variables of Berlin
            longitude.Text = loc_lon_Berlin.ToString();
            latitude.Text = loc_lat_Berlin.ToString();
        }

        private async void getCurrentLocationAsync()
        {
            /// get the current location from Xamarin.Essentials
            var curLoc = await Geolocation.GetLastKnownLocationAsync();
            /// save current location to member variables of longitude and latitude
            loc_lon = curLoc.Longitude;
            loc_lat = curLoc.Latitude;
        }

        private async void dirBerlinCur_Clicked(object sender, EventArgs e)
        {
            getCurrentLocationAsync();
            /// create location of Berlin longitude and latitude
            var location = new Location(loc_lat_Berlin, loc_lon_Berlin);
            /// initial map options with the name and mode (e.g. by car, bike, ...)
            var mapLaunch = new MapLaunchOptions();
            mapLaunch.Name = "Berlin";
            mapLaunch.NavigationMode = NavigationMode.Default;
            /// open map with the navigation from current place to Berlin
            await Map.OpenAsync(location, mapLaunch);

        }

        private async void showBerlin_Clicked(object sender, EventArgs e)
        {
            /// create a placemark for Berlin with the country name and the locality
            Placemark placemark = new Placemark();
            placemark.CountryName = "Germany";
            placemark.Locality = "Berlin";
            /// open placement in map
            await placemark.OpenMapsAsync();
        }
    }
}
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorldProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SensorPage : ContentPage
    {
        ///interaction with the accelerometer
        public void AccelerometerSensor()
        {
            ///start reading changes
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            ///start and set delay for monitoring changes
            Accelerometer.Start(SensorSpeed.UI);
        }
        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            ///write output changes into entry
            string x = e.Reading.Acceleration.X.ToString();
            string y = e.Reading.Acceleration.Y.ToString();
            string z = e.Reading.Acceleration.Z.ToString();
            accelometer.Text = x + " ; " + y + " ; " + z;
        }

        ///interaction with the barometer
        public void BarometerSensor()
        {
            ///check if sensor is monitoring at the moment
            ///dont continue if true
            if (Barometer.IsMonitoring)
                return;
            ///start reading changes
            Barometer.ReadingChanged += Barometer_ReadingChanged;
            ///start and set delay for monitoring changes
            Barometer.Start(SensorSpeed.UI);
        }
        private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            ///write output changes into entry
            string pressure = e.Reading.PressureInHectopascals.ToString();
            barometer.Text = pressure;
        }

        //interaction with the battery (required permission BatteryStatus)
        public void BatterySensor()
        {
            ///fill entry with current values
            string level = Battery.ChargeLevel.ToString();
            string state = Battery.State.ToString();
            string source = Battery.PowerSource.ToString();
            battery.Text = level + " ; " + state + " ; " + source;

            ///start reading changes
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }
        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            ///write output changes into entry
            string level = e.ChargeLevel.ToString();
            string state = e.State.ToString();
            string source = e.PowerSource.ToString();
            battery.Text = level + " ; " + state + " ; " + source;
        }

        //interaction with the compass
        public void CompassSensor()
        {
            ///check if sensor is monitoring at the moment
            ///dont continue if true
            if (Compass.IsMonitoring)
                return;
            ///start reading changes
            Compass.ReadingChanged += Compass_ReadingChanged;
            ///start and set delay for monitoring changes
            Compass.Start(SensorSpeed.UI);
        }
        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            ///write output changes into entry
            string degrees = e.Reading.HeadingMagneticNorth.ToString();
            compass.Text = degrees;
        }

        //start vibration actor(required permission vibrate)
        public void VibrationActor()
        {
            //start the vibration actor with a duration of two seconds
            var duration = TimeSpan.FromSeconds(2);
            Vibration.Vibrate(duration);

        }

        //interaction with the shaking sensor
        public void ShakingSensor()
        {
            ///start reading changes
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        }
        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            //start virbration actor
            VibrationActor();
        }

        public SensorPage()
        {
            InitializeComponent();
            AccelerometerSensor();
            BarometerSensor();
            BatterySensor();
            CompassSensor();
        }

    }
}
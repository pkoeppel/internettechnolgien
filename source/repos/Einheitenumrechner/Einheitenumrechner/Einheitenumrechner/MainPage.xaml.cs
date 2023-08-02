using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Einheitenumrechner
{
    public partial class MainPage : ContentPage
    {
        List<String> currencyList, lenghtList, weightList, speedList, volumeList;
        public MainPage()
        {
            InitializeComponent();
            convert_unit.Items.Add("Währung");
            convert_unit.Items.Add("Länge");
            convert_unit.Items.Add("Gewicht");
            convert_unit.Items.Add("Speicherplatz");
            convert_unit.Items.Add("Geschwindigkeit");
        }
        private void unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            input_value.Text = "";
            output_value.Text = "";
        }
        private void Convert_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            input_unit.Items.Clear();
            output_unit.Items.Clear();
            input_value.Text = "";
            output_value.Text = "";
            switch (convert_unit.SelectedIndex)
            {
                case 0:
                    SetUpCurrency();
                    break;
                case 1:
                    SetUpLenght();
                    break;
                case 2:
                    SetUpWeight();
                    break;
                case 3:
                    SetUpVolume();
                    break;
                case 4:
                    SetUpSpeed();
                    break;
                default:
                    break;
            }
            input_unit.SelectedIndex = 0;
            output_unit.SelectedIndex = 1;
        }
        private void SetUpSpeed()
        {
            speedList = new List<String>();
            speedList.Add("µm/s"); 
            speedList.Add("mm/s");
            speedList.Add("m/s");
            speedList.Add("km/s");
            speedList.Add("km/h");
            speedList.Add("mph");
            foreach (String speed in speedList)
            {
                input_unit.Items.Add(speed);
                output_unit.Items.Add(speed);
            }
        }
        private void SetUpVolume()
        {
            volumeList = new List<String>();
            volumeList.Add("bit");
            volumeList.Add("B");
            volumeList.Add("kB");
            volumeList.Add("MB");
            volumeList.Add("GB");
            volumeList.Add("TB");
            volumeList.Add("PB");
            volumeList.Add("EB");
            volumeList.Add("ZB");
            volumeList.Add("YB");
            volumeList.Add("KiB");
            volumeList.Add("MiB");
            volumeList.Add("GiB");
            volumeList.Add("TiB");
            volumeList.Add("PiB");
            volumeList.Add("EiB");
            volumeList.Add("ZiB");
            volumeList.Add("YiB");
            foreach (String volume in volumeList)
            {
                input_unit.Items.Add(volume);
                output_unit.Items.Add(volume);
            }
        }
        private void SetUpWeight()
        {
            weightList = new List<String>();
            weightList.Add("u"); 
            weightList.Add("ng");
            weightList.Add("mg");
            weightList.Add("g");
            weightList.Add("dag");
            weightList.Add("hg");
            weightList.Add("kg");
            weightList.Add("kN");
            weightList.Add("t");
            weightList.Add("lb");
            foreach (String weight in weightList) 
            {
                input_unit.Items.Add(weight);
                output_unit.Items.Add(weight);
            }
        }
        private void SetUpLenght()
        {
            lenghtList = new List<String>();
            lenghtList.Add("A");
            lenghtList.Add("nm");
            lenghtList.Add("µm");
            lenghtList.Add("mm");
            lenghtList.Add("cm");
            lenghtList.Add("m");
            lenghtList.Add("km");
            lenghtList.Add("in");
            lenghtList.Add("ft");
            lenghtList.Add("yd");
            lenghtList.Add("mil");
            foreach (var lenght in lenghtList)
            {
                input_unit.Items.Add(lenght);
                output_unit.Items.Add(lenght);
            }
        }
        private void SetUpCurrency()
        {
            currencyList = new List<String>();
            currencyList.Add("Amerikanischer Dollar");
            currencyList.Add("Euro");
            currencyList.Add("Pfund");
            currencyList.Add("Russischer Rubel");
            currencyList.Add("Bitcoin");
            currencyList.Add("Tschechische Krone");
            currencyList.Add("Dänische Krone");
            currencyList.Add("Schwedische Krone");
            currencyList.Add("Won");
            currencyList.Add("Peso");
            currencyList.Add("Yen");
            currencyList.Add("Mark");
            foreach (String currency in currencyList)
            {
                input_unit.Items.Add(currency);
                output_unit.Items.Add(currency);
            }
        }

        private async void Button_Convert_Clicked(object sender, EventArgs e)
        {
            String inputValue = input_value.Text;

            String result;
            try
            {
                switch (convert_unit.SelectedIndex)
                {
                    case 0:
                        result = ConvertCurrency(Convert.ToDouble(inputValue));
                        break;
                    case 1:
                        result = ConvertLenghtUnit(Convert.ToDouble(inputValue));
                        break;
                    case 2:
                        result = ConvertWeight(Convert.ToDouble(inputValue));
                        break;
                    case 3:
                        result = ConvertVolume(Convert.ToDouble(inputValue));  
                        break;
                    case 4:
                        result = ConvertSpeed(Convert.ToDouble(inputValue));
                        break;
                    default:
                        result = "";
                        break;
                }
                 output_value.Text = result;
            } catch
            {
                await DisplayAlert("Warnung", "Deine Eingabe war fehlerhaft! Bitte versuche es erneut!", "OK");
            }
        }
        private String ConvertSpeed(double inputValueFormated)
        {
            double standardValue, outputValueFormated;
            switch (input_unit.SelectedIndex)
            {
                case 0:
                    standardValue = inputValueFormated * 0.000001;
                    break;
                case 1:
                    standardValue = inputValueFormated * 0.001;
                    break;
                case 2:
                    standardValue = inputValueFormated * 1;
                    break;
                case 3:
                    standardValue = inputValueFormated * 1000;
                    break;
                case 4:
                    standardValue = inputValueFormated * 0.278;
                    break;
                case 5:
                    standardValue = inputValueFormated * 0.44704;
                    break;
                default:
                    standardValue = 0;
                    break;
            }
            switch (output_unit.SelectedIndex)
            {
                case 0:
                    outputValueFormated = standardValue * 1000000;
                    break;
                case 1:
                    outputValueFormated = standardValue * 1000;
                    break;
                case 2:
                    outputValueFormated = standardValue * 1;
                    break;
                case 3:
                    outputValueFormated = standardValue * 0.001;
                    break;
                case 4:
                    outputValueFormated = standardValue * 3.6;
                    break;
                case 5:
                    outputValueFormated = standardValue * 2.2369362921;
                    break;
                default:
                    outputValueFormated = 0;
                    break;
            }
            return string.Format("{0}", outputValueFormated);
        }
        private String ConvertVolume(double inputValueFormated)
        {
            double standardValue, outputValueFormated;
            switch (input_unit.SelectedIndex)
            {
                case 0:
                    standardValue = inputValueFormated * 0.125;
                    break;
                case 1:
                    standardValue = inputValueFormated * 1;
                    break;
                case 2:
                    standardValue = inputValueFormated * Math.Pow(10,-3);
                    break;
                case 3:
                    standardValue = inputValueFormated * Math.Pow(10, -6);
                    break;
                case 4:
                    standardValue = inputValueFormated * Math.Pow(10, -9);
                    break;
                case 5:
                    standardValue = inputValueFormated * Math.Pow(10, -12);
                    break;
                case 6:
                    standardValue = inputValueFormated * Math.Pow(10, -15);
                    break;
                case 7:
                    standardValue = inputValueFormated * Math.Pow(10, -18);
                    break;
                case 8:
                    standardValue = inputValueFormated * Math.Pow(10, -21);
                    break;
                case 9:
                    standardValue = inputValueFormated * Math.Pow(10, -24);
                    break;
                case 10:
                    standardValue = inputValueFormated * Math.Pow(2, -10);
                    break;
                case 11:
                    standardValue = inputValueFormated * Math.Pow(2, -20);
                    break;
                case 12:
                    standardValue = inputValueFormated * Math.Pow(2, -30);
                    break;
                case 13:
                    standardValue = inputValueFormated * Math.Pow(2, -40);
                    break;
                case 14:
                    standardValue = inputValueFormated * Math.Pow(2, -50);
                    break;
                case 15:
                    standardValue = inputValueFormated * Math.Pow(2, -60);
                    break;
                case 16:
                    standardValue = inputValueFormated * Math.Pow(2, -70);
                    break;
                case 17:
                    standardValue = inputValueFormated * Math.Pow(2, -80);
                    break;
                default:
                    standardValue = 0;
                    break;
            }
            switch (output_unit.SelectedIndex)
            {
                case 0:
                    outputValueFormated = standardValue * 8;
                    break;
                case 1:
                    outputValueFormated = standardValue * 1;
                    break;
                case 2:
                    outputValueFormated = standardValue * Math.Pow(10, 3);
                    break;
                case 3:
                    outputValueFormated = standardValue * Math.Pow(10, 6);
                    break;
                case 4:
                    outputValueFormated = standardValue * Math.Pow(10, 9);
                    break;
                case 5:
                    outputValueFormated = standardValue * Math.Pow(10, 12);
                    break;
                case 6:
                    outputValueFormated = standardValue * Math.Pow(10, 15);
                    break;
                case 7:
                    outputValueFormated = standardValue * Math.Pow(10, 18);
                    break;
                case 8:
                    outputValueFormated = standardValue * Math.Pow(10, 21);
                    break;
                case 9:
                    outputValueFormated = standardValue * Math.Pow(10, 24);
                    break;
                case 10:
                    outputValueFormated = standardValue * Math.Pow(2, 10);
                    break;
                case 11:
                    outputValueFormated = standardValue * Math.Pow(2, 20);
                    break;
                case 12:
                    outputValueFormated = standardValue * Math.Pow(2,30);
                    break;
                case 13:
                    outputValueFormated = standardValue * Math.Pow(2, 40);
                    break;
                case 14:
                    outputValueFormated = standardValue * Math.Pow(2, 50);
                    break;
                case 15:
                    outputValueFormated = standardValue * Math.Pow(2, 60);
                    break;
                case 16:
                    outputValueFormated = standardValue * Math.Pow(2, 70);
                    break;
                case 17:
                    outputValueFormated = standardValue * Math.Pow(2, 80);
                    break;
                default:
                    outputValueFormated = 0;
                    break;
            }
            return string.Format("{0}", outputValueFormated);
        }
        private String ConvertWeight(double inputValueFormated)
        {
            double standardValue, outputValueFormated;
            switch (input_unit.SelectedIndex)
            {
                case 0:
                    standardValue = inputValueFormated * 1.6605654724 * Math.Pow(10,-15);
                    break;
                case 1:
                    standardValue = inputValueFormated * 0.000000001;
                    break;
                case 2:
                    standardValue = inputValueFormated * 0.001;
                    break;
                case 3:
                    standardValue = inputValueFormated * 1;
                    break;
                case 4:
                    standardValue = inputValueFormated * 10;
                    break;
                case 5:
                    standardValue = inputValueFormated * 100;
                    break;
                case 6:
                    standardValue = inputValueFormated * 1000;
                    break;
                case 7:
                    standardValue = inputValueFormated * 1.019716005 * Math.Pow(10,5);
                    break;
                case 8:
                    standardValue = inputValueFormated * 1000000;
                    break;
                case 9:
                    standardValue = inputValueFormated * 453.59237;
                    break;
                default:
                    standardValue = 0;
                    break;
            }
            switch (output_unit.SelectedIndex)
            {
                case 0:
                    outputValueFormated = standardValue * 6.022045 * Math.Pow(10, 23);
                    break;
                case 1:
                    outputValueFormated = standardValue * 1000000000;
                    break;
                case 2:
                    outputValueFormated = standardValue * 1000;
                    break;
                case 3:
                    outputValueFormated = standardValue * 1;
                    break;
                case 4:
                    outputValueFormated = standardValue * 0.1;
                    break;
                case 5:
                    outputValueFormated = standardValue * 0.01;
                    break;
                case 6:
                    outputValueFormated = standardValue * 0.001;
                    break;
                case 7:
                    outputValueFormated = standardValue * 0.0000098067;
                    break;
                case 8:
                    outputValueFormated = standardValue * 0.000001;
                    break;
                case 9:
                    outputValueFormated = standardValue * 0.0022046226;
                    break;
                default:
                    outputValueFormated = 0;
                    break;
            }
            return string.Format("{0}", outputValueFormated);
        }
        private String ConvertLenghtUnit(double inputValueFormated)
        {
            double standardValue, outputValueFormated;
            switch(input_unit.SelectedIndex)
            {
                case 0:
                    standardValue = inputValueFormated * 0.0000000001;
                    break;
                case 1:
                    standardValue = inputValueFormated * 0.000000001;
                    break;
                case 2:
                    standardValue = inputValueFormated * 0.000001;
                    break;
                case 3:
                    standardValue = inputValueFormated * 0.001;
                    break;
                case 4:
                    standardValue = inputValueFormated * 0.01;
                    break;
                case 5:
                    standardValue = inputValueFormated * 1;
                    break;
                case 6:
                    standardValue = inputValueFormated * 1000;
                    break;
                case 7:
                    standardValue = inputValueFormated * 0.0254;
                    break;
                case 8:
                    standardValue = inputValueFormated * 0.3048;
                    break;
                case 9:
                    standardValue = inputValueFormated * 0.9144;
                    break;
                case 10:
                    standardValue = inputValueFormated * 1609.34;
                    break;
                default:
                    standardValue = 0;
                    break;
            }
            switch (output_unit.SelectedIndex)
            {
                case 0:
                    outputValueFormated = standardValue * 10000000000;
                    break;
                case 1:
                    outputValueFormated = standardValue * 1000000000;
                    break;
                case 2:
                    outputValueFormated = standardValue * 1000000;
                    break;
                case 3:
                    outputValueFormated = standardValue * 1000;
                    break;
                case 4:
                    outputValueFormated = standardValue * 100;
                    break;
                case 5:
                    outputValueFormated = standardValue * 1;
                    break;
                case 6:
                    outputValueFormated = standardValue * 0.001;
                    break;
                case 7:
                    outputValueFormated = standardValue * 39.3701;
                    break;
                case 8:
                    outputValueFormated = standardValue * 3.28084;
                    break;
                case 9:
                    outputValueFormated = standardValue * 1.09361;
                    break;
                case 10:
                    outputValueFormated = standardValue * 0.000621371;
                    break;
                default:
                    outputValueFormated = 0;
                    break;
            }
            return string.Format("{0}", outputValueFormated);
        }
        private String ConvertCurrency(double inputValueFormated)
        {
            double standardValue, outputValueFormated;
            //Umwandeln von Eingangseinheit in Standardeinheit (Dollar)
            switch (input_unit.SelectedIndex)
            {
                case 0:
                    standardValue = inputValueFormated * 1;
                    break;
                case 1:
                    standardValue = inputValueFormated * 1.0997;
                    break;
                case 2:
                    standardValue = inputValueFormated * 1.2834;
                    break;
                case 3:
                    standardValue = inputValueFormated * 0.0109;
                    break;
                case 4:
                    standardValue = inputValueFormated * 29226.7233;
                    break;
                case 5:
                    standardValue = inputValueFormated * 0.046;
                    break;
                case 6:
                    standardValue = inputValueFormated * 0.1476;
                    break;
                case 7:
                    standardValue = inputValueFormated * 0.095;
                    break;
                case 8:
                    standardValue = inputValueFormated * 0.0008;
                    break;
                case 9:
                    standardValue = inputValueFormated * 0.0597;
                    break;
                case 10:
                    standardValue = inputValueFormated * 0.007;
                    break;
                case 11:
                    standardValue = inputValueFormated * 0.56;
                    break;
                default:
                    standardValue = 0;
                    break;
            }
            //Umwandeln von Standardeinheit (Dollar) in Ausgangseinheit
            switch (output_unit.SelectedIndex)
            {
                case 0:
                    outputValueFormated = standardValue * 1;
                    break;
                case 1:
                    outputValueFormated = standardValue * 0.9093;
                    break;
                case 2:
                    outputValueFormated = standardValue * 0.7792;
                    break;
                case 3:
                    outputValueFormated = standardValue * 91.6504;
                    break;
                case 4:
                    outputValueFormated = standardValue * 3.4215 * Math.Pow(10,-5);
                    break;
                case 5:
                    outputValueFormated = standardValue * 21.7216;
                    break;
                case 6:
                    outputValueFormated = standardValue * 6.7761;
                    break;
                case 7:
                    outputValueFormated = standardValue * 10.5242;
                    break;
                case 8:
                    outputValueFormated = standardValue * 1278.2812;
                    break;
                case 9:
                    outputValueFormated = standardValue * 16.7532;
                    break;
                case 10:
                    outputValueFormated = standardValue * 142.661;
                    break;
                case 11:
                    outputValueFormated = standardValue * 1.78;
                    break;
                default:
                    outputValueFormated = 0;
                    break;
            }
            return string.Format("{0:0.00}", outputValueFormated);
        }
    }
}

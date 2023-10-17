using freecurrencyapi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Einheitenumrechner
{
    public partial class MainPage : ContentPage
    {
        private List<String> currencyList, lenghtList, weightList, speedList, volumeList;
        private readonly JObject responseObject;
        public MainPage()
        {
            InitializeComponent();
            
            Freecurrencyapi fx = new Freecurrencyapi("fca_live_nB19c6lLttd1cbMyHJ1A1uXMqRje1Fbi7oxzhwIC");
            String currencyRate = fx.Latest();
            responseObject = JsonConvert.DeserializeObject<ApiResponse>(currencyRate).ApiData;
            
            convert_unit.Items.Add("Währung");
            convert_unit.Items.Add("Länge");
            convert_unit.Items.Add("Gewicht");
            convert_unit.Items.Add("Speicherplatz");
            convert_unit.Items.Add("Geschwindigkeit");
        }
        private void Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            input_value.Text = "";
            output_value.Text = "";
        }
        private void ConvertUnit_SelectedIndexChanged(object sender, EventArgs e)
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
            lenghtList.Add("dm");
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
            currencyList.Add("Euro");
            currencyList.Add("US Dollar");
            currencyList.Add("Yen");
            currencyList.Add("Tschechische Krone");
            currencyList.Add("Dänische Krone");
            currencyList.Add("Pfund");
            currencyList.Add("Zloty");
            currencyList.Add("Schwedische Krone");
            currencyList.Add("Franken");
            currencyList.Add("Rubel");
            currencyList.Add("Lira");
            currencyList.Add("Real");
            currencyList.Add("Yuan");
            currencyList.Add("Rupee");
            currencyList.Add("Won");
            currencyList.Add("Peso");
            currencyList.Add("Bitcoin");
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
                double value = Convert.ToDouble(inputValue);
                switch (convert_unit.SelectedIndex)
                {
                    case 0:
                        result = ConvertCurrency(value);
                        break;
                    case 1:
                        result = ConvertLenght(value);
                        break;
                    case 2:
                        result = ConvertWeight(value);
                        break;
                    case 3:
                        result = ConvertVolume(value);  
                        break;
                    case 4:
                        result = ConvertSpeed(value);
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
        private String ConvertSpeed(double input)
        {
            double standard, output;
            switch (input_unit.SelectedIndex)
            {
                case 0:
                    standard = input * 0.000001;
                    break;
                case 1:
                    standard = input * 0.001;
                    break;
                case 2:
                    standard = input * 1;
                    break;
                case 3:
                    standard = input * 1000;
                    break;
                case 4:
                    standard = input * 0.278;
                    break;
                case 5:
                    standard = input * 0.44704;
                    break;
                default:
                    standard = 0;
                    break;
            }
            switch (output_unit.SelectedIndex)
            {
                case 0:
                    output = standard * 1000000;
                    break;
                case 1:
                    output = standard * 1000;
                    break;
                case 2:
                    output = standard * 1;
                    break;
                case 3:
                    output = standard * 0.001;
                    break;
                case 4:
                    output = standard * 3.6;
                    break;
                case 5:
                    output = standard * 2.2369362921;
                    break;
                default:
                    output = 0;
                    break;
            }
            return string.Format("{0}", output);
        }
        private String ConvertVolume(double input)
        {
            double standard, output;
            switch (input_unit.SelectedIndex)
            {
                case 0:
                    standard = input * 0.125;
                    break;
                case 1:
                    standard = input * 1;
                    break;
                case 2:
                    standard = input * Math.Pow(10,-3);
                    break;
                case 3:
                    standard = input * Math.Pow(10, -6);
                    break;
                case 4:
                    standard = input * Math.Pow(10, -9);
                    break;
                case 5:
                    standard = input * Math.Pow(10, -12);
                    break;
                case 6:
                    standard = input * Math.Pow(10, -15);
                    break;
                case 7:
                    standard = input * Math.Pow(10, -18);
                    break;
                case 8:
                    standard = input * Math.Pow(10, -21);
                    break;
                case 9:
                    standard = input * Math.Pow(10, -24);
                    break;
                case 10:
                    standard = input * Math.Pow(2, -10);
                    break;
                case 11:
                    standard = input * Math.Pow(2, -20);
                    break;
                case 12:
                    standard = input * Math.Pow(2, -30);
                    break;
                case 13:
                    standard = input * Math.Pow(2, -40);
                    break;
                case 14:
                    standard = input * Math.Pow(2, -50);
                    break;
                case 15:
                    standard = input * Math.Pow(2, -60);
                    break;
                case 16:
                    standard = input * Math.Pow(2, -70);
                    break;
                case 17:
                    standard = input * Math.Pow(2, -80);
                    break;
                default:
                    standard = 0;
                    break;
            }
            switch (output_unit.SelectedIndex)
            {
                case 0:
                    output = standard * 8;
                    break;
                case 1:
                    output = standard * 1;
                    break;
                case 2:
                    output = standard * Math.Pow(10, 3);
                    break;
                case 3:
                    output = standard * Math.Pow(10, 6);
                    break;
                case 4:
                    output = standard * Math.Pow(10, 9);
                    break;
                case 5:
                    output = standard * Math.Pow(10, 12);
                    break;
                case 6:
                    output = standard * Math.Pow(10, 15);
                    break;
                case 7:
                    output = standard * Math.Pow(10, 18);
                    break;
                case 8:
                    output = standard * Math.Pow(10, 21);
                    break;
                case 9:
                    output = standard * Math.Pow(10, 24);
                    break;
                case 10:
                    output = standard * Math.Pow(2, 10);
                    break;
                case 11:
                    output = standard * Math.Pow(2, 20);
                    break;
                case 12:
                    output = standard * Math.Pow(2,30);
                    break;
                case 13:
                    output = standard * Math.Pow(2, 40);
                    break;
                case 14:
                    output = standard * Math.Pow(2, 50);
                    break;
                case 15:
                    output = standard * Math.Pow(2, 60);
                    break;
                case 16:
                    output = standard * Math.Pow(2, 70);
                    break;
                case 17:
                    output = standard * Math.Pow(2, 80);
                    break;
                default:
                    output = 0;
                    break;
            }
            return string.Format("{0}", output);
        }
        private String ConvertWeight(double input)
        {
            double standard, output;
            switch (input_unit.SelectedIndex)
            {
                case 0:
                    standard = input * 1.6605654724 * Math.Pow(10,-15);
                    break;
                case 1:
                    standard = input * 0.000000001;
                    break;
                case 2:
                    standard = input * 0.001;
                    break;
                case 3:
                    standard = input * 1;
                    break;
                case 4:
                    standard = input * 10;
                    break;
                case 5:
                    standard = input * 100;
                    break;
                case 6:
                    standard = input * 1000;
                    break;
                case 7:
                    standard = input * 1.019716005 * Math.Pow(10,5);
                    break;
                case 8:
                    standard = input * 1000000;
                    break;
                case 9:
                    standard = input * 453.59237;
                    break;
                default:
                    standard = 0;
                    break;
            }
            switch (output_unit.SelectedIndex)
            {
                case 0:
                    output = standard * 6.022045 * Math.Pow(10, 23);
                    break;
                case 1:
                    output = standard * 1000000000;
                    break;
                case 2:
                    output = standard * 1000;
                    break;
                case 3:
                    output = standard * 1;
                    break;
                case 4:
                    output = standard * 0.1;
                    break;
                case 5:
                    output = standard * 0.01;
                    break;
                case 6:
                    output = standard * 0.001;
                    break;
                case 7:
                    output = standard * 0.0000098067;
                    break;
                case 8:
                    output = standard * 0.000001;
                    break;
                case 9:
                    output = standard * 0.0022046226;
                    break;
                default:
                    output = 0;
                    break;
            }
            return string.Format("{0}", output);
        }
        private String ConvertLenght(double input)
        {
            double standard, output;
            switch(input_unit.SelectedIndex)
            {
                case 0:
                    standard = input * 0.0000000001;
                    break;
                case 1:
                    standard = input * 0.000000001;
                    break;
                case 2:
                    standard = input * 0.000001;
                    break;
                case 3:
                    standard = input * 0.001;
                    break;
                case 4:
                    standard = input * 0.01;
                    break;
                case 5:
                    standard = input * 0.1;
                    break;
                case 6:
                    standard = input * 1;
                    break;
                case 7:
                    standard = input * 1000;
                    break;
                case 8:
                    standard = input * 0.0254;
                    break;
                case 9:
                    standard = input * 0.3048;
                    break;
                case 10:
                    standard = input * 0.9144;
                    break;
                case 11:
                    standard = input * 1609.34;
                    break;
                default:
                    standard = 0;
                    break;
            }
            switch (output_unit.SelectedIndex)
            {
                case 0:
                    output = standard * 10000000000;
                    break;
                case 1:
                    output = standard * 1000000000;
                    break;
                case 2:
                    output = standard * 1000000;
                    break;
                case 3:
                    output = standard * 1000;
                    break;
                case 4:
                    output = standard * 100;
                    break;
                case 5:
                    output = standard * 10;
                    break;
                case 6:
                    output = standard * 1;
                    break;
                case 7:
                    output = standard * 0.001;
                    break;
                case 8:
                    output = standard * 39.3701;
                    break;
                case 9:
                    output = standard * 3.28084;
                    break;
                case 10:
                    output = standard * 1.09361;
                    break;
                case 11:
                    output = standard * 0.000621371;
                    break;
                default:
                    output = 0;
                    break;
            }
            return string.Format("{0}", output);
        }
        private String ConvertCurrency(double input)
        {
            double standard, output;
            
            //Umwandeln von Eingangseinheit in Standardeinheit (Dollar)
            switch (input_unit.SelectedIndex)
            {
                case 0:
                    standard = input * 1 / (double) responseObject.GetValue("EUR");
                    break;
                case 1:
                    standard = input * 1 / (double) responseObject.GetValue("USD");
                    break;
                case 2:
                    standard = input * 1 / (double) responseObject.GetValue("JPY");
                    break;
                case 3:
                    standard = input * 1 / (double) responseObject.GetValue("CZK");
                    break;
                case 4:
                    standard = input * 1 / (double) responseObject.GetValue("DKK");
                    break;
                case 5:
                    standard = input * 1 / (double) responseObject.GetValue("GBP");
                    break;
                case 6:
                    standard = input * 1 / (double) responseObject.GetValue("PLN");
                    break;
                case 7:
                    standard = input * 1 / (double) responseObject.GetValue("SEK");
                    break;
                case 8:
                    standard = input * 1 / (double) responseObject.GetValue("CHF");
                    break;
                case 9:
                    standard = input * 1 / (double) responseObject.GetValue("RUB");
                    break;
                case 10:
                    standard = input * 1 / (double) responseObject.GetValue("TRY");
                    break;
                case 11:
                    standard = input * 1 / (double) responseObject.GetValue("BRL");
                    break;
                case 12:
                    standard = input * 1 / (double) responseObject.GetValue("CNY");
                    break;
                case 13:
                    standard = input * 1 / (double) responseObject.GetValue("INR");
                    break;
                case 14:
                    standard = input * 1 / (double) responseObject.GetValue("KRW");
                    break;
                case 15:
                    standard = input * 1 / (double) responseObject.GetValue("MXN");
                    break;
                case 16:
                    standard = input * 1 / 3.4215 * Math.Pow(10, -5);
                    break;
                case 17:
                    standard = input * 1 / 1.78;
                    break;
                default:
                    standard = 0;
                    break;
            }
            //Umwandeln von Standardeinheit (Dollar) in Ausgangseinheit
            switch (output_unit.SelectedIndex)
            {
                case 0:
                    output = standard *  (double)responseObject.GetValue("EUR");
                    break;
                case 1:
                    output = standard *  (double)responseObject.GetValue("USD");
                    break;
                case 2:
                    output = standard *  (double)responseObject.GetValue("JPY");
                    break;
                case 3:
                    output = standard *  (double)responseObject.GetValue("CZK");
                    break;
                case 4:
                    output = standard *  (double)responseObject.GetValue("DKK");
                    break;
                case 5:
                    output = standard *  (double)responseObject.GetValue("GBP");
                    break;
                case 6:
                    output = standard *  (double)responseObject.GetValue("PLN");
                    break;
                case 7:
                    output = standard *  (double)responseObject.GetValue("SEK");
                    break;
                case 8:
                    output = standard *  (double)responseObject.GetValue("CHF");
                    break;
                case 9:
                    output = standard *  (double)responseObject.GetValue("RUB");
                    break;
                case 10:
                    output = standard *  (double)responseObject.GetValue("TRY");
                    break;
                case 11:
                    output = standard *  (double)responseObject.GetValue("BRL");
                    break;
                case 12:
                    output = standard *  (double)responseObject.GetValue("CNY");
                    break;
                case 13:
                    output = standard *  (double)responseObject.GetValue("INR");
                    break;
                case 14:
                    output = standard *  (double)responseObject.GetValue("KRW");
                    break;
                case 15:
                    output = standard *  (double)responseObject.GetValue("MXN");
                    break;
                case 16:
                    output = standard *  3.4215 * Math.Pow(10, -5);
                    break;
                case 17:
                    output = standard *  1.78;
                    break;
                default:
                    output = 0;
                    break;
            }
            return string.Format("{0:0.00}", output);
        }
    }
    class ApiResponse
    {
        public JObject ApiData { get; set; }
    }

    
}

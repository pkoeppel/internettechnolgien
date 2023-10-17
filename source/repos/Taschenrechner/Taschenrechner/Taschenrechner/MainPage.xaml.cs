using System;
using Xamarin.Forms;

namespace Taschenrechner
{
    public partial class MainPage : ContentPage
    {
        private String operation;
        private double firstValue;
        private Boolean operationSet, resetEntry, specialVisible;

        public MainPage()
        {
            InitializeComponent();

            operation = "";
            firstValue = 0;
            operationSet = false;
            resetEntry = false;
            specialVisible = false;
        }
        
        private void MainVisibility()
        {
            //set visibility of normal true
            value0.IsVisible = true;
            value1.IsVisible = true;
            value2.IsVisible = true;
            value3.IsVisible = true;
            value4.IsVisible = true;
            value5.IsVisible = true;
            value6.IsVisible = true; 
            value7.IsVisible = true;
            value8.IsVisible = true;
            value9.IsVisible = true;
            valueKomma.IsVisible = true;
            minus.IsVisible = true;
            plus.IsVisible = true;
            mal.IsVisible = true;
            //set visibility of special false
            log.IsVisible = false;
            logten.IsVisible = false;
            lognat.IsVisible = false;
            logdual.IsVisible = false;
            conste.IsVisible = false;
            ehochx.IsVisible = false;
            tenhochx.IsVisible = false;
            constPi.IsVisible = false;
            xhochy.IsVisible = false;
            xquadrat.IsVisible = false;
            wurzel.IsVisible = false;
            xwurzely.IsVisible = false;
            mod.IsVisible = false;
            fak.IsVisible = false;
            specialVisible = false;
        }
        private async void Calculate()
        {
            //zweiten Operanten holen
            double secondValue = GetValue();
            double result = 0;
            //aktuelle Operation ausführen
            switch (operation)
            {
                case "+":
                    result = firstValue + secondValue;
                    break;
                case "-":
                    result = firstValue - secondValue;
                    break;
                case "*":
                    result = firstValue * secondValue;
                    break;
                case "/":
                    if (secondValue != 0)
                    {
                        result = firstValue / secondValue;
                    }
                    else
                    {
                        result = 0;
                        await DisplayAlert("Warnung!", "Division durch 0 nicht möglich", "OK");
                    }
                    break;
                case "x^y":
                    result = Math.Pow(firstValue, secondValue);
                    break;
                case "x√y":
                    result = Math.Pow(1 / firstValue, secondValue);
                    break;
                case "log":
                    result = Math.Log(firstValue, secondValue);
                    break;
                case "mod":
                    result = firstValue % secondValue;
                    break;
                default:
                    result = 0;
                    break;
            }
            //Ausgabe des Ergebniss
            numericInput.Text = result.ToString();
            firstValue = result;
        }
        private double GetValue()
        {
            //versuchen Wert zu konvertieren
            //wenn nicht möglich (Wert ist nicht gesetzt) -> 0 zurück
            try
            {
                return Convert.ToDouble(numericInput.Text);
            }
            catch
            {
                return 0;
            }
        }
        
        private void Button_Clicked_Clear(object sender, EventArgs e)
        {
            String value = ((Button)sender).Text;
            //prüfen ob kompletter Abbruch oder nur leeren des Eingabefeldes
            if (value == "CC")
            {
                //leeren des Eingabefeldes 
                numericInput.Text = "";
                valueClear.Text = "AC";
                valueSign.Text = "-";
            }
            if (value == "AC")
            {
                //kompletter Abbruch
                numericInput.Text = "";
                operation = "";
                firstValue = 0;
                operationSet = false;
                valueClear.Text = "AC";
                valueSign.Text = "-";
            }
        }
        private void Button_Clicked_Value(object sender, EventArgs e)
        {
            //prüfen ob zuvor ein Operator gesetzt wurde
            //wenn ja leeren des Feldes und rücksetzen
            if (resetEntry)
            {
                numericInput.Text = "";
                resetEntry = false;
            }

            //Einfügen in Textfeld
            String oldValue = numericInput.Text;
            String newValue = ((Button)sender).Text;
            //wenn neuer Wert ein Komma 
            if (newValue.Equals("."))
            {
                //prüfen ob zuvor schon Zahl eingegeben
                //wenn nein vorangestellte Null einfügen
                if (oldValue == "" || oldValue == null)
                {
                    oldValue = "0";
                }
                //prüfen ob bereits ein Komma vorhanden ist
                //wenn ja kein weiteres einfügen
                if (!oldValue.Contains("."))
                {
                    numericInput.Text = oldValue + newValue;
                }
            }
            //wenn neuer Wert eine Null ist prüfen ob an erster Stelle
            else if (newValue.Equals("0"))
            {
                if (oldValue != "0")
                {
                    numericInput.Text = oldValue + newValue;
                }
            }
            //wenn neuer Wert ist eine beliebige Zahl 
            else
            {
                numericInput.Text = oldValue + newValue;
            }
        }
        private void Button_Clicked_Operation(object sender, EventArgs e)
        {
            //prüfen ob bereits einmal das Operationszeichen gesetzt wurde
            if (!operationSet)
            {
                //wenn nein -> Zahl und Operation abspeichern, bestätigen das zeichen gesetzt 
                operation = ((Button)sender).Text;
                firstValue = GetValue();
                operationSet = true;
                resetEntry = true;
                MainVisibility();
            }
            else
            {
                //wenn ja -> Zahl2 holen, Operation ausführen, ausgeben, erste Zahl auf Ergebniss setzen, gesetzte Operation bleibt auf true
                Calculate();
                operation = ((Button)sender).Text;
                operationSet = true;
                resetEntry = true;
                MainVisibility();
            }
        }
        private void Button_Clicked_Result(object sender, EventArgs e)
        {
            //einfaches Ausgeben des Ergebnisses ohne weitere Operation
            if (operationSet)
            {
                Calculate();
                resetEntry = true;
                operationSet = false;
                operation = "";
                valueClear.Text = "AC";
            }
        }
        private void Button_Clicked_Sign(object sender, EventArgs e)
        {
            //Vorzeichen verändern
            String oldValue = numericInput.Text;
            //prüfen welches Vorzeichen aktuell gesetzt ist
            // bei +: - davor setzten
            // bei -: austausche des - mit einem leeren String
            if (!oldValue.Contains("-"))
            {
                numericInput.Text = "-" + numericInput.Text;
                valueSign.Text = "+";
            }
            else
            {
                numericInput.Text = numericInput.Text.Replace("-", "");
                valueSign.Text = "-";
            }
        }
        private void Button_Clicked_Change(object sender, EventArgs e)
        {
            if (specialVisible)
            {
                MainVisibility();
            }
            else
            {
                //set visibility of normal false
                value0.IsVisible = false;
                value1.IsVisible = false;
                value2.IsVisible = false;
                value3.IsVisible = false;
                value4.IsVisible = false;
                value5.IsVisible = false;
                value6.IsVisible = false;
                value7.IsVisible = false;
                value8.IsVisible = false;
                value9.IsVisible = false;
                valueKomma.IsVisible = false;
                minus.IsVisible = false;
                plus.IsVisible = false;
                mal.IsVisible = false;
                //set visibility of special true
                log.IsVisible = true;
                logten.IsVisible = true;
                lognat.IsVisible = true;
                logdual.IsVisible = true;
                conste.IsVisible = true;
                ehochx.IsVisible = true;
                tenhochx.IsVisible = true;
                constPi.IsVisible = true;
                xhochy.IsVisible = true;
                xquadrat.IsVisible = true;
                wurzel.IsVisible = true;
                xwurzely.IsVisible = true;
                mod.IsVisible = true;
                fak.IsVisible = true;

                specialVisible = true;
            }
        }
        private void Button_Clicked_Percent(object sender, EventArgs e)
        {
            //wenn zuvor keine Zahl eingegeben -> Prozentzahl auf 100 bezogen
            //sonst auf zuvor gegebene Zahl
            if (!operationSet)
            {
                double value = GetValue();
                double result = value / 100;
                numericInput.Text = result.ToString();
                operationSet = true;
                resetEntry = true;
            }
            else
            {
                double value = GetValue();
                double result = firstValue/100 * value;
                numericInput.Text = result.ToString();
                resetEntry = true;
            }
        }
        private void Button_Clicked_ConstPi(object sender, EventArgs e)
        {
            //Ausgabe der Konstante PI
            numericInput.Text = Math.PI.ToString();
            MainVisibility();
        }
        private void Button_Clicked_EUpX(object sender, EventArgs e)
        {
            //Konstante e hoch der einegebenen Zahl
            double x= GetValue();
            double result = Math.Pow(Math.PI, x);
            numericInput.Text = result.ToString();
            MainVisibility();
        }
        private void Button_Clicked_TenUpX(object sender, EventArgs e)
        {
            //10 hoch der eingegebenen Zahl
            double x = GetValue();
            double result = Math.Pow(10, x);
            numericInput.Text = result.ToString();
            MainVisibility();
        }
        private void Button_Clicked_XUpTwo(object sender, EventArgs e)
        {
            //eingegebene Zahl hoch 2
            double x = GetValue();
            double result = Math.Pow(x, 2);
            numericInput.Text = result.ToString();
            MainVisibility();
        }
        private void Button_Clicked_Root(object sender, EventArgs e)
        {
            //Quadratwurzel gezogen aus der eingegebenen Zahl
            double x = GetValue();
            double result = Math.Sqrt(x);
            numericInput.Text = result.ToString();
            MainVisibility();
        }
        private void Button_Clicked_ConstE(object sender, EventArgs e)
        {
            //Ausgabe der Konstante PI
            numericInput.Text = Math.E.ToString();
            MainVisibility();
        }
        private void Button_Clicked_LogBaseTen(object sender, EventArgs e)
        {
            //Logarithmus zur Basis 10 der eingegebenen Zahl
            double x = GetValue();
            double result = Math.Log10(x);
            numericInput.Text = result.ToString();
            MainVisibility();
        }
        private void Button_Clicked_LogNat(object sender, EventArgs e)
        {
            //natürlicher Logarithmus der eingegebenen Zahl
            double x = GetValue();
            double result = Math.Log(x,Math.E);
            numericInput.Text = result.ToString();
            MainVisibility();
        }
        private void Button_Clicked_LogDual(object sender, EventArgs e)
        {
            //Logarithmus dualis der eingegebenen Zahl
            double x = GetValue();
            double result = Math.Log(x, 2);
            numericInput.Text = result.ToString();
            MainVisibility();
        }
        private void Button_Clicked_Faculty(object sender, EventArgs e)
        {
            //Fakultät der eingegebenen Zahl
            double x = GetValue();
            double result = 1;
            for (int i = 0; i <= x; i++)
            {
                result *= i;
            }
            numericInput.Text = result.ToString();
            MainVisibility();
        }
        private void Button_Clicked_Delete(object sender, EventArgs e)
        {
            if (numericInput.Text != "")
            {
                String value = numericInput.Text;
                if (value == "0.")
                {
                    numericInput.Text = "";
                }
                else
                {
                    numericInput.Text = value.Remove(value.Length - 1);
                }
            }
        }
        private void NumericInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            //zum Leeren des Textfeldes umwandeln des Buttons
            valueClear.Text = "CC";
        }
    }
    
}
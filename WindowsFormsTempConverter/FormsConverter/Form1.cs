using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ButtonPressed(object sender, EventArgs e)
        {
            char source = ChangeToChar(comboBox1.Text);
            char dest = ChangeToChar(comboBox2.Text);
            double num = Double.Parse(textBox1.Text);
            double result = Utilities.AnyTempToAnyTemp(source, num, dest);
            label1.Text = "" + result;
        }

        private char ChangeToChar(string option)
        {
            switch (option)
            {
                case "Fahrenheit":
                    return 'f';
                case "Celsius":
                    return 'c';
                case "Kelvin":
                    return 'k';
                default:
                    Console.Write("Default");
                    break;
            }
            return 'x';
        }
    }
}

class Utilities
{
    public static double FahrenheitToCelsius(double temp)
    {
        return (((temp - 32) * 5) / 9);
    }

    public static double CelsiusToFahrenheit(double temp)
    {
        return (((temp * 9) / 5) + 32);
    }

    public static double KelvinToCelsius(double temp)
    {
        return temp - 273;
    }

    public static double CelsiusToKelvin(double temp)
    {
        return temp + 273;
    }

    public static double FahrenheitToKelvin(double temp)
    {
        temp = FahrenheitToCelsius(temp);
        return CelsiusToKelvin(temp);
    }

    public static double KelvinToFahrenheit(double temp)
    {
        temp = KelvinToCelsius(temp);
        return CelsiusToFahrenheit(temp);
    }

    public static double AnyTempToAnyTemp(char source, double temp, char destination)
    {
        //use enum

        source = Char.ToLower(source);
        destination = Char.ToLower(destination);
        if (source == destination)
        {
            return temp;
        }

        switch (source)
        {
            case 'f':
                return destination == 'c' ? FahrenheitToCelsius(temp) : FahrenheitToKelvin(temp);
            case 'c':
                return destination == 'f' ? CelsiusToFahrenheit(temp) : CelsiusToKelvin(temp);
            case 'k':
                return destination == 'c' ? KelvinToCelsius(temp) : KelvinToFahrenheit(temp);
            default:
                Console.Write("Default");
                break;
        }
        return temp;
    }
}

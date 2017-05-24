using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_number_click(object sender, RoutedEventArgs e)
        {
            if(resultTextBox.Text == "0" || isOperationPerformed)
            {
                resultTextBox.Clear();
            }

            isOperationPerformed = false;

            Button button = (Button)sender;
            if(button.Content.ToString() == ".")
            {
                if(!resultTextBox.Text.Contains("."))
                    resultTextBox.Text += button.Content;
            }else
                resultTextBox.Text += button.Content;
        }

        private void operator_click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operationPerformed = button.Content.ToString();

            resultValue = Double.Parse(resultTextBox.Text, CultureInfo.InvariantCulture);

            LabelOperation.Content = resultValue + " " + operationPerformed;
            isOperationPerformed = true;
        }

        private void CEButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Text = "0";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Text = "0";
            resultValue = 0;
        }

        private void equationButton_Click(object sender, RoutedEventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    resultTextBox.Text = (resultValue + Double.Parse(resultTextBox.Text, CultureInfo.InvariantCulture)).ToString();
                    break;

                case "-":
                    resultTextBox.Text = (resultValue - Double.Parse(resultTextBox.Text, CultureInfo.InvariantCulture)).ToString();
                    break;

                case "*":
                    resultTextBox.Text = (resultValue * Double.Parse(resultTextBox.Text, CultureInfo.InvariantCulture)).ToString();
                    break;

                case "/":
                    resultTextBox.Text = (resultValue / Double.Parse(resultTextBox.Text, CultureInfo.InvariantCulture)).ToString();
                    break;

                default:
                    break;
            }
        }
    }
}

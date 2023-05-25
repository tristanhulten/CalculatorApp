using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfCalculatorApp
{
    public partial class MainWindow : Window
    {
        private string currentNumber;
        private string storedNumber;
        private char currentOperator;

        public MainWindow()
        {
            InitializeComponent();
            Clear();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var number = button.Content.ToString();
            currentNumber += number;
            resultTextBox.Text = currentNumber;
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!currentNumber.Contains(","))
            {
                currentNumber += ",";
                resultTextBox.Text = currentNumber;
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var operation = button.Content.ToString()[0];

            if (currentNumber != "")
            {
                if (storedNumber != "")
                {
                    Calculate();
                    storedNumber = currentNumber;
                }
                else
                {
                    storedNumber = currentNumber;
                }
                currentNumber = "";
            }

            currentOperator = operation;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            currentNumber = "";
            storedNumber = "";
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Calculate()
        {
            if (currentNumber != "" && storedNumber != "")
            {
                double num1 = double.Parse(storedNumber);
                double num2 = double.Parse(currentNumber);
                double result = 0;

                switch (currentOperator)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if(num2 == 0)
                        {
                            resultTextBox.Text = "Math error";
                            return;
                        }
                        result = num1 / num2;
                        break;
                }

                currentNumber = result.ToString();
                resultTextBox.Text = currentNumber;
            }
        }

        private void Clear()
        {
            currentNumber = "";
            storedNumber = "";
            currentOperator = '\0';
            resultTextBox.Text = "0";
        }
    }
}

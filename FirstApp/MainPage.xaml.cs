using System;
using Xamarin.Forms;

namespace FirstApp
{
    public partial class MainPage : ContentPage
    {

        public string displayValue;

        public double leftOperand;
        public double rightOperand;
        public double result;

        public bool operationSelected = false;
        public string operation;

        public string decimalPoint;

        public enum Operation { Add, Subtract, Multiply, Divide, Percent };

        public MainPage()
        {
            InitializeComponent();
            displayValue = "0";
            numbersField.Text = displayValue;
            decimalPoint = findDecimalPointSign();
            DecimalBtn.Text = decimalPoint;
        }

        private string findDecimalPointSign()
        {
            double a = 2.5;
            string txt = a.ToString();
            return txt.Substring(1, 1);
        }

        private void DisplayValue()
        {
            numbersField.Text = displayValue;
        }

        private void onDigitButtonClick(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (numbersField.Text == "0" && btn.Text != decimalPoint)
            {
                displayValue = btn.Text;
            }
            else
            {
                displayValue += btn.Text;
            }
            if (operationSelected) rightOperand = double.Parse(displayValue);
            else
            {
                if (!displayValue.EndsWith(decimalPoint))
                {
                    leftOperand = double.Parse(displayValue);
                }
            }
            DisplayValue();

        }

        private void onClearClick(Object sender, EventArgs e)
        {
            leftOperand = 0;
            rightOperand = 0;
            result = 0;
            displayValue = "0";
            operationSelected = false;
            DisplayValue();
        }

        private void onOperationButtonClick(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "+/-")
            {
                if (operationSelected)
                {
                    rightOperand = -rightOperand;
                    displayValue = rightOperand.ToString();
                }
                else
                {
                    leftOperand = -leftOperand;
                    displayValue = leftOperand.ToString();
                }
            }
            else if (btn.Text == "%" && !operationSelected)
            {
                leftOperand = leftOperand / 100;
                displayValue = leftOperand.ToString();
            }
            else
            {
                if (operationSelected) return;
                operation = btn.Text;
                operationSelected = true;
                displayValue = "";
            }
            DisplayValue();
        }

        private void onEqualButtonClicked(Object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    result = leftOperand + rightOperand;
                    break;
                case "-":
                    result = leftOperand - rightOperand;
                    break;
                case "x":
                    result = leftOperand * rightOperand;
                    break;
                case "/":
                    result = leftOperand / rightOperand;
                    break;
            }
            displayValue = result.ToString();
            DisplayValue();
            operationSelected = false;
            operation = "";
            rightOperand = 0;
            leftOperand = result;
        }
    }
}

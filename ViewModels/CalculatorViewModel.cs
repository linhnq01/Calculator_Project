using CalculatorMVVM.Commands;
using CalculatorMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CalculatorMVVM.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {
        #region Properties
        public CalculatorModel _model { get; set; } = new CalculatorModel();

        private string _entered_Number = "";
        public string Entered_Number
        {
            get { return _entered_Number; }
            set
            {
                _entered_Number = value;
                OnPropertyChanged("Entered_Number");
            }
        }

        private string _keyPressedString;
        public string KeyPressedString
        {
            get { return _keyPressedString; }
            set
            {
                _keyPressedString = value;
                OnPropertyChanged("KeyPressedString");
            }
        }
        #endregion

        #region Commands
        public ICommand DigitButtonPressCommand { get; set; }
        public ICommand OperationButtonPressCommand { get; set; }
        public ICommand FunctionButtonPressCommand { get; set; }
        public ICommand KeyBindingCommand { get; set; }
        #endregion

        #region Methods
        public double Factorial(double number)
        {
            if (number >= 171)
            {
                return Double.PositiveInfinity; // Trả về dương vô cùng nếu đầu vào quá lớn
            }
            else if (number < 0)
            {
                return Double.NaN; // Trả về NaN (Không phải số) nếu đầu vào là số âm
            }
            else
            {
                double decimalPartOfNumber = number - Math.Floor(number); // Trích xuất phần thập phân của số
                if (decimalPartOfNumber == 0.0)
                {
                    // Nếu số là số nguyên
                    BigInteger factorial = BigInteger.One;
                    for (int i = 1; i <= (int)number; i++)
                    {
                        factorial *= i;
                    }
                    return (double)factorial; // Chuyển đổi giai thừa thành Double và trả về
                }
                else
                {
                    return GammaLanczos(number + 1); // Nếu số không phải là số nguyên, sử dụng phương pháp xấp xỉ Lanczos của hàm gamma
                }
            }
        }

        public double GammaLanczos(double x)
        {
            double xx = x;
            List<double> p = new List<double>();
            p.Add(0.9999999999998099);
            p.Add(676.5203681218851);
            p.Add(-1259.1392167224028);
            p.Add(771.3234287776531);
            p.Add(-176.6150291621406);
            p.Add(12.507343278686905);
            p.Add(-0.13857109526572012);
            p.Add(9.984369578019572E-6);
            p.Add(1.5056327351493116e-7);
            int g = 7;
            if (xx < 0.5) return Math.PI / (Math.Sin(Math.PI * xx) * GammaLanczos(1.0 - xx));
            xx--;
            double a = p[0];
            double t = xx + g + 0.5;
            for (int i = 1; i < p.Count; i++)
            {
                a += p[i] / (xx + i);
            }
            return Math.Sqrt(2.0 * Math.PI) * Math.Pow(t, xx + 0.5) * Math.Exp(-t) * a;
        }


        public double pow(double firstNumber, int n)
        {
            if (n == 0) return 1;
            if ((n & 1) == 1)
                return pow(firstNumber, n / 2) * pow(firstNumber, n / 2) * firstNumber;
            return pow(firstNumber, n / 2) * pow(firstNumber, n / 2);

        }
        private string Cal(double firstNumber, double secondNumber, string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                case "^":
                    result = pow(firstNumber, (int)secondNumber);
                    break;
                case "sqrt":
                    result = Math.Sqrt(firstNumber);
                    break;
                default:
                    break;
            }
            return result.ToString();

        }
        public void Clear()
        {
            KeyPressedString = "";
        }

        private double thirdNumber = 0;
        public int count = 0;

        public void result(string operation)
        {
            _model.FirstOperand = Convert.ToDouble(Entered_Number);
            if (operation == "+" || operation == "-" || operation == "*" || operation == "/" || operation == "^")
            {
                KeyPressedString += Entered_Number + operation;
                _model.Operation = operation;
                Entered_Number = "";
            }
            else if (operation == "√")
            {
                KeyPressedString += operation + Entered_Number;
                Entered_Number = "";
            }
            else if (operation == "%" || operation == "!")
            {
                KeyPressedString += Entered_Number + operation;
                Entered_Number = "";
            }
            else
            {
                KeyPressedString += operation + $"({_model.FirstOperand})";
                Entered_Number = "";
            }
        }

        private void equalTo()
        {
            if (count == 0)
            {
                _model.SecondOperand = Convert.ToDouble(Entered_Number);
                thirdNumber = _model.SecondOperand;
                count++;
                Entered_Number = Cal(_model.FirstOperand, thirdNumber, _model.Operation);
                Clear();
                KeyPressedString = _model.FirstOperand + _model.Operation + thirdNumber.ToString() + " =";
            }
            else
            {
                _model.FirstOperand = Convert.ToDouble(Entered_Number);
                Entered_Number = Cal(_model.FirstOperand, thirdNumber, _model.Operation);
                Clear();
                KeyPressedString = _model.FirstOperand + _model.Operation + thirdNumber.ToString() + " =";
            }
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public void GetDeleteButtonPress()
        {
            if (Entered_Number.Length > 0)
                Entered_Number = Entered_Number.Remove(Entered_Number.Length - 1);
        }

        public void GetResetButtonPress()
        {
            _model.FirstOperand = 0;
            _model.SecondOperand = 0;
            Entered_Number = "";
            KeyPressedString = "";
        }
        #endregion

        public void GetPressButtonOperation(string operation)
        {
            try
            {
                switch (operation)
                {
                    case "+":
                        result(operation);
                        break;
                    case "-":
                        result(operation);
                        break;
                    case "*":
                        result(operation);
                        break;
                    case "/":
                        result(operation);
                        break;
                    case "^":
                        result(operation);
                        break;
                    case "√":
                        result(operation);
                        Entered_Number = (Math.Sqrt(_model.FirstOperand)).ToString();
                        break;
                    case "%":
                        result(operation);
                        Entered_Number = (_model.FirstOperand / 100).ToString();
                        break;
                    case "sin":
                        result(operation);
                        Entered_Number = (Math.Sin(DegreeToRadian(_model.FirstOperand))).ToString();
                        break;
                    case "cos":
                        result(operation);
                        Entered_Number = (Math.Cos(DegreeToRadian(_model.FirstOperand))).ToString();
                        break;
                    case "!":
                        result(operation);
                        Entered_Number = Factorial(_model.FirstOperand).ToString();
                        break;
                    case "=":
                        equalTo();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Có lỗi: " + e.Message);

            }
        }

        

        public CalculatorViewModel()
        { 

            DigitButtonPressCommand = new DigitButtonPressCommand(this);

            OperationButtonPressCommand = new OperationButtonPressCommand(this);

            FunctionButtonPressCommand = new FunctionButtonPressCommand(this);

            KeyBindingCommand = new KeyBindingCommand(this);

        }


    }
}

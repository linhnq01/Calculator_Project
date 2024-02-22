using CalculatorMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorMVVM.Commands
{
    public class KeyBindingCommand : ICommand
    {
        private readonly CalculatorViewModel _viewModel;

        public KeyBindingCommand(CalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            switch (parameter.ToString())
            {
                case "0":
                    _viewModel.Entered_Number += "0";
                    break;
                case "1":
                    _viewModel.Entered_Number += "1";
                    break;
                case "2":
                    _viewModel.Entered_Number += "2";
                    break;
                case "3":
                    _viewModel.Entered_Number += "3";
                    break;
                case "4":
                    _viewModel.Entered_Number += "4";
                    break;
                case "5":
                    _viewModel.Entered_Number += "5";
                    break;
                case "6":
                    _viewModel.Entered_Number += "6";
                    break;
                case "7":
                    _viewModel.Entered_Number += "7";
                    break;
                case "8":
                    _viewModel.Entered_Number += "8";
                    break;
                case "9":
                    _viewModel.Entered_Number += "9";
                    break;
                case ".":
                    _viewModel.Entered_Number += ".";
                    break;
                case "+":
                    _viewModel.GetPressButtonOperation(parameter.ToString());
                    break;
                case "-":
                    _viewModel.GetPressButtonOperation(parameter.ToString());
                    break;
                case "*":
                    _viewModel.GetPressButtonOperation(parameter.ToString());
                    break;
                case "/":
                    _viewModel.GetPressButtonOperation(parameter.ToString());
                    break;
            }
        }
    }
}

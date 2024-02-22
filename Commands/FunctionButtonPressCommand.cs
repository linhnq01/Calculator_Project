using CalculatorMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorMVVM.Commands
{
    public class FunctionButtonPressCommand : ICommand
    {
        private CalculatorViewModel _viewModel;

        public FunctionButtonPressCommand(CalculatorViewModel viewModel)
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
            if (parameter.ToString() == "Del")
            {
                _viewModel.GetDeleteButtonPress();
            }

            if (parameter.ToString() == "AC")
            {
                _viewModel.GetResetButtonPress();
                _viewModel.count = 0;
            }
        }
    }
}

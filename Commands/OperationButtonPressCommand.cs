using CalculatorMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorMVVM.Commands
{
    public class OperationButtonPressCommand : ICommand
    {
        private CalculatorViewModel _viewModel;

        public OperationButtonPressCommand(CalculatorViewModel viewModel)
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
            _viewModel.GetPressButtonOperation(parameter.ToString());
        }

    }
}

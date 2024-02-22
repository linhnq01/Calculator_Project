using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVVM.Models
{
    public class CalculatorModel
    {
        public double FirstOperand { get; set; }
        public double SecondOperand { get; set; }
        public string Operation { get; set; }

        public CalculatorModel()
        {
            FirstOperand = 0;
            SecondOperand = 0;
        }
    }
}

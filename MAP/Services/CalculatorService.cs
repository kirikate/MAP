using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Calculator;

namespace MAP.Services
{
	public class CalculatorService : ICalculatorService
	{
		public string DivideByZeroText  => CalculatorClass.DivideByZeroText;
		public string BigValueText => CalculatorClass.BigValueText;

		public string GetErrors(string expression) => CalculatorClass.GetErrors(expression);

		public string Eval(string expression)
		{
			return CalculatorClass.Eval(expression);
		}

		public bool IsValidExpression(string expression)
		{
			return CalculatorClass.IsValidExpression(expression);
		}
	}
}

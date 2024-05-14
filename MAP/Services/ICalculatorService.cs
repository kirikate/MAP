using Domain.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Services
{
	public interface ICalculatorService
	{
		public string DivideByZeroText { get; }
		public string BigValueText { get; }

		public string GetErrors(string expression);

		public bool IsValidExpression(string expression);

		public string Eval(string expression);
	}
}

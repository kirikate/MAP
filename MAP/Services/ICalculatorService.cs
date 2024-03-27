using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Services
{
	public interface ICalculatorService
	{
		public bool IsValidExpression(string expression);

		public string Eval(string expression);
	}
}

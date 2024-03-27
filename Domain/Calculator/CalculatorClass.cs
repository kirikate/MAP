using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using org.matheval;

namespace Domain.Calculator;

public static class CalculatorClass
{
	public static bool IsValidExpression(string expression)
	{
		var expr = new Expression(expression);
		return expr.GetError().Count == 0;
	}

	public static string Eval(string expression)
	{
		var expr = new Expression(expression);

		return expr.Eval().ToString();
	}
}

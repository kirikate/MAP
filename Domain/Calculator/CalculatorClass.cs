using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using org.matheval;

namespace Domain.Calculator;

public static class CalculatorClass
{
	public const string BigValueText = "Return value is too big";
	public const string DivideByZeroText = "Division by zero";
	public static bool IsValidExpression(string expression)
	{
		var expr = new Expression(expression);
		return expr.GetError().Count == 0;
	}

	public static string GetErrors(string expression)
	{
		var expr = new Expression(expression);
		string result = expr.GetError().First();
		foreach (string error in expr.GetError().Skip(1))
		{
			result += $", {error}";
			
		}

		return result;
	}

	public static string Eval(string expression)
	{
		var expr = new Expression(expression);
		try
		{
			return expr.Eval().ToString();
		}
		catch(System.OverflowException)
		{
			return BigValueText;
		}
		catch(DivideByZeroException) 
		{
			return DivideByZeroText;
		}
	}
}

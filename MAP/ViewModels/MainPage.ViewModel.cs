using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAP.Helpers;
using MAP.Services;

namespace MAP.ViewModels;

public partial class MainPageViewModel: ObservableObject
{
	ICalculatorService _cs;
	IServiceProvider _serviceProvider;
	IThemeService _ts;

	public MainPageViewModel(ICalculatorService cs, IServiceProvider serviceProvider, IThemeService ts) 
	{ 
		_cs = cs;
		_serviceProvider = serviceProvider;
		_ts = ts;
	}

	[ObservableProperty]
	string _expressionText = "";
	[ObservableProperty]
	string _errorText = "";

	Stack<string> _stack = new Stack<string>();

	[RelayCommand]
	void Input(object sender)
	{
		if(sender is Button button) 
		{
			if(ExpressionText == _cs.BigValueText || ExpressionText == _cs.DivideByZeroText)
			{
				ExpressionText = "";
			}
			ExpressionText += button.Text;

			IsValidExpression = _cs.IsValidExpression(ExpressionText);
			if(IsValidExpression)
			{
				ErrorText = "";	
			}
			else
			{
				ErrorText = _cs.GetErrors(ExpressionText);
			}
		}
	}

	[RelayCommand]
	void Calculate()
	{
		if (ExpressionText == _cs.BigValueText || ExpressionText == _cs.DivideByZeroText || ExpressionText == "")
		{
			return;
		}

		if (IsValidExpression)
		{
			ExpressionText = _cs.Eval(ExpressionText);
			ExpressionText = ExpressionText.Replace(',', '.');
		}
	}

	[ObservableProperty]
	bool _isValidExpression = true;

	[RelayCommand]
	void Delete()
	{
		if (ExpressionText == _cs.BigValueText || ExpressionText == _cs.DivideByZeroText)
		{
			ExpressionText = "";
		}
		if (_expressionText.Length != 0)
		{
			ExpressionText = _expressionText.Substring(0, _expressionText.Length - 1);
			IsValidExpression = _cs.IsValidExpression(ExpressionText);
			if (IsValidExpression)
			{
				ErrorText = "";
			}
			else
			{
				ErrorText = _cs.GetErrors(ExpressionText);
			}
		}
	}

	[RelayCommand]
	void Clear()
	{
		ExpressionText = "";
	}

	[RelayCommand]
	void Push()
	{
		_stack.Push(ExpressionText);
	}

	[RelayCommand]
	void Pop() 
	{
		if (_stack.Count == 0) return;
		ExpressionText += _stack.Pop();
		IsValidExpression = _cs.IsValidExpression(ExpressionText);
		if (IsValidExpression)
		{
			ErrorText = "";
		}
		else
		{
			ErrorText = _cs.GetErrors(ExpressionText);
		}
	}

	[RelayCommand]
	void Lab2()
	{
		Page popup = _serviceProvider.GetKeyedService<Page>("Lab2Popup");
		ArgsHelper.Send += ArgsHelper_Send;
		Application.Current.MainPage.Navigation.PushModalAsync(popup);

	}

	private void ArgsHelper_Send(object obj)
	{
		if(obj is int val)
		{
			ExpressionText += val.ToString();
		}

		IsValidExpression = _cs.IsValidExpression(ExpressionText);
		if (IsValidExpression)
		{
			ErrorText = "";
		}
		else
		{
			ErrorText = _cs.GetErrors(ExpressionText);
		}

		ArgsHelper.Send -= ArgsHelper_Send;
	}

	[RelayCommand]
	void ChangeTheme()
	{
		var theme = _ts.GetCurrentTheme();
		if(theme == Theme.Default) 
		{
			theme = Theme.Second;
		}
		else
		{
			theme = Theme.Default;
		}

		_ts.SetCurrentTheme(theme);
	}
}

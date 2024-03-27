using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAP.Services;

namespace MAP.ViewModels;

public partial class MainPageViewModel: ObservableObject
{
	ICalculatorService _cs;
	public MainPageViewModel(ICalculatorService cs) { _cs = cs; }

	[ObservableProperty]
	string _expressionText = "";

	[RelayCommand]
	void Input(object sender)
	{
		if(sender is Button button) 
		{
			ExpressionText += button.Text;

			IsValidExpression = _cs.IsValidExpression(ExpressionText);
		}
	}

	[RelayCommand]
	void Calculate()
	{
		if(IsValidExpression)
			ExpressionText = _cs.Eval(ExpressionText);
	}

	[ObservableProperty]
	bool _isValidExpression = true;

	[RelayCommand]
	void Delete()
	{
		if(_expressionText.Length != 0)
			ExpressionText = _expressionText.Substring(0, _expressionText.Length - 1);
	}

	[RelayCommand]
	void Clear()
	{
		ExpressionText = "";
	}
}

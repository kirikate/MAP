using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Services
{

	public enum Theme
	{
		Default,
		Second
	}
	public interface IThemeService
	{
		Theme GetCurrentTheme();

		void SetCurrentTheme(Theme theme);
	}
}

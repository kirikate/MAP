using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Helpers
{
	public static class ServiceHelper
	{
		public static IServiceProvider ServiceProvider { get; private set; }
		public static void SetServiceProvider(IServiceProvider sp) => ServiceProvider = sp;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.Helpers
{
	public static class ArgsHelper
	{
		public delegate void SendDelegate(object obj);
		static public event SendDelegate? Send = null;
		public static void Invoke(object obj) => Send.Invoke(obj);

		public static void Clear() => Send = null;
	}
}

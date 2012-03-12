using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aren.menu
{
	class MenuStateEventArgs : EventArgs
	{
		public enum states
		{
			main = 1,
			play,
			cont,
			load,
			save,
			options,
			exit
		}

		public states state;

		public MenuStateEventArgs (states changeTo)
		{
			state = changeTo;
		}
	}
}

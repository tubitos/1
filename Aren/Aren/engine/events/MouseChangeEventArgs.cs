using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Aren.engine.events
{
	class MouseChangeEventArgs : EventArgs
	{
		public MouseState mouseState;

		public MouseChangeEventArgs (MouseState mouseState)
		{
			this.mouseState = mouseState;
		}
	}
}

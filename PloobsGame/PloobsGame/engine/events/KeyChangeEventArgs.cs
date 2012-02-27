using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace PloobsGame.engine.events
{
	class KeyChangeEventArgs : EventArgs
	{
		public KeyboardState keyState;

		public KeyChangeEventArgs (KeyboardState keyState)
		{
			this.keyState = keyState;
		}
	}
}

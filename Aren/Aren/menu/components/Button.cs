using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Aren.menu.components
{
	class Button
	{
		public Vector2 position;
		public float width;
		public float height;
		public String text;

		public Button ()
		{

		}

		public static event EventHandler Click;
		public static event EventHandler MouseOver;
		public static event EventHandler MouseDown;
	}
}

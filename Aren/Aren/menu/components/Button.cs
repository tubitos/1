using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Aren.engine.settings;
using Microsoft.Xna.Framework.Input;

namespace Aren.menu.components
{
	class Button
	{
		public Vector2 position;
		public float width;
		public float height;
		public String text;

		public Button ()
			: this (0, 0, 1, 1)
		{
			
		}

		public Button (float x, float y, float width, float height)
			: this (new Vector2(x, y), width, height)
		{

		}

		public Button (Vector2 position, float width, float height)
		{
			this.position = position;
			this.height = height;
			this.width = width;
		}

		public Boolean WithinBounds (float x, float y)
		{
			return WithinBounds(new Vector2(x, y));
		}

		public Boolean WithinBounds (Vector2 point)
		{
			if (point.X < position.X)
			{
				return false;
			}
			else if (point.X > (position.X + width))
			{
				return false;
			}

			if (point.Y < position.Y)
			{
				return false;
			}
			else if (point.Y > (position.Y + height))
			{
				return false;
			}

			return true;
		}

		public void Update ()
		{
			MouseState mstate = InputStates.mstate;
			MouseState omstate = InputStates.omstate;

			if (WithinBounds(mstate.X, mstate.Y))
			{
				MouseOver(this, new MouseOverEventArgs());

				if (mstate.LeftButton == ButtonState.Pressed)
				{
					MouseDown(this, new MouseDownEventArgs());

					if (omstate.LeftButton == ButtonState.Released)
					{
						Click(this, new ButtonClickEventArgs());
					}
				}
			}
		}

		public static event EventHandler Click;
		public static event EventHandler MouseOver;
		public static event EventHandler MouseDown;
	}
}

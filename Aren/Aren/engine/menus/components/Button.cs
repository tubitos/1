using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Aren.engine.menus.components
{
	class Button
	{
		Texture2D normal;
		Texture2D mouseOver;
		Texture2D mouseLeftDown;
		//Texture2D mouseRightDown;
		Texture2D mouseRelease;

		float _width;
		float _height;

		public float width
		{
			get
			{
				return _width;
			}
			set
			{
				if (value >= 0)
				{
					_width = value;
				}
				else
				{
					throw new ArgumentException ("Width can not be less then zero!");
				}
			}
		}
		public float height
		{
			get
			{
				return _height;
			}
			set
			{
				if (value >= 0)
				{
					_height = value;
				}
				else
				{
					throw new ArgumentException ("Height can not be less then zero!");
				}
			}
		}

		Boolean oneState;
		int state;

		public Button (Texture2D initial, float width, float height)
			: this (initial, null, null, null, width, height)
		{
			oneState = true;
			state = 0;
		}

		public Button (Texture2D initial, Texture2D hover, Texture2D click, Texture2D release, float width, float height)
		{
			normal = initial;
			mouseOver = hover;
			mouseLeftDown = click;
			mouseRelease = release;

			this.width = width;
			this.height = height;

			if (!oneState)
			{
				oneState = false;
			}
		}

		public Texture2D GetState ()
		{
			if (!oneState)
			{
				switch (state)
				{
					case 0:
						return normal;

					case 1:
						return mouseOver;

					case 2:
						return mouseLeftDown;

					case 3:
						return mouseRelease;
				}
			}

			return normal;
		}

		public void Update (MouseState mstate)
		{
			if (mstate.LeftButton == ButtonState.Released)
			{
				
			}
		}
	}
}

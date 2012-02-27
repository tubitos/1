using System;
using Microsoft.Xna.Framework;

namespace PloobsGame.engine.helpers
{
	class Size
	{
		int _width;
		int _height;

		public int width
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
					throw new ArgumentException ("Width can not be less then zero");
				}
			}
		}
		public int height
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
					throw new ArgumentException ("Height can not be less then zero");
				}
			}
		}

		public Size ()
		{
			width = 0;
			height = 0;
		}

		public Size (int value)
		{
			width = height = value;
		}

		public Size (int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		public Size (Vector2 size)
		{
			width = (int)size.X;
			height = (int)size.Y;
		}

		public Vector2 ToVector2 ()
		{
			return new Vector2 (width, height);
		}

		public static Vector2 SizeToVector2 (Size size)
		{
			return new Vector2 (size.width, size.height);
		}
	}
}
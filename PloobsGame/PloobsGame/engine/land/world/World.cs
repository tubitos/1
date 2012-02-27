using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PloobsGame.engine.land.chunk;

namespace PloobsGame.engine.land.world
{
	class World
	{
		Area[,] areas;

		public World (int worldSize)
		{
			areas = new Area [10, 10];
			CreateNewArea ();
		}

		void CreateNewArea ()
		{
			for (int x = 0; x < areas.GetLength (0); x++)
			{
				for (int y = 0; y < areas.GetLength (1); y++)
				{
					areas[x, y] = new Area (new Vector2 (10.0F), new Vector2 (x, y));
				}
			}
		}
	}
}

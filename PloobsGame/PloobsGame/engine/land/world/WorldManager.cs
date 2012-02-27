using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsGame.engine.helpers;
using PloobsGame.engine.land.chunk;
using Microsoft.Xna.Framework;

namespace PloobsGame.engine.land.world
{
	class WorldManager
	{
		World world;

		public WorldManager (int worldSize)
		{
			world = new World (worldSize);
		}

		public void LoadArea (Direction.direction direction, Vector2 position)
		{
			
		}

		public Area GetLocalWorld ()
		{
			throw new NotImplementedException ();
		}
	}
}

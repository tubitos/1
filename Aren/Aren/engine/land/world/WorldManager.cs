using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aren.engine.land.chunk;
using Microsoft.Xna.Framework;

namespace Aren.engine.land.world
{
	class WorldManager
	{
		World world;

		public WorldManager (int worldSize)
		{
			world = new World (worldSize);
		}

		public Area GetLocalWorld ()
		{
			throw new NotImplementedException ();
		}
	}
}

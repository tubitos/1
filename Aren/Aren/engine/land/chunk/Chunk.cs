using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.Modelo;
using Microsoft.Xna.Framework;
using PloobsEngine.Physics.Bepu;
using PloobsEngine.Physics;
using PloobsEngine.Material;
using PloobsEngine.SceneControl;
using Aren.engine.objects;

namespace Aren.engine.land.chunk
{
	class Chunk : MeshModel
	{
		public Chunk () 
			: base ()
		{

		}

		public override void SetTexture (String path, TextureType type)
		{
			model.SetTexture (path, type);
		}
	}
}

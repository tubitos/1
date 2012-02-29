using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.Physics.Bepu;
using Microsoft.Xna.Framework;
using PloobsEngine.Physics;
using PloobsEngine.SceneControl;

namespace Aren.engine.objects
{
	class MeshModel : BaseModel
	{
		TriangleMeshObject mesh;

		public override IObject modelObject
		{
			get
			{
				if (obj == null)
				{
					obj = new IObject (Materials.dMaterial, mod, mesh);
				}

				return obj;
			}
		}

		public MeshModel ()
			: base ()
		{

		}

		public void SetupCollisionModel (TriangleMeshObject collisionModel)
		{
			mesh = collisionModel;
		}
	}
}

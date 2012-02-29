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
	class BoxModel : BaseModel
	{
		public BoxModel ()
		{
			objType = new BoxObject (Vector3.Zero, 1.0F, 1.0F, 1.0F, 1.0F, Vector3.One, Matrix.Identity, MaterialDescription.DefaultBepuMaterial ());
		}

		public void SetupCollisionModel (BoxObject collisionModel)
		{
			base.SetupCollisionModel (collisionModel);
		}
	}
}

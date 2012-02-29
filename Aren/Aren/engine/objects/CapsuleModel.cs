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
	class CapsuleModel : BaseModel
	{
		public CapsuleModel ()
			: base ()
		{
			objType = new CapsuleObject (Vector3.Zero, 100.0F, 20.0F, 1.0F, Matrix.Identity, MaterialDescription.DefaultBepuMaterial ());
		}

		public void SetupCollisionModel (CapsuleObject collisionModel)
		{
			base.SetupCollisionModel (collisionModel);
		}
	}
}

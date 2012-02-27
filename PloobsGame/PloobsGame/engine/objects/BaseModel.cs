using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.Material;
using PloobsEngine.SceneControl;
using Microsoft.Xna.Framework;
using PloobsEngine.Modelo;
using PloobsEngine.Physics.Bepu;
using PloobsEngine.Physics;
using PloobsEngine;

namespace PloobsGame.engine
{
	class BaseModel
	{
		protected IObject obj;
		protected BepuEntityObject objType;

		public Vector2 worldPosition;
		public Vector2 localPosition;
		public String name;

		protected SimpleModel mod;
			
		public virtual SimpleModel model
		{
			get
			{
				return mod;
			}
			set
			{
				mod = value;
				name = value.Name;
			}
		}
		public virtual IObject modelObject
		{
			get
			{
				if (obj == null)
				{
					obj = new IObject (Materials.dMaterial, mod, objType);
				}

				return obj;
			}
		}

		public BaseModel ()
		{
			name = "unNamed";
		}

		public virtual void SetupCollisionModel (BepuEntityObject collisionModel)
		{
			throw new NotImplementedException ();
		}

		public virtual void SetTexture (String path, TextureType type)
		{
			throw new NotImplementedException ();
		}

		public virtual void SetPosition (Vector3 position)
		{
			objType.Position = position;
		}

		public virtual void SetRotation (Matrix rotation)
		{
			objType.Rotation = rotation;
		}
	}
}
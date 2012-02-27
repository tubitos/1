using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PloobsGame.engine.events
{
	class PlayerMoveEventArgs : EventArgs
	{
		public Vector3 position;
		public Vector3 rotation;
		public Vector3 faceVector;

		public PlayerMoveEventArgs (Vector3 position, Vector3 rotation, Vector3 faceVector)
		{
			this.position = position;
			this.rotation = rotation;
			this.faceVector = faceVector;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.Cameras;
using PloobsEngine.SceneControl;
using Microsoft.Xna.Framework;
using PloobsEngine.Engine.Logger;

namespace Aren.engine.entity.mob.people.player
{
	public class PlayerCamera : ICamera
	{
		public float targetVerticalOffset;

		private bool yAlwaysUp = false;

		public bool YAlwaysUp
		{
			get
			{
				return yAlwaysUp;
			}
			set
			{
				yAlwaysUp = value;
			}
		}
		bool useFakeFrontVector = false;

		private float horizontalOffset = 50;

		public float HorizontalOffset
		{
			get
			{
				return horizontalOffset;
			}
			set
			{
				horizontalOffset = value;
			}
		}
		private float verticalOffset = 25;

		public float VerticalOffset
		{
			get
			{
				return verticalOffset;
			}
			set
			{
				verticalOffset = value;
			}
		}
		private IObject obj;
		private Vector3 _frente = Vector3.UnitX;

		public PlayerCamera (IObject obj, float camereaVerticalOffset)
		{
			targetVerticalOffset = camereaVerticalOffset;

			this.obj = obj;
			Up = Vector3.Up;
			init();
		}

		public PlayerCamera (IObject obj, float horizontalOffset, float verticalOffset)
			: this(obj, 0)
		{
			this.horizontalOffset = horizontalOffset;
			this.verticalOffset = verticalOffset;
		}

		private void init ()
		{
			_projection = Matrix.CreatePerspectiveFieldOfView(_fieldOdView, _aspectRatio, _nearPlane, _farPlane);
		}

		private Vector3 DescobrirTras ()
		{
			if (useFakeFrontVector == true)
			{
				return _frente * (-horizontalOffset);
			}
			else
			{
				return obj.PhysicObject.FaceVector * (-horizontalOffset);
			}

		}

		private Vector3 DescobrirCima ()
		{
			if (yAlwaysUp)
				return Vector3.Up * verticalOffset;

			Vector3 p0 = Vector3.Zero;
			Vector3 p1 = Vector3.Up;
			Vector3 f1 = Vector3.Transform(p0, obj.WorldMatrix);
			Vector3 f2 = Vector3.Transform(p1, obj.WorldMatrix);
			Vector3 frente = Vector3.Subtract(f2, f1);
			frente = Vector3.Normalize(frente);
			frente = Vector3.Multiply(frente, verticalOffset);
			return frente;
		}




		#region Fields

		private Vector3 _position = Vector3.Right;
		private Vector3 _target = Vector3.Zero;
		private bool _hasmoved = true;
		private Vector3 _up = Vector3.Up;
		private Quaternion _rotation = Quaternion.Identity;
		private float _fieldOdView = MathHelper.PiOver4;
		private float _aspectRatio = 4f / 3f;
		private float _nearPlane = 1.0f;
		private float _farPlane = 1000.0f;
		private Matrix _view;
		private Matrix _projection;
		private BoundingFrustum _frustrum;
		private Matrix Vp;

		#endregion

		#region ICamera Members

		public override bool Hasmoved
		{
			get
			{
				return _hasmoved;
			}
		}

		public override Microsoft.Xna.Framework.Vector3 Position
		{
			get
			{
				return _position;
			}
			set
			{
				this._position = value;
				_view = Matrix.CreateLookAt(value, _target, _up);// cria o lookat, com a posicao do objeto como target e o offset com a transgformacao do rigidbody como a posicao da camera

			}
		}

		public override Microsoft.Xna.Framework.Vector3 Target
		{
			get
			{
				return this._target;
			}
			set
			{
				this._target = value;

				_target.Y = value.Y + targetVerticalOffset;

				_view = Matrix.CreateLookAt(_position, _target, Up);// cria o lookat, com a posicao do objeto como target e o offset com a transgformacao do rigidbody como a posicao da camera
			}
		}

		public override Microsoft.Xna.Framework.Vector3 Up
		{
			get
			{
				return _up;
			}
			set
			{
				this._up = value;
				_view = Matrix.CreateLookAt(_position, _target, value);// cria o lookat, com a posicao do objeto como target e o offset com a transgformacao do rigidbody como a posicao da camera
			}
		}

		public override Microsoft.Xna.Framework.Quaternion Rotation
		{
			get
			{
				ActiveLogger.LogMessage("Cant set/get Rotation in this Camera: " + Name + " Returning Identity", LogLevel.RecoverableError);
				return Quaternion.Identity;
			}
			set
			{
				ActiveLogger.LogMessage("Cant set/get Rotation in this Camera: " + Name, LogLevel.RecoverableError);
			}
		}

		public override float FieldOfView
		{
			get
			{
				return this._fieldOdView;
			}
			set
			{
				this._fieldOdView = value;
				_projection = Matrix.CreatePerspectiveFieldOfView(_fieldOdView, _aspectRatio, _nearPlane, _farPlane);

			}
		}

		public override float AspectRatio
		{
			get
			{
				return _aspectRatio;
			}
			set
			{
				this._aspectRatio = value;
				_projection = Matrix.CreatePerspectiveFieldOfView(_fieldOdView, _aspectRatio, _nearPlane, _farPlane);
			}
		}

		public override float NearPlane
		{
			get
			{
				return this._nearPlane;
			}
			set
			{
				this._nearPlane = value;
				_projection = Matrix.CreatePerspectiveFieldOfView(_fieldOdView, _aspectRatio, _nearPlane, _farPlane);
			}
		}

		public override float FarPlane
		{
			get
			{
				return this._farPlane;
			}
			set
			{
				this._farPlane = value;
				_projection = Matrix.CreatePerspectiveFieldOfView(_fieldOdView, _aspectRatio, _nearPlane, _farPlane);
			}
		}

		public override Matrix View
		{
			get
			{
				return _view;
			}
		}

		public override Microsoft.Xna.Framework.Matrix Projection
		{
			get
			{
				return _projection;
			}
		}

		public override Microsoft.Xna.Framework.BoundingFrustum BoundingFrustum
		{
			get
			{
				if (_hasmoved)
				{
					this._frustrum = new BoundingFrustum(_view * _projection);
					return this._frustrum;
				}
				return this._frustrum;

			}
		}

		protected override void Update (Microsoft.Xna.Framework.GameTime gt)
		{
			Matrix r = Matrix.CreateTranslation(Vector3.Add(DescobrirCima(), DescobrirTras()));
			Matrix transforma = Matrix.Multiply(obj.WorldMatrix, r);
			_position = Vector3.Transform(Vector3.Zero, transforma);
			_target = Vector3.Transform(Vector3.Zero, obj.WorldMatrix);
			_target.Y += targetVerticalOffset;
			_view = Matrix.CreateLookAt(_position, _target, Up);// cria o lookat, com a posicao do objeto como target e o offset com a transgformacao do rigidbody como a posicao da camera
			Vp = View * Projection;
			_hasmoved = true;
		}


		#endregion



		public override Matrix ViewProjection
		{
			get
			{
				return Vp;
			}
		}

		public override void GetObjectData (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			ActiveLogger.LogMessage("Serialization not implemented yet", LogLevel.RecoverableError);
		}
	}
}
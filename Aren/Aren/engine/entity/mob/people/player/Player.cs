using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.Cameras;
using PloobsEngine.Physics.Bepu;
using PloobsEngine;
using PloobsEngine.SceneControl;
using Microsoft.Xna.Framework;
using PloobsEngine.Material;
using PloobsEngine.Modelo;
using Microsoft.Xna.Framework.Input;
using PloobsEngine.Utils;
using Aren.engine.settings;
using PloobsEngine.Engine;
using Aren.engine.events;

namespace Aren.engine.entity.mob.people.player
{
	class Player : Person
	{
		PlayerCamera camera;

		MouseState bstate;

		IObject obj;
		SimpleModel mod;

		Boolean isActive = true;
		Boolean useMouse = true;
		float rotSpeed;
		float zoomDistance;
		float height;
		Vector3 scale = new Vector3(.05F);

		public Player (IScreen screen, Vector3 position, Matrix rotation, SimpleModel model, float width, float height, Boolean useThirdPerson = false)
			: base(screen, position, rotation, width, height, new Vector3(.05F))
		{
			this.height = height * scale.Y;

			charecter.CharacterController.HorizontalMotionConstraint.Speed = 50;
			charecter.CharacterController.HorizontalMotionConstraint.MaximumForce = 10000;
			charecter.CharacterController.JumpSpeed = 35;

			mod = model;

			obj = new IObject(Materials.dMaterial, mod, charecter);

			Mouse.SetPosition(EngineSettings.graphicInfo.BackBufferWidth / 2, EngineSettings.graphicInfo.BackBufferHeight / 2);
			bstate = Mouse.GetState();

			rotSpeed = 0.05F;
			zoomDistance = 50;

			camera = new PlayerCamera(obj);
			camera.HorizontalOffset = -camera.HorizontalOffset;

			UpdateCamera();

			if (useThirdPerson)
			{

			}
			else
			{

			}

			this.Start();
		}

		public float viewDistance
		{
			get
			{
				return camera.FarPlane;
			}

			set
			{
				camera.FarPlane = value;
			}
		}
		public float FOV
		{
			get
			{
				return camera.FieldOfView;
			}

			set
			{
				camera.FieldOfView = value;
			}
		}

		public float rotationSpeed
		{
			get
			{
				return rotSpeed;
			}
			set
			{
				if (value > 0)
				{
					rotSpeed = value;
				}
				else
				{
					throw new ArgumentException("Rotation Speed cannot be less then or equal to zero");
				}
			}
		}

		public ICamera GetCamera ()
		{
			return camera;
		}

		public IObject GetObject ()
		{
			return obj;
		}

		void UpdateCamera ()
		{
			camera.HorizontalOffset = (-1) * zoomDistance * (float)Math.Cos(camVRot);
			camera.VerticalOffset = zoomDistance * (float)Math.Sin(camVRot);
		}

		float hRot = 0.0F;
		float vRot = 0.0F;
		float camVRot = 0;
		float camHRot = 0;
		float PI = (float)Math.PI;
		float PI2 = (float)Math.PI * 2;

		protected override void Update (GameTime gameTime)
		{
			base.Update(gameTime);

			isActive = !EngineSettings.freeMouse;

			if (isActive)
			{
				if (InputStates.mstate != bstate && useMouse == true)
				{
					float xDif = InputStates.mstate.X - bstate.X;
					float yDif = InputStates.mstate.Y - bstate.Y;

					hRot = MathHelper.ToRadians((-1) * rotSpeed * xDif);
					vRot = MathHelper.ToRadians((-1) * rotSpeed * yDif);

					Mouse.SetPosition(EngineSettings.graphicInfo.BackBufferWidth / 2, EngineSettings.graphicInfo.BackBufferHeight / 2);

					charecter.RotateYByAngleRadians(hRot);

					camHRot += hRot;
					camVRot += vRot;

					if (camHRot >= PI2)
					{
						camHRot -= PI2;
					}
					else if (camHRot <= 0)
					{
						camHRot += PI2;
					}

					if (camVRot >= PI2)
					{
						camVRot -= PI2;
					}
					else if (camVRot <= 0)
					{
						camVRot += PI2;
					}
				}

				Vector2 totalMovement = Vector2.Zero;
				Vector2 mv = VectorUtils.ToVector2(charecter.FaceVector);
				Vector2 lado = VectorUtils.Perpendicular2DNormalized(mv);

				//TO SLIDE MOVEMENT USE
				//totalMovement += lado;
				//totalMovement -= lado;

				if (InputStates.kstate.IsKeyDown(Controls.forward))
				{
					totalMovement -= mv;
				}

				if (InputStates.kstate.IsKeyDown(Controls.backward))
				{
					totalMovement += mv;
				}

				if (InputStates.kstate.IsKeyDown(Controls.strafeRight))
				{
					totalMovement -= lado;
				}

				if (InputStates.kstate.IsKeyDown(Controls.strafeLeft))
				{
					totalMovement += lado;
				}

				if (totalMovement == Vector2.Zero)
				{
					charecter.MoveToDirection(Vector2.Zero);
				}
				else
				{
					charecter.MoveToDirection(Vector2.Normalize(totalMovement));

					Quaternion q = Quaternion.CreateFromRotationMatrix(charecter.Rotation);
					PlayerMove(this, new PlayerMoveEventArgs(charecter.Position, new Vector3(q.X, q.Y, q.Z), Vector3.Normalize(charecter.FaceVector)));
				}

				//Jumping
				if (InputStates.kstate.IsKeyDown(Controls.jump))
				{
					charecter.Jump();
				}

				UpdateCamera();
			}
		}

		public static event EventHandler PlayerMove;
	}
}
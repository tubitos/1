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
		//CameraFollowObject tpCam;
		CameraFirstPerson camera;

		MouseState bstate;

		IObject obj;
		SimpleModel mod;

		Boolean isActive = true;
		Boolean useMouse = true;
		float rotSpeed;
		float zoomDistance;

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

		public Player (IScreen screen, Vector3 position, Matrix rotation, SimpleModel model, float width, float height, Boolean useThirdPerson = false)
			: base (screen, position, rotation, width, height)
		{
			charecter.CharacterController.HorizontalMotionConstraint.Speed = 50;
			charecter.CharacterController.HorizontalMotionConstraint.MaximumForce = 10000;
			charecter.CharacterController.JumpSpeed = 35;
			
			mod = model;

			obj = new IObject (Materials.dMaterial, mod, charecter);

			Mouse.SetPosition (EngineSettings.graphicInfo.BackBufferWidth / 2, EngineSettings.graphicInfo.BackBufferHeight / 2);
			bstate = Mouse.GetState ();

			rotSpeed = 0.05F;
			zoomDistance = 50;

			camera = new CameraFirstPerson(false, EngineSettings.graphicInfo);
			camera.FarPlane = 2000.0F;

			SetCameraPositionRotation();

			if (useThirdPerson)
			{
				
			}
			else
			{
				
			}

			this.Start ();
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
					throw new ArgumentException ("Rotation Speed cannot be less then or equal to zero");
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

		void SetCameraPositionRotation ()
		{
			Quaternion q = Quaternion.CreateFromRotationMatrix (charecter.Rotation);

			float rot = (float)((q.Y + 0) * Math.PI);

			Console.WriteLine(q.Y + "    " + rot);

			camera.LeftRightRot = rot;
			camera.UpDownRot = camRot;
			
			float faceL = charecter.FaceVector.Length();

			float a1 = (float)(Math.Sin(rot) * faceL);
			float b1 = (float)(Math.Cos(rot) * faceL);

			float sf = zoomDistance / faceL;
			float offx = a1 * sf;
			float offz = b1 * sf;

			Vector3 camPos = camera.Position;

			camPos.X = charecter.Position.X - offx;
			camPos.Z = charecter.Position.Z - offz;
			camPos.Y = 10;

			camera.Position = camPos;
		}

		float hRot = 0.0F;
		float vRot = 0.0F;
		float camRot = 0;

		protected override void Update (GameTime gameTime)
		{
			base.Update (gameTime);

			isActive = !EngineSettings.freeMouse;

			Console.WriteLine(charecter.Position.X + "    " + charecter.Position.Z);

			if (isActive)
			{
				//KeyboardState kstate = Keyboard.GetState ();
				//MouseState mstate = Mouse.GetState ();

				if (InputStates.mstate != bstate && useMouse == true)
				{
					float xDif = InputStates.mstate.X - bstate.X;
					float yDif = InputStates.mstate.Y - bstate.Y;

					hRot = (-1) * rotSpeed * xDif;
					vRot = (-1) * rotSpeed * yDif;

					Mouse.SetPosition (EngineSettings.graphicInfo.BackBufferWidth / 2, EngineSettings.graphicInfo.BackBufferHeight / 2);

					charecter.RotateYByAngleDegrees (hRot);
					//tpCam.Cimaoffset -= (int) (vRot * 16);

					camRot -= MathHelper.ToRadians (vRot);

					SetCameraPositionRotation();

					//tpCam.Cimaoffset = (int)(Math.Sin ((Double)camRot) * 50);
					//tpCam.Trasoffset = -(int)(Math.Cos ((Double)camRot) * 50);
				}

				Vector2 totalMovement = Vector2.Zero;
				Vector2 mv = VectorUtils.ToVector2 (charecter.FaceVector);
				Vector2 lado = VectorUtils.Perpendicular2DNormalized (mv);

				//TO SLIDE MOVEMENT USE
				//totalMovement += lado;
				//totalMovement -= lado;

				if (InputStates.kstate.IsKeyDown (Controls.forward))
				{
					totalMovement -= mv;
				}

				if (InputStates.kstate.IsKeyDown (Controls.backward))
				{
					totalMovement += mv;
				}

				if (InputStates.kstate.IsKeyDown (Controls.strafeRight))
				{
					totalMovement -= lado;
					//charecter.RotateYByAngleDegrees (-1);
				}

				if (InputStates.kstate.IsKeyDown (Controls.strafeLeft))
				{
					totalMovement += lado;
					//charecter.RotateYByAngleDegrees (1);
				}

				if (totalMovement == Vector2.Zero)
				{
					charecter.MoveToDirection (Vector2.Zero);
				}
				else
				{
					charecter.MoveToDirection (Vector2.Normalize (totalMovement));
					
					Quaternion q = Quaternion.CreateFromRotationMatrix (charecter.Rotation);
					PlayerMove (this, new PlayerMoveEventArgs (charecter.Position, new Vector3 (q.X, q.Y, q.Z), Vector3.Normalize (charecter.FaceVector)));
				}
				
				//Jumping
				if (InputStates.kstate.IsKeyDown (Controls.jump))
				{
					charecter.Jump ();
				}
			}
		}

		public static event EventHandler PlayerMove;
	}
}
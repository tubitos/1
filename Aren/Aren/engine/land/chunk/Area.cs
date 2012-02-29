using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PloobsEngine.Modelo;
using PloobsEngine.Engine;
using PloobsEngine.Physics.Bepu;
using PloobsEngine.Physics;
using Aren.engine.settings;
using Aren.engine.events;
using Aren.engine.entity.mob.people.player;
using PloobsEngine.Utils;

namespace Aren.engine.land.chunk
{
	class Area
	{
		Chunk[] world;
		List<Chunk> loadedWorld;

		int _width;
		int _length;

		public String name;

		public Chunk[] localWorld
		{
			get
			{
				return world;
			}
		}
		public int width
		{
			get
			{
				return _width;
			}
		}
		public int length
		{
			get
			{
				return _length;
			}
		}

		public Area (Vector2 worldSize)
			: this (worldSize, Vector2.Zero)
		{
			
		}

		public Area (Vector2 worldSize, Vector2 worldPosition)
		{
			name = String.Format ("Area: {0}, {1}", worldPosition.X, worldPosition.Y);

			Player.PlayerMove += new EventHandler (UpdateLoadedList);
			
			SetUpChunkArray (worldSize);

			loadedWorld = world.ToList<Chunk> ();
		}

		public Chunk[] GetLoadedChunks ()
		{
			return loadedWorld.ToArray ();
		}

		public Boolean IsLoaded (Chunk chunk)
		{
			if (loadedWorld.Contains (chunk))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void UpdateLoadedList (object sender, EventArgs e)
		{
			if (e is PlayerMoveEventArgs && sender is Player)
			{
				PlayerMoveEventArgs pmea = e as PlayerMoveEventArgs;
				Player player = sender as Player;

				#region old calculation code
				/*
				 * 
				 * calculates a "triangle" in the direction the player is facing and loads the chunks in view
				 * 
				//Calculate three points of view triangle: a, b, and c

				Vector2 a;
				Vector2 b;
				Vector2 c;
				Vector2 d = VectorUtils.ToVector2 (pmea.position);
				Vector2 face = VectorUtils.ToVector2 (pmea.faceVector);
				Vector2 f;

				float fh = player.FOV / 2;
				float v = player.viewDistance;
				float theta = MathHelper.ToRadians (pmea.rotation.Y);
				Double m;
				Double xp;
				Double zp;
				Double s;

				s = Math.Sqrt (Math.Pow((2 * d.X - face.X), 2) + Math.Pow((2 * d.Y - face.Y), 2));
				a = new Vector2 ((float)(d.X - ((100 * (face.X - d.X)) / s)), (float)(d.Y - ((100 * (face.Y - d.Y)) / s)));
				f = new Vector2 ((float)(d.X + ((v * (face.X - d.X)) / s)), (float)(d.Y + ((v * (face.Y - d.Y)) / s)));

				m = (v + 100) * Math.Tan (fh);
				xp = m * Math.Sin (theta);
				zp = m * Math.Cos (theta);

				b = new Vector2 ((float)(f.X + xp), (float)(f.Y - zp));
				c = new Vector2 ((float)(f.X - xp), (float)(f.Y + zp));

				//"Rotate" points to standerd position

				Matrix rotationMatrix = new Matrix ((float)Math.Cos (theta), (float)-Math.Sin (theta), 0, 0, (float)Math.Sin (theta), (float)Math.Cos (theta), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);


				//Get corner vertices for each chunk

				//Check if point is within triangle
				*/
				#endregion
				
				//"creates" a circle and loads the chunks within the circle

				//(x ^ 2) + (z ^ 2) = (d ^ 2)
				float xa = pmea.position.X;
				float za = pmea.position.Z;
				float d = player.viewDistance;

				List<Chunk> temp = new List<Chunk> ();

				foreach (Chunk c in world)
				{
					if ((Math.Pow (c.localPosition.X, 2) + Math.Pow (c.localPosition.Y, 2)) <= Math.Pow (d, 2))
					{
						temp.Add (c);
					}
				}

				loadedWorld = new List<Chunk> (temp.Count);

				for (int i = 0; i < temp.Count; i++)
				{
					loadedWorld.Add (temp [i]);
				}
				
				temp = null;

				Console.WriteLine ("loaded chunks updated");
			}
		}

		private void SetUpChunkArray (Vector2 worldSize)
		{
			_width = (int) worldSize.X;
			_length = (int) worldSize.Y;

			world = new Chunk[_width * _length];

			for (int i = 0; i < world.GetLength (0); i++)
			{
				world[i] = new Chunk ();
				world[i].localPosition = new Vector2 ((float) (i % _width), (float) Math.Floor ((double) i / _width));
				world[i].worldPosition = Vector2.Zero;
				world[i].model = new SimpleModel (EngineSettings.factory, "models\\landscape\\chunk\\#test\\chunk");
				world[i].SetTexture ("models\\landscape\\chunk\\#test\\chunkT", TextureType.DIFFUSE);
				world[i].name = name + String.Format (" Chunk: {0}, {1}", (i % _width), (i % _width));
				world[i].SetupCollisionModel (new TriangleMeshObject (world[i].model, (new Vector3 (1000.0F) * new Vector3 (world[i].localPosition.X, 0.0F, world[i].localPosition.Y)), Matrix.Identity, Vector3.One, MaterialDescription.DefaultBepuMaterial ()));
			}
		}

		String GetModelAt (Vector2 worldPosition, Vector2 localPosition, out String textureString)
		{
			String pre = "models\\landscape\\chunk\\";

			String wx = worldPosition.X.ToString ();
			String wy = worldPosition.Y.ToString ();

			if (wx.Length == 1)
			{
				wx = "0" + wx;
			}

			if (wy.Length == 1)
			{
				wy = "0" + wy;
			}

			String lx = localPosition.X.ToString ();
			String ly = localPosition.Y.ToString ();

			if (lx.Length == 1)
			{
				lx = "0" + lx;
			}

			if (ly.Length == 1)
			{
				ly = "0" + ly;
			}

			pre += String.Format ("{0},{1}\\", wx, wy);

			textureString = pre + String.Format ("{0},{1}T", lx, ly);
			return pre + String.Format ("{0},{1}", lx, ly);
		}
	}
}
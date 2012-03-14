using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PloobsEngine.Cameras;
using PloobsEngine.Input;
using PloobsEngine.Light;
using PloobsEngine.Material;
using PloobsEngine.Modelo;
using PloobsEngine.Physics;
using PloobsEngine.Physics.Bepu;
using PloobsEngine.SceneControl;
using Aren.engine.land.chunk;
using System.Collections.Generic;
using Aren.engine.objects;
using Aren.engine.entity.mob.people.player;
using Aren.engine.settings;

namespace Aren
{
	public class Level : IScene
	{

		//
		//sets world and render technic
		//
		protected override void SetWorldAndRenderTechnich (out IRenderTechnic renderTech, out IWorld world)
		{
			BepuPhysicWorld bpw = new BepuPhysicWorld (-98.0F, true, 1.0F);

			world = new IWorld (bpw, new SimpleCuller ());

			DeferredRenderTechnicInitDescription desc = DeferredRenderTechnicInitDescription.Default ();
			desc.UseFloatingBufferForLightMap = true;
			renderTech = new DeferredRenderTechnic (desc);
		}

		Area localWorld;

		//
		//load content for the screen
		//
		protected override void LoadContent (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.GraphicFactory factory, IContentManager contentManager)
		{
			//
			//Setup Statics
			//
			EngineSettings.factory = factory;
			EngineSettings.graphicInfo = GraphicInfo;
			EngineSettings.freeMouse = false;

			Controls.forward = Keys.W;
			Controls.backward = Keys.S;
			Controls.strafeLeft = Keys.A;
			Controls.strafeRight = Keys.D;
			Controls.jump = Keys.Space;
			Controls.crouch = Keys.LeftControl;

			InputStates.omstate = Mouse.GetState ();
			InputStates.okstate = Keyboard.GetState ();

			base.LoadContent (GraphicInfo, factory, contentManager);

			//
			//Create player and player camera
			//
			Player player = new Player (this, new Vector3 (675, 100, 1566), Matrix.Identity,
				new SimpleModel (factory, "Models//objects//people//baseMan", "Models//objects//people//baseManT"), 40.0F, 100.0F, true);
			World.AddObject (player.GetObject ());
			World.CameraManager.AddCamera (player.GetCamera (), "player cam");
			World.CameraManager.SetActiveCamera ("player cam");

			//
			//Setup other graphics
			//
			mouseCursor = factory.GetTexture2D ("Images//mouse//defualt");

			//
			//Create world
			//
			localWorld = new Area (new Vector2 (5));
			//localWorld.SetUpChunkArray (factory, new Vector2 (5, 5));
			//temp = localWorld.GetLoadedChunks ();//localWorld.localWorld;


			//
			//Setup Lights
			//
			#region lights
			DirectionalLightPE ld1 = new DirectionalLightPE (Vector3.Left, Color.White);
			DirectionalLightPE ld2 = new DirectionalLightPE (Vector3.Right, Color.White);
			DirectionalLightPE ld3 = new DirectionalLightPE (Vector3.Backward, Color.White);
			DirectionalLightPE ld4 = new DirectionalLightPE (Vector3.Forward, Color.White);
			DirectionalLightPE ld5 = new DirectionalLightPE (Vector3.Down, Color.White);

			float li = 1F;
			ld1.LightIntensity = li;
			ld2.LightIntensity = li;
			ld3.LightIntensity = li;
			ld4.LightIntensity = li;
			ld5.LightIntensity = li;

			this.World.AddLight (ld1);
			this.World.AddLight (ld2);
			this.World.AddLight (ld3);
			this.World.AddLight (ld4);
			this.World.AddLight (ld5);
			#endregion
		}

		Chunk[] temp;

		protected override void Update (GameTime gameTime)
		{
			InputStates.mstate = Mouse.GetState ();
			InputStates.kstate = Keyboard.GetState ();

			base.Update (gameTime);
			
			//load world models
			temp = localWorld.GetLoadedChunks ();

			for (int i = 0; i < temp.GetLength (0); i++)
			{
				if (!World.ContainsObject (temp[i].modelObject))
				{
					World.AddObject (temp[i].modelObject);
				}
			}

			temp = localWorld.localWorld;
			
			for (int i = 0; i < temp.GetLength (0); i++)
			{
				if (!(World.ContainsObject (temp[i].modelObject) && localWorld.IsLoaded (temp[i])))
				{
					World.RemoveObject (temp[i].modelObject);
				}
			}

			InputStates.omstate = InputStates.mstate;
			InputStates.okstate = InputStates.kstate;
		} 

		Texture2D mouseCursor;

		protected override void Draw (GameTime gameTime, RenderHelper render)
		{
			//MouseState mstate = Mouse.GetState ();

			base.Draw (gameTime, render);

			render.RenderTextComplete ("Demo: Basic Screen Deferred", new Vector2 (GraphicInfo.Viewport.Width - 315, 15), Color.White, Matrix.Identity);

			if (EngineSettings.freeMouse)
			{
				render.RenderTextureComplete (mouseCursor, Color.White, new Rectangle (InputStates.mstate.X, InputStates.mstate.Y, 32, 32), Matrix.Identity);
			}
		}
	}
}

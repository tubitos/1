using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.SceneControl;
using PloobsEngine.Physics;
using Microsoft.Xna.Framework;
using PloobsGame.engine.settings;
using Microsoft.Xna.Framework.Graphics;

namespace PloobsGame.menu
{
	public class MainMenu : IScene
	{
		Texture2D mouseCursor;
		SpriteFont font;

		String[] menuButtonText;

		protected override void SetWorldAndRenderTechnich (out IRenderTechnic renderTech, out IWorld world)
		{
			BepuPhysicWorld bpw = new BepuPhysicWorld (-9.8F, true, 1.0F);
			
			world = new IWorld (bpw, new SimpleCuller ());

			DeferredRenderTechnicInitDescription desc = DeferredRenderTechnicInitDescription.Default ();
			desc.UseFloatingBufferForLightMap = true;
			renderTech = new DeferredRenderTechnic (desc);
		}

		protected override void InitScreen (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.EngineStuff engine)
		{
			base.InitScreen (GraphicInfo, engine);
		}

		protected override void LoadContent (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.GraphicFactory factory, IContentManager contentManager)
		{
			base.LoadContent (GraphicInfo, factory, contentManager);

			//
			//Setup other graphics
			//
			mouseCursor = factory.GetTexture2D ("Images//mouse//defualt");
		 	font = factory.GetSpriteFont ("MenuFont");
			
			//
			//Intialize text array
			//
			menuButtonText = new String[3];
		}

		protected override void AfterLoadContent (IContentManager manager, PloobsEngine.Engine.GraphicInfo ginfo, PloobsEngine.Engine.GraphicFactory factory)
		{
			base.AfterLoadContent (manager, ginfo, factory);
		}

		protected override void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			base.Update (gameTime);
		}

		protected override void Draw (Microsoft.Xna.Framework.GameTime gameTime, RenderHelper render)
		{
			base.Draw (gameTime, render);

			//Draw text
			render.RenderTextComplete ("This is the main menu!", new Vector2 (20, 20), Color.White, Matrix.Identity);

			for (int i = 0; i < (menuButtonText.GetLength (0) + 1); i++)
			{
				render.RenderTextComplete (menuButtonText[i],
					new Vector2 (100, (20 * i)), Color.White,
					Matrix.Identity, font);
			}

			//Draw Mouse
			if (EngineSettings.freeMouse)
			{
				render.RenderTextureComplete (mouseCursor, Color.White, new Rectangle (EngineSettings.mstate.X, EngineSettings.mstate.Y, 32, 32), Matrix.Identity);
			}
		}

		protected override void CleanUp (PloobsEngine.Engine.EngineStuff engine)
		{
			base.CleanUp (engine);
		}
	}
}

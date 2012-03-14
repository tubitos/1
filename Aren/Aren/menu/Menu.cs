using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.SceneControl;
using PloobsEngine.Physic2D.Farseer;
using PloobsEngine.Physics;
using Microsoft.Xna.Framework;
using PloobsEngine.SceneControl._2DScene;
using PloobsEngine.Particles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using PloobsEngine.Physic2D;
using PloobsEngine.Engine;

namespace Aren.menu
{
	public class Menu : IScreen
	{
		protected Texture2D backT;
		protected Texture2D mouseT;
		protected SpriteFont arenScript;
		protected EngineStuff engine;
		protected MouseState mstate;
		public static Boolean drawBackground;

		protected override void InitScreen (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.EngineStuff engine)
		{
			mstate = Mouse.GetState();
			this.engine = engine;

			base.InitScreen(GraphicInfo, engine);
		}

		protected override void LoadContent (GraphicInfo GraphicInfo, GraphicFactory factory, IContentManager contentManager)
		{
			mouseT = contentManager.GetAsset<Texture2D>("Images//mouse//defualt");

			base.LoadContent(GraphicInfo, factory, contentManager);
		}

		protected override void Update (GameTime gameTime)
		{
			base.Update(gameTime);

			mstate = Mouse.GetState();
		}

		protected override void Draw (GameTime gameTime, RenderHelper render)
		{
			if (drawBackground)
			{
				int w = render.GetViewPort().Width;
				int h = render.GetViewPort().Height;

				render.RenderTextureComplete(backT, Color.White, new Rectangle(0, 0, w, h), Matrix.Identity); 
			}
		}
	}
}

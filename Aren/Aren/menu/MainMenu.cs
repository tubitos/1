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

namespace Aren.menu
{
	public class MainMenu : I2DScene
	{
		protected override void SetWorldAndRenderTechnich (out RenderTechnich2D renderTech, out I2DWorld world)
		{
			world = new I2DWorld(new FarseerWorld(new Vector2(0, -1)));
			renderTech = new Basic2DRenderTechnich();
		}

		protected override void InitScreen (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.EngineStuff engine)
		{
			base.InitScreen(GraphicInfo, engine);
		}

		protected override void LoadContent (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.GraphicFactory factory, IContentManager contentManager)
		{
			base.LoadContent(GraphicInfo, factory, contentManager);
		}

		protected override void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			base.Update(gameTime);
		}

		protected override void Draw (Microsoft.Xna.Framework.GameTime gameTime, RenderHelper render)
		{
			base.Draw(gameTime, render);
		}
	}
}

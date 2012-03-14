using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aren.menu
{
	public class Options : Menu
	{
		protected override void LoadContent (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.GraphicFactory factory, PloobsEngine.SceneControl.IContentManager contentManager)
		{
			base.LoadContent(GraphicInfo, factory, contentManager);
		}

		protected override void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			base.Update(gameTime);
		}

		protected override void Draw (Microsoft.Xna.Framework.GameTime gameTime, PloobsEngine.SceneControl.RenderHelper render)
		{
			base.Draw(gameTime, render);
		}
	}
}

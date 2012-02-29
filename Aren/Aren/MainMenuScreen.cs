using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.SceneControl;
using Microsoft.Xna.Framework.Graphics;

namespace Aren
{
	class MainMenuScreen : IScene
	{
		Texture2D startButton;

		protected override void LoadContent (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.GraphicFactory factory, IContentManager contentManager)
		{
			base.LoadContent (GraphicInfo, factory, contentManager);
		}

		protected override void Draw (Microsoft.Xna.Framework.GameTime gameTime, RenderHelper render)
		{
			base.Draw (gameTime, render);
		}
	}
}

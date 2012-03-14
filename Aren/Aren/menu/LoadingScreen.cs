using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.SceneControl;
using Microsoft.Xna.Framework;
using System.Timers;
using Microsoft.Xna.Framework.Graphics;

namespace Aren.menu
{
	public class LoadingScreen : Menu
	{
		String[] texts;
		int state;
		int interval;
		int maxInterval;

		protected override void LoadContent (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.GraphicFactory factory, IContentManager contentManager)
		{
			base.LoadContent(GraphicInfo, factory, contentManager);

			texts = new String[4] { "Loading ", 
									"Loading . ", 
									"Loading . . ", 
									"Loading . . . " };
			state = 0;
			interval = 0;
			maxInterval = 5;
		}

		protected override void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			base.Update(gameTime);
		}

		protected override void Draw (Microsoft.Xna.Framework.GameTime gameTime, RenderHelper render)
		{
			render.Clear(Color.Black);

			int w = render.GetViewPort().Width;
			int h = render.GetViewPort().Height;

			render.RenderTextComplete(texts[state], new Vector2(w / 2, h / 2), Color.DarkRed, Matrix.Identity, arenScript);

			if (interval < maxInterval)
			{
				interval++;
			}
			else
			{
				ChangeState();
				interval = 0;
			}
		}

		void ChangeState ()
		{
			if (state < (texts.Length - 1))
			{
				state++;
			}
			else
			{
				state = 0;
			}
		}
	}
}

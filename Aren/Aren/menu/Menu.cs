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

namespace Aren.menu
{
	public class Menu
	{
		protected Texture2D texture;
		protected SpriteFont starFont;

		public virtual void LoadContent (ContentManager content)
		{
			starFont = content.Load<SpriteFont>("Images\\font\\StarFont");
		}

		public virtual void Update (GameTime gameTime, KeyboardState kstate, MouseState mstate)
		{

		}

		public virtual void Draw (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, Vector2.Zero, Color.White);
		}
	}
}

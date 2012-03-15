using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Aren.menu.components;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aren.menu
{
	public class MainMenu : Menu
	{
		List<Button> buttons;

		Button play;
		Button options;
		Button exit;

		public void Init ()
		{
			buttons = new List<Button>();

			//button positions
			//(627, 594)
			//(661, 666)
			//(680, 738)
			//(695, 810)
			//(675, 882)

			play = new Button(627, 594, 162, 46);
			options = new Button(695, 810, 162, 46);
			exit = new Button(675, 882, 162, 46);
			play.text = "Play";
			options.text = "Options";
			exit.text = "Quit";

			play.Click += new EventHandler(play_Click);
			options.Click += new EventHandler(options_Click);
			exit.Click += new EventHandler(exit_Click);

			buttons.Add(play);
			buttons.Add(options);
			buttons.Add(exit);
		}

		void options_Click (object sender, EventArgs e)
		{
			ScreenManager.AddScreen(screens.options);
		}

		void play_Click (object sender, EventArgs e)
		{
			//Add loading screen first, but for now
			ScreenManager.AddScreen(screens.level, screens.loadingScreen);
			ScreenManager.RemoveScreen(this);
		}

		void exit_Click (object sender, EventArgs e)
		{
			engine.Exit();
		}

		protected override void LoadContent (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.GraphicFactory factory, PloobsEngine.SceneControl.IContentManager contentManager)
		{
			arenScript = contentManager.GetAsset<SpriteFont>("Images//font//ArenScriptFont");
			backT = contentManager.GetAsset<Texture2D>("Images//menus//MainMenu");
			drawBackground = true;

			Init();

			base.LoadContent(GraphicInfo, factory, contentManager);
		}

		protected override void Update (GameTime gameTime)
		{
			base.Update(gameTime);
			
			foreach (Button b in buttons)
			{
				b.Update(mstate);
			}
		}

		protected override void Draw (GameTime gameTime, PloobsEngine.SceneControl.RenderHelper render)
		{
			base.Draw(gameTime, render);

			render.RenderBegin(Matrix.Identity);

			foreach (Button b in buttons)
			{
				render.RenderText(b.text, b.position, Vector2.One, Color.DarkRed, arenScript);
			}

			render.RenderTexture(mouseT, Color.White, new Rectangle(mstate.X, mstate.Y, 10, 10));

			render.RenderEnd();
		}
	}
}

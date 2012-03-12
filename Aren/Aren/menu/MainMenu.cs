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
	class MainMenu : Menu
	{
		List<Button> buttons;

		Button play;
		Button exit;

		public MainMenu ()
		{
			buttons = new List<Button>();

			//button positions
			//(617, 594)
			//(651, 666)
			//(670, 738)
			//(685, 810)
			//(665, 882)

			play = new Button(617, 594, 162, 46);
			exit = new Button(665, 882, 162, 46);
			play.text = "Play";
			exit.text = "Quit";

			play.Click += new EventHandler(play_Click);
			exit.Click += new EventHandler(exit_Click);

			buttons.Add(play);
			buttons.Add(exit);
		}

		void play_Click (object sender, EventArgs e)
		{
			onStateChange(MenuStateEventArgs.states.play);
		}

		void exit_Click (object sender, EventArgs e)
		{
			onStateChange(MenuStateEventArgs.states.exit);
		}

		public override void LoadContent (ContentManager content)
		{
			texture = content.Load<Texture2D>("Images\\menus\\MainMenu");

			base.LoadContent(content);
		}

		public override void Update (GameTime gameTime, KeyboardState kstate, MouseState mstate)
		{
			foreach (Button b in buttons)
			{
				b.Update(mstate);
			}

			//base.Update(gameTime, kstate, mstate);
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			foreach (Button b in buttons)
			{
				spriteBatch.DrawString(arenScript, b.text, b.position, Color.DarkRed);
			}

			spriteBatch.DrawString(arenScript, "Aren: Rise of the North", new Vector2(450, 40), Color.DarkRed);

			base.Draw(spriteBatch);
		}

		void onStateChange (MenuStateEventArgs.states changeTo)
		{
			if (ChangeState != null)
			{
				ChangeState(this, new MenuStateEventArgs(changeTo));
			}
		}

		public event EventHandler ChangeState;
	}
}

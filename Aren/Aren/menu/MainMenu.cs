﻿using System;
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
			//(607, 594)
			//(641, 666)
			//(660, 738)
			//(675, 810)
			//(655, 882)

			play = new Button(607, 594, 162, 46);
			exit = new Button(655, 882, 162, 46);
			play.text = "Play";
			exit.text = "Quit";

			play.Click += new EventHandler(play_Click);
			exit.Click += new EventHandler(exit_Click);

			buttons.Add(play);
			buttons.Add(exit);
		}

		void play_Click (object sender, EventArgs e)
		{
			
		}

		void exit_Click (object sender, EventArgs e)
		{
			
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
				spriteBatch.DrawString(starFont, b.text, b.position, Color.DarkRed);
			}
			
			spriteBatch.DrawString(starFont, "Aren: Rise of the North", new Vector2(450, 40), Color.DarkRed);

			base.Draw(spriteBatch);
		}
	}
}

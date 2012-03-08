using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PloobsEngine.Engine;
using PloobsEngine.SceneControl;
using System.Threading;
using Aren.menu;

namespace Aren
{
	public class Entry : Game
	{
		public Boolean enabled;
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Thread thread = new Thread(new ThreadStart(Play));

		MainMenu mainMenu;

		public Entry ()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			enabled = false;

			Window.Title = "Aren: Rise of the North";

			mainMenu = new MainMenu();
		}

		protected override void Initialize ()
		{
			base.Initialize();
			enabled = true;

			graphics.PreferredBackBufferHeight = 960;
			graphics.PreferredBackBufferWidth = 1280;
			graphics.ApplyChanges();
		}

		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			mainMenu.LoadContent(Content);
		}

		MouseState mstate;
		KeyboardState kstate;

		protected override void Update (GameTime gameTime)
		{
			if (enabled)
			{
				kstate = Keyboard.GetState();
				mstate = Mouse.GetState();

				if (kstate.IsKeyDown(Keys.Escape))
				{
					Exit();
				}

				if (kstate.IsKeyDown(Keys.F1))
				{
					thread.Start();
					enabled = false;
				}

				mainMenu.Update(gameTime, kstate, mstate);

				base.Update(gameTime);
			}
			else
			{
				if (!thread.IsAlive)
				{
					Exit();
				}
			}
		}

		protected override void Draw (GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);

			mainMenu.Draw(spriteBatch);

			spriteBatch.End();

			base.Draw(gameTime);

		}

		static InitialEngineDescription desc = InitialEngineDescription.Default();
		static EngineStuff engine;

		public static void Play ()
		{
			//desc.UseAnisotropicFiltering = Boolean.Parse(args[0]);
			//desc.isFixedGameTime = Boolean.Parse(args[1]);
			//desc.useMipMapWhenPossible = Boolean.Parse(args[2]);
			//desc.isMultiSampling = Boolean.Parse(args[3]);
			//desc.UseVerticalSyncronization = Boolean.Parse(args[4]);
			//desc.isFullScreen = Boolean.Parse(args[5]);

			desc.BackBufferWidth = 800;//int.Parse(args[7]);
			desc.BackBufferHeight = 600;//int.Parse(args[8]);

			engine = new EngineStuff(ref desc, LoadScreen);
			engine.Run();
		}

		static void LoadScreen (ScreenManager screenManager)
		{
			screenManager.AddScreen(new Level());
			screenManager.AddScreen(new InputManager());
		}
	}
}

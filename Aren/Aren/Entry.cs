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
using Aren.engine.settings.properties;

namespace Aren
{
	public class Entry
	{
		public static void Main (String[] args)
		{
			if (args.Contains<String>("-windowed"))
			{
				Play(true);
			}
			else
			{
				Play(false);
			}
		}

		static InitialEngineDescription desc;
		static EngineStuff engine;

		public static void Play (Boolean windowed)
		{
			Saver.Setup();

			//desc.UseAnisotropicFiltering = Boolean.Parse(args[0]);
			//desc.isFixedGameTime = Boolean.Parse(args[1]);
			//desc.useMipMapWhenPossible = Boolean.Parse(args[2]);
			//desc.isMultiSampling = Boolean.Parse(args[3]);
			//desc.UseVerticalSyncronization = Boolean.Parse(args[4]);

			desc = InitialEngineDescription.Default();
			desc.isFullScreen = !windowed;

			if (!windowed)
			{
				desc.BackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
				desc.BackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			}
			else
			{
				desc.BackBufferWidth = 1280;
				desc.BackBufferHeight = 960;
			}
			
			engine = new EngineStuff(ref desc, LoadScreen);
			engine.Run();
		}

		static void LoadScreen (ScreenManager screenManager)
		{
			screenManager.AddScreen(screens.mainMenu);

			//screenManager.AddScreen(new Level());
			//screenManager.AddScreen(new InputManager());
		}

		//void menuStateChange (object sender, EventArgs e)
		//{
		//    if (e is MenuStateEventArgs)
		//    {
		//        MenuStateEventArgs m = e as MenuStateEventArgs;

		//        switch (m.state)
		//        {
		//            case MenuStateEventArgs.states.main:
		//                break;

		//            case MenuStateEventArgs.states.play:
		//                Start();
		//                break;

		//            case MenuStateEventArgs.states.cont:
		//                break;
						
		//            case MenuStateEventArgs.states.load:
		//                break;

		//            case MenuStateEventArgs.states.save:
		//                break;

		//            case MenuStateEventArgs.states.options:
		//                break;

		//            case MenuStateEventArgs.states.exit:
		//                Exit();
		//                break;
		//        }
		//    }
		//}
	}
}

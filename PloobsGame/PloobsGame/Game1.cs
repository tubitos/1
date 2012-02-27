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

namespace PloobsGame
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		InitialEngineDescription desc = InitialEngineDescription.Default ();
		EngineStuff engine;
		
		public Game1 (String[] args)
		{
			Content.RootDirectory = "Content";
			
			desc.UseAnisotropicFiltering = Boolean.Parse (args[0]);
			desc.isFixedGameTime = Boolean.Parse (args [1]);
			desc.useMipMapWhenPossible = Boolean.Parse (args [2]);
			desc.isMultiSampling = Boolean.Parse (args [3]);
			desc.UseVerticalSyncronization = Boolean.Parse (args [4]);
			desc.isFullScreen = Boolean.Parse (args [5]);

			desc.BackBufferWidth = int.Parse (args[7]);
			desc.BackBufferHeight = int.Parse (args [8]);
			
			engine = new EngineStuff (ref desc, LoadScreen);
			engine.Run ();
		}

		void LoadScreen (ScreenManager manager)
		{
			manager.AddScreen (new BasicScreenDeferredDemo ());
			manager.AddScreen (new InputManager ());
		}
	}
}

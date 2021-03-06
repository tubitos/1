﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.SceneControl;
using PloobsEngine.Engine;
using Microsoft.Xna.Framework.Input;
using PloobsEngine.Input;
using PloobsEngine.Commands;
using PloobsEngine.MessageSystem;
using Aren.engine.settings.properties;
using Aren.engine.settings;

namespace Aren
{
	public class InputManager : IScreen
	{
		EngineStuff engine;

		protected override void InitScreen (GraphicInfo GraphicInfo, EngineStuff engine)
		{
			base.InitScreen (GraphicInfo, engine);

			this.engine = engine;
		}
		
		protected override void LoadContent (GraphicInfo GraphicInfo, GraphicFactory factory, IContentManager contentManager)
		{
			base.LoadContent (GraphicInfo, factory, contentManager);

			List<SimpleConcreteKeyboardInputPlayable> keys = new List<SimpleConcreteKeyboardInputPlayable> ();

			keys.Add (new SimpleConcreteKeyboardInputPlayable (StateKey.PRESS, Keys.Escape, LeaveGame));
			keys.Add (new SimpleConcreteKeyboardInputPlayable (StateKey.RELEASE, Keys.Tab, GameMenu));
			keys.Add (new SimpleConcreteKeyboardInputPlayable (StateKey.RELEASE, Keys.F9, Save));
			
			for (int i = 0; i < keys.Count; i++)
			{
				this.BindInput (keys [i]);
			}

		}

		protected override void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			base.Update (gameTime);
		}

		protected override void Draw (Microsoft.Xna.Framework.GameTime gameTime, RenderHelper render)
		{
			
		}

		void GameMenu (InputPlayableKeyBoard ipk)
		{
			EngineSettings.freeMouse = !EngineSettings.freeMouse;
		}

		void Save (InputPlayableKeyBoard ipk)
		{
			Saver.Save();
		}

		void LeaveGame (InputPlayableKeyBoard ipk)
		{
			engine.Exit ();
		}
	}
}
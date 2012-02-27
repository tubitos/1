using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.SceneControl;
using PloobsEngine.Engine;
using Microsoft.Xna.Framework.Input;
using PloobsEngine.Input;
using PloobsEngine.Commands;
using PloobsEngine.MessageSystem;
using PloobsGame.engine.menus;
using PloobsGame.engine.settings.properties;

namespace PloobsGame
{
	class InputManager : IScreen
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

		GameMenu gameMenu;

		void GameMenu (InputPlayableKeyBoard ipk)
		{
			if (gameMenu == null)
			{
				gameMenu = new GameMenu ();
				ScreenManager.AddScreen (gameMenu);
			}
			else
			{
				gameMenu.active = !gameMenu.active;
			}
		}

		Saver saver = new Saver ();

		void Save (InputPlayableKeyBoard ipk)
		{
			saver.Save ();
		}

		void LeaveGame (InputPlayableKeyBoard ipk)
		{
			engine.Exit ();
		}
	}
}
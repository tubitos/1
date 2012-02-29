using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.SceneControl;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PloobsEngine.Physics;
using Aren.engine.settings;
using Microsoft.Xna.Framework.Input;
using Aren.engine.helpers;

namespace Aren.engine.menus
{
	class GameMenu : IScene
	{
		Boolean _active;
		Texture2D screen;
		Vector2 screenPos;
		int numButtons;
		int buttonSpacing;
		Rectangle[] collisionBounds;
		Size buttonSize;

		public Boolean active
		{
			get
			{
				return _active;
			}
			set
			{
				_active = value;
				EngineSettings.freeMouse = value; 
			}
		}

		public GameMenu ()
		{
			active = true;
		}

		protected override void SetWorldAndRenderTechnich (out IRenderTechnic renderTech, out IWorld world)
		{
			BepuPhysicWorld bpw = new BepuPhysicWorld (-98.0F, true, 1.0F);

			world = new IWorld (bpw, new SimpleCuller ());

			DeferredRenderTechnicInitDescription desc = DeferredRenderTechnicInitDescription.Default ();
			desc.UseFloatingBufferForLightMap = true;
			renderTech = new DeferredRenderTechnic (desc);
		}

		protected override void LoadContent (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.GraphicFactory factory, IContentManager contentManager)
		{
			base.LoadContent (GraphicInfo, factory, contentManager);

			numButtons = 3;
			buttonSpacing = 2;
			buttonSize = new Size (251, 53);

			screen = contentManager.GetAsset<Texture2D> ("Images//menus/gameMenu");
			screenPos = new Vector2 ((GraphicInfo.BackBufferWidth / 2) - (screen.Width / 2),
									 (GraphicInfo.BackBufferHeight / 2) - (screen.Height / 2));

			SetupButtonBounds ();
		}

		protected override void Update (GameTime gameTime)
		{
			if (active)
			{
				//MouseState mstate = Mouse.GetState ();

				Rectangle mrect = new Rectangle (InputStates.mstate.X, InputStates.mstate.Y, 0, 0);

				if (InputStates.omstate.LeftButton == ButtonState.Released)
				{
					for (int i = 0; i < collisionBounds.GetLength (0); i++)
					{
						if (mrect.Intersects (collisionBounds [i]))
						{
							if (InputStates.mstate.LeftButton == ButtonState.Pressed)
							{
								Console.WriteLine ("Button {0} pressed", i);
								break;
							}
						}
					} 
				}
			}
		}

		protected override void Draw (GameTime gameTime, RenderHelper render)
		{
			if (active)
			{
				render.RenderTextureComplete (screen, Color.White, new Rectangle ((int)screenPos.X, (int)screenPos.Y, screen.Width, screen.Height), Matrix.Identity);
			}
		}

		void SetupButtonBounds ()
		{
			collisionBounds = new Rectangle [numButtons];

			for (int i = 0; i < collisionBounds.GetLength (0); i++)
			{
				if (i == 0)
				{
					collisionBounds [i] = new Rectangle ((int)screenPos.X, (int)screenPos.Y, buttonSize.width, buttonSize.height);
				}
				else
				{
					collisionBounds [i] = new Rectangle ((int)screenPos.X, collisionBounds[i - 1].Y + buttonSpacing + buttonSize.height, buttonSize.width, buttonSize.height);
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PloobsEngine.SceneControl.GUI;
using TomShane.Neoforce.Controls;
using Microsoft.Xna.Framework;

namespace Aren.menu
{
	public class Options : Menu
	{
		NeoforceGui ngui;
		Manager manager;

		public Options ()
			: this(new NeoforceGui())
		{
			
		}

		public Options (IGui gui)
			: base(gui)
		{
			
		}

		protected override void LoadContent (PloobsEngine.Engine.GraphicInfo GraphicInfo, PloobsEngine.Engine.GraphicFactory factory, PloobsEngine.SceneControl.IContentManager contentManager)
		{
			base.LoadContent(GraphicInfo, factory, contentManager);

			ngui = Gui as NeoforceGui;
			manager = ngui.Manager;

			Window window = new Window(manager);
			window.Init();
			window.Text = "Options";
			window.Width = 480;
			window.Height = 200;
			window.Center();
			window.Visible = true;

			Button button = new Button(manager);
			button.Init();
			button.Text = "OK";
			button.Width = 72;
			button.Height = 24;
			button.Left = (window.ClientWidth / 2) - (button.Width / 2);
			button.Top = window.ClientHeight - button.Height - 8;
			button.Anchor = Anchors.Bottom;
			button.Parent = window;
			button.Click += new TomShane.Neoforce.Controls.EventHandler(button_Click);

			manager.Add(window);
		}

		void button_Click (object sender, TomShane.Neoforce.Controls.EventArgs e)
		{
			
		}

		protected override void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			base.Update(gameTime);
		}

		protected override void Draw (Microsoft.Xna.Framework.GameTime gameTime, PloobsEngine.SceneControl.RenderHelper render)
		{
			base.Draw(gameTime, render);

			render.RenderBegin(Matrix.Identity);

			render.RenderTexture(mouseT, Color.White, new Rectangle(mstate.X, mstate.Y, 10, 10));

			render.RenderEnd();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace PloobsGame.engine.settings.properties
{
	class Saver
	{
		String settingsPath;
		KeysConverter kc;

		Hashtable keys;
		Hashtable graphics;
		Hashtable sound;
		Hashtable game;

		public Saver ()
			: this (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.None) + @"\My Games\[GAME NAME]\config\")
		{
			
		}

		public Saver (String savePath)
		{
			keys = new Hashtable ();
			graphics = new Hashtable ();
			sound = new Hashtable ();
			game = new Hashtable ();

			kc = new KeysConverter ();

			settingsPath = savePath;

			if (!Directory.Exists (settingsPath))
			{
				Directory.CreateDirectory (settingsPath);
			}

			CheckForSettingsFiles ();
		}

		void CheckForSettingsFiles ()
		{
			FileStream fs = new FileStream (settingsPath + @"keys.cfg", FileMode.Open);

			if (!File.Exists (settingsPath + @"keys.cfg"))
			{
				fs = File.Create (settingsPath + @"keys.cfg");
			}

			if (!File.Exists (settingsPath + @"graphics.cfg"))
			{
				fs = File.Create (settingsPath + @"graphics.cfg");
			}

			if (!File.Exists (settingsPath + @"sound.cfg"))
			{
				fs = File.Create (settingsPath + @"sound.cfg");
			}

			if (!File.Exists (settingsPath + @"game.cfg"))
			{
				fs = File.Create (settingsPath + @"game.cfg");
			}

			fs.Close ();
		}

		void PopulateKeys ()
		{
			keys.Add ("forward", kc.ConvertToString (Controls.forward));
			keys.Add ("backward", kc.ConvertToString (Controls.backward));
			keys.Add ("crouch", kc.ConvertToString (Controls.crouch));
			keys.Add ("jump", kc.ConvertToString (Controls.jump));
			keys.Add ("strafeLeft", kc.ConvertToString (Controls.strafeLeft));
			keys.Add ("strafeRight", kc.ConvertToString (Controls.strafeRight));
		}

		void PopulateGraphics ()
		{

		}

		void PopulateSound ()
		{

		}

		void PopulateGame ()
		{

		}

		public void Save ()
		{
			CheckForSettingsFiles ();

			StreamWriter sw;

			#region save keys
			sw = new StreamWriter (settingsPath + @"keys.cfg");

			PopulateKeys ();

			sw.WriteLine ("#Configuration for keys");

			foreach (String str in keys.Keys)
			{
				sw.WriteLine ("{0} = {1}:", str, keys [str]);
			}
			#endregion

			sw.Close ();
			sw.Dispose ();
		}
	}
}

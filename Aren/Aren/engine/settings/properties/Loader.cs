using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace Aren.engine.settings.properties
{
	class Loader
	{
		String settingsPath;
		KeysConverter kc;

		Hashtable keys;
		Hashtable graphics;
		Hashtable sound;
		Hashtable game;

		public Loader ()
			: this (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.None) + @"\My Games\[GAME NAME]\config\")
		{
			
		}

		public Loader (String savePath)
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

			if (!CheckForSettingsFiles ())
			{
				throw new FileNotFoundException ("Not all setting files are created!");
			}
		}

		Boolean CheckForSettingsFiles ()
		{
			FileStream fs = new FileStream (settingsPath + @"keys.cfg", FileMode.Open);

			if (File.Exists (settingsPath + @"keys.cfg"))
			{
				if (File.Exists (settingsPath + @"graphics.cfg"))
				{
					if (File.Exists (settingsPath + @"sound.cfg"))
					{
						if (File.Exists (settingsPath + @"game.cfg"))
						{
							return true;
						}
					}
				}
			}

			fs.Close ();

			return false;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace Aren.engine.settings.properties
{
	public static class Saver
	{
		static String settingsPath;
		static KeysConverter kc;

		static Hashtable keys;
		static Hashtable graphics;
		static Hashtable sound;
		static Hashtable game;

		public static void Setup ()
		{
			Setup(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.None) + @"\My Games\Aren\config");
		}

		public static void Setup (String savePath)
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

		static void CheckForSettingsFiles ()
		{
			try
			{
				FileStream fs;

				if (!File.Exists(settingsPath + @"\keys.cfg"))
				{
					fs = File.Create(settingsPath + @"\keys.cfg");
					fs.Close();
				}
				
				if (!File.Exists(settingsPath + @"\graphics.cfg"))
				{
					fs = File.Create(settingsPath + @"\graphics.cfg");
					fs.Close();
				}

				if (!File.Exists(settingsPath + @"\sound.cfg"))
				{
					fs = File.Create(settingsPath + @"\sound.cfg");
					fs.Close();
				}

				if (!File.Exists(settingsPath + @"\game.cfg"))
				{
					fs = File.Create(settingsPath + @"\game.cfg");
					fs.Close();
				}
			}
			catch (Exception e)
			{
				if (e is UnauthorizedAccessException)
				{
					MessageBox.Show("Unauthorized Access Exception at 'Aren.engine.settings.properties.Saver'!" +
						"\nPlese contact support regarding this issue.", "Unhandled Excepton!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
				{
					MessageBox.Show(e.StackTrace, e.Message, MessageBoxButtons.OK);
				}
			}
		}

		static void PopulateKeys ()
		{
			keys.Add ("forward", kc.ConvertToString (Controls.forward));
			keys.Add ("backward", kc.ConvertToString (Controls.backward));
			keys.Add ("crouch", kc.ConvertToString (Controls.crouch));
			keys.Add ("jump", kc.ConvertToString (Controls.jump));
			keys.Add ("strafeLeft", kc.ConvertToString (Controls.strafeLeft));
			keys.Add ("strafeRight", kc.ConvertToString (Controls.strafeRight));
		}

		static void PopulateGraphics ()
		{

		}

		static void PopulateSound ()
		{

		}

		static void PopulateGame ()
		{

		}

		public static void Save ()
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

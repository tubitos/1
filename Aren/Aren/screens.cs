using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aren.menu;

namespace Aren
{
	public static class screens
	{
		public static Level level = new Level();

		public static LoadingScreen loadingScreen = new LoadingScreen();

		public static MainMenu mainMenu = new MainMenu();
		public static Options options = new Options();
	}
}

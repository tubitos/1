using System;
namespace PloobsGame
{
#if WINDOWS || XBOX
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		public static void Main (string [] args)
		{
			for (int i = 0; i <  args.Length; i++)
			{
				Console.WriteLine (args [i]);
			}

			Game1 game = new Game1 (args);
			game.Run ();
		}
	}
#endif
}


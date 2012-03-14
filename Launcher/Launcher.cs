using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aren;
using System.Threading;

namespace Launcher
{
	public partial class Launcher : Form
	{
		static String [] args = new String [9];
		Thread thread = new Thread (new ThreadStart (gameStart));

		private static void gameStart ()
		{
			//Aren.Program.Main (args);
		}

		public Launcher ()
		{
			InitializeComponent ();
		}

		private void button2_Click (object sender, EventArgs e)
		{
			Application.Exit ();
		}

		private void button1_Click (object sender, EventArgs e)
		{
			args [0] = af.Checked ? "true" : "false";
			args [1] = force.Checked ? "true" : "false";
			args [2] = mipmaps.Checked ? "true" : "false";
			args [3] = multi.Checked ? "true" : "false";
			args [4] = vsync.Checked ? "true" : "false";
			args [5] = fullscreen.Checked ? "true" : "false";
			args [6] = (((fov.Value - 5) * 3) + 90).ToString ();

			String [] temp = res.Text.Split ('x');

			args [7] = temp [0];
			args [8] = temp [1];

			thread.Start ();

			this.Hide ();

			//while (thread.IsAlive) ;

			Application.Exit ();
		}

		private void UpdateFOV (object sender, EventArgs e)
		{
			fovvalue.Text = (((fov.Value - 5) * 3) + 90).ToString ();
		}
	}
}

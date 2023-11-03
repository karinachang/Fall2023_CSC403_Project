using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
	public partial class Menu : Form
	{
		private SoundPlayer theme = new SoundPlayer(Properties.Resources.menu);

		public Menu()
		{
			InitializeComponent();
			//start theme song
			theme.PlayLooping();
		}

		private void StartGame(object sender, EventArgs e)
		{
			// start the level on click
			// COMMENT OUT ALL LEVELS EXCEPT THE ONE YOU WANT TO TEST/RUN
			FrmLevel newGame = new FrmLevel();
            // FrmLevel2 newGame = new FrmLevel2();
            // FrmLevel3 newGame = new FrmLevel3();
            newGame.Size = new Size(1160, 740);
			this.Hide();
			// starts the level, when level window is closed this returns control to here to then close the menu
			newGame.ShowDialog();
			this.Close();
		}
	}
}

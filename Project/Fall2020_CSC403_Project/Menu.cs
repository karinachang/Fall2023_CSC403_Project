using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
	public partial class Menu : Form
	{
		private SoundPlayer song = new SoundPlayer(Properties.Resources.menu);

		public Menu()
		{
			InitializeComponent();
			//start theme song
			song.PlayLooping();
		}

		private void StartGame(object sender, EventArgs e)
		{
			// stop this level's song
			song.Stop();

            // starts the level, when level window is closed this returns control to here to then close the menu
            // COMMENT OUT ALL LEVELS EXCEPT THE ONE YOU WANT TO TEST/RUN
            FrmLevel level1 = new FrmLevel();
            // FrmLevel2 newGame = new FrmLevel2();
            // FrmLevel3 newGame = new FrmLevel3();
            level1.Size = new Size(1160, 740);
			this.Hide();
            level1.ShowDialog();

			// control returned here, close the whole Application
			this.Close();
		}
	}
}

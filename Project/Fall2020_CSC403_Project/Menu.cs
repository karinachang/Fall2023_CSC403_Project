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
            // go to backstory
            BackStory backStory = new BackStory();
            backStory.Size = new Size(800, 450);
			this.Hide();
            backStory.ShowDialog();

			// control returned here, close the whole Application
			this.Close();
		}
	}
}

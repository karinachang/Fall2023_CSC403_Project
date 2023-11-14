using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
	public partial class CutScene2 : Form
	{
        private SoundPlayer song = new SoundPlayer(Properties.Resources.wahwahwah);
        public CutScene2()
        {
            InitializeComponent();
            // Check the global mute state before playing the song
            if (!GlobalMuteState.IsMuted)
            {
                song.PlayLooping();
            }
        }

        private void StartLevel()
		{
            // starts the level
            FrmLevel2 level2  = new FrmLevel2();
            level2.Size = new Size(1160, 740);
			this.Hide();
            level2.ShowDialog();

			// control returned here
			this.Close();
		}

        private void CutScene2_KeyDown(object sender, KeyEventArgs e) {
            // wait for Enter key to be pressed
            switch (e.KeyCode) {
                case Keys.Enter:
                    StartLevel();
                    break;
                default:
                    break;
            }
        }
    }
}

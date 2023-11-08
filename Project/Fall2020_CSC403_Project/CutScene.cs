using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
	public partial class CutScene : Form
	{
		public CutScene()
		{
			InitializeComponent();
		}

		private void StartLevel()
		{
            // starts the level
            FrmLevel level  = new FrmLevel();
            level.Size = new Size(1160, 740);
			this.Hide();
            level.ShowDialog();

			// control returned here
			this.Close();
		}

        private void CutScene_KeyDown(object sender, KeyEventArgs e) {
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

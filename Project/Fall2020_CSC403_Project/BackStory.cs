using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
	public partial class BackStory : Form
	{
		public BackStory()
		{
			InitializeComponent();
		}

		private void StartCutScene()
		{
            // starts the cut scene for level 1
            CutScene2 cutScene  = new CutScene2();
            cutScene.Size = new Size(800, 450);
			this.Hide();
            cutScene.ShowDialog();

			// control returned here
			this.Close();
		}

        private void BackStory_KeyDown(object sender, KeyEventArgs e) {
            // wait for Enter key to be pressed
            switch (e.KeyCode) {
                case Keys.Enter:
                    StartCutScene();
                    break;
                default:
                    break;
            }
        }
    }
}

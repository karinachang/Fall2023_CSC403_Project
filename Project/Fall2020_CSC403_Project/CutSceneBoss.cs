using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
	public partial class CutSceneBoss : Form
	{
        public CutSceneBoss()
        {
            InitializeComponent();
        }

        private void StartLevel() {
			// go back to level control to open boss battle
			this.Close();
		}

        private void CutSceneBoss_KeyDown(object sender, KeyEventArgs e) {
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

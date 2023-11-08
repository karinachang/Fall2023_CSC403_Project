﻿using System;
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
            // starts the level, when level window is closed this returns control to here to then close the menu
            // COMMENT OUT ALL LEVELS/BACKSTORY EXCEPT THE ONE YOU WANT TO TEST/RUN
            // FrmLevel level = new FrmLevel();
            // FrmLevel2 level  = new FrmLevel2();
            // FrmLevel3 level = new FrmLevel3();
			/*
            level.Size = new Size(1160, 740);
            this.Hide();
            level.ShowDialog();
			*/
            BackStory backStory = new BackStory();
            backStory.Size = new Size(800, 450);
			this.Hide();
            backStory.ShowDialog();

			// control returned here, close the whole Application
			this.Close();
		}
	}
}

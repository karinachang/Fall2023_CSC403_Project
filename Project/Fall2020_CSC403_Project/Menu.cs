using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public static class GlobalMuteState
    {
        public static bool IsMuted { get; set; } = false;
    }

    public partial class Menu : Form
    {
        private SoundPlayer song = new SoundPlayer(Properties.Resources.menu);
        private bool isMuted = false;
        private Button btnMute;

        public Menu()
        {
            InitializeComponent();
            // Start theme song
            song.PlayLooping();

            // Create the mute button
            btnMute = new Button();
            btnMute.Size = new Size(100, 80); // Set the size as needed
            btnMute.Location = new Point(480, 200); // Set the location as needed
            btnMute.Text = "Mute";

            // Style the button to match the "Start Game" button
            btnMute.FlatStyle = FlatStyle.Flat;
            btnMute.FlatAppearance.BorderColor = Color.Black; // Set the border color
            btnMute.FlatAppearance.BorderSize = 1; // Set the border size
            btnMute.BackColor = Color.Transparent; // Match the color; you'll need to use the correct color
            btnMute.ForeColor = Color.Black; // Text color, set as needed
            btnMute.FlatAppearance.MouseOverBackColor = btnMute.BackColor;

            btnMute.Click += new EventHandler(btnMute_Click); // Subscribe to the click event
            // Add the button to the form's controls
            this.Controls.Add(btnMute);
        }



        private void StartGame(object sender, EventArgs e)
        {
            // Go to backstory
            BackStory backStory = new BackStory();
            backStory.Size = new Size(800, 450);
            this.Hide();
            backStory.ShowDialog();

            // Control returned here, close the whole Application
            this.Close();
        }

        public void btnMute_Click(object sender, EventArgs e)
        {
            // Toggle the isMuted flag
            isMuted = !isMuted;
            GlobalMuteState.IsMuted = isMuted; // Update the global mute state

            if (isMuted)
            {
                song.Stop();
                btnMute.Text = "Unmute";
            }
            else
            {
                song.PlayLooping();
                btnMute.Text = "Mute";
            }
        }

    }
}

﻿using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
	public partial class FrmLevel3 : Form {
		private Player player;
		private bool isPaused = false;
		private BossHershey bossHersheys;
		private Character hiddenCollision;
		private Character[] walls;
		private DateTime timeBegin;
		private TimeSpan totalTimePaused;
		private DateTime pauseBegin;
		private FrmBattle_Boss frmBattle;
        private PictureBox healthBarBackground;
        private PictureBox healthBar;
        private Label lblHealthValue;

        private void InitializeHealthBar()
        {
            // Initialize Health Bar Background
            healthBarBackground = new PictureBox();
            healthBarBackground.Size = new Size(200, 25);
            healthBarBackground.Location = new Point(10, this.ClientSize.Height - healthBarBackground.Height - 10);
            healthBarBackground.BackColor = Color.Gray;
            this.Controls.Add(healthBarBackground);

            // Initialize Actual Health Bar
            healthBar = new PictureBox();
            healthBar.Size = new Size(200, 25);
            healthBar.Location = new Point(10, this.ClientSize.Height - healthBar.Height - 10);
            healthBar.BackColor = Color.Green;
            this.Controls.Add(healthBar);
            healthBar.BringToFront();

            // Initialize Health Value Label
            lblHealthValue = new Label();
            lblHealthValue.Size = new Size(50, 25);
            lblHealthValue.Location = new Point(healthBarBackground.Right + 10, healthBarBackground.Top);
            lblHealthValue.ForeColor = Color.Black;
            lblHealthValue.Text = player.Health.ToString();
            this.Controls.Add(lblHealthValue);
            lblHealthValue.BringToFront();
        }

        private SoundPlayer song = new SoundPlayer(Properties.Resources.boss);
        private SoundPlayer mute = new SoundPlayer(Properties.Resources.mute);
        public FrmLevel3()

        {
            InitializeComponent();
            // Check the global mute state before playing the song
            if (!GlobalMuteState.IsMuted)
            {
                song.PlayLooping();
            }
        }

        private void FrmLevel3_Load(object sender, EventArgs e) {
			const int PADDING = 7;
			const int NUM_WALLS = 13;

			player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));
			bossHersheys = new BossHershey(CreatePosition(picBossHersheys), CreateCollider(picBossHersheys, PADDING));
			hiddenCollision = new Character(CreatePosition(picHiddenCollision), CreateCollider(picHiddenCollision, PADDING));
	  

			bossHersheys.Img = picHiddenHersheys.BackgroundImage;

			bossHersheys.Color = Color.Red;


			walls = new Character[NUM_WALLS];
			for (int w = 0; w < NUM_WALLS; w++) {
				PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
				walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
			}

			Game.player = player;

			// handling timer
			timeBegin = DateTime.Now;
			totalTimePaused = new TimeSpan(0, 0, 0, 0, 0);
            InitializeHealthBar();
            // Update the health bar with the initial value
            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            float healthPercentage = (float)player.Health / player.MaxHealth;
            healthBar.Width = (int)(healthPercentage * healthBarBackground.Width);
            lblHealthValue.Text = player.Health.ToString();
        }

        private Vector2 CreatePosition(PictureBox pic) {
			return new Vector2(pic.Location.X, pic.Location.Y);
		}

		private Collider CreateCollider(PictureBox pic, int padding) {
			Rectangle rect = new Rectangle(pic.Location, new Size(pic.Size.Width - padding, pic.Size.Height - padding));
			return new Collider(rect);
		}

		private void FrmLevel3_KeyUp(object sender, KeyEventArgs e) {
			player.ResetMoveSpeed();
		}

		private void tmrUpdateInGameTime_Tick(object sender, EventArgs e) {
			TimeSpan span = DateTime.Now - timeBegin - totalTimePaused;
			string time = span.ToString(@"hh\:mm\:ss");
			lblInGameTime.Text = "Time: " + time.ToString();
		}

		private void tmrPlayerMove_Tick(object sender, EventArgs e) {
			if (isPaused)
				return; // Skip moving if the game is paused

			// move player
			player.Move();

			// check collision with walls
			if (HitAWall(player))
				player.MoveBack();

			// check collision with enemy
			if (HitAChar(player, bossHersheys) && picBossHersheys.BackgroundImage == picHiddenHersheys.BackgroundImage) {
				Fight(bossHersheys);
				picBossHersheys.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if(HitAChar(player, hiddenCollision)){
				picBossHersheys.BackgroundImage = picHiddenHersheys.BackgroundImage;
			}

			// update player's picture box
			picPlayer.Location = new Point((int)player.Position.x, (int)player.Position.y);
		}

		private bool HitAWall(Character c) {
			bool hitAWall = false;
			for (int w = 0; w < walls.Length; w++) {
				if (c.Collider.Intersects(walls[w].Collider)) {
					hitAWall = true;
					break;
				}
			}
			return hitAWall;
		}

		private bool HitAChar(Character you, Character other) {
			return you.Collider.Intersects(other.Collider);
		}

        private void Fight(BossHershey enemy)
        {
            player.ResetMoveSpeed();
            player.MoveBack();
			// boss cutscene first
			CutSceneBoss cutSceneBoss = new CutSceneBoss();
            cutSceneBoss.Size = new Size(800, 450);
            this.Hide();
            cutSceneBoss.ShowDialog();
			// boss battle next
            frmBattle = FrmBattle_Boss.GetInstance(enemy);
            frmBattle.ShowDialog(); // Make the battle form modal
            UpdateHealthBar(); // Update health bar after the battle
        }

        private Bitmap BlurImage(Bitmap image)
		{
			float blurValue = 5.0f;
			Bitmap result = new Bitmap(image.Width, image.Height);
			using (Graphics g = Graphics.FromImage(result)) {
				// Create blur effect
				System.Drawing.Imaging.ImageAttributes blur = new System.Drawing.Imaging.ImageAttributes();
				blur.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(new float[][] {
					new float[] {1, 0, 0, 0, 0},
					new float[] {0, 1, 0, 0, 0},
					new float[] {0, 0, 1, 0, 0},
					new float[] {0, 0, 0, 1, 0},
					new float[] {0, 0, 0, 0, 1}
				}));
				blur.SetGamma(blurValue);

				// Draw the original image over the effect
				g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, blur);
			}
			return result;
		}

		private void BlurBackground()
		{
			// Capture the current screen
			Bitmap screenshot = new Bitmap(this.Width, this.Height);
			this.DrawToBitmap(screenshot, new Rectangle(0, 0, this.Width, this.Height));

			// Apply blur
			Bitmap blurredScreenshot = BlurImage(screenshot);

			// Create a PictureBox to hold the blurred screenshot
			PictureBox blurOverlay = new PictureBox {
				Size = new Size(this.Width, this.Height),
				Location = new Point(-10, -30),
				Image = blurredScreenshot,
				Name = "blurOverlay"
			};

			// Add the PictureBox to your form
			this.Controls.Add(blurOverlay);
			blurOverlay.BringToFront();
		}

        private void AddPauseButtons()
        {
            // Create Exit button
            Button btnExit = new Button();
            btnExit.Text = "Exit";
            btnExit.Size = new Size(100, 50);
            btnExit.Location = new Point(this.Width / 2 - btnExit.Width - 30, this.Height / 2); // Centered
            btnExit.Font = new Font("Arial", 12, FontStyle.Bold);  // Change the font style
            btnExit.BackColor = Color.LightCoral; // Change the background color
            btnExit.ForeColor = Color.White;  // Change the text color
            btnExit.Click += (s, e) => { Application.Exit(); }; // Close the program when clicked
            btnExit.Name = "btnExit";
            this.Controls.Add(btnExit);
            btnExit.BringToFront();

            // Create Main menu button
            Button btnRestart = new Button();
            btnRestart.Text = "Main Menu";
            btnRestart.Size = new Size(100, 50);
            btnRestart.Location = new Point(this.Width / 2 + 30, this.Height / 2); // Centered
            btnRestart.Font = new Font("Arial", 12, FontStyle.Bold);  // Change the font style
            btnRestart.BackColor = Color.LightGreen; // Change the background color
            btnRestart.ForeColor = Color.White;  // Change the text color
            btnRestart.Click += (s, e) => { Application.Restart(); }; // Restart the program when clicked
            btnRestart.Name = "btnRestart";
            this.Controls.Add(btnRestart);
            btnRestart.BringToFront();

            // Create Game Paused label
            Label lblPaused = new Label();
            lblPaused.Text = "Paused";
            lblPaused.Size = new Size(300, 70);  // Increased size
            lblPaused.Location = new Point(this.Width / 2 - 150, this.Height / 2 - 150);  // Centered
            lblPaused.Font = new Font("Verdana", 28, FontStyle.Bold);  // Changed font and size
            lblPaused.ForeColor = Color.Gold;  // Changed text color
            lblPaused.BackColor = Color.Transparent;  // Made background transparent
            lblPaused.Name = "lblPaused";
            lblPaused.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblPaused);
            lblPaused.BringToFront();

            // Updated flashing Press ESC label
            Label lblPressEsc = new Label();
            lblPressEsc.Text = "Press 'ESC' key to Resume";
            lblPressEsc.Size = new Size(300, 20);  // Increased size
            lblPressEsc.Location = new Point(this.Width / 2 - 150, this.Height / 2 - 50);  // Centered
            lblPressEsc.Font = new Font("Verdana", 8, FontStyle.Italic);  // Changed font and size
            lblPressEsc.ForeColor = Color.LightGray;  // Changed text color
            lblPressEsc.BackColor = Color.Transparent;  // Made background transparent
            lblPressEsc.Name = "lblPressEsc";
            lblPressEsc.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblPressEsc);
            lblPressEsc.BringToFront();

            // Create Mute/Unmute button
            Button btnMuteUnmute = new Button();
            btnMuteUnmute.Text = GlobalMuteState.IsMuted ? "Unmute" : "Mute"; // Set the text based on the mute state
            btnMuteUnmute.Size = new Size(100, 50);
            btnMuteUnmute.Location = new Point(this.Width / 2 - 50, this.Height / 2 + 80); // Adjust the position as needed
            btnMuteUnmute.Font = new Font("Arial", 12, FontStyle.Bold);  // Change the font style
            btnMuteUnmute.BackColor = Color.Red; // Change the background color
            btnMuteUnmute.ForeColor = Color.White;  // Change the text color
            btnMuteUnmute.Name = "btnMuteUnmute";
            btnMuteUnmute.Click += (s, e) => {
                // Toggle the mute state
                GlobalMuteState.IsMuted = !GlobalMuteState.IsMuted;
                // Update the text of the button
                btnMuteUnmute.Text = GlobalMuteState.IsMuted ? "Unmute" : "Mute";

                // If muted, stop the sound, otherwise resume playing
                if (GlobalMuteState.IsMuted)
                {
                    mute.PlayLooping();
                }
                else
                {
                    song.PlayLooping();
                }
            };
            btnMuteUnmute.Name = "btnMuteUnmute";
            this.Controls.Add(btnMuteUnmute);
            btnMuteUnmute.BringToFront();

            // Timer for flashing text (same as before)
            Timer flashTimer = new Timer();
            flashTimer.Interval = 500; // half a second
            flashTimer.Tick += (s, e) => { lblPressEsc.Visible = !lblPressEsc.Visible; };
            flashTimer.Start();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			if (keyData == Keys.Escape) {
				isPaused = !isPaused; // Toggle pause state
				if (isPaused) {
					pauseBegin = DateTime.Now;
					BlurBackground();
					AddPauseButtons(); // Add Exit and Restart buttons
				}
				else {
					totalTimePaused += DateTime.Now - pauseBegin;
					Controls.RemoveByKey("blurOverlay"); // Remove the blur when unpaused
					Controls.RemoveByKey("btnExit"); // Remove the Exit button
					Controls.RemoveByKey("btnRestart"); // Remove the Restart button
					Controls.RemoveByKey("lblPaused"); // Remove the Pause label
					Controls.RemoveByKey("lblPressEsc"); // Remove the Press ESC label
                    Controls.RemoveByKey("btnMuteUnmute"); // Remove the Mute/Unmute button
                }

				return true; // Indicate that you've handled this key
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void FrmLevel3_KeyDown(object sender, KeyEventArgs e) {
			if (isPaused && e.KeyCode != Keys.Escape)
				return; // If the game is paused, ignore other keys

			switch (e.KeyCode) {
				case Keys.Left:
					player.GoLeft();
					break;
				case Keys.Right:
					player.GoRight();
					break;
				case Keys.Up:
					player.GoUp();
					break;
				case Keys.Down:
					player.GoDown();
					break;
				default:
					player.ResetMoveSpeed();
					break;
			}
		}
		private void lblInGameTime_Click(object sender, EventArgs e) {
		
		}
	}
}

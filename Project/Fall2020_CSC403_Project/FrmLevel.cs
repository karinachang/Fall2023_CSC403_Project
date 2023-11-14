using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
	public partial class FrmLevel : Form {
		private Player player;
		private bool isPaused = false;
		private Reeses enemyReeses;
		private Reeses enemyReeses1;
		private Reeses enemyReeses2;
		private Reeses enemyReeses3;
		private Reeses enemyReeses4;
		private Reeses enemyReeses5;
		private Reeses enemyReeses6;
		private Character[] walls;
        private Character door;
        private DateTime timeBegin;
		private TimeSpan totalTimePaused;
		private DateTime pauseBegin;
		private FrmBattle_Reeses frmBattle;
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

        private SoundPlayer song = new SoundPlayer(Properties.Resources.slowdramatic);
        private SoundPlayer mute = new SoundPlayer(Properties.Resources.mute);
        public FrmLevel() {
            InitializeComponent();
            // Check the global mute state before playing the song
            if (!GlobalMuteState.IsMuted)
            {
                song.PlayLooping();
            }
        }

		private void FrmLevel_Load(object sender, EventArgs e) {
			const int PADDING = 7;
			const int NUM_WALLS = 10;

			player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));
			enemyReeses = new Reeses(CreatePosition(picEnemyReeses), CreateCollider(picEnemyReeses, PADDING));
			enemyReeses1 = new Reeses(CreatePosition(picEnemyReeses1), CreateCollider(picEnemyReeses1, PADDING));
            enemyReeses2 = new Reeses(CreatePosition(picEnemyReeses2), CreateCollider(picEnemyReeses2, PADDING));
            enemyReeses3 = new Reeses(CreatePosition(picEnemyReeses3), CreateCollider(picEnemyReeses3, PADDING));
            enemyReeses4 = new Reeses(CreatePosition(picEnemyReeses4), CreateCollider(picEnemyReeses4, PADDING));
            enemyReeses5 = new Reeses(CreatePosition(picEnemyReeses5), CreateCollider(picEnemyReeses5, PADDING));
            enemyReeses6 = new Reeses(CreatePosition(picEnemyReeses6), CreateCollider(picEnemyReeses6, PADDING));
			enemyReeses.Img = picEnemyReeses.BackgroundImage;
			enemyReeses1.Img = picEnemyReeses1.BackgroundImage;
			enemyReeses2.Img = picEnemyReeses2.BackgroundImage;
			enemyReeses3.Img = picEnemyReeses3.BackgroundImage;
			enemyReeses4.Img = picEnemyReeses4.BackgroundImage;
			enemyReeses5.Img = picEnemyReeses5.BackgroundImage;
			enemyReeses6.Img = picEnemyReeses6.BackgroundImage;
			enemyReeses.Color = Color.Green;
			enemyReeses1.Color = Color.FromArgb(255, 245, 161);
			enemyReeses2.Color = Color.Red;
			enemyReeses3.Color = Color.Red;
			enemyReeses4.Color = Color.Red;
			enemyReeses5.Color = Color.Red;
			enemyReeses6.Color = Color.Red;

			walls = new Character[NUM_WALLS];
			for (int w = 0; w < NUM_WALLS; w++) {
				PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
				walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
			}

            door = new Character(CreatePosition(picDoor), CreateCollider(picDoor, PADDING));

            Game.player = player;

			// handling timer
			timeBegin = DateTime.Now;
			totalTimePaused = new TimeSpan(0, 0, 0, 0, 0);
            InitializeHealthBar();
            // Update the health bar with the initial value
            UpdateHealthBar();
        }

		private void UpdateHealthBar() {
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

		private void FrmLevel_KeyUp(object sender, KeyEventArgs e) {
			player.ResetMoveSpeed();
		}

		private void tmrUpdateInGameTime_Tick(object sender, EventArgs e) {
			TimeSpan span = DateTime.Now - timeBegin - totalTimePaused;
			string time = span.ToString(@"hh\:mm\:ss");
			lblInGameTime.Text = "Time: " + time.ToString();
        }
        private void SwitchLevel() {
            // starts the cut scene for level 2
            CutScene2 cutScene2 = new CutScene2();
            cutScene2.Size = new Size(800, 450);
            this.Hide();
            cutScene2.ShowDialog();

            // control returned here
            this.Close();
        }
        private void tmrPlayerMove_Tick(object sender, EventArgs e) {
			if (isPaused)
				return; // Skip moving if the game is paused

			// move player
			player.Move();

			// check collision with walls
			if (HitAWall(player))
				player.MoveBack();
			// check collision with door
			if (HitADoor(player)) {
                player.ResetMoveSpeed();
                player.MoveBack();
                if (enemyReeses.Health < 0)
					SwitchLevel();
			}
            // check collision with enemies
            if (HitAChar(player, enemyReeses) && enemyReeses.Health > 0) {
				Fight(enemyReeses);
				picEnemyReeses.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if (HitAChar(player, enemyReeses1) && enemyReeses1.Health > 0) {
				Fight(enemyReeses1);
				picEnemyReeses1.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if (HitAChar(player, enemyReeses2) && enemyReeses2.Health > 0) {
				Fight(enemyReeses2);
				picEnemyReeses2.BackgroundImage = picEnemyDead.BackgroundImage;
			}
            else if (HitAChar(player, enemyReeses3) && enemyReeses3.Health > 0)
            {
                Fight(enemyReeses3);
                picEnemyReeses3.BackgroundImage = picEnemyDead.BackgroundImage;
            }
            else if (HitAChar(player, enemyReeses4) && enemyReeses4.Health > 0)
            {
                Fight(enemyReeses4);
                picEnemyReeses4.BackgroundImage = picEnemyDead.BackgroundImage;
            }
			else if (HitAChar(player, enemyReeses5) && enemyReeses5.Health > 0)
            {
                Fight(enemyReeses5);
                picEnemyReeses5.BackgroundImage = picEnemyDead.BackgroundImage;
            }
			else if (HitAChar(player, enemyReeses6) && enemyReeses6.Health > 0)
            {
                Fight(enemyReeses6);
                picEnemyReeses6.BackgroundImage = picEnemyDead.BackgroundImage;
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
        private bool HitADoor(Character c)
        {
            return c.Collider.Intersects(door.Collider);
        }

        private bool HitAChar(Character you, Character other) {
			return you.Collider.Intersects(other.Collider);
		}

		private void Fight(Reeses enemy)
		{
            player.ResetMoveSpeed();
            player.MoveBack();
            frmBattle = FrmBattle_Reeses.GetInstance(enemy);
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

		private void AddPauseButtons() {
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

		private void FrmLevel_KeyDown(object sender, KeyEventArgs e) {
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
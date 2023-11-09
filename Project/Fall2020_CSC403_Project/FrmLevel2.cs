using Fall2020_CSC403_Project.code;
using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
	public partial class FrmLevel2 : Form {
		private Player player;
		private bool isPaused = false;
		private Enemy enemyKitkat;
		private Enemy enemyKitkat1;
		private Enemy enemyKitkat2;
		private Enemy enemyKitkat3;
		private Enemy enemyKitkat4;
		private Enemy enemyKitkat5;
		private Enemy enemyKitkat6;
		private Enemy enemyKitkat7;
		private Enemy enemyKitkat8;
		private Enemy enemyKitkat9;
		private Character[] walls;
		private Character door;
		private DateTime timeBegin;
		private TimeSpan totalTimePaused;
		private DateTime pauseBegin;
		private FrmBattle frmBattle;
		private PictureBox healthBarBackground;
		private PictureBox healthBar;
		private Label lblHealthValue;
		private Enemy kitKatWithKey;

		public FrmLevel2() {
			InitializeComponent();
		}

		private void FrmLevel2_Load(object sender, EventArgs e) {
			const int PADDING = 7;
			const int NUM_WALLS = 13;

			player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));
			enemyKitkat = new Enemy(CreatePosition(picEnemyKitkat), CreateCollider(picEnemyKitkat, PADDING));
			enemyKitkat1 = new Enemy(CreatePosition(picEnemyKitkat1), CreateCollider(picEnemyKitkat1, PADDING));
			enemyKitkat2 = new Enemy(CreatePosition(picEnemyKitkat2), CreateCollider(picEnemyKitkat2, PADDING));
			enemyKitkat3 = new Enemy(CreatePosition(picEnemyKitkat3), CreateCollider(picEnemyKitkat3, PADDING));
			enemyKitkat4 = new Enemy(CreatePosition(picEnemyKitkat4), CreateCollider(picEnemyKitkat4, PADDING));
			enemyKitkat5 = new Enemy(CreatePosition(picEnemyKitkat5), CreateCollider(picEnemyKitkat5, PADDING));
			enemyKitkat6 = new Enemy(CreatePosition(picEnemyKitkat6), CreateCollider(picEnemyKitkat6, PADDING));
			enemyKitkat7 = new Enemy(CreatePosition(picEnemyKitkat7), CreateCollider(picEnemyKitkat7, PADDING));
			enemyKitkat8 = new Enemy(CreatePosition(picEnemyKitkat8), CreateCollider(picEnemyKitkat8, PADDING));
			enemyKitkat9 = new Enemy(CreatePosition(picEnemyKitkat9), CreateCollider(picEnemyKitkat9, PADDING));

			enemyKitkat.Img = picEnemyKitkat.BackgroundImage;
			enemyKitkat1.Img = picEnemyKitkat1.BackgroundImage;
			enemyKitkat2.Img = picEnemyKitkat2.BackgroundImage;
			enemyKitkat3.Img = picEnemyKitkat3.BackgroundImage;
			enemyKitkat4.Img = picEnemyKitkat4.BackgroundImage;
			enemyKitkat5.Img = picEnemyKitkat5.BackgroundImage;
			enemyKitkat6.Img = picEnemyKitkat6.BackgroundImage;
			enemyKitkat7.Img = picEnemyKitkat7.BackgroundImage;
			enemyKitkat8.Img = picEnemyKitkat8.BackgroundImage;
			enemyKitkat9.Img = picEnemyKitkat9.BackgroundImage;

			enemyKitkat.Color = Color.FromArgb(255, 245, 161);
			enemyKitkat1.Color = Color.Blue;
			enemyKitkat2.Color = Color.Green;
			enemyKitkat3.Color = Color.Red;
			enemyKitkat4.Color = Color.Red;
			enemyKitkat5.Color = Color.Red;
			enemyKitkat6.Color = Color.Red;
			enemyKitkat7.Color = Color.Red;
			enemyKitkat8.Color = Color.Red;
			enemyKitkat9.Color = Color.Red;

			// give random kit kat the key to the door
			Enemy[] allEnemies = new Enemy[] {enemyKitkat, enemyKitkat1, enemyKitkat2, enemyKitkat3,
				enemyKitkat4, enemyKitkat5, enemyKitkat6, enemyKitkat7, enemyKitkat8, enemyKitkat9};
			Random random = new Random();
			kitKatWithKey = allEnemies[random.Next(0, allEnemies.Length)];

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

			// handling timer
			timeBegin = DateTime.Now;
			totalTimePaused = new TimeSpan(0, 0, 0, 0, 0);
			InitializeHealthBar();
			// Update the health bar with the initial value
			UpdateHealthBar();
		}

		private void InitializeHealthBar() {
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

		private void FrmLevel2_KeyUp(object sender, KeyEventArgs e) {
			player.ResetMoveSpeed();
		}

		private void tmrUpdateInGameTime_Tick(object sender, EventArgs e) {
			TimeSpan span = DateTime.Now - timeBegin - totalTimePaused;
			string time = span.ToString(@"hh\:mm\:ss");
			lblInGameTime.Text = "Time: " + time.ToString();
		}

		private void SwitchLevel() {
			// starts the cut scene for level 3
			CutScene3 cutScene3 = new CutScene3();
			cutScene3.Size = new Size(800, 450);
			this.Hide();
			cutScene3.ShowDialog();

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
			// check collision with door
			if (HitADoor(player)) {
				player.ResetMoveSpeed();
				player.MoveBack();
				// you must have killed the kit kat with the key to open the door
				if (kitKatWithKey.Health < 0)
					SwitchLevel();
			}
			// check collision with enemies
			if (HitAChar(player, enemyKitkat) && enemyKitkat.Health > 0) {
				Fight(enemyKitkat);
				picEnemyKitkat.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if (HitAChar(player, enemyKitkat1) && enemyKitkat1.Health > 0)
			{
				Fight(enemyKitkat1);
				picEnemyKitkat1.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if (HitAChar(player, enemyKitkat2) && enemyKitkat2.Health > 0) {
				Fight(enemyKitkat2);
				picEnemyKitkat2.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if (HitAChar(player, enemyKitkat3) && enemyKitkat3.Health > 0) {
				Fight(enemyKitkat3);
				picEnemyKitkat3.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if (HitAChar(player, enemyKitkat4) && enemyKitkat4.Health > 0) {
				Fight(enemyKitkat4);
				picEnemyKitkat4.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if (HitAChar(player, enemyKitkat5) && enemyKitkat5.Health > 0) {
				Fight(enemyKitkat5);
				picEnemyKitkat5.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if (HitAChar(player, enemyKitkat6) && enemyKitkat6.Health > 0) {
				Fight(enemyKitkat6);
				picEnemyKitkat6.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if (HitAChar(player, enemyKitkat7) && enemyKitkat7.Health > 0) {
				Fight(enemyKitkat7);
				picEnemyKitkat7.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if (HitAChar(player, enemyKitkat8) && enemyKitkat8.Health > 0) {
				Fight(enemyKitkat8);
				picEnemyKitkat8.BackgroundImage = picEnemyDead.BackgroundImage;
			}
			else if (HitAChar(player, enemyKitkat9) && enemyKitkat9.Health > 0) {
				Fight(enemyKitkat9);
				picEnemyKitkat9.BackgroundImage = picEnemyDead.BackgroundImage;
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

		private bool HitADoor(Character c) {
			return c.Collider.Intersects(door.Collider);
		}

		private bool HitAChar(Character you, Character other) {
			return you.Collider.Intersects(other.Collider);
		}

		private void Fight(Enemy enemy)
		{
			player.ResetMoveSpeed();
			player.MoveBack();
			frmBattle = FrmBattle.GetInstance(enemy);
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
				}

				return true; // Indicate that you've handled this key
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void FrmLevel2_KeyDown(object sender, KeyEventArgs e) {
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

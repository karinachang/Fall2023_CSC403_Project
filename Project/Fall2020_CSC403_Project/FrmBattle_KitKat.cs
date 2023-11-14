
using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Text;
using System.Media;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Fall2020_CSC403_Project
{
    public partial class FrmBattle_KitKat : Form
    {
        public static FrmBattle_KitKat instance = null;
        private KitKat enemy;
        private Player player;

        private FrmBattle_KitKat()
        {
            InitializeComponent();
            player = Game.player;
        }

        public void Setup()
        {
            // update for this enemy
            picEnemy.BackgroundImage = enemy.Img;
            picEnemy.Refresh();
            BackColor = enemy.Color;
            picBossBattle.Visible = false;

            // Observer pattern
            enemy.AttackEvent += PlayerDamage;
            player.AttackEvent += EnemyDamage;

            // show health
            UpdateHealthBars();
        }

        /*
		public static PrivateFontCollection addBloodyFont() {
			//Add bloody font to private font collection
			PrivateFontCollection pfc = new PrivateFontCollection();
			int fontLength = Properties.Resources.Bloody_terror_TTF.Length;
			byte[] fontdata = Properties.Resources.Bloody_terror_TTF;
			System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
			Marshal.Copy(fontdata, 0, data, fontLength);
			pfc.AddMemoryFont(data, fontLength);
			return pfc;
		} */

        public static FrmBattle_KitKat GetInstance(KitKat enemy)
        {
            if (instance == null)
            {
                instance = new FrmBattle_KitKat();
                instance.enemy = enemy;
                instance.Setup();
            }
            return instance;
        }

        private void UpdateHealthBars()
        {
            float playerHealthPer = player.Health / (float)player.MaxHealth;
            float enemyHealthPer = enemy.Health / (float)enemy.MaxHealth;

            const int MAX_HEALTHBAR_WIDTH = 226;
            lblPlayerHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * playerHealthPer);
            lblEnemyHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * enemyHealthPer);

            lblPlayerHealthFull.Text = player.Health.ToString();
            lblEnemyHealthFull.Text = enemy.Health.ToString();
        }
        private int playerHitAmount()
        {
            Random rand = new Random();
            uint hit = (uint)rand.Next(0, 3);

            if (hit == 0)
                return -3;
            else if (hit == 1)
                return -4;
            else if (hit == 2)
                return -5;
            else
                return 0;
        }
        private int enemyHitAmount()
        {
            Random rand = new Random();
            uint hit = (uint)rand.Next(0, 3);

            if (hit == 0)
                return -2;
            else if (hit == 1)
                return -3;
            else if (hit == 2)
                return -4;
            else
                return 0;
        }

        private void enemyEaten()
        {
            //Enemy eaten notification
            Label enemyEaten = new Label();
            // PrivateFontCollection pfc = addBloodyFont();
            enemyEaten.TextAlign = ContentAlignment.TopCenter;
            enemyEaten.Size = new Size(300, 100);
            // enemyEaten.Font = new Font(pfc.Families[0], 15);
            enemyEaten.Text = "You have eaten the enemy and regained health";
            enemyEaten.Location = new Point(this.Width / 2 - 150, this.Height / 2 - 150);
            enemyEaten.BackColor = Color.Black;
            enemyEaten.ForeColor = Color.Red;
            enemyEaten.Name = "eatEnemy";
            this.Controls.Add(enemyEaten);
            enemyEaten.BringToFront();
        }
        private void restoreHealth()
        {
            int currentHealth = player.Health;
            int healthToAdd = 15 - currentHealth;
            player.AlterHealth(healthToAdd);
        }

        private void AddWinOrLossControls(string message, Color backgroundColor, EventHandler btnClickHandler)
        {
            // Create a panel to darken the background
            Panel darkPanel = new Panel();
            darkPanel.Size = this.ClientSize;
            darkPanel.Location = Point.Empty;
            darkPanel.BackColor = Color.FromArgb(128, 0, 0, 0);  // Semi-transparent
            this.Controls.Add(darkPanel);
            darkPanel.BringToFront();

            // Create a label to show the message
            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.Size = new Size(300, 50);
            lblMessage.Location = new Point(this.Width / 2 - 150, this.Height / 2 - 25); // Centered
            lblMessage.Font = new Font("Arial", 12, FontStyle.Bold);
            lblMessage.ForeColor = Color.White;
            lblMessage.BackColor = backgroundColor;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblMessage);
            lblMessage.BringToFront();

            // Create a button to proceed
            Button btnProceed = new Button();
            btnProceed.Text = "Proceed";
            btnProceed.Size = new Size(100, 50);
            btnProceed.Location = new Point(this.Width / 2 - 50, this.Height / 2 + 50); // Below the label
            btnProceed.Click += btnClickHandler; // Attach click event handler
            this.Controls.Add(btnProceed);
            btnProceed.BringToFront();
        }


        private void btnProceedForWin_Click(object sender, EventArgs e)
        {
            // Code to proceed after winning
            this.Close();
        }

        private void btnProceedForLoss_Click(object sender, EventArgs e)
        {
            // Code to proceed after losing
            Application.Exit();
        }

        private void defeatEnemy()
        {
            AddWinOrLossControls("Congrats! You defeated the opponent.", Color.Green, new EventHandler(btnProceedForWin_Click));
            restoreHealth();
            enemyEaten();
            instance = null;
            // Close();
        }

        private void defeatPlayer()
        {
            AddWinOrLossControls("Mr. Peanut died. You suck!", Color.Red, new EventHandler(btnProceedForLoss_Click));
            instance = null;
            // Close();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            player.OnAttack(playerHitAmount()); //range -3, -4, -5

            if (enemy.Health > 0)
                enemy.OnAttack(enemyHitAmount()); //range -2,-3,-4

            UpdateHealthBars();

            if (player.Health <= 0)
            {
                defeatPlayer();
                instance = null;
                //Close();
            }
            else if (enemy.Health <= 0)
            {
                defeatEnemy();
                instance = null;
                //Close();
            }
        }

        private string enemy_Choice()
        {
            Random rand = new Random();
            String choice;
            uint num = (uint)rand.Next(0, 3);
            if (num == 0)
            {
                choice = "Rock";
            }
            else if (num == 1)
            {
                choice = "Paper";
            }
            else
            {
                choice = "Scissors";
            }

            return choice; //0,1,2
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            if (enemy.Health > 0)
            {
                //player chose rock
                String enemyChoice;
                String playerChoice;
                enemyChoice = enemy_Choice();
                playerChoice = "Rock";
                player_v_enemy(playerChoice, enemyChoice);
            }

            UpdateHealthBars();

            if (player.Health <= 0)
            {
                defeatPlayer();
                instance = null;
            }
            else if (enemy.Health <= 0)
            {
                defeatEnemy();
                instance = null;
            }
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            //player chose Paper
            if (enemy.Health > 0)
            {
                String enemyChoice;
                String playerChoice;
                enemyChoice = enemy_Choice();
                playerChoice = "Paper";
                player_v_enemy(playerChoice, enemyChoice);
            }

            UpdateHealthBars();

            if (player.Health <= 0)
            {
                defeatPlayer();
                instance = null;
            }
            else if (enemy.Health <= 0)
            {
                defeatEnemy();
                instance = null;
            }
        }
        private void btnScissors_Click(object sender, EventArgs e)
        {
            //player chose Scissors
            if (enemy.Health > 0)
            {
                String enemyChoice;
                String playerChoice;
                enemyChoice = enemy_Choice();
                playerChoice = "Scissors";
                player_v_enemy(playerChoice, enemyChoice);
            }

            UpdateHealthBars();

            if (player.Health <= 0)
            {
                defeatPlayer();
                instance = null;
            }
            else if (enemy.Health <= 0)
            {
                defeatEnemy();
                instance = null;
            }
        }

        private void player_v_enemy(String playerChoice, String enemyChoice)
        {
            if (playerChoice == "Rock")
            {
                if (enemyChoice == "Paper")
                {
                    enemy.OnAttack(enemyHitAmount());
                }
                if (enemyChoice == "Scissors")
                {
                    player.OnAttack(playerHitAmount());
                }
            }
            if (playerChoice == "Paper")
            {
                if (enemyChoice == "Rock")
                {
                    player.OnAttack(playerHitAmount());
                }
                if (enemyChoice == "Scissors")
                {
                    enemy.OnAttack(enemyHitAmount());
                }
            }
            if (playerChoice == "Scissors")
            {
                if (enemyChoice == "Rock")
                {
                    enemy.OnAttack(enemyHitAmount());
                }
                if (enemyChoice == "Paper")
                {
                    player.OnAttack(playerHitAmount());
                }
            }
        }

        private void EnemyDamage(int amount)
        {
            enemy.AlterHealth(amount);
        }

        private void PlayerDamage(int amount)
        {
            player.AlterHealth(amount);
        }

        private void tmrFinalBattle_Tick(object sender, EventArgs e)
        {
            picBossBattle.Visible = false;
            tmrFinalBattle.Enabled = false;
        }

        private void picEnemy_Click(object sender, EventArgs e)
        {

        }
    }
}
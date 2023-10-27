
﻿using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
  public partial class FrmBattle : Form {
    public static FrmBattle instance = null;
    private Enemy enemy;
    private Player player;

    private FrmBattle() {
      InitializeComponent();
      player = Game.player;
    }

    public void Setup() {
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

    public void SetupForBossBattle() {
      picBossBattle.Location = Point.Empty;
      picBossBattle.Size = ClientSize;
      picBossBattle.Visible = true;

      SoundPlayer simpleSound = new SoundPlayer(Resources.final_battle);
      simpleSound.Play();

      tmrFinalBattle.Enabled = true;
    }

    public static FrmBattle GetInstance(Enemy enemy) {
      if (instance == null) {
        instance = new FrmBattle();
        instance.enemy = enemy;
        instance.Setup();
      }
      return instance;
    }

    private void UpdateHealthBars() {
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

            uint num = (uint)rand.Next();
            uint hit = num % 3;

            if(hit == 0)
            {
                return -3;
            }
            if(hit == 1)
            {
                return -4;
            }
            if(hit == 2)
            {
                return -5;
            }
            else
            {
                return 0;
            }
        }
        private int enemyHitAmount()
        {
            Random rand = new Random();

            uint num = (uint)rand.Next();
            uint hit = num % 3;

            if (hit == 0)
            {
                return -2;
            }
            if (hit == 1)
            {
                return -3;
            }
            if (hit == 2)
            {
                return -4;
            }
            else
            {
                return 0;
            }
        }

        private void enemyEaten()
        {
            //Enemy eaten notification
        }
        private void restoreHealth()
        {
            int a = player.Health;
            int healthToAdd = 20 - a;
            player.AlterHealth(healthToAdd);
        }

        private void defeatEnemy()
        {
            restoreHealth();
            enemyEaten();
        }
        private void defeatPlayer()
        {
            //Iftesam
        }

        private void btnAttack_Click(object sender, EventArgs e) {
      player.OnAttack(playerHitAmount()); //range -3, -4, -5
      if (enemy.Health > 0) {
                enemy.OnAttack(enemyHitAmount()); //range -2,-3,-4
      }

      UpdateHealthBars();
      if (player.Health <= 0) {
        defeatPlayer();
        instance = null;
        Close();
      }
      else if(enemy.Health <= 0){
            defeatEnemy();
            instance = null;
            Close();
        }
    }

    private void EnemyDamage(int amount) {
      enemy.AlterHealth(amount);
    }

    private void PlayerDamage(int amount) {
      player.AlterHealth(amount);
    }
    
    private void tmrFinalBattle_Tick(object sender, EventArgs e) {
      picBossBattle.Visible = false;
      tmrFinalBattle.Enabled = false;
    }

        private void picEnemy_Click(object sender, EventArgs e)
        {

        }
    }
}


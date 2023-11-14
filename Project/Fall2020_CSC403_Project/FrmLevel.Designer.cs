namespace Fall2020_CSC403_Project {
  partial class FrmLevel {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblInGameTime = new System.Windows.Forms.Label();
            this.tmrUpdateInGameTime = new System.Windows.Forms.Timer(this.components);
            this.tmrPlayerMove = new System.Windows.Forms.Timer(this.components);
            this.picDoor = new System.Windows.Forms.PictureBox();
            this.picWall2 = new System.Windows.Forms.PictureBox();
            this.picWall8 = new System.Windows.Forms.PictureBox();
            this.picWall1 = new System.Windows.Forms.PictureBox();
            this.picWall0 = new System.Windows.Forms.PictureBox();
            this.picWall4 = new System.Windows.Forms.PictureBox();
            this.picWall5 = new System.Windows.Forms.PictureBox();
            this.picEnemyDead = new System.Windows.Forms.PictureBox();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.picEnemyReeses = new System.Windows.Forms.PictureBox();
            this.picEnemyReeses1 = new System.Windows.Forms.PictureBox();
            this.picEnemyReeses2 = new System.Windows.Forms.PictureBox();
            this.picWall7 = new System.Windows.Forms.PictureBox();
            this.picWall6 = new System.Windows.Forms.PictureBox();
            this.picWall9 = new System.Windows.Forms.PictureBox();
            this.picWall3 = new System.Windows.Forms.PictureBox();
            this.picEnemyReeses3 = new System.Windows.Forms.PictureBox();
            this.picEnemyReeses4 = new System.Windows.Forms.PictureBox();
            this.picEnemyReeses5 = new System.Windows.Forms.PictureBox();
            this.picEnemyReeses6 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyDead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInGameTime
            // 
            this.lblInGameTime.AutoSize = true;
            this.lblInGameTime.BackColor = System.Drawing.Color.Black;
            this.lblInGameTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInGameTime.ForeColor = System.Drawing.Color.White;
            this.lblInGameTime.Location = new System.Drawing.Point(16, 11);
            this.lblInGameTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInGameTime.Name = "lblInGameTime";
            this.lblInGameTime.Size = new System.Drawing.Size(60, 24);
            this.lblInGameTime.TabIndex = 2;
            this.lblInGameTime.Text = "label1";
            this.lblInGameTime.Click += new System.EventHandler(this.lblInGameTime_Click);
            // 
            // tmrUpdateInGameTime
            // 
            this.tmrUpdateInGameTime.Enabled = true;
            this.tmrUpdateInGameTime.Tick += new System.EventHandler(this.tmrUpdateInGameTime_Tick);
            // 
            // tmrPlayerMove
            // 
            this.tmrPlayerMove.Enabled = true;
            this.tmrPlayerMove.Interval = 10;
            this.tmrPlayerMove.Tick += new System.EventHandler(this.tmrPlayerMove_Tick);
            // 
            // picDoor
            // 
            this.picDoor.BackColor = System.Drawing.Color.IndianRed;
            this.picDoor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDoor.Location = new System.Drawing.Point(1362, 256);
            this.picDoor.Margin = new System.Windows.Forms.Padding(4);
            this.picDoor.Name = "picDoor";
            this.picDoor.Size = new System.Drawing.Size(80, 205);
            this.picDoor.TabIndex = 20;
            this.picDoor.TabStop = false;
            // 
            // picWall2
            // 
            this.picWall2.BackColor = System.Drawing.Color.Transparent;
            this.picWall2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWall2.Location = new System.Drawing.Point(13, 1);
            this.picWall2.Margin = new System.Windows.Forms.Padding(4);
            this.picWall2.Name = "picWall2";
            this.picWall2.Size = new System.Drawing.Size(1555, 257);
            this.picWall2.TabIndex = 16;
            this.picWall2.TabStop = false;
            // 
            // picWall8
            // 
            this.picWall8.BackColor = System.Drawing.Color.Transparent;
            this.picWall8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWall8.Location = new System.Drawing.Point(1542, 82);
            this.picWall8.Margin = new System.Windows.Forms.Padding(4);
            this.picWall8.Name = "picWall8";
            this.picWall8.Size = new System.Drawing.Size(26, 808);
            this.picWall8.TabIndex = 15;
            this.picWall8.TabStop = false;
            // 
            // picWall1
            // 
            this.picWall1.BackColor = System.Drawing.Color.Transparent;
            this.picWall1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWall1.Location = new System.Drawing.Point(1489, 256);
            this.picWall1.Margin = new System.Windows.Forms.Padding(4);
            this.picWall1.Name = "picWall1";
            this.picWall1.Size = new System.Drawing.Size(27, 366);
            this.picWall1.TabIndex = 13;
            this.picWall1.TabStop = false;
            // 
            // picWall0
            // 
            this.picWall0.BackColor = System.Drawing.Color.Transparent;
            this.picWall0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWall0.Location = new System.Drawing.Point(2, 1);
            this.picWall0.Margin = new System.Windows.Forms.Padding(4);
            this.picWall0.Name = "picWall0";
            this.picWall0.Size = new System.Drawing.Size(10, 889);
            this.picWall0.TabIndex = 12;
            this.picWall0.TabStop = false;
            // 
            // picWall4
            // 
            this.picWall4.BackColor = System.Drawing.Color.Transparent;
            this.picWall4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWall4.Location = new System.Drawing.Point(1450, 256);
            this.picWall4.Margin = new System.Windows.Forms.Padding(4);
            this.picWall4.Name = "picWall4";
            this.picWall4.Size = new System.Drawing.Size(20, 221);
            this.picWall4.TabIndex = 8;
            this.picWall4.TabStop = false;
            // 
            // picWall5
            // 
            this.picWall5.BackColor = System.Drawing.Color.Transparent;
            this.picWall5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWall5.Location = new System.Drawing.Point(2, 847);
            this.picWall5.Margin = new System.Windows.Forms.Padding(4);
            this.picWall5.Name = "picWall5";
            this.picWall5.Size = new System.Drawing.Size(1468, 43);
            this.picWall5.TabIndex = 6;
            this.picWall5.TabStop = false;
            // 
            // picEnemyDead
            // 
            this.picEnemyDead.BackColor = System.Drawing.Color.Transparent;
            this.picEnemyDead.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.enemy_dead;
            this.picEnemyDead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picEnemyDead.Location = new System.Drawing.Point(292, 106);
            this.picEnemyDead.Margin = new System.Windows.Forms.Padding(4);
            this.picEnemyDead.Name = "picEnemyDead";
            this.picEnemyDead.Size = new System.Drawing.Size(38, 66);
            this.picEnemyDead.TabIndex = 18;
            this.picEnemyDead.TabStop = false;
            // 
            // picPlayer
            // 
            this.picPlayer.BackColor = System.Drawing.Color.Transparent;
            this.picPlayer.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player;
            this.picPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayer.Location = new System.Drawing.Point(20, 563);
            this.picPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(72, 131);
            this.picPlayer.TabIndex = 0;
            this.picPlayer.TabStop = false;
            // 
            // picEnemyReeses
            // 
            this.picEnemyReeses.BackColor = System.Drawing.Color.Transparent;
            this.picEnemyReeses.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.enemy_reeses;
            this.picEnemyReeses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEnemyReeses.Location = new System.Drawing.Point(1174, 343);
            this.picEnemyReeses.Margin = new System.Windows.Forms.Padding(4);
            this.picEnemyReeses.Name = "picEnemyReeses";
            this.picEnemyReeses.Size = new System.Drawing.Size(121, 118);
            this.picEnemyReeses.TabIndex = 4;
            this.picEnemyReeses.TabStop = false;
            // 
            // picEnemyReeses1
            // 
            this.picEnemyReeses1.BackColor = System.Drawing.Color.Transparent;
            this.picEnemyReeses1.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.enemy_reeses1;
            this.picEnemyReeses1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEnemyReeses1.Location = new System.Drawing.Point(1304, 512);
            this.picEnemyReeses1.Margin = new System.Windows.Forms.Padding(4);
            this.picEnemyReeses1.Name = "picEnemyReeses1";
            this.picEnemyReeses1.Size = new System.Drawing.Size(138, 110);
            this.picEnemyReeses1.TabIndex = 5;
            this.picEnemyReeses1.TabStop = false;
            // 
            // picEnemyReeses2
            // 
            this.picEnemyReeses2.BackColor = System.Drawing.Color.Transparent;
            this.picEnemyReeses2.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.enemy_reeses2;
            this.picEnemyReeses2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEnemyReeses2.Location = new System.Drawing.Point(1056, 759);
            this.picEnemyReeses2.Margin = new System.Windows.Forms.Padding(4);
            this.picEnemyReeses2.Name = "picEnemyReeses2";
            this.picEnemyReeses2.Size = new System.Drawing.Size(96, 78);
            this.picEnemyReeses2.TabIndex = 19;
            this.picEnemyReeses2.TabStop = false;
            // 
            // picWall7
            // 
            this.picWall7.BackColor = System.Drawing.Color.Transparent;
            this.picWall7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWall7.Location = new System.Drawing.Point(1515, 256);
            this.picWall7.Margin = new System.Windows.Forms.Padding(4);
            this.picWall7.Name = "picWall7";
            this.picWall7.Size = new System.Drawing.Size(28, 454);
            this.picWall7.TabIndex = 14;
            this.picWall7.TabStop = false;
            // 
            // picWall6
            // 
            this.picWall6.BackColor = System.Drawing.Color.Transparent;
            this.picWall6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWall6.Location = new System.Drawing.Point(1469, 256);
            this.picWall6.Margin = new System.Windows.Forms.Padding(4);
            this.picWall6.Name = "picWall6";
            this.picWall6.Size = new System.Drawing.Size(21, 299);
            this.picWall6.TabIndex = 9;
            this.picWall6.TabStop = false;
            // 
            // picWall9
            // 
            this.picWall9.BackColor = System.Drawing.Color.Transparent;
            this.picWall9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWall9.Location = new System.Drawing.Point(1432, 256);
            this.picWall9.Margin = new System.Windows.Forms.Padding(4);
            this.picWall9.Name = "picWall9";
            this.picWall9.Size = new System.Drawing.Size(29, 156);
            this.picWall9.TabIndex = 11;
            this.picWall9.TabStop = false;
            // 
            // picWall3
            // 
            this.picWall3.BackColor = System.Drawing.Color.Transparent;
            this.picWall3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWall3.Location = new System.Drawing.Point(1423, 308);
            this.picWall3.Margin = new System.Windows.Forms.Padding(4);
            this.picWall3.Name = "picWall3";
            this.picWall3.Size = new System.Drawing.Size(10, 83);
            this.picWall3.TabIndex = 3;
            this.picWall3.TabStop = false;
            // 
            // picEnemyReeses3
            // 
            this.picEnemyReeses3.BackColor = System.Drawing.Color.Transparent;
            this.picEnemyReeses3.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.enemy_reeses3;
            this.picEnemyReeses3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEnemyReeses3.Location = new System.Drawing.Point(1056, 437);
            this.picEnemyReeses3.Margin = new System.Windows.Forms.Padding(4);
            this.picEnemyReeses3.Name = "picEnemyReeses3";
            this.picEnemyReeses3.Size = new System.Drawing.Size(121, 118);
            this.picEnemyReeses3.TabIndex = 21;
            this.picEnemyReeses3.TabStop = false;
            // 
            // picEnemyReeses4
            // 
            this.picEnemyReeses4.BackColor = System.Drawing.Color.Transparent;
            this.picEnemyReeses4.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.enemy_reeses4;
            this.picEnemyReeses4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEnemyReeses4.Location = new System.Drawing.Point(666, 451);
            this.picEnemyReeses4.Margin = new System.Windows.Forms.Padding(4);
            this.picEnemyReeses4.Name = "picEnemyReeses4";
            this.picEnemyReeses4.Size = new System.Drawing.Size(121, 118);
            this.picEnemyReeses4.TabIndex = 22;
            this.picEnemyReeses4.TabStop = false;
            // 
            // picEnemyReeses5
            // 
            this.picEnemyReeses5.BackColor = System.Drawing.Color.Transparent;
            this.picEnemyReeses5.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.enemy_reeses5;
            this.picEnemyReeses5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEnemyReeses5.Location = new System.Drawing.Point(415, 721);
            this.picEnemyReeses5.Margin = new System.Windows.Forms.Padding(4);
            this.picEnemyReeses5.Name = "picEnemyReeses5";
            this.picEnemyReeses5.Size = new System.Drawing.Size(121, 118);
            this.picEnemyReeses5.TabIndex = 23;
            this.picEnemyReeses5.TabStop = false;
            // 
            // picEnemyReeses6
            // 
            this.picEnemyReeses6.BackColor = System.Drawing.Color.Transparent;
            this.picEnemyReeses6.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.enemy_reeses6;
            this.picEnemyReeses6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picEnemyReeses6.Location = new System.Drawing.Point(224, 437);
            this.picEnemyReeses6.Margin = new System.Windows.Forms.Padding(4);
            this.picEnemyReeses6.Name = "picEnemyReeses6";
            this.picEnemyReeses6.Size = new System.Drawing.Size(121, 118);
            this.picEnemyReeses6.TabIndex = 24;
            this.picEnemyReeses6.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(39, 256);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1422, 605);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // FrmLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(160)))), ((int)(((byte)(82)))));
            this.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.reesesroost;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1556, 850);
            this.Controls.Add(this.picDoor);
            this.Controls.Add(this.picPlayer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picEnemyReeses6);
            this.Controls.Add(this.picEnemyReeses5);
            this.Controls.Add(this.picEnemyReeses4);
            this.Controls.Add(this.picEnemyReeses3);
            this.Controls.Add(this.picWall2);
            this.Controls.Add(this.picWall8);
            this.Controls.Add(this.picWall7);
            this.Controls.Add(this.lblInGameTime);
            this.Controls.Add(this.picWall1);
            this.Controls.Add(this.picWall0);
            this.Controls.Add(this.picWall9);
            this.Controls.Add(this.picWall6);
            this.Controls.Add(this.picWall4);
            this.Controls.Add(this.picWall5);
            this.Controls.Add(this.picWall3);
            this.Controls.Add(this.picEnemyDead);
            this.Controls.Add(this.picEnemyReeses);
            this.Controls.Add(this.picEnemyReeses1);
            this.Controls.Add(this.picEnemyReeses2);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Level 01 - Reese\'s Roost";
            this.Load += new System.EventHandler(this.FrmLevel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLevel_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmLevel_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyDead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyReeses6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox picPlayer;
    private System.Windows.Forms.Label lblInGameTime;
    private System.Windows.Forms.Timer tmrUpdateInGameTime;
    private System.Windows.Forms.Timer tmrPlayerMove;
    private System.Windows.Forms.PictureBox picEnemyReeses;
    private System.Windows.Forms.PictureBox picEnemyReeses1;
    private System.Windows.Forms.PictureBox picWall5;
    private System.Windows.Forms.PictureBox picWall4;
    private System.Windows.Forms.PictureBox picWall0;
    private System.Windows.Forms.PictureBox picWall8;
    private System.Windows.Forms.PictureBox picWall1;
    private System.Windows.Forms.PictureBox picWall2;
    private System.Windows.Forms.PictureBox picEnemyDead;
    private System.Windows.Forms.PictureBox picEnemyReeses2;
    private System.Windows.Forms.PictureBox picDoor;
        private System.Windows.Forms.PictureBox picWall7;
        private System.Windows.Forms.PictureBox picWall6;
        private System.Windows.Forms.PictureBox picWall9;
        private System.Windows.Forms.PictureBox picWall3;
        private System.Windows.Forms.PictureBox picEnemyReeses3;
        private System.Windows.Forms.PictureBox picEnemyReeses4;
        private System.Windows.Forms.PictureBox picEnemyReeses5;
        private System.Windows.Forms.PictureBox picEnemyReeses6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


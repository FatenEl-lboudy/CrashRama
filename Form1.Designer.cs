namespace CrashRama
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.explosoon = new System.Windows.Forms.PictureBox();
            this.AI1 = new System.Windows.Forms.PictureBox();
            this.AI2 = new System.Windows.Forms.PictureBox();
            this.award = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.roadTrack2 = new System.Windows.Forms.PictureBox();
            this.roadTrack1 = new System.Windows.Forms.PictureBox();
            this.butStart = new System.Windows.Forms.Button();
            this.texScore = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.explosoon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.award)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.explosoon);
            this.panel1.Controls.Add(this.AI1);
            this.panel1.Controls.Add(this.AI2);
            this.panel1.Controls.Add(this.award);
            this.panel1.Controls.Add(this.player);
            this.panel1.Controls.Add(this.roadTrack2);
            this.panel1.Controls.Add(this.roadTrack1);
            this.panel1.Location = new System.Drawing.Point(-8, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 559);
            this.panel1.TabIndex = 0;
            // 
            // explosoon
            // 
            this.explosoon.Image = global::CrashRama.Properties.Resources.explosion;
            this.explosoon.Location = new System.Drawing.Point(54, 261);
            this.explosoon.Name = "explosoon";
            this.explosoon.Size = new System.Drawing.Size(64, 64);
            this.explosoon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.explosoon.TabIndex = 6;
            this.explosoon.TabStop = false;
            // 
            // AI1
            // 
            this.AI1.Image = global::CrashRama.Properties.Resources.carGreen;
            this.AI1.Location = new System.Drawing.Point(54, 14);
            this.AI1.Name = "AI1";
            this.AI1.Size = new System.Drawing.Size(50, 101);
            this.AI1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.AI1.TabIndex = 5;
            this.AI1.TabStop = false;
            this.AI1.Tag = "carLeft";
            // 
            // AI2
            // 
            this.AI2.Image = global::CrashRama.Properties.Resources.carGrey;
            this.AI2.Location = new System.Drawing.Point(312, 15);
            this.AI2.Name = "AI2";
            this.AI2.Size = new System.Drawing.Size(50, 100);
            this.AI2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.AI2.TabIndex = 4;
            this.AI2.TabStop = false;
            this.AI2.Tag = "carRight";
            // 
            // award
            // 
            this.award.Image = global::CrashRama.Properties.Resources.bronze;
            this.award.Location = new System.Drawing.Point(79, 144);
            this.award.Name = "award";
            this.award.Size = new System.Drawing.Size(250, 100);
            this.award.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.award.TabIndex = 5;
            this.award.TabStop = false;
            // 
            // player
            // 
            this.player.Image = global::CrashRama.Properties.Resources.carYellow;
            this.player.Location = new System.Drawing.Point(203, 409);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(50, 99);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 5;
            this.player.TabStop = false;
            // 
            // roadTrack2
            // 
            this.roadTrack2.Image = global::CrashRama.Properties.Resources.roadTrack;
            this.roadTrack2.Location = new System.Drawing.Point(0, 0);
            this.roadTrack2.Name = "roadTrack2";
            this.roadTrack2.Size = new System.Drawing.Size(423, 559);
            this.roadTrack2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roadTrack2.TabIndex = 4;
            this.roadTrack2.TabStop = false;
            // 
            // roadTrack1
            // 
            this.roadTrack1.Image = global::CrashRama.Properties.Resources.roadTrack;
            this.roadTrack1.Location = new System.Drawing.Point(0, -519);
            this.roadTrack1.Name = "roadTrack1";
            this.roadTrack1.Size = new System.Drawing.Size(407, 328);
            this.roadTrack1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roadTrack1.TabIndex = 0;
            this.roadTrack1.TabStop = false;
            // 
            // butStart
            // 
            this.butStart.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.butStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butStart.Location = new System.Drawing.Point(153, 591);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(92, 40);
            this.butStart.TabIndex = 1;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = false;
            this.butStart.Click += new System.EventHandler(this.restartGame);
            // 
            // texScore
            // 
            this.texScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texScore.Location = new System.Drawing.Point(-40, 573);
            this.texScore.Name = "texScore";
            this.texScore.Size = new System.Drawing.Size(485, 23);
            this.texScore.TabIndex = 2;
            this.texScore.Text = "Score: 0";
            this.texScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.texScore.Click += new System.EventHandler(this.restartGame);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 634);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 66);
            this.label2.TabIndex = 3;
            this.label2.Text = "Press and Right to move the car .\r\n\r\nDont hit any other cars in the game and surv" +
    "ive as long as you  can\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.restartGame);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 749);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.texScore);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "CrashRama";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.explosoon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.award)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Label texScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox roadTrack1;
        private System.Windows.Forms.PictureBox roadTrack2;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox explosoon;
        private System.Windows.Forms.PictureBox AI1;
        private System.Windows.Forms.PictureBox AI2;
        private System.Windows.Forms.PictureBox award;
        private System.Windows.Forms.Timer gameTimer;
    }
}


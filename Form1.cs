using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrashRama
{
    public partial class Form1 : Form
    {

        int roadSpeed;
        int trafficSpeed;
        int playerSpeed = 12;
        int score;
        int carImage;

        Random rand = new Random();
        Random carPosition = new Random();

        bool goleft, goright;


        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {

            texScore.Text = "Score: " + score;
            score++;


            if (goleft == true && player.Left > 10)
            {
                player.Left -= playerSpeed;
            }
            if (goright == true && player.Left < 415)
            {
                player.Left += playerSpeed;
            }

            roadTrack1.Top += roadSpeed;
            roadTrack2.Top += roadSpeed;

            if (roadTrack2.Top > 519)
            {
                roadTrack2.Top = -519;
            }
            if (roadTrack1.Top > 519)
            {
                roadTrack1.Top = -519;
            }

            AI1.Top += trafficSpeed;
            AI2.Top += trafficSpeed;


            if (AI1.Top > 530)
            {
                changeAIcars(AI1);
            }

            if (AI2.Top > 530)
            {
                changeAIcars(AI2);
            }

            if (player.Bounds.IntersectsWith(AI1.Bounds) || player.Bounds.IntersectsWith(AI2.Bounds))
            {
                gameOver();
            }

            if (score > 40 && score < 500)
            {
                award.Image = Properties.Resources.bronze;
            }


            if (score > 500 && score < 2000)
            {
                award.Image = Properties.Resources.silver;
                roadSpeed = 20;
                trafficSpeed = 22;
            }

            if (score > 2000)
            {
                award.Image = Properties.Resources.gold;
                trafficSpeed = 27;
                roadSpeed = 25;
            }


        }
        //--------------------Start Hill-climbing Search 
        private void changeAIcars(PictureBox tempCar)
        {
            int bestCarImage = carImage;  // Start with current image
            double bestScore = EvaluateCarImage(bestCarImage); // Evaluate current state

            // Attempt to find a better state
            for (int testImage = 1; testImage <= 9; testImage++)
            {
                double testScore = EvaluateCarImage(testImage);
                if (testScore > bestScore)  // Check if the new state is better
                {
                    bestScore = testScore;
                    bestCarImage = testImage; // Update to the better state
                }
            }

            // Set the best found state
            carImage = bestCarImage;
            UpdateCarImage(tempCar, carImage); // Update the image
            // Adjust position based on the car tag
            tempCar.Top = carPosition.Next(100, 400) * -1;
            if ((string)tempCar.Tag == "carLeft")
            {
                tempCar.Left = carPosition.Next(5, 200);
            }
            else if ((string)tempCar.Tag == "carRight")
            {
                tempCar.Left = carPosition.Next(245, 422);
            }
        }

        private double EvaluateCarImage(int imageIndex)
        {
            // Example scoring function for car images
            // Here we simply return a score based on image index, you could use a more complex function
            return imageIndex * 100;
        }

        private void UpdateCarImage(PictureBox car, int imageIndex)
        {
            switch (imageIndex)
            {
                case 1: car.Image = Properties.Resources.ambulance; break;
                case 2: car.Image = Properties.Resources.carGreen; break;
                case 3: car.Image = Properties.Resources.carGrey; break;
                case 4: car.Image = Properties.Resources.carOrange; break;
                case 5: car.Image = Properties.Resources.carPink; break;
                case 6: car.Image = Properties.Resources.CarRed; break;
                case 7: car.Image = Properties.Resources.carYellow; break;
                case 8: car.Image = Properties.Resources.TruckBlue; break;
                case 9: car.Image = Properties.Resources.TruckWhite; break;
                default: car.Image = Properties.Resources.carGrey; break;  // Default case
            }
        }
        //=---------------------------------------End------------------------------=

        private void gameOver()
        {
            playSound();
            gameTimer.Stop();
            explosoon.Visible = true;
            player.Controls.Add(explosoon);
            explosoon.Location = new Point(-8, 5);
            explosoon.BackColor = Color.Transparent;

            award.Visible = true;
            award.BringToFront();

            butStart.Enabled = true;




        }

        private void ResetGame()
        {

            butStart.Enabled = false;
            explosoon.Visible = false;
            award.Visible = false;
            goleft = false;
            goright = false;
            score = 0;
            award.Image = Properties.Resources.bronze;

            roadSpeed = 12;
            trafficSpeed = 15;

            AI1.Top = carPosition.Next(200, 500) * -1;
            AI1.Left = carPosition.Next(5, 200);

            AI2.Top = carPosition.Next(200, 500) * -1;
            AI2.Left = carPosition.Next(245, 422);

            gameTimer.Start();



        }

        private void restartGame(object sender, EventArgs e)
        {
            ResetGame();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void playSound()
        {
            System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.hit);
            playCrash.Play();

        }
    }
}
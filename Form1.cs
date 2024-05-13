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
        // start Breadth first search
        /*private void changeAIcars(PictureBox tempCar)
   {
       Queue<int> imageQueue = new Queue<int>(); // Queue to hold the images to be explored
       HashSet<int> explored = new HashSet<int>(); // Set to track explored images
       int bestImageIndex = carImage; // Start with the current image as the best option
       double bestScore = EvaluateCarImage(bestImageIndex); // Evaluate the current image

       // Initialize BFS with the current image
       imageQueue.Enqueue(carImage);
       explored.Add(carImage);

       while (imageQueue.Count > 0)
       {
           int currentImage = imageQueue.Dequeue();
           List<int> neighbors = GetImageNeighbors(currentImage); // Get neighboring images

           foreach (int neighbor in neighbors)
           {
               if (!explored.Contains(neighbor))
               {
                   explored.Add(neighbor);
                   imageQueue.Enqueue(neighbor);

                   double score = EvaluateCarImage(neighbor);
                   if (score > bestScore) // Check if the neighbor is a better option
                   {
                       bestScore = score;
                       bestImageIndex = neighbor;
                   }
               }
           }
       }

       // Update the car image to the best found option
       carImage = bestImageIndex;
       UpdateCarImage(tempCar, carImage);
       PositionCar(tempCar);
   }

   private List<int> GetImageNeighbors(int imageIndex)
   {
       // This function defines how to find neighboring images, which could be based on some logic
       // Example: consider next and previous images as neighbors
       List<int> neighbors = new List<int>();
       if (imageIndex > 1) neighbors.Add(imageIndex - 1);
       if (imageIndex < 9) neighbors.Add(imageIndex + 1);
       return neighbors;
   }

   private double EvaluateCarImage(int imageIndex)
   {
       // Example evaluation function that scores each image
       // This could be more complex depending on the game's needs
       return imageIndex * 100; // Higher index might be considered better for simplicity
   }

   private void UpdateCarImage(PictureBox car, int imageIndex)
   {
       switch (imageIndex)
       {
           case 1: car.Image = Properties.Resources.ambulance; break;
           case 2: car.Image = Properties.Resources.carGreen; break;
           case 3: car.Image = Properties.Resources.carGrey; break;
           // Continue for other cases
           default: car.Image = Properties.Resources.carGrey; break;
       }
   }

   private void PositionCar(PictureBox car)
   {
       car.Top = carPosition.Next(100, 400) * -1;
       if ((string)car.Tag == "carLeft")
       {
           car.Left = carPosition.Next(5, 200);
       }
       else if ((string)car.Tag == "carRight")
       {
           car.Left = carPosition.Next(245, 422);
       }
   }*/
        // End Breadth first search
        // start Simulated Annealing Search
        /*private void changeAIcars(PictureBox tempCar)
{
    int k = 3; // Number of states to keep track of
    List<int> states = new List<int>(); // Current states (car images)
    List<int> newStates = new List<int>(); // New proposed states

    // Initialize with random states
    for(int i = 0; i < k; i++)
    {
        states.Add(rand.Next(1, 10));
    }

    // Evaluate each state and generate successors
    for(int i = 0; i < k; i++)
    {
        int newState = rand.Next(1, 10);
        if (EvaluateState(newState) > EvaluateState(states[i]))
        {
            newStates.Add(newState);
        }
        else
        {
            newStates.Add(states[i]);
        }
    }

    // Sort states by their evaluation and keep the best k
    newStates.Sort((a, b) => EvaluateState(b).CompareTo(EvaluateState(a)));
    newStates = newStates.Take(k).ToList();

    // Choose the best new state
    carImage = newStates.First();
    UpdateCarImage(tempCar, carImage);

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

private int EvaluateState(int imageIndex)
{
    // Example of a simple evaluation function
    return imageIndex;  // Assuming higher index, better quality
}

private void UpdateCarImage(PictureBox car, int imageIndex)
{
    switch (imageIndex)
    {
        case 1: car.Image = Properties.Resources.ambulance; break;
        case 2: car.Image = Properties.Resources.carGreen; break;
        // Add other cases as above
        default: car.Image = Properties.Resources.carGrey; break;
    }
}
        */
        // End Simulated Annealing Search
        // start Iterative Deepening Search (IDS)
        /*private void changeAIcars(PictureBox tempCar)
{
    int depth = 0;
    bool found = false;
    int targetImageIndex = 0;

    while (!found)
    {
        found = DepthLimitedSearch(tempCar, depth, ref targetImageIndex);
        depth++;
    }

    UpdateCarImage(tempCar, targetImageIndex);
    PositionCar(tempCar);
}

private bool DepthLimitedSearch(PictureBox car, int limit, ref int bestImageIndex)
{
    int bestScore = -1;
    for (int i = 1; i <= 9; i++)
    {
        int score = EvaluateCarImage(i);
        if (score > bestScore && limit > 0)  // Check if this node is worth exploring
        {
            bestScore = score;
            bestImageIndex = i;
        }
    }
    return bestScore > 0;  // Return true if a valid image was found
}

private int EvaluateCarImage(int imageIndex)
{
    // Example scoring function for car images
    return imageIndex * 100;  // Simulated scoring based on image index
}

private void UpdateCarImage(PictureBox car, int imageIndex)
{
    switch (imageIndex)
    {
        case 1: car.Image = Properties.Resources.ambulance; break;
        case 2: car.Image = Properties.Resources.carGreen; break;
        case 3: car.Image = Properties.Resources.carGrey; break;
        // More cases as needed
        default: car.Image = Properties.Resources.carGrey; break;
    }
}

private void PositionCar(PictureBox car)
{
    car.Top = carPosition.Next(100, 400) * -1;
    if ((string)car.Tag == "carLeft")
    {
        car.Left = carPosition.Next(5, 200);
    }
    else if ((string)car.Tag == "carRight")
    {
        car.Left = carPosition.Next(245, 422);
    }
}*/
        // start Depth first search
        /*private void changeAIcars(PictureBox tempCar)
{
    Stack<int> imageStack = new Stack<int>(); // Stack to hold images for DFS
    HashSet<int> visited = new HashSet<int>(); // Set to track visited images
    int bestImageIndex = carImage; // Start with the current image as the best option
    double bestScore = EvaluateCarImage(bestImageIndex); // Evaluate the current image

    // Start DFS with the current image
    imageStack.Push(carImage);
    visited.Add(carImage);

    while (imageStack.Count > 0)
    {
        int currentImage = imageStack.Pop();
        List<int> neighbors = GetImageNeighbors(currentImage); // Get neighboring images

        foreach (int neighbor in neighbors)
        {
            if (!visited.Contains(neighbor))
            {
                visited.Add(neighbor);
                imageStack.Push(neighbor);

                double score = EvaluateCarImage(neighbor);
                if (score > bestScore) // Check if the neighbor is a better option
                {
                    bestScore = score;
                    bestImageIndex = neighbor;
                }
            }
        }
    }

    // Update the car image to the best found option
    carImage = bestImageIndex;
    UpdateCarImage(tempCar, carImage);
    PositionCar(tempCar);
}

private List<int> GetImageNeighbors(int imageIndex)
{
    // This function defines how to find neighboring images
    // Example: consider next and previous images as neighbors
    List<int> neighbors = new List<int>();
    if (imageIndex > 1) neighbors.Add(imageIndex - 1);
    if (imageIndex < 9) neighbors.Add(imageIndex + 1);
    return neighbors;
}

private double EvaluateCarImage(int imageIndex)
{
    // Simple evaluation function to assign a score to each image
    return imageIndex * 100; // Example: higher index might be considered better
}

private void UpdateCarImage(PictureBox car, int imageIndex)
{
    switch (imageIndex)
    {
        case 1: car.Image = Properties.Resources.ambulance; break;
        case 2: car.Image = Properties.Resources.carGreen; break;
        case 3: car.Image = Properties.Resources.carGrey; break;
        // Complete for other images as needed
        case 9: car.Image = Properties.Resources.TruckWhite; break;
        default: car.Image = Properties.Resources.carGrey; break;
    }
}

private void PositionCar(PictureBox car)
{
    car.Top = carPosition.Next(100, 400) * -1;
    if ((string)car.Tag == "carLeft")
    {
        car.Left = carPosition.Next(5, 200);
    }
    else if ((string)car.Tag == "carRight")
    {
        car.Left = carPosition.Next(245, 422);
    }
}*/

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
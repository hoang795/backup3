using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {
        // Variables start here
        int pipeSpeed = 8; // default pipe speed defined with an integer
        int gravity = 15; // default gravity speed defined with an integer
        int score = 0; // default score integer set to 0
        // variable ends

        public Form1()
        {
            InitializeComponent(); // Ensures components are initialized
        }

        public Form1(string param1, int param2)
        {
            InitializeComponent(); // Ensures components are initialized
            MessageBox.Show($"Received parameters: {param1}, {param2}");
            // You can use param1 and param2 to modify the game settings or behavior.
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            // this is the game key is down event that's linked to the main form
            if (e.KeyCode == Keys.Space)
            {
                // if the space key is pressed then the gravity will be set to -15
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            // this is the game key is up event that's linked to the main form
            if (e.KeyCode == Keys.Space)
            {
                // if the space key is released then gravity is set back to 15
                gravity = 15;
            }
        }

        private void endGame()
        {
            // this is the game end function, this function will run when the bird touches the ground or the pipes
            scoreText.Text += " Game over!!!"; // show the game over text on the score text, += is used to add the new string of text next to the score instead of overriding it
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity; // link the flappy bird picture box to the gravity
            pipeBottom.Left -= pipeSpeed; // move the bottom pipe to the left
            pipeTop.Left -= pipeSpeed; // move the top pipe to the left
            scoreText.Text = "Score: " + score; // update the score text

            if (pipeBottom.Left < -150)
            {
                // reset bottom pipe and increase score
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                // reset top pipe and increase score
                pipeTop.Left = 950;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25)
            {
                // end the game if conditions are met
                endGame();
            }

            if (score > 5)
            {
                // increase pipe speed after score 5
                pipeSpeed = 15;
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

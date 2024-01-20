using System;
using System.Drawing;
using System.Windows.Forms;
namespace MRobinson_Assignment1
{
    public partial class Form1 : Form
    {
        private bool turn = true; // true = X turn, false = O turn
        private PictureBox[] boxes;
        private int scoreX = 0; // Score for Player X
        private int scoreO = 0; // Score for Player O

        public Form1()
        {
            InitializeComponent();
            boxes = new PictureBox[] { pictureBox1, pictureBox10, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9 };

            foreach (var box in boxes) //The foreach loop attaches a click event handler (Box_Click) to each PictureBox and sets its Tag property to an empty string. The Tag property is used to store (‘X’ or ‘O’) in each cell.
            {
                box.Click += Box_Click;
                box.Tag = "";
            }
            //These lines initialize the labels that display the scores with the current scores (0 at the start).
            lblXOutPut.Text = scoreX.ToString();
            lblOOutput.Text = scoreO.ToString();
        }

        private void Box_Click(object sender, EventArgs e)// This is the event handler for when a PictureBox is clicked. It places the current player’s mark in the clicked cell if it’s empty and then checks if there’s a winner.
        {
            var box = (PictureBox)sender;
            if (box.Tag.ToString() == "")
            {
                if (turn)
                {
                    box.Image = Properties.Resources.X;
                    box.Tag = "X";

                }
                else
                {
                    box.Image = Properties.Resources.O;
                    box.Tag = "O";
                }
                turn = !turn;
                CheckForWinner();
            }
        }

        //This array of strings represents the winning combinations for a Tic-Tac-Toe game on a 3x3 grid. Each string in the array represents a line (row, column, or diagonal) on the Tic-Tac-Toe board. Each string represents a cell on the board, with the cells numbered from 0 to 8, starting from the top left and going row by row
        private void CheckForWinner()
        {
            string[] lines = new string[]
            {
            "012", "345", "678", "036", "147", "258", "048", "246"
            };

            foreach (string line in lines) //This block of code is used to check if there is a winner in the Tic-Tac-Toe game.
            {

                //For each line, it checks if all three cells in the line have the same mark (either ‘X’ or ‘O’) and are not empty. This is done by comparing the Tag property of the PictureBoxes corresponding to the cells in the line.
                if (boxes[int.Parse(line[0].ToString())].Tag.ToString() != "" && //
                    boxes[int.Parse(line[0].ToString())].Tag.ToString() == boxes[int.Parse(line[1].ToString())].Tag.ToString() &&
                    boxes[int.Parse(line[0].ToString())].Tag.ToString() == boxes[int.Parse(line[2].ToString())].Tag.ToString())
                {
                    if (boxes[int.Parse(line[0].ToString())].Tag.ToString() == "X")
                    {
                        scoreX++;
                        lblXOutPut.Text = scoreX.ToString();
                    }
                    else
                    {
                        scoreO++;
                        lblOOutput.Text = scoreO.ToString();
                    }
                    MessageBox.Show("Player " + boxes[int.Parse(line[0].ToString())].Tag.ToString() + " Wins!");
                    ResetGame();
                    return;
                }
            }

            bool tie = true; //This block of code is used to check if the game is a tie
            foreach (var box in boxes)
            {
                if (box.Tag.ToString() == "")
                {
                    tie = false;
                    break;
                }
            }

            if (tie)
            {
                MessageBox.Show("It's a tie!");
                ResetGame();
            }
        }

        private void ResetGame()//This method resets the game and all the individual PictureBoxes 
        {
            foreach (var box in boxes)
            {
                box.Image = null;
                box.Tag = "";
            }
            turn = true;
        }

        private void btnReset_Click_1(object sender, EventArgs e)//This  btnReset_Click_1 event uses the ResetGame method to reset the entire form for a new game 
        {
            ResetGame();
            scoreX = 0;
            scoreO = 0;
            lblXOutPut.Text = scoreX.ToString();
            lblOOutput.Text = scoreO.ToString();
        }

        private void btnExit_Click_1(object sender, EventArgs e)//This btnExit_Click_1 closes the form 
        {
            this.Close();
        }

        private void btnNewGame_Click_1(object sender, EventArgs e)// This btnNewGame_Click_1 rest just the PictureBox, giving the players the option of replaying or starting a new game. It doesn't however reset the scores like the Reset Button.
        {
            ResetGame();
        }
    }
}


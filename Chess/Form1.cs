using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    

    public class Piece
    {
        public Button b;
        public int x;
        public int y;
        public string Type;
        public bool is_player;
        
        public void Player()
        {
            is_player = true;
        }


        // Sets the arrays for legal moves
        public void Move_set()
        {
            if (b.Text != string.Empty)
            {
                Type = b.Text;
            }
            if (Type == "P")
            {
                bool[,] pawn_moves = new bool[5, 5];
                pawn_moves[2, 3] = true;
                pawn_moves[2, 4] = true;
                pawn_moves[3, 3] = true;
                pawn_moves[1, 3] = true;
                
            }
            if (Type == "R")
            {
                bool[,] rook_player_moves = new bool[7, 7];
                rook_player_moves[2, 3] = true;
                rook_player_moves[1, 3] = true;
                rook_player_moves[0, 3] = true;
                rook_player_moves[4, 3] = true;
                rook_player_moves[5, 3] = true;
                rook_player_moves[6, 3] = true;
                rook_player_moves[3, 4] = true;
                rook_player_moves[3, 5] = true;
                rook_player_moves[3, 6] = true;
                rook_player_moves[3, 2] = true;
                rook_player_moves[3, 1] = true;
                rook_player_moves[3, 0] = true;
            }
            if (Type == "K")
            {
                bool[,] king_moves = new bool[5, 3];
                king_moves[1, 0] = true;
                king_moves[2, 0] = true;
                king_moves[3, 0] = true;
                king_moves[1, 1] = true;
                king_moves[3, 1] = true;
                king_moves[1, 2] = true;
                king_moves[2, 2] = true;
                king_moves[3, 2] = true;
                king_moves[4, 1] = true;
                king_moves[0, 1] = true;
            }
            if (Type == "B")
            {
                bool[,] bishop_moves = new bool[7, 7];
                bishop_moves[2, 2] = true;
                bishop_moves[1, 1] = true;
                bishop_moves[0, 0] = true;
                bishop_moves[4, 4] = true;
                bishop_moves[5, 5] = true;
                bishop_moves[6, 6] = true;
                bishop_moves[0, 6] = true;
                bishop_moves[1, 5] = true;
                bishop_moves[2, 4] = true;
                bishop_moves[4, 2] = true;
                bishop_moves[5, 1] = true;
                bishop_moves[6, 0] = true;
            }
            if (Type == "Kn")
            {
                bool[,] knight_moves = new bool[5, 5];
                knight_moves[1, 0] = true;
                knight_moves[3, 0] = true;
                knight_moves[0, 1] = true;
                knight_moves[4, 1] = true;
                knight_moves[4, 3] = true;
                knight_moves[0, 3] = true;
                knight_moves[1, 4] = true;
                knight_moves[3, 4] = true;
            }
            if (Type == "Q")
            {
                bool[,] queen_moves = new bool[7, 7];
                queen_moves[0, 0] = true;
                queen_moves[1, 1] = true;
                queen_moves[2, 2] = true;
                queen_moves[4, 4] = true;
                queen_moves[5, 5] = true;
                queen_moves[6, 6] = true;
                queen_moves[0, 3] = true;
                queen_moves[1, 3] = true;
                queen_moves[2, 3] = true;
                queen_moves[4, 3] = true;
                queen_moves[5, 3] = true;
                queen_moves[6, 3] = true;
                queen_moves[3, 0] = true;
                queen_moves[3, 1] = true;
                queen_moves[3, 2] = true;
                queen_moves[3, 4] = true;
                queen_moves[3, 5] = true;
                queen_moves[3, 6] = true;
                queen_moves[0, 6] = true;
                queen_moves[1, 5] = true;
                queen_moves[2, 4] = true;
                queen_moves[4, 2] = true;
                queen_moves[5, 1] = true;
                queen_moves[6, 0] = true;
            }
        }

        // Sets the color and texts of the buttons
        public void Color_text()
        {
            if (is_player == true)
            {
                b.ForeColor = Color.Gray;
            }
            if (is_player != true)
            {
                b.ForeColor = Color.Black;
            }
            if (Type == "P")
            {
                b.Text = "P";
            }
            if (Type == "Q")
            {
                b.Text = "Q";
            }
            if (Type == "K")
            {
                b.Text = "K";
            }
            if (Type == "R")
            {
                b.Text = "R";
            }
            if (Type == "Kn")
            {
                b.Text = "Kn";
            }
            if (Type == "B")
            {
                b.Text = "B";
            }
        }
        public void Move()
        {
            
        }
    }

    public partial class Form1 : Form
    {
        string[,] board = new string[8, 8];
        public Button[,] b_board = new Button[8, 8];

        public Form1()
        {
            InitializeComponent();
            Button_create();
        }

    
        public void Button_create()
        {
            for (int j = 0; j < 8; j++)
                for (int i = 0; i < 8; i++)
                {

                    Button b = new Button();
                    b.Size = new Size(50, 50);
                    b.Location = new Point(100 + 50 * i, 100 + 50 * j);
                    // Sets up the button names
                    b.Name = $"{i}_{j}";
                    if (b.Name == $"{i}_6")
                    {
                        b.Text = "P";
                    }
                    if (b.Name == $"{i}_1")
                        b.Text = "P";
                    if (b.Name == "0_0" || b.Name == "0_7" || b.Name == "7_7" || b.Name == "7_0")
                        b.Text = "R";
                    if (b.Name == "1_0" || b.Name == "1_7" || b.Name == "6_7" || b.Name == "6_0")
                        b.Text = "Kn";
                    if (b.Name == "2_0" || b.Name == "2_7" || b.Name == "5_7" || b.Name == "5_0")
                        b.Text = "B";
                    if (b.Name == "3_0" || b.Name == "3_7")
                        b.Text = "Q";
                    if (b.Name == "4_0" || b.Name == "4_7")
                        b.Text = "K";

                    // Colors the white piece names to gray
                    if (b.Name == $"{i}_6" || b.Name == $"{i}_7")
                        b.ForeColor = Color.Gray;

                    // Disables all other buttons exept those containing a white piece
                    if (b.Name == $"{i}_0" || b.Name == $"{i}_1")
                        b.Enabled = false;

                    // Colors the board correctly
                    if ((i % 2 == 0 && j % 2 == 0) || (i == 0 && j == 0))
                        b.BackColor = Color.White;
                    else if (i % 2 != 0 && j % 2 != 0)
                        b.BackColor = Color.White;
                    else b.BackColor = Color.SandyBrown;

                    if (b.Text == string.Empty)
                        b.Enabled = false;
                    this.Controls.Add(b);
                    b.Click += new EventHandler(NewButton_CLick);
                    b_board[i, j] = b;
                }
        }
         

        private void NewButton_CLick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            var p = new Piece();
            // Set's is_player as true
            p.Player();
            // Sets Piece.b as sender button
            p.b = b;
            // Runs Move_set
            p.Move_set();
            // Set's button forecolor
            p.Color_text();
            // Get's buttons x and y co-ordinates
            string[] buttonName = b.Name.Split('_');
            int x = Convert.ToInt32(buttonName[0]);
            int y = Convert.ToInt32(buttonName[1]);
            p.x = x;
            p.y = y;
            
        }
    }
}
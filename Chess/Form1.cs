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

        
    }       
    public class Pawn_Player : Piece
    {
        public bool is_pawn;
        public void pawn_player_moves()
            {
            bool[,] pawn_player_moves = new bool[5, 5];
            pawn_player_moves[2, 3] = true;
            pawn_player_moves[2, 4] = true;
            pawn_player_moves[3, 3] = true;
            pawn_player_moves[1, 3] = true;
            }
        

    }
    public class Rook_Player : Piece
    {

    }
    public class Bishop_Player : Piece
    {

    }
    public class Knight : Piece
    {

    }
    public class Queen : Piece
    {

    }
    public class King : Piece
    {

    }
    public partial class Form1 : Form
    {
        bool player_turn;
        string[,] board = new string[8, 8];
        Piece[,] b_board = new Piece[8, 8];
        string[,] b_clicked = new string[8, 8];
        
        public Form1()
        {
            InitializeComponent();
            button_create();
        }
        private void button_create()
        {
            for (int j = 0; j < 8; j++)
                for (int i = 0; i < 8; i++)
                {
                    b_board[i, j] = new Piece();

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
                    // This is the old way I did this, left it here to remind me to never fucking do it again.
                    /*if (b.Name == "0_0" || b.Name == "2_0" || b.Name == "4_0" || b.Name == "6_0" ||
                        b.Name == "1_1" || b.Name == "3_1" || b.Name == "5_1" || b.Name == "7_1" ||
                        b.Name == "0_2" || b.Name == "2_2" || b.Name == "4_2" || b.Name == "6_2" ||
                        b.Name == "1_3" || b.Name == "3_3" || b.Name == "5_3" || b.Name == "7_3" ||
                        b.Name == "0_4" || b.Name == "2_4" || b.Name == "4_4" || b.Name == "6_4" ||
                        b.Name == "1_5" || b.Name == "3_5" || b.Name == "5_5" || b.Name == "7_5" ||
                        b.Name == "0_6" || b.Name == "2_6" || b.Name == "4_6" || b.Name == "6_6" ||
                        b.Name == "1_7" || b.Name == "3_7" || b.Name == "5_7" || b.Name == "7_7")
                        b.BackColor = Color.SandyBrown;*/
                    // Colors the board correctly
                    if ((i % 2 == 0 && j % 2 == 0) || (i == 0 && j == 0))
                        b.BackColor = Color.White;
                    else if (i % 2 != 0 && j % 2 != 0)
                        b.BackColor = Color.White;
                    else b.BackColor = Color.SandyBrown;

                    if (b.Text == "")
                        b.Enabled = false;
                    this.Controls.Add(b);

                    b.Click += new EventHandler(newButton_CLick);
                    b_board[i, j].b = b;
                }
        }

        private void newButton_CLick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            
            foreach (Control c in this.Controls)
            {
                string[] b_name = b.Name.Split('_');
                int x = Convert.ToInt32(b_name[0]);
                int y = Convert.ToInt32(b_name[1]);
                b_clicked[x, y] = "Clicked";
                
            }
        }
    }
}
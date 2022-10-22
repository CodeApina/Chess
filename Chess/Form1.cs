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
        public int x;
        public int y;
        public string piece_text;
        public bool is_on_board = true;

    }
    public sealed class Pawn : Piece
    {
        public Pawn(int x, int y, string piece_text)
        {
            piece_text = piece_text;
            x = x;
            y = y;
        }

    }
    public sealed class Rook : Piece
    {
        public Rook(int x, int y, string piece_text)
        {
            piece_text = piece_text;
            x = x;
            y = y;
        }
    }
    public sealed class Knight : Piece
    {
        public Knight(int x, int y, string piece_text)
        {
            piece_text = piece_text;
            x = x;
            y = y;
        }
    }
    public sealed class Bishop : Piece
    {
        public Bishop(int x, int y, string piece_text)
        {
            piece_text = piece_text;
            x = x;
            y = y;
        }
    }
    public sealed class Queen : Piece
    {
        public Queen(int x, int y, string piece_text)
        {
            piece_text = piece_text;
            x = x;
            y = y;
        }
    }
    public sealed class King : Piece 
    {
        public King(int x, int y, string piece_text)
        {
            piece_text = piece_text;
            x = x;
            y = y;
        }
    }

    public partial class Form1 : Form
    {
        string[,] board = new string[8, 8];
        public Button[,] b_board = new Button[8, 8];
        public Piece m_selected_piece = null;
        public Piece[] player_pieces = new Piece[8];
        public Piece[] ai_pieces = new Piece[8];
        
        public void Initialize_Pieces()
        {
            for (int i = 0; i < 8; i++)
            {
                player_pieces[i] = new Pawn(i, 6, "P");
                ai_pieces[i] = new Pawn(i,1,"P");
            }


        }

        public Form1()
        {
            InitializeComponent();
            Initialize_Pieces();
            Button_create(m_selected_piece);
            
        }

        public void Place_Pieces(int x, int y, Piece piece)
        {;
            //for (int i = 0; i < 16; i++)
            //{
            //    x = player_pieces[i].x;
            //    y = player_pieces[i].y;
            //    if (b.Name == $"{x}_{y}")
            //    {
            //        b.Text = player_pieces[i].piece_text;
            //    }
            //    ai_pieces[(int)i].x = x;
            //    ai_pieces[(int)i].y = y;
            //    if(b.Name == $"{x}_{y}")
            //    {
            //        b.Text = ai_pieces[i].piece_text;
            //    }
            //}
        }

    
        public void Button_create(Piece piece)
        {
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                {

                    Button b = new Button();
                    b.Size = new Size(50, 50);
                    b.Location = new Point(100 + 50 * x, 100 + 50 * y);
                    // Sets up the button names
                    b.Name = $"{x}_{y}";
                    /*if (b.Name == $"{x}_6")
                    {
                        b.Text = "P";
                    }
                    if (b.Name == $"{x}_1")
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
                    foreach (Piece piece1 in player_pieces)
                    {

                    }
                    for (int i = 0; i < 8; i++)
                    {
                        x = player_pieces[(int)i].x;
                        y = player_pieces[(int)i].y;
                        if (b.Name == $"{x}_{y}")
                        {
                            b.Text = player_pieces[i].piece_text;
                        }
                        ai_pieces[(int)i].x = x;
                        ai_pieces[(int)i].y = y;
                        if (b.Name == $"{x}_{y}")
                        {
                            b.Text = ai_pieces[i].piece_text;
                        }
                    }

                    // Colors the white piece names to gray
                    if (b.Name == $"{x}_6" || b.Name == $"{x}_7")
                        b.ForeColor = Color.Gray;*/

                    b.Enabled = false;
                    // Colors the board correctly
                    if ((x % 2 == 0 && y % 2 == 0) || (x == 0 && y == 0))
                        b.BackColor = Color.White;
                    else if (x % 2 != 0 && y % 2 != 0)
                        b.BackColor = Color.White;
                    else b.BackColor = Color.SandyBrown;
                    this.Controls.Add(b);
                    b.Click += new EventHandler(NewButton_CLick);
                    b_board[x, y] = b;
                }
        }
        
        public void Process_Move(Piece selected_piece, int x, int y)
        {

        }

        private void NewButton_CLick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            // Get's buttons x and y co-ordinates
            string[] buttonName = button.Name.Split('_');
            int x = Convert.ToInt32(buttonName[0]);
            int y = Convert.ToInt32(buttonName[1]);

            //deselect selected piece
            if (m_selected_piece != null && m_selected_piece.x == x && m_selected_piece.y == y)
                m_selected_piece = null;

            //updates selection if needed
            foreach (Piece piece in player_pieces)
            {
                if (piece.x == x && piece.y == y)
                {
                    m_selected_piece = piece;
                }
            }
            foreach (Piece piece in ai_pieces)
            {
                if (piece.x == x && piece.y == y)
                {
                    m_selected_piece = piece;
                }
            }
            if (m_selected_piece != null && m_selected_piece.x != x && m_selected_piece.y != y)
            {
                Process_Move(m_selected_piece, x, y);
            }
            
        }
    }
}
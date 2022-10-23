using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        public bool has_moved = false;

    }
    public sealed class Pawn : Piece
    {
        public Pawn(int x1, int y1)
        {
            piece_text = "P";
            x = x1;
            y = y1;
        }

    }
    public sealed class Rook : Piece
    {
        public Rook(int x1, int y1)
        {
            piece_text = "R";
            x = x1;
            y = y1;
        }
    }
    public sealed class Knight : Piece
    {
        public Knight(int x1, int y1)
        {
            piece_text = "Kn";
            x = x1;
            y = y1;
        }
    }
    public sealed class Bishop : Piece
    {
        public Bishop(int x1, int y1)
        {
            piece_text = "B";
            x = x1;
            y = y1;
        }
    }
    public sealed class Queen : Piece
    {
        public Queen(int x1, int y1)
        {
            piece_text = "Q";
            x = x1;
            y = y1;
        }
    }
    public sealed class King : Piece 
    {
        public King(int x1, int y1)
        {
            piece_text = "K";
            x = x1;
            y = y1;
        }
    }
    public static class Prompt
    {
        public static int ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 200;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, AutoSize = true };
            NumericUpDown inputBox = new NumericUpDown() { Left = 50, Top = 50, Width = 400, Maximum = 4, Minimum = 1 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            return (int)inputBox.Value;
        }
    }

    public partial class Form1 : Form
    {
        public Button[,] b_board = new Button[8, 8];
        public Piece m_selected_piece = null;
        public Piece[] player_pieces = new Piece[16];
        public Piece[] ai_pieces = new Piece[16];

        public void Initialize_Pieces()
        {
            for (int i = 0; i < 8; i++)
            {
                player_pieces[i] = new Pawn( i, 6);
                ai_pieces[i] = new Pawn(i,1);
            }
            player_pieces[8] = new Rook(0, 7);
            player_pieces[9] = new Rook(7, 7);
            player_pieces[10] = new Knight(1, 7);
            player_pieces[11] = new Knight(6, 7);
            player_pieces[12] = new Bishop(2, 7);
            player_pieces[13] = new Bishop(5, 7);
            player_pieces[14] = new Queen(3, 7);
            player_pieces[15] = new King(4, 7);
            ai_pieces[8] = new Rook(0, 0);
            ai_pieces[9] = new Rook(7, 0);
            ai_pieces[10] = new Knight(1, 0);
            ai_pieces[11] = new Knight(6, 0);
            ai_pieces[12] = new Bishop(2, 0);
            ai_pieces[13] = new Bishop(5, 0);
            ai_pieces[14] = new Queen(3, 0);
            ai_pieces[15] = new King(4, 0);
            

        }

        public Form1()
        {
            InitializeComponent();
            Initialize_Pieces();
            Button_create();
            Board_fill();
            Check_Mate(check);


        }

    
        public void Button_create()
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
                    b.Click += new EventHandler(Button_CLick);
                    b_board[x, y] = b;
                }
        }
        public void Board_fill()
        {
            foreach (Button b in b_board)
            {
                b.Text = "";
                b.Enabled = false;
            }
            foreach (Piece piece in player_pieces)
            {
                if (piece != null && piece.is_on_board == true)
                {
                    Button button = b_board[piece.x, piece.y];
                    button.Enabled = true;
                    button.Text = piece.piece_text;
                    button.ForeColor = Color.Gray;
                }
            }
            foreach (Piece piece in ai_pieces)
            {
                if (piece.is_on_board == true)
                {
                    Button button = b_board[piece.x, piece.y];
                    button.Text = piece.piece_text;
                }
            }
        }
        public void Pawn_Moves(Piece selected_piece)
        {
            if (selected_piece.has_moved == false)
            {
                b_board[m_selected_piece.x, m_selected_piece.y - 1].Enabled = true;
                b_board[m_selected_piece.x, m_selected_piece.y - 2].Enabled = true;
                if (selected_piece.x - 1 >= 0 && b_board[m_selected_piece.x - 1, m_selected_piece.y - 1].Text != "" && b_board[m_selected_piece.x - 1, m_selected_piece.y - 1].ForeColor != Color.Gray)
                {
                    b_board[m_selected_piece.x - 1, m_selected_piece.y - 1].Enabled = true;
                }
                if (selected_piece.x + 1 <= 7 && b_board[m_selected_piece.x + 1, m_selected_piece.y - 1].Text != "" && b_board[m_selected_piece.x + 1, m_selected_piece.y - 1].ForeColor != Color.Gray)
                {
                    b_board[m_selected_piece.x + 1, m_selected_piece.y - 1].Enabled = true;
                }
            }
            if (selected_piece.has_moved == true && m_selected_piece.y - 1 >= 0)
            {
                if (selected_piece.x - 1 >= 0 && b_board[m_selected_piece.x - 1, m_selected_piece.y - 1].Text != "" && b_board[m_selected_piece.x - 1, m_selected_piece.y - 1].ForeColor != Color.Gray)
                {
                    b_board[m_selected_piece.x - 1, m_selected_piece.y - 1].Enabled = true;
                }
                if (selected_piece.x + 1 <= 7 && b_board[m_selected_piece.x + 1, m_selected_piece.y - 1].Text != "" && b_board[m_selected_piece.x + 1, m_selected_piece.y - 1].ForeColor != Color.Gray)
                {
                    b_board[m_selected_piece.x + 1, m_selected_piece.y - 1].Enabled = true;
                }
                if (b_board[m_selected_piece.x, m_selected_piece.y - 1].Text == "")
                    b_board[m_selected_piece.x, m_selected_piece.y - 1].Enabled = true;
            }
        }
        //TODO: Enable castling.
        public void Rook_Moves(Piece selected_piece)
        {
            bool positive_x_axis_blocked = false;
            bool negative_x_axis_blocked = false;
            bool positive_y_axis_blocked = false;
            bool negative_y_axis_blocked = false;
            for (int i = 1; i < 8; i++)
            {
                if (selected_piece is Rook)
                {
                    if (m_selected_piece.x + i <= 7)
                    {
                        if (!positive_x_axis_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y].Text == "")
                            b_board[selected_piece.x + i, selected_piece.y].Enabled = true;
                        else if (!positive_x_axis_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y].Text != "")
                        {
                            b_board[selected_piece.x + i, selected_piece.y].Enabled = true;
                            positive_x_axis_blocked = true;
                        }
                        else if (b_board[m_selected_piece.x + i, m_selected_piece.y].Text != "")
                            positive_x_axis_blocked = true;
                    }
                    if (m_selected_piece.x - i >= 0)
                    {
                        if (!negative_x_axis_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y].Text == "")
                            b_board[selected_piece.x - i, selected_piece.y].Enabled = true;
                        else if (!negative_x_axis_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y].Text != "")
                        {
                            b_board[selected_piece.x - i, selected_piece.y].Enabled = true;
                            negative_x_axis_blocked = true;
                        }
                        else if (b_board[m_selected_piece.x - i, m_selected_piece.y].Text != "")
                            negative_x_axis_blocked = true;
                    }
                    if (m_selected_piece.y + i <= 7)
                    {
                        if (!positive_y_axis_blocked && b_board[m_selected_piece.x, m_selected_piece.y + i].Text == "")
                            b_board[selected_piece.x, selected_piece.y + i].Enabled = true;
                        else if (!positive_y_axis_blocked && b_board[m_selected_piece.x, m_selected_piece.y + i].Text != "")
                        {
                            b_board[selected_piece.x, selected_piece.y + i].Enabled = true;
                            positive_y_axis_blocked = true;
                        }
                        else if (m_selected_piece.y + i <= 7 && b_board[m_selected_piece.x, m_selected_piece.y + i].Text != "")
                            positive_y_axis_blocked = true;
                    }
                    if (m_selected_piece.y - i >= 0)
                    {
                        if (!negative_y_axis_blocked && b_board[m_selected_piece.x, m_selected_piece.y - i].Text == "")
                            b_board[selected_piece.x, selected_piece.y - 1 * i].Enabled = true;
                        else if (!negative_y_axis_blocked && b_board[m_selected_piece.x, m_selected_piece.y - i].Text != "")
                        {
                            b_board[selected_piece.x, selected_piece.y - i].Enabled = true;
                            negative_y_axis_blocked = true;
                        }
                        else if (m_selected_piece.y - i >= 0 && b_board[m_selected_piece.x, m_selected_piece.y - i].Text != "")
                            negative_y_axis_blocked = true;
                    }
                }
            }

        }
        //TODO: FIX
        public void Bishop_Moves(Piece selected_piece)
        {
            bool positive_x_axis_blocked = false;
            bool negative_x_axis_blocked = false;
            bool positive_y_axis_blocked = false;
            bool negative_y_axis_blocked = false;
            for (int i = 1; i < 8; i++)
            {
                if (m_selected_piece.y + i <= 7 && m_selected_piece.x + i <= 7)
                {
                    if (!positive_x_axis_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y + i].Text == "")
                        b_board[selected_piece.x + i, selected_piece.y + i].Enabled = true;
                    else if (!positive_x_axis_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y + i].Text != "")
                    {
                        b_board[selected_piece.x + i, selected_piece.y + i].Enabled = true;
                        positive_x_axis_blocked = true;
                    }
                    else if (b_board[m_selected_piece.x + i, m_selected_piece.y + i].Text != "")
                        positive_x_axis_blocked = true;
                }
                if (m_selected_piece.y - i >= 0 && m_selected_piece.x - i >= 0)
                {
                    if (!negative_x_axis_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y - i].Text == "")
                        b_board[selected_piece.x - i, selected_piece.y - i].Enabled = true;
                    else if (!negative_x_axis_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y - i].Text != "")
                    {
                        b_board[selected_piece.x - i, selected_piece.y - i].Enabled = true;
                        negative_x_axis_blocked = true;
                    }
                    else if (b_board[m_selected_piece.x - i, m_selected_piece.y - i].Text != "")
                        negative_x_axis_blocked = true;
                }
                if (m_selected_piece.y + i <= 7 && m_selected_piece.x - i >= 0)
                {
                    if (!positive_y_axis_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y + i].Text == "")
                        b_board[selected_piece.x - i, selected_piece.y + i].Enabled = true;
                    else if (!positive_y_axis_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y + i].Text != "")
                    {
                        b_board[selected_piece.x - i, selected_piece.y + i].Enabled = true;
                        positive_y_axis_blocked = true;
                    }
                    else if (b_board[m_selected_piece.x - i, m_selected_piece.y + i].Text != "")
                        positive_y_axis_blocked = true;
                }
                if (m_selected_piece.y - i >= 0 && m_selected_piece.x + i <= 7)
                {
                    if (!negative_y_axis_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y - i].Text == "")
                        b_board[selected_piece.x + i, selected_piece.y - i].Enabled = true;
                    else if (!negative_y_axis_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y - i].Text != "")
                    {
                        b_board[selected_piece.x + i, selected_piece.y - i].Enabled = true;
                        negative_y_axis_blocked = true;
                    }
                    else if (b_board[m_selected_piece.x + i, m_selected_piece.y - i].Text != "")
                        negative_y_axis_blocked = true;
                }
            }
        }
        //TODO: FIX
        public void Queen_Moves(Piece selected_piece)
        {
            bool right_down_diagonal_blocked = false;
            bool left_up_diagonal_blocked = false;
            bool left_down_diagonal_blocked = false;
            bool right_up_diagonal_blocked = false;
            bool positive_x_axis_blocked = false;
            bool negative_x_axis_blocked = false;
            bool positive_y_axis_blocked = false;
            bool negative_y_axis_blocked = false;
            for (int i = 1; i < 8; i++)
            {
                if (m_selected_piece.y + i <= 7 && m_selected_piece.x + i <= 7)
                {
                    if (!right_down_diagonal_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y + i].Text == "")
                        b_board[selected_piece.x + i, selected_piece.y + i].Enabled = true;
                    else if (!right_down_diagonal_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y + i].Text != "")
                    {
                        b_board[selected_piece.x + i, selected_piece.y + i].Enabled = true;
                        right_down_diagonal_blocked = true;
                    }
                    else if (b_board[m_selected_piece.x + i, m_selected_piece.y + i].Text != "")
                        right_down_diagonal_blocked = true;
                }
                if (m_selected_piece.y - i >= 0 && m_selected_piece.x - i >= 0)
                {
                    if (!left_up_diagonal_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y - i].Text == "")
                        b_board[selected_piece.x - i, selected_piece.y - i].Enabled = true;
                    else if (!left_up_diagonal_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y - i].Text != "")
                    {
                        b_board[selected_piece.x - i, selected_piece.y - i].Enabled = true;
                        left_up_diagonal_blocked = true;
                    }
                    else if (b_board[m_selected_piece.x - i, m_selected_piece.y - i].Text != "")
                        left_up_diagonal_blocked = true;
                }
                if (m_selected_piece.y + i <= 7 && m_selected_piece.x - i >= 0)
                {
                    if (!left_down_diagonal_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y + i].Text == "")
                        b_board[selected_piece.x - i, selected_piece.y + i].Enabled = true;
                    else if (!left_down_diagonal_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y + i].Text != "")
                    {
                        b_board[selected_piece.x - i, selected_piece.y + i].Enabled = true;
                        left_down_diagonal_blocked = true;
                    }
                    else if (b_board[m_selected_piece.x - i, m_selected_piece.y + i].Text != "")
                        left_down_diagonal_blocked = true;
                }
                if (m_selected_piece.y - i >= 0 && m_selected_piece.x + i <= 7)
                {
                    if (!right_up_diagonal_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y - i].Text == "")
                        b_board[selected_piece.x + i, selected_piece.y - i].Enabled = true;
                    else if (!right_up_diagonal_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y - i].Text != "")
                    {
                        b_board[selected_piece.x + i, selected_piece.y - i].Enabled = true;
                        right_up_diagonal_blocked = true;
                    }
                    else if (b_board[m_selected_piece.x + i, m_selected_piece.y - i].Text != "")
                        right_up_diagonal_blocked = true;
                }
                if (m_selected_piece.x + i <= 7)
                {
                    if (!positive_x_axis_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y].Text == "")
                        b_board[selected_piece.x + i, selected_piece.y].Enabled = true;
                    else if (!positive_x_axis_blocked && b_board[m_selected_piece.x + i, m_selected_piece.y].Text != "")
                    {
                        b_board[selected_piece.x + i, selected_piece.y].Enabled = true;
                        positive_x_axis_blocked = true;
                    }
                    else if (b_board[m_selected_piece.x + i, m_selected_piece.y].Text != "")
                        positive_x_axis_blocked = true;
                }
                if (m_selected_piece.x - i >= 0)
                {
                    if (!negative_x_axis_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y].Text == "")
                        b_board[selected_piece.x - i, selected_piece.y].Enabled = true;
                    else if (!negative_x_axis_blocked && b_board[m_selected_piece.x - i, m_selected_piece.y].Text != "")
                    {
                        b_board[selected_piece.x - i, selected_piece.y].Enabled = true;
                        negative_x_axis_blocked = true;
                    }
                    else if (b_board[m_selected_piece.x - i, m_selected_piece.y].Text != "")
                        negative_x_axis_blocked = true;
                }
                if (m_selected_piece.y + i <= 7)
                {
                    if (!positive_y_axis_blocked && b_board[m_selected_piece.x, m_selected_piece.y + i].Text == "")
                        b_board[selected_piece.x, selected_piece.y + i].Enabled = true;
                    else if (!positive_y_axis_blocked && b_board[m_selected_piece.x, m_selected_piece.y + i].Text != "")
                    {
                        b_board[selected_piece.x, selected_piece.y + i].Enabled = true;
                        positive_y_axis_blocked = true;
                    }
                    else if (m_selected_piece.y + i <= 7 && b_board[m_selected_piece.x, m_selected_piece.y + i].Text != "")
                        positive_y_axis_blocked = true;
                }
                if (m_selected_piece.y - i >= 0)
                {
                    if (!negative_y_axis_blocked && b_board[m_selected_piece.x, m_selected_piece.y - i].Text == "")
                        b_board[selected_piece.x, selected_piece.y - 1 * i].Enabled = true;
                    else if (!negative_y_axis_blocked && b_board[m_selected_piece.x, m_selected_piece.y - i].Text != "")
                    {
                        b_board[selected_piece.x, selected_piece.y - i].Enabled = true;
                        negative_y_axis_blocked = true;
                    }
                    else if (m_selected_piece.y - i >= 0 && b_board[m_selected_piece.x, m_selected_piece.y - i].Text != "")
                        negative_y_axis_blocked = true;
                }
            }

        }
        //TODO: Make so king can't move to a check mate & enable castling
        public void King_Moves(Piece selected_piece)
        {
            if (selected_piece.x + 1 <= 7)
                b_board[selected_piece.x + 1, selected_piece.y].Enabled = true;
            if (selected_piece.x - 1 >= 0)
                b_board[selected_piece.x - 1, selected_piece.y].Enabled = true;
            if (selected_piece.y + 1 <= 7)
                b_board[selected_piece.x, selected_piece.y + 1].Enabled = true;
            if (selected_piece.y - 1 >= 0)
                b_board[selected_piece.x, selected_piece.y - 1].Enabled = true;
            if (selected_piece.x + 1 <= 7 && selected_piece.y + 1 <= 7)
                b_board[selected_piece.x + 1, selected_piece.y + 1].Enabled = true;
            if (selected_piece.x - 1 >= 0 && selected_piece.y - 1 >= 0)
                b_board[selected_piece.x - 1, selected_piece.y - 1].Enabled = true;
            if (selected_piece.x + 1 <= 7 && selected_piece.y - 1 >= 0)
                b_board[selected_piece.x + 1, selected_piece.y - 1].Enabled = true;
            if (selected_piece.x - 1 >= 0 && selected_piece.y + 1 <= 7)
                b_board[selected_piece.x - 1, selected_piece.y + 1].Enabled = true;
        }
        //TODO: Add Knight moves 
        public void Knight_Moves(Piece selected_piece)
        {
            if (selected_piece.y - 2 >= 0)
            {
                if (selected_piece.x - 1 >= 0)
                {
                    b_board[selected_piece.x - 1, selected_piece.y - 2].Enabled = true;
                }
                if (selected_piece.x + 1 <= 7)
                {
                    b_board[selected_piece.x + 1, selected_piece.y - 2].Enabled = true;
                }
            }
            if (selected_piece.y + 2 <= 7)
            {
                if (selected_piece.x - 1 >= 0)
                {
                    b_board[selected_piece.x - 1, selected_piece.y + 2].Enabled = true;
                }
                if (selected_piece.x + 1 <= 7)
                {
                    b_board[selected_piece.x + 1, selected_piece.y + 2].Enabled = true;
                }
            }
            if (selected_piece.x - 2 >= 0)
            {
                if (selected_piece.y - 1 >= 0)
                {
                    b_board[selected_piece.x - 2, selected_piece.y - 1].Enabled = true;
                }
                if (selected_piece.y + 1 <= 7)
                {
                    b_board[selected_piece.x - 2, selected_piece.y + 1].Enabled = true;
                }
            }
            if (selected_piece.x + 2 <= 7)
            {
                if (selected_piece.y - 1 >= 0)
                {
                    b_board[selected_piece.x + 2, selected_piece.y - 1].Enabled = true;
                }
                if (selected_piece.y + 1 <= 7)
                {
                    b_board[selected_piece.x + 2, selected_piece.y + 1].Enabled = true;
                }
            }
        }
        public bool Check_Mate(bool check)
        {
            for (int i = 0; i > player_pieces.Length; i++)
            {
                Piece piece = player_pieces[i];
                if (piece is Pawn)
                    Pawn_Moves(piece);
                if (piece is Rook)
                    Rook_Moves(piece);
                if (piece is Bishop)
                    Bishop_Moves(piece);
                if (piece is Queen)
                    Queen_Moves(piece);
                if (piece is King)
                    King_Moves(piece);
                if (piece is Knight)
                    Knight_Moves(piece);
            }
            foreach (Button b in b_board)
            {
                if (b.Enabled == true && b.Text == "K" && b.ForeColor != Color.Gray)
                    check = true;
            }
            return check;

        }
        public void Set_Tiles_For_Move(Piece selected_piece)
        {
            if (selected_piece is Pawn)
                Pawn_Moves(selected_piece);
            if (selected_piece is Rook)
                Rook_Moves(selected_piece);
            if (selected_piece is Bishop)
                Bishop_Moves(selected_piece);
            if (selected_piece is Queen)
                Queen_Moves(selected_piece);
            if (selected_piece is King)
                King_Moves(selected_piece);
            if (selected_piece is Knight)
                Knight_Moves(selected_piece);
        }
        //TODO: Add check mates
        public void Process_Move(Piece selected_piece, int x, int y)
        {
            selected_piece.x = x;
            selected_piece.y = y;
            selected_piece.has_moved = true;
            foreach (Piece piece in ai_pieces)
            {
                if (piece.x == x && piece.y == y)
                {
                    piece.is_on_board = false;
                }
            }
            if (selected_piece != null && selected_piece is Pawn && selected_piece.y == 0)
                Promote_Pawn(m_selected_piece, x, y);
            Board_fill();
            m_selected_piece = null;
            

            
        }
        public void Promote_Pawn(Piece selected_piece, int x, int y)
        {
            int promote_value = Prompt.ShowDialog("1. Queen, &2. &Bishop, &3. &Knight, &4. &Rook", "Promote");
            int player_pieces_length = player_pieces.Count(s => s != null);
            for (int i = 0; i < player_pieces.Length; i++)
            {
                if (selected_piece.x == player_pieces[i].x && selected_piece.y == player_pieces[i].y)
                {
                    switch (promote_value)
                    {
                        case 1:
                            player_pieces[i] = new Queen(selected_piece.x, selected_piece.y);
                            break;
                        case 2:
                            player_pieces[i] = new Bishop(selected_piece.x, selected_piece.y);
                            break;
                        case 3:
                            player_pieces[i] = new Knight(selected_piece.x, selected_piece.y);
                            break;
                        case 4:
                            player_pieces[i] = new Rook(selected_piece.x, selected_piece.y);
                            break;
                        default:
                            MessageBox.Show("The fuck you trying to do");
                            break;
                    }
                        
                   
                }
            }

        }
        bool check = false;
        private void Button_CLick(object sender, EventArgs e)
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
                if (piece != null && piece.x == x && piece.y == y)
                {
                    m_selected_piece = piece;
                    Board_fill();
                }
            }
            Set_Tiles_For_Move(m_selected_piece);
            if (m_selected_piece != null && m_selected_piece.x != x || m_selected_piece.y != y)
            {
                Process_Move(m_selected_piece, x, y);
            }
            check = false;
            if (Check_Mate(check))
            {
                MessageBox.Show("Check");
            }

            
        }
    }
}
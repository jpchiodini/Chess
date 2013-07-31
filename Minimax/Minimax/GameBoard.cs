using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minimax
{
    public enum PieceType { None, Pawn, Rook, Knight, Bishop, Queen, King };
    public enum PieceColor { White, Black };

    public struct Piece
    {
        public PieceType Type { get; set; }
        public PieceColor Color { get; set; }
    }

    public struct Square
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Piece currentPiece;
        //default to none
    }

    public struct boardSquare
    {
        public int X;
        public int Y;
    }

    public struct Board
    {
        public Square[,] squares { get; set; }
        //keep track of pieces
        //public int Num_wKings = 1;
        //public int Num_bKings = 1;
        //public int Num_wQueens = 1;
        //public int Num_bQueens = 1;
        //public int Num_wRooks = 2;
        //public int Num_bRooks = 2;
        //public int Num_wKnights = 2;
        //public int Num_bKnights = 2;
        //public int Num_wBishops = 2;
        //public int Num_bBishops = 2;
        //public int Num_wPawns = 8;
        //public int Num_bPawns = 8;

        public int Num_wKings;
        public int Num_bKings;
        public int Num_wQueens;
        public int Num_bQueens;
        public int Num_wRooks;
        public int Num_bRooks;
        public int Num_wKnights;
        public int Num_bKnights;
        public int Num_wBishops;
        public int Num_bBishops;
        public int Num_wPawns;
        public int Num_bPawns;
    }

    public struct Player
    {
        public PieceColor playerColor;
    }

    class GameBoard
    {
        public Board board;

        public GameBoard()
        {            
            board.squares = new Square[8, 8];
            for (int ii = 0; ii < 8; ii++)
            {
                for (int jj = 0; jj < 8; jj++)
                {
                    board.squares[jj, ii].X = ii;
                    board.squares[jj, ii].Y = jj;
                }
            }
            
        }
        /// <summary>
        /// Clones the board for determining new position
        /// </summary>
        /// <returns></returns>
        public Board Clone()
        {
            //Board board = this.board;
            return board;
        }
        //initialize the game board
        public void init()
        {
            //white team
            board.squares[0, 0].currentPiece.Color = PieceColor.White;
            board.squares[0, 1].currentPiece.Color = PieceColor.White;
            board.squares[0, 2].currentPiece.Color = PieceColor.White;
            board.squares[0, 3].currentPiece.Color = PieceColor.White;
            board.squares[0, 4].currentPiece.Color = PieceColor.White;
            board.squares[0, 5].currentPiece.Color = PieceColor.White;
            board.squares[0, 6].currentPiece.Color = PieceColor.White;
            board.squares[0, 7].currentPiece.Color = PieceColor.White;

            board.squares[0, 0].currentPiece.Type = PieceType.Rook;
            board.squares[0, 1].currentPiece.Type = PieceType.Knight;
            board.squares[0, 2].currentPiece.Type = PieceType.Bishop;
            board.squares[0, 3].currentPiece.Type = PieceType.Queen;
            board.squares[0, 4].currentPiece.Type = PieceType.King;
            board.squares[0, 5].currentPiece.Type = PieceType.Bishop;
            board.squares[0, 6].currentPiece.Type = PieceType.Knight;
            board.squares[0, 7].currentPiece.Type = PieceType.Rook;

            for (int ii = 0; ii < 8; ii++)
            {
                board.squares[1, ii].currentPiece.Color = PieceColor.White;
                board.squares[1, ii].currentPiece.Type = PieceType.Pawn;
            }

            //black team
            board.squares[7, 0].currentPiece.Color = PieceColor.Black;
            board.squares[7, 1].currentPiece.Color = PieceColor.Black;
            board.squares[7, 2].currentPiece.Color = PieceColor.Black;
            board.squares[7, 3].currentPiece.Color = PieceColor.Black;
            board.squares[7, 4].currentPiece.Color = PieceColor.Black;
            board.squares[7, 5].currentPiece.Color = PieceColor.Black;
            board.squares[7, 6].currentPiece.Color = PieceColor.Black;
            board.squares[7, 7].currentPiece.Color = PieceColor.Black;

            board.squares[7, 0].currentPiece.Type = PieceType.Rook;
            board.squares[7, 1].currentPiece.Type = PieceType.Knight;
            board.squares[7, 2].currentPiece.Type = PieceType.Bishop;
            board.squares[7, 3].currentPiece.Type = PieceType.Queen;
            board.squares[7, 4].currentPiece.Type = PieceType.King;
            board.squares[7, 5].currentPiece.Type = PieceType.Bishop;
            board.squares[7, 6].currentPiece.Type = PieceType.Knight;
            board.squares[7, 7].currentPiece.Type = PieceType.Rook;

            for (int ii = 0; ii < 8; ii++)
            {
                board.squares[6, ii].currentPiece.Color = PieceColor.White;
                board.squares[6, ii].currentPiece.Type = PieceType.Pawn;
            }

            for (int ii = 2; ii < 6; ii++)
            {
                for (int jj = 0; jj < 8; jj++)
                {
                    board.squares[ii, jj].currentPiece.Type = PieceType.None;
                }
            }

            board.Num_wKings = 1;
            board.Num_bKings = 1;
            board.Num_wQueens = 1;
            board.Num_bQueens = 1;
            board.Num_wRooks = 2;
            board.Num_bRooks = 2;
            board.Num_wKnights = 2;
            board.Num_bKnights = 2;
            board.Num_wBishops = 2;
            board.Num_bBishops = 2;
            board.Num_wPawns = 8;
            board.Num_bPawns = 8;
        }

        public void printBoard(Board board)
        {                      
            for (int ii = 7; ii >= 0; ii--)
            {
                //have to render backwards for user viewing
                for (int jj =0 ; jj < 8; jj++)                
                    Console.Write(board.squares[ii, jj].currentPiece.Type);
                
                Console.WriteLine("\n");
            }
        }

        public int getWhiteScore(Board board)
        {
            int material_score =
                200 * (board.Num_wKings - board.Num_bKings)
                + 9 * (board.Num_wQueens - board.Num_bQueens)
                + 5 * (board.Num_wRooks - board.Num_bRooks)
                + 3 * (board.Num_wKnights - board.Num_bKnights)
                + 3 * (board.Num_wBishops - board.Num_bBishops)
                + 1 * (board.Num_wPawns - board.Num_bPawns);
            //temporary
            int mobility_score = 1;
            int Eval = 1 * (material_score + mobility_score);
            return Eval;

        }

        public int getBlackScore(Board board)
        {
            int material_score =
                200 * (board.Num_wKings - board.Num_bKings)
                + 9 * (board.Num_wQueens - board.Num_bQueens)
                + 5 * (board.Num_wRooks - board.Num_bRooks)
                + 3 * (board.Num_wKnights - board.Num_bKnights)
                + 3 * (board.Num_wBishops - board.Num_bBishops)
                + 1 * (board.Num_wPawns - board.Num_bPawns);
            //temporary
            int mobility_score = 1;
            int Eval = -1 * (material_score + mobility_score);
            return Eval;

        }


        public Board getBoard()
        {
            return board;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minimax
{
    struct PieceMoveSet
    {
        //stores all possible moves
        public List<List<boardSquare>> rook;
        public List<List<boardSquare>> knight;
        public List<List<boardSquare>> bishop;
        public List<List<boardSquare>> queen;
        public List<List<boardSquare>> king;
        public List<List<boardSquare>> pawn;
    }



    //moves the specified piece and updates the board.
    class Move
    {

        public Board board;
        public Move(Board board)
        {
            this.board = board;
        }

        //makes a manual move where i want;
        public Board makeMove(int original_x, int original_y, int future_x, int future_y, Board board, Player p)
        {
            //if there is something to move there
            if (board.squares[original_x, original_y].currentPiece.Type != PieceType.None)
            {
                board.squares[future_x, future_y].currentPiece.Type = board.squares[original_x, original_y].currentPiece.Type;
                board.squares[original_x, original_y].currentPiece.Type = PieceType.None;
                return board;
            }
            else
            { return board; }
        }


        public PieceMoveSet genMoves(Board board)
        {
            PieceMoveSet pms;
            boardSquare s;
            
            pms.rook = new List<List<boardSquare>>();
            pms.queen = new List<List<boardSquare>>();
            pms.pawn = new List<List<boardSquare>>();
            pms.knight = new List<List<boardSquare>>();
            pms.king = new List<List<boardSquare>>();
            pms.bishop = new List<List<boardSquare>>();
            //#########################################################
            //for rook
            for (int ii = 0; ii < 8; ii++)
            {
                for (int jj = 0; jj < 8; jj++)
                {
                    List<boardSquare> temp = new List<boardSquare>();
                    //horizontal
                    for (int kk = jj+1; kk < 8; kk++)
                    {
                        s.X = ii;
                        s.Y = kk;                        
                        temp.Add(s);
                    }
                    for (int kk = jj - 1; kk >= 0; kk--)
                    {                        
                        s.X = ii;
                        s.Y = kk;
                        temp.Add(s);
                    }
                    //vertical
                    for (int kk = ii + 1; kk < 8; kk++)
                    {                        
                        s.X = kk;
                        s.Y = jj;
                        temp.Add(s);
                    }
                    for (int kk = ii - 1; kk >= 0; kk--)
                    {
                        s.X = kk;
                        s.Y = jj;
                        temp.Add(s);
                    }
                    pms.rook.Add(temp);                    
                }
            }
            //###########################################################
            //for bishop
            int column_count,row_count;
            for (int ii = 0; ii < 8; ii++)
            {
                for (int jj = 0; jj < 8; jj++)
                {
                    List<boardSquare> temp = new List<boardSquare>();                         
                    //diagonal up right.
                    row_count = ii;
                    if (row_count < 7)
                    {
                        for (int kk = jj + 1; kk < 8; kk++)
                        {
                            if (row_count < 7)
                            {

                                row_count++;
                                s.X = row_count;
                                s.Y = kk;
                                temp.Add(s);
                            }

                        }
                    }
                    //diagonal up left.
                    row_count = ii;
                    if (row_count < 7)
                    {
                        for (int kk = jj - 1; kk >= 0; kk--)
                        {
                            if (row_count < 7)
                            {

                                row_count++;
                                s.X = row_count;
                                s.Y = kk;
                                temp.Add(s);
                            }
                        }
                    }
                    //diagonal down left.
                    row_count = ii;
                    if (row_count > 0)
                    {
                        for (int kk = jj - 1; kk >= 0; kk--)
                        {
                            if (row_count > 0)
                            {
                                row_count--;
                                s.X = row_count;
                                s.Y = kk;
                                temp.Add(s);
                            }
                        }
                    }
                        //diagonal down right.
                        row_count = ii;
                    if(row_count > 0)
                    {
                        for (int kk = jj + 1; kk < 8; kk++)
                        {
                            if (row_count > 0)
                            {
                                row_count--;
                                s.X = row_count;
                                s.Y = kk;
                                temp.Add(s);
                            }
                        }
                    }
                    
                    pms.bishop.Add(temp);
                }
            }
            //###########################################################
            //For Queen
            for (int ii = 0; ii < 8; ii++)
            {
                for (int jj = 0; jj < 8; jj++)
                {
                    //Queen = Bishop + Rook

                    List<boardSquare> temp = new List<boardSquare>();
                    //diagonal up right.
                    row_count = ii;
                    if (row_count < 7)
                    {
                        for (int kk = jj + 1; kk < 8; kk++)
                        {
                            if (row_count < 7)
                            {

                                row_count++;
                                s.X = row_count;
                                s.Y = kk;
                                temp.Add(s);
                            }

                        }
                    }
                    //diagonal up left.
                    row_count = ii;
                    if (row_count < 7)
                    {
                        for (int kk = jj - 1; kk >= 0; kk--)
                        {
                            if (row_count < 7)
                            {

                                row_count++;
                                s.X = row_count;
                                s.Y = kk;
                                temp.Add(s);
                            }

                        }
                    }
                    //diagonal down left.
                    row_count = ii;
                    if (row_count > 0)
                    {
                        for (int kk = jj - 1; kk >= 0; kk--)
                        {
                            if (row_count > 0)
                            {
                                row_count--;
                                s.X = row_count;
                                s.Y = kk;
                                temp.Add(s);
                            }
                        }
                    }
                    //diagonal down right.
                    row_count = ii;
                    if (row_count > 0)
                    {
                        for (int kk = jj + 1; kk < 8; kk++)
                        {
                            if (row_count > 0)
                            {
                                row_count--;
                                s.X = row_count;
                                s.Y = kk;
                                temp.Add(s);
                            }
                        }
                    }

                    //rook functionality
                    //horizontal
                    for (int kk = jj + 1; kk < 8; kk++)
                    {
                        s.X = ii;
                        s.Y = kk;
                        temp.Add(s);
                    }
                    for (int kk = jj - 1; kk >= 0; kk--)
                    {
                        s.X = ii;
                        s.Y = kk;
                        temp.Add(s);
                    }
                    //vertical
                    for (int kk = ii + 1; kk < 8; kk++)
                    {
                        s.X = kk;
                        s.Y = jj;
                        temp.Add(s);
                    }
                    for (int kk = ii - 1; kk >= 0; kk--)
                    {
                        s.X = kk;
                        s.Y = jj;
                        temp.Add(s);
                    }
                    pms.queen.Add(temp);
                }
            }


            return pms;
        }








        /// <summary>
        /// Returns True if a requested move is valid
        /// </summary>
        /// <returns></returns>
        public bool canMove(int original_x, int original_y, int future_x, int future_y, Board board, Player p)
        {
            //depending on the piece in position, move accordingly
            // may need to include detection of other pieces???
            switch (board.squares[original_x, original_y].currentPiece.Type)
            {
                case PieceType.Bishop:
                    //return canMoveBishop(original_x, original_y, future_x, future_y, board);
                    break;
                case PieceType.King:
                    break;
                case PieceType.Knight:
                    return canMoveKnight(original_x, original_y, future_x, future_y, board, p);
                    break;
                case PieceType.Pawn:
                    break;
                case PieceType.Queen:
                    break;
                case PieceType.Rook:
                    return canMoveRook(original_x, original_y, future_x, future_y, board, p);
                    break;

            }
            return false;
        }



        public bool canMoveBishop(int original_x, int original_y, int future_x, int future_y, Board board)
        {
            return false; //assume moves are on the board?
        }
        public bool canMoveKnight(int original_x, int original_y, int future_x, int future_y, Board board, Player p)
        {
            //Move Piece, no take
            //move 1 on x, 2 on y
            if (
                (original_x + 1 == future_x && original_y + 2 == future_y && board.squares[future_x, future_y].currentPiece.Type == PieceType.None)
                || (original_x - 1 == future_x && original_y + 2 == future_y && board.squares[future_x, future_y].currentPiece.Type == PieceType.None)
                || (original_x + 1 == future_x && original_y - 2 == future_y && board.squares[future_x, future_y].currentPiece.Type == PieceType.None)
                || (original_x - 1 == future_x && original_y - 2 == future_y && board.squares[future_x, future_y].currentPiece.Type == PieceType.None)
                )
            { return true; }

            //move 2 on x 1 on y
            else if (
                (original_y + 1 == future_y && original_x + 2 == future_x && board.squares[future_x, future_y].currentPiece.Type == PieceType.None)
                || (original_y - 1 == future_y && original_x + 2 == future_x && board.squares[future_x, future_y].currentPiece.Type == PieceType.None)
                || (original_y + 1 == future_y && original_x - 2 == future_x && board.squares[future_x, future_y].currentPiece.Type == PieceType.None)
                || (original_y - 1 == future_y && original_x - 2 == future_x && board.squares[future_x, future_y].currentPiece.Type == PieceType.None)
                )
            { return true; }
            //Take piece
            //move 1 on x, 2 on y
            else if (
                (original_x + 1 == future_x && original_y + 2 == future_y && board.squares[future_x, future_y].currentPiece.Color != p.playerColor)
                || (original_x - 1 == future_x && original_y + 2 == future_y && board.squares[future_x, future_y].currentPiece.Color != p.playerColor)
                || (original_x + 1 == future_x && original_y - 2 == future_y && board.squares[future_x, future_y].currentPiece.Color != p.playerColor)
                || (original_x - 1 == future_x && original_y - 2 == future_y && board.squares[future_x, future_y].currentPiece.Color != p.playerColor)
                )
            { return true; }

             //move 2 on x 1 on y
            else if (
                (original_y + 1 == future_y && original_x + 2 == future_x && board.squares[future_x, future_y].currentPiece.Color != p.playerColor)
                || (original_y - 1 == future_y && original_x + 2 == future_x && board.squares[future_x, future_y].currentPiece.Color != p.playerColor)
                || (original_y + 1 == future_y && original_x - 2 == future_x && board.squares[future_x, future_y].currentPiece.Color != p.playerColor)
                || (original_y - 1 == future_y && original_x - 2 == future_x && board.squares[future_x, future_y].currentPiece.Color != p.playerColor)
                )
            { return true; }

            else
            { return false; }

        }
        public bool canMoveRook(int original_x, int original_y, int future_x, int future_y, Board board, Player p)
        {
            //Moving to empty space
            //Move vertical if x changes, y is constant, and there is no piece in the desired move space.
            if ((original_x != future_x) && (original_y == future_y) && (board.squares[future_x, future_y].currentPiece.Type == PieceType.None))
            {
                //is there any piece blocking??


                if (future_x > original_x)
                {
                    for (int ii = original_x + 1; ii < future_x; ii++)
                    {
                        if (board.squares[ii, future_y].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else if (original_x > future_x)
                {
                    for (int ii = original_x - 1; ii > future_x; ii--)
                    {
                        if (board.squares[ii, future_y].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;

                }
                else { return false; }
            }
            //Move horizontal if y changes, x is constant, and there is no piece in the desired move space.
            if ((original_y != future_y) && (original_x == future_x) && (board.squares[future_x, future_y].currentPiece.Type == PieceType.None))
            {
                if (future_y > original_y)
                {
                    for (int ii = original_y + 1; ii < future_y; ii++)
                    {
                        if (board.squares[future_x, ii].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else if (original_y > future_y)
                {
                    for (int ii = original_x - 1; ii > future_x; ii--)
                    {
                        if (board.squares[future_x, ii].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else { return false; }
            }
            //Moving to occupied space STILL MUST ACCOUNT FOR CHECK...
            if ((original_x != future_x) && (original_y == future_y) && (board.squares[future_x, future_y].currentPiece.Color != p.playerColor))
            {
                if (future_x > original_x)
                {
                    for (int ii = original_x + 1; ii < future_x; ii++)
                    {
                        if (board.squares[ii, future_y].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else if (original_x > future_x)
                {
                    for (int ii = original_x - 1; ii > future_x; ii--)
                    {
                        if (board.squares[ii, future_y].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else { return false; }
            }
            //Moving to occupied space
            if ((original_y != future_y) && (original_x == future_x) && (board.squares[future_x, future_y].currentPiece.Color != p.playerColor))
            { //is there any piece blocking??
                if (future_y > original_y)
                {
                    for (int ii = original_y + 1; ii < future_y; ii++)
                    {
                        if (board.squares[future_x, ii].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else if (original_y > future_y)
                {
                    for (int ii = original_x - 1; ii > future_x; ii--)
                    {
                        if (board.squares[future_x, ii].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else { return false; }
            }
            else
            { return false; }

        }
        public bool canMoveQueen(int original_x, int original_y, int future_x, int future_y, Board board, Player p)
        {
            //Moving to empty space
            //Move vertical if x changes, y is constant, and there is no piece in the desired move space.
            if ((original_x != future_x) && (original_y == future_y) && (board.squares[future_x, future_y].currentPiece.Type == PieceType.None))
            {
                //is there any piece blocking??


                if (future_x > original_x)
                {
                    for (int ii = original_x + 1; ii < future_x; ii++)
                    {
                        if (board.squares[ii, future_y].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else if (original_x > future_x)
                {
                    for (int ii = original_x - 1; ii > future_x; ii--)
                    {
                        if (board.squares[ii, future_y].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;

                }
                else { return false; }
            }
            //Move horizontal if y changes, x is constant, and there is no piece in the desired move space.
            if ((original_y != future_y) && (original_x == future_x) && (board.squares[future_x, future_y].currentPiece.Type == PieceType.None))
            {
                if (future_y > original_y)
                {
                    for (int ii = original_y + 1; ii < future_y; ii++)
                    {
                        if (board.squares[future_x, ii].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else if (original_y > future_y)
                {
                    for (int ii = original_x - 1; ii > future_x; ii--)
                    {
                        if (board.squares[future_x, ii].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else { return false; }
            }
            //Moving to occupied space STILL MUST ACCOUNT FOR CHECK...
            if ((original_x != future_x) && (original_y == future_y) && (board.squares[future_x, future_y].currentPiece.Color != p.playerColor))
            {
                if (future_x > original_x)
                {
                    for (int ii = original_x + 1; ii < future_x; ii++)
                    {
                        if (board.squares[ii, future_y].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else if (original_x > future_x)
                {
                    for (int ii = original_x - 1; ii > future_x; ii--)
                    {
                        if (board.squares[ii, future_y].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else { return false; }
            }
            //Moving to occupied space
            if ((original_y != future_y) && (original_x == future_x) && (board.squares[future_x, future_y].currentPiece.Color != p.playerColor))
            { //is there any piece blocking??
                if (future_y > original_y)
                {
                    for (int ii = original_y + 1; ii < future_y; ii++)
                    {
                        if (board.squares[future_x, ii].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else if (original_y > future_y)
                {
                    for (int ii = original_x - 1; ii > future_x; ii--)
                    {
                        if (board.squares[future_x, ii].currentPiece.Type != PieceType.None)
                        { return false; }
                    }
                    return true;
                }
                else { return false; }
            }

            //Start Diagonal Part




            else
            { return false; }
        }
        public bool canMoveKing(int original_x, int original_y, int future_x, int future_y)
        { return false; }
        public bool canMovePawn(int original_x, int original_y, int future_x, int future_y)
        { return false; }

    }




}

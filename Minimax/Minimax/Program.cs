using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minimax
{
    class Program
    {
        static void Main(string[] args)
        {
            //GamePosition gamePosition = new GamePosition();
            //gamePosition.initializeState();            
            GameBoard gameboard = new GameBoard();
            Board board = gameboard.getBoard();
            Player player1;
            Player player2;
            player1.playerColor = PieceColor.White;
            player2.playerColor = PieceColor.Black;
            gameboard.init();
            board = gameboard.getBoard();
            gameboard.printBoard(board);

            var make_move = new Move(board);
            make_move.genMoves(board);


            while (true)
            {
                Console.WriteLine("enter a orig x");
                string orig = Console.ReadLine();
                Console.WriteLine("enter a orig y");
                string orig1 = Console.ReadLine();

                Console.WriteLine("enter a x  to move your piece");
                string temp = Console.ReadLine();
                Console.WriteLine("enter a y  to move your piece");
                string temp1 = Console.ReadLine();
                int x, y, x1, y1;
                x = Convert.ToInt32(orig);
                y = Convert.ToInt32(orig1);
                x1 = Convert.ToInt32(temp);
                y1 = Convert.ToInt32(temp1);

                //black player
                board = make_move.makeMove(x, y, x1, y1, board, player2);
                gameboard.printBoard(board);
                string maybee = Console.ReadLine();
                if (maybee == "do it")
                {
                    Console.WriteLine("enter a orig x");
                    orig = Console.ReadLine();
                    Console.WriteLine("enter a orig y");
                    orig1 = Console.ReadLine();

                    Console.WriteLine("enter a x  to move your piece");
                    temp = Console.ReadLine();
                    Console.WriteLine("enter a y  to move your piece");
                    temp1 = Console.ReadLine();
                    x = Convert.ToInt32(orig);
                    y = Convert.ToInt32(orig1);
                    x1 = Convert.ToInt32(temp);
                    y1 = Convert.ToInt32(temp1);
                    Console.Write(make_move.canMove(x, y, x1, y1, board, player2));
                }




            }



            int s = 5;
        }
    }
}

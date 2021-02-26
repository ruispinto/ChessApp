using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp
{
    class Program
    {
        static Board myBoard = new Board(8);
        static public string chessPiece = "";

        // static public int option = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the chess tutorial");
            Console.WriteLine("Here you can learn the possible moves of a chess piece in the board when playing");
            Console.WriteLine();

            // show the empty chess board
            printBoard(myBoard, "");

            int option = 1;

            while (option > 0)
                {

                    // ask user for the coordinates where the piece will be placed
                    Cell currentCell = setCUrrentCell();
                    currentCell.CurrentlyOccupied = true;

                    Console.WriteLine();
                    Console.WriteLine("Choose from one of the pieces to play:");
                    Console.WriteLine("    1 - Knight");
                    Console.WriteLine("    2 - King");
                    Console.WriteLine("    3 - Rook");
                    Console.WriteLine("    4 - Bishop");
                    Console.WriteLine("    5 - Queen");
                    Console.WriteLine("    6 - Pawn");
                    Console.WriteLine("    0 - Exit the game");

                    // test the option entered
                    Console.Write("Number: ");

                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Only one of these numbers are allowed");
                    }
                    if (option > 0)
                        if (option < 7)
                        {
                            Console.WriteLine();

                        if (option == 1)
                            chessPiece = "Knight";
                        else if (option == 2)
                            chessPiece = "King";
                        else if (option == 3)
                            chessPiece = "Rook";
                        else if (option == 4)
                            chessPiece = "Bishop";
                        else if (option == 5)
                            chessPiece = "Queen";
                        else if (option == 6)
                            chessPiece = "Pawn";

                            // calculate all legal moves for that piece
                            myBoard.MarkNextLegalMoves(currentCell, option);

                            // print the chess board. Use an X to occupie the square. Use a + for the legal move. Use . for empty cell
                            printBoard(myBoard, chessPiece);

                        }

            }

            Console.WriteLine("Press 'Enter' to exit the game...");
            Console.ReadLine();
        }

        private static Cell setCUrrentCell()
        {
            int currentRow = 0;
            int currentColumn = 0;

            // get x and y coordinate from the user, return the cell location
            Console.WriteLine("Enter the current row number (between 0 and " + (myBoard.Size - 1) + ")");
            try
            {
                currentRow = int.Parse(Console.ReadLine());
            }
            catch
            {
                currentRow = 3;
                Console.WriteLine("Not valid. Default row will be: " + currentRow);
            }

            // just testing current row if it is greater than the board size
            if (currentRow > myBoard.Size - 1)
            {
                currentRow = myBoard.Size - 1;
                Console.WriteLine("Exceeded the board size. Default row will be: " + currentRow);
            }
            
            Console.WriteLine("Enter the current column number (between 0 and " + (myBoard.Size - 1) + ")");
            try
            {
                currentColumn = int.Parse(Console.ReadLine());
            }
            catch
            {
                currentColumn = 3;
                Console.WriteLine("Not valid. Default column will be: " + currentColumn);
            }

            // just testing current column if it is greater than the board size
            if (currentColumn > myBoard.Size - 1)
            {
                currentRow = myBoard.Size - 1;
                Console.WriteLine("Exceeded the board size. Default column will be: " + currentColumn);
            }

            // myBoard.theGrid[currentRow, currentColumn].CurrentlyOccupied = true;
            return myBoard.theGrid[currentRow, currentColumn];
        }

        private static void printBoard(Board myBoard, string v)
        {
            // print the chess board. Use an X to occupie the square. Use a + for the legal move. Use . for empty cell
            Console.Write("Chess Board");

            if (v != "")
                Console.Write(" - Possible moves for " + v);

            Console.WriteLine();
            // one row
            for (int i = 0; i < myBoard.Size; i++)
            {
                Console.Write("+");
                for(int n = 0; n < myBoard.Size; n++)
                {
                    Console.Write("---+");
                }
                Console.WriteLine();

                // one column
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Cell c = myBoard.theGrid[i, j];

                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write("| X ");
                    }
                    else if (c.LegalNexMove == true)
                    {
                        Console.Write("| + ");
                    }
                    else
                    {
                        Console.Write("|   ");
                    }
                }
                Console.Write("|");
                Console.WriteLine();

            }

            Console.Write("+");
            for (int n = 0; n < myBoard.Size; n++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
            Console.Write("=");
            for (int n = 0; n < myBoard.Size; n++)
            {
                Console.Write("====");
            }
            Console.WriteLine("=====");
        }
    }
}

using System;

namespace NQueenApp
{
    class NQueen
    {
        int queenPeice = 4; //number of queens peices
        void printNQueen(int[,] board) // Prints to Console 
        {
            for (int i = 0; i < queenPeice; i++)
            {
                for (int j = 0; j < queenPeice; j++)
                    Console.Write(" " + board[i, j]
                                      + " ");
                Console.WriteLine();
            }
        }
        bool isSafePositionForQueen(int[,] board, int row, int column) //checks that queen a can be placed on board[row, column]. column queens are already placeed in columns and checking only left side for attacking queens 
        {
            int i, j;
            for (i = 0; i < column; i++)  //check attacking queens left side 
                if (board[row, i] == 1)
                    return false;
            for (i = row, j = column; i >= 0 && //check attacking queens upper left side 
                 j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;
            for (i = row, j = column; j >= 0 &&  //check attacking queens lower left side 
                          i < queenPeice; i++, j--)
                if (board[i, j] == 1)
                    return false;
            return true;
        }
        bool solveNQueenHelper(int[,] board, int column) //returns possible arrangement of queens 
        {
            if (column >= queenPeice)  //checks to see if all queens have been placed
                return true;

            for (int i = 0; i < queenPeice; i++)  //Evaluate columns and rows by placing queen one by one 
            {
                if (isSafePositionForQueen(board, i, column))  //safety check to see if queen can be placed in this position 
                {
                    board[i, column] = 1;  //if safe then place queen on board (column, row)

                    if (solveNQueenHelper(board, column + 1) == true)  //recursion to place the rest of queens 
                        return true;

                    board[i, column] = 0; //Backtrack if no solution and remove queen from board 
                }
            }
            return false;  //return false if can't can't place queen in (column, row) 
        }
        bool solveNQueen() // Utilizes Backtracking to change previous indexes and columns to check if queen can attack another queen. (return false if queen can't be placed) (returns true if queen can be placed)
        {
            int[,] board = {{ 0, 0, 0, 0 }, //matrix representation of board and queens will be printed out in matrix on console
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 }};

            if (solveNQueenHelper(board, 0) == false) //Checks if solution exists by calling solveNQueenHelper
            {
                Console.Write("Solution does not exist"); //displays only if there is no solution 
                return false;
            }

            printNQueen(board); //prints board (1 represents occupied square by queen, and 0 represents empty square) 
            return true;
        }
        public static void Main(String[] args)
        {
            NQueen Queen = new NQueen();
            Queen.solveNQueen(); //calls codes to check NQueen
        }
    }
}
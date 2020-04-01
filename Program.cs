using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        static int CalculateLivesNeighborhood(char[,] board, int x,  int y)
        {
            int row = board.GetLength(0);
            int column = board.GetLength(1);
            int count = 0;
            for (int i = x-1; i <= x +1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < row && j < column)
                    {
                        if(i != x || j != y)
                        {
                            count += (board[i, j] == '1')? 1:0;
                        }
                    }
                }
            }
            return count;
        }
        static char GetNextGenerate(char[,] board, int x, int y)
        {
            int countLivesNeighborhood = CalculateLivesNeighborhood(board, x, y);
            char current = board[x,y];
            if (countLivesNeighborhood < 2 || countLivesNeighborhood > 3)
            {
                current = '0';
            }else if (countLivesNeighborhood == 3 && current == '0')
            {
                current = '1';
            }
            return current;
        }
        static void Show (char cell, int x, int y )
        {
            Console.SetCursorPosition(x, y);
            Console.CursorVisible = false;
            Console.Write(cell);
        }
        static void Main(string[] args)
        {
            Func<Task4, char[,]>TaskSolver = task =>
            {
                int row = task.Board.GetLength(0);
                int column = task.Board.GetLength(1);
                char[,] board = new char[row, column];

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        board[i, j] = task.Board[i,j];
                    }
                }

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        board[i, j] = GetNextGenerate(task.Board, i, j);
                    }
                }


                for (int i = row-1; i >= 0; i--)
                {
                    for (int j = column -1; j >= 0; j--)
                    {
                        Show(board[i, j], i, j);
                    }
                }

                return board;
            };
            Task4.CheckSolver(TaskSolver);
            
        }
    }
}

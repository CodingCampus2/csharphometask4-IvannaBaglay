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
            for (int i = x-1; i < x +1; i++)
            {
                for (int j = y - 1; j < y + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < row && j < column)
                    {
                        count += board[i, j];
                    }
                }
            }
            return 0;
        }
        static char GetNextGenerate(char[,] board, int x, int y)
        {
            int countLivesNeighborhood = CalculateLivesNeighborhood(board, x, y);
            char current = board[x,y];
            if (countLivesNeighborhood < 2)
            {
                current = '0';
            }else if (countLivesNeighborhood == 3 && current == '0')
            {
                current = '0';
            }else if (countLivesNeighborhood > 4)
            {
                current = '0';
            }
            return current;
        }
        static void Main(string[] args)
        {
            Func<Task4, char[,]>TaskSolver = task =>
            {
                char[,] board = task.Board;
                int row = board.GetLength(0);
                int column = board.GetLength(1);
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        board[i, j] = GetNextGenerate(task.Board, i, j);
                    }
                }
                return board;
            };

            Task4.CheckSolver(TaskSolver);
        }
    }
}

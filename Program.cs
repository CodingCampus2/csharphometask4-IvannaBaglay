using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        const char LIVE = '+';
        const char DEAD = '-';
        static void GenerateRandomCharArray(char[,] array, int row, int column)
        {
            string chars = "0101010101010101";
            Random rand = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    int num = rand.Next(chars.Length);
                    array[i, j] = chars[num];
                }
            }
        }
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

        static void CopyArray(char[,] arrayFrom, char[,] arrayTo, int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    arrayTo[i, j] = arrayFrom[i, j];
                }
            }
        }
        static void Show(char[,] array, int row, int column)
        {
            for (int i = row - 1; i >= 0; i--)
            {
                for (int j = column - 1; j >= 0; j--)
                {
                    Show(array[i, j], i, j);
                }
            }
        }
        static void GameOfLife()
        {
            int row = 100;
            int column = 50;
            char[,] newGeneration = new char[row, column];
            GenerateRandomCharArray(newGeneration, row, column);

            while (true)
            {
                char[,] currentGeneration = new char[row, column];
                CopyArray(newGeneration, currentGeneration, row, column);
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        newGeneration[i, j] = GetNextGenerate(currentGeneration, i, j);
                    }
                }
                Show(newGeneration, row, column);
            }
        }

        static void Show (char cell, int x, int y )
        {
            char symbol = (cell == '1') ? LIVE : DEAD;
            Console.SetCursorPosition(x, y);
            Console.CursorVisible = false;
            Console.Write(symbol);
        }
        static void Main(string[] args)
        {
            Func<Task4, char[,]>TaskSolver = task =>
            {
                int row = task.Board.GetLength(0);
                int column = task.Board.GetLength(1);
                char[,] board = new char[row, column];
                char[,] old = new char[row, column];

                CopyArray(task.Board, board, row, column);

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        board[i, j] = GetNextGenerate(task.Board, i, j);
                    }
                }

                // GameOfLife(); 
                return board;
            };
            Task4.CheckSolver(TaskSolver);
            
        }
    }
}

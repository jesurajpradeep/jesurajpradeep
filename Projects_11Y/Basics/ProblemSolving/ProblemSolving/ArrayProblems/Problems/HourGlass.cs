using ArrayProblems.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayProblems.Problems
{
    class HourGlass : IArrayProblem
    {
        //int[,] array = new int[6, 6];
        int[,] array = { {1, 2, 3, 0, 0 },
                         {0, 0, 0, 0, 0 },
                         {2, 1, 4, 0, 0 },
                         { 0, 0, 0, 0, 0},
                         {1, 1, 0, 1, 0 }};

        public HourGlass()
        {

        }

        public void Solve()
        {
            int rowLength = array.GetLength(0);
            int colLength = array.GetLength(1);
            int max_sum = int.MinValue;

            for(int row = 0; row < rowLength - 2; row++)
            {
                for(int col = 0; col < colLength - 2; col++)
                {
                    int sum = array[row, col] + array[row, col + 1] + array[row, col + 2] +
                                                array[row + 1, col + 1] +
                              array[row + 2, col] + array[row + 2, col + 1] + array[row + 2, col + 2];
                    max_sum = Math.Max(max_sum, sum);
                }
            }

            Console.WriteLine($"max_sum: {max_sum}");
        }
    }
}

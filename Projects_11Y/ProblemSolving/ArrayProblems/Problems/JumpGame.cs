using ArrayProblems.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayProblems.Problems
{
    class JumpGame : IArrayProblem
    {
        int[] nums = { 2, 3, 1, 1, 4 };

        public JumpGame()
        {

        }

        private bool CanJumpIndex(int[] nums)
        {
            bool __result = false;
            int len = nums.Length - 1;
            int iter = 0;
            for (int currentArrayIndex = 0; currentArrayIndex <= len && iter <= len; iter++)
            {
                int indexValue = nums[currentArrayIndex];
                if (indexValue == 0)
                {
                    __result = false;
                    break;
                }
                currentArrayIndex = indexValue + currentArrayIndex;
                if (currentArrayIndex >= len)
                {
                    __result = true;
                    break;
                }

                if (currentArrayIndex < len)
                    continue;
            }
            Console.WriteLine($"Jump result: {__result} iter: {iter}");
            return __result;
        }

        private bool CanJump2(int[] nums)
        {
            int j = nums.Length - 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] + i >= j)
                    j = i;
            }

            bool __result = j == 0;
            Console.WriteLine($"Jump result: {__result}");

            return j == 0;
        }

        public void Solve()
        {
            int[] nums = { 2, 3, 1, 1, 4 };
            nums = new int[] { 3, 2, 1, 0, 4 };
            CanJumpIndex(nums);
        }
    }
}

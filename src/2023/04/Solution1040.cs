using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{

    ///<summary>
    /// no: 1040
    /// title: 移动石子直到连续 II
    /// problems: https://leetcode.cn/problems/moving-stones-until-consecutive-ii/
    /// date: 20230407
    /// </summary>
    public static class Solution1040
    {
        // 参考解答
        public static int[] NumMovesStonesII(int[] stones) {
            int length = stones.Length;
            Array.Sort(stones);

            if(stones[length - 1] - stones[0] + 1 == length)
                return new int[] {0, 0};

            int max = Math.Max(stones[length - 2] - stones[0] + 1, stones[length - 1] - stones[1] + 1) - (length - 1);
            int min = length;

            for(int i = 0, j = 0; i < length && j + 1 < length; i++){
                while(j + 1 < length && stones[j + 1] - stones[i] + 1 <= length){
                    j++;
                }

                if(j - i + 1 == length - 1 && stones[j] - stones[i] + 1 == length - 1)
                    min = Math.Min(min, 2);
                else
                    min = Math.Min(min, length - (j - i + 1));
            }

            return new int[] { min, max};
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1033
    /// title: 移动石子直到连续
    /// problems: https://leetcode.cn/problems/moving-stones-until-consecutive/
    /// date: 20230430
    /// </summary>
    public static class Solution1033
    {
        public static int[] NumMovesStones(int a, int b, int c) {
            var stones = new int[]{a, b, c};
            Array.Sort(stones);
            int min = 0;
            int max = 0;
            if(stones[2] - stones[0] == 2)
                min = 0;
            else if(stones[1] - stones[0] <= 2 || stones[2] - stones[1] <= 2)
                min = 1;
            else
                min = 2;
            
            max = stones[2] - stones[0] - 2;
            return new int[]{min, max};
        }   
    }
}
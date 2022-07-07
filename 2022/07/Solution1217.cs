using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1217
    /// title: 玩筹码
    /// problems: https://leetcode.cn/problems/minimum-cost-to-move-chips-to-the-same-position/
    /// date: 20220708
    /// </summary>
    public static class Solution1217
    {
        public static int MinCostToMoveChips(int[] position) {
            int sum1 = 0, sum2 = 0;
            
            for(int i = 0; i < position.Length; i++){
                if(position[i] % 2 == 1)
                    sum1++;
                else
                    sum2++;
            }

            return Math.Min(sum1, sum2);
        }
    }
}
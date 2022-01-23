using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2029
    /// title: 石子游戏 IX
    /// problems: https://leetcode-cn.com/problems/stone-game-ix/
    /// date: 20220120
    /// </summary>
    public static class Solution2029
    {
        public static bool StoneGameIX(int[] stones) {
            int length = stones.Length;
            var count =  new int[3];

            for(int i = 0; i < length; i++){
                stones[i] %= 3;
                count[stones[i]]++;
            }

            if(count[0] % 2 == 0)
                return count[1] >= 1 && count[2] >= 1;
            
            return Math.Abs(count[1] - count[2]) > 2;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 50
    /// title: 宝石补给
    /// problems: https://leetcode.cn/problems/WHnhjV/?envType=daily-question&envId=2023-09-15
    /// date: 20230915
    /// type: lcp
    /// </summary>
    public static class Solution_lcp_50
    {
        public static int GiveGem(int[] gem, int[][] operations) {
            int n = gem.Length;
            foreach(var operation in operations){
                (int x, int y) = (operation[0], operation[1]);
                
                int give = gem[x] / 2;
                gem[y] += give;
                gem[x] -= give;
            }

            int max = -1;
            int min = int.MaxValue;
            foreach(var num in gem){
                max = Math.Max(max, num);
                min = Math.Min(min, num);
            }

            return max - min;
        }
    }
}
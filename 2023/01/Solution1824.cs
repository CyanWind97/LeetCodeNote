using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1824
    /// title: 最少侧跳次数
    /// problems: https://leetcode.cn/problems/minimum-sideway-jumps/
    /// date: 20230121
    /// </summary>
    public static class Solution1824
    {
        // 参考解答 动态规划
        public static int MinSideJumps(int[] obstacles) {
            int n = obstacles.Length - 1;
            int[] d = new int[3];
            Array.Fill(d, 1);
            d[1] = 0;
            for (int i = 1; i <= n; i++) {
                int minCnt = int.MaxValue;
                for (int j = 0; j < 3; j++) {
                    if (j == obstacles[i] - 1) 
                        d[j] = int.MaxValue;
                    else 
                        minCnt = Math.Min(minCnt, d[j]);
                    
                }
                for (int j = 0; j < 3; j++) {
                    if (j == obstacles[i] - 1) 
                        continue;
                    
                    d[j] = Math.Min(d[j], minCnt + 1);
                }
            }

            return Math.Min(Math.Min(d[0], d[1]), d[2]);
        }
    }
}
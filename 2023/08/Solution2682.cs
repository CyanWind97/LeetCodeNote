using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2682
    /// title: 找出转圈游戏输家
    /// problems: https://leetcode.cn/problems/find-the-losers-of-the-circular-game/
    /// date: 20230816
    /// </summary>
    public static class Solution2682
    {
        public static int[] CircularGameLosers(int n, int k) {
            var visit = new bool[n];
            for(int i = k, j = 0; !visit[j]; i += k){
                visit[j] = true;
                j = (j + i) % n;
            }

            return Enumerable.Range(1, n).Where(i => !visit[i - 1]).ToArray();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 514
    /// title: 自由之路
    /// problems: https://leetcode.cn/problems/freedom-trail/description/?envType=daily-question&envId=2024-01-29
    /// date: 20240129
    /// </summary>
    public static class Solution514
    {
        public static int FindRotateSteps(string ring, string key) {
            int n = ring.Length;
            int m = key.Length;
            var pos = Enumerable.Range(0, 26).Select(_ => new List<int>()).ToArray();

            for(int i = 0; i < n; i++){
                pos[ring[i] - 'a'].Add(i);
            }

            var dp = new int[m, n];
            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    dp[i, j] = int.MaxValue / 2;
                }
            }
            
            foreach(var i in pos[key[0] - 'a']){
                dp[0, i] = Math.Min(i, n - i) + 1;
            }

            for(int i = 1; i < m; i++){
                foreach(var j in pos[key[i] - 'a']){
                    foreach(var k in pos[key[i - 1] - 'a']){
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, k] + Math.Min(Math.Abs(j - k), n - Math.Abs(j - k)) + 1);
                    }
                }
            }

            return Enumerable.Range(0, n)
                    .Select(i => dp[m - 1, i])
                    .Min();
        }
    }
}
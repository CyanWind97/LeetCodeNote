using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1000
    /// title: 合并石头的最低成本
    /// problems: https://leetcode.cn/problems/minimum-cost-to-merge-stones/
    /// date: 20230404
    /// </summary>
    public static class Solution1000
    {
        // 参考解答
        // 状态压缩 dp
        public static int MergeStones(int[] stones, int k) {
            int n = stones.Length;
            if(stones.Length == 1)
                return 0;
            
            if((n - 1) % (k - 1) != 0)
                return -1;
             
            const int INF = 0x3f3f3f3f;
            var dp = new int[n, n];
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    dp[i, j] = INF;
                }
            }

            var sum = new int[n + 1];
            for(int i = 0; i < n; i++){
                dp[i, i] = 0;
                sum[i + 1] = sum[i] + stones[i];
            }

            for(int len = 2; len <= n; len++){
                for(int l = 0; l < n && l + len - 1 < n; l++){
                    int r = l + len - 1;
                    for(int p = l; p < r; p += k - 1){
                        dp[l, r] = Math.Min(dp[l, r], dp[l, p] + dp[p + 1, r]);
                    }

                    if((r - l) % (k - 1) == 0)
                        dp[l, r] += sum[r + 1] - (l == 0 ? 0 : sum[l]);
                }
            }

            return dp[0, n - 1];
        }   
    }
}
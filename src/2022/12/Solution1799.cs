using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1799
    /// title: N 次操作后的最大分数和
    /// problems: https://leetcode.cn/problems/maximize-score-after-n-operations/
    /// date: 20221222
    /// </summary>
    public static class Solution1799
    {
        // 参考解答
        // dp
        public static int MaxScore(int[] nums) {
            int Count(int n){
                int ans = 0;
                while(n > 0){
                    n = n&(n-1);
                    ans++;
                }
                return ans;
            }

            int GCD(int x, int y) {
                return y == 0 ? x : GCD(y, x % y);
            }

            int n = nums.Length;
            var dp = new int[1<<n];
            for(int i = 0; i < n; ++i){
                for(int j = i+1; j < n; ++j){
                    dp[(1<<i)|(1<<j)] = GCD(nums[i],nums[j]);
                }
            }
            
            for(int i = 1; i < (1<<n); ++i){
                if(Count(i) % 2 == 1) 
                    continue;
                
                for(int j = i; j != 0; j = (j-1)&i){
                    if(Count(i) - Count(j) == 2){
                        dp[i] = Math.Max(dp[i],dp[j] + (Count(i)/2)*dp[i^j]);
                    }
                }
            }


            return dp[(1 << n) - 1];
        }
    }
}
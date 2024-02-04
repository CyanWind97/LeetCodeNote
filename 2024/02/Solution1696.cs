using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1696
    /// title: 跳跃游戏 VI
    /// problems: https://leetcode.cn/problems/jump-game-vi/description/?envType=daily-question&envId=2024-02-05
    /// date: 20240205
    /// </summary>
    public static class Solution1696
    {
        public static int MaxResult(int[] nums, int k) {
            int n = nums.Length;
            var dp = new int[n];
            dp[0] = nums[0];
            var deque = new List<int>();
            var start = 0;
            
            deque.Add(0);
            for(int i = 1; i < n; i++){
                while(deque.Count - start > 0 && deque[start] < i - k)
                    start++;
                
                dp[i] = dp[deque[start]] + nums[i];;
                while(deque.Count - start > 0 && dp[deque.Last()] <= dp[i])
                    deque.RemoveAt(deque.Count - 1);

                deque.Add(i);
            }

            return dp[n - 1];
        }
    }
}
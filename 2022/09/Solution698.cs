using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 698
    /// title: 划分为k个相等的子集
    /// problems: https://leetcode.cn/problems/partition-to-k-equal-sum-subsets/
    /// date: 20220920
    /// </summary>
    public static class Solution698
    {
        // 参考解答
        // 状态压缩 + 动态规划
        public static bool CanPartitionKSubsets(int[] nums, int k) {
            int sum = nums.Sum();
            if (sum % k != 0) 
                return false;
            
            int per = sum / k;
            Array.Sort(nums);
            int n = nums.Length;
            if (nums[n - 1] > per) 
                return false;
            
            var dp = new bool[1 << n];
            var curSum = new int[1 << n];
            dp[0] = true;
            for (int i = 0; i < 1 << n; i++) {
                if (!dp[i]) {
                    continue;
                }
                for (int j = 0; j < n; j++) {
                    if (curSum[i] + nums[j] > per) {
                        break;
                    }
                    if (((i >> j) & 1) == 0) {
                        int next = i | (1 << j);
                        if (!dp[next]) {
                            curSum[next] = (curSum[i] + nums[j]) % per;
                            dp[next] = true;
                        }
                    }
                }
            }

            return dp[(1 << n) - 1];
        }   
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 416
/// title: 分割等和子集
/// problems: https://leetcode.cn/problems/partition-equal-subset-sum
/// date: 20250407
/// </summary>
public static class Solution416
{
    public static bool CanPartition(int[] nums) {
        int sum = 0;
        foreach (int num in nums) {
            sum += num;
        }
        
        // 如果总和为奇数，无法分割成两个相等的子集
        if (sum % 2 != 0) {
            return false;
        }
        
        int target = sum / 2;
        int n = nums.Length;
        
        // dp[i]表示是否可以选择一些数字使其和为i
        bool[] dp = new bool[target + 1];
        // 初始化：和为0总是可能的（不选择任何元素）
        dp[0] = true;
        
        foreach (int num in nums) {
            // 从后往前遍历，避免重复使用同一个元素
            for (int i = target; i >= num; i--) {
                // 对于当前值i，可以选择不使用num或使用num
                dp[i] = dp[i] || dp[i - num];
            }
        }
        
        return dp[target];
    }
}

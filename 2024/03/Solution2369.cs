using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 2369
/// title: 检查数组是否存在有效划分
/// problems: https://leetcode.cn/problems/check-if-there-is-a-valid-partition-for-the-array/description/?envType=daily-question&envId=2024-03-01
/// date: 20240301
/// </summary> 
public static class Solution2369
{
    public static bool ValidPartition(int[] nums) {
        int length = nums.Length;
        var dp = new bool[length + 1];
        dp[0] = true;

        bool ValidTree(int start)
            => (nums[start] == nums[start + 1] && nums[start] == nums[start + 2])
            || (nums[start + 2] - nums[start + 1] == 1 && nums[start + 1] - nums[start] == 1);
            
        dp[2] = dp[0] && (nums[0] == nums[1]);

        for (int i = 3; i <= length; i++){
            dp[i] = dp[i - 2] && (nums[i - 2] == nums[i - 1]);
            dp[i] = dp[i] || (dp[i - 3] && ValidTree(i - 3));
        }

        return dp[length];
    } 
}

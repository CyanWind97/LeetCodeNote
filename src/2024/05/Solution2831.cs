using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2831
/// title: 找出最长等值子数组
/// problems: https://leetcode.cn/problems/find-the-longest-equal-subarray
/// date: 20240523
/// </summary>
public static class Solution2831
{
    public static int LongestEqualSubarray(IList<int> nums, int k) {
        int length = nums.Count;
        int result = 0;
        var count = new Dictionary<int, int>();
        for (int i = 0, j = 0; j < length; j++) {
            count.TryAdd(nums[j], 0);
            count[nums[j]]++;
            
            while(j - i + 1 - count[nums[i]] > k) {
                count[nums[i]]--;
                i++;
            }

            result = Math.Max(result, count[nums[j]]);
        }

        return result;
    }
}

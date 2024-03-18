using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1793
/// title: 好子数组的最大分数
/// problems: https://leetcode.cn/problems/maximum-score-of-a-good-subarray
/// date: 20240319
/// </summary>
public static class Solution1793
{
    public static int MaximumScore(int[] nums, int k) {
        int length = nums.Length;
        int left = k - 1;
        int right = k + 1;
        int result = 0;

        int i = nums[k];
       do{
            while(left >= 0 && nums[left] >= i)
                left--;

            while(right < length && nums[right] >= i)
                right++;
            
            result = Math.Max(result, i * (right - left - 1));
            i--;
        }while(left >= 0 || right < length);

        return result;
    }
}

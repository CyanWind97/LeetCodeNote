using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2779
/// title: 数组的最大美丽值
/// problems: https://leetcode.cn/problems/maximum-beauty-of-an-array-after-applying-operation
/// date: 20240615
/// </summary>
public static class Solution2779
{
    // 参考解答
    // 排序 + 滑动窗口
    public static int MaximumBeauty(int[] nums, int k) {
        int length = nums.Length;
        Array.Sort(nums);
        int result = 0;

        for(int i = 0, j = 0; i < length; i++){
            while(nums[i] - 2 * k > nums[j])
                j++;

            result = Math.Max(result, i - j + 1);
        }

        return result;
    }
}

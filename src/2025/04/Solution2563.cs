using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2563
/// title: 统计公平数对的数目
/// problems: https://leetcode.cn/problems/count-the-number-of-fair-pairs
/// date: 20250419
/// </summary>
public static class Solution2563
{
    public static long CountFairPairs(int[] nums, int lower, int upper) {
         // 先对数组进行排序
        Array.Sort(nums);

        long CountPairsSumLessThanOrEqual(int target) {
            long count = 0;
            int left = 0;
            int right = nums.Length - 1;
            
            while (left < right) {
                if (nums[left] + nums[right] <= target) {
                    // 如果当前左右指针的和小于等于target
                    // 那么右指针到left+1之间的所有元素与left都能形成和小于等于target的对
                    count += right - left;
                    left++;
                } else {
                    // 否则，需要减小和，所以移动右指针
                    right--;
                }
            }
            
            return count;
        }
        
        // 计算满足和小于等于某值的对数，再相减得到目标范围内的对数
        return CountPairsSumLessThanOrEqual(upper) - CountPairsSumLessThanOrEqual(lower - 1);
    }
}

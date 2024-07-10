using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2972
/// title:  计移除递增子数组的数目 II
/// problems: https://leetcode.cn/problems/count-the-number-of-incremovable-subarrays-ii
/// date: 20240711
/// </summary>
public static class Solution2972
{
    // 参考解答
    public static long IncremovableSubarrayCount(int[] nums) {
        long result = 0;
        int length = nums.Length;
        int l = 0;
        while(l < length - 1){
            if (nums[l] >= nums[l + 1])
                break;

            l++;
        }

        if (l == length - 1)
            return (long)length * (length + 1) / 2;
        
        result += l + 2;

        for(int r = length - 1; r > 0; r--){
            if (r < length - 1 && nums[r] >= nums[r + 1])
                break;

            while(l >= 0 && nums[l] >= nums[r])
                l--;
            
            result += l + 2;
        }
        
        return result;
    }
}

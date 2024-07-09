using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2970
/// title:  统计移除递增子数组的数目 I
/// problems: https://leetcode.cn/problems/count-the-number-of-incremovable-subarrays-i
/// date: 20240710
/// </summary>
public static class Solution2970
{
    // 参考解答
    public static int IncremovableSubarrayCount(int[] nums) {
        int length = nums.Length;
        int result = 0;
        int l = 1;
        while(l < length && nums[l - 1] < nums[l])
            l++;
        
        result += l + (l < length ? 1 : 0);

        for(int r = length - 2; r >= 0; r--){
            while(l > 0 && nums[l - 1] >= nums[r + 1])
                l--;
            
            result += l + (l <= r ? 1 : 0);

            if(nums[r] >= nums[r + 1])
                break;
        }

        return result;
    }
}

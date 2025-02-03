using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 922
/// title: 按奇偶排序数组 II
/// problems: https://leetcode.cn/problems/sort-array-by-parity-ii
/// date: 20250204
/// </summary>
public static class Solution922
{
    public static int[] SortArrayByParityII(int[] nums) {
        int n = nums.Length;
        for(int l = 0, r = 1; l < n; l+=2){
            if ((nums[l] & 1) == 0)
                continue;
            
            while((nums[r] & 1) == 1){
                r += 2;
            }

            (nums[l], nums[r]) = (nums[r], nums[l]);
        }

        return nums;
    }
}

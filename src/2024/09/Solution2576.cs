using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2576
/// title:  求出最多标记下标
/// problems: https://leetcode.cn/problems/find-the-maximum-number-of-marked-indices
/// date: 20240912
/// </summary>
public static class Solution2576
{
    public static int MaxNumOfMarkedIndices(int[] nums) {
        Array.Sort(nums);
        int n = nums.Length;
        int m  = n / 2;
        int result = 0;
        for(int i = 0, j = m; i < m && j < n; i++){
            while(j < n && 2 * nums[i] > nums[j]){
                j++;
            }

            if(j < n){
                result += 2;
                j++;
            }
        }

        return result;
    }
}

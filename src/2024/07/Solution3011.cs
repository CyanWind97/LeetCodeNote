using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3011
/// title:  判断一个数组是否可以变为有序
/// problems: https://leetcode.cn/problems/find-if-array-can-be-sorted
/// date: 20240713
/// </summary>
public static class Solution3011
{
    public static bool CanSortArray(int[] nums) {
        int currOnes =  int.PopCount(nums[0]);
        int lastMax = 0;
        int max =  nums[0];

        for(int i = 1; i < nums.Length; i++){
            int ones = int.PopCount(nums[i]);
            if (ones != currOnes){
                lastMax = max;
                max =  nums[i];
                currOnes = ones;
            }else{
                max = Math.Max(max, nums[i]);
            }
            
            if (nums[i] < lastMax)
                return false;
        }

        return true;
    }
}

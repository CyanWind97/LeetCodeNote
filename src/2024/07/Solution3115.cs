using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3115
/// title: 质数的最大距离
/// problems: https://leetcode.cn/problems/maximum-prime-difference
/// date: 20240702
/// </summary>
public static class Solution3115
{
    public static int MaximumPrimeDifference(int[] nums) {
        bool IsPrime(int num){
            if (num < 2)
                return false;
            
            for(int i = 2; i * i <= num; i++){
                if (num % i == 0)
                    return false;
            }

            return true;
        }

        int n = nums.Length;
        (int l, int r) = (0, n - 1);

        while(l < n && !IsPrime(nums[l]))
            l++;

        while(r >= l && !IsPrime(nums[r]))
            r--;

        return r - l;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2614
/// title: 对角线上的质数
/// problems: https://leetcode.cn/problems/prime-in-diagonal
/// date: 20250318
/// </summary>
public static class Solution2614
{
    public static int DiagonalPrime(int[][] nums) {
        int n = nums.Length;
        int result = 0;

        static bool IsPrime(int num) {
            if (num < 2) 
                return false;
            
            for (int i = 2; i * i <= num; i++) {
                if (num % i == 0) 
                    return false;
            }

            return true;
        }

        for (int i = 0; i < n; i++) {
            if (IsPrime(nums[i][i])) 
                result = Math.Max(result, nums[i][i]);
            
            if (IsPrime(nums[i][n - 1 - i]))
                result = Math.Max(result, nums[i][n - 1 - i]);
        }

        return result;
    }
}

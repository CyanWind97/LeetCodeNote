using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3153
/// title: 所有数对中数位不同之和
/// problems: https://leetcode.cn/problems/sum-of-digit-differences-of-all-pairs
/// date: 20240830
/// </summary>
public static class Solution3153
{
    public static long SumDigitDifferences(int[] nums) {
        int n = 0;
        for(int x = nums[0]; x > 0; x /= 10)
            n++;
        
        var counts = new int[n, 10];
        long result = 0;

        for(int i = 0; i < nums.Length; i++){
            var num = nums[i];
            for(int j = 0, x = num; x > 0; x /= 10, j++){
                int curr = x % 10;
                result += i - counts[j, curr];
                counts[j, curr]++;
            }
        }

        return result;
    }   
}

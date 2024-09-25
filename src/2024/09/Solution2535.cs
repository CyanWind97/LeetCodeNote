using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2535
/// title: 数组元素和与数字和的绝对差
/// problems: https://leetcode.cn/problems/difference-between-element-sum-and-digit-sum-of-an-array
/// date: 20240926
/// </summary>
public static class Solution2535
{
    public static int DifferenceOfSum(int[] nums) {
        int sum = 0;
        int digitSum = 0;
        foreach(var num in nums){
            sum += num;

            int x = num;
            while(x > 0){
                digitSum += x % 10;
                x /= 10;
            }
        }

        return Math.Abs(sum - digitSum);
    }
}

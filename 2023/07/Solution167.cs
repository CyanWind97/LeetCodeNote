using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 167
    /// title:  两数之和 II - 输入有序数组
    /// problems: https://leetcode.cn/problems/two-sum-ii-input-array-is-sorted/
    /// date: 20230708
    /// </summary>
    public static class Solution167
    {
        public static int[] TwoSum(int[] numbers, int target) {
            int length = numbers.Length;
            int left = 0;
            int right = length - 1;
            while(left < right){
                int sum = numbers[left] + numbers[right];
                if(sum == target)
                    return new int[]{left + 1, right + 1};
                else if(sum < target)
                    left++;
                else
                    right--;
            }

            return Array.Empty<int>();
        }
    }
}
using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 556
    /// title: 下一个更大元素 III
    /// problems: https://leetcode.cn/problems/next-greater-element-iii/
    /// date: 20220703
    /// </summary>
    public static class Solution556
    {
        public static int NextGreaterElement(int n) {
            var nums = n.ToString().ToCharArray();
            int length = nums.Length;
            int i = length - 2;

            while(i >= 0 && nums[i] >= nums[i + 1]){
                i--;
            }

            if(i < 0)
                return -1;

            int j = length - 1;
            while(j >= 0 && nums[i] >= nums[j]){
                j--;
            }

            (nums[i], nums[j]) = (nums[j], nums[i]);
            Array.Reverse(nums, i + 1, length - i - 1);

            var result = long.Parse(new string(nums));

            return result > int.MaxValue ? -1 : (int)result;
        }
    }
}
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 961
    /// title: 在长度 2N 的数组中找出重复 N 次的元素
    /// problems: https://leetcode.cn/problems/n-repeated-element-in-size-2n-array/
    /// date: 20220521
    /// </summary>
    public static class Solution961
    {
        public static int RepeatedNTimes(int[] nums) {
            int n = nums.Length / 2;
            var set = new HashSet<int>();
            
            for(int i = 0; i <= n; i++){
                if(!set.Add(nums[i]))
                    return nums[i];
            }

            return -1;
        }
    }
}
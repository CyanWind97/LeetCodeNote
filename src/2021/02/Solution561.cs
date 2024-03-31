using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 561
    /// title:  数组拆分 I
    /// problems: https://leetcode-cn.com/problems/array-partition-i/
    /// date: 20210216
    /// </summary>
    public class Solution561
    {
        public static int ArrayPairSum(int[] nums) {
            int n = nums.Length / 2;
            Array.Sort(nums);
            int sum = 0;
            for(int i = 0; i < 2 * n; i += 2){
                sum += nums[i];
            }

            return sum;
        }
    }
}
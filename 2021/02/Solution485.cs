using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 485
    /// title: 最大连续1的个数
    /// problems: https://leetcode-cn.com/problems/max-consecutive-ones/
    /// date: 20210215
    /// </summary>
    public static class Solution485
    {
        public static int FindMaxConsecutiveOnes(int[] nums) {
            int length = nums.Length;
            int resut = 0;
            int cur = 0;
            foreach(var num in nums){
                if(num == 1){
                    cur++;
                }else{
                    resut = Math.Max(resut, cur);
                    cur = 0;
                }
            }

            return Math.Max(resut, cur);
        }
    }
}
using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1413
    /// title:  逐步求和得到正数的最小值
    /// problems: https://leetcode.cn/problems/minimum-value-to-get-positive-step-by-step-sum/
    /// date: 20220809
    /// </summary>
    public static class Solution1413
    {
        public static int MinStartValue(int[] nums) {
            int startValue = 1;
            int sum = 0;
            
            foreach(var num in nums){
                sum += num;
                if(sum < 0)
                    startValue = Math.Max(startValue, -sum + 1);
            }
            
            return startValue;
        }
    }
}
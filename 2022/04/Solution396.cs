using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 396
    /// title: 旋转函数
    /// problems: https://leetcode-cn.com/problems/rotate-function/
    /// date: 20220422
    /// </summary>    
    public static class Solution396
    {
        public static int MaxRotateFunction(int[] nums) {
            var length = nums.Length;
            var sum = nums.Sum();
            var cur = Enumerable.Range(0, length)
                        .Aggregate(0, (sum, i) => sum +=  i * nums[i]);
            
            var result = cur;
            
            for(int i = 1; i < length; i++){
                cur += (sum - length * nums[length - i]);
                result = Math.Max(cur, result);
            }

            return result;
        }
    }
}
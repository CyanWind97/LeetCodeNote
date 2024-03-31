using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2455
    /// title: 可被三整除的偶数的平均值
    /// problems: https://leetcode.cn/problems/average-value-of-even-numbers-that-are-divisible-by-three/
    /// date: 20230529
    /// </summary>
    public static class Solution2455
    {
        public static int AverageValue(int[] nums) {
            var sum = 0;
            var count = 0;
            for(int i = 0; i < nums.Length; i++){
                if(nums[i] % 6 == 0){
                    sum += nums[i];
                    count++;
                }
            }

            return count == 0 ? 0 : sum / count;
        }
    }
}
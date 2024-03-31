using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 136
    /// title: 只出现一次的数字
    /// problems: https://leetcode.cn/problems/single-number/?envType=daily-question&envId=2023-10-14
    /// date: 20231014
    /// </summary>
    public static class Solution136
    {
        public static int SingleNumber(int[] nums) {
            int result = 0;
            foreach(var num in nums){
                result ^= num;
            }

            return result;
        }
    }
}
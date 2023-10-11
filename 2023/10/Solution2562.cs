using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2562
    /// title: 找出数组的串联值
    /// problems: https://leetcode.cn/problems/find-the-array-concatenation-value/?envType=daily-question&envId=2023-10-12
    /// date: 20231012
    /// </summary>
    public static class Solution2562
    {
        public static long FindTheArrayConcVal(int[] nums) {
            int length = nums.Length;    
            long sum = 0;
            for(int i = 0; i < length / 2; i++){
                (int a, int b) = (nums[i], nums[^(i + 1)]);
                long c = 1;
                for(int d = b;  d > 0; d /= 10)
                    c *= 10;
                    
                sum += a * c + b;
            }

            if(length % 2 == 1)
                sum += nums[length / 2];

            return sum;
        }
    }
}
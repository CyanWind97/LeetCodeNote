using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1827
    /// title:  最少操作使数组递增
    /// problems: https://leetcode.cn/problems/minimum-operations-to-make-the-array-increasing/
    /// date: 20221211
    /// </summary>
    public static class Solution1827
    {
        public static int MinOperations(int[] nums) {
            int pre = nums[0] - 1;
            int count = 0;
            foreach(var num in nums){
                pre = Math.Max(pre + 1, num);
                count += pre - num;
            }

            return count;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2357
    /// title: 使数组中所有元素都等于零
    /// problems: https://leetcode.cn/problems/make-array-zero-by-subtracting-equal-amounts/
    /// date: 20230224
    /// </summary>
    public static class Solution2357
    {
        public static int MinimumOperations(int[] nums) {
            return nums.Distinct().Count(num => num != 0);
        }
    }
}
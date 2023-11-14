using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2656
    /// title: K 个元素的最大和
    /// problems: https://leetcode.cn/problems/maximum-sum-with-exactly-k-elements/description/?envType=daily-question&envId=2023-11-15
    /// date: 20231115
    /// </summary>
    public static class Solution2656
    {
        public static int MaximizeSum(int[] nums, int k) {
            var max = nums.Max();
            return (max + max + k - 1) * k / 2;
        }
    }
}
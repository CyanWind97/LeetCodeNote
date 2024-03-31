using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2859
    /// title: 计算 K 置位下标对应元素的和
    /// problems: https://leetcode.cn/problems/sum-of-values-at-indices-with-k-set-bits/description/?envType=daily-question&envId=2024-01-25
    /// date: 20240125
    /// </summary>
    public static class Solution2859
    {
        public static int SumIndicesWithKSetBits(IList<int> nums, int k) {

            int BitCount(int i) {
                i = i - ((i >> 1) & 0x55555555);
                i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
                i = (i + (i >> 4)) & 0x0f0f0f0f;
                i = i + (i >> 8);
                i = i + (i >> 16);
                return i & 0x3f;
            }

            return nums.Where((num, i) => BitCount(i) == k).Sum();
        }
    }
}
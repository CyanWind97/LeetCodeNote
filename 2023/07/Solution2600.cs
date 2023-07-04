using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2600
    /// title:  K 件物品的最大和
    /// problems: https://leetcode.cn/problems/k-items-with-the-maximum-sum/
    /// date: 20230705
    /// </summary>
    public static class Solution2600
    {
        public static int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k) {
            return Math.Min(numOnes, k)- Math.Max(0, k - numOnes - numZeros);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1711
    /// title: 大餐计数
    /// problems: https://leetcode-cn.com/problems/count-good-meals/
    /// date: 20210707
    /// </summary>
    public static class Solution1711
    {
        public static int CountPairs(int[] deliciousness) {
            const int MOD = 1000000007;
            int maxVal = deliciousness.Max();
            int maxSum = maxVal * 2;
            int pairs = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            int n = deliciousness.Length;
            for (int i = 0; i < n; i++) {
                int val = deliciousness[i];
                for (int sum = 1; sum <= maxSum; sum <<= 1) {
                    int count = 0;
                    dictionary.TryGetValue(sum - val, out count);
                    pairs = (pairs + count) % MOD;
                }
                if (dictionary.ContainsKey(val)) {
                    dictionary[val]++;
                } else {
                    dictionary.Add(val, 1);
                }
            }
            return pairs;
        }
    }
}
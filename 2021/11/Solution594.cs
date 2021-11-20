using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 594
    /// title: 最长和谐子序列
    /// problems: https://leetcode-cn.com/problems/longest-harmonious-subsequence/
    /// date: 20211120
    /// </summary>
    public static class Solution594
    {
        public static int FindLHS(int[] nums) {
            var map = new Dictionary<int, int>();
            int res = 0;
            foreach (int num in nums) {
                if (map.ContainsKey(num)) 
                    map[num]++;
                else 
                    map.Add(num, 1);
            }
            foreach (int key in map.Keys) {
                if (map.ContainsKey(key + 1))
                    res = Math.Max(res, map[key] + map[key + 1]);
                
            }
            return res;
        }
    }
}
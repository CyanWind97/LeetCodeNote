using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2735
    /// title: 收集巧克力
    /// problems: https://leetcode.cn/problems/collecting-chocolates/description/?envType=daily-question&envId=2023-12-28
    /// date: 20231228
    /// </summary>
    public static class Solution2735
    {
        public static long MinCost(int[] nums, int x) {
            int n = nums.Length;
            var f = nums.ToArray();
            var result = nums.Sum(num => (long)num);

            for(int k = 1; k < n; k++){
                for(int i = 0; i < n; i++){
                    f[i] = Math.Min(f[i], nums[(i + k) % n]);
                }

                result = Math.Min(result, f.Sum(num => (long)num) + (long)x * k);
            }

            return result;
        }
    }
}
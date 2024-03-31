using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 446
    /// title: 等差数列划分 II - 子序列
    /// problems: https://leetcode-cn.com/problems/arithmetic-slices-ii-subsequence/
    /// date: 20210811
    /// </summary>
    public static class Solution446
    {
        public static int NumberOfArithmeticSlices(int[] nums) {
            int ans = 0;
            int n = nums.Length;
            var f = new Dictionary<long, int>[n];
            for (int i = 0; i < n; ++i) {
                f[i] = new Dictionary<long, int>();
            }
            
            for (int i = 0; i < n; ++i) {
                for (int j = 0; j < i; ++j) {
                    long d = 1L * nums[i] - nums[j];
                    int cnt = f[j].ContainsKey(d) ? f[j][d] : 0;
                    ans += cnt;
                    if (f[i].ContainsKey(d)) {
                        f[i][d] += cnt + 1;
                    } else {
                        f[i].Add(d, cnt + 1);
                    }
                }
            }
            return ans;
        }
    }
}
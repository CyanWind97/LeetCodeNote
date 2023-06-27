using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1681
    /// title: 最小不兼容性
    /// problems: https://leetcode.cn/problems/minimum-incompatibility/
    /// date: 20230628
    /// </summary>
    public static class Solution1681
    {
        // 参考解答
        // 状态压缩 + DP
        // Todo: 还是觉得有更好的解法, 这些题感觉是把简单问题复杂化，滥用状态压缩dp
        public static int MinimumIncompatibility(int[] nums, int k) {
            int n = nums.Length;
            int m = n / k;
            int[] g = new int[1 << n];

            int BitCount(int x) {
                int cnt = 0;
                while (x > 0) {
                    x &= x - 1;
                    ++cnt;
                }
                return cnt;
            }

            Array.Fill(g, -1);
            for (int i = 1; i < 1 << n; ++i) {
                if (BitCount(i) != m) 
                    continue;
                
                var set = new HashSet<int>();
                int mi = 20, mx = 0;
                for (int j = 0; j < n; ++j) {
                    if ((i >> j & 1) == 1) {
                        if (set.Contains(nums[j])) 
                            break;
                        
                        set.Add(nums[j]);
                        mi = Math.Min(mi, nums[j]);
                        mx = Math.Max(mx, nums[j]);
                    }
                }

                if (set.Count == m) 
                    g[i] = mx - mi;
                
            }
            int[] f = new int[1 << n];
            int inf = 1 << 30;
            Array.Fill(f, inf);
            f[0] = 0;
            for (int i = 0; i < 1 << n; ++i) {
                if (f[i] == inf) 
                    continue;
                
                HashSet<int> s = new();
                int mask = 0;
                for (int j = 0; j < n; ++j) {
                    if ((i >> j & 1) == 0 && !s.Contains(nums[j])) {
                        s.Add(nums[j]);
                        mask |= 1 << j;
                    }
                }

                if (s.Count < m) 
                    continue;
                
                for (int j = mask; j > 0; j = (j - 1) & mask) {
                    if (g[j] != -1) {
                        f[i | j] = Math.Min(f[i | j], f[i] + g[j]);
                    }
                }
            }

            return f[(1 << n) - 1] == inf ? -1 : f[(1 << n) - 1];
        }
    }
}
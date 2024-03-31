namespace LeetCodeNote
{
    /// <summary>
    /// no: 940
    /// title: 不同的子序列 II
    /// problems: https://leetcode.cn/problems/distinct-subsequences-ii/
    /// date: 20221014
    /// </summary>

    public static class Solution940
    {
        // 参考解答
        public static int DistinctSubseqII(string s) {
            const int MOD = 1000000007;
            int[] g = new int[26];
            int n = s.Length, total = 0;
            for (int i = 0; i < n; ++i) {
                int oi = s[i] - 'a';
                int prev = g[oi];
                g[oi] = (total + 1) % MOD;
                total = ((total + g[oi] - prev) % MOD + MOD) % MOD;
            }

            return total;
        }
    }
}
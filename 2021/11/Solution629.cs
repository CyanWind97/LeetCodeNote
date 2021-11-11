namespace LeetCodeNote
{
    /// <summary>
    /// no: 629
    /// title:  K个逆序对数组
    /// problems: https://leetcode-cn.com/problems/k-inverse-pairs-array/
    /// date: 20211111
    /// </summary>
    public static class Solution629
    {
        public static int KInversePairs(int n, int k) {
            const int MOD = 1000000007;
            int[,] f = new int[2, k + 1];
            f[0, 0] = 1;
            for (int i = 1; i <= n; ++i) {
                for (int j = 0; j <= k; ++j) {
                    int cur = i & 1, prev = cur ^ 1;
                    f[cur, j] = (j - 1 >= 0 ? f[cur, j - 1] : 0) - (j - i >= 0 ? f[prev, j - i] : 0) + f[prev, j];
                    if (f[cur, j] >= MOD) {
                        f[cur, j] -= MOD;
                    } else if (f[cur, j] < 0) {
                        f[cur, j] += MOD;
                    }
                }
            }
            return f[n & 1, k];
        }
    }
}
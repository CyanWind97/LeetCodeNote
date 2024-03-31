namespace LeetCodeNote
{
    /// <summary>
    /// no: 2055
    /// title: 蜡烛之间的盘子
    /// problems: https://leetcode-cn.com/problems/plates-between-candles/
    /// date: 20220308
    /// </summary>
    public static class Solution2055
    {
        public static int[] PlatesBetweenCandles(string s, int[][] queries) {
            int n = s.Length;
            int[] preSum = new int[n];
            for (int i = 0, sum = 0; i < n; i++) {
                if (s[i] == '*') {
                    sum++;
                }
                preSum[i] = sum;
            }
            int[] left = new int[n];
            for (int i = 0, l = -1; i < n; i++) {
                if (s[i] == '|') {
                    l = i;
                }
                left[i] = l;
            }
            int[] right = new int[n];
            for (int i = n - 1, r = -1; i >= 0; i--) {
                if (s[i] == '|') {
                    r = i;
                }
                right[i] = r;
            }
            int[] ans = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++) {
                int[] query = queries[i];
                int x = right[query[0]], y = left[query[1]];
                ans[i] = x == -1 || y == -1 || x >= y ? 0 : preSum[y] - preSum[x];
            }
            return ans;
        }
    }
}
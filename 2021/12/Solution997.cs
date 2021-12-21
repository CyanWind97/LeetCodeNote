namespace LeetCodeNote
{
    /// <summary>
    /// no: 997
    /// title:  找到小镇的法官
    /// problems: https://leetcode-cn.com/problems/find-the-town-judge/
    /// date: 20211219
    /// </summary>
    public static class Solution997
    {
        /// <summary>
        /// 参考解答 入度 出度
        /// </summary>
        public static int FindJudge(int n, int[][] trust) {
            int[] inDegrees = new int[n + 1];
            int[] outDegrees = new int[n + 1];
            foreach (int[] edge in trust) {
                int x = edge[0], y = edge[1];
                ++inDegrees[y];
                ++outDegrees[x];
            }

            for (int i = 1; i <= n; ++i) {
                if (inDegrees[i] == n - 1 && outDegrees[i] == 0) {
                    return i;
                }
            }
            return -1;
        }
    }
}
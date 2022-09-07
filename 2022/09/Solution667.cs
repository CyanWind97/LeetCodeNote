namespace LeetCodeNote
{
    // <summary>
    /// no: 667
    /// title: 优美的排列 II
    /// problems: https://leetcode.cn/problems/beautiful-arrangement-ii/
    /// date: 20220908
    /// </summary>
    public static class Solution667
    {
        // 参考解答
        public static int[] ConstructArray(int n, int k) {
            int[] result = new int[n];
            int index = 0;
            for (int i = 1; i < n - k; ++i) {
                result[index] = i;
                ++index;
            }

            for (int i = n - k, j = n; i <= j; ++i, --j) {
                result[index] = i;
                ++index;
                if (i != j) {
                    result[index] = j;
                    ++index;
                }
            }

            return result;
        }
    }
}
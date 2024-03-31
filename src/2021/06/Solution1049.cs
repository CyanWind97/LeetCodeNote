using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1049
    /// title: 最后一块石头的重量 II
    /// problems: https://leetcode-cn.com/problems/last-stone-weight-ii/
    /// date: 20210608
    /// </summary>
    public static class Solution1049
    {
        // 参考解答 dp
        // 有放回不会产生额外质量，最终问题转化为求小于sum/2的最大和
        public static int LastStoneWeightII(int[] stones) {
            int sum = stones.Sum();

            int m = sum / 2;
            bool[] dp = new bool[m + 1];
            dp[0] = true;
            foreach (int weight in stones) {
                for (int j = m; j >= weight; --j) {
                    dp[j] = dp[j] || dp[j - weight];
                }
            }
            for (int j = m;; --j) {
                if (dp[j]) {
                    return sum - 2 * j;
                }
            }
        }
    }
}

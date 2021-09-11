namespace LeetCodeNote
{
    /// <summary>
    /// no: 600
    /// title: 不含连续1的非负整数
    /// problems: https://leetcode-cn.com/problems/non-negative-integers-without-consecutive-ones/
    /// date: 20210911
    /// </summary>

    public static class Solution600
    {
        // 参考解答动态规划
        public static int FindIntegers(int n) {
            int[] dp = new int[31];
            dp[0] = dp[1] = 1;

            for (int i = 2; i < 31; ++i) {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            int pre = 0, res = 0;
            for (int i = 29; i >= 0; --i) {
                int val = 1 << i;
                if ((n & val) != 0) {
                    res += dp[i + 1];
                    if (pre == 1)
                        break;
                    
                    pre = 1;
                } else {
                    pre = 0;
                }

                if (i == 0)
                    ++res;
            }

            return res;
        }
    }
}
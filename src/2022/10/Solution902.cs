using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 902
    /// title: 最大为 N 的数字组合
    /// problems: https://leetcode.cn/problems/numbers-at-most-n-given-digit-set/
    /// date: 20221018
    /// </summary>
    public static class Solution902
    {   
        // 参考解答
        // dp
        public static int AtMostNGivenDigitSet(string[] digits, int n) {
            string s = n.ToString();
            int m = digits.Length, k = s.Length;
            int[][] dp = new int[k + 1][];
            for (int i = 0; i <= k; i++) {
                dp[i] = new int[2];
            }
            dp[0][1] = 1;
            for (int i = 1; i <= k; i++) {
                for (int j = 0; j < m; j++) {
                    if (digits[j][0] == s[i - 1]) {
                        dp[i][1] = dp[i - 1][1];
                    } else if (digits[j][0] < s[i - 1]) {
                        dp[i][0] += dp[i - 1][1];
                    } else {
                        break;
                    }
                }
                if (i > 1) {
                    dp[i][0] += m + dp[i - 1][0] * m;
                }
            }
            return dp[k][0] + dp[k][1];
        }


        // 参考解答
        // 数学
        public static int AtMostNGivenDigitSet_1(string[] digits, int n) {
            string s = n.ToString();
            int m = digits.Length, k = s.Length;
            IList<int> bits = new List<int>();
            bool isLimit = true;
            for (int i = 0; i < k; i++) {
                if (!isLimit) {
                    bits.Add(m - 1);
                } else {
                    int selectIndex = -1;
                    for (int j = 0; j < m; j++) {
                        if (digits[j][0] <= s[i]) {
                            selectIndex = j;
                        } else {
                            break;
                        }
                    }
                    if (selectIndex >= 0) {
                        bits.Add(selectIndex);
                        if (digits[selectIndex][0] < s[i]) {
                            isLimit = false;
                        }
                    } else {
                        int len = bits.Count;
                        while (bits.Count > 0 && bits[bits.Count - 1] == 0) {
                            bits.RemoveAt(bits.Count - 1);
                        }
                        if (bits.Count > 0) {
                            bits[bits.Count - 1]--;
                        } else {
                            len--;
                        }
                        while (bits.Count <= len) {
                            bits.Add(m - 1);
                        }
                        isLimit = false;
                    }
                }
            }
            int ans = 0;
            for (int i = 0; i < bits.Count; i++) {
                ans = ans * m + (bits[i] + 1);
            }
            return ans;
        }
    }
}
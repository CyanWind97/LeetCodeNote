using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 730
    /// title: 统计不同回文子序列
    /// problems: https://leetcode.cn/problems/count-different-palindromic-subsequences/
    /// date: 20220610
    /// </summary>
    public static class Solution730
    {   
        // 参考解答 动态规划
        public static int CountPalindromicSubsequences(string s) {
            const int MOD = 1_000_000_007;
            int length = s.Length;
            var dp = new int[length, length];
            var next = new int[length, 4];
            var pre = new int[length, 4];
            for(int i = 0; i < length; i++){
                dp[i, i] = 1;
            }

            var pos = new int[4];
            Array.Fill(pos, -1);

            for(int i = 0; i < length; i++){
                for(int c = 0; c < 4; c++){
                    pre[i, c] = pos[c];
                }

                pos[s[i] - 'a'] = i;
            }

            Array.Fill(pos, length);

            for(int i = length - 1; i >= 0; i--){
                for(int c = 0; c < 4; c++){
                    next[i, c] = pos[c];
                }

                pos[s[i] - 'a'] = i;
            }

            for(int l = 2; l <= length; l++){
                for(int i = 0; i + l <= length; i++){
                    int j = i + l - 1;
                    if(s[i] == s[j]){
                        int low = next[i, s[i] - 'a'];
                        int high = pre[j, s[i] - 'a'];
                        if(low > high)
                            dp[i, j] = (2 + dp[i + 1, j - 1] * 2) % MOD;
                        else if(low == high)
                            dp[i, j] = (1 + dp[i + 1, j - 1] * 2) % MOD;
                        else
                            dp[i, j] = (dp[i + 1, j - 1] * 2 % MOD - dp[low + 1, high - 1] + MOD) % MOD; 
                    }else{
                        dp[i, j] = ((dp[i + 1, j] + dp[i, j - 1]) % MOD - dp[i + 1, j - 1] + MOD) % MOD;
                    }
                }
            }

            return dp[0, length - 1];
        }
    }
}
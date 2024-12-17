using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3292
/// title: 形成目标字符串需要的最少字符串数 II
/// problems: https://leetcode.cn/problems/minimum-number-of-valid-strings-to-form-target-ii
/// date: 20241218
/// </summary>
public static class Solution3292
{
    public static int MinValidStrings(string[] words, string target) {
        int n = target.Length;
        var back = new int[n];

        int[] PrefixFunction(string world){
            var s = $"{world}#{target}";
            int m = s.Length;
            var prefix = new int[m];

            for (int i = 1; i < m; i++) {
                int j = prefix[i - 1];
                while (j > 0 && s[i] != s[j])
                    j = prefix[j - 1];
                if (s[i] == s[j])
                    j++;
                prefix[i] = j;
            }

            return prefix;
        }

        foreach (var word in words) {
            var prefix = PrefixFunction(word);
            int m = word.Length;
            for (int i = 0; i < n; i++) {
                back[i] = Math.Max(back[i], prefix[m + i + 1]);
            }
        }

        var dp = Enumerable.Repeat(1000000000, n + 1).ToArray();
        dp[0] = 0;
        for (int i = 0; i < n; i++){
            dp[i + 1] = dp[i + 1 - back[i]] + 1;
            if (dp[i + 1] > n)
                return -1;
        }

        return dp[n];
    }
}

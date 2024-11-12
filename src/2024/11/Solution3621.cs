using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3621
/// title: 统计满足 K 约束的子字符串数量 II
/// problems: https://leetcode.cn/problems/count-substrings-that-satisfy-k-constraint-ii
/// date: 20241113
/// </summary>
public class Solution3621
{
    // 参考解答
    // 滑动窗口
    public static long[] CountKConstraintSubstrings(string s, int k, int[][] queries) {
        int n = s.Length;
        int[] count = new int[2];
        int[] right = new int[n];
        Array.Fill(right, n);
        long[] prefix = new long[n + 1];
        for (int i = 0, j = 0; j < n; ++j) {
            count[s[j] - '0']++;
            while (count[0] > k && count[1] > k) {
                count[s[i] - '0']--;
                right[i] = j;
                i++;
            }
            prefix[j + 1] = prefix[j] + j - i + 1;
        }

        long[] res = new long[queries.Length];
        for (int q = 0; q < queries.Length; q++) {
            int l = queries[q][0], r = queries[q][1];
            int i = Math.Min(right[l], r + 1);
            long part1 = (long)(i - l + 1) * (i - l) / 2;
            long part2 = prefix[r + 1] - prefix[i];
            res[q] = part1 + part2;
        }
        return res;
    }
}

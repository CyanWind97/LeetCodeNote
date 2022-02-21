using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 838
    /// title: 推多米诺
    /// problems: https://leetcode-cn.com/problems/push-dominoes/
    /// date: 20220221
    /// </summary>
    public static class Solution838
    {
        public static string PushDominoes(string dominoes) {
            char[] s = dominoes.ToCharArray();
            int n = s.Length, i = 0;
            char left = 'L';
            while (i < n) {
                int j = i;
                while (j < n && s[j] == '.') { // 找到一段连续的没有被推动的骨牌
                    j++;
                }
                char right = j < n ? s[j] : 'R';
                if (left == right) { // 方向相同，那么这些竖立骨牌也会倒向同一方向
                    while (i < j) {
                        s[i++] = right;
                    }
                } else if (left == 'R' && right == 'L') { // 方向相对，那么就从两侧向中间倒
                    int k = j - 1;
                    while (i < k) {
                        s[i++] = 'R';
                        s[k--] = 'L';
                    }
                }
                left = right;
                i = j + 1;
            }
            return new string(s);
        }
    }
}
namespace LeetCodeNote
{
    /// <summary>
    /// no: 1332
    /// title: 删除回文子序列
    /// problems: https://leetcode-cn.com/problems/remove-palindromic-subsequences/
    /// date: 20220122
    /// </summary>

    public static class Solution1332
    {
        public static int RemovePalindromeSub(string s) {
            int length = s.Length;
            for (int i = 0; i < length / 2; ++i) {
                if (s[i] != s[length - 1 - i]) {
                    return 2;
                }
            }
            return 1;
        }
    }
}
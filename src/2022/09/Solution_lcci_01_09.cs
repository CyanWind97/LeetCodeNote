namespace LeetCodeNote
{
    /// <summary>
    /// no: 01.09.
    /// title: 01.09. 字符串轮转
    /// problems: https://leetcode.cn/problems/string-rotation-lcci/
    /// date: 20220929
    /// type: 面试题 lcci
    /// </summary>
    public class Solution_lcci_01_09
    {
        public static bool IsFlipedString(string s1, string s2) {
            return s1.Length == s2.Length && (s1 + s1).Contains(s2);
        }
    }
}